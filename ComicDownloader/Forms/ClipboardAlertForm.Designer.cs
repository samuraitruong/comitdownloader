using MetroFramework.Controls;

namespace ComicDownloader.Forms
{
    partial class ClipboardAlertForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClipboardAlertForm));
            this.label2 = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lnkMangaUrl = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.btnAbort = new MetroFramework.Controls.MetroButton();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.tabControlChapters = new MetroFramework.Controls.MetroTabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.lblCat = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblAltName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageChapters = new System.Windows.Forms.TabPage();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.lstChapters = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.htmlSummary = new MetroFramework.Drawing.Html.HtmlPanel();
            this.chkClipboardEnable = new MetroFramework.Controls.MetroCheckBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tabControlChapters.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.tabPageChapters.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstChapters)).BeginInit();
            this.tabPageSummary.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Author";
            // 
            // lblAuthor
            // 
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Location = new System.Drawing.Point(70, 12);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(35, 13);
            this.lblAuthor.TabIndex = 3;
            this.lblAuthor.Text = "Name";
            // 
            // lnkMangaUrl
            // 
            this.lnkMangaUrl.AutoSize = true;
            this.lnkMangaUrl.Location = new System.Drawing.Point(77, 161);
            this.lnkMangaUrl.Name = "lnkMangaUrl";
            this.lnkMangaUrl.Size = new System.Drawing.Size(38, 13);
            this.lnkMangaUrl.TabIndex = 16;
            this.lnkMangaUrl.TabStop = true;
            this.lnkMangaUrl.Text = "http://";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "URL";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(324, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(104, 379);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(117, 41);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "Download";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(281, 379);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(119, 41);
            this.btnAbort.TabIndex = 13;
            this.btnAbort.Text = "Ignore";
            this.btnAbort.Click += new System.EventHandler(this.button2_Click);
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = null;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // tabControlChapters
            // 
            this.tabControlChapters.Controls.Add(this.tabInfo);
            this.tabControlChapters.Controls.Add(this.tabPageChapters);
            this.tabControlChapters.Controls.Add(this.tabPageSummary);
            this.tabControlChapters.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlChapters.Location = new System.Drawing.Point(20, 60);
            this.tabControlChapters.Name = "tabControlChapters";
            this.tabControlChapters.SelectedIndex = 0;
            this.tabControlChapters.Size = new System.Drawing.Size(550, 281);
            this.tabControlChapters.TabIndex = 14;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.metroPanel1);
            this.tabInfo.Location = new System.Drawing.Point(4, 35);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Size = new System.Drawing.Size(542, 242);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Manga Info";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.lblCat);
            this.metroPanel1.Controls.Add(this.label6);
            this.metroPanel1.Controls.Add(this.lblAltName);
            this.metroPanel1.Controls.Add(this.label3);
            this.metroPanel1.Controls.Add(this.lnkMangaUrl);
            this.metroPanel1.Controls.Add(this.label4);
            this.metroPanel1.Controls.Add(this.pictureBox1);
            this.metroPanel1.Controls.Add(this.label2);
            this.metroPanel1.Controls.Add(this.lblAuthor);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(542, 242);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Location = new System.Drawing.Point(70, 82);
            this.lblCat.MaximumSize = new System.Drawing.Size(200, 0);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(40, 13);
            this.lblCat.TabIndex = 21;
            this.lblCat.Text = "[[CAT]]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Categories";
            // 
            // lblAltName
            // 
            this.lblAltName.AutoSize = true;
            this.lblAltName.Location = new System.Drawing.Point(70, 34);
            this.lblAltName.MaximumSize = new System.Drawing.Size(200, 0);
            this.lblAltName.Name = "lblAltName";
            this.lblAltName.Size = new System.Drawing.Size(35, 13);
            this.lblAltName.TabIndex = 19;
            this.lblAltName.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Alt Name";
            // 
            // tabPageChapters
            // 
            this.tabPageChapters.Controls.Add(this.metroPanel3);
            this.tabPageChapters.Location = new System.Drawing.Point(4, 35);
            this.tabPageChapters.Name = "tabPageChapters";
            this.tabPageChapters.Size = new System.Drawing.Size(542, 242);
            this.tabPageChapters.TabIndex = 2;
            this.tabPageChapters.Text = "Chapters";
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.lstChapters);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(0, 0);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(542, 242);
            this.metroPanel3.TabIndex = 15;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // lstChapters
            // 
            this.lstChapters.AllColumns.Add(this.olvColumn1);
            this.lstChapters.AllColumns.Add(this.olvColumn2);
            this.lstChapters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2});
            this.lstChapters.FullRowSelect = true;
            this.lstChapters.GridLines = true;
            this.lstChapters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstChapters.Location = new System.Drawing.Point(7, 8);
            this.lstChapters.Name = "lstChapters";
            this.lstChapters.Size = new System.Drawing.Size(521, 267);
            this.lstChapters.TabIndex = 2;
            this.lstChapters.UseCompatibleStateImageBehavior = false;
            this.lstChapters.View = System.Windows.Forms.View.Details;
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "ChapId";
            this.olvColumn1.CellPadding = null;
            this.olvColumn1.Searchable = false;
            this.olvColumn1.Sortable = false;
            this.olvColumn1.Text = "ID";
            this.olvColumn1.UseFiltering = false;
            this.olvColumn1.Width = 30;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Name";
            this.olvColumn2.CellPadding = null;
            this.olvColumn2.Groupable = false;
            this.olvColumn2.Text = "Name";
            this.olvColumn2.Width = 200;
            this.olvColumn2.WordWrap = true;
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.Controls.Add(this.metroPanel2);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 35);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Size = new System.Drawing.Size(542, 242);
            this.tabPageSummary.TabIndex = 1;
            this.tabPageSummary.Text = "Summary";
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.htmlSummary);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(542, 242);
            this.metroPanel2.TabIndex = 15;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // htmlSummary
            // 
            this.htmlSummary.AutoScroll = true;
            this.htmlSummary.AutoScrollMinSize = new System.Drawing.Size(536, 0);
            this.htmlSummary.BackColor = System.Drawing.SystemColors.Window;
            this.htmlSummary.Location = new System.Drawing.Point(3, 3);
            this.htmlSummary.Name = "htmlSummary";
            this.htmlSummary.Size = new System.Drawing.Size(536, 272);
            this.htmlSummary.TabIndex = 12;
            // 
            // chkClipboardEnable
            // 
            this.chkClipboardEnable.AutoSize = true;
            this.chkClipboardEnable.Location = new System.Drawing.Point(24, 349);
            this.chkClipboardEnable.Name = "chkClipboardEnable";
            this.chkClipboardEnable.Size = new System.Drawing.Size(239, 15);
            this.chkClipboardEnable.TabIndex = 17;
            this.chkClipboardEnable.Text = "Do not  monitoring clipboard for this site";
            this.chkClipboardEnable.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Clipboard detect";
            this.notifyIcon1.BalloonTipTitle = "Comic Downloader";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Comic Downloader";
            this.notifyIcon1.Visible = true;
            // 
            // ClipboardAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 432);
            this.ControlBox = false;
            this.Controls.Add(this.tabControlChapters);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkClipboardEnable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClipboardAlertForm";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Manga Title";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tabControlChapters.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.tabPageChapters.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstChapters)).EndInit();
            this.tabPageSummary.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAuthor;
        private MetroButton btnOK;
        private MetroButton btnAbort;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkMangaUrl;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroTabControl tabControlChapters;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.TabPage tabPageChapters;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private BrightIdeasSoftware.ObjectListView lstChapters;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private MetroCheckBox chkClipboardEnable;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblAltName;
        private System.Windows.Forms.Label label3;
        private MetroFramework.Drawing.Html.HtmlPanel htmlSummary;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
    }
}