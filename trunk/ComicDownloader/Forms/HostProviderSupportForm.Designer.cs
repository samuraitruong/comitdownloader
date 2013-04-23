namespace ComicDownloader
{
    partial class HostProviderSupportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostProviderSupportForm));
            this.dataListView1 = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn4 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn5 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.batchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allProvidersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectedProviderHaventCachedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.hyperlinkStyle1 = new BrightIdeasSoftware.HyperlinkStyle();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataListView1
            // 
            this.dataListView1.AlternateRowBackColor = System.Drawing.Color.Gray;
            this.dataListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn3,
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn4,
            this.olvColumn5});
            this.dataListView1.ContextMenuStrip = this.contextMenuStrip1;
            
            this.dataListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataListView1.FullRowSelect = true;
            this.dataListView1.GridLines = true;
            this.dataListView1.GroupWithItemCountFormat = "{0} ({1} providers)";
            this.dataListView1.GroupWithItemCountSingularFormat = "{0} ({1} provider)";
            this.dataListView1.Location = new System.Drawing.Point(0, 0);
            this.dataListView1.Name = "dataListView1";
            this.dataListView1.ShowItemCountOnGroups = true;
            this.dataListView1.Size = new System.Drawing.Size(520, 273);
            this.dataListView1.TabIndex = 1;
            this.dataListView1.UseCompatibleStateImageBehavior = false;
            this.dataListView1.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Language";
            this.olvColumn3.CellPadding = null;
            this.olvColumn3.Text = "Language";
            this.olvColumn3.Width = 120;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Text = "Name";
            this.olvColumn1.Width = 120;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "HostUrl";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.Hyperlink = true;
            this.olvColumn2.Text = "Url";
            this.olvColumn2.Width = 200;
            // 
            // olvColumn4
            // 
            this.olvColumn4.AspectName = "Stories";
            this.olvColumn4.CellPadding = null;
            this.olvColumn4.Text = "Stories";
            this.olvColumn4.Width = 100;
            // 
            // olvColumn5
            // 
            this.olvColumn5.AspectName = "Status";
            this.olvColumn5.CellPadding = null;
            this.olvColumn5.Hyperlink = true;
            this.olvColumn5.Text = "Status";
            this.olvColumn5.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batchToolStripMenuItem,
            this.openToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 70);
            // 
            // batchToolStripMenuItem
            // 
            this.batchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allProvidersToolStripMenuItem,
            this.SelectedProviderHaventCachedToolStripMenuItem});
            this.batchToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1365535653_Process_Accept;
            this.batchToolStripMenuItem.Name = "batchToolStripMenuItem";
            this.batchToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.batchToolStripMenuItem.Text = "Batch";
            // 
            // allProvidersToolStripMenuItem
            // 
            this.allProvidersToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1365535542_reload;
            this.allProvidersToolStripMenuItem.Name = "allProvidersToolStripMenuItem";
            this.allProvidersToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.allProvidersToolStripMenuItem.Text = "All Providers";
            this.allProvidersToolStripMenuItem.Click += new System.EventHandler(this.allProvidersToolStripMenuItem_Click);
            // 
            // SelectedProviderHaventCachedToolStripMenuItem
            // 
            this.SelectedProviderHaventCachedToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1365535741_select_by_adding_to_selection;
            this.SelectedProviderHaventCachedToolStripMenuItem.Name = "SelectedProviderHaventCachedToolStripMenuItem";
            this.SelectedProviderHaventCachedToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.SelectedProviderHaventCachedToolStripMenuItem.Text = "Selection";
            this.SelectedProviderHaventCachedToolStripMenuItem.Click += new System.EventHandler(this.SelectedProviderMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 251);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(520, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(500, 16);
            this.progressBar.Paint += new System.Windows.Forms.PaintEventHandler(this.progressBar_Paint);
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
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1365319718_Globe1;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // HostProviderSupportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 273);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataListView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HostProviderSupportForm";
            this.Text = "We currently support list providers below";
            this.Load += new System.EventHandler(this.HostProviderSupportForm_Load);
            this.Resize += new System.EventHandler(this.HostProviderSupportForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataListView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView dataListView1;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn4;
        private BrightIdeasSoftware.OLVColumn olvColumn5;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private BrightIdeasSoftware.HyperlinkStyle hyperlinkStyle1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem batchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allProvidersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectedProviderHaventCachedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}