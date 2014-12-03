namespace NewParser
{
	partial class Editor
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.GrammarXml = new System.Windows.Forms.TextBox();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.InputText = new System.Windows.Forms.TextBox();
			this.InputSelection = new System.Windows.Forms.TabControl();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.OutputText = new System.Windows.Forms.TextBox();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.OutputNodes = new System.Windows.Forms.TreeView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.FormattedOutput = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.Tables = new System.Windows.Forms.TabControl();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.OutputData = new System.Windows.Forms.DataGridView();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.ToXmlTreeView = new System.Windows.Forms.TreeView();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.ParseButton = new System.Windows.Forms.ToolStripButton();
			this.resetColoursButton = new System.Windows.Forms.ToolStripButton();
			this.clearInput = new System.Windows.Forms.ToolStripButton();
			this.testRegexes = new System.Windows.Forms.ToolStripButton();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.copyToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.pasteToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.VersionNumber = new System.Windows.Forms.ToolStripStatusLabel();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.TimeTaken = new System.Windows.Forms.ToolStripStatusLabel();
			this.OverallResult = new System.Windows.Forms.ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.InputSelection.SuspendLayout();
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
			this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.GrammarXml);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(1496, 826);
			this.splitContainer1.SplitterDistance = 498;
			this.splitContainer1.SplitterWidth = 5;
			this.splitContainer1.TabIndex = 0;
			// 
			// GrammarXml
			// 
			this.GrammarXml.AcceptsTab = true;
			this.GrammarXml.AllowDrop = true;
			this.GrammarXml.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.GrammarXml.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GrammarXml.Location = new System.Drawing.Point(0, 0);
			this.GrammarXml.Margin = new System.Windows.Forms.Padding(4);
			this.GrammarXml.MaxLength = 999999999;
			this.GrammarXml.Multiline = true;
			this.GrammarXml.Name = "GrammarXml";
			this.GrammarXml.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.GrammarXml.Size = new System.Drawing.Size(498, 826);
			this.GrammarXml.TabIndex = 0;
			this.GrammarXml.Text = resources.GetString("GrammarXml.Text");
			this.GrammarXml.WordWrap = false;
			this.GrammarXml.TextChanged += new System.EventHandler(this.GrammarXml_TextChanged);
			this.GrammarXml.DragDrop += new System.Windows.Forms.DragEventHandler(this.GrammarXml_DragDrop);
			this.GrammarXml.DragEnter += new System.Windows.Forms.DragEventHandler(this.GrammarXml_DragEnter);
			this.GrammarXml.Leave += new System.EventHandler(this.GrammarXml_Leave);
			// 
			// splitContainer2
			// 
			this.splitContainer2.AllowDrop = true;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.InputText);
			this.splitContainer2.Panel1.Controls.Add(this.InputSelection);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
			this.splitContainer2.Size = new System.Drawing.Size(993, 826);
			this.splitContainer2.SplitterDistance = 432;
			this.splitContainer2.SplitterWidth = 5;
			this.splitContainer2.TabIndex = 0;
			// 
			// InputText
			// 
			this.InputText.AcceptsReturn = true;
			this.InputText.AcceptsTab = true;
			this.InputText.AllowDrop = true;
			this.InputText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.InputText.Location = new System.Drawing.Point(0, 26);
			this.InputText.Margin = new System.Windows.Forms.Padding(4);
			this.InputText.MaxLength = 999999999;
			this.InputText.Multiline = true;
			this.InputText.Name = "InputText";
			this.InputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.InputText.Size = new System.Drawing.Size(993, 406);
			this.InputText.TabIndex = 1;
			this.InputText.Text = "BEGIN 123 END";
			this.InputText.WordWrap = false;
			this.InputText.TextChanged += new System.EventHandler(this.InputText_TextChanged);
			this.InputText.DragDrop += new System.Windows.Forms.DragEventHandler(this.InputText_DragDrop);
			this.InputText.DragEnter += new System.Windows.Forms.DragEventHandler(this.InputText_DragEnter);
			this.InputText.DragOver += new System.Windows.Forms.DragEventHandler(this.InputText_DragOver);
			this.InputText.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.InputText_GiveFeedback);
			// 
			// InputSelection
			// 
			this.InputSelection.Controls.Add(this.tabPage7);
			this.InputSelection.Controls.Add(this.tabPage8);
			this.InputSelection.Dock = System.Windows.Forms.DockStyle.Top;
			this.InputSelection.ImageList = this.imageList;
			this.InputSelection.Location = new System.Drawing.Point(0, 0);
			this.InputSelection.Margin = new System.Windows.Forms.Padding(4);
			this.InputSelection.Name = "InputSelection";
			this.InputSelection.SelectedIndex = 0;
			this.InputSelection.Size = new System.Drawing.Size(993, 26);
			this.InputSelection.TabIndex = 2;
			this.InputSelection.SelectedIndexChanged += new System.EventHandler(this.InputSelection_SelectedIndexChanged);
			// 
			// tabPage7
			// 
			this.tabPage7.BackColor = System.Drawing.Color.Maroon;
			this.tabPage7.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.tabPage7.Location = new System.Drawing.Point(4, 25);
			this.tabPage7.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage7.Size = new System.Drawing.Size(985, 0);
			this.tabPage7.TabIndex = 0;
			this.tabPage7.Text = "User";
			// 
			// tabPage8
			// 
			this.tabPage8.Location = new System.Drawing.Point(4, 25);
			this.tabPage8.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage8.Size = new System.Drawing.Size(985, 0);
			this.tabPage8.TabIndex = 1;
			this.tabPage8.Text = "*";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// imageList
			// 
			this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "OK.ico");
			this.imageList.Images.SetKeyName(1, "Error.ico");
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
			this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(993, 389);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.OutputText);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage1.Size = new System.Drawing.Size(985, 360);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Parsing Result";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// OutputText
			// 
			this.OutputText.AcceptsReturn = true;
			this.OutputText.AcceptsTab = true;
			this.OutputText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutputText.Location = new System.Drawing.Point(4, 4);
			this.OutputText.Margin = new System.Windows.Forms.Padding(4);
			this.OutputText.Multiline = true;
			this.OutputText.Name = "OutputText";
			this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.OutputText.Size = new System.Drawing.Size(977, 352);
			this.OutputText.TabIndex = 2;
			this.OutputText.WordWrap = false;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.OutputNodes);
			this.tabPage4.Location = new System.Drawing.Point(4, 25);
			this.tabPage4.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage4.Size = new System.Drawing.Size(985, 360);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Output Nodes";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// OutputNodes
			// 
			this.OutputNodes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.OutputNodes.Location = new System.Drawing.Point(4, 4);
			this.OutputNodes.Margin = new System.Windows.Forms.Padding(4);
			this.OutputNodes.Name = "OutputNodes";
			this.OutputNodes.Size = new System.Drawing.Size(977, 352);
			this.OutputNodes.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.FormattedOutput);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage3.Size = new System.Drawing.Size(985, 360);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Formatted Output";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// FormattedOutput
			// 
			this.FormattedOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.FormattedOutput.Location = new System.Drawing.Point(4, 4);
			this.FormattedOutput.Margin = new System.Windows.Forms.Padding(4);
			this.FormattedOutput.Multiline = true;
			this.FormattedOutput.Name = "FormattedOutput";
			this.FormattedOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.FormattedOutput.Size = new System.Drawing.Size(977, 352);
			this.FormattedOutput.TabIndex = 1;
			this.FormattedOutput.WordWrap = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.Tables);
			this.tabPage2.Controls.Add(this.OutputData);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage2.Size = new System.Drawing.Size(985, 360);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Extracted Data";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// Tables
			// 
			this.Tables.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.Tables.Controls.Add(this.tabPage6);
			this.Tables.ItemSize = new System.Drawing.Size(0, 18);
			this.Tables.Location = new System.Drawing.Point(3, 1);
			this.Tables.Margin = new System.Windows.Forms.Padding(4);
			this.Tables.Multiline = true;
			this.Tables.Name = "Tables";
			this.Tables.SelectedIndex = 0;
			this.Tables.Size = new System.Drawing.Size(980, 25);
			this.Tables.TabIndex = 1;
			this.Tables.SelectedIndexChanged += new System.EventHandler(this.Tables_SelectedIndexChanged);
			// 
			// tabPage6
			// 
			this.tabPage6.Location = new System.Drawing.Point(4, 4);
			this.tabPage6.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Padding = new System.Windows.Forms.Padding(4);
			this.tabPage6.Size = new System.Drawing.Size(972, 0);
			this.tabPage6.TabIndex = 0;
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// OutputData
			// 
			this.OutputData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputData.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.OutputData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.OutputData.Location = new System.Drawing.Point(-1, 26);
			this.OutputData.Margin = new System.Windows.Forms.Padding(4);
			this.OutputData.Name = "OutputData";
			this.OutputData.Size = new System.Drawing.Size(984, 328);
			this.OutputData.TabIndex = 0;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.ToXmlTreeView);
			this.tabPage5.Location = new System.Drawing.Point(4, 25);
			this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(985, 360);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "ToXml";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// ToXmlTreeView
			// 
			this.ToXmlTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ToXmlTreeView.Location = new System.Drawing.Point(0, 0);
			this.ToXmlTreeView.Margin = new System.Windows.Forms.Padding(4);
			this.ToXmlTreeView.Name = "ToXmlTreeView";
			this.ToXmlTreeView.Size = new System.Drawing.Size(985, 360);
			this.ToXmlTreeView.TabIndex = 1;
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.AutoScroll = true;
			this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
			this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1496, 826);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(1496, 853);
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
            this.clearInput,
            this.testRegexes,
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.cutToolStripButton,
            this.copyToolStripButton,
            this.pasteToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
			this.toolStrip1.Location = new System.Drawing.Point(3, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(611, 27);
			this.toolStrip1.TabIndex = 0;
			// 
			// ParseButton
			// 
			this.ParseButton.Image = ((System.Drawing.Image)(resources.GetObject("ParseButton.Image")));
			this.ParseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ParseButton.Name = "ParseButton";
			this.ParseButton.Size = new System.Drawing.Size(99, 24);
			this.ParseButton.Text = "Parse Now";
			this.ParseButton.ToolTipText = "Parse Now (F5)";
			this.ParseButton.Click += new System.EventHandler(this.ParseButton_Click);
			// 
			// resetColoursButton
			// 
			this.resetColoursButton.Image = ((System.Drawing.Image)(resources.GetObject("resetColoursButton.Image")));
			this.resetColoursButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.resetColoursButton.Name = "resetColoursButton";
			this.resetColoursButton.Size = new System.Drawing.Size(111, 24);
			this.resetColoursButton.Text = "Reset Colors";
			this.resetColoursButton.Click += new System.EventHandler(this.resetColoursButton_Click);
			// 
			// clearInput
			// 
			this.clearInput.Image = ((System.Drawing.Image)(resources.GetObject("clearInput.Image")));
			this.clearInput.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.clearInput.Name = "clearInput";
			this.clearInput.Size = new System.Drawing.Size(101, 24);
			this.clearInput.Text = "Clear Input";
			this.clearInput.Click += new System.EventHandler(this.clearInput_Click);
			// 
			// testRegexes
			// 
			this.testRegexes.Image = ((System.Drawing.Image)(resources.GetObject("testRegexes.Image")));
			this.testRegexes.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.testRegexes.Name = "testRegexes";
			this.testRegexes.Size = new System.Drawing.Size(115, 24);
			this.testRegexes.Text = "Test Regexes";
			this.testRegexes.Click += new System.EventHandler(this.testRegexes_Click);
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(23, 24);
			this.newToolStripButton.Text = "&New";
			this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 24);
			this.openToolStripButton.Text = "&Open";
			this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 24);
			this.saveToolStripButton.Text = "&Save";
			this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
			// 
			// cutToolStripButton
			// 
			this.cutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cutToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton.Image")));
			this.cutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripButton.Name = "cutToolStripButton";
			this.cutToolStripButton.Size = new System.Drawing.Size(23, 24);
			this.cutToolStripButton.Text = "C&ut";
			// 
			// copyToolStripButton
			// 
			this.copyToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.copyToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripButton.Image")));
			this.copyToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripButton.Name = "copyToolStripButton";
			this.copyToolStripButton.Size = new System.Drawing.Size(23, 24);
			this.copyToolStripButton.Text = "&Copy";
			// 
			// pasteToolStripButton
			// 
			this.pasteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.pasteToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripButton.Image")));
			this.pasteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripButton.Name = "pasteToolStripButton";
			this.pasteToolStripButton.Size = new System.Drawing.Size(23, 24);
			this.pasteToolStripButton.Text = "&Paste";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Size = new System.Drawing.Size(23, 24);
			this.helpToolStripButton.Text = "He&lp";
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VersionNumber,
            this.StatusLabel,
            this.TimeTaken,
            this.OverallResult});
			this.statusStrip.Location = new System.Drawing.Point(0, 853);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
			this.statusStrip.Size = new System.Drawing.Size(1496, 25);
			this.statusStrip.TabIndex = 1;
			// 
			// VersionNumber
			// 
			this.VersionNumber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.VersionNumber.Name = "VersionNumber";
			this.VersionNumber.Size = new System.Drawing.Size(50, 20);
			this.VersionNumber.Text = "0.0.0.0";
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = false;
			this.StatusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.StatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(100, 20);
			// 
			// TimeTaken
			// 
			this.TimeTaken.AutoSize = false;
			this.TimeTaken.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.TimeTaken.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.TimeTaken.Name = "TimeTaken";
			this.TimeTaken.Size = new System.Drawing.Size(100, 20);
			// 
			// OverallResult
			// 
			this.OverallResult.Name = "OverallResult";
			this.OverallResult.Size = new System.Drawing.Size(56, 20);
			this.OverallResult.Text = "Overall";
			// 
			// Editor
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1496, 878);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.statusStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.MinimumSize = new System.Drawing.Size(661, 482);
			this.Name = "Editor";
			this.Text = "Parser Studio";
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Editor_DragEnter);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TestWindow_KeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TestWindow_KeyPress);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.InputSelection.ResumeLayout(false);
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
		private System.Windows.Forms.TextBox GrammarXml;
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
		private System.Windows.Forms.TabControl InputSelection;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripButton cutToolStripButton;
		private System.Windows.Forms.ToolStripButton copyToolStripButton;
		private System.Windows.Forms.ToolStripButton pasteToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton helpToolStripButton;
		private System.Windows.Forms.ToolStripStatusLabel VersionNumber;
		private System.Windows.Forms.ToolStripButton testRegexes;
		private System.Windows.Forms.ToolStripStatusLabel OverallResult;
	}
}