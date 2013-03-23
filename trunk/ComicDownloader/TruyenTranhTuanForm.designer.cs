using System.Drawing;
namespace ComicDownloader
{
    partial class TruyenTranhTuanForm
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
            this.txtUrl = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPages = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.MaskedTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPageCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.progess = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalDownloadCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.bntDownload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExitThread = new System.Windows.Forms.Button();
            this.bntInfo = new System.Windows.Forms.Button();
            this.ddlList = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bntStop = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listHistory = new ComicDownloader.EXListView();
            this.index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProgress = ((ComicDownloader.EXColumnHeader)(new ComicDownloader.EXColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((ComicDownloader.EXColumnHeader)(new ComicDownloader.EXColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(14, 65);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(221, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "http://truyentranhtuan.com/one-piece";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CHAPTER(1,2 or 1-10..)";
            // 
            // txtPages
            // 
            this.txtPages.Location = new System.Drawing.Point(14, 110);
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(221, 20);
            this.txtPages.TabIndex = 2;
            this.txtPages.Text = "1-100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TITLE";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(14, 150);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(221, 20);
            this.txtTitle.TabIndex = 4;
            this.txtTitle.Text = "DAO HAI TAC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "DIRECTORY";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(14, 188);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(191, 20);
            this.txtDir.TabIndex = 6;
            this.txtDir.Text = "C:\\Users\\Administrator\\Desktop\\teset";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 188);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.toolStripStatusLabel1,
            this.lblPageCount,
            this.progess,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel2,
            this.lblTotalDownloadCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(949, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 17);
            this.lblStatus.Text = "Pedding";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // lblPageCount
            // 
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(0, 17);
            // 
            // progess
            // 
            this.progess.Name = "progess";
            this.progess.Size = new System.Drawing.Size(400, 16);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(16, 20);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(31, 17);
            this.toolStripStatusLabel2.Text = "Total";
            // 
            // lblTotalDownloadCount
            // 
            this.lblTotalDownloadCount.Name = "lblTotalDownloadCount";
            this.lblTotalDownloadCount.Size = new System.Drawing.Size(0, 17);
            // 
            // bntDownload
            // 
            this.bntDownload.Location = new System.Drawing.Point(161, 236);
            this.bntDownload.Name = "bntDownload";
            this.bntDownload.Size = new System.Drawing.Size(75, 23);
            this.bntDownload.TabIndex = 11;
            this.bntDownload.Text = "Download";
            this.bntDownload.UseVisualStyleBackColor = true;
            this.bntDownload.Click += new System.EventHandler(this.bntDownload_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExitThread);
            this.panel1.Controls.Add(this.bntInfo);
            this.panel1.Controls.Add(this.ddlList);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.bntStop);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.txtPages);
            this.panel1.Controls.Add(this.bntDownload);
            this.panel1.Controls.Add(this.txtUrl);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 379);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnExitThread
            // 
            this.btnExitThread.Location = new System.Drawing.Point(16, 236);
            this.btnExitThread.Name = "btnExitThread";
            this.btnExitThread.Size = new System.Drawing.Size(75, 23);
            this.btnExitThread.TabIndex = 17;
            this.btnExitThread.Text = "Stop";
            this.btnExitThread.UseVisualStyleBackColor = true;
            this.btnExitThread.Click += new System.EventHandler(this.btnExitThread_Click);
            // 
            // bntInfo
            // 
            this.bntInfo.Enabled = false;
            this.bntInfo.Image = global::ComicDownloader.Properties.Resources.gtk_about;
            this.bntInfo.Location = new System.Drawing.Point(242, 22);
            this.bntInfo.Name = "bntInfo";
            this.bntInfo.Size = new System.Drawing.Size(30, 23);
            this.bntInfo.TabIndex = 16;
            this.bntInfo.UseVisualStyleBackColor = true;
            this.bntInfo.Click += new System.EventHandler(this.bntInfo_Click);
            // 
            // ddlList
            // 
            this.ddlList.FormattingEnabled = true;
            this.ddlList.Location = new System.Drawing.Point(16, 25);
            this.ddlList.Name = "ddlList";
            this.ddlList.Size = new System.Drawing.Size(219, 21);
            this.ddlList.TabIndex = 15;
            this.ddlList.SelectedIndexChanged += new System.EventHandler(this.ddlList_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Select a story from list";
            // 
            // bntStop
            // 
            this.bntStop.Enabled = false;
            this.bntStop.Location = new System.Drawing.Point(80, 236);
            this.bntStop.Name = "bntStop";
            this.bntStop.Size = new System.Drawing.Size(75, 23);
            this.bntStop.TabIndex = 13;
            this.bntStop.Text = "Pause";
            this.bntStop.UseVisualStyleBackColor = true;
            this.bntStop.Click += new System.EventHandler(this.bntStop_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(13, 283);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(227, 13);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://truyentranhtuan.com/danh-sach-truyen/";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listHistory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(278, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 379);
            this.panel2.TabIndex = 13;
            // 
            // listHistory
            // 
            this.listHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.index,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeaderProgress,
            this.columnHeader4,
            this.columnHeader5});
            this.listHistory.ControlPadding = 4;
            this.listHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listHistory.FullRowSelect = true;
            this.listHistory.GridLines = true;
            this.listHistory.Location = new System.Drawing.Point(0, 0);
            this.listHistory.Name = "listHistory";
            this.listHistory.OwnerDraw = true;
            this.listHistory.Size = new System.Drawing.Size(671, 379);
            this.listHistory.TabIndex = 9;
            this.listHistory.UseCompatibleStateImageBehavior = false;
            this.listHistory.View = System.Windows.Forms.View.Details;
            // 
            // index
            // 
            this.index.Text = "Index";
            this.index.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.index.Width = 51;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Chapter";
            this.columnHeader1.Width = 115;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Pages";
            this.columnHeader2.Width = 66;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.Width = 102;
            // 
            // columnHeaderProgress
            // 
            this.columnHeaderProgress.Text = "Progress";
            this.columnHeaderProgress.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Folder";
            this.columnHeader4.Width = 72;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "PDF";
            // 
            // TruyenTranhTuanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 401);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "TruyenTranhTuanForm";
            this.Text = "Truyen Tranh Tuan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtPages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button button1;
        private EXListView listHistory;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar progess;
        private System.Windows.Forms.Button bntDownload;
        private EXColumnHeader columnHeaderProgress;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private EXColumnHeader columnHeader5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblPageCount;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalDownloadCount;
        private System.Windows.Forms.ColumnHeader index;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button bntStop;
        private System.Windows.Forms.ComboBox ddlList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bntInfo;
        private System.Windows.Forms.Button btnExitThread;
        
    }
}

