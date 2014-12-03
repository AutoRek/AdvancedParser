namespace NewParser
{
	partial class RegexTester
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
			this.Pattern = new System.Windows.Forms.TextBox();
			this.InputText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.MatchResult = new System.Windows.Forms.Label();
			this.MatchDetails = new System.Windows.Forms.TreeView();
			this.label4 = new System.Windows.Forms.Label();
			this.WholeStringMatch = new System.Windows.Forms.CheckBox();
			this.Accept = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Pattern
			// 
			this.Pattern.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Pattern.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Pattern.Location = new System.Drawing.Point(93, 12);
			this.Pattern.Name = "Pattern";
			this.Pattern.Size = new System.Drawing.Size(532, 25);
			this.Pattern.TabIndex = 0;
			this.Pattern.TextChanged += new System.EventHandler(this.Pattern_TextChanged);
			// 
			// InputText
			// 
			this.InputText.AcceptsReturn = true;
			this.InputText.AcceptsTab = true;
			this.InputText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.InputText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.InputText.Location = new System.Drawing.Point(93, 40);
			this.InputText.MaxLength = 327670;
			this.InputText.Multiline = true;
			this.InputText.Name = "InputText";
			this.InputText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.InputText.Size = new System.Drawing.Size(532, 88);
			this.InputText.TabIndex = 1;
			this.InputText.WordWrap = false;
			this.InputText.TextChanged += new System.EventHandler(this.InputText_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Input Text";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 15);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Pattern";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 134);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 17);
			this.label3.TabIndex = 3;
			this.label3.Text = "Is Match?";
			// 
			// MatchResult
			// 
			this.MatchResult.AutoSize = true;
			this.MatchResult.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.MatchResult.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MatchResult.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.MatchResult.Location = new System.Drawing.Point(95, 134);
			this.MatchResult.Name = "MatchResult";
			this.MatchResult.Size = new System.Drawing.Size(56, 17);
			this.MatchResult.TabIndex = 3;
			this.MatchResult.Text = "No Text";
			// 
			// MatchDetails
			// 
			this.MatchDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MatchDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.MatchDetails.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MatchDetails.Location = new System.Drawing.Point(93, 168);
			this.MatchDetails.Name = "MatchDetails";
			this.MatchDetails.Size = new System.Drawing.Size(532, 216);
			this.MatchDetails.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(12, 168);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "Details";
			// 
			// WholeStringMatch
			// 
			this.WholeStringMatch.AutoSize = true;
			this.WholeStringMatch.Checked = true;
			this.WholeStringMatch.CheckState = System.Windows.Forms.CheckState.Checked;
			this.WholeStringMatch.Location = new System.Drawing.Point(195, 135);
			this.WholeStringMatch.Name = "WholeStringMatch";
			this.WholeStringMatch.Size = new System.Drawing.Size(166, 21);
			this.WholeStringMatch.TabIndex = 5;
			this.WholeStringMatch.Text = "Whole string matches";
			this.WholeStringMatch.UseVisualStyleBackColor = true;
			this.WholeStringMatch.CheckedChanged += new System.EventHandler(this.WholeStringMatch_CheckedChanged);
			// 
			// Accept
			// 
			this.Accept.Location = new System.Drawing.Point(550, 386);
			this.Accept.Name = "Accept";
			this.Accept.Size = new System.Drawing.Size(75, 33);
			this.Accept.TabIndex = 6;
			this.Accept.Text = "Copy";
			this.Accept.UseVisualStyleBackColor = true;
			this.Accept.Click += new System.EventHandler(this.Accept_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(469, 386);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(75, 33);
			this.Cancel.TabIndex = 6;
			this.Cancel.Text = "Cancel";
			this.Cancel.UseVisualStyleBackColor = true;
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// RegexTester
			// 
			this.AcceptButton = this.Accept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(637, 421);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.Accept);
			this.Controls.Add(this.WholeStringMatch);
			this.Controls.Add(this.MatchDetails);
			this.Controls.Add(this.MatchResult);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.InputText);
			this.Controls.Add(this.Pattern);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RegexTester";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Regex Testing";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox Pattern;
		private System.Windows.Forms.TextBox InputText;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label MatchResult;
		private System.Windows.Forms.TreeView MatchDetails;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox WholeStringMatch;
		private System.Windows.Forms.Button Accept;
		private System.Windows.Forms.Button Cancel;
	}
}