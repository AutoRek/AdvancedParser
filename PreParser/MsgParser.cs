using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using ApiSoftware.Library35;
using ApiSoftware.Library35.Parsing;

namespace AutoRek.Message.PreParser
{
	/// <summary>
	/// Parses messages
	/// </summary>
	public class MsgParser
	{
		public const string Help = @"
Parses Messages in a specifed input folder using an AutoRek template 
and outputs the results to the specifed outputfolder.

Parameters:
-I InputFolder	Folder to read messages from.
-A ArchiveFolder Folder to place completed files ({InputFolder}\Archive if not supplied)
-E Error Folder to place completed files ({InputFolder}\Error if not supplied)
-F FileMask		File pattern to restrict read files to Default *.*
-R Recurse		Read subfolders default: false.
-O OutputFolder	Target folder for parsed result files
-T TemplateFile	Path to template file
-M Mode			Parse Mode
					- CSV			- Parse to one (or more) csv files (Default)
					- XML_Element	- Parse to XML as elements
					- XML_Attr		- Parse to XML as attributes
-L LogFile		Path to store log information (logs to console only if blank)
-S Severity		Severity of messages to log to file (default 1)
				- 0 - Info
				- 1 - Warning
				- 2 - Error
";
		public string InputFolder;
		public string ArchiveFolder;
		public string ErrorFolder;
		public string FileMask;
		public bool Recurse;
		public string OutputFolder;
		public string TemplateFile;
		public OutputMode Mode;
		public string LogFile;
		public int Severity;

		private DateTime runStart;
		private int processed;
		private int success;
		private int failed;

		/// <summary>
		/// Initializes a new instance of the <see cref="Parser"/> class.
		/// </summary>
		public MsgParser()
		{
			FileMask = "*.*";
			Mode = OutputMode.CSV;
			Severity = 1;
			runStart = DateTime.Now;
		}

		public void Parse()
		{
			try
			{
				if (string.IsNullOrEmpty(ArchiveFolder))
				{
					ArchiveFolder = Path.Combine(InputFolder, @"Archive");
				}

				if (string.IsNullOrEmpty(ErrorFolder))
				{
					ErrorFolder = Path.Combine(InputFolder, @"Error");
				}

				string[] fileList = null;
				fileList = GetFolderFileList();

				if (fileList == null || fileList.Length == 0)
				{
					WriteLog("No files in input directory", 1);
					return;
				}

				if (string.IsNullOrEmpty(OutputFolder))
				{
					throw new InvalidOperationException("OutputFolder must be specified");
				}

				Parser parser = GetParser();
				foreach (var file in fileList)
				{
					processed++;
					WriteLog(string.Format("Processing file {0}").Values(file));
					try
					{
						if (!File.Exists(file)) throw new FileNotFoundException("Could not find file \"{0}\"".Values(file));
						var fileName = Path.GetFileName(file);
						var content = File.ReadAllText(file);
						var result = parser.Parse(content);

						if (result.IsMatch)
						{
							FileIO.EnsureFolderExists(OutputFolder);

							if (Mode == OutputMode.XML_Element)
							{
								var outputPath = Path.Combine(OutputFolder, fileName + ".xml");
								File.WriteAllText(outputPath, result.ToXml("Xml", false));
							}
							else if (Mode == OutputMode.XML_Attr)
							{
								var outputPath = Path.Combine(OutputFolder, fileName + ".xml");
								File.WriteAllText(outputPath, result.ToXml());
							}
							else
							{
								using (var ds = new DataSet())
								{

									result.Fill(ds, IdMode.RowAndParents, IdStyle.Guid);
									foreach (DataTable table in ds.Tables)
									{
										var outputPath = Path.Combine(OutputFolder, fileName + table.TableName + ".csv");
										table.WriteDelimitedData(outputPath);
									}
								}
							}
							MoveOrRemoveFile(file, ArchiveFolder);
							success++;
							WriteLog("File \"{0}\" Loaded Successfully".Values(file));
						}
						else
						{
							throw new SyntaxErrorException(result.GetErrorText());
						}
					}
					catch (Exception ex)
					{
						failed++;
						WriteLog("Failed to process file \"{0}\" Message {1}".Values(file, ex.Message), 3);
						MoveOrRemoveFile(file, ErrorFolder);
					}
				}

				WriteLog("Run complete {0} of {1} files processed in {2} Seconds.".Values(success, processed, DateTime.Now.Subtract(runStart).TotalSeconds), 1);
				if (failed > 0)
				{
					WriteLog("{0} files failed - see log for details".Values(failed), 2);
				}

			}
			catch (Exception e)
			{
				WriteLog(e.Message + " - Program Terminated", 3);
			}
		}

		private Parser GetParser()
		{
			if (string.IsNullOrEmpty(TemplateFile)) throw new InvalidOperationException("Template file must be specified");
			if (!File.Exists(TemplateFile)) throw new InvalidOperationException("Template file does not exist at \"{0}\"".Values(TemplateFile));

			var grammer = File.ReadAllText(TemplateFile);
			return Parser.LoadXml(grammer);
		}

		/// <summary>
		/// Gets the folder file list.
		/// </summary>
		/// <returns></returns>
		/// <exception cref="System.IO.FileNotFoundException">Folder  + InputFolder +  not found</exception>
		private string[] GetFolderFileList()
		{
			// Build the file list from the folder
			if (!Directory.Exists(InputFolder)) throw new FileNotFoundException("Folder " + InputFolder + " not found");
			return Directory.GetFiles(InputFolder, FileMask, Recurse ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly);
		}

		private void WriteLog(string message, int level = 0)
		{
			Console.WriteLine(message);
			if (!string.IsNullOrEmpty(LogFile) && level >= Severity)
			{
				try
				{
					File.AppendAllText(LogFile, message);
				}
				catch (Exception e)
				{
					Console.WriteLine("Failed to log message to file - {0}".Values(e.Message));
				}
			}
		}

		private void MoveOrRemoveFile(string file, string targetFolder)
		{
			if (string.IsNullOrEmpty(file) || !File.Exists(file)) return;
			if (string.IsNullOrEmpty(targetFolder))
			{
				File.Delete(file);
			}
			else
			{
				targetFolder = Path.Combine(targetFolder, runStart.ToString("yyyyyMMddHHmmssffff"));
				var targetFile = Path.Combine(file, targetFolder, Path.GetFileName(file));

				FileIO.EnsureFolderExists(targetFolder);
				File.Move(file, targetFile);
			}
		}
	}
}
