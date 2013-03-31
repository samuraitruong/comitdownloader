namespace ComicDownloader
{
    partial class AppMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppMainForm));
            this.mdiTabStrip1 = new Cx.Windows.Forms.MdiTabStrip();
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonOrbMenuItem1 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.mnuOptions = new System.Windows.Forms.RibbonOrbMenuItem();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.rbtHome = new System.Windows.Forms.RibbonTab();
            this.pnlDownload = new System.Windows.Forms.RibbonPanel();
            this.cobDownloaders = new System.Windows.Forms.RibbonComboBox();
            this.bntMyTest = new System.Windows.Forms.RibbonButton();
            this.rbtDownloadQueue = new System.Windows.Forms.RibbonPanel();
            this.bntQueueDownload = new System.Windows.Forms.RibbonButton();
            this.bntStartQueue = new System.Windows.Forms.RibbonButton();
            this.bntStopQueue = new System.Windows.Forms.RibbonButton();
            this.bntClearQueue = new System.Windows.Forms.RibbonButton();
            this.bntResumeError = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel13 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.SuspendLayout();
            // 
            // mdiTabStrip1
            // 
            this.mdiTabStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mdiTabStrip1.Location = new System.Drawing.Point(0, 110);
            this.mdiTabStrip1.Name = "mdiTabStrip1";
            this.mdiTabStrip1.SelectedTab = null;
            this.mdiTabStrip1.ShowItemToolTips = false;
            this.mdiTabStrip1.Size = new System.Drawing.Size(731, 25);
            this.mdiTabStrip1.TabIndex = 3;
            this.mdiTabStrip1.Text = "mdiTabStrip1";
            this.mdiTabStrip1.TabIndexChanged += new System.EventHandler(this.mdiTabStrip1_TabIndexChanged);
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.ribbonOrbMenuItem1);
            this.ribbon1.OrbDropDown.MenuItems.Add(this.mnuOptions);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 160);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            // 
            // 
            // 
            this.ribbon1.QuickAcessToolbar.Items.Add(this.ribbonButton1);
            this.ribbon1.QuickAcessToolbar.Items.Add(this.ribbonButton2);
            this.ribbon1.Size = new System.Drawing.Size(731, 110);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Tabs.Add(this.rbtHome);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonOrbMenuItem1
            // 
            this.ribbonOrbMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonOrbMenuItem1.Image = global::ComicDownloader.Properties.Resources._1364561270_exit;
            this.ribbonOrbMenuItem1.MaximumSize = new System.Drawing.Size(0, 0);
            this.ribbonOrbMenuItem1.MinimumSize = new System.Drawing.Size(0, 0);
            this.ribbonOrbMenuItem1.SmallImage = global::ComicDownloader.Properties.Resources._1364561270_exit;
            this.ribbonOrbMenuItem1.Text = "Exit";
            this.ribbonOrbMenuItem1.Click += new System.EventHandler(this.ribbonOrbMenuItem1_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.mnuOptions.Image = global::ComicDownloader.Properties.Resources._1364561047_wheel;
            this.mnuOptions.MaximumSize = new System.Drawing.Size(0, 0);
            this.mnuOptions.MinimumSize = new System.Drawing.Size(0, 0);
            this.mnuOptions.SmallImage = global::ComicDownloader.Properties.Resources._1364561047_wheel;
            this.mnuOptions.Text = "Options";
            this.mnuOptions.ToolTipImage = global::ComicDownloader.Properties.Resources._1364561047_wheel;
            this.mnuOptions.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Image = global::ComicDownloader.Properties.Resources._1364155386_gtk_refresh;
            this.ribbonButton1.MaximumSize = new System.Drawing.Size(0, 0);
            this.ribbonButton1.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton1.MinimumSize = new System.Drawing.Size(0, 0);
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "ribbonButton1";
            this.ribbonButton1.Click += new System.EventHandler(this.ribbonButton1_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.MaximumSize = new System.Drawing.Size(0, 0);
            this.ribbonButton2.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Compact;
            this.ribbonButton2.MinimumSize = new System.Drawing.Size(0, 0);
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // rbtHome
            // 
            this.rbtHome.Panels.Add(this.pnlDownload);
            this.rbtHome.Panels.Add(this.rbtDownloadQueue);
            this.rbtHome.Text = "Home";
            // 
            // pnlDownload
            // 
            this.pnlDownload.Items.Add(this.cobDownloaders);
            this.pnlDownload.Text = null;
            // 
            // cobDownloaders
            // 
            this.cobDownloaders.DropDownItems.Add(this.bntMyTest);
            this.cobDownloaders.Text = "Select a host provider";
            this.cobDownloaders.TextBoxText = "";
            this.cobDownloaders.TextBoxWidth = 150;
            // 
            // bntMyTest
            // 
            this.bntMyTest.Image = ((System.Drawing.Image)(resources.GetObject("bntMyTest.Image")));
            this.bntMyTest.MaximumSize = new System.Drawing.Size(0, 0);
            this.bntMyTest.MinimumSize = new System.Drawing.Size(0, 0);
            this.bntMyTest.SmallImage = ((System.Drawing.Image)(resources.GetObject("bntMyTest.SmallImage")));
            this.bntMyTest.Text = "[[MangaReader]]";
            // 
            // rbtDownloadQueue
            // 
            this.rbtDownloadQueue.Items.Add(this.bntQueueDownload);
            this.rbtDownloadQueue.Items.Add(this.bntStartQueue);
            this.rbtDownloadQueue.Items.Add(this.bntStopQueue);
            this.rbtDownloadQueue.Items.Add(this.bntClearQueue);
            this.rbtDownloadQueue.Items.Add(this.bntResumeError);
            this.rbtDownloadQueue.Text = "Download Queue";
            // 
            // bntQueueDownload
            // 
            this.bntQueueDownload.Image = global::ComicDownloader.Properties.Resources._1364647756_sheduled_task;
            this.bntQueueDownload.MaximumSize = new System.Drawing.Size(0, 0);
            this.bntQueueDownload.MinimumSize = new System.Drawing.Size(0, 0);
            this.bntQueueDownload.SmallImage = ((System.Drawing.Image)(resources.GetObject("bntQueueDownload.SmallImage")));
            this.bntQueueDownload.Click += new System.EventHandler(this.bntQueueDownload_Click);
            // 
            // bntStartQueue
            // 
            this.bntStartQueue.Image = global::ComicDownloader.Properties.Resources.media_playback_start__1_;
            this.bntStartQueue.MaximumSize = new System.Drawing.Size(0, 0);
            this.bntStartQueue.MinimumSize = new System.Drawing.Size(0, 0);
            this.bntStartQueue.SmallImage = ((System.Drawing.Image)(resources.GetObject("bntStartQueue.SmallImage")));
            this.bntStartQueue.Click += new System.EventHandler(this.bntStartQueue_Click);
            // 
            // bntStopQueue
            // 
            this.bntStopQueue.Image = global::ComicDownloader.Properties.Resources.media_playback_stop;
            this.bntStopQueue.MaximumSize = new System.Drawing.Size(0, 0);
            this.bntStopQueue.MinimumSize = new System.Drawing.Size(0, 0);
            this.bntStopQueue.SmallImage = ((System.Drawing.Image)(resources.GetObject("bntStopQueue.SmallImage")));
            // 
            // bntClearQueue
            // 
            this.bntClearQueue.Image = global::ComicDownloader.Properties.Resources._1364710944_clear_left;
            this.bntClearQueue.MaximumSize = new System.Drawing.Size(0, 0);
            this.bntClearQueue.MinimumSize = new System.Drawing.Size(0, 0);
            this.bntClearQueue.SmallImage = ((System.Drawing.Image)(resources.GetObject("bntClearQueue.SmallImage")));
            this.bntClearQueue.Click += new System.EventHandler(this.bntClearQueue_Click);
            // 
            // bntResumeError
            // 
            this.bntResumeError.Image = global::ComicDownloader.Properties.Resources._1364712905_download;
            this.bntResumeError.MaximumSize = new System.Drawing.Size(0, 0);
            this.bntResumeError.MinimumSize = new System.Drawing.Size(0, 0);
            this.bntResumeError.SmallImage = ((System.Drawing.Image)(resources.GetObject("bntResumeError.SmallImage")));
            this.bntResumeError.Click += new System.EventHandler(this.bntResumeError_Click);
            // 
            // ribbonPanel13
            // 
            this.ribbonPanel13.Text = "XomTruyen.com";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Text = "XomTruyen.com";
            // 
            // AppMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 273);
            this.Controls.Add(this.mdiTabStrip1);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "AppMainForm";
            this.Text = "Manga & Comic DL";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AppMainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private Cx.Windows.Forms.MdiTabStrip mdiTabStrip1;
        private System.Windows.Forms.RibbonOrbMenuItem ribbonOrbMenuItem1;
        private System.Windows.Forms.RibbonPanel ribbonPanel13;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonTab rbtHome;
        private System.Windows.Forms.RibbonPanel pnlDownload;
        private System.Windows.Forms.RibbonComboBox cobDownloaders;
        private System.Windows.Forms.RibbonButton bntMyTest;
        private System.Windows.Forms.RibbonOrbMenuItem mnuOptions;
        
        private System.Windows.Forms.RibbonPanel rbtDownloadQueue;
        private System.Windows.Forms.RibbonButton bntQueueDownload;
        private System.Windows.Forms.RibbonButton bntStartQueue;
        private System.Windows.Forms.RibbonButton bntStopQueue;
        private System.Windows.Forms.RibbonButton bntClearQueue;
        private System.Windows.Forms.RibbonButton bntResumeError;
        
    }
}