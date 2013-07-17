namespace NewParser
{
	partial class TestWindow
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestWindow));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.GrammarXml = new System.Windows.Forms.RichTextBox();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.InputText = new System.Windows.Forms.TextBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.OutputText = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.OutputNodes = new System.Windows.Forms.TreeView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.FormattedOutput = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.Tables = new System.Windows.Forms.TabControl();
			this.OutputData = new System.Windows.Forms.DataGridView();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.ToXmlTreeView = new System.Windows.Forms.TreeView();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ParseButton = new System.Windows.Forms.ToolStripButton();
			this.resetColoursButton = new System.Windows.Forms.ToolStripButton();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.TimeTaken = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.clearInput = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.Tables.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.OutputData)).BeginInit();
			this.tabPage5.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.statusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.GrammarXml);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(1122, 666);
			this.splitContainer1.SplitterDistance = 374;
			this.splitContainer1.TabIndex = 0;
			// 
			// GrammarXml
			// 
			this.GrammarXml.AcceptsTab = true;
			this.GrammarXml.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.GrammarXml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GrammarXml.EnableAutoDragDrop = true;
			this.GrammarXml.Location = new System.Drawing.Point(0, 0);
			this.GrammarXml.Name = "GrammarXml";
			this.GrammarXml.Size = new System.Drawing.Size(374, 666);
			this.GrammarXml.TabIndex = 0;
			this.GrammarXml.Text = resources.GetString("GrammarXml.Text");
			this.GrammarXml.WordWrap = false;
			this.GrammarXml.TextChanged += new System.EventHandler(this.GrammarXml_TextChanged);
			this.GrammarXml.Leave += new System.EventHandler(this.GrammarXml_Leave);
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.InputText);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer2.Size = new System.Drawing.Size(744, 666);
			this.splitContainer2.SplitterDistance = 349;
			this.splitContainer2.TabIndex = 0;
			// 
			// InputText
			// 
			this.InputText.AcceptsReturn = true;
			this.InputText.AcceptsTab = true;
			this.InputText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InputText.Location = new System.Drawing.Point(0, 0);
			this.InputText.MaxLength = 32767000;
			this.InputText.Multiline = true;
			this.InputText.Name = "InputText";
			this.InputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.InputText.Size = new System.Drawing.Size(744, 349);
			this.InputText.TabIndex = 1;
			this.InputText.Text = "BEGIN 123 END";
			this.InputText.WordWrap = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage5);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(744, 313);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.OutputText);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(736, 287);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Parsing Result";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// OutputText
			// 
			this.OutputText.AcceptsReturn = true;
			this.OutputText.AcceptsTab = true;
			this.OutputText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutputText.Location = new System.Drawing.Point(3, 3);
			this.OutputText.Multiline = true;
			this.OutputText.Name = "OutputText";
			this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.OutputText.Size = new System.Drawing.Size(730, 281);
			this.OutputText.TabIndex = 2;
			this.OutputText.WordWrap = false;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.OutputNodes);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(736, 287);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Output Nodes";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// OutputNodes
			// 
			this.OutputNodes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutputNodes.Location = new System.Drawing.Point(3, 3);
			this.OutputNodes.Name = "OutputNodes";
			this.OutputNodes.Size = new System.Drawing.Size(730, 281);
			this.OutputNodes.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.FormattedOutput);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(736, 287);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Formatted Output";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// FormattedOutput
			// 
			this.FormattedOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FormattedOutput.Location = new System.Drawing.Point(3, 3);
			this.FormattedOutput.Multiline = true;
			this.FormattedOutput.Name = "FormattedOutput";
			this.FormattedOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.FormattedOutput.Size = new System.Drawing.Size(730, 281);
			this.FormattedOutput.TabIndex = 1;
			this.FormattedOutput.WordWrap = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.Tables);
			this.tabPage2.Controls.Add(this.OutputData);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(736, 287);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Extracted Data";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// Tables
			// 
			this.Tables.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.Tables.Controls.Add(this.tabPage6);
			this.Tables.ItemSize = new System.Drawing.Size(0, 18);
			this.Tables.Location = new System.Drawing.Point(2, 1);
			this.Tables.Multiline = true;
			this.Tables.Name = "Tables";
			this.Tables.SelectedIndex = 0;
			this.Tables.Size = new System.Drawing.Size(735, 20);
			this.Tables.TabIndex = 1;
			this.Tables.SelectedIndexChanged += new System.EventHandler(this.Tables_SelectedIndexChanged);
			// 
			// OutputData
			// 
			this.OutputData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputData.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.OutputData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.OutputData.Location = new System.Drawing.Point(-1, 21);
			this.OutputData.Name = "OutputData";
			this.OutputData.Size = new System.Drawing.Size(737, 266);
			this.OutputData.TabIndex = 0;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.ToXmlTreeView);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(736, 287);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "ToXml";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// ToXmlTreeView
			// 
			this.ToXmlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ToXmlTreeView.Location = new System.Drawing.Point(0, 0);
			this.ToXmlTreeView.Name = "ToXmlTreeView";
			this.ToXmlTreeView.Size = new System.Drawing.Size(736, 287);
			this.ToXmlTreeView.TabIndex = 1;
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.AutoScroll = true;
			this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1122, 666);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(1122, 691);
			this.toolStripContainer1.TabIndex = 1;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ParseButton,
            this.resetColoursButton,
            this.clearInput});
			this.toolStrip1.Location = new System.Drawing.Point(3, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(303, 25);
			this.toolStrip1.TabIndex = 0;
			// 
			// ParseButton
			// 
			this.ParseButton.Image = ((System.Drawing.Image)(resources.GetObject("ParseButton.Image")));
			this.ParseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ParseButton.Name = "ParseButton";
			this.ParseButton.Size = new System.Drawing.Size(83, 22);
			this.ParseButton.Text = "Parse Now";
			this.ParseButton.ToolTipText = "Parse Now (F5)";
			this.ParseButton.Click += new System.EventHandler(this.ParseButton_Click);
			// 
			// resetColoursButton
			// 
			this.resetColoursButton.Image = ((System.Drawing.Image)(resources.GetObject("resetColoursButton.Image")));
			this.resetColoursButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.resetColoursButton.Name = "resetColoursButton";
			this.resetColoursButton.Size = new System.Drawing.Size(92, 22);
			this.resetColoursButton.Text = "Reset Colors";
			this.resetColoursButton.Click += new System.EventHandler(this.resetColoursButton_Click);
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.TimeTaken});
			this.statusStrip.Location = new System.Drawing.Point(0, 691);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(1122, 22);
			this.statusStrip.TabIndex = 1;
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = false;
			this.StatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.StatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(100, 17);
			// 
			// TimeTaken
			// 
			this.TimeTaken.AutoSize = false;
			this.TimeTaken.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.TimeTaken.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.TimeTaken.Name = "TimeTaken";
			this.TimeTaken.Size = new System.Drawing.Size(100, 17);
			// 
			// tabPage6
			// 
			this.tabPage6.Location = new System.Drawing.Point(4, 4);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage6.Size = new System.Drawing.Size(727, 0);
			this.tabPage6.TabIndex = 0;
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// clearInput
			// 
			this.clearInput.Image = ((System.Drawing.Image)(resources.GetObject("clearInput.Image")));
			this.clearInput.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearInput.Name = "clearInput";
			this.clearInput.Size = new System.Drawing.Size(85, 22);
			this.clearInput.Text = "Clear Input";
			this.clearInput.Click += new System.EventHandler(this.clearInput_Click);
			// 
			// TestWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1122, 713);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.statusStrip);
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(500, 400);
			this.Name = "TestWindow";
			this.Text = "Parser Test Console";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TestWindow_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TestWindow_KeyPress);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage4.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.Tables.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.OutputData)).EndInit();
			this.tabPage5.ResumeLayout(false);
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.RichTextBox GrammarXml;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.TextBox InputText;
		private System.Windows.Forms.TextBox OutputText;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton ParseButton;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGridView OutputData;
		private System.Windows.Forms.TabControl Tables;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TextBox FormattedOutput;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TreeView OutputNodes;
		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel TimeTaken;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.TreeView ToXmlTreeView;
		private System.Windows.Forms.ToolStripButton resetColoursButton;
		private System.Windows.Forms.TabPage tabPage6;
		private System.Windows.Forms.ToolStripButton clearInput;
	}
}