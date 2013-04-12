namespace ComicDownloader.Forms
{
    partial class SearchForm
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
            BrightIdeasSoftware.CellStyle cellStyle1 = new BrightIdeasSoftware.CellStyle();
            BrightIdeasSoftware.CellStyle cellStyle2 = new BrightIdeasSoftware.CellStyle();
            BrightIdeasSoftware.CellStyle cellStyle3 = new BrightIdeasSoftware.CellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addThisStoryToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.hyperlinkStyle1 = new BrightIdeasSoftware.HyperlinkStyle();
            this.miniToolStrip = new System.Windows.Forms.StatusStrip();
            this.lvLastestUpdates = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.loadingCircle1 = new MRG.Controls.UI.LoadingCircle();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOnlineSearch = new System.Windows.Forms.Button();
            this.bntCacheSearch = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lvLastestUpdates)).BeginInit();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.addThisStoryToQueueToolStripMenuItem,
            this.toolStripMenuItem2});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(142, 76);
            this.contextMenuStrip1.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.contextMenuStrip1_Closed);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::ComicDownloader.Properties.Resources._1365319718_Globe1;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem1.Text = "Browse";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(138, 6);
            // 
            // addThisStoryToQueueToolStripMenuItem
            // 
            this.addThisStoryToQueueToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364410878_Add;
            this.addThisStoryToQueueToolStripMenuItem.Name = "addThisStoryToQueueToolStripMenuItem";
            this.addThisStoryToQueueToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.addThisStoryToQueueToolStripMenuItem.Text = "Add to Queue";
            this.addThisStoryToQueueToolStripMenuItem.Click += new System.EventHandler(this.addThisStoryToQueueToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::ComicDownloader.Properties.Resources._1363942937_ark2;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(141, 22);
            this.toolStripMenuItem2.Text = "Download";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // hyperlinkStyle1
            // 
            cellStyle1.Font = null;
            cellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.hyperlinkStyle1.Normal = cellStyle1;
            cellStyle2.Font = null;
            cellStyle2.FontStyle = System.Drawing.FontStyle.Underline;
            this.hyperlinkStyle1.Over = cellStyle2;
            this.hyperlinkStyle1.OverCursor = System.Windows.Forms.Cursors.Hand;
            cellStyle3.Font = null;
            cellStyle3.ForeColor = System.Drawing.Color.Purple;
            this.hyperlinkStyle1.Visited = cellStyle3;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Location = new System.Drawing.Point(103, 0);
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.Size = new System.Drawing.Size(561, 20);
            this.miniToolStrip.TabIndex = 1;
            // 
            // lvLastestUpdates
            // 
            this.lvLastestUpdates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn4});
            this.lvLastestUpdates.ContextMenuStrip = this.contextMenuStrip1;
            this.lvLastestUpdates.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvLastestUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLastestUpdates.EmptyListMsg = "Searching will take few minutes to complete";
            this.lvLastestUpdates.FullRowSelect = true;
            this.lvLastestUpdates.GridLines = true;
            this.lvLastestUpdates.HeaderUsesThemes = false;
            this.lvLastestUpdates.Location = new System.Drawing.Point(0, 48);
            this.lvLastestUpdates.Name = "lvLastestUpdates";
            this.lvLastestUpdates.SelectColumnsOnRightClickBehaviour = BrightIdeasSoftware.ObjectListView.ColumnSelectBehaviour.Submenu;
            this.lvLastestUpdates.ShowCommandMenuOnRightClick = true;
            this.lvLastestUpdates.Size = new System.Drawing.Size(692, 251);
            this.lvLastestUpdates.TabIndex = 0;
            this.lvLastestUpdates.UseCompatibleStateImageBehavior = false;
            this.lvLastestUpdates.UseFilterIndicator = true;
            this.lvLastestUpdates.UseFiltering = true;
            this.lvLastestUpdates.UseHotItem = true;
            this.lvLastestUpdates.UseHyperlinks = true;
            this.lvLastestUpdates.View = System.Windows.Forms.View.Details;
            this.lvLastestUpdates.SelectedIndexChanged += new System.EventHandler(this.lvLastestUpdates_SelectedIndexChanged);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Provider";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "Site";
            this.olvColumn1.Width = 167;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "StoryName";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.Text = "Story name";
            this.olvColumn2.Width = 189;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "StoryUrl";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.Groupable = false;
            this.olvColumn4.Hyperlink = true;
            this.olvColumn4.Text = "Url";
            this.olvColumn4.Width = 251;
            // 
            // olvColumn3
            // 
            this.olvColumn3.CellPadding = null;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.loadingCircle1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnOnlineSearch);
            this.panel1.Controls.Add(this.bntCacheSearch);
            this.panel1.Controls.Add(this.txtKeyword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 48);
            this.panel1.TabIndex = 2;
            // 
            // loadingCircle1
            // 
            this.loadingCircle1.Active = false;
            this.loadingCircle1.Color = System.Drawing.Color.DarkGray;
            this.loadingCircle1.InnerCircleRadius = 6;
            this.loadingCircle1.Location = new System.Drawing.Point(591, 13);
            this.loadingCircle1.Name = "loadingCircle1";
            this.loadingCircle1.NumberSpoke = 9;
            this.loadingCircle1.OuterCircleRadius = 7;
            this.loadingCircle1.RotationSpeed = 100;
            this.loadingCircle1.Size = new System.Drawing.Size(75, 23);
            this.loadingCircle1.SpokeThickness = 4;
            this.loadingCircle1.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.Firefox;
            this.loadingCircle1.TabIndex = 5;
            this.loadingCircle1.Text = "loadingCircle1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "(Ex: Dragon Ball, One Piece...)";
            // 
            // btnOnlineSearch
            // 
            this.btnOnlineSearch.Location = new System.Drawing.Point(384, 4);
            this.btnOnlineSearch.Name = "btnOnlineSearch";
            this.btnOnlineSearch.Size = new System.Drawing.Size(119, 23);
            this.btnOnlineSearch.TabIndex = 3;
            this.btnOnlineSearch.Text = "Search Online";
            this.btnOnlineSearch.UseVisualStyleBackColor = true;
            this.btnOnlineSearch.Click += new System.EventHandler(this.btnOnlineSearch_Click);
            // 
            // bntCacheSearch
            // 
            this.bntCacheSearch.Location = new System.Drawing.Point(259, 4);
            this.bntCacheSearch.Name = "bntCacheSearch";
            this.bntCacheSearch.Size = new System.Drawing.Size(119, 23);
            this.bntCacheSearch.TabIndex = 2;
            this.bntCacheSearch.Text = "Search On Cache";
            this.bntCacheSearch.UseVisualStyleBackColor = true;
            this.bntCacheSearch.Click += new System.EventHandler(this.bntCacheSearch_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(55, 5);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(179, 20);
            this.txtKeyword.TabIndex = 1;
            this.txtKeyword.Text = "Dragon Ball";
            this.txtKeyword.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtKeyword_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 277);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(692, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(400, 16);
            this.progressBar.Click += new System.EventHandler(this.progressBar_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 299);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lvLastestUpdates);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchForm";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.LastestChapterUpdateForm_Load);
            this.Resize += new System.EventHandler(this.LastestChapterUpdateForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lvLastestUpdates)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addThisStoryToQueueToolStripMenuItem;
        private BrightIdeasSoftware.HyperlinkStyle hyperlinkStyle1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.StatusStrip miniToolStrip;
        private BrightIdeasSoftware.ObjectListView lvLastestUpdates;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Button btnOnlineSearch;
        private System.Windows.Forms.Button bntCacheSearch;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private MRG.Controls.UI.LoadingCircle loadingCircle1;
        private System.Windows.Forms.Label label2;
    }
}