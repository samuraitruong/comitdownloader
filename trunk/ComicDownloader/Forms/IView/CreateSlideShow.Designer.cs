namespace IView.UI.Forms
{
    partial class CreateSlideShow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateSlideShow));
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.pan_Files = new System.Windows.Forms.Panel();
            this.lvw_Files = new System.Windows.Forms.ListView();
            this.ch_Files = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ts_FileOptions = new System.Windows.Forms.ToolStrip();
            this.tsb_Add = new System.Windows.Forms.ToolStripButton();
            this.tsb_Remove = new System.Windows.Forms.ToolStripButton();
            this.tss_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_MoveUp = new System.Windows.Forms.ToolStripButton();
            this.tsb_MoveDown = new System.Windows.Forms.ToolStripButton();
            this.tss_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddb_Sort = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmi_sort_Ascending = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_sort_Descending = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_sort_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_sort_Randomize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsl_FilesInfo = new System.Windows.Forms.ToolStripLabel();
            this.pan_ImagePreview = new System.Windows.Forms.Panel();
            this.gbx_Files = new System.Windows.Forms.GroupBox();
            this.lbl_PreviewFileName = new System.Windows.Forms.Label();
            this.ckb_ShowPreview = new System.Windows.Forms.CheckBox();
            this.gbx_Properties = new System.Windows.Forms.GroupBox();
            this.pan_NameError = new System.Windows.Forms.Panel();
            this.nud_Seconds = new System.Windows.Forms.NumericUpDown();
            this.lbl_Seconds = new System.Windows.Forms.Label();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.cbx_FadeSpeed = new System.Windows.Forms.ComboBox();
            this.cbx_TransitionMode = new System.Windows.Forms.ComboBox();
            this.txtb_SaveLocation = new System.Windows.Forms.TextBox();
            this.lbl_SaveoLocation = new System.Windows.Forms.Label();
            this.lbl_Created = new System.Windows.Forms.Label();
            this.dtp_Created = new System.Windows.Forms.DateTimePicker();
            this.txtb_FileName = new System.Windows.Forms.TextBox();
            this.lbl_FileName = new System.Windows.Forms.Label();
            this.lbl_ImageViewTime = new System.Windows.Forms.Label();
            this.lbl_FadeSpeed = new System.Windows.Forms.Label();
            this.lbl_TransitionMode = new System.Windows.Forms.Label();
            this.btn_Import = new System.Windows.Forms.Button();
            this.tt_Info = new System.Windows.Forms.ToolTip(this.components);
            this.pan_Files.SuspendLayout();
            this.ts_FileOptions.SuspendLayout();
            this.gbx_Files.SuspendLayout();
            this.gbx_Properties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Seconds)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.Location = new System.Drawing.Point(457, 422);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "&Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.Enabled = false;
            this.btn_OK.Location = new System.Drawing.Point(376, 422);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 25);
            this.btn_OK.TabIndex = 0;
            this.btn_OK.Text = "&Save";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // pan_Files
            // 
            this.pan_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_Files.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_Files.Controls.Add(this.lvw_Files);
            this.pan_Files.Controls.Add(this.ts_FileOptions);
            this.pan_Files.Location = new System.Drawing.Point(6, 20);
            this.pan_Files.Name = "pan_Files";
            this.pan_Files.Size = new System.Drawing.Size(392, 162);
            this.pan_Files.TabIndex = 4;
            // 
            // lvw_Files
            // 
            this.lvw_Files.AllowDrop = true;
            this.lvw_Files.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvw_Files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_Files});
            this.lvw_Files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvw_Files.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvw_Files.Location = new System.Drawing.Point(0, 25);
            this.lvw_Files.Name = "lvw_Files";
            this.lvw_Files.ShowItemToolTips = true;
            this.lvw_Files.Size = new System.Drawing.Size(390, 135);
            this.lvw_Files.TabIndex = 0;
            this.lvw_Files.UseCompatibleStateImageBehavior = false;
            this.lvw_Files.View = System.Windows.Forms.View.Details;
            this.lvw_Files.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvw_Files_ItemSelectionChanged);
            this.lvw_Files.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvw_Files_DragDrop);
            this.lvw_Files.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvw_Files_DragEnter);
            // 
            // ch_Files
            // 
            this.ch_Files.Text = "Files";
            this.ch_Files.Width = 360;
            // 
            // ts_FileOptions
            // 
            this.ts_FileOptions.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_FileOptions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_FileOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_Add,
            this.tsb_Remove,
            this.tss_01,
            this.tsb_MoveUp,
            this.tsb_MoveDown,
            this.tss_02,
            this.tsddb_Sort,
            this.tsl_FilesInfo});
            this.ts_FileOptions.Location = new System.Drawing.Point(0, 0);
            this.ts_FileOptions.Name = "ts_FileOptions";
            this.ts_FileOptions.Size = new System.Drawing.Size(390, 25);
            this.ts_FileOptions.TabIndex = 0;
            this.ts_FileOptions.Text = "toolStrip1";
            // 
            // tsb_Add
            // 
            this.tsb_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Add.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Add.Image")));
            this.tsb_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Add.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsb_Add.Name = "tsb_Add";
            this.tsb_Add.Size = new System.Drawing.Size(23, 22);
            this.tsb_Add.Text = "Add Files";
            this.tsb_Add.Click += new System.EventHandler(this.tsb_Add_Click);
            // 
            // tsb_Remove
            // 
            this.tsb_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_Remove.Enabled = false;
            this.tsb_Remove.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Remove.Image")));
            this.tsb_Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Remove.Name = "tsb_Remove";
            this.tsb_Remove.Size = new System.Drawing.Size(23, 22);
            this.tsb_Remove.Text = "Remove";
            this.tsb_Remove.Click += new System.EventHandler(this.tsb_Remove_Click);
            // 
            // tss_01
            // 
            this.tss_01.Name = "tss_01";
            this.tss_01.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_MoveUp
            // 
            this.tsb_MoveUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_MoveUp.Enabled = false;
            this.tsb_MoveUp.Image = ((System.Drawing.Image)(resources.GetObject("tsb_MoveUp.Image")));
            this.tsb_MoveUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_MoveUp.Name = "tsb_MoveUp";
            this.tsb_MoveUp.Size = new System.Drawing.Size(23, 22);
            this.tsb_MoveUp.Text = "Move Up";
            this.tsb_MoveUp.Click += new System.EventHandler(this.tsb_MoveUp_Click);
            // 
            // tsb_MoveDown
            // 
            this.tsb_MoveDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_MoveDown.Enabled = false;
            this.tsb_MoveDown.Image = ((System.Drawing.Image)(resources.GetObject("tsb_MoveDown.Image")));
            this.tsb_MoveDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_MoveDown.Name = "tsb_MoveDown";
            this.tsb_MoveDown.Size = new System.Drawing.Size(23, 22);
            this.tsb_MoveDown.Text = "Move Down";
            this.tsb_MoveDown.Click += new System.EventHandler(this.tsb_MoveDown_Click);
            // 
            // tss_02
            // 
            this.tss_02.Name = "tss_02";
            this.tss_02.Size = new System.Drawing.Size(6, 25);
            // 
            // tsddb_Sort
            // 
            this.tsddb_Sort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_sort_Ascending,
            this.tsmi_sort_Descending,
            this.tss_sort_01,
            this.tsmi_sort_Randomize});
            this.tsddb_Sort.Enabled = false;
            this.tsddb_Sort.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_Sort.Image")));
            this.tsddb_Sort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_Sort.Name = "tsddb_Sort";
            this.tsddb_Sort.Size = new System.Drawing.Size(63, 22);
            this.tsddb_Sort.Text = "Sort";
            // 
            // tsmi_sort_Ascending
            // 
            this.tsmi_sort_Ascending.Name = "tsmi_sort_Ascending";
            this.tsmi_sort_Ascending.Size = new System.Drawing.Size(147, 22);
            this.tsmi_sort_Ascending.Text = "Ascending";
            this.tsmi_sort_Ascending.Click += new System.EventHandler(this.tsmi_sort_Ascending_Click);
            // 
            // tsmi_sort_Descending
            // 
            this.tsmi_sort_Descending.Name = "tsmi_sort_Descending";
            this.tsmi_sort_Descending.Size = new System.Drawing.Size(147, 22);
            this.tsmi_sort_Descending.Text = "Descending";
            this.tsmi_sort_Descending.Click += new System.EventHandler(this.tsmi_sort_Descending_Click);
            // 
            // tss_sort_01
            // 
            this.tss_sort_01.Name = "tss_sort_01";
            this.tss_sort_01.Size = new System.Drawing.Size(144, 6);
            // 
            // tsmi_sort_Randomize
            // 
            this.tsmi_sort_Randomize.Name = "tsmi_sort_Randomize";
            this.tsmi_sort_Randomize.Size = new System.Drawing.Size(147, 22);
            this.tsmi_sort_Randomize.Text = "Randomize";
            this.tsmi_sort_Randomize.Click += new System.EventHandler(this.tsmi_sort_Randomize_Click);
            // 
            // tsl_FilesInfo
            // 
            this.tsl_FilesInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsl_FilesInfo.Name = "tsl_FilesInfo";
            this.tsl_FilesInfo.Size = new System.Drawing.Size(59, 22);
            this.tsl_FilesInfo.Text = "Items: 0";
            // 
            // pan_ImagePreview
            // 
            this.pan_ImagePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pan_ImagePreview.BackColor = System.Drawing.Color.Black;
            this.pan_ImagePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pan_ImagePreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_ImagePreview.Location = new System.Drawing.Point(404, 20);
            this.pan_ImagePreview.Name = "pan_ImagePreview";
            this.pan_ImagePreview.Size = new System.Drawing.Size(110, 80);
            this.pan_ImagePreview.TabIndex = 5;
            // 
            // gbx_Files
            // 
            this.gbx_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Files.Controls.Add(this.lbl_PreviewFileName);
            this.gbx_Files.Controls.Add(this.ckb_ShowPreview);
            this.gbx_Files.Controls.Add(this.pan_Files);
            this.gbx_Files.Controls.Add(this.pan_ImagePreview);
            this.gbx_Files.Location = new System.Drawing.Point(12, 12);
            this.gbx_Files.Name = "gbx_Files";
            this.gbx_Files.Size = new System.Drawing.Size(520, 188);
            this.gbx_Files.TabIndex = 6;
            this.gbx_Files.TabStop = false;
            this.gbx_Files.Text = "Files";
            // 
            // lbl_PreviewFileName
            // 
            this.lbl_PreviewFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_PreviewFileName.AutoEllipsis = true;
            this.lbl_PreviewFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_PreviewFileName.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PreviewFileName.Location = new System.Drawing.Point(404, 130);
            this.lbl_PreviewFileName.Name = "lbl_PreviewFileName";
            this.lbl_PreviewFileName.Size = new System.Drawing.Size(110, 52);
            this.lbl_PreviewFileName.TabIndex = 0;
            this.lbl_PreviewFileName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckb_ShowPreview
            // 
            this.ckb_ShowPreview.AutoSize = true;
            this.ckb_ShowPreview.Checked = true;
            this.ckb_ShowPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckb_ShowPreview.Location = new System.Drawing.Point(404, 106);
            this.ckb_ShowPreview.Name = "ckb_ShowPreview";
            this.ckb_ShowPreview.Size = new System.Drawing.Size(115, 21);
            this.ckb_ShowPreview.TabIndex = 0;
            this.ckb_ShowPreview.Text = "Show preview";
            this.ckb_ShowPreview.UseVisualStyleBackColor = true;
            this.ckb_ShowPreview.CheckedChanged += new System.EventHandler(this.ckb_ShowPreview_CheckedChanged);
            // 
            // gbx_Properties
            // 
            this.gbx_Properties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbx_Properties.Controls.Add(this.pan_NameError);
            this.gbx_Properties.Controls.Add(this.nud_Seconds);
            this.gbx_Properties.Controls.Add(this.lbl_Seconds);
            this.gbx_Properties.Controls.Add(this.btn_Browse);
            this.gbx_Properties.Controls.Add(this.cbx_FadeSpeed);
            this.gbx_Properties.Controls.Add(this.cbx_TransitionMode);
            this.gbx_Properties.Controls.Add(this.txtb_SaveLocation);
            this.gbx_Properties.Controls.Add(this.lbl_SaveoLocation);
            this.gbx_Properties.Controls.Add(this.lbl_Created);
            this.gbx_Properties.Controls.Add(this.dtp_Created);
            this.gbx_Properties.Controls.Add(this.txtb_FileName);
            this.gbx_Properties.Controls.Add(this.lbl_FileName);
            this.gbx_Properties.Controls.Add(this.lbl_ImageViewTime);
            this.gbx_Properties.Controls.Add(this.lbl_FadeSpeed);
            this.gbx_Properties.Controls.Add(this.lbl_TransitionMode);
            this.gbx_Properties.Location = new System.Drawing.Point(12, 206);
            this.gbx_Properties.Name = "gbx_Properties";
            this.gbx_Properties.Size = new System.Drawing.Size(520, 210);
            this.gbx_Properties.TabIndex = 7;
            this.gbx_Properties.TabStop = false;
            this.gbx_Properties.Text = "Properties";
            // 
            // pan_NameError
            // 
            this.pan_NameError.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pan_NameError.BackgroundImage")));
            this.pan_NameError.Location = new System.Drawing.Point(242, 21);
            this.pan_NameError.Name = "pan_NameError";
            this.pan_NameError.Size = new System.Drawing.Size(16, 16);
            this.pan_NameError.TabIndex = 20;
            this.pan_NameError.Visible = false;
            // 
            // nud_Seconds
            // 
            this.nud_Seconds.Location = new System.Drawing.Point(124, 70);
            this.nud_Seconds.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nud_Seconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_Seconds.Name = "nud_Seconds";
            this.nud_Seconds.Size = new System.Drawing.Size(60, 24);
            this.nud_Seconds.TabIndex = 2;
            this.nud_Seconds.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Seconds.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lbl_Seconds
            // 
            this.lbl_Seconds.AutoSize = true;
            this.lbl_Seconds.Location = new System.Drawing.Point(190, 72);
            this.lbl_Seconds.Name = "lbl_Seconds";
            this.lbl_Seconds.Size = new System.Drawing.Size(60, 17);
            this.lbl_Seconds.TabIndex = 18;
            this.lbl_Seconds.Text = "Seconds";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Browse.Location = new System.Drawing.Point(479, 179);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(35, 25);
            this.btn_Browse.TabIndex = 6;
            this.btn_Browse.Text = "...";
            this.tt_Info.SetToolTip(this.btn_Browse, "Browse");
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // cbx_FadeSpeed
            // 
            this.cbx_FadeSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_FadeSpeed.FormattingEnabled = true;
            this.cbx_FadeSpeed.Location = new System.Drawing.Point(124, 131);
            this.cbx_FadeSpeed.Name = "cbx_FadeSpeed";
            this.cbx_FadeSpeed.Size = new System.Drawing.Size(134, 25);
            this.cbx_FadeSpeed.TabIndex = 4;
            // 
            // cbx_TransitionMode
            // 
            this.cbx_TransitionMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_TransitionMode.FormattingEnabled = true;
            this.cbx_TransitionMode.Location = new System.Drawing.Point(124, 100);
            this.cbx_TransitionMode.Name = "cbx_TransitionMode";
            this.cbx_TransitionMode.Size = new System.Drawing.Size(134, 25);
            this.cbx_TransitionMode.TabIndex = 3;
            // 
            // txtb_SaveLocation
            // 
            this.txtb_SaveLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_SaveLocation.BackColor = System.Drawing.Color.White;
            this.txtb_SaveLocation.Location = new System.Drawing.Point(6, 183);
            this.txtb_SaveLocation.Name = "txtb_SaveLocation";
            this.txtb_SaveLocation.ReadOnly = true;
            this.txtb_SaveLocation.Size = new System.Drawing.Size(467, 24);
            this.txtb_SaveLocation.TabIndex = 5;
            // 
            // lbl_SaveoLocation
            // 
            this.lbl_SaveoLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbl_SaveoLocation.AutoSize = true;
            this.lbl_SaveoLocation.Location = new System.Drawing.Point(6, 163);
            this.lbl_SaveoLocation.Name = "lbl_SaveoLocation";
            this.lbl_SaveoLocation.Size = new System.Drawing.Size(94, 17);
            this.lbl_SaveoLocation.TabIndex = 13;
            this.lbl_SaveoLocation.Text = "Save location:";
            // 
            // lbl_Created
            // 
            this.lbl_Created.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Created.AutoSize = true;
            this.lbl_Created.Location = new System.Drawing.Point(261, 20);
            this.lbl_Created.Name = "lbl_Created";
            this.lbl_Created.Size = new System.Drawing.Size(61, 17);
            this.lbl_Created.TabIndex = 12;
            this.lbl_Created.Text = "Created:";
            // 
            // dtp_Created
            // 
            this.dtp_Created.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtp_Created.Location = new System.Drawing.Point(264, 40);
            this.dtp_Created.Name = "dtp_Created";
            this.dtp_Created.Size = new System.Drawing.Size(250, 24);
            this.dtp_Created.TabIndex = 1;
            // 
            // txtb_FileName
            // 
            this.txtb_FileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtb_FileName.Location = new System.Drawing.Point(6, 40);
            this.txtb_FileName.MaxLength = 256;
            this.txtb_FileName.Name = "txtb_FileName";
            this.txtb_FileName.Size = new System.Drawing.Size(252, 24);
            this.txtb_FileName.TabIndex = 0;
            this.txtb_FileName.Text = "Untitled";
            this.txtb_FileName.TextChanged += new System.EventHandler(this.txtb_FileName_TextChanged);
            // 
            // lbl_FileName
            // 
            this.lbl_FileName.AutoSize = true;
            this.lbl_FileName.Location = new System.Drawing.Point(6, 20);
            this.lbl_FileName.Name = "lbl_FileName";
            this.lbl_FileName.Size = new System.Drawing.Size(69, 17);
            this.lbl_FileName.TabIndex = 9;
            this.lbl_FileName.Text = "File name:";
            // 
            // lbl_ImageViewTime
            // 
            this.lbl_ImageViewTime.AutoSize = true;
            this.lbl_ImageViewTime.Location = new System.Drawing.Point(6, 72);
            this.lbl_ImageViewTime.Name = "lbl_ImageViewTime";
            this.lbl_ImageViewTime.Size = new System.Drawing.Size(112, 17);
            this.lbl_ImageViewTime.TabIndex = 8;
            this.lbl_ImageViewTime.Text = "Image view time:";
            // 
            // lbl_FadeSpeed
            // 
            this.lbl_FadeSpeed.AutoSize = true;
            this.lbl_FadeSpeed.Location = new System.Drawing.Point(6, 134);
            this.lbl_FadeSpeed.Name = "lbl_FadeSpeed";
            this.lbl_FadeSpeed.Size = new System.Drawing.Size(82, 17);
            this.lbl_FadeSpeed.TabIndex = 7;
            this.lbl_FadeSpeed.Text = "Fade speed:";
            // 
            // lbl_TransitionMode
            // 
            this.lbl_TransitionMode.AutoSize = true;
            this.lbl_TransitionMode.Location = new System.Drawing.Point(6, 103);
            this.lbl_TransitionMode.Name = "lbl_TransitionMode";
            this.lbl_TransitionMode.Size = new System.Drawing.Size(111, 17);
            this.lbl_TransitionMode.TabIndex = 6;
            this.lbl_TransitionMode.Text = "Transition mode:";
            // 
            // btn_Import
            // 
            this.btn_Import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Import.Location = new System.Drawing.Point(12, 422);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(90, 25);
            this.btn_Import.TabIndex = 2;
            this.btn_Import.Text = "&Import...";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // FormCreateSlideShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 457);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.gbx_Properties);
            this.Controls.Add(this.gbx_Files);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCreateSlideShow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Slide Show";
            this.pan_Files.ResumeLayout(false);
            this.pan_Files.PerformLayout();
            this.ts_FileOptions.ResumeLayout(false);
            this.ts_FileOptions.PerformLayout();
            this.gbx_Files.ResumeLayout(false);
            this.gbx_Files.PerformLayout();
            this.gbx_Properties.ResumeLayout(false);
            this.gbx_Properties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Seconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Panel pan_ImagePreview;
        private System.Windows.Forms.Panel pan_Files;
        private System.Windows.Forms.ListView lvw_Files;
        private System.Windows.Forms.ColumnHeader ch_Files;
        private System.Windows.Forms.ToolStrip ts_FileOptions;
        private System.Windows.Forms.ToolStripButton tsb_Add;
        private System.Windows.Forms.ToolStripButton tsb_Remove;
        private System.Windows.Forms.ToolStripSeparator tss_01;
        private System.Windows.Forms.ToolStripButton tsb_MoveUp;
        private System.Windows.Forms.ToolStripButton tsb_MoveDown;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_Sort;
        private System.Windows.Forms.GroupBox gbx_Files;
        private System.Windows.Forms.GroupBox gbx_Properties;
        private System.Windows.Forms.ComboBox cbx_FadeSpeed;
        private System.Windows.Forms.ComboBox cbx_TransitionMode;
        private System.Windows.Forms.TextBox txtb_SaveLocation;
        private System.Windows.Forms.Label lbl_SaveoLocation;
        private System.Windows.Forms.Label lbl_Created;
        private System.Windows.Forms.DateTimePicker dtp_Created;
        private System.Windows.Forms.TextBox txtb_FileName;
        private System.Windows.Forms.Label lbl_FileName;
        private System.Windows.Forms.Label lbl_ImageViewTime;
        private System.Windows.Forms.Label lbl_FadeSpeed;
        private System.Windows.Forms.Label lbl_TransitionMode;
        private System.Windows.Forms.Label lbl_PreviewFileName;
        private System.Windows.Forms.Label lbl_Seconds;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.ToolStripSeparator tss_02;
        private System.Windows.Forms.ToolStripLabel tsl_FilesInfo;
        private System.Windows.Forms.CheckBox ckb_ShowPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmi_sort_Ascending;
        private System.Windows.Forms.ToolStripMenuItem tsmi_sort_Descending;
        private System.Windows.Forms.ToolStripSeparator tss_sort_01;
        private System.Windows.Forms.ToolStripMenuItem tsmi_sort_Randomize;
        private System.Windows.Forms.NumericUpDown nud_Seconds;
        private System.Windows.Forms.Panel pan_NameError;
        private System.Windows.Forms.ToolTip tt_Info;

    }
}