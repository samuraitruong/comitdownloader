namespace DDay.Update.ConfigurationTool.Forms
{
    partial class MainForm
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOptions = new System.Windows.Forms.Button();
            this.panelManualInfo = new System.Windows.Forms.Panel();
            this.btnBrowseIcon = new System.Windows.Forms.Button();
            this.txtIconFile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBrowseExec = new System.Windows.Forms.Button();
            this.txtMainExec = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbManualConfig = new System.Windows.Forms.RadioButton();
            this.rbUseDistribution = new System.Windows.Forms.RadioButton();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbUpdateNotifier = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateBootstrap = new System.Windows.Forms.Button();
            this.btnVerifyURI = new System.Windows.Forms.Button();
            this.txtUpdateURI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.descUC = new DDay.Update.ConfigurationTool.UserControls.DescriptionUserControl();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFileOpenDepManifest = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRecent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelManualInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "application";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.panel1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.label6);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(447, 355);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(447, 379);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnOptions);
            this.panel1.Controls.Add(this.panelManualInfo);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.txtDestinationFolder);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cbUpdateNotifier);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCreateBootstrap);
            this.panel1.Controls.Add(this.btnVerifyURI);
            this.panel1.Controls.Add(this.txtUpdateURI);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.descUC);
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 354);
            this.panel1.TabIndex = 18;
            this.panel1.Visible = false;
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOptions.Location = new System.Drawing.Point(11, 320);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(75, 23);
            this.btnOptions.TabIndex = 42;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // panelManualInfo
            // 
            this.panelManualInfo.Controls.Add(this.btnBrowseIcon);
            this.panelManualInfo.Controls.Add(this.txtIconFile);
            this.panelManualInfo.Controls.Add(this.label5);
            this.panelManualInfo.Controls.Add(this.btnBrowseExec);
            this.panelManualInfo.Controls.Add(this.txtMainExec);
            this.panelManualInfo.Controls.Add(this.label4);
            this.panelManualInfo.Enabled = false;
            this.panelManualInfo.Location = new System.Drawing.Point(15, 142);
            this.panelManualInfo.Name = "panelManualInfo";
            this.panelManualInfo.Size = new System.Drawing.Size(420, 56);
            this.panelManualInfo.TabIndex = 41;
            // 
            // btnBrowseIcon
            // 
            this.btnBrowseIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseIcon.Location = new System.Drawing.Point(346, 32);
            this.btnBrowseIcon.Name = "btnBrowseIcon";
            this.btnBrowseIcon.Size = new System.Drawing.Size(74, 23);
            this.btnBrowseIcon.TabIndex = 46;
            this.btnBrowseIcon.Text = "&Browse";
            this.btnBrowseIcon.UseVisualStyleBackColor = true;
            this.btnBrowseIcon.Click += new System.EventHandler(this.btnBrowseIcon_Click);
            // 
            // txtIconFile
            // 
            this.txtIconFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIconFile.Location = new System.Drawing.Point(130, 32);
            this.txtIconFile.Margin = new System.Windows.Forms.Padding(0);
            this.txtIconFile.Name = "txtIconFile";
            this.txtIconFile.Size = new System.Drawing.Size(213, 20);
            this.txtIconFile.TabIndex = 45;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 32);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 21);
            this.label5.TabIndex = 44;
            this.label5.Text = "Icon File";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBrowseExec
            // 
            this.btnBrowseExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseExec.Location = new System.Drawing.Point(346, 5);
            this.btnBrowseExec.Name = "btnBrowseExec";
            this.btnBrowseExec.Size = new System.Drawing.Size(74, 23);
            this.btnBrowseExec.TabIndex = 43;
            this.btnBrowseExec.Text = "&Browse";
            this.btnBrowseExec.UseVisualStyleBackColor = true;
            this.btnBrowseExec.Click += new System.EventHandler(this.btnBrowseExec_Click);
            // 
            // txtMainExec
            // 
            this.txtMainExec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMainExec.Location = new System.Drawing.Point(130, 7);
            this.txtMainExec.Margin = new System.Windows.Forms.Padding(0);
            this.txtMainExec.Name = "txtMainExec";
            this.txtMainExec.Size = new System.Drawing.Size(213, 20);
            this.txtMainExec.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 21);
            this.label4.TabIndex = 41;
            this.label4.Text = "Main Executable";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbManualConfig);
            this.groupBox1.Controls.Add(this.rbUseDistribution);
            this.groupBox1.Location = new System.Drawing.Point(11, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 129);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // rbManualConfig
            // 
            this.rbManualConfig.AutoSize = true;
            this.rbManualConfig.Location = new System.Drawing.Point(9, 45);
            this.rbManualConfig.Name = "rbManualConfig";
            this.rbManualConfig.Size = new System.Drawing.Size(191, 20);
            this.rbManualConfig.TabIndex = 34;
            this.rbManualConfig.Text = "Manually Provide File Information";
            this.rbManualConfig.UseVisualStyleBackColor = true;
            this.rbManualConfig.CheckedChanged += new System.EventHandler(this.rbFileInfo_CheckedChanged);
            // 
            // rbUseDistribution
            // 
            this.rbUseDistribution.AutoSize = true;
            this.rbUseDistribution.Checked = true;
            this.rbUseDistribution.Location = new System.Drawing.Point(9, 19);
            this.rbUseDistribution.Name = "rbUseDistribution";
            this.rbUseDistribution.Size = new System.Drawing.Size(230, 20);
            this.rbUseDistribution.TabIndex = 33;
            this.rbUseDistribution.TabStop = true;
            this.rbUseDistribution.Text = "Determine File Information Automatically";
            this.rbUseDistribution.UseVisualStyleBackColor = true;
            this.rbUseDistribution.CheckedChanged += new System.EventHandler(this.rbFileInfo_CheckedChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(363, 293);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 25;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationFolder.Location = new System.Drawing.Point(145, 295);
            this.txtDestinationFolder.Margin = new System.Windows.Forms.Padding(0);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.Size = new System.Drawing.Size(215, 20);
            this.txtDestinationFolder.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Location = new System.Drawing.Point(12, 294);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 21);
            this.label3.TabIndex = 23;
            this.label3.Text = "Destination Folder";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbUpdateNotifier
            // 
            this.cbUpdateNotifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbUpdateNotifier.DisplayMember = "Text";
            this.cbUpdateNotifier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUpdateNotifier.FormattingEnabled = true;
            this.cbUpdateNotifier.Location = new System.Drawing.Point(145, 259);
            this.cbUpdateNotifier.Margin = new System.Windows.Forms.Padding(0);
            this.cbUpdateNotifier.Name = "cbUpdateNotifier";
            this.cbUpdateNotifier.Size = new System.Drawing.Size(293, 24);
            this.cbUpdateNotifier.TabIndex = 22;
            this.cbUpdateNotifier.ValueMember = "Value";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.Location = new System.Drawing.Point(12, 262);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 21);
            this.label2.TabIndex = 21;
            this.label2.Text = "Update Notifier (GUI)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCreateBootstrap
            // 
            this.btnCreateBootstrap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateBootstrap.Location = new System.Drawing.Point(145, 320);
            this.btnCreateBootstrap.Margin = new System.Windows.Forms.Padding(0);
            this.btnCreateBootstrap.Name = "btnCreateBootstrap";
            this.btnCreateBootstrap.Size = new System.Drawing.Size(157, 23);
            this.btnCreateBootstrap.TabIndex = 20;
            this.btnCreateBootstrap.Text = "&Create Bootstrap";
            this.btnCreateBootstrap.UseVisualStyleBackColor = true;
            this.btnCreateBootstrap.Click += new System.EventHandler(this.btnCreateBootstrap_Click);
            // 
            // btnVerifyURI
            // 
            this.btnVerifyURI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerifyURI.Location = new System.Drawing.Point(363, 230);
            this.btnVerifyURI.Margin = new System.Windows.Forms.Padding(0);
            this.btnVerifyURI.Name = "btnVerifyURI";
            this.btnVerifyURI.Size = new System.Drawing.Size(75, 23);
            this.btnVerifyURI.TabIndex = 19;
            this.btnVerifyURI.Text = "Verify URI";
            this.btnVerifyURI.UseVisualStyleBackColor = true;
            this.btnVerifyURI.Click += new System.EventHandler(this.btnVerifyURI_Click);
            // 
            // txtUpdateURI
            // 
            this.txtUpdateURI.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateURI.Location = new System.Drawing.Point(145, 206);
            this.txtUpdateURI.Margin = new System.Windows.Forms.Padding(0);
            this.txtUpdateURI.Name = "txtUpdateURI";
            this.txtUpdateURI.Size = new System.Drawing.Size(294, 20);
            this.txtUpdateURI.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Location = new System.Drawing.Point(12, 207);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "Update URI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // descUC
            // 
            this.descUC.Description = null;
            this.descUC.Dock = System.Windows.Forms.DockStyle.Top;
            this.descUC.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.descUC.Location = new System.Drawing.Point(0, 0);
            this.descUC.Margin = new System.Windows.Forms.Padding(3, 7, 3, 7);
            this.descUC.Name = "descUC";
            this.descUC.Padding = new System.Windows.Forms.Padding(5, 11, 5, 11);
            this.descUC.Size = new System.Drawing.Size(447, 138);
            this.descUC.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(423, 64);
            this.label6.TabIndex = 17;
            this.label6.Text = "To begin, click \"File\" -> \"Open Deployment Manifest\".\n\nYour deployment manifest i" +
                "s a file with an \".application\" extension created by ClickOnce when you publish " +
                "your application.";
            // 
            // menuStrip
            // 
            this.menuStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(447, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFileOpenDepManifest,
            this.tsmiRecent,
            this.toolStripSeparator1,
            this.tsmiFileExit});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(37, 20);
            this.tsmiFile.Text = "&File";
            // 
            // tsmiFileOpenDepManifest
            // 
            this.tsmiFileOpenDepManifest.Name = "tsmiFileOpenDepManifest";
            this.tsmiFileOpenDepManifest.Size = new System.Drawing.Size(220, 22);
            this.tsmiFileOpenDepManifest.Text = "Open &Deployment Manifest";
            this.tsmiFileOpenDepManifest.Click += new System.EventHandler(this.tsmiFileOpenDepManFromURL_Click);
            // 
            // tsmiRecent
            // 
            this.tsmiRecent.Name = "tsmiRecent";
            this.tsmiRecent.Size = new System.Drawing.Size(220, 22);
            this.tsmiRecent.Text = "&Recent";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(217, 6);
            // 
            // tsmiFileExit
            // 
            this.tsmiFileExit.Name = "tsmiFileExit";
            this.tsmiFileExit.Size = new System.Drawing.Size(220, 22);
            this.tsmiFileExit.Text = "E&xit";
            this.tsmiFileExit.Click += new System.EventHandler(this.tsmiFileExit_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(179, 22);
            this.tsmiAbout.Text = "&About DDay.Update";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 379);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DDay.Update Configuration Tool";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelManualInfo.ResumeLayout(false);
            this.panelManualInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileExit;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDestinationFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbUpdateNotifier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateBootstrap;
        private System.Windows.Forms.Button btnVerifyURI;
        private System.Windows.Forms.TextBox txtUpdateURI;
        private System.Windows.Forms.Label label1;
        private DDay.Update.ConfigurationTool.UserControls.DescriptionUserControl descUC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelManualInfo;
        private System.Windows.Forms.RadioButton rbManualConfig;
        private System.Windows.Forms.RadioButton rbUseDistribution;
        private System.Windows.Forms.Button btnBrowseIcon;
        private System.Windows.Forms.TextBox txtIconFile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnBrowseExec;
        private System.Windows.Forms.TextBox txtMainExec;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiFileOpenDepManifest;
        private System.Windows.Forms.ToolStripMenuItem tsmiRecent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
    }
}