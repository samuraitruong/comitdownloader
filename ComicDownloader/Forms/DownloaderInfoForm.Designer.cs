using MetroFramework.Controls;
using System.Windows.Forms;


namespace ComicDownloader.Forms
{
    partial class DownloaderInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloaderInfoForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblUpdated = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblEllapsedTime = new System.Windows.Forms.Label();
            this.groupBox1 = new MetroFramework.Controls.MetroPanel();
            this.btnAbort = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.tabGeneral = new MetroFramework.Controls.MetroTabPage();
            this.tabSearch = new MetroFramework.Controls.MetroTabPage();
            this.searchLoading = new MRG.Controls.UI.LoadingCircle();
            this.listSearchResult = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSearch = new MetroFramework.Controls.MetroButton();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.onlineCheck = new MetroFramework.Controls.MetroCheckBox();
            this.offlineCheck = new MetroFramework.Controls.MetroCheckBox();
            this.tabUpdate = new MetroFramework.Controls.MetroTabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.loading = new MRG.Controls.UI.LoadingCircle();
            this.listLastestUpdate = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.metroTabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listSearchResult)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabUpdate.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listLastestUpdate)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(91, 16);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(38, 13);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.TabStop = true;
            this.lblUrl.Text = "http://";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(90, 42);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(90, 68);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 13);
            this.lblTotal.TabIndex = 5;
            this.lblTotal.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Manga";
            // 
            // lblUpdated
            // 
            this.lblUpdated.AutoSize = true;
            this.lblUpdated.Location = new System.Drawing.Point(91, 95);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(35, 13);
            this.lblUpdated.TabIndex = 7;
            this.lblUpdated.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Last updated";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Time ran";
            // 
            // lblEllapsedTime
            // 
            this.lblEllapsedTime.AutoSize = true;
            this.lblEllapsedTime.Location = new System.Drawing.Point(91, 119);
            this.lblEllapsedTime.Name = "lblEllapsedTime";
            this.lblEllapsedTime.Size = new System.Drawing.Size(35, 13);
            this.lblEllapsedTime.TabIndex = 9;
            this.lblEllapsedTime.Text = "Name";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAbort);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblEllapsedTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lblUrl);
            this.groupBox1.Controls.Add(this.lblUpdated);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.HorizontalScrollbarBarColor = true;
            this.groupBox1.HorizontalScrollbarHighlightOnWheel = false;
            this.groupBox1.HorizontalScrollbarSize = 10;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 369);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.Text = "Info";
            this.groupBox1.VerticalScrollbarBarColor = true;
            this.groupBox1.VerticalScrollbarHighlightOnWheel = false;
            this.groupBox1.VerticalScrollbarSize = 10;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(295, 276);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(119, 35);
            this.btnAbort.TabIndex = 13;
            this.btnAbort.Text = "No, Keep my list";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(114, 276);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(117, 35);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "Agree and Update";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label10
            // 
            this.label10.AllowDrop = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(16, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(519, 86);
            this.label10.TabIndex = 11;
            this.label10.Text = resources.GetString("label10.Text");
            this.label10.UseCompatibleTextRendering = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(359, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.tabGeneral);
            this.metroTabControl1.Controls.Add(this.tabSearch);
            this.metroTabControl1.Controls.Add(this.tabUpdate);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(565, 408);
            this.metroTabControl1.TabIndex = 14;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.groupBox1);
            this.tabGeneral.HorizontalScrollbarBarColor = true;
            this.tabGeneral.HorizontalScrollbarHighlightOnWheel = false;
            this.tabGeneral.HorizontalScrollbarSize = 10;
            this.tabGeneral.Location = new System.Drawing.Point(4, 35);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Size = new System.Drawing.Size(557, 369);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "Update List";
            this.tabGeneral.VerticalScrollbarBarColor = true;
            this.tabGeneral.VerticalScrollbarHighlightOnWheel = false;
            this.tabGeneral.VerticalScrollbarSize = 10;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.searchLoading);
            this.tabSearch.Controls.Add(this.listSearchResult);
            this.tabSearch.Controls.Add(this.btnSearch);
            this.tabSearch.Controls.Add(this.txtKeyword);
            this.tabSearch.Controls.Add(this.onlineCheck);
            this.tabSearch.Controls.Add(this.offlineCheck);
            this.tabSearch.HorizontalScrollbarBarColor = true;
            this.tabSearch.HorizontalScrollbarHighlightOnWheel = false;
            this.tabSearch.HorizontalScrollbarSize = 10;
            this.tabSearch.Location = new System.Drawing.Point(4, 35);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Size = new System.Drawing.Size(557, 369);
            this.tabSearch.TabIndex = 2;
            this.tabSearch.Text = "Search";
            this.tabSearch.VerticalScrollbarBarColor = true;
            this.tabSearch.VerticalScrollbarHighlightOnWheel = false;
            this.tabSearch.VerticalScrollbarSize = 10;
            // 
            // searchLoading
            // 
            this.searchLoading.Active = true;
            this.searchLoading.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.searchLoading.Color = System.Drawing.Color.DarkGray;
            this.searchLoading.InnerCircleRadius = 6;
            this.searchLoading.Location = new System.Drawing.Point(236, 191);
            this.searchLoading.Name = "searchLoading";
            this.searchLoading.NumberSpoke = 9;
            this.searchLoading.OuterCircleRadius = 7;
            this.searchLoading.RotationSpeed = 40;
            this.searchLoading.Size = new System.Drawing.Size(42, 29);
            this.searchLoading.SpokeThickness = 4;
            this.searchLoading.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.Firefox;
            this.searchLoading.TabIndex = 22;
            this.searchLoading.Text = "loadingCircle1";
            this.searchLoading.Visible = false;
            // 
            // listSearchResult
            // 
            this.listSearchResult.AllColumns.Add(this.olvColumn1);
            this.listSearchResult.AllColumns.Add(this.olvColumn4);
            this.listSearchResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn4});
            this.listSearchResult.ContextMenuStrip = this.contextMenuStrip1;
            this.listSearchResult.Location = new System.Drawing.Point(4, 47);
            this.listSearchResult.Name = "listSearchResult";
            this.listSearchResult.Size = new System.Drawing.Size(545, 322);
            this.listSearchResult.TabIndex = 10;
            this.listSearchResult.UseCompatibleStateImageBehavior = false;
            this.listSearchResult.View = System.Windows.Forms.View.Details;
            this.listSearchResult.SelectionChanged += new System.EventHandler(this.listLastestUpdate_SelectionChanged);
            this.listSearchResult.DoubleClick += new System.EventHandler(this.listLastestUpdate_DoubleClick);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 246;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Url";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.CheckBoxes = true;
            this.olvColumn4.Hyperlink = true;
            this.olvColumn4.Searchable = false;
            this.olvColumn4.Sortable = false;
            this.olvColumn4.Text = "URL";
            this.olvColumn4.UseFiltering = false;
            this.olvColumn4.Width = 275;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.addToQueueToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 120);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // addToQueueToolStripMenuItem
            // 
            this.addToQueueToolStripMenuItem.Name = "addToQueueToolStripMenuItem";
            this.addToQueueToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.addToQueueToolStripMenuItem.Text = "Add to queue";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(473, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 31);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(236, 16);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(231, 20);
            this.txtKeyword.TabIndex = 8;
            this.txtKeyword.Text = "Dragon ball";
            // 
            // onlineCheck
            // 
            this.onlineCheck.AutoSize = true;
            this.onlineCheck.Checked = true;
            this.onlineCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onlineCheck.Location = new System.Drawing.Point(120, 16);
            this.onlineCheck.Name = "onlineCheck";
            this.onlineCheck.Size = new System.Drawing.Size(96, 15);
            this.onlineCheck.TabIndex = 7;
            this.onlineCheck.Text = "Online Search";
            this.onlineCheck.UseVisualStyleBackColor = true;
            // 
            // offlineCheck
            // 
            this.offlineCheck.AutoSize = true;
            this.offlineCheck.Checked = true;
            this.offlineCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.offlineCheck.Location = new System.Drawing.Point(3, 16);
            this.offlineCheck.Name = "offlineCheck";
            this.offlineCheck.Size = new System.Drawing.Size(97, 15);
            this.offlineCheck.TabIndex = 6;
            this.offlineCheck.Text = "Offline Search";
            this.offlineCheck.UseVisualStyleBackColor = true;
            // 
            // tabUpdate
            // 
            this.tabUpdate.Controls.Add(this.panel1);
            this.tabUpdate.HorizontalScrollbarBarColor = true;
            this.tabUpdate.HorizontalScrollbarHighlightOnWheel = false;
            this.tabUpdate.HorizontalScrollbarSize = 10;
            this.tabUpdate.Location = new System.Drawing.Point(4, 35);
            this.tabUpdate.Name = "tabUpdate";
            this.tabUpdate.Size = new System.Drawing.Size(557, 369);
            this.tabUpdate.TabIndex = 1;
            this.tabUpdate.Text = "Lastest Manga";
            this.tabUpdate.VerticalScrollbarBarColor = true;
            this.tabUpdate.VerticalScrollbarHighlightOnWheel = false;
            this.tabUpdate.VerticalScrollbarSize = 10;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.loading);
            this.panel1.Controls.Add(this.listLastestUpdate);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 369);
            this.panel1.TabIndex = 22;
            // 
            // loading
            // 
            this.loading.Active = true;
            this.loading.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.loading.Color = System.Drawing.Color.DarkGray;
            this.loading.InnerCircleRadius = 6;
            this.loading.Location = new System.Drawing.Point(3, 337);
            this.loading.Name = "loading";
            this.loading.NumberSpoke = 9;
            this.loading.OuterCircleRadius = 7;
            this.loading.RotationSpeed = 40;
            this.loading.Size = new System.Drawing.Size(42, 29);
            this.loading.SpokeThickness = 4;
            this.loading.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.Firefox;
            this.loading.TabIndex = 21;
            this.loading.Text = "loadingCircle1";
            // 
            // listLastestUpdate
            // 
            this.listLastestUpdate.AllColumns.Add(this.olvColumn2);
            this.listLastestUpdate.AllColumns.Add(this.olvColumn3);
            this.listLastestUpdate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn2,
            this.olvColumn3});
            this.listLastestUpdate.ContextMenuStrip = this.contextMenuStrip1;
            this.listLastestUpdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLastestUpdate.FullRowSelect = true;
            this.listLastestUpdate.Location = new System.Drawing.Point(0, 10);
            this.listLastestUpdate.Name = "listLastestUpdate";
            this.listLastestUpdate.OverlayText.Text = "Lastest";
            this.listLastestUpdate.OverlayText.TextColor = System.Drawing.Color.Lavender;
            this.listLastestUpdate.Size = new System.Drawing.Size(557, 359);
            this.listLastestUpdate.TabIndex = 2;
            this.listLastestUpdate.UseCompatibleStateImageBehavior = false;
            this.listLastestUpdate.View = System.Windows.Forms.View.Details;
            this.listLastestUpdate.SelectionChanged += new System.EventHandler(this.listLastestUpdate_SelectionChanged);
            this.listLastestUpdate.DoubleClick += new System.EventHandler(this.listLastestUpdate_DoubleClick);
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Name";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.Text = "Name";
            this.olvColumn2.UseInitialLetterForGroup = true;
            this.olvColumn2.Width = 200;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Url";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.Groupable = false;
            this.olvColumn3.Hyperlink = true;
            this.olvColumn3.Text = "URL";
            this.olvColumn3.Width = 150;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 10);
            this.panel2.TabIndex = 0;
            // 
            // DownloaderInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 488);
            this.Controls.Add(this.metroTabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DownloaderInfoForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Downloader Info";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.metroTabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listSearchResult)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabUpdate.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listLastestUpdate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUpdated;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblEllapsedTime;
        private MetroPanel groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage tabGeneral;
        private MetroFramework.Controls.MetroTabPage tabUpdate;
        private MetroFramework.Controls.MetroTabPage tabSearch;
        private BrightIdeasSoftware.ObjectListView listLastestUpdate;
        private BrightIdeasSoftware.ObjectListView listSearchResult;
        private MetroButton btnSearch;
        private System.Windows.Forms.TextBox txtKeyword;
        private MetroCheckBox onlineCheck;
        private MetroCheckBox offlineCheck;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private MRG.Controls.UI.LoadingCircle loading;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private MRG.Controls.UI.LoadingCircle searchLoading;
    }
}