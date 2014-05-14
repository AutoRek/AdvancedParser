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

		/// <summary>
		/// Initializes a new instance of the <see cref="Editor"/> class.
		/// </summary>
		public Editor()
		{
			InitializeComponent();
			GrammarXml.Text = Properties.Settings.Default.RulesXml;
			Inputs.Add(Properties.Settings.Default.InputText);
			InputText.Text = Inputs[0];
			//GrammarXml. = GrammarXml.Rtf.Replace(@"\deflang2057", @"\deflang2057\deftab144");
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

		private void ParseNow()
		{

			try
			{
				StatusLabel.Text = "Parsing";
				statusStrip.Refresh();
				var grammar = Parser.LoadXml(GrammarXml.Text);

				Properties.Settings.Default.RulesXml = GrammarXml.Text;
				Properties.Settings.Default.InputText = InputText.Text;
				Properties.Settings.Default.Save();

				var timer = Stopwatch.StartNew();

				Results.Clear();
				var i = 0;
				foreach (var input in Inputs)
				{
					var r = grammar.Parse(input);
					Results.Add(r);
					if (r.IsMatch)
					{
						InputSelection.TabPages[i].ImageIndex = 0;
					}
					else
					{
						InputSelection.TabPages[i].ImageIndex = 1;
					}
					i += 1;
				}
				//var result = grammar.Parse(InputText.Text);
				timer.Stop();
				StatusLabel.Text = "Preparing results";
				statusStrip.Refresh();

				TimeTaken.Text = string.Format("{0:n2}ms", timer.Elapsed.TotalMilliseconds);
				DisplayResults();
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
				StatusLabel.Text = "Parsed OK";
				StatusLabel.BackColor = Color.DarkGreen;
				StatusLabel.ForeColor = Color.White;
			}
			else
			{
				var xml = result.XmlSerialize();
				var err = result.GetErrorNode();
				OutputText.Text += err.GetErrorText();
				InputText.SelectionStart = err.Begin;
				InputText.SelectionLength = err.End - err.Begin + 1;
				StatusLabel.Text = "Parse Error";
				StatusLabel.BackColor = Color.Yellow;
				StatusLabel.ForeColor = Color.Black;
			}
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
					MessageBox.Show("Please drag one or more files.");
				}
				else
				{
					Inputs.Clear();
					InputSelection.TabPages.Clear();
					foreach (var path in paths)
					{
						InputSelection.TabPages.Add(Path.GetFileNameWithoutExtension(path));
						Inputs.Add(File.ReadAllText(path));
					}
					ParseNow();
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
