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
            this.label1 = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblMangaName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lnkMangaUrl = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblChapters = new System.Windows.Forms.Label();
            this.lblSumary = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new MetroFramework.Controls.MetroButton();
            this.btnAbort = new MetroFramework.Controls.MetroButton();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.tabPageChapters = new System.Windows.Forms.TabPage();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.objectListView1 = new BrightIdeasSoftware.ObjectListView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabInfo.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.tabPageChapters.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site Url";
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
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Site name";
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
            // lblMangaName
            // 
            this.lblMangaName.AutoSize = true;
            this.lblMangaName.Location = new System.Drawing.Point(90, 66);
            this.lblMangaName.Name = "lblMangaName";
            this.lblMangaName.Size = new System.Drawing.Size(35, 13);
            this.lblMangaName.TabIndex = 5;
            this.lblMangaName.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Manga Name";
            // 
            // lnkMangaUrl
            // 
            this.lnkMangaUrl.AutoSize = true;
            this.lnkMangaUrl.Location = new System.Drawing.Point(91, 92);
            this.lnkMangaUrl.Name = "lnkMangaUrl";
            this.lnkMangaUrl.Size = new System.Drawing.Size(38, 13);
            this.lnkMangaUrl.TabIndex = 16;
            this.lnkMangaUrl.TabStop = true;
            this.lnkMangaUrl.Text = "http://";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Total Chapter";
            // 
            // lblChapters
            // 
            this.lblChapters.AutoSize = true;
            this.lblChapters.Location = new System.Drawing.Point(91, 119);
            this.lblChapters.Name = "lblChapters";
            this.lblChapters.Size = new System.Drawing.Size(19, 13);
            this.lblChapters.TabIndex = 15;
            this.lblChapters.Text = "10";
            // 
            // lblSumary
            // 
            this.lblSumary.AllowDrop = true;
            this.lblSumary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSumary.ForeColor = System.Drawing.Color.Black;
            this.lblSumary.Location = new System.Drawing.Point(12, 11);
            this.lblSumary.Name = "lblSumary";
            this.lblSumary.Size = new System.Drawing.Size(421, 165);
            this.lblSumary.TabIndex = 11;
            this.lblSumary.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Manga Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Location = new System.Drawing.Point(257, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(80, 343);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(117, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "Download";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.Location = new System.Drawing.Point(251, 343);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(119, 23);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInfo);
            this.tabControl.Controls.Add(this.tabPageSummary);
            this.tabControl.Controls.Add(this.tabPageChapters);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(20, 60);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(444, 259);
            this.tabControl.TabIndex = 14;
            // 
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.metroPanel1);
            this.tabInfo.Location = new System.Drawing.Point(4, 35);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Size = new System.Drawing.Size(436, 220);
            this.tabInfo.TabIndex = 0;
            this.tabInfo.Text = "Manga Info";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Controls.Add(this.lnkMangaUrl);
            this.metroPanel1.Controls.Add(this.label7);
            this.metroPanel1.Controls.Add(this.lblChapters);
            this.metroPanel1.Controls.Add(this.label4);
            this.metroPanel1.Controls.Add(this.pictureBox1);
            this.metroPanel1.Controls.Add(this.label5);
            this.metroPanel1.Controls.Add(this.label1);
            this.metroPanel1.Controls.Add(this.lblUrl);
            this.metroPanel1.Controls.Add(this.label2);
            this.metroPanel1.Controls.Add(this.lblName);
            this.metroPanel1.Controls.Add(this.lblMangaName);
            this.metroPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(0, 0);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(436, 220);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.Controls.Add(this.metroPanel2);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 35);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Size = new System.Drawing.Size(436, 220);
            this.tabPageSummary.TabIndex = 1;
            this.tabPageSummary.Text = "Summary";
            // 
            // metroPanel2
            // 
            this.metroPanel2.Controls.Add(this.lblSumary);
            this.metroPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(0, 0);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(436, 220);
            this.metroPanel2.TabIndex = 15;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // tabPageChapters
            // 
            this.tabPageChapters.Controls.Add(this.metroPanel3);
            this.tabPageChapters.Location = new System.Drawing.Point(4, 35);
            this.tabPageChapters.Name = "tabPageChapters";
            this.tabPageChapters.Size = new System.Drawing.Size(436, 220);
            this.tabPageChapters.TabIndex = 2;
            this.tabPageChapters.Text = "Chapters";
            // 
            // metroPanel3
            // 
            this.metroPanel3.Controls.Add(this.objectListView1);
            this.metroPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(0, 0);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(436, 220);
            this.metroPanel3.TabIndex = 15;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // objectListView1
            // 
            this.objectListView1.Location = new System.Drawing.Point(20, 18);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.Size = new System.Drawing.Size(403, 157);
            this.objectListView1.TabIndex = 2;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
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
            this.ClientSize = new System.Drawing.Size(484, 382);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClipboardAlertForm";
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Manga Title";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.tabPageSummary.ResumeLayout(false);
            this.metroPanel2.ResumeLayout(false);
            this.tabPageChapters.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblMangaName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSumary;
        private MetroButton btnOK;
        private MetroButton btnAbort;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkMangaUrl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblChapters;
        private System.Windows.Forms.Label label4;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroTabControl tabControl;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.TabPage tabPageChapters;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private BrightIdeasSoftware.ObjectListView objectListView1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}