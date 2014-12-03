using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NewParser
{
	/// <summary>
	/// Window to test regexes
	/// </summary>
	public partial class RegexTester : Form
	{
		/// <summary>
		/// Default constructor
		/// </summary>
		public RegexTester()
		{
			InitializeComponent();
		}

		private void HandleException(Exception ex)
		{
			MatchResult.Text = ex.Message;
		}

		private void Pattern_TextChanged(object sender, EventArgs e)
		{
			try
			{
				TestRegex();
			}
			catch (Exception ex)
			{
				HandleException(ex);			
			}
		}

		private void InputText_TextChanged(object sender, EventArgs e)
		{
			try
			{
				TestRegex();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void WholeStringMatch_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				TestRegex();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void TestRegex()
		{
			if (string.IsNullOrEmpty(InputText.Text) || string.IsNullOrEmpty(Pattern.Text)) return;
			var pattern = Pattern.Text;
			if (WholeStringMatch.Checked) pattern = "\\A" + pattern + "\\z";
			var matches = Regex.Matches(InputText.Text, pattern);
			if (matches.Count > 0)
			{
				MatchResult.Text = "Yes";
				MatchResult.BackColor = Color.Green;
			}
			else
			{
				MatchResult.Text = "No";
				MatchResult.BackColor = Color.Red;
			}
			MatchDetails.Nodes.Clear();
			foreach (Match match in matches)
			{
				var node = new TreeNode(match.Value);
				MatchDetails.Nodes.Add(node);
				node.Nodes.Add("Index:" + match.Index);
				node.Nodes.Add("Length:" + match.Length);
			}
		}

		private void Accept_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(Pattern.Text)) Clipboard.SetText(Pattern.Text);
			this.Close();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

	}
}
