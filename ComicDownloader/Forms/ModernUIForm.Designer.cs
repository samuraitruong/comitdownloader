using System.Reflection;
using System.Windows.Forms.VisualStyles;
namespace ComicDownloader.Forms
{
    partial class ModernUIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModernUIForm));
            this.textColumn1 = new XPTable.Models.TextColumn();
            this.textColumn2 = new XPTable.Models.TextColumn();
            this.textColumn3 = new XPTable.Models.TextColumn();
            this.lnkAbout = new MetroFramework.Controls.MetroLink();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.tlQueueDownload = new MetroFramework.Controls.MetroTile();
            this.tlSettings = new MetroFramework.Controls.MetroTile();
            this.tlLastestUpdate = new MetroFramework.Controls.MetroTile();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.bntSearch = new MetroFramework.Controls.MetroButton();
            this.txtKeyword = new MetroFramework.Controls.MetroTextBox();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.tlNewDownload = new MetroFramework.Controls.MetroTile();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroTile6 = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.updateProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.lblStatus = new MetroFramework.Controls.MetroLabel();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnkAbout
            // 
            this.lnkAbout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lnkAbout.Location = new System.Drawing.Point(20, 557);
            this.lnkAbout.Name = "lnkAbout";
            this.lnkAbout.Size = new System.Drawing.Size(760, 23);
            this.lnkAbout.TabIndex = 2;
            this.lnkAbout.Text = "Comic Downloader V1";
            this.lnkAbout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // tlQueueDownload
            // 
            this.tlQueueDownload.ActiveControl = null;
            this.tlQueueDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tlQueueDownload.Location = new System.Drawing.Point(599, 14);
            this.tlQueueDownload.Name = "tlQueueDownload";
            this.tlQueueDownload.Size = new System.Drawing.Size(150, 150);
            this.tlQueueDownload.Style = MetroFramework.MetroColorStyle.Green;
            this.tlQueueDownload.TabIndex = 7;
            this.tlQueueDownload.Text = "Task Scheduler";
            this.tlQueueDownload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tlQueueDownload.TileImage = global::ComicDownloader.Properties.Resources._1365926714_Document_scheduled_tasks_icon;
            this.tlQueueDownload.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tlQueueDownload.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tlQueueDownload.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroToolTip1.SetToolTip(this.tlQueueDownload, "View Download schedule");
            this.tlQueueDownload.UseTileImage = true;
            this.tlQueueDownload.Click += new System.EventHandler(this.QueueDownload_Click);
            // 
            // tlSettings
            // 
            this.tlSettings.ActiveControl = null;
            this.tlSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tlSettings.Location = new System.Drawing.Point(411, 14);
            this.tlSettings.Name = "tlSettings";
            this.tlSettings.Size = new System.Drawing.Size(150, 150);
            this.tlSettings.Style = MetroFramework.MetroColorStyle.Lime;
            this.tlSettings.TabIndex = 9;
            this.tlSettings.Text = "Option";
            this.tlSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tlSettings.TileImage = global::ComicDownloader.Properties.Resources._1365927134_cog_icon_2_48x48;
            this.tlSettings.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tlSettings.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tlSettings.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroToolTip1.SetToolTip(this.tlSettings, "Change Download settings");
            this.tlSettings.UseTileImage = true;
            this.tlSettings.Click += new System.EventHandler(this.tlSetting_Click);
            // 
            // tlLastestUpdate
            // 
            this.tlLastestUpdate.ActiveControl = null;
            this.tlLastestUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tlLastestUpdate.Location = new System.Drawing.Point(20, 187);
            this.tlLastestUpdate.Name = "tlLastestUpdate";
            this.tlLastestUpdate.Size = new System.Drawing.Size(150, 150);
            this.tlLastestUpdate.Style = MetroFramework.MetroColorStyle.Magenta;
            this.tlLastestUpdate.TabIndex = 10;
            this.tlLastestUpdate.Text = "Update";
            this.tlLastestUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tlLastestUpdate.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tlLastestUpdate.TileImage = global::ComicDownloader.Properties.Resources._1365927859_system_software_update;
            this.tlLastestUpdate.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tlLastestUpdate.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tlLastestUpdate.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroToolTip1.SetToolTip(this.tlLastestUpdate, "View lastest update from providers");
            this.tlLastestUpdate.UseTileImage = true;
            this.tlLastestUpdate.Click += new System.EventHandler(this.tlLastestUpdate_Click);
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.Color.White;
            this.metroTabPage1.Controls.Add(this.bntSearch);
            this.metroTabPage1.Controls.Add(this.txtKeyword);
            this.metroTabPage1.Controls.Add(this.metroTile2);
            this.metroTabPage1.Controls.Add(this.tlLastestUpdate);
            this.metroTabPage1.Controls.Add(this.tlNewDownload);
            this.metroTabPage1.Controls.Add(this.metroButton1);
            this.metroTabPage1.Controls.Add(this.metroTile6);
            this.metroTabPage1.Controls.Add(this.metroTile1);
            this.metroTabPage1.Controls.Add(this.updateProgressBar);
            this.metroTabPage1.Controls.Add(this.lblStatus);
            this.metroTabPage1.Controls.Add(this.tlSettings);
            this.metroTabPage1.Controls.Add(this.metroTile3);
            this.metroTabPage1.Controls.Add(this.tlQueueDownload);
            this.metroTabPage1.CustomBackground = true;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(752, 458);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Home";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // bntSearch
            // 
            this.bntSearch.Location = new System.Drawing.Point(619, 406);
            this.bntSearch.Name = "bntSearch";
            this.bntSearch.Size = new System.Drawing.Size(130, 38);
            this.bntSearch.Style = MetroFramework.MetroColorStyle.Purple;
            this.bntSearch.TabIndex = 13;
            this.bntSearch.Text = "Search";
            this.bntSearch.Theme = MetroFramework.MetroThemeStyle.Light;
            this.bntSearch.Click += new System.EventHandler(this.bntSearch_Click);
            // 
            // txtKeyword
            // 
            this.txtKeyword.Location = new System.Drawing.Point(20, 421);
            this.txtKeyword.MaxLength = 32767;
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.PasswordChar = '\0';
            this.txtKeyword.PromptText = "Enter manga title";
            this.txtKeyword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtKeyword.SelectedText = "";
            this.txtKeyword.Size = new System.Drawing.Size(578, 23);
            this.txtKeyword.TabIndex = 12;
            this.txtKeyword.Text = "Dragon Ball";
            this.txtKeyword.TextChanged += new System.EventHandler(this.txtKeyword_TextChanged);
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(411, 187);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(211, 150);
            this.metroTile2.TabIndex = 15;
            this.metroTile2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.metroTile2.TileImage = global::ComicDownloader.Properties.Resources._1366530835_paypal_curved;
            this.metroTile2.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile2.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile2.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile2.UseTileImage = true;
            this.metroTile2.Click += new System.EventHandler(this.metroTile2_Click);
            // 
            // tlNewDownload
            // 
            this.tlNewDownload.ActiveControl = null;
            this.tlNewDownload.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.tlNewDownload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tlNewDownload.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tlNewDownload.Location = new System.Drawing.Point(20, 14);
            this.tlNewDownload.Name = "tlNewDownload";
            this.tlNewDownload.Size = new System.Drawing.Size(150, 150);
            this.tlNewDownload.Style = MetroFramework.MetroColorStyle.Orange;
            this.tlNewDownload.TabIndex = 3;
            this.tlNewDownload.Text = "New Download";
            this.tlNewDownload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tlNewDownload.TileImage = global::ComicDownloader.Properties.Resources._1365926784_download;
            this.tlNewDownload.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tlNewDownload.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.tlNewDownload.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.tlNewDownload.UseTileImage = true;
            this.tlNewDownload.Click += new System.EventHandler(this.metroTile1_Click);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(619, 357);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(130, 38);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Magenta;
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Text = "Update Database";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroTile6
            // 
            this.metroTile6.ActiveControl = null;
            this.metroTile6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile6.Location = new System.Drawing.Point(211, 187);
            this.metroTile6.Name = "metroTile6";
            this.metroTile6.Size = new System.Drawing.Size(150, 150);
            this.metroTile6.Style = MetroFramework.MetroColorStyle.Red;
            this.metroTile6.TabIndex = 11;
            this.metroTile6.Text = "Product Page";
            this.metroTile6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile6.TileImage = global::ComicDownloader.Properties.Resources._1365927946_social_balloon_14;
            this.metroTile6.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTile6.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile6.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile6.UseTileImage = true;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(640, 187);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(150, 84);
            this.metroTile1.TabIndex = 14;
            this.metroTile1.Text = "Check of Update";
            this.metroTile1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.metroTile1.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile1.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Regular;
            this.metroTile1.Visible = false;
            this.metroTile1.Click += new System.EventHandler(this.metroTile1_Click_1);
            // 
            // updateProgressBar
            // 
            this.updateProgressBar.Location = new System.Drawing.Point(20, 357);
            this.updateProgressBar.Name = "updateProgressBar";
            this.updateProgressBar.Size = new System.Drawing.Size(578, 38);
            this.updateProgressBar.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(20, 398);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(118, 19);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Update database...";
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.metroTile3.Location = new System.Drawing.Point(211, 14);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(150, 150);
            this.metroTile3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTile3.TabIndex = 8;
            this.metroTile3.Text = "Search";
            this.metroTile3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.metroTile3.TileImage = global::ComicDownloader.Properties.Resources._1365926986_document_search;
            this.metroTile3.TileImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroTile3.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.metroTile3.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.metroTile3.UseTileImage = true;
            this.metroTile3.Click += new System.EventHandler(this.metroTile3_Click);
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.metroTabPage1);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(760, 497);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.metroTabControl1_Selected);
            this.metroTabControl1.TabIndexChanged += new System.EventHandler(this.metroTabControl1_TabIndexChanged);
            // 
            // ModernUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.metroTabControl1);
            this.Controls.Add(this.lnkAbout);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModernUIForm";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "Comic Downloader 1.1 Build 300116 ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModernUIForm_FormClosing);
            this.Load += new System.EventHandler(this.ModernUIForm_Load);
            this.Resize += new System.EventHandler(this.ModernUIForm_Resize);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroLink lnkAbout;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private XPTable.Models.TextColumn textColumn1;
        private XPTable.Models.TextColumn textColumn2;
        private XPTable.Models.TextColumn textColumn3;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroButton bntSearch;
        private MetroFramework.Controls.MetroTextBox txtKeyword;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile tlLastestUpdate;
        private MetroFramework.Controls.MetroTile tlNewDownload;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTile metroTile6;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroProgressBar updateProgressBar;
        private MetroFramework.Controls.MetroLabel lblStatus;
        private MetroFramework.Controls.MetroTile tlSettings;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroTile tlQueueDownload;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;


        //private MetroFramework.Controls.MetroTile metroTile2;


    }
}