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

namespace NewParser
{
	/// <summary>
	/// 
	/// </summary>
	public partial class TestWindow : Form
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TestWindow"/> class.
		/// </summary>
		public TestWindow()
		{
			InitializeComponent();
		}

		private void ParseButton_Click(object sender, EventArgs e)
		{
			try
			{

				var grammar = Rules.LoadXml(GrammarXml.Text);

				var timer = Stopwatch.StartNew();
				var result = grammar.Parse(InputText.Text);
				timer.Stop();
				OutputText.Text = timer.Elapsed.TotalMilliseconds.ToString();
				if (result.IsMatch)
				{
					OutputText.Text += "\r\nParses OK";
					OutputText.Text += "\r\n" + result.XmlSerialize();
					FormattedOutput.Text = result.FormattedOutput();
					var ds = new DataSet();
					result.Fill(ds);
					OutputData.DataSource = ds;
					Tables.TabPages.Clear();
					foreach (DataTable table in ds.Tables) { Tables.TabPages.Add(table.TableName); }
					if (ds.Tables.Count > 0) { OutputData.DataMember = ds.Tables[0].TableName; }
					//OutputText.Text += "\r\n" + ds.GetXml();
				}
				else
				{
					OutputText.Text += result.GetErrorText();
				}
			}
			catch (Exception ex)
			{
				OutputText.Text = ex.FullText();
			}
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
	}
}
