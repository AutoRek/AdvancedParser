using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ApiSoftware.Library35;
using ApiSoftware.Library35.Parsing;
using System.Diagnostics;
using System.Xml;
using System.IO;

namespace NewParser
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Editor : Form
	{
		private List<string> Inputs = new List<string>();
		private List<OutputNode> Results = new List<OutputNode>();
		private string filePath = string.Empty;
		private int Passed { get; set; }
		private int Failed { get; set; }
		private int firstFail;
		private string error;

		/// <summary>
		/// Initializes a new instance of the <see cref="Editor"/> class.
		/// </summary>
		public Editor()
		{
			InitializeComponent();
			GrammarXml.Text = Properties.Settings.Default.RulesXml;
			Inputs.Add(Properties.Settings.Default.InputText);
			InputText.Text = Inputs[0];
			VersionNumber.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
			GrammarXml.KeyDown += ShortCut_KeyDown;
			InputText.KeyDown += ShortCut_KeyDown;
			//GrammarXml. = GrammarXml.Rtf.Replace(@"\deflang2057", @"\deflang2057\deftab144");
		}

		void ShortCut_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				if (e.KeyCode == Keys.A)
				{
					((TextBox)sender).SelectAll();
				}
			}
		}

		private void ParseButton_Click(object sender, EventArgs e)
		{
			ParseNow();
		}

		private void Tables_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (OutputData.DataSource is DataSet && Tables.SelectedIndex >= 0)
				{
					OutputData.DataMember = (OutputData.DataSource as DataSet).Tables[Tables.SelectedIndex].TableName;
				}
			}
			catch (Exception ex)
			{
				OutputText.Text = ex.FullText();
			}
		}

		private void TestWindow_KeyPress(object sender, KeyPressEventArgs e)
		{

		}

		private void TestWindow_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F5)
			{
				ParseNow();
			}
		}

		private void LoadAndParseFiles(string[] paths, bool loadPasses = false)
		{
			try
			{
				SetStatusText("Parsing", Color.White, Color.DarkBlue);
				ClearPreviouslyLoaded();
				var grammar = Parser.LoadXml(GrammarXml.Text);
				for (int i = 0; i < paths.Length; i++)
				{

					// in this mode, only failures are added
					var path = paths[i];
					if (File.Exists(path))
					{
						LoadAndParseFile(grammar, path, loadPasses);
						OverallResult.Text = "Loaded: {0} of {1}; Passes: {2}  Fails: {3} {4}".Values(i, paths.Length, Passed, Failed, error);
						statusStrip.Refresh();
						if (i % 10 == 0) Application.DoEvents();
					}
				}
				SetStatusOverall();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void LoadAndParseFolder(string path)
		{
			try
			{
				SetStatusText("Parsing", Color.White, Color.DarkBlue);
				ClearPreviouslyLoaded();
				var grammar = Parser.LoadXml(GrammarXml.Text);
				var count = 0;
				foreach (var file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
				{
					count += 1;
					LoadAndParseFile(grammar, file, false);
					OverallResult.Text = "Loaded: {0}; Passes: {1}  Fails: {2} {3}".Values(count, Passed, Failed, error);
					statusStrip.Refresh();
					if (count % 10 == 0) Application.DoEvents();
				}
				SetStatusOverall();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void LoadAndParseFile(Parser grammar, string path, bool loadPasses)
		{
			try
			{
				var input = File.ReadAllText(path);
				var r = grammar.Parse(input);
				if (r.IsMatch)
				{
					if (loadPasses)
					{
						var page = new TabPage(Path.GetFileNameWithoutExtension(path));
						InputSelection.TabPages.Add(page);
						page.ImageIndex = 0;
						Inputs.Add(input);
						Results.Add(r);
					}
					Passed += 1;
				}
				else
				{
					var page = new TabPage(Path.GetFileNameWithoutExtension(path));
					InputSelection.TabPages.Add(page);
					page.ImageIndex = 1;
					Inputs.Add(input);
					Results.Add(r);
					if (firstFail == -1) firstFail = InputSelection.TabCount;
					Failed += 1;
				}
			}
			catch (Exception e)
			{
				Failed += 1;
				error = e.Message;
			}
		}

		private void ClearPreviouslyLoaded()
		{
			Passed = 0;
			Failed = 0;
			Inputs.Clear();
			Results.Clear();
			InputSelection.TabPages.Clear();
			firstFail = -1;
			error = string.Empty;
		}

		private void ParseNow()
		{
			Passed = 0;
			Failed = 0;
			try
			{
				StatusLabel.Text = "Parsing";
				statusStrip.Refresh();
				var grammar = Parser.LoadXml(GrammarXml.Text);

				Properties.Settings.Default.RulesXml = GrammarXml.Text;
				Properties.Settings.Default.InputText = InputText.Text;
				Properties.Settings.Default.Save();

				var timer = new Stopwatch();

				Results.Clear();
				var i = 0;
				firstFail = -1;
				foreach (var input in Inputs)
				{
					timer.Start();
					var r = grammar.Parse(input);
					Results.Add(r);
					if (r.IsMatch)
					{
						InputSelection.TabPages[i].ImageIndex = 0;
						Passed += 1;
					}
					else
					{
						InputSelection.TabPages[i].ImageIndex = 1;
						Failed += 1;
						if (firstFail == -1) firstFail = i;
					}
					i += 1;
					timer.Stop();
					OverallResult.Text = "Passes: {0}  Fails: {1}".Values(Passed, Failed);
					Application.DoEvents();
				}
				//var result = grammar.Parse(InputText.Text);
				StatusLabel.Text = "Preparing results";
				statusStrip.Refresh();

				TimeTaken.Text = string.Format("{0:n2}ms", timer.Elapsed.TotalMilliseconds);
				DisplayResults();
				if (firstFail >= 0) InputSelection.SelectedIndex = firstFail;
			}
			catch (Exception ex)
			{
				tabControl1.SelectedIndex = 0;
				StatusLabel.Text = "Error";
				StatusLabel.BackColor = Color.Red;
				StatusLabel.ForeColor = Color.White;
				TimeTaken.Text = "";
				OutputText.Text = ex.FullText();
			}
		}

		private void DisplayResults()
		{
			if (Results.Count == 0) return;
			var selectedIndex = GetSelectedTab();
			if (selectedIndex < Inputs.Count) InputText.Text = Inputs[selectedIndex]; else InputText.Text = string.Empty;
			var result = Results[selectedIndex];
			OutputText.Text = "";
			PopulateXml(OutputNodes, result.XmlSerialize());
			if (result.IsMatch)
			{
				OutputText.Text += "\r\nParses OK";
				FormattedOutput.Text = result.FormattedOutput();
				var ds = new DataSet();
				result.Fill(ds, IdMode.RowAndParents, IdStyle.Guid);
				Tables.TabPages.Clear();
				if (ds.Tables.Count > 0)
				{
					OutputData.DataSource = ds;
					foreach (DataTable table in ds.Tables) { Tables.TabPages.Add(table.TableName); }
					OutputData.DataMember = ds.Tables[0].TableName;
				}
				PopulateXml(ToXmlTreeView, result.ToXml(true));
				SetStatusText("Parsed OK", Color.White, Color.DarkGreen);
			}
			else
			{
				var xml = result.XmlSerialize();
				var err = result.GetErrorNode();
				OutputText.Text += err.GetErrorText();
				InputText.SelectionStart = err.Begin;
				InputText.SelectionLength = err.End - err.Begin + 1;
				SetStatusText("Parse Error", Color.Black, Color.Yellow);
			}
		}

		private void SetStatusOverall()
		{
			if (Passed == 0)
				SetStatusText("Failed", Color.White, Color.Red);
			else if (Failed > 0)
				SetStatusText("Partial", Color.Black, Color.Yellow);
			else
				SetStatusText("Passed", Color.White, Color.DarkGreen);
		}

		private void SetStatusText(string text, Color foreground, Color background)
		{
			StatusLabel.Text = text;
			StatusLabel.ForeColor = foreground;
			StatusLabel.BackColor = background;
			statusStrip.Refresh();
		}

		private void HandleException(Exception ex)
		{
			StatusLabel.Text = "Error";
			StatusLabel.BackColor = Color.Red;
			StatusLabel.ForeColor = Color.White;
			TimeTaken.Text = "";
			OutputText.Text = ex.FullText();
		}

		private void PopulateXml(TreeView treeView, string xmlString)
		{
			try
			{
				treeView.SuspendLayout();
				treeView.Nodes.Clear();
				var xml = new XmlDocument();
				xml.LoadXml(xmlString);
				var root = new TreeNode();
				PopulateXml(xml.DocumentElement, root);
				root.ExpandAll();
				treeView.Nodes.Add(root);
				treeView.ResumeLayout();

			}
			catch (Exception e)
			{
				OutputText.Text += e.Message;
			}
		}

		private void PopulateXml(XmlNode xml, TreeNode treeNode)
		{
			treeNode.Text = "<" + xml.Name;
			foreach (XmlAttribute attr in xml.Attributes)
			{
				treeNode.Text += " " + attr.Name + "=\"" + attr.Value + "\"";
			}
			treeNode.Text += ">";
			if (xml.HasChildNodes)
			{
				foreach (XmlNode xmlnode in xml.ChildNodes)
				{
					var node = treeNode.Nodes.Add("<" + xmlnode.Name + "> := " + xmlnode.Value);
					node.Expand();
					PopulateXml(xmlnode, node);
				}
			}
			//treeNode.Expand();
		}

		private void GrammarXml_TextChanged(object sender, EventArgs e)
		{

		}

		private void ResetTextColors()
		{
			//GrammarXml.SelectAll();
			//GrammarXml.SelectionColor = Color.Black;
			//GrammarXml.SelectionBackColor = Color.White;
			//GrammarXml.DeselectAll();
		}

		private void GrammarXml_Leave(object sender, EventArgs e)
		{

		}

		private void resetColoursButton_Click(object sender, EventArgs e)
		{
			ResetTextColors();
		}

		private void clearInput_Click(object sender, EventArgs e)
		{
			InputSelection.TabPages.Clear();
			InputSelection.TabPages.Add("User");
			Inputs.Clear();
			Results.Clear();
			Inputs.Add("");
			InputText.Text = String.Empty;
		}

		private void Editor_DragEnter(object sender, DragEventArgs e)
		{

		}

		private void InputText_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
			{
				var paths = e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop) as string[];
				if (paths == null || paths.Length == 0)
				{
					MessageBox.Show("Please drag one or more files, or a folder");
				}
				else
				{
					if (paths.Length == 1 && Directory.Exists(paths[0]))
					{
						// Parse the folder contents, only record errors
						LoadAndParseFolder(paths[0]);
					}
					else if (paths.Length > 100)
					{
						// Long list, parse everything but only record errors
						LoadAndParseFiles(paths, false);
					}
					else
					{
						// load and parse everything
						LoadAndParseFiles(paths, true);
						//LoadFiles(paths);
						//ParseNow();
					}
				}
			}
		}

		private void LoadFiles(string[] paths)
		{
			Inputs.Clear();
			InputSelection.TabPages.Clear();
			for (int i = 0; i < paths.Length; i++)
			{
				var path = paths[i];
				if (File.Exists(path))
				{
					InputSelection.TabPages.Add(Path.GetFileNameWithoutExtension(path));
					Inputs.Add(File.ReadAllText(path));
					OverallResult.Text = "Loaded: {0} of {1}".Values(i, paths.Length);
					Application.DoEvents();
				}
			}
		}

		private void InputText_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}

		private void InputText_DragOver(object sender, DragEventArgs e)
		{

		}

		private void InputText_GiveFeedback(object sender, GiveFeedbackEventArgs e)
		{

		}

		private void InputSelection_SelectedIndexChanged(object sender, EventArgs e)
		{
			DisplayResults();
		}

		private void InputText_TextChanged(object sender, EventArgs e)
		{
			var selectedIndex = GetSelectedTab();
			if (selectedIndex < Inputs.Count) Inputs[selectedIndex] = InputText.Text;
		}

		private int GetSelectedTab()
		{
			var selectedIndex = InputSelection.SelectedIndex;
			if (selectedIndex < 0) selectedIndex = 0;
			return selectedIndex;
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				using (var openDialog = new OpenFileDialog())
				{
					openDialog.Title = "Select Grammar file";
					if (openDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						OpenGrammarFile(openDialog.FileName);
					}
				}
			}
			catch (Exception ex)
			{
				OutputText.Text = ex.FullText();
			}
		}

		private void saveToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				using (var saveDialog = new SaveFileDialog())
				{
					saveDialog.Title = "Save Grammar file";
					saveDialog.FileName = filePath;
					if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						File.WriteAllText(saveDialog.FileName, GrammarXml.Text);
					}
				}
			}
			catch (Exception ex)
			{
				OutputText.Text = ex.FullText();
			}
		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			try
			{
				filePath = string.Empty;
				GrammarXml.Text =
@"<Rules>
	<OneOrMore Name='root'>
		<Include>statement</Include>
	</OneOrMore>
	<Sequence Name='statement'>
		<Symbol>\s*BEGIN</Symbol>
		<Symbol>\s*\d+</Symbol>
		<Symbol>\s*END</Symbol>
	</Sequence>
</Rules>";
			}
			catch (Exception ex)
			{
				OutputText.Text = ex.FullText();
			}
		}

		private void testRegexes_Click(object sender, EventArgs e)
		{
			try
			{
				var tester = new RegexTester();
				tester.Show();
			}
			catch (Exception ex)
			{
				OutputText.Text = ex.FullText();
			}
		}

		private void OpenGrammarFile(string path)
		{
			filePath = path;
			GrammarXml.Text = File.ReadAllText(filePath);
			ParseNow();
		}

		private void GrammarXml_DragDrop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
			{
				var paths = e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop) as string[];
				if (paths == null || paths.Length != 1)
				{
					MessageBox.Show("Please drag one file.");
				}
				else
				{
					OpenGrammarFile(paths[0]);
				}
			}
		}

		private void GrammarXml_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.Copy;
			}
		}


	}
}
