using System.Drawing;
using System.Windows.Forms;

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
            this.lblStoryPDF = new System.Windows.Forms.ToolStripStatusLabel();
            this.bntDownload = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lstChapters = new XPTable.Models.Table();
            this.columnModel1 = new XPTable.Models.ColumnModel();
            this.chkSelect = new XPTable.Models.CheckBoxColumn();
            this.txtChapIdentify = new XPTable.Models.TextColumn();
            this.colChapId = new XPTable.Models.NumberColumn();
            this.txtChapName = new XPTable.Models.TextColumn();
            this.txtChapLink = new XPTable.Models.TextColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuReadOnline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectInverse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectSelected = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAddQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.addOnlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddandStartQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.tblChapters = new XPTable.Models.TableModel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblAuthor = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblCat = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.htmlSumary = new MetroFramework.Drawing.Html.HtmlPanel();
            this.groupDownload = new System.Windows.Forms.GroupBox();
            this.btnExitThread = new System.Windows.Forms.Button();
            this.bntPauseThread = new System.Windows.Forms.Button();
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.btnSetting = new System.Windows.Forms.Button();
            this.ddlFilter = new System.Windows.Forms.ComboBox();
            this.loading = new MRG.Controls.UI.LoadingCircle();
            this.bntRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bntInfo = new System.Windows.Forms.Button();
            this.ddlList = new GroupedComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listHistory = new ComicDownloader.EXListView();
            this.index = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderProgress = ((ComicDownloader.EXColumnHeader)(new ComicDownloader.EXColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPDF = ((ComicDownloader.EXColumnHeader)(new ComicDownloader.EXColumnHeader()));
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openEbooksFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.errInvalidFileName = new System.Windows.Forms.ErrorProvider(this.components);
            this.tooltip = new MetroFramework.Drawing.Html.HtmlToolTip();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstChapters)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupDownload.SuspendLayout();
            this.groupInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errInvalidFileName)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(6, 80);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(230, 20);
            this.txtUrl.TabIndex = 0;
            this.txtUrl.Text = "[URL to story copy and paste or select from list]";
            this.txtUrl.TextChanged += new System.EventHandler(this.txtUrl_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Story title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(6, 128);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(232, 20);
            this.txtTitle.TabIndex = 4;
            this.txtTitle.Text = "[Story Title - unset]";
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(6, 19);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(236, 20);
            this.txtDir.TabIndex = 6;
            this.txtDir.Text = "C:\\Users\\Administrator\\Desktop\\teset";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.HelpRequest += new System.EventHandler(this.folderBrowserDialog1_HelpRequest);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 19);
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
            this.lblSelected,
            this.lblStoryPDF});
            this.statusStrip1.Location = new System.Drawing.Point(0, 409);
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
            this.lblStatus.Size = new System.Drawing.Size(51, 17);
            this.lblStatus.Text = "Pending";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // lblPageCount
            // 
            this.lblPageCount.Name = "lblPageCount";
            this.lblPageCount.Size = new System.Drawing.Size(0, 17);
            // 
            // progess
            // 
            this.progess.Maximum = 0;
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
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(33, 17);
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
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // lblSelected
            // 
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(0, 17);
            // 
            // lblStoryPDF
            // 
            this.lblStoryPDF.Name = "lblStoryPDF";
            this.lblStoryPDF.Size = new System.Drawing.Size(0, 17);
            // 
            // bntDownload
            // 
            this.bntDownload.Enabled = false;
            this.bntDownload.Location = new System.Drawing.Point(6, 45);
            this.bntDownload.Name = "bntDownload";
            this.bntDownload.Size = new System.Drawing.Size(70, 28);
            this.bntDownload.TabIndex = 11;
            this.bntDownload.Text = "Download";
            this.bntDownload.UseVisualStyleBackColor = true;
            this.bntDownload.Click += new System.EventHandler(this.bntDownload_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Controls.Add(this.groupDownload);
            this.panel1.Controls.Add(this.groupInfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 409);
            this.panel1.TabIndex = 12;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 159);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(278, 168);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstChapters);
            this.tabPage1.Location = new System.Drawing.Point(23, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(251, 160);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Chapters";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lstChapters
            // 
            this.lstChapters.ColumnModel = this.columnModel1;
            this.lstChapters.ContextMenuStrip = this.contextMenuStrip1;
            this.lstChapters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstChapters.FullRowSelect = true;
            this.lstChapters.GridLines = XPTable.Models.GridLines.Columns;
            this.lstChapters.HideSelection = true;
            this.lstChapters.Location = new System.Drawing.Point(3, 3);
            this.lstChapters.MultiSelect = true;
            this.lstChapters.Name = "lstChapters";
            this.lstChapters.Size = new System.Drawing.Size(245, 154);
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
            this.txtChapName.Width = 180;
            // 
            // txtChapLink
            // 
            this.txtChapLink.Text = "Link";
            this.txtChapLink.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReadOnline,
            this.toolStripSeparator2,
            this.mnuSelectAll,
            this.mnuSelectNone,
            this.mnuSelectInverse,
            this.mnuSelectSelected,
            this.toolStripSeparator1,
            this.mnuAddQueue});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(183, 148);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // mnuReadOnline
            // 
            this.mnuReadOnline.Image = global::ComicDownloader.Properties.Resources._1365316352_mark_as_read_32;
            this.mnuReadOnline.Name = "mnuReadOnline";
            this.mnuReadOnline.Size = new System.Drawing.Size(182, 22);
            this.mnuReadOnline.Text = "Read Online";
            this.mnuReadOnline.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Enabled = false;
            this.mnuSelectAll.Image = global::ComicDownloader.Properties.Resources._1364718418_checked_checkbox;
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(182, 22);
            this.mnuSelectAll.Text = "Check all";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // mnuSelectNone
            // 
            this.mnuSelectNone.Enabled = false;
            this.mnuSelectNone.Image = global::ComicDownloader.Properties.Resources._1364718448_checkbox_unchecked;
            this.mnuSelectNone.Name = "mnuSelectNone";
            this.mnuSelectNone.Size = new System.Drawing.Size(182, 22);
            this.mnuSelectNone.Text = "Uncheck All";
            this.mnuSelectNone.Click += new System.EventHandler(this.mnuSelectNone_Click);
            // 
            // mnuSelectInverse
            // 
            this.mnuSelectInverse.Enabled = false;
            this.mnuSelectInverse.Image = global::ComicDownloader.Properties.Resources._1364718484_radio_unchecked;
            this.mnuSelectInverse.Name = "mnuSelectInverse";
            this.mnuSelectInverse.Size = new System.Drawing.Size(182, 22);
            this.mnuSelectInverse.Text = "Check Inverse";
            this.mnuSelectInverse.Click += new System.EventHandler(this.mnuSelectInverse_Click);
            // 
            // mnuSelectSelected
            // 
            this.mnuSelectSelected.Enabled = false;
            this.mnuSelectSelected.Image = global::ComicDownloader.Properties.Resources._1364718512_to_do_list_cheked_all;
            this.mnuSelectSelected.Name = "mnuSelectSelected";
            this.mnuSelectSelected.Size = new System.Drawing.Size(182, 22);
            this.mnuSelectSelected.Text = "Check all select item";
            this.mnuSelectSelected.Click += new System.EventHandler(this.mnuSelectSelected_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuAddQueue
            // 
            this.mnuAddQueue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addOnlyToolStripMenuItem,
            this.mnuAddandStartQueue});
            this.mnuAddQueue.Enabled = false;
            this.mnuAddQueue.Image = global::ComicDownloader.Properties.Resources._1364647743_sheduled_task;
            this.mnuAddQueue.Name = "mnuAddQueue";
            this.mnuAddQueue.Size = new System.Drawing.Size(182, 22);
            this.mnuAddQueue.Text = "Add to Queue";
            this.mnuAddQueue.Click += new System.EventHandler(this.mnuAddQueue_Click);
            // 
            // addOnlyToolStripMenuItem
            // 
            this.addOnlyToolStripMenuItem.Image = global::ComicDownloader.Properties.Resources._1364718586_netvibes;
            this.addOnlyToolStripMenuItem.Name = "addOnlyToolStripMenuItem";
            this.addOnlyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addOnlyToolStripMenuItem.Text = "Add Only";
            this.addOnlyToolStripMenuItem.Click += new System.EventHandler(this.addOnlyToolStripMenuItem_Click);
            // 
            // mnuAddandStartQueue
            // 
            this.mnuAddandStartQueue.Image = global::ComicDownloader.Properties.Resources._1364718804_start_here_ubuntustudio;
            this.mnuAddandStartQueue.Name = "mnuAddandStartQueue";
            this.mnuAddandStartQueue.Size = new System.Drawing.Size(149, 22);
            this.mnuAddandStartQueue.Text = "And and Start ";
            this.mnuAddandStartQueue.Click += new System.EventHandler(this.mnuAddandStartQueue_Click);
            // 
            // tblChapters
            // 
            this.tblChapters.RowAdded += new XPTable.Events.TableModelEventHandler(this.tblChapters_RowAdded);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.flowLayoutPanel1);
            this.tabPage2.Location = new System.Drawing.Point(23, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(251, 160);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(245, 154);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblName);
            this.panel3.Controls.Add(this.metroLabel1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(239, 29);
            this.panel3.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AllowDrop = true;
            this.lblName.Location = new System.Drawing.Point(54, 3);
            this.lblName.MaximumSize = new System.Drawing.Size(170, 200);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(159, 19);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel1.Location = new System.Drawing.Point(3, 3);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(45, 19);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Name";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblAuthor);
            this.panel5.Controls.Add(this.metroLabel4);
            this.panel5.Location = new System.Drawing.Point(3, 38);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(239, 29);
            this.panel5.TabIndex = 3;
            // 
            // lblAuthor
            // 
            this.lblAuthor.AllowDrop = true;
            this.lblAuthor.Location = new System.Drawing.Point(54, 3);
            this.lblAuthor.MaximumSize = new System.Drawing.Size(170, 200);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(168, 19);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "AUTHOR";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(3, 3);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(52, 19);
            this.metroLabel4.TabIndex = 0;
            this.metroLabel4.Text = "Author";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblCat);
            this.panel4.Controls.Add(this.metroLabel3);
            this.panel4.Location = new System.Drawing.Point(3, 73);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(239, 29);
            this.panel4.TabIndex = 2;
            // 
            // lblCat
            // 
            this.lblCat.AllowDrop = true;
            this.lblCat.Location = new System.Drawing.Point(54, 3);
            this.lblCat.MaximumSize = new System.Drawing.Size(170, 200);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(168, 19);
            this.lblCat.TabIndex = 1;
            this.lblCat.Text = "CAT";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(3, 3);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(30, 19);
            this.metroLabel3.TabIndex = 0;
            this.metroLabel3.Text = "Cat";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.metroLabel2);
            this.panel6.Controls.Add(this.metroLabel5);
            this.panel6.Location = new System.Drawing.Point(3, 108);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(239, 29);
            this.panel6.TabIndex = 3;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AllowDrop = true;
            this.metroLabel2.Location = new System.Drawing.Point(54, 3);
            this.metroLabel2.MaximumSize = new System.Drawing.Size(170, 200);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(168, 19);
            this.metroLabel2.TabIndex = 1;
            this.metroLabel2.Text = "Unknow";
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(3, 3);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(47, 19);
            this.metroLabel5.TabIndex = 0;
            this.metroLabel5.Text = "Status";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Location = new System.Drawing.Point(3, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(239, 10);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.pictureBox1_LoadCompleted);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.htmlSumary);
            this.tabPage3.Location = new System.Drawing.Point(23, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(251, 160);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Summary";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // htmlSumary
            // 
            this.htmlSumary.AutoScroll = true;
            this.htmlSumary.AutoScrollMinSize = new System.Drawing.Size(245, 18);
            this.htmlSumary.BackColor = System.Drawing.SystemColors.Window;
            this.htmlSumary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.htmlSumary.Location = new System.Drawing.Point(3, 3);
            this.htmlSumary.MinimumSize = new System.Drawing.Size(0, 300);
            this.htmlSumary.Name = "htmlSumary";
            this.htmlSumary.Size = new System.Drawing.Size(245, 300);
            this.htmlSumary.TabIndex = 5;
            this.htmlSumary.Text = "Summary";
            // 
            // groupDownload
            // 
            this.groupDownload.Controls.Add(this.txtDir);
            this.groupDownload.Controls.Add(this.button1);
            this.groupDownload.Controls.Add(this.btnExitThread);
            this.groupDownload.Controls.Add(this.bntPauseThread);
            this.groupDownload.Controls.Add(this.bntDownload);
            this.groupDownload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupDownload.Location = new System.Drawing.Point(0, 327);
            this.groupDownload.Name = "groupDownload";
            this.groupDownload.Size = new System.Drawing.Size(278, 82);
            this.groupDownload.TabIndex = 21;
            this.groupDownload.TabStop = false;
            this.groupDownload.Text = "Destination Folder";
            // 
            // btnExitThread
            // 
            this.btnExitThread.Enabled = false;
            this.btnExitThread.Location = new System.Drawing.Point(172, 45);
            this.btnExitThread.Name = "btnExitThread";
            this.btnExitThread.Size = new System.Drawing.Size(70, 28);
            this.btnExitThread.TabIndex = 17;
            this.btnExitThread.Text = "Stop";
            this.btnExitThread.UseVisualStyleBackColor = true;
            this.btnExitThread.Click += new System.EventHandler(this.btnExitThread_Click);
            // 
            // bntPauseThread
            // 
            this.bntPauseThread.Enabled = false;
            this.bntPauseThread.Location = new System.Drawing.Point(96, 45);
            this.bntPauseThread.Name = "bntPauseThread";
            this.bntPauseThread.Size = new System.Drawing.Size(70, 28);
            this.bntPauseThread.TabIndex = 13;
            this.bntPauseThread.Text = "Pause";
            this.bntPauseThread.UseVisualStyleBackColor = true;
            this.bntPauseThread.Click += new System.EventHandler(this.bntPauseThread_Click);
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.btnSetting);
            this.groupInfo.Controls.Add(this.ddlFilter);
            this.groupInfo.Controls.Add(this.loading);
            this.groupInfo.Controls.Add(this.bntRefresh);
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
            this.groupInfo.Text = "Select a manga to download";
            // 
            // btnSetting
            // 
            this.btnSetting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSetting.Image = global::ComicDownloader.Properties.Resources._1454337668_gear_user;
            this.btnSetting.Location = new System.Drawing.Point(248, 2);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(26, 26);
            this.btnSetting.TabIndex = 22;
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // ddlFilter
            // 
            this.ddlFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ddlFilter.FormattingEnabled = true;
            this.ddlFilter.Location = new System.Drawing.Point(6, 32);
            this.ddlFilter.Name = "ddlFilter";
            this.ddlFilter.Size = new System.Drawing.Size(44, 23);
            this.ddlFilter.TabIndex = 21;
            this.ddlFilter.SelectedIndexChanged += new System.EventHandler(this.ddlFilter_SelectedIndexChanged);
            // 
            // loading
            // 
            this.loading.Active = true;
            this.loading.Color = System.Drawing.Color.DarkGray;
            this.loading.InnerCircleRadius = 5;
            this.loading.Location = new System.Drawing.Point(144, 96);
            this.loading.Name = "loading";
            this.loading.NumberSpoke = 12;
            this.loading.OuterCircleRadius = 11;
            this.loading.RotationSpeed = 100;
            this.loading.Size = new System.Drawing.Size(33, 26);
            this.loading.SpokeThickness = 2;
            this.loading.StylePreset = MRG.Controls.UI.LoadingCircle.StylePresets.MacOSX;
            this.loading.TabIndex = 20;
            this.loading.Text = "loadingCircle1";
            this.loading.Visible = false;
            // 
            // bntRefresh
            // 
            this.bntRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bntRefresh.Enabled = false;
            this.bntRefresh.Image = global::ComicDownloader.Properties.Resources._1454256850_view_refresh;
            this.bntRefresh.Location = new System.Drawing.Point(242, 32);
            this.bntRefresh.Name = "bntRefresh";
            this.bntRefresh.Size = new System.Drawing.Size(33, 25);
            this.bntRefresh.TabIndex = 18;
            this.bntRefresh.UseVisualStyleBackColor = true;
            this.bntRefresh.Click += new System.EventHandler(this.bntRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Story Url (copy & paste or select above";
            // 
            // bntInfo
            // 
            this.bntInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bntInfo.Image = global::ComicDownloader.Properties.Resources._1454256989_sign_info;
            this.bntInfo.Location = new System.Drawing.Point(242, 80);
            this.bntInfo.Name = "bntInfo";
            this.bntInfo.Size = new System.Drawing.Size(30, 23);
            this.bntInfo.TabIndex = 16;
            this.bntInfo.UseVisualStyleBackColor = true;
            this.bntInfo.Click += new System.EventHandler(this.bntInfo_Click);
            // 
            // ddlList
            // 
            this.ddlList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.ddlList.DataSource = null;
            this.ddlList.DisplayMember = "Name";
            this.ddlList.DropDownHeight = 500;
            this.ddlList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ddlList.FormattingEnabled = true;
            this.ddlList.GroupMember = "Group";
            this.ddlList.IntegralHeight = false;
            this.ddlList.ItemHeight = 17;
            this.ddlList.Location = new System.Drawing.Point(54, 32);
            this.ddlList.MaxDropDownItems = 20;
            this.ddlList.Name = "ddlList";
            this.ddlList.Size = new System.Drawing.Size(174, 23);
            this.ddlList.TabIndex = 15;
            this.ddlList.ValueMember = "Url";
            this.ddlList.SelectedIndexChanged += new System.EventHandler(this.ddlList_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listHistory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(278, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 409);
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
            this.listHistory.ContextMenuStrip = this.contextMenuStrip2;
            this.listHistory.ControlPadding = 4;
            this.listHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listHistory.FullRowSelect = true;
            this.listHistory.GridLines = true;
            this.listHistory.Location = new System.Drawing.Point(0, 0);
            this.listHistory.Name = "listHistory";
            this.listHistory.OwnerDraw = true;
            this.listHistory.Size = new System.Drawing.Size(671, 409);
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
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem,
            this.openEbooksFolderToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(181, 48);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // openEbooksFolderToolStripMenuItem
            // 
            this.openEbooksFolderToolStripMenuItem.Name = "openEbooksFolderToolStripMenuItem";
            this.openEbooksFolderToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openEbooksFolderToolStripMenuItem.Text = "Open Ebooks Folder";
            this.openEbooksFolderToolStripMenuItem.Click += new System.EventHandler(this.openEbooksFolderToolStripMenuItem_Click);
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
            // tooltip
            // 
            this.tooltip.OwnerDraw = true;
            // 
            // DownloaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 431);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "DownloaderForm";
            this.Text = "Comic Downloader Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DownloaderForm_FormClosing);
            this.Load += new System.EventHandler(this.DownloadForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstChapters)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupDownload.ResumeLayout(false);
            this.groupDownload.PerformLayout();
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errInvalidFileName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox txtUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txtTitle;
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bntInfo;
        private System.Windows.Forms.Button btnExitThread;
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuReadOnline;
        private GroupedComboBox ddlList;
        private System.Windows.Forms.ComboBox ddlFilter;
        private Button btnSetting;
        private ToolStripMenuItem openFolderToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip2;
        private ToolStripStatusLabel lblStoryPDF;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel3;
        private MetroFramework.Controls.MetroLabel lblName;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private Panel panel4;
        private MetroFramework.Controls.MetroLabel lblCat;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private PictureBox pictureBox1;
        private Panel panel5;
        private MetroFramework.Controls.MetroLabel lblAuthor;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Drawing.Html.HtmlToolTip tooltip;
        private Panel panel6;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private TabPage tabPage3;
        private MetroFramework.Drawing.Html.HtmlPanel htmlSumary;
        private ToolStripMenuItem openEbooksFolderToolStripMenuItem;
    }
}

