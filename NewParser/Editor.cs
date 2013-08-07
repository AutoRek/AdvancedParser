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

namespace NewParser
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Editor : Form
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Editor"/> class.
		/// </summary>
		public Editor()
		{
			InitializeComponent();
			GrammarXml.Text = Properties.Settings.Default.RulesXml;
			InputText.Text = Properties.Settings.Default.InputText;
			GrammarXml.Rtf = GrammarXml.Rtf.Replace(@"\deflang2057", @"\deflang2057\deftab144");
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
				var grammar = Parser.LoadXml(GrammarXml.Text);

				Properties.Settings.Default.RulesXml = GrammarXml.Text;
				Properties.Settings.Default.InputText = InputText.Text;
				Properties.Settings.Default.Save();

				var timer = Stopwatch.StartNew();
				var result = grammar.Parse(InputText.Text);
				timer.Stop();
				OutputText.Text = string.Format("{0:n2}ms", timer.Elapsed.TotalMilliseconds);
				PopulateXml(OutputNodes, result.XmlSerialize());
				if (result.IsMatch)
				{
					OutputText.Text += "\r\nParses OK";
					FormattedOutput.Text = result.FormattedOutput();
					var ds = new DataSet();
					result.Fill(ds, IdMode.RowAndParents, IdStyle.Guid);
					OutputData.DataSource = ds;
					Tables.TabPages.Clear();
					foreach (DataTable table in ds.Tables) { Tables.TabPages.Add(table.TableName); }
					if (ds.Tables.Count > 0) { OutputData.DataMember = ds.Tables[0].TableName; }
					PopulateXml(ToXmlTreeView, result.ToXml());
					StatusLabel.Text = "Parsed OK";
					StatusLabel.BackColor = Color.DarkGreen;
					StatusLabel.ForeColor = Color.White;
					TimeTaken.Text = string.Format("{0:n2}ms", timer.Elapsed.TotalMilliseconds);
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
					TimeTaken.Text = string.Format("{0:n2}ms", timer.Elapsed.TotalMilliseconds);
				}
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

		private void PopulateXml(TreeView treeView, string xmlString)
		{
			try
			{
				treeView.SuspendLayout();
				treeView.Nodes.Clear();
				var xml = new XmlDocument();
				xml.LoadXml(xmlString);
				var root = treeView.Nodes.Add("Root");
				PopulateXml(xml.DocumentElement, root);
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
					PopulateXml(xmlnode, node);
				}
			}
			treeNode.Expand();
		}

		private void GrammarXml_TextChanged(object sender, EventArgs e)
		{

		}

		private void ResetTextColors()
		{
			GrammarXml.SelectAll();
			GrammarXml.SelectionColor = Color.Black;
			GrammarXml.SelectionBackColor = Color.White;
			GrammarXml.DeselectAll();
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
			InputText.Text = String.Empty;
		}

	}
}
