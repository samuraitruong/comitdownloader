namespace ComicDownloader.Forms
{
    partial class QueueDownloadForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QueueDownloadForm));
            this.lsvItems = new BrightIdeasSoftware.DataListView();
            this.olvProviderName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvStoryName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvChapterName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvChapterUrl = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvStatus = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvSize = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvProgress = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.heightRenderer = new BrightIdeasSoftware.BarRenderer();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRemovAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuForceDownload = new System.Windows.Forms.ToolStripMenuItem();
            this.moveUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveBottomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barRenderer1 = new BrightIdeasSoftware.BarRenderer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.lsvItems)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lsvItems
            // 
            this.lsvItems.AllowColumnReorder = true;
            this.lsvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvProviderName,
            this.olvStoryName,
            this.olvChapterName,
            this.olvChapterUrl,
            this.olvStatus,
            this.olvSize,
            this.olvProgress});
            this.lsvItems.ContextMenuStrip = this.contextMenuStrip1;
            this.lsvItems.DataSource = null;
            this.lsvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvItems.EmptyListMsg = "There is no item";
            this.lsvItems.EmptyListMsgFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvItems.FullRowSelect = true;
            this.lsvItems.GridLines = true;
            this.lsvItems.Location = new System.Drawing.Point(0, 0);
            this.lsvItems.Name = "lsvItems";
            this.lsvItems.OverlayText.Alignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.lsvItems.OverlayText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lsvItems.OverlayText.Font = new System.Drawing.Font("Segoe UI Semibold", 54F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvItems.OverlayText.Rotation = 35;
            this.lsvItems.OverlayText.Text = "Comic Downloader v1.0";
            this.lsvItems.OverlayText.TextColor = System.Drawing.Color.MidnightBlue;
            this.lsvItems.OverlayText.Transparency = 40;
            this.lsvItems.Size = new System.Drawing.Size(866, 251);
            this.lsvItems.TabIndex = 2;
            this.lsvItems.UseCompatibleStateImageBehavior = false;
            this.lsvItems.UseExplorerTheme = true;
            this.lsvItems.View = System.Windows.Forms.View.Details;
            // 
            // olvProviderName
            // 
            this.olvProviderName.AspectName = "ProviderName";
            this.olvProviderName.CellPadding = null;
            this.olvProviderName.IsTileViewColumn = true;
            this.olvProviderName.Text = "Provider Name";
            this.olvProviderName.Width = 120;
            // 
            // olvStoryName
            // 
            this.olvStoryName.AspectName = "StoryName";
            this.olvStoryName.CellPadding = null;
            this.olvStoryName.IsTileViewColumn = true;
            this.olvStoryName.Text = "Story Name";
            this.olvStoryName.Width = 120;
            // 
            // olvChapterName
            // 
            this.olvChapterName.AspectName = "ChapterName";
            this.olvChapterName.CellPadding = null;
            this.olvChapterName.IsTileViewColumn = true;
            this.olvChapterName.Text = "Chapter name";
            this.olvChapterName.Width = 80;
            // 
            // olvChapterUrl
            // 
            this.olvChapterUrl.AspectName = "ChapterUrl";
            this.olvChapterUrl.CellPadding = null;
            this.olvChapterUrl.Groupable = false;
            this.olvChapterUrl.IsTileViewColumn = true;
            this.olvChapterUrl.Text = "Chapter URL";
            this.olvChapterUrl.Width = 150;
            // 
            // olvStatus
            // 
            this.olvStatus.AspectName = "Status";
            this.olvStatus.CellPadding = null;
            this.olvStatus.Groupable = false;
            this.olvStatus.IsTileViewColumn = true;
            this.olvStatus.Text = "Status";
            // 
            // olvSize
            // 
            this.olvSize.AspectName = "Size";
            this.olvSize.CellPadding = null;
            this.olvSize.Groupable = false;
            this.olvSize.IsTileViewColumn = true;
            this.olvSize.Text = "Size";
            // 
            // olvProgress
            // 
            this.olvProgress.AspectName = "Progress";
            this.olvProgress.CellPadding = null;
            this.olvProgress.Groupable = false;
            this.olvProgress.Renderer = this.heightRenderer;
            this.olvProgress.Searchable = false;
            this.olvProgress.Sortable = false;
            this.olvProgress.Text = "Progress";
            // 
            // heightRenderer
            // 
            this.heightRenderer.BackgroundColor = System.Drawing.Color.Green;
            this.heightRenderer.UseStandardBar = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRemovAll,
            this.mnuRemoveSelection,
            this.mnuForceDownload,
            this.moveUpToolStripMenuItem,
            this.moveDownToolStripMenuItem,
            this.moveTopToolStripMenuItem,
            this.moveBottomToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(160, 180);
            // 
            // mnuRemovAll
            // 
            this.mnuRemovAll.Image = global::ComicDownloader.Properties.Resources._1364717902_list_remove;
            this.mnuRemovAll.Name = "mnuRemovAll";
            this.mnuRemovAll.Size = new System.Drawing.Size(159, 22);
            this.mnuRemovAll.Text = "Remove All";
            this.mnuRemovAll.Click += new System.EventHandler(this.mnuRemovAll_Click);
            // 
            // mnuRemoveSelection
            // 
            this.mnuRemoveSelection.Image = global::ComicDownloader.Properties.Resources._1364717999_delete;
            this.mnuRemoveSelection.Name = "mnuRemoveSelection";
            this.mnuRemoveSelection.Size = new System.Drawing.Size(159, 22);
            this.mnuRemoveSelection.Text = "Remove Selection";
            // 
            // mnuForceDownload
            // 
            this.mnuForceDownload.Image = global::ComicDownloader.Properties.Resources._1364718151_stopwatch_start;
            this.mnuForceDownload.Name = "mnuForceDownload";
            this.mnuForceDownload.Size = new System.Drawing.Size(159, 22);
            this.mnuForceDownload.Text = "Force Download";
            // 
            // moveUpToolStripMenuItem
            // 
            this.moveUpToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364718266_up;
            this.moveUpToolStripMenuItem.Name = "moveUpToolStripMenuItem";
            this.moveUpToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.moveUpToolStripMenuItem.Text = "Move Up";
            // 
            // moveDownToolStripMenuItem
            // 
            this.moveDownToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364718322_emblem_downloads;
            this.moveDownToolStripMenuItem.Name = "moveDownToolStripMenuItem";
            this.moveDownToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.moveDownToolStripMenuItem.Text = "Move Down";
            // 
            // moveTopToolStripMenuItem
            // 
            this.moveTopToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364718270_go_top;
            this.moveTopToolStripMenuItem.Name = "moveTopToolStripMenuItem";
            this.moveTopToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.moveTopToolStripMenuItem.Text = "Move Top";
            // 
            // moveBottomToolStripMenuItem
            // 
            this.moveBottomToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364718320_go_bottom;
            this.moveBottomToolStripMenuItem.Name = "moveBottomToolStripMenuItem";
            this.moveBottomToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.moveBottomToolStripMenuItem.Text = "Move Bottom";
            // 
            // barRenderer1
            // 
            this.barRenderer1.UseStandardBar = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 251);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(866, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "StoryName";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.DisplayIndex = 0;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "StoryUrl";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.DisplayIndex = 1;
            // 
            // QueueDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 273);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.lsvItems);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QueueDownloadForm";
            this.Text = "Queue Download";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QueueDownloadForm_FormClosing);
            this.Load += new System.EventHandler(this.QueueDownloadForm_Load);
            this.MdiChildActivate += new System.EventHandler(this.QueueDownloadForm_MdiChildActivate);
            this.Enter += new System.EventHandler(this.QueueDownloadForm_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.lsvItems)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private BrightIdeasSoftware.DataListView lsvItems;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvProviderName;
        private BrightIdeasSoftware.OLVColumn olvStoryName;
        private BrightIdeasSoftware.OLVColumn olvStatus;
        private BrightIdeasSoftware.OLVColumn olvSize;
        private BrightIdeasSoftware.OLVColumn olvChapterUrl;
        private BrightIdeasSoftware.OLVColumn olvChapterName;
        private BrightIdeasSoftware.OLVColumn olvProgress;
        private BrightIdeasSoftware.BarRenderer barRenderer1;
        private BrightIdeasSoftware.BarRenderer heightRenderer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuRemovAll;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveSelection;
        private System.Windows.Forms.ToolStripMenuItem mnuForceDownload;
        private System.Windows.Forms.ToolStripMenuItem moveUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveBottomToolStripMenuItem;
    }
}