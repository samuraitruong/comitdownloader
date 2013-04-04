namespace ComicDownloader.Forms
{
    partial class LastestChapterUpdateForm
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
            this.lvLastestUpdates = new BrightIdeasSoftware.DataListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.downloadThisChapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadAllChapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addChapterToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addThisStoryToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAllChapterUpdatesToQueueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readThisChapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.hyperlinkStyle1 = new BrightIdeasSoftware.HyperlinkStyle();
            ((System.ComponentModel.ISupportInitialize)(this.lvLastestUpdates)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvLastestUpdates
            // 
            this.lvLastestUpdates.AllColumns.Add(this.olvColumn1);
            this.lvLastestUpdates.AllColumns.Add(this.olvColumn2);
            this.lvLastestUpdates.AllColumns.Add(this.olvColumn3);
            this.lvLastestUpdates.AllColumns.Add(this.olvColumn4);
            this.lvLastestUpdates.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3,
            this.olvColumn4});
            this.lvLastestUpdates.ContextMenuStrip = this.contextMenuStrip1;
            this.lvLastestUpdates.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvLastestUpdates.DataSource = null;
            this.lvLastestUpdates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLastestUpdates.EmptyListMsg = "please waiting in a couple of second to system update lastest chapter from provid" +
                "ers";
            this.lvLastestUpdates.FullRowSelect = true;
            this.lvLastestUpdates.GridLines = true;
            this.lvLastestUpdates.Location = new System.Drawing.Point(3, 3);
            this.lvLastestUpdates.Name = "lvLastestUpdates";
            this.lvLastestUpdates.Size = new System.Drawing.Size(735, 231);
            this.lvLastestUpdates.TabIndex = 0;
            this.lvLastestUpdates.UseCompatibleStateImageBehavior = false;
            this.lvLastestUpdates.UseHyperlinks = true;
            this.lvLastestUpdates.View = System.Windows.Forms.View.Details;
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
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "ChapterName";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.Text = "Chapter Name";
            this.olvColumn3.Width = 208;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "ChapterUrl";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.Groupable = false;
            this.olvColumn4.Hyperlink = true;
            this.olvColumn4.Text = "ChapterUrl";
            this.olvColumn4.Width = 251;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadThisChapterToolStripMenuItem,
            this.downloadAllChapterToolStripMenuItem,
            this.addChapterToQueueToolStripMenuItem,
            this.addThisStoryToQueueToolStripMenuItem,
            this.addAllChapterUpdatesToQueueToolStripMenuItem,
            this.readThisChapterToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(245, 136);
            // 
            // downloadThisChapterToolStripMenuItem
            // 
            this.downloadThisChapterToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364671000_10;
            this.downloadThisChapterToolStripMenuItem.Name = "downloadThisChapterToolStripMenuItem";
            this.downloadThisChapterToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.downloadThisChapterToolStripMenuItem.Text = "Download this chapter only";
            // 
            // downloadAllChapterToolStripMenuItem
            // 
            this.downloadAllChapterToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364561047_wheel;
            this.downloadAllChapterToolStripMenuItem.Name = "downloadAllChapterToolStripMenuItem";
            this.downloadAllChapterToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.downloadAllChapterToolStripMenuItem.Text = "Download all chapter in select story";
            // 
            // addChapterToQueueToolStripMenuItem
            // 
            this.addChapterToQueueToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364410881_plus_32;
            this.addChapterToQueueToolStripMenuItem.Name = "addChapterToQueueToolStripMenuItem";
            this.addChapterToQueueToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.addChapterToQueueToolStripMenuItem.Text = "Add this chapter to Queue";
            this.addChapterToQueueToolStripMenuItem.Click += new System.EventHandler(this.addChapterToQueueToolStripMenuItem_Click);
            // 
            // addThisStoryToQueueToolStripMenuItem
            // 
            this.addThisStoryToQueueToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364410878_Add;
            this.addThisStoryToQueueToolStripMenuItem.Name = "addThisStoryToQueueToolStripMenuItem";
            this.addThisStoryToQueueToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.addThisStoryToQueueToolStripMenuItem.Text = "Add this story to Queue";
            // 
            // addAllChapterUpdatesToQueueToolStripMenuItem
            // 
            this.addAllChapterUpdatesToQueueToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364647756_sheduled_task;
            this.addAllChapterUpdatesToQueueToolStripMenuItem.Name = "addAllChapterUpdatesToQueueToolStripMenuItem";
            this.addAllChapterUpdatesToQueueToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.addAllChapterUpdatesToQueueToolStripMenuItem.Text = "Add all chapter updates to Queue";
            // 
            // readThisChapterToolStripMenuItem
            // 
            this.readThisChapterToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364392872_slideshow;
            this.readThisChapterToolStripMenuItem.Name = "readThisChapterToolStripMenuItem";
            this.readThisChapterToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.readThisChapterToolStripMenuItem.Text = "Read this chapter";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lvLastestUpdates, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.47369F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.52632F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(741, 266);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 244);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(741, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
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
            // LastestChapterUpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 266);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LastestChapterUpdateForm";
            this.Text = "Lastest Updates";
            this.Load += new System.EventHandler(this.LastestChapterUpdateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvLastestUpdates)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.DataListView lvLastestUpdates;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem downloadThisChapterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadAllChapterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addChapterToQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addThisStoryToQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAllChapterUpdatesToQueueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readThisChapterToolStripMenuItem;
        private BrightIdeasSoftware.HyperlinkStyle hyperlinkStyle1;
    }
}