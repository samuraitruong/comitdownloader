using System.Drawing;
namespace ComicDownloader
{
    partial class DownloaderForm
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
            this.txtUrl = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDir = new System.Windows.Forms.MaskedTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStoriesCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPageCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.progess = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotalDownloadCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.bntDownload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gpbChapters = new System.Windows.Forms.GroupBox();
            this.lstChapters = new XPTable.Models.Table();
            this.columnModel1 = new XPTable.Models.ColumnModel();
            this.chkSelect = new XPTable.Models.CheckBoxColumn();
            this.txtChapIdentify = new XPTable.Models.TextColumn();
            this.colChapId = new XPTable.Models.NumberColumn();
            this.txtChapName = new XPTable.Models.TextColumn();
            this.txtChapLink = new XPTable.Models.TextColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectInverse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.addOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddandStartQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.tblChapters = new XPTable.Models.TableModel();
            this.groupDownload = new System.Windows.Forms.GroupBox();
            this.btnExitThread = new System.Windows.Forms.Button();
            this.bntPauseThread = new System.Windows.Forms.Button();
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.loading = new MRG.Controls.UI.LoadingCircle();
            this.bntRefresh = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bntInfo = new System.Windows.Forms.Button();
            this.ddlList = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listHistory = new ComicDownloader.EXListView();
            this.index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProgress = ((ComicDownloader.EXColumnHeader)(new ComicDownloader.EXColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPDF = ((ComicDownloader.EXColumnHeader)(new ComicDownloader.EXColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errInvalidFileName = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gpbChapters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstChapters)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.groupDownload.SuspendLayout();
            this.groupInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errInvalidFileName)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(17, 80);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(219, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "[[Select a story from list]]";
            this.txtUrl.TextChanged += new System.EventHandler(this.txtUrl_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TITLE";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(19, 125);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(219, 20);
            this.txtTitle.TabIndex = 4;
            this.txtTitle.Text = "[[Select a story from list]]";
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "DIRECTORY";
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(19, 32);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(223, 20);
            this.txtDir.TabIndex = 6;
            this.txtDir.Text = "C:\\Users\\Administrator\\Desktop\\teset";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 29);
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
            this.lblStoriesCount,
            this.lblStatus,
            this.toolStripStatusLabel1,
            this.lblPageCount,
            this.progess,
            this.toolStripSplitButton1,
            this.toolStripStatusLabel2,
            this.lblTotalDownloadCount,
            this.toolStripStatusLabel3,
            this.lblSelected});
            this.statusStrip1.Location = new System.Drawing.Point(0, 358);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(949, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStoriesCount
            // 
            this.lblStoriesCount.BorderStyle = System.Windows.Forms.Border3DStyle.Adjust;
            this.lblStoriesCount.Name = "lblStoriesCount";
            this.lblStoriesCount.Size = new System.Drawing.Size(0, 17);
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
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.Sunken;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(11, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // lblSelected
            // 
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(0, 17);
            // 
            // bntDownload
            // 
            this.bntDownload.Enabled = false;
            this.bntDownload.Location = new System.Drawing.Point(17, 58);
            this.bntDownload.Name = "bntDownload";
            this.bntDownload.Size = new System.Drawing.Size(70, 23);
            this.bntDownload.TabIndex = 11;
            this.bntDownload.Text = "Download";
            this.bntDownload.UseVisualStyleBackColor = true;
            this.bntDownload.Click += new System.EventHandler(this.bntDownload_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gpbChapters);
            this.panel1.Controls.Add(this.groupDownload);
            this.panel1.Controls.Add(this.groupInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 358);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // gpbChapters
            // 
            this.gpbChapters.Controls.Add(this.lstChapters);
            this.gpbChapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbChapters.Location = new System.Drawing.Point(0, 159);
            this.gpbChapters.Name = "gpbChapters";
            this.gpbChapters.Size = new System.Drawing.Size(278, 105);
            this.gpbChapters.TabIndex = 22;
            this.gpbChapters.TabStop = false;
            this.gpbChapters.Text = "Select chapter(s) to download";
            // 
            // lstChapters
            // 
            this.lstChapters.ColumnModel = this.columnModel1;
            this.lstChapters.ContextMenuStrip = this.contextMenuStrip1;
            this.lstChapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstChapters.FullRowSelect = true;
            this.lstChapters.GridLines = XPTable.Models.GridLines.Columns;
            this.lstChapters.HideSelection = true;
            this.lstChapters.Location = new System.Drawing.Point(3, 16);
            this.lstChapters.MultiSelect = true;
            this.lstChapters.Name = "lstChapters";
            this.lstChapters.Size = new System.Drawing.Size(272, 86);
            this.lstChapters.TabIndex = 0;
            this.lstChapters.TableModel = this.tblChapters;
            this.lstChapters.CellClick += new XPTable.Events.CellMouseEventHandler(this.lstChapters_CellClick);
            this.lstChapters.CellCheckChanged += new XPTable.Events.CellCheckBoxEventHandler(this.lstChapters_CellCheckChanged);
            this.lstChapters.SelectionChanged += new XPTable.Events.SelectionEventHandler(this.lstChapters_SelectionChanged);
            this.lstChapters.ContextMenuStripChanged += new System.EventHandler(this.lstChapters_ContextMenuStripChanged);
            // 
            // columnModel1
            // 
            this.columnModel1.Columns.AddRange(new XPTable.Models.Column[] {
            this.chkSelect,
            this.txtChapIdentify,
            this.colChapId,
            this.txtChapName,
            this.txtChapLink});
            // 
            // chkSelect
            // 
            this.chkSelect.Text = "ID";
            this.chkSelect.Width = 60;
            // 
            // txtChapIdentify
            // 
            this.txtChapIdentify.Text = "Identity";
            this.txtChapIdentify.Visible = false;
            // 
            // colChapId
            // 
            this.colChapId.Text = "ChapId";
            this.colChapId.Visible = false;
            // 
            // txtChapName
            // 
            this.txtChapName.Text = "Name";
            this.txtChapName.Width = 200;
            // 
            // txtChapLink
            // 
            this.txtChapLink.Text = "Link";
            this.txtChapLink.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSelectAll,
            this.mnuSelectNone,
            this.mnuSelectInverse,
            this.mnuSelectSelected,
            this.toolStripSeparator1,
            this.mnuAddQueue});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(171, 120);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Enabled = false;
            this.mnuSelectAll.Image = global::ComicDownloader.Properties.Resources._1364718418_checked_checkbox;
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(170, 22);
            this.mnuSelectAll.Text = "Check all";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // mnuSelectNone
            // 
            this.mnuSelectNone.Enabled = false;
            this.mnuSelectNone.Image = global::ComicDownloader.Properties.Resources._1364718448_checkbox_unchecked;
            this.mnuSelectNone.Name = "mnuSelectNone";
            this.mnuSelectNone.Size = new System.Drawing.Size(170, 22);
            this.mnuSelectNone.Text = "Uncheck All";
            this.mnuSelectNone.Click += new System.EventHandler(this.mnuSelectNone_Click);
            // 
            // mnuSelectInverse
            // 
            this.mnuSelectInverse.Enabled = false;
            this.mnuSelectInverse.Image = global::ComicDownloader.Properties.Resources._1364718484_radio_unchecked;
            this.mnuSelectInverse.Name = "mnuSelectInverse";
            this.mnuSelectInverse.Size = new System.Drawing.Size(170, 22);
            this.mnuSelectInverse.Text = "Check Inverse";
            this.mnuSelectInverse.Click += new System.EventHandler(this.mnuSelectInverse_Click);
            // 
            // mnuSelectSelected
            // 
            this.mnuSelectSelected.Enabled = false;
            this.mnuSelectSelected.Image = global::ComicDownloader.Properties.Resources._1364718512_to_do_list_cheked_all;
            this.mnuSelectSelected.Name = "mnuSelectSelected";
            this.mnuSelectSelected.Size = new System.Drawing.Size(170, 22);
            this.mnuSelectSelected.Text = "Check all select item";
            this.mnuSelectSelected.Click += new System.EventHandler(this.mnuSelectSelected_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // mnuAddQueue
            // 
            this.mnuAddQueue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOnlyToolStripMenuItem,
            this.mnuAddandStartQueue});
            this.mnuAddQueue.Enabled = false;
            this.mnuAddQueue.Image = global::ComicDownloader.Properties.Resources._1364647743_sheduled_task;
            this.mnuAddQueue.Name = "mnuAddQueue";
            this.mnuAddQueue.Size = new System.Drawing.Size(170, 22);
            this.mnuAddQueue.Text = "Add to Queue";
            this.mnuAddQueue.Click += new System.EventHandler(this.mnuAddQueue_Click);
            // 
            // addOnlyToolStripMenuItem
            // 
            this.addOnlyToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364718586_netvibes;
            this.addOnlyToolStripMenuItem.Name = "addOnlyToolStripMenuItem";
            this.addOnlyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.addOnlyToolStripMenuItem.Text = "Add Only";
            this.addOnlyToolStripMenuItem.Click += new System.EventHandler(this.addOnlyToolStripMenuItem_Click);
            // 
            // mnuAddandStartQueue
            // 
            this.mnuAddandStartQueue.Image = global::ComicDownloader.Properties.Resources._1364718804_start_here_ubuntustudio;
            this.mnuAddandStartQueue.Name = "mnuAddandStartQueue";
            this.mnuAddandStartQueue.Size = new System.Drawing.Size(144, 22);
            this.mnuAddandStartQueue.Text = "And and Start ";
            this.mnuAddandStartQueue.Click += new System.EventHandler(this.mnuAddandStartQueue_Click);
            // 
            // tblChapters
            // 
            this.tblChapters.RowAdded += new XPTable.Events.TableModelEventHandler(this.tblChapters_RowAdded);
            // 
            // groupDownload
            // 
            this.groupDownload.Controls.Add(this.txtDir);
            this.groupDownload.Controls.Add(this.label4);
            this.groupDownload.Controls.Add(this.button1);
            this.groupDownload.Controls.Add(this.btnExitThread);
            this.groupDownload.Controls.Add(this.bntPauseThread);
            this.groupDownload.Controls.Add(this.bntDownload);
            this.groupDownload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupDownload.Location = new System.Drawing.Point(0, 264);
            this.groupDownload.Name = "groupDownload";
            this.groupDownload.Size = new System.Drawing.Size(278, 94);
            this.groupDownload.TabIndex = 21;
            this.groupDownload.TabStop = false;
            this.groupDownload.Text = "Download";
            // 
            // btnExitThread
            // 
            this.btnExitThread.Enabled = false;
            this.btnExitThread.Location = new System.Drawing.Point(172, 58);
            this.btnExitThread.Name = "btnExitThread";
            this.btnExitThread.Size = new System.Drawing.Size(70, 23);
            this.btnExitThread.TabIndex = 17;
            this.btnExitThread.Text = "Stop";
            this.btnExitThread.UseVisualStyleBackColor = true;
            this.btnExitThread.Click += new System.EventHandler(this.btnExitThread_Click);
            // 
            // bntPauseThread
            // 
            this.bntPauseThread.Enabled = false;
            this.bntPauseThread.Location = new System.Drawing.Point(93, 58);
            this.bntPauseThread.Name = "bntPauseThread";
            this.bntPauseThread.Size = new System.Drawing.Size(70, 23);
            this.bntPauseThread.TabIndex = 13;
            this.bntPauseThread.Text = "Pause";
            this.bntPauseThread.UseVisualStyleBackColor = true;
            this.bntPauseThread.Click += new System.EventHandler(this.bntPauseThread_Click);
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.loading);
            this.groupInfo.Controls.Add(this.bntRefresh);
            this.groupInfo.Controls.Add(this.label5);
            this.groupInfo.Controls.Add(this.label3);
            this.groupInfo.Controls.Add(this.txtTitle);
            this.groupInfo.Controls.Add(this.label1);
            this.groupInfo.Controls.Add(this.bntInfo);
            this.groupInfo.Controls.Add(this.txtUrl);
            this.groupInfo.Controls.Add(this.ddlList);
            this.groupInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupInfo.Location = new System.Drawing.Point(0, 0);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(278, 159);
            this.groupInfo.TabIndex = 20;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "Info";
            // 
            // loading
            // 
            this.loading.Active = true;
            this.loading.Color = System.Drawing.Color.DarkGray;
            this.loading.InnerCircleRadius = 5;
            this.loading.Location = new System.Drawing.Point(172, 12);
            this.loading.Name = "loading";
            this.loading.NumberSpoke = 12;
            this.loading.OuterCircleRadius = 11;
            this.loading.RotationSpeed = 100;
            this.loading.Size = new System.Drawing.Size(10, 10);
            this.loading.SpokeThickness = 2;
            this.loading.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loading.TabIndex = 20;
            this.loading.Text = "loadingCircle1";
            this.loading.Visible = false;
            // 
            // bntRefresh
            // 
            this.bntRefresh.Enabled = false;
            this.bntRefresh.Image = global::ComicDownloader.Properties.Resources._1364155386_gtk_refresh;
            this.bntRefresh.Location = new System.Drawing.Point(242, 32);
            this.bntRefresh.Name = "bntRefresh";
            this.bntRefresh.Size = new System.Drawing.Size(33, 25);
            this.bntRefresh.TabIndex = 18;
            this.bntRefresh.UseVisualStyleBackColor = true;
            this.bntRefresh.Click += new System.EventHandler(this.bntRefresh_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Select a story from list";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL";
            // 
            // bntInfo
            // 
            this.bntInfo.Image = global::ComicDownloader.Properties.Resources.gtk_about;
            this.bntInfo.Location = new System.Drawing.Point(242, 80);
            this.bntInfo.Name = "bntInfo";
            this.bntInfo.Size = new System.Drawing.Size(30, 23);
            this.bntInfo.TabIndex = 16;
            this.bntInfo.UseVisualStyleBackColor = true;
            this.bntInfo.Click += new System.EventHandler(this.bntInfo_Click);
            // 
            // ddlList
            // 
            this.ddlList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlList.FormattingEnabled = true;
            this.ddlList.ItemHeight = 17;
            this.ddlList.Location = new System.Drawing.Point(19, 32);
            this.ddlList.Name = "ddlList";
            this.ddlList.Size = new System.Drawing.Size(209, 25);
            this.ddlList.TabIndex = 15;
            this.ddlList.SelectedIndexChanged += new System.EventHandler(this.ddlList_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listHistory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(278, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 358);
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
            this.colPDF});
            this.listHistory.ControlPadding = 4;
            this.listHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listHistory.FullRowSelect = true;
            this.listHistory.GridLines = true;
            this.listHistory.Location = new System.Drawing.Point(0, 0);
            this.listHistory.Name = "listHistory";
            this.listHistory.OwnerDraw = true;
            this.listHistory.Size = new System.Drawing.Size(671, 358);
            this.listHistory.StateImageList = this.imageList1;
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
            this.columnHeader4.Width = 25;
            // 
            // colPDF
            // 
            this.colPDF.Text = "PDF";
            this.colPDF.Width = 25;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(24, 24);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // errInvalidFileName
            // 
            this.errInvalidFileName.ContainerControl = this;
            // 
            // DownloaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 380);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "DownloaderForm";
            this.Text = "Comic Downloader Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloaderForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.gpbChapters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstChapters)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupDownload.ResumeLayout(false);
            this.groupDownload.PerformLayout();
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errInvalidFileName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtUrl;
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
        private EXColumnHeader colPDF;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblPageCount;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblTotalDownloadCount;
        private System.Windows.Forms.ColumnHeader index;
        private System.Windows.Forms.Button bntPauseThread;
        private System.Windows.Forms.ComboBox ddlList;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bntInfo;
        private System.Windows.Forms.Button btnExitThread;
        private System.Windows.Forms.GroupBox gpbChapters;
        private System.Windows.Forms.GroupBox groupDownload;
        private System.Windows.Forms.GroupBox groupInfo;
        private XPTable.Models.Table lstChapters;
        private XPTable.Models.ColumnModel columnModel1;
        private XPTable.Models.CheckBoxColumn chkSelect;
        private XPTable.Models.TextColumn txtChapName;
        private XPTable.Models.TextColumn txtChapLink;
        private XPTable.Models.TableModel tblChapters;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectNone;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectInverse;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectSelected;
        private XPTable.Models.NumberColumn colChapId;
        private System.Windows.Forms.ToolStripStatusLabel lblStoriesCount;
        private System.Windows.Forms.Button bntRefresh;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblSelected;
        private System.Windows.Forms.ErrorProvider errInvalidFileName;
        private MRG.Controls.UI.LoadingCircle loading;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuAddQueue;
        private System.Windows.Forms.ToolStripMenuItem addOnlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuAddandStartQueue;
        private XPTable.Models.TextColumn txtChapIdentify;
        
    }
}

