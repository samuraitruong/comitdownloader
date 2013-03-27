namespace IView.UI.Forms
{
    partial class MainWindow
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
            // Clean up.
            CleanUpResources(disposing);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.ms_Main = new System.Windows.Forms.MenuStrip();
            this.tsmi_File = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_file_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_file_OpenImageFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_file_OpenSlideShowFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_file_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_file_Favourite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_file_NewFavourite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_file_AddFavourite = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_file_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_file_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_file_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_file_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_file_PageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_file_PrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_file_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_file_04 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_file_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_file_05 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_file_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_ClearChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_edit_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_edit_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_edit_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_edit_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_edit_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_edit_FreeTransform = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_Transform = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_Resize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_Shear = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_edit_04 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_edit_Rotate90Clockwise = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_Rotate90CounterClockwise = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_Rotate180 = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_edit_05 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_edit_FlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_edit_FlipVertical = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_View = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_view_Windows = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_win_OpenNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_win_CloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_win_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tss_view_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_view_SlideShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_view_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_view_Explorer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_view_ImageList = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_view_Task = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_view_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_view_ImageListView = new System.Windows.Forms.ToolStripMenuItem();
            this.cms_ImageListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_ilvw_LargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ilvw_MediumIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ilvw_SmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ilvw_List = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_ilvw_Details = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_view_04 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_view_Toolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_view_StatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_view_FullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_view_05 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_view_Refresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Filters = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_filter_GreyScale = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_filter_Invert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_filter_PhotoCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_filter_RotateColour = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_filter_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_filter_BrightnessContrast = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_filter_ColourBalance = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_filter_Gamma = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_filter_Noise = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_filter_Transparency = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_tools_BatchEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_tools_ContactSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_tools_CreateSlideShow = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_tools_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_tools_AdjustTime = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_tools_EyeDropper = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_tools_RedEyeCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_tools_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_tools_ScreenCapture = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_tools_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_tools_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_help_Documentation = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_help_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_help_CheckUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_help_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_help_Donation = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_help_VisitHome = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_help_Codeplex = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_help_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_help_ReadMe = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_help_04 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_help_About = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_FullScreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_elvw_View = new System.Windows.Forms.ToolStripMenuItem();
            this.ss_Main = new System.Windows.Forms.StatusStrip();
            this.tssl_Info = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_MousePosition = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_ImageDimensions = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsc_Main = new System.Windows.Forms.ToolStripContainer();
            this.sc_Explorer = new System.Windows.Forms.SplitContainer();
            this.cms_ExplorerTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_etvw_NewFavourite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_etvw_EditFavourite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_etvw_RemoveAllFavourites = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_etvw_RemoveFavourite = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_etvw_RefreshDevices = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_etvw_Tools = new System.Windows.Forms.ToolStrip();
            this.tsb_etvw_Close = new System.Windows.Forms.ToolStripButton();
            this.tsddb_etvw_Dock = new System.Windows.Forms.ToolStripDropDownButton();
            this.cms_Docking = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_dock_DockWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_dock_FloatingWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_dock_Hide = new System.Windows.Forms.ToolStripMenuItem();
            this.tsddb_task_Dock = new System.Windows.Forms.ToolStripDropDownButton();
            this.sc_Tasks = new System.Windows.Forms.SplitContainer();
            this.sc_ImageList = new System.Windows.Forms.SplitContainer();
            this.cms_ImageBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_imgbx_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_imgbx_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_imgbx_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_imgbx_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_imgbx_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_imgbx_AutoScale = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_imgbx_04 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_imgbx_SetBackGround = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_imgbx_CenterImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_imgbx_StretchImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_imgbx_TileImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_imgbx_05 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_imgbx_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_imgbx_Tools = new System.Windows.Forms.ToolStrip();
            this.tlp_ImageBoxTools = new System.Windows.Forms.TableLayoutPanel();
            this.lbl_ImageIndexDisplay = new System.Windows.Forms.Label();
            this.cms_ExplorerListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_elvw_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_elvw_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_elvw_Rename = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_elvw_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_elvw_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_elvw_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tss_elvw_04 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_elvw_CopyPath = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_elvw_OpenContainingFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.imgl_SmallImageList = new System.Windows.Forms.ImageList(this.components);
            this.ts_elvw_Tools = new System.Windows.Forms.ToolStrip();
            this.tsb_elvw_Close = new System.Windows.Forms.ToolStripButton();
            this.tsddb_elvw_Dock = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsl_elvw_ItemInfo = new System.Windows.Forms.ToolStripLabel();
            this.pan_TasksContainer = new System.Windows.Forms.Panel();
            this.ts_task_Tools = new System.Windows.Forms.ToolStrip();
            this.tsb_task_Close = new System.Windows.Forms.ToolStripButton();
            this.tsddb_task_Tasks = new System.Windows.Forms.ToolStripDropDownButton();
            this.cms_Tasks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi_task_Crop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_task_Resize = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_task_Shear = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_task_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_task_RedEyeCorrection = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_task_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_task_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.tsb_tb_TasksWindow = new System.Windows.Forms.ToolStripSplitButton();
            this.ts_Toolbar = new System.Windows.Forms.ToolStrip();
            this.tsb_tb_Open = new System.Windows.Forms.ToolStripButton();
            this.tsb_tb_AddFavourite = new System.Windows.Forms.ToolStripButton();
            this.tss_tb_01 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_tb_Save = new System.Windows.Forms.ToolStripButton();
            this.tsb_tb_02 = new System.Windows.Forms.ToolStripSeparator();
            this.tssb_tb_Print = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmi_tb_PageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_tb_PrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_tb_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.tss_tb_03 = new System.Windows.Forms.ToolStripSeparator();
            this.tscbx_tb_Zoom = new System.Windows.Forms.ToolStripComboBox();
            this.tss_tb_04 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_tb_RotateLeft90 = new System.Windows.Forms.ToolStripButton();
            this.tsb_tb_RotateRight90 = new System.Windows.Forms.ToolStripButton();
            this.tss_tb_05 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_tb_SlideShow = new System.Windows.Forms.ToolStripButton();
            this.tss_tb_06 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_tb_EyeDropper = new System.Windows.Forms.ToolStripButton();
            this.tsl_tb_PixelInfo = new System.Windows.Forms.ToolStripLabel();
            this.tss_tb_07 = new System.Windows.Forms.ToolStripSeparator();
            this.tsb_tb_ExplorerWindow = new System.Windows.Forms.ToolStripButton();
            this.tsb_tb_ImageListWindow = new System.Windows.Forms.ToolStripButton();
            this.etvw_Directorys = new IView.Controls.Library.ExplorerTreeView();
            this.imgbx_MainImage = new IView.Controls.Library.ImageBox();
            this.tsddb_imgbx_Directorys = new IView.Controls.Library.ToolStripDirectoryButton();
            this.btn_nav_FirstImage = new IView.Controls.Library.AquaButton();
            this.btn_nav_PreviousImage = new IView.Controls.Library.AquaButton();
            this.btn_nav_NextImage = new IView.Controls.Library.AquaButton();
            this.btn_nav_LastImage = new IView.Controls.Library.AquaButton();
            this.elvw_Images = new IView.Controls.Library.ExplorerListView();
            this.ch_FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_Date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_FileType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsddb_tb_AddRemove = new IView.Controls.Library.ToolStripAddRemoveButton();
            this.ms_Main.SuspendLayout();
            this.cms_ImageListView.SuspendLayout();
            this.ss_Main.SuspendLayout();
            this.tsc_Main.ContentPanel.SuspendLayout();
            this.tsc_Main.TopToolStripPanel.SuspendLayout();
            this.tsc_Main.SuspendLayout();
            this.sc_Explorer.Panel1.SuspendLayout();
            this.sc_Explorer.Panel2.SuspendLayout();
            this.sc_Explorer.SuspendLayout();
            this.cms_ExplorerTreeView.SuspendLayout();
            this.ts_etvw_Tools.SuspendLayout();
            this.cms_Docking.SuspendLayout();
            this.sc_Tasks.Panel1.SuspendLayout();
            this.sc_Tasks.Panel2.SuspendLayout();
            this.sc_Tasks.SuspendLayout();
            this.sc_ImageList.Panel1.SuspendLayout();
            this.sc_ImageList.Panel2.SuspendLayout();
            this.sc_ImageList.SuspendLayout();
            this.cms_ImageBox.SuspendLayout();
            this.ts_imgbx_Tools.SuspendLayout();
            this.tlp_ImageBoxTools.SuspendLayout();
            this.cms_ExplorerListView.SuspendLayout();
            this.ts_elvw_Tools.SuspendLayout();
            this.ts_task_Tools.SuspendLayout();
            this.cms_Tasks.SuspendLayout();
            this.ts_Toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ms_Main
            // 
            this.ms_Main.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ms_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_File,
            this.tsmi_Edit,
            this.tsmi_View,
            this.tsmi_Filters,
            this.tsmi_Tools,
            this.tsmi_Help,
            this.tsmi_Exit,
            this.tsmi_FullScreen});
            this.ms_Main.Location = new System.Drawing.Point(0, 0);
            this.ms_Main.Name = "ms_Main";
            this.ms_Main.ShowItemToolTips = true;
            this.ms_Main.Size = new System.Drawing.Size(634, 24);
            this.ms_Main.TabIndex = 0;
            this.ms_Main.Text = "menuStrip1";
            // 
            // tsmi_File
            // 
            this.tsmi_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_file_Open,
            this.tss_file_01,
            this.tsmi_file_Favourite,
            this.tss_file_02,
            this.tsmi_file_Save,
            this.tsmi_file_SaveAs,
            this.tss_file_03,
            this.tsmi_file_PageSetup,
            this.tsmi_file_PrintPreview,
            this.tsmi_file_Print,
            this.tss_file_04,
            this.tsmi_file_Properties,
            this.tss_file_05,
            this.tsmi_file_Exit});
            this.tsmi_File.Name = "tsmi_File";
            this.tsmi_File.Size = new System.Drawing.Size(35, 20);
            this.tsmi_File.Text = "&File";
            this.tsmi_File.DropDownClosed += new System.EventHandler(this.ms_tsmi_DropDownClosed);
            this.tsmi_File.DropDownOpening += new System.EventHandler(this.tsmi_File_DropDownOpening);
            // 
            // tsmi_file_Open
            // 
            this.tsmi_file_Open.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_file_OpenImageFile,
            this.tsmi_file_OpenSlideShowFile});
            this.tsmi_file_Open.Name = "tsmi_file_Open";
            this.tsmi_file_Open.Size = new System.Drawing.Size(149, 22);
            this.tsmi_file_Open.Text = "&Open";
            // 
            // tsmi_file_OpenImageFile
            // 
            this.tsmi_file_OpenImageFile.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_file_OpenImageFile.Image")));
            this.tsmi_file_OpenImageFile.Name = "tsmi_file_OpenImageFile";
            this.tsmi_file_OpenImageFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.tsmi_file_OpenImageFile.Size = new System.Drawing.Size(226, 22);
            this.tsmi_file_OpenImageFile.Text = "&Image File...";
            this.tsmi_file_OpenImageFile.Click += new System.EventHandler(this.tsmi_file_OpenImageFile_Click);
            // 
            // tsmi_file_OpenSlideShowFile
            // 
            this.tsmi_file_OpenSlideShowFile.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_file_OpenSlideShowFile.Image")));
            this.tsmi_file_OpenSlideShowFile.Name = "tsmi_file_OpenSlideShowFile";
            this.tsmi_file_OpenSlideShowFile.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.tsmi_file_OpenSlideShowFile.Size = new System.Drawing.Size(226, 22);
            this.tsmi_file_OpenSlideShowFile.Text = "Slide Show File...";
            this.tsmi_file_OpenSlideShowFile.Click += new System.EventHandler(this.tsmi_file_OpenSlideShowFile_Click);
            // 
            // tss_file_01
            // 
            this.tss_file_01.Name = "tss_file_01";
            this.tss_file_01.Size = new System.Drawing.Size(146, 6);
            // 
            // tsmi_file_Favourite
            // 
            this.tsmi_file_Favourite.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_file_NewFavourite,
            this.tsmi_file_AddFavourite});
            this.tsmi_file_Favourite.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_file_Favourite.Image")));
            this.tsmi_file_Favourite.Name = "tsmi_file_Favourite";
            this.tsmi_file_Favourite.Size = new System.Drawing.Size(149, 22);
            this.tsmi_file_Favourite.Text = "&Favourites";
            // 
            // tsmi_file_NewFavourite
            // 
            this.tsmi_file_NewFavourite.Name = "tsmi_file_NewFavourite";
            this.tsmi_file_NewFavourite.Size = new System.Drawing.Size(176, 22);
            this.tsmi_file_NewFavourite.Text = "&New Favourite...";
            this.tsmi_file_NewFavourite.Click += new System.EventHandler(this.tsmi_file_NewFavourite_Click);
            // 
            // tsmi_file_AddFavourite
            // 
            this.tsmi_file_AddFavourite.Name = "tsmi_file_AddFavourite";
            this.tsmi_file_AddFavourite.Size = new System.Drawing.Size(176, 22);
            this.tsmi_file_AddFavourite.Text = "Add Current &Location";
            this.tsmi_file_AddFavourite.Click += new System.EventHandler(this.tsmi_file_AddFavourite_Click);
            // 
            // tss_file_02
            // 
            this.tss_file_02.Name = "tss_file_02";
            this.tss_file_02.Size = new System.Drawing.Size(146, 6);
            // 
            // tsmi_file_Save
            // 
            this.tsmi_file_Save.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_file_Save.Image")));
            this.tsmi_file_Save.Name = "tsmi_file_Save";
            this.tsmi_file_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.tsmi_file_Save.Size = new System.Drawing.Size(149, 22);
            this.tsmi_file_Save.Text = "&Save";
            this.tsmi_file_Save.Click += new System.EventHandler(this.tsmi_file_Save_Click);
            // 
            // tsmi_file_SaveAs
            // 
            this.tsmi_file_SaveAs.Name = "tsmi_file_SaveAs";
            this.tsmi_file_SaveAs.Size = new System.Drawing.Size(149, 22);
            this.tsmi_file_SaveAs.Text = "Save &As...";
            this.tsmi_file_SaveAs.Click += new System.EventHandler(this.tsmi_file_SaveAs_Click);
            // 
            // tss_file_03
            // 
            this.tss_file_03.Name = "tss_file_03";
            this.tss_file_03.Size = new System.Drawing.Size(146, 6);
            // 
            // tsmi_file_PageSetup
            // 
            this.tsmi_file_PageSetup.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_file_PageSetup.Image")));
            this.tsmi_file_PageSetup.Name = "tsmi_file_PageSetup";
            this.tsmi_file_PageSetup.Size = new System.Drawing.Size(149, 22);
            this.tsmi_file_PageSetup.Text = "Page Set&up...";
            this.tsmi_file_PageSetup.Click += new System.EventHandler(this.tsmi_file_PageSetup_Click);
            // 
            // tsmi_file_PrintPreview
            // 
            this.tsmi_file_PrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_file_PrintPreview.Image")));
            this.tsmi_file_PrintPreview.Name = "tsmi_file_PrintPreview";
            this.tsmi_file_PrintPreview.Size = new System.Drawing.Size(149, 22);
            this.tsmi_file_PrintPreview.Text = "Print Pre&view...";
            this.tsmi_file_PrintPreview.Click += new System.EventHandler(this.tsmi_file_PrintPreview_Click);
            // 
            // tsmi_file_Print
            // 
            this.tsmi_file_Print.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_file_Print.Image")));
            this.tsmi_file_Print.Name = "tsmi_file_Print";
            this.tsmi_file_Print.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.tsmi_file_Print.Size = new System.Drawing.Size(149, 22);
            this.tsmi_file_Print.Text = "&Print...";
            this.tsmi_file_Print.Click += new System.EventHandler(this.tsmi_file_Print_Click);
            // 
            // tss_file_04
            // 
            this.tss_file_04.Name = "tss_file_04";
            this.tss_file_04.Size = new System.Drawing.Size(146, 6);
            // 
            // tsmi_file_Properties
            // 
            this.tsmi_file_Properties.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_file_Properties.Image")));
            this.tsmi_file_Properties.Name = "tsmi_file_Properties";
            this.tsmi_file_Properties.Size = new System.Drawing.Size(149, 22);
            this.tsmi_file_Properties.Text = "P&roperties";
            this.tsmi_file_Properties.Click += new System.EventHandler(this.tsmi_file_Properties_Click);
            // 
            // tss_file_05
            // 
            this.tss_file_05.Name = "tss_file_05";
            this.tss_file_05.Size = new System.Drawing.Size(146, 6);
            // 
            // tsmi_file_Exit
            // 
            this.tsmi_file_Exit.Name = "tsmi_file_Exit";
            this.tsmi_file_Exit.ShortcutKeyDisplayString = "Alt+F4";
            this.tsmi_file_Exit.Size = new System.Drawing.Size(149, 22);
            this.tsmi_file_Exit.Text = "E&xit";
            this.tsmi_file_Exit.Click += new System.EventHandler(this.tsmi_file_Exit_Click);
            // 
            // tsmi_Edit
            // 
            this.tsmi_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_edit_Undo,
            this.tsmi_edit_Redo,
            this.tsmi_edit_ClearChanges,
            this.tss_edit_01,
            this.tsmi_edit_Copy,
            this.tsmi_edit_Paste,
            this.tsmi_edit_Delete,
            this.tsmi_edit_Rename,
            this.tss_edit_02,
            this.tsmi_edit_SelectAll,
            this.tss_edit_03,
            this.tsmi_edit_FreeTransform,
            this.tsmi_edit_Transform});
            this.tsmi_Edit.Name = "tsmi_Edit";
            this.tsmi_Edit.Size = new System.Drawing.Size(37, 20);
            this.tsmi_Edit.Text = "&Edit";
            this.tsmi_Edit.DropDownClosed += new System.EventHandler(this.ms_tsmi_DropDownClosed);
            this.tsmi_Edit.DropDownOpening += new System.EventHandler(this.tsmi_Edit_DropDownOpening);
            // 
            // tsmi_edit_Undo
            // 
            this.tsmi_edit_Undo.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_edit_Undo.Image")));
            this.tsmi_edit_Undo.Name = "tsmi_edit_Undo";
            this.tsmi_edit_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.tsmi_edit_Undo.Size = new System.Drawing.Size(156, 22);
            this.tsmi_edit_Undo.Text = "&Undo";
            this.tsmi_edit_Undo.Click += new System.EventHandler(this.tsmi_edit_Undo_Click);
            // 
            // tsmi_edit_Redo
            // 
            this.tsmi_edit_Redo.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_edit_Redo.Image")));
            this.tsmi_edit_Redo.Name = "tsmi_edit_Redo";
            this.tsmi_edit_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.tsmi_edit_Redo.Size = new System.Drawing.Size(156, 22);
            this.tsmi_edit_Redo.Text = "&Redo";
            this.tsmi_edit_Redo.Click += new System.EventHandler(this.tsmi_edit_Redo_Click);
            // 
            // tsmi_edit_ClearChanges
            // 
            this.tsmi_edit_ClearChanges.Name = "tsmi_edit_ClearChanges";
            this.tsmi_edit_ClearChanges.Size = new System.Drawing.Size(156, 22);
            this.tsmi_edit_ClearChanges.Text = "Clear C&hanges";
            this.tsmi_edit_ClearChanges.Click += new System.EventHandler(this.tsmi_edit_ClearChanges_Click);
            // 
            // tss_edit_01
            // 
            this.tss_edit_01.Name = "tss_edit_01";
            this.tss_edit_01.Size = new System.Drawing.Size(153, 6);
            // 
            // tsmi_edit_Copy
            // 
            this.tsmi_edit_Copy.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_edit_Copy.Image")));
            this.tsmi_edit_Copy.Name = "tsmi_edit_Copy";
            this.tsmi_edit_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmi_edit_Copy.Size = new System.Drawing.Size(156, 22);
            this.tsmi_edit_Copy.Text = "&Copy";
            this.tsmi_edit_Copy.Click += new System.EventHandler(this.tsmi_edit_Copy_Click);
            // 
            // tsmi_edit_Paste
            // 
            this.tsmi_edit_Paste.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_edit_Paste.Image")));
            this.tsmi_edit_Paste.Name = "tsmi_edit_Paste";
            this.tsmi_edit_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.tsmi_edit_Paste.Size = new System.Drawing.Size(156, 22);
            this.tsmi_edit_Paste.Text = "&Paste";
            this.tsmi_edit_Paste.Click += new System.EventHandler(this.tsmi_edit_Paste_Click);
            // 
            // tsmi_edit_Delete
            // 
            this.tsmi_edit_Delete.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_edit_Delete.Image")));
            this.tsmi_edit_Delete.Name = "tsmi_edit_Delete";
            this.tsmi_edit_Delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.tsmi_edit_Delete.Size = new System.Drawing.Size(156, 22);
            this.tsmi_edit_Delete.Text = "&Delete";
            this.tsmi_edit_Delete.Click += new System.EventHandler(this.tsmi_edit_Delete_Click);
            // 
            // tsmi_edit_Rename
            // 
            this.tsmi_edit_Rename.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_edit_Rename.Image")));
            this.tsmi_edit_Rename.Name = "tsmi_edit_Rename";
            this.tsmi_edit_Rename.Size = new System.Drawing.Size(156, 22);
            this.tsmi_edit_Rename.Text = "Re&name...";
            this.tsmi_edit_Rename.Click += new System.EventHandler(this.tsmi_edit_Rename_Click);
            // 
            // tss_edit_02
            // 
            this.tss_edit_02.Name = "tss_edit_02";
            this.tss_edit_02.Size = new System.Drawing.Size(153, 6);
            // 
            // tsmi_edit_SelectAll
            // 
            this.tsmi_edit_SelectAll.Name = "tsmi_edit_SelectAll";
            this.tsmi_edit_SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tsmi_edit_SelectAll.Size = new System.Drawing.Size(156, 22);
            this.tsmi_edit_SelectAll.Text = "Select &All";
            this.tsmi_edit_SelectAll.Click += new System.EventHandler(this.tsmi_edit_SelectAll_Click);
            // 
            // tss_edit_03
            // 
            this.tss_edit_03.Name = "tss_edit_03";
            this.tss_edit_03.Size = new System.Drawing.Size(153, 6);
            // 
            // tsmi_edit_FreeTransform
            // 
            this.tsmi_edit_FreeTransform.Name = "tsmi_edit_FreeTransform";
            this.tsmi_edit_FreeTransform.Size = new System.Drawing.Size(156, 22);
            this.tsmi_edit_FreeTransform.Text = "Free Transform";
            this.tsmi_edit_FreeTransform.Click += new System.EventHandler(this.tsmi_edit_FreeTransform_Click);
            // 
            // tsmi_edit_Transform
            // 
            this.tsmi_edit_Transform.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_edit_Resize,
            this.tsmi_edit_Shear,
            this.tss_edit_04,
            this.tsmi_edit_Rotate90Clockwise,
            this.tsmi_edit_Rotate90CounterClockwise,
            this.tsmi_edit_Rotate180,
            this.tss_edit_05,
            this.tsmi_edit_FlipHorizontal,
            this.tsmi_edit_FlipVertical});
            this.tsmi_edit_Transform.Name = "tsmi_edit_Transform";
            this.tsmi_edit_Transform.Size = new System.Drawing.Size(156, 22);
            this.tsmi_edit_Transform.Text = "Transform";
            // 
            // tsmi_edit_Resize
            // 
            this.tsmi_edit_Resize.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_edit_Resize.Image")));
            this.tsmi_edit_Resize.Name = "tsmi_edit_Resize";
            this.tsmi_edit_Resize.Size = new System.Drawing.Size(190, 22);
            this.tsmi_edit_Resize.Text = "Resize";
            this.tsmi_edit_Resize.Click += new System.EventHandler(this.tsmi_edit_Resize_Click);
            // 
            // tsmi_edit_Shear
            // 
            this.tsmi_edit_Shear.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_edit_Shear.Image")));
            this.tsmi_edit_Shear.Name = "tsmi_edit_Shear";
            this.tsmi_edit_Shear.Size = new System.Drawing.Size(190, 22);
            this.tsmi_edit_Shear.Text = "Shear";
            this.tsmi_edit_Shear.Click += new System.EventHandler(this.tsmi_edit_Shear_Click);
            // 
            // tss_edit_04
            // 
            this.tss_edit_04.Name = "tss_edit_04";
            this.tss_edit_04.Size = new System.Drawing.Size(187, 6);
            // 
            // tsmi_edit_Rotate90Clockwise
            // 
            this.tsmi_edit_Rotate90Clockwise.Name = "tsmi_edit_Rotate90Clockwise";
            this.tsmi_edit_Rotate90Clockwise.ShortcutKeyDisplayString = "Ctrl+.";
            this.tsmi_edit_Rotate90Clockwise.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemPeriod)));
            this.tsmi_edit_Rotate90Clockwise.Size = new System.Drawing.Size(190, 22);
            this.tsmi_edit_Rotate90Clockwise.Text = "Rotate 90º CW";
            this.tsmi_edit_Rotate90Clockwise.Click += new System.EventHandler(this.tsmi_edit_Rotate90Clockwise_Click);
            // 
            // tsmi_edit_Rotate90CounterClockwise
            // 
            this.tsmi_edit_Rotate90CounterClockwise.Name = "tsmi_edit_Rotate90CounterClockwise";
            this.tsmi_edit_Rotate90CounterClockwise.ShortcutKeyDisplayString = "Ctrl+,";
            this.tsmi_edit_Rotate90CounterClockwise.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Oemcomma)));
            this.tsmi_edit_Rotate90CounterClockwise.Size = new System.Drawing.Size(190, 22);
            this.tsmi_edit_Rotate90CounterClockwise.Text = "Rotate 90º CCW";
            this.tsmi_edit_Rotate90CounterClockwise.Click += new System.EventHandler(this.tsmi_edit_Rotate90CounterClockwise_Click);
            // 
            // tsmi_edit_Rotate180
            // 
            this.tsmi_edit_Rotate180.Name = "tsmi_edit_Rotate180";
            this.tsmi_edit_Rotate180.Size = new System.Drawing.Size(190, 22);
            this.tsmi_edit_Rotate180.Text = "Rotate 180º";
            this.tsmi_edit_Rotate180.Click += new System.EventHandler(this.tsmi_edit_Rotate180_Click);
            // 
            // tss_edit_05
            // 
            this.tss_edit_05.Name = "tss_edit_05";
            this.tss_edit_05.Size = new System.Drawing.Size(187, 6);
            // 
            // tsmi_edit_FlipHorizontal
            // 
            this.tsmi_edit_FlipHorizontal.Name = "tsmi_edit_FlipHorizontal";
            this.tsmi_edit_FlipHorizontal.Size = new System.Drawing.Size(190, 22);
            this.tsmi_edit_FlipHorizontal.Text = "Flip Horizontal";
            this.tsmi_edit_FlipHorizontal.Click += new System.EventHandler(this.tsmi_edit_FlipHorizontal_Click);
            // 
            // tsmi_edit_FlipVertical
            // 
            this.tsmi_edit_FlipVertical.Name = "tsmi_edit_FlipVertical";
            this.tsmi_edit_FlipVertical.Size = new System.Drawing.Size(190, 22);
            this.tsmi_edit_FlipVertical.Text = "Flip Vertical";
            this.tsmi_edit_FlipVertical.Click += new System.EventHandler(this.tsmi_edit_FlipVertical_Click);
            // 
            // tsmi_View
            // 
            this.tsmi_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_view_Windows,
            this.tss_view_01,
            this.tsmi_view_SlideShow,
            this.tss_view_02,
            this.tsmi_view_Explorer,
            this.tsmi_view_ImageList,
            this.tsmi_view_Task,
            this.tss_view_03,
            this.tsmi_view_ImageListView,
            this.tss_view_04,
            this.tsmi_view_Toolbar,
            this.tsmi_view_StatusBar,
            this.tsmi_view_FullScreen,
            this.tss_view_05,
            this.tsmi_view_Refresh});
            this.tsmi_View.Name = "tsmi_View";
            this.tsmi_View.Size = new System.Drawing.Size(41, 20);
            this.tsmi_View.Text = "&View";
            this.tsmi_View.DropDownClosed += new System.EventHandler(this.ms_tsmi_DropDownClosed);
            this.tsmi_View.DropDownOpening += new System.EventHandler(this.tsmi_View_DropDownOpening);
            // 
            // tsmi_view_Windows
            // 
            this.tsmi_view_Windows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_win_OpenNew,
            this.tsmi_win_CloseAll,
            this.tss_win_01});
            this.tsmi_view_Windows.Name = "tsmi_view_Windows";
            this.tsmi_view_Windows.Size = new System.Drawing.Size(171, 22);
            this.tsmi_view_Windows.Text = "&Windows";
            this.tsmi_view_Windows.DropDownClosed += new System.EventHandler(this.ms_tsmi_DropDownClosed);
            // 
            // tsmi_win_OpenNew
            // 
            this.tsmi_win_OpenNew.Name = "tsmi_win_OpenNew";
            this.tsmi_win_OpenNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmi_win_OpenNew.Size = new System.Drawing.Size(204, 22);
            this.tsmi_win_OpenNew.Text = "Open &New Window";
            this.tsmi_win_OpenNew.Click += new System.EventHandler(this.tsmi_win_OpenNew_Click);
            // 
            // tsmi_win_CloseAll
            // 
            this.tsmi_win_CloseAll.Name = "tsmi_win_CloseAll";
            this.tsmi_win_CloseAll.Size = new System.Drawing.Size(204, 22);
            this.tsmi_win_CloseAll.Text = "Close &All";
            this.tsmi_win_CloseAll.Click += new System.EventHandler(this.tsmi_win_CloseAll_Click);
            // 
            // tss_win_01
            // 
            this.tss_win_01.Name = "tss_win_01";
            this.tss_win_01.Size = new System.Drawing.Size(201, 6);
            // 
            // tss_view_01
            // 
            this.tss_view_01.Name = "tss_view_01";
            this.tss_view_01.Size = new System.Drawing.Size(168, 6);
            // 
            // tsmi_view_SlideShow
            // 
            this.tsmi_view_SlideShow.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_view_SlideShow.Image")));
            this.tsmi_view_SlideShow.Name = "tsmi_view_SlideShow";
            this.tsmi_view_SlideShow.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.tsmi_view_SlideShow.Size = new System.Drawing.Size(171, 22);
            this.tsmi_view_SlideShow.Text = "Play Slide Show";
            this.tsmi_view_SlideShow.Click += new System.EventHandler(this.tsmi_view_SlideShow_Click);
            // 
            // tss_view_02
            // 
            this.tss_view_02.Name = "tss_view_02";
            this.tss_view_02.Size = new System.Drawing.Size(168, 6);
            // 
            // tsmi_view_Explorer
            // 
            this.tsmi_view_Explorer.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_view_Explorer.Image")));
            this.tsmi_view_Explorer.Name = "tsmi_view_Explorer";
            this.tsmi_view_Explorer.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.tsmi_view_Explorer.Size = new System.Drawing.Size(171, 22);
            this.tsmi_view_Explorer.Text = "&Explorer Panel";
            this.tsmi_view_Explorer.Click += new System.EventHandler(this.tsmi_view_Explorer_Click);
            // 
            // tsmi_view_ImageList
            // 
            this.tsmi_view_ImageList.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_view_ImageList.Image")));
            this.tsmi_view_ImageList.Name = "tsmi_view_ImageList";
            this.tsmi_view_ImageList.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.tsmi_view_ImageList.Size = new System.Drawing.Size(171, 22);
            this.tsmi_view_ImageList.Text = "&Image List Panel";
            this.tsmi_view_ImageList.Click += new System.EventHandler(this.tsmi_view_ImageList_Click);
            // 
            // tsmi_view_Task
            // 
            this.tsmi_view_Task.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_view_Task.Image")));
            this.tsmi_view_Task.Name = "tsmi_view_Task";
            this.tsmi_view_Task.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.tsmi_view_Task.Size = new System.Drawing.Size(171, 22);
            this.tsmi_view_Task.Text = "&Tasks Panel";
            this.tsmi_view_Task.Click += new System.EventHandler(this.tsmi_view_Task_Click);
            // 
            // tss_view_03
            // 
            this.tss_view_03.Name = "tss_view_03";
            this.tss_view_03.Size = new System.Drawing.Size(168, 6);
            // 
            // tsmi_view_ImageListView
            // 
            this.tsmi_view_ImageListView.DropDown = this.cms_ImageListView;
            this.tsmi_view_ImageListView.Name = "tsmi_view_ImageListView";
            this.tsmi_view_ImageListView.Size = new System.Drawing.Size(171, 22);
            this.tsmi_view_ImageListView.Text = "Image &List View";
            // 
            // cms_ImageListView
            // 
            this.cms_ImageListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_ImageListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_ilvw_LargeIcons,
            this.tsmi_ilvw_MediumIcons,
            this.tsmi_ilvw_SmallIcons,
            this.tsmi_ilvw_List,
            this.tsmi_ilvw_Details});
            this.cms_ImageListView.Name = "cms_ImageListView";
            this.cms_ImageListView.OwnerItem = this.tsmi_elvw_View;
            this.cms_ImageListView.Size = new System.Drawing.Size(140, 114);
            this.cms_ImageListView.Opening += new System.ComponentModel.CancelEventHandler(this.cms_ImageListView_Opening);
            // 
            // tsmi_ilvw_LargeIcons
            // 
            this.tsmi_ilvw_LargeIcons.Name = "tsmi_ilvw_LargeIcons";
            this.tsmi_ilvw_LargeIcons.Size = new System.Drawing.Size(139, 22);
            this.tsmi_ilvw_LargeIcons.Text = "Large Icons";
            this.tsmi_ilvw_LargeIcons.Click += new System.EventHandler(this.tsmi_ilvw_LargeIcons_Click);
            // 
            // tsmi_ilvw_MediumIcons
            // 
            this.tsmi_ilvw_MediumIcons.Name = "tsmi_ilvw_MediumIcons";
            this.tsmi_ilvw_MediumIcons.Size = new System.Drawing.Size(139, 22);
            this.tsmi_ilvw_MediumIcons.Text = "Medium Icons";
            this.tsmi_ilvw_MediumIcons.Click += new System.EventHandler(this.tsmi_ilvw_MediumIcons_Click);
            // 
            // tsmi_ilvw_SmallIcons
            // 
            this.tsmi_ilvw_SmallIcons.Name = "tsmi_ilvw_SmallIcons";
            this.tsmi_ilvw_SmallIcons.Size = new System.Drawing.Size(139, 22);
            this.tsmi_ilvw_SmallIcons.Text = "Small Icons";
            this.tsmi_ilvw_SmallIcons.Click += new System.EventHandler(this.tsmi_ilvw_SmallIcons_Click);
            // 
            // tsmi_ilvw_List
            // 
            this.tsmi_ilvw_List.Name = "tsmi_ilvw_List";
            this.tsmi_ilvw_List.Size = new System.Drawing.Size(139, 22);
            this.tsmi_ilvw_List.Text = "List";
            this.tsmi_ilvw_List.Click += new System.EventHandler(this.tsmi_ilvw_List_Click);
            // 
            // tsmi_ilvw_Details
            // 
            this.tsmi_ilvw_Details.Name = "tsmi_ilvw_Details";
            this.tsmi_ilvw_Details.Size = new System.Drawing.Size(139, 22);
            this.tsmi_ilvw_Details.Text = "Details";
            this.tsmi_ilvw_Details.Click += new System.EventHandler(this.tsmi_ilvw_Details_Click);
            // 
            // tss_view_04
            // 
            this.tss_view_04.Name = "tss_view_04";
            this.tss_view_04.Size = new System.Drawing.Size(168, 6);
            // 
            // tsmi_view_Toolbar
            // 
            this.tsmi_view_Toolbar.Name = "tsmi_view_Toolbar";
            this.tsmi_view_Toolbar.Size = new System.Drawing.Size(171, 22);
            this.tsmi_view_Toolbar.Text = "T&oolbar";
            this.tsmi_view_Toolbar.Click += new System.EventHandler(this.tsmi_view_Toolbar_Click);
            // 
            // tsmi_view_StatusBar
            // 
            this.tsmi_view_StatusBar.Name = "tsmi_view_StatusBar";
            this.tsmi_view_StatusBar.Size = new System.Drawing.Size(171, 22);
            this.tsmi_view_StatusBar.Text = "Status &Bar";
            this.tsmi_view_StatusBar.Click += new System.EventHandler(this.tsmi_view_StatusBar_Click);
            // 
            // tsmi_view_FullScreen
            // 
            this.tsmi_view_FullScreen.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_view_FullScreen.Image")));
            this.tsmi_view_FullScreen.Name = "tsmi_view_FullScreen";
            this.tsmi_view_FullScreen.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.tsmi_view_FullScreen.Size = new System.Drawing.Size(171, 22);
            this.tsmi_view_FullScreen.Text = "Full &Screen";
            this.tsmi_view_FullScreen.Click += new System.EventHandler(this.tsmi_view_FullScreen_Click);
            // 
            // tss_view_05
            // 
            this.tss_view_05.Name = "tss_view_05";
            this.tss_view_05.Size = new System.Drawing.Size(168, 6);
            // 
            // tsmi_view_Refresh
            // 
            this.tsmi_view_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_view_Refresh.Image")));
            this.tsmi_view_Refresh.Name = "tsmi_view_Refresh";
            this.tsmi_view_Refresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmi_view_Refresh.Size = new System.Drawing.Size(171, 22);
            this.tsmi_view_Refresh.Text = "&Refresh";
            this.tsmi_view_Refresh.Click += new System.EventHandler(this.tsmi_view_Refresh_Click);
            // 
            // tsmi_Filters
            // 
            this.tsmi_Filters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_filter_GreyScale,
            this.tsmi_filter_Invert,
            this.tsmi_filter_PhotoCopy,
            this.tsmi_filter_RotateColour,
            this.tss_filter_01,
            this.tsmi_filter_BrightnessContrast,
            this.tsmi_filter_ColourBalance,
            this.tsmi_filter_Gamma,
            this.tsmi_filter_Noise,
            this.tsmi_filter_Transparency});
            this.tsmi_Filters.Name = "tsmi_Filters";
            this.tsmi_Filters.Size = new System.Drawing.Size(48, 20);
            this.tsmi_Filters.Text = "F&ilters";
            this.tsmi_Filters.DropDownClosed += new System.EventHandler(this.ms_tsmi_DropDownClosed);
            this.tsmi_Filters.DropDownOpening += new System.EventHandler(this.tsmi_Filters_DropDownOpening);
            // 
            // tsmi_filter_GreyScale
            // 
            this.tsmi_filter_GreyScale.Name = "tsmi_filter_GreyScale";
            this.tsmi_filter_GreyScale.Size = new System.Drawing.Size(182, 22);
            this.tsmi_filter_GreyScale.Text = "Grey Scale";
            this.tsmi_filter_GreyScale.Click += new System.EventHandler(this.tsmi_filter_GreyScale_Click);
            // 
            // tsmi_filter_Invert
            // 
            this.tsmi_filter_Invert.Name = "tsmi_filter_Invert";
            this.tsmi_filter_Invert.Size = new System.Drawing.Size(182, 22);
            this.tsmi_filter_Invert.Text = "Invert";
            this.tsmi_filter_Invert.Click += new System.EventHandler(this.tsmi_filter_Invert_Click);
            // 
            // tsmi_filter_PhotoCopy
            // 
            this.tsmi_filter_PhotoCopy.Name = "tsmi_filter_PhotoCopy";
            this.tsmi_filter_PhotoCopy.Size = new System.Drawing.Size(182, 22);
            this.tsmi_filter_PhotoCopy.Text = "Photo Copy";
            this.tsmi_filter_PhotoCopy.Click += new System.EventHandler(this.tsmi_filter_PhotoCopy_Click);
            // 
            // tsmi_filter_RotateColour
            // 
            this.tsmi_filter_RotateColour.Name = "tsmi_filter_RotateColour";
            this.tsmi_filter_RotateColour.Size = new System.Drawing.Size(182, 22);
            this.tsmi_filter_RotateColour.Text = "Rotate Colours";
            this.tsmi_filter_RotateColour.Click += new System.EventHandler(this.tsmi_filter_RotateColour_Click);
            // 
            // tss_filter_01
            // 
            this.tss_filter_01.Name = "tss_filter_01";
            this.tss_filter_01.Size = new System.Drawing.Size(179, 6);
            // 
            // tsmi_filter_BrightnessContrast
            // 
            this.tsmi_filter_BrightnessContrast.Name = "tsmi_filter_BrightnessContrast";
            this.tsmi_filter_BrightnessContrast.Size = new System.Drawing.Size(182, 22);
            this.tsmi_filter_BrightnessContrast.Text = "Brightness/Contrast...";
            this.tsmi_filter_BrightnessContrast.Click += new System.EventHandler(this.tsmi_filter_BrightnessContrast_Click);
            // 
            // tsmi_filter_ColourBalance
            // 
            this.tsmi_filter_ColourBalance.Name = "tsmi_filter_ColourBalance";
            this.tsmi_filter_ColourBalance.Size = new System.Drawing.Size(182, 22);
            this.tsmi_filter_ColourBalance.Text = "Colour Balance...";
            this.tsmi_filter_ColourBalance.Click += new System.EventHandler(this.tsmi_filter_ColourBalance_Click);
            // 
            // tsmi_filter_Gamma
            // 
            this.tsmi_filter_Gamma.Name = "tsmi_filter_Gamma";
            this.tsmi_filter_Gamma.Size = new System.Drawing.Size(182, 22);
            this.tsmi_filter_Gamma.Text = "Gamma Adjustment...";
            this.tsmi_filter_Gamma.Click += new System.EventHandler(this.tsmi_filter_Gamma_Click);
            // 
            // tsmi_filter_Noise
            // 
            this.tsmi_filter_Noise.Name = "tsmi_filter_Noise";
            this.tsmi_filter_Noise.Size = new System.Drawing.Size(182, 22);
            this.tsmi_filter_Noise.Text = "Noise...";
            this.tsmi_filter_Noise.Click += new System.EventHandler(this.tsmi_filter_Noise_Click);
            // 
            // tsmi_filter_Transparency
            // 
            this.tsmi_filter_Transparency.Name = "tsmi_filter_Transparency";
            this.tsmi_filter_Transparency.Size = new System.Drawing.Size(182, 22);
            this.tsmi_filter_Transparency.Text = "Transparency...";
            this.tsmi_filter_Transparency.Click += new System.EventHandler(this.tsmi_filter_Transparency_Click);
            // 
            // tsmi_Tools
            // 
            this.tsmi_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_tools_BatchEditor,
            this.tsmi_tools_ContactSheet,
            this.tsmi_tools_CreateSlideShow,
            this.tss_tools_01,
            this.tsmi_tools_AdjustTime,
            this.tsmi_tools_EyeDropper,
            this.tsmi_tools_RedEyeCorrection,
            this.tss_tools_02,
            this.tsmi_tools_ScreenCapture,
            this.tss_tools_03,
            this.tsmi_tools_Options});
            this.tsmi_Tools.Name = "tsmi_Tools";
            this.tsmi_Tools.Size = new System.Drawing.Size(44, 20);
            this.tsmi_Tools.Text = "&Tools";
            this.tsmi_Tools.DropDownClosed += new System.EventHandler(this.ms_tsmi_DropDownClosed);
            this.tsmi_Tools.DropDownOpening += new System.EventHandler(this.tsmi_Tools_DropDownOpening);
            // 
            // tsmi_tools_BatchEditor
            // 
            this.tsmi_tools_BatchEditor.Name = "tsmi_tools_BatchEditor";
            this.tsmi_tools_BatchEditor.Size = new System.Drawing.Size(191, 22);
            this.tsmi_tools_BatchEditor.Text = "Batch Editor...";
            this.tsmi_tools_BatchEditor.Visible = false;
            this.tsmi_tools_BatchEditor.Click += new System.EventHandler(this.tsmi_tools_BatchEditor_Click);
            // 
            // tsmi_tools_ContactSheet
            // 
            this.tsmi_tools_ContactSheet.Name = "tsmi_tools_ContactSheet";
            this.tsmi_tools_ContactSheet.Size = new System.Drawing.Size(191, 22);
            this.tsmi_tools_ContactSheet.Text = "Create Contact Sheet...";
            this.tsmi_tools_ContactSheet.Visible = false;
            this.tsmi_tools_ContactSheet.Click += new System.EventHandler(this.tsmi_tools_ContactSheet_Click);
            // 
            // tsmi_tools_CreateSlideShow
            // 
            this.tsmi_tools_CreateSlideShow.Name = "tsmi_tools_CreateSlideShow";
            this.tsmi_tools_CreateSlideShow.Size = new System.Drawing.Size(191, 22);
            this.tsmi_tools_CreateSlideShow.Text = "Create Slide Show...";
            this.tsmi_tools_CreateSlideShow.Click += new System.EventHandler(this.tsmi_tools_CreateSlideShow_Click);
            // 
            // tss_tools_01
            // 
            this.tss_tools_01.Name = "tss_tools_01";
            this.tss_tools_01.Size = new System.Drawing.Size(188, 6);
            // 
            // tsmi_tools_AdjustTime
            // 
            this.tsmi_tools_AdjustTime.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_tools_AdjustTime.Image")));
            this.tsmi_tools_AdjustTime.Name = "tsmi_tools_AdjustTime";
            this.tsmi_tools_AdjustTime.Size = new System.Drawing.Size(191, 22);
            this.tsmi_tools_AdjustTime.Text = "Adjust Time...";
            this.tsmi_tools_AdjustTime.Click += new System.EventHandler(this.tsmi_tools_AdjustTime_Click);
            // 
            // tsmi_tools_EyeDropper
            // 
            this.tsmi_tools_EyeDropper.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_tools_EyeDropper.Image")));
            this.tsmi_tools_EyeDropper.Name = "tsmi_tools_EyeDropper";
            this.tsmi_tools_EyeDropper.Size = new System.Drawing.Size(191, 22);
            this.tsmi_tools_EyeDropper.Text = "Eye Dropper";
            this.tsmi_tools_EyeDropper.Click += new System.EventHandler(this.tsmi_tools_EyeDropper_Click);
            // 
            // tsmi_tools_RedEyeCorrection
            // 
            this.tsmi_tools_RedEyeCorrection.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_tools_RedEyeCorrection.Image")));
            this.tsmi_tools_RedEyeCorrection.Name = "tsmi_tools_RedEyeCorrection";
            this.tsmi_tools_RedEyeCorrection.Size = new System.Drawing.Size(191, 22);
            this.tsmi_tools_RedEyeCorrection.Text = "Red Eye Correction";
            this.tsmi_tools_RedEyeCorrection.Click += new System.EventHandler(this.tsmi_tools_RedEyeCorrection_Click);
            // 
            // tss_tools_02
            // 
            this.tss_tools_02.Name = "tss_tools_02";
            this.tss_tools_02.Size = new System.Drawing.Size(188, 6);
            // 
            // tsmi_tools_ScreenCapture
            // 
            this.tsmi_tools_ScreenCapture.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_tools_ScreenCapture.Image")));
            this.tsmi_tools_ScreenCapture.Name = "tsmi_tools_ScreenCapture";
            this.tsmi_tools_ScreenCapture.Size = new System.Drawing.Size(191, 22);
            this.tsmi_tools_ScreenCapture.Text = "Screen Capture Tool";
            this.tsmi_tools_ScreenCapture.Click += new System.EventHandler(this.tsmi_tools_ScreenCapture_Click);
            // 
            // tss_tools_03
            // 
            this.tss_tools_03.Name = "tss_tools_03";
            this.tss_tools_03.Size = new System.Drawing.Size(188, 6);
            // 
            // tsmi_tools_Options
            // 
            this.tsmi_tools_Options.Name = "tsmi_tools_Options";
            this.tsmi_tools_Options.Size = new System.Drawing.Size(191, 22);
            this.tsmi_tools_Options.Text = "Options...";
            this.tsmi_tools_Options.Click += new System.EventHandler(this.tsmi_tools_Options_Click);
            // 
            // tsmi_Help
            // 
            this.tsmi_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_help_Documentation,
            this.tss_help_01,
            this.tsmi_help_CheckUpdates,
            this.tss_help_02,
            this.tsmi_help_Donation,
            this.tsmi_help_VisitHome,
            this.tsmi_help_Codeplex,
            this.tss_help_03,
            this.tsmi_help_ReadMe,
            this.tss_help_04,
            this.tsmi_help_About});
            this.tsmi_Help.Name = "tsmi_Help";
            this.tsmi_Help.Size = new System.Drawing.Size(40, 20);
            this.tsmi_Help.Text = "&Help";
            this.tsmi_Help.Visible = false;
            // 
            // tsmi_help_Documentation
            // 
            this.tsmi_help_Documentation.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_help_Documentation.Image")));
            this.tsmi_help_Documentation.Name = "tsmi_help_Documentation";
            this.tsmi_help_Documentation.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.tsmi_help_Documentation.Size = new System.Drawing.Size(206, 22);
            this.tsmi_help_Documentation.Text = "&Help";
            this.tsmi_help_Documentation.Click += new System.EventHandler(this.tsmi_help_Documentation_Click);
            // 
            // tss_help_01
            // 
            this.tss_help_01.Name = "tss_help_01";
            this.tss_help_01.Size = new System.Drawing.Size(203, 6);
            // 
            // tsmi_help_CheckUpdates
            // 
            this.tsmi_help_CheckUpdates.Name = "tsmi_help_CheckUpdates";
            this.tsmi_help_CheckUpdates.Size = new System.Drawing.Size(206, 22);
            this.tsmi_help_CheckUpdates.Text = "Check For &Updates";
            this.tsmi_help_CheckUpdates.Click += new System.EventHandler(this.tsmi_help_CheckUpdates_Click);
            // 
            // tss_help_02
            // 
            this.tss_help_02.Name = "tss_help_02";
            this.tss_help_02.Size = new System.Drawing.Size(203, 6);
            // 
            // tsmi_help_Donation
            // 
            this.tsmi_help_Donation.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_help_Donation.Image")));
            this.tsmi_help_Donation.Name = "tsmi_help_Donation";
            this.tsmi_help_Donation.Size = new System.Drawing.Size(206, 22);
            this.tsmi_help_Donation.Text = "Make a &Donation...";
            this.tsmi_help_Donation.Click += new System.EventHandler(this.tsmi_help_Donation_Click);
            // 
            // tsmi_help_VisitHome
            // 
            this.tsmi_help_VisitHome.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_help_VisitHome.Image")));
            this.tsmi_help_VisitHome.Name = "tsmi_help_VisitHome";
            this.tsmi_help_VisitHome.Size = new System.Drawing.Size(206, 22);
            this.tsmi_help_VisitHome.Text = "Visit iView.NET Home";
            this.tsmi_help_VisitHome.Click += new System.EventHandler(this.tsmi_help_VisitHome_Click);
            // 
            // tsmi_help_Codeplex
            // 
            this.tsmi_help_Codeplex.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_help_Codeplex.Image")));
            this.tsmi_help_Codeplex.Name = "tsmi_help_Codeplex";
            this.tsmi_help_Codeplex.Size = new System.Drawing.Size(206, 22);
            this.tsmi_help_Codeplex.Text = "Visit iView.NET on Codeplex";
            this.tsmi_help_Codeplex.Click += new System.EventHandler(this.tsmi_help_Codeplex_Click);
            // 
            // tss_help_03
            // 
            this.tss_help_03.Name = "tss_help_03";
            this.tss_help_03.Size = new System.Drawing.Size(203, 6);
            // 
            // tsmi_help_ReadMe
            // 
            this.tsmi_help_ReadMe.Name = "tsmi_help_ReadMe";
            this.tsmi_help_ReadMe.Size = new System.Drawing.Size(206, 22);
            this.tsmi_help_ReadMe.Text = "&Read Me...";
            this.tsmi_help_ReadMe.Click += new System.EventHandler(this.tsmi_help_ReadMe_Click);
            // 
            // tss_help_04
            // 
            this.tss_help_04.Name = "tss_help_04";
            this.tss_help_04.Size = new System.Drawing.Size(203, 6);
            // 
            // tsmi_help_About
            // 
            this.tsmi_help_About.Name = "tsmi_help_About";
            this.tsmi_help_About.Size = new System.Drawing.Size(206, 22);
            this.tsmi_help_About.Text = "&About iView.NET";
            this.tsmi_help_About.Click += new System.EventHandler(this.tsmi_help_About_Click);
            // 
            // tsmi_Exit
            // 
            this.tsmi_Exit.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmi_Exit.AutoSize = false;
            this.tsmi_Exit.AutoToolTip = true;
            this.tsmi_Exit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmi_Exit.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_Exit.Image")));
            this.tsmi_Exit.Name = "tsmi_Exit";
            this.tsmi_Exit.Size = new System.Drawing.Size(20, 20);
            this.tsmi_Exit.Text = "&Close";
            this.tsmi_Exit.Visible = false;
            this.tsmi_Exit.Click += new System.EventHandler(this.tsmi_Exit_Click);
            // 
            // tsmi_FullScreen
            // 
            this.tsmi_FullScreen.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsmi_FullScreen.AutoSize = false;
            this.tsmi_FullScreen.AutoToolTip = true;
            this.tsmi_FullScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsmi_FullScreen.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_FullScreen.Image")));
            this.tsmi_FullScreen.Name = "tsmi_FullScreen";
            this.tsmi_FullScreen.Size = new System.Drawing.Size(20, 20);
            this.tsmi_FullScreen.Text = "&Restore Down";
            this.tsmi_FullScreen.Visible = false;
            this.tsmi_FullScreen.Click += new System.EventHandler(this.tsmi_FullScreen_Click);
            // 
            // tsmi_elvw_View
            // 
            this.tsmi_elvw_View.DropDown = this.cms_ImageListView;
            this.tsmi_elvw_View.Name = "tsmi_elvw_View";
            this.tsmi_elvw_View.Size = new System.Drawing.Size(187, 22);
            this.tsmi_elvw_View.Text = "View";
            // 
            // ss_Main
            // 
            this.ss_Main.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ss_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Info,
            this.tssl_MousePosition,
            this.tssl_ImageDimensions});
            this.ss_Main.Location = new System.Drawing.Point(0, 301);
            this.ss_Main.Name = "ss_Main";
            this.ss_Main.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ss_Main.Size = new System.Drawing.Size(634, 22);
            this.ss_Main.TabIndex = 1;
            this.ss_Main.Text = "statusStrip1";
            // 
            // tssl_Info
            // 
            this.tssl_Info.AutoToolTip = true;
            this.tssl_Info.Name = "tssl_Info";
            this.tssl_Info.Size = new System.Drawing.Size(619, 17);
            this.tssl_Info.Spring = true;
            this.tssl_Info.Text = "Ready";
            this.tssl_Info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tssl_MousePosition
            // 
            this.tssl_MousePosition.Image = ((System.Drawing.Image)(resources.GetObject("tssl_MousePosition.Image")));
            this.tssl_MousePosition.Margin = new System.Windows.Forms.Padding(0, 3, 40, 2);
            this.tssl_MousePosition.Name = "tssl_MousePosition";
            this.tssl_MousePosition.Size = new System.Drawing.Size(42, 17);
            this.tssl_MousePosition.Text = "0, 0";
            this.tssl_MousePosition.Visible = false;
            // 
            // tssl_ImageDimensions
            // 
            this.tssl_ImageDimensions.Image = ((System.Drawing.Image)(resources.GetObject("tssl_ImageDimensions.Image")));
            this.tssl_ImageDimensions.Margin = new System.Windows.Forms.Padding(0, 3, 40, 2);
            this.tssl_ImageDimensions.Name = "tssl_ImageDimensions";
            this.tssl_ImageDimensions.Size = new System.Drawing.Size(47, 17);
            this.tssl_ImageDimensions.Text = "0 x 0";
            this.tssl_ImageDimensions.Visible = false;
            // 
            // tsc_Main
            // 
            // 
            // tsc_Main.ContentPanel
            // 
            this.tsc_Main.ContentPanel.Controls.Add(this.sc_Explorer);
            this.tsc_Main.ContentPanel.Padding = new System.Windows.Forms.Padding(2, 2, 2, 1);
            this.tsc_Main.ContentPanel.Size = new System.Drawing.Size(634, 252);
            this.tsc_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsc_Main.Location = new System.Drawing.Point(0, 24);
            this.tsc_Main.Name = "tsc_Main";
            this.tsc_Main.Size = new System.Drawing.Size(634, 277);
            this.tsc_Main.TabIndex = 2;
            this.tsc_Main.Text = "toolStripContainer1";
            // 
            // tsc_Main.TopToolStripPanel
            // 
            this.tsc_Main.TopToolStripPanel.Controls.Add(this.ts_Toolbar);
            // 
            // sc_Explorer
            // 
            this.sc_Explorer.BackColor = System.Drawing.Color.White;
            this.sc_Explorer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sc_Explorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_Explorer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.sc_Explorer.Location = new System.Drawing.Point(2, 2);
            this.sc_Explorer.Name = "sc_Explorer";
            // 
            // sc_Explorer.Panel1
            // 
            this.sc_Explorer.Panel1.BackColor = System.Drawing.Color.White;
            this.sc_Explorer.Panel1.Controls.Add(this.etvw_Directorys);
            this.sc_Explorer.Panel1.Controls.Add(this.ts_etvw_Tools);
            // 
            // sc_Explorer.Panel2
            // 
            this.sc_Explorer.Panel2.BackColor = System.Drawing.Color.White;
            this.sc_Explorer.Panel2.Controls.Add(this.sc_Tasks);
            this.sc_Explorer.Size = new System.Drawing.Size(630, 249);
            this.sc_Explorer.SplitterDistance = 184;
            this.sc_Explorer.TabIndex = 1;
            // 
            // cms_ExplorerTreeView
            // 
            this.cms_ExplorerTreeView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_ExplorerTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_etvw_NewFavourite,
            this.tsmi_etvw_EditFavourite,
            this.tsmi_etvw_RemoveAllFavourites,
            this.tsmi_etvw_RemoveFavourite,
            this.tsmi_etvw_RefreshDevices});
            this.cms_ExplorerTreeView.Name = "cms_ExplorerTreeView";
            this.cms_ExplorerTreeView.Size = new System.Drawing.Size(167, 114);
            this.cms_ExplorerTreeView.Opening += new System.ComponentModel.CancelEventHandler(this.cms_ExplorerTreeView_Opening);
            // 
            // tsmi_etvw_NewFavourite
            // 
            this.tsmi_etvw_NewFavourite.Name = "tsmi_etvw_NewFavourite";
            this.tsmi_etvw_NewFavourite.Size = new System.Drawing.Size(166, 22);
            this.tsmi_etvw_NewFavourite.Text = "New Favourite...";
            this.tsmi_etvw_NewFavourite.Click += new System.EventHandler(this.tsmi_etvw_NewFavourite_Click);
            // 
            // tsmi_etvw_EditFavourite
            // 
            this.tsmi_etvw_EditFavourite.Name = "tsmi_etvw_EditFavourite";
            this.tsmi_etvw_EditFavourite.Size = new System.Drawing.Size(166, 22);
            this.tsmi_etvw_EditFavourite.Text = "Edit Favourite...";
            this.tsmi_etvw_EditFavourite.Click += new System.EventHandler(this.tsmi_etvw_EditFavourite_Click);
            // 
            // tsmi_etvw_RemoveAllFavourites
            // 
            this.tsmi_etvw_RemoveAllFavourites.Name = "tsmi_etvw_RemoveAllFavourites";
            this.tsmi_etvw_RemoveAllFavourites.Size = new System.Drawing.Size(166, 22);
            this.tsmi_etvw_RemoveAllFavourites.Text = "Remove All...";
            this.tsmi_etvw_RemoveAllFavourites.Click += new System.EventHandler(this.tsmi_etvw_RemoveAllFavourites_Click);
            // 
            // tsmi_etvw_RemoveFavourite
            // 
            this.tsmi_etvw_RemoveFavourite.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_etvw_RemoveFavourite.Image")));
            this.tsmi_etvw_RemoveFavourite.Name = "tsmi_etvw_RemoveFavourite";
            this.tsmi_etvw_RemoveFavourite.Size = new System.Drawing.Size(166, 22);
            this.tsmi_etvw_RemoveFavourite.Text = "Remove Favourite";
            this.tsmi_etvw_RemoveFavourite.Click += new System.EventHandler(this.tsmi_etvw_RemoveFavourite_Click);
            // 
            // tsmi_etvw_RefreshDevices
            // 
            this.tsmi_etvw_RefreshDevices.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_etvw_RefreshDevices.Image")));
            this.tsmi_etvw_RefreshDevices.Name = "tsmi_etvw_RefreshDevices";
            this.tsmi_etvw_RefreshDevices.Size = new System.Drawing.Size(166, 22);
            this.tsmi_etvw_RefreshDevices.Text = "Refresh Device List";
            this.tsmi_etvw_RefreshDevices.Click += new System.EventHandler(this.tsmi_etvw_RefreshDevices_Click);
            // 
            // ts_etvw_Tools
            // 
            this.ts_etvw_Tools.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_etvw_Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_etvw_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_etvw_Close,
            this.tsddb_etvw_Dock});
            this.ts_etvw_Tools.Location = new System.Drawing.Point(0, 0);
            this.ts_etvw_Tools.Name = "ts_etvw_Tools";
            this.ts_etvw_Tools.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ts_etvw_Tools.Size = new System.Drawing.Size(182, 25);
            this.ts_etvw_Tools.Stretch = true;
            this.ts_etvw_Tools.TabIndex = 4;
            // 
            // tsb_etvw_Close
            // 
            this.tsb_etvw_Close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_etvw_Close.BackColor = System.Drawing.Color.Transparent;
            this.tsb_etvw_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_etvw_Close.Image = ((System.Drawing.Image)(resources.GetObject("tsb_etvw_Close.Image")));
            this.tsb_etvw_Close.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_etvw_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_etvw_Close.Name = "tsb_etvw_Close";
            this.tsb_etvw_Close.Size = new System.Drawing.Size(23, 22);
            this.tsb_etvw_Close.Text = "Close";
            this.tsb_etvw_Close.Click += new System.EventHandler(this.tsb_etvw_Close_Click);
            // 
            // tsddb_etvw_Dock
            // 
            this.tsddb_etvw_Dock.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsddb_etvw_Dock.BackColor = System.Drawing.Color.Transparent;
            this.tsddb_etvw_Dock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddb_etvw_Dock.DropDown = this.cms_Docking;
            this.tsddb_etvw_Dock.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_etvw_Dock.Image")));
            this.tsddb_etvw_Dock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsddb_etvw_Dock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_etvw_Dock.Name = "tsddb_etvw_Dock";
            this.tsddb_etvw_Dock.ShowDropDownArrow = false;
            this.tsddb_etvw_Dock.Size = new System.Drawing.Size(20, 22);
            this.tsddb_etvw_Dock.Text = "Window Position";
            // 
            // cms_Docking
            // 
            this.cms_Docking.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_Docking.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_dock_DockWindow,
            this.tsmi_dock_FloatingWindow,
            this.tsmi_dock_Hide});
            this.cms_Docking.Name = "cms_Docking";
            this.cms_Docking.OwnerItem = this.tsddb_elvw_Dock;
            this.cms_Docking.Size = new System.Drawing.Size(113, 70);
            this.cms_Docking.Opening += new System.ComponentModel.CancelEventHandler(this.cms_Docking_Opening);
            // 
            // tsmi_dock_DockWindow
            // 
            this.tsmi_dock_DockWindow.Name = "tsmi_dock_DockWindow";
            this.tsmi_dock_DockWindow.Size = new System.Drawing.Size(112, 22);
            this.tsmi_dock_DockWindow.Text = "Dock";
            this.tsmi_dock_DockWindow.Click += new System.EventHandler(this.tsmi_dock_DockWindow_Click);
            // 
            // tsmi_dock_FloatingWindow
            // 
            this.tsmi_dock_FloatingWindow.Name = "tsmi_dock_FloatingWindow";
            this.tsmi_dock_FloatingWindow.Size = new System.Drawing.Size(112, 22);
            this.tsmi_dock_FloatingWindow.Text = "Floating";
            this.tsmi_dock_FloatingWindow.Click += new System.EventHandler(this.tsmi_dock_FloatingWindow_Click);
            // 
            // tsmi_dock_Hide
            // 
            this.tsmi_dock_Hide.Name = "tsmi_dock_Hide";
            this.tsmi_dock_Hide.Size = new System.Drawing.Size(112, 22);
            this.tsmi_dock_Hide.Text = "Hide";
            this.tsmi_dock_Hide.Click += new System.EventHandler(this.tsmi_dock_Hide_Click);
            // 
            // tsddb_task_Dock
            // 
            this.tsddb_task_Dock.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsddb_task_Dock.BackColor = System.Drawing.Color.Transparent;
            this.tsddb_task_Dock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddb_task_Dock.DropDown = this.cms_Docking;
            this.tsddb_task_Dock.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_task_Dock.Image")));
            this.tsddb_task_Dock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsddb_task_Dock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_task_Dock.Name = "tsddb_task_Dock";
            this.tsddb_task_Dock.ShowDropDownArrow = false;
            this.tsddb_task_Dock.Size = new System.Drawing.Size(20, 22);
            this.tsddb_task_Dock.Text = "Window Position";
            // 
            // sc_Tasks
            // 
            this.sc_Tasks.BackColor = System.Drawing.Color.White;
            this.sc_Tasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sc_Tasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_Tasks.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sc_Tasks.Location = new System.Drawing.Point(0, 0);
            this.sc_Tasks.Name = "sc_Tasks";
            // 
            // sc_Tasks.Panel1
            // 
            this.sc_Tasks.Panel1.BackColor = System.Drawing.Color.White;
            this.sc_Tasks.Panel1.Controls.Add(this.sc_ImageList);
            // 
            // sc_Tasks.Panel2
            // 
            this.sc_Tasks.Panel2.BackColor = System.Drawing.Color.White;
            this.sc_Tasks.Panel2.Controls.Add(this.pan_TasksContainer);
            this.sc_Tasks.Panel2.Controls.Add(this.ts_task_Tools);
            this.sc_Tasks.Size = new System.Drawing.Size(442, 249);
            this.sc_Tasks.SplitterDistance = 248;
            this.sc_Tasks.TabIndex = 2;
            // 
            // sc_ImageList
            // 
            this.sc_ImageList.BackColor = System.Drawing.Color.White;
            this.sc_ImageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.sc_ImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sc_ImageList.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.sc_ImageList.Location = new System.Drawing.Point(0, 0);
            this.sc_ImageList.Name = "sc_ImageList";
            this.sc_ImageList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // sc_ImageList.Panel1
            // 
            this.sc_ImageList.Panel1.BackColor = System.Drawing.Color.White;
            this.sc_ImageList.Panel1.Controls.Add(this.imgbx_MainImage);
            this.sc_ImageList.Panel1.Controls.Add(this.ts_imgbx_Tools);
            this.sc_ImageList.Panel1.Controls.Add(this.tlp_ImageBoxTools);
            this.sc_ImageList.Panel1MinSize = 100;
            // 
            // sc_ImageList.Panel2
            // 
            this.sc_ImageList.Panel2.BackColor = System.Drawing.Color.White;
            this.sc_ImageList.Panel2.Controls.Add(this.elvw_Images);
            this.sc_ImageList.Panel2.Controls.Add(this.ts_elvw_Tools);
            this.sc_ImageList.Size = new System.Drawing.Size(248, 249);
            this.sc_ImageList.SplitterDistance = 139;
            this.sc_ImageList.TabIndex = 1;
            // 
            // cms_ImageBox
            // 
            this.cms_ImageBox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_ImageBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_imgbx_Copy,
            this.tsmi_imgbx_Paste,
            this.tsmi_imgbx_Delete,
            this.tsmi_imgbx_Rename,
            this.tss_imgbx_03,
            this.tsmi_imgbx_AutoScale,
            this.tss_imgbx_04,
            this.tsmi_imgbx_SetBackGround,
            this.tss_imgbx_05,
            this.tsmi_imgbx_Properties});
            this.cms_ImageBox.Name = "cms_imgbx_ContextMenuStrip";
            this.cms_ImageBox.Size = new System.Drawing.Size(206, 176);
            this.cms_ImageBox.Opening += new System.ComponentModel.CancelEventHandler(this.cms_ImageBox_Opening);
            // 
            // tsmi_imgbx_Copy
            // 
            this.tsmi_imgbx_Copy.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_imgbx_Copy.Image")));
            this.tsmi_imgbx_Copy.Name = "tsmi_imgbx_Copy";
            this.tsmi_imgbx_Copy.ShortcutKeyDisplayString = "Ctrl+C";
            this.tsmi_imgbx_Copy.Size = new System.Drawing.Size(205, 22);
            this.tsmi_imgbx_Copy.Text = "Copy";
            this.tsmi_imgbx_Copy.Click += new System.EventHandler(this.tsmi_imgbx_Copy_Click);
            // 
            // tsmi_imgbx_Paste
            // 
            this.tsmi_imgbx_Paste.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_imgbx_Paste.Image")));
            this.tsmi_imgbx_Paste.Name = "tsmi_imgbx_Paste";
            this.tsmi_imgbx_Paste.ShortcutKeyDisplayString = "Ctrl+V";
            this.tsmi_imgbx_Paste.Size = new System.Drawing.Size(205, 22);
            this.tsmi_imgbx_Paste.Text = "Paste";
            this.tsmi_imgbx_Paste.Click += new System.EventHandler(this.tsmi_imgbx_Paste_Click);
            // 
            // tsmi_imgbx_Delete
            // 
            this.tsmi_imgbx_Delete.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_imgbx_Delete.Image")));
            this.tsmi_imgbx_Delete.Name = "tsmi_imgbx_Delete";
            this.tsmi_imgbx_Delete.ShortcutKeyDisplayString = "Del";
            this.tsmi_imgbx_Delete.Size = new System.Drawing.Size(205, 22);
            this.tsmi_imgbx_Delete.Text = "Delete...";
            this.tsmi_imgbx_Delete.Click += new System.EventHandler(this.tsmi_imgbx_Delete_Click);
            // 
            // tsmi_imgbx_Rename
            // 
            this.tsmi_imgbx_Rename.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_imgbx_Rename.Image")));
            this.tsmi_imgbx_Rename.Name = "tsmi_imgbx_Rename";
            this.tsmi_imgbx_Rename.Size = new System.Drawing.Size(205, 22);
            this.tsmi_imgbx_Rename.Text = "Rename...";
            this.tsmi_imgbx_Rename.Click += new System.EventHandler(this.tsmi_imgbx_Rename_Click);
            // 
            // tss_imgbx_03
            // 
            this.tss_imgbx_03.Name = "tss_imgbx_03";
            this.tss_imgbx_03.Size = new System.Drawing.Size(202, 6);
            // 
            // tsmi_imgbx_AutoScale
            // 
            this.tsmi_imgbx_AutoScale.Name = "tsmi_imgbx_AutoScale";
            this.tsmi_imgbx_AutoScale.Size = new System.Drawing.Size(205, 22);
            this.tsmi_imgbx_AutoScale.Text = "Auto Scale";
            this.tsmi_imgbx_AutoScale.Click += new System.EventHandler(this.tsmi_imgbx_AutoScale_Click);
            // 
            // tss_imgbx_04
            // 
            this.tss_imgbx_04.Name = "tss_imgbx_04";
            this.tss_imgbx_04.Size = new System.Drawing.Size(202, 6);
            // 
            // tsmi_imgbx_SetBackGround
            // 
            this.tsmi_imgbx_SetBackGround.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_imgbx_CenterImage,
            this.tsmi_imgbx_StretchImage,
            this.tsmi_imgbx_TileImage});
            this.tsmi_imgbx_SetBackGround.Name = "tsmi_imgbx_SetBackGround";
            this.tsmi_imgbx_SetBackGround.Size = new System.Drawing.Size(205, 22);
            this.tsmi_imgbx_SetBackGround.Text = "Set as Desktop Background";
            // 
            // tsmi_imgbx_CenterImage
            // 
            this.tsmi_imgbx_CenterImage.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_imgbx_CenterImage.Image")));
            this.tsmi_imgbx_CenterImage.Name = "tsmi_imgbx_CenterImage";
            this.tsmi_imgbx_CenterImage.Size = new System.Drawing.Size(142, 22);
            this.tsmi_imgbx_CenterImage.Text = "Center Image";
            this.tsmi_imgbx_CenterImage.Click += new System.EventHandler(this.tsmi_imgbx_CenterImage_Click);
            // 
            // tsmi_imgbx_StretchImage
            // 
            this.tsmi_imgbx_StretchImage.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_imgbx_StretchImage.Image")));
            this.tsmi_imgbx_StretchImage.Name = "tsmi_imgbx_StretchImage";
            this.tsmi_imgbx_StretchImage.Size = new System.Drawing.Size(142, 22);
            this.tsmi_imgbx_StretchImage.Text = "Stretch Image";
            this.tsmi_imgbx_StretchImage.Click += new System.EventHandler(this.tsmi_imgbx_StretchImage_Click);
            // 
            // tsmi_imgbx_TileImage
            // 
            this.tsmi_imgbx_TileImage.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_imgbx_TileImage.Image")));
            this.tsmi_imgbx_TileImage.Name = "tsmi_imgbx_TileImage";
            this.tsmi_imgbx_TileImage.Size = new System.Drawing.Size(142, 22);
            this.tsmi_imgbx_TileImage.Text = "Tile Image";
            this.tsmi_imgbx_TileImage.Click += new System.EventHandler(this.tsmi_imgbx_TileImage_Click);
            // 
            // tss_imgbx_05
            // 
            this.tss_imgbx_05.Name = "tss_imgbx_05";
            this.tss_imgbx_05.Size = new System.Drawing.Size(202, 6);
            // 
            // tsmi_imgbx_Properties
            // 
            this.tsmi_imgbx_Properties.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_imgbx_Properties.Image")));
            this.tsmi_imgbx_Properties.Name = "tsmi_imgbx_Properties";
            this.tsmi_imgbx_Properties.Size = new System.Drawing.Size(205, 22);
            this.tsmi_imgbx_Properties.Text = "Properties";
            this.tsmi_imgbx_Properties.Click += new System.EventHandler(this.tsmi_imgbx_Properties_Click);
            // 
            // ts_imgbx_Tools
            // 
            this.ts_imgbx_Tools.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_imgbx_Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_imgbx_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddb_imgbx_Directorys});
            this.ts_imgbx_Tools.Location = new System.Drawing.Point(0, 0);
            this.ts_imgbx_Tools.Name = "ts_imgbx_Tools";
            this.ts_imgbx_Tools.Size = new System.Drawing.Size(246, 25);
            this.ts_imgbx_Tools.TabIndex = 6;
            // 
            // tlp_ImageBoxTools
            // 
            this.tlp_ImageBoxTools.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tlp_ImageBoxTools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tlp_ImageBoxTools.ColumnCount = 7;
            this.tlp_ImageBoxTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_ImageBoxTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlp_ImageBoxTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlp_ImageBoxTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlp_ImageBoxTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlp_ImageBoxTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlp_ImageBoxTools.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_ImageBoxTools.Controls.Add(this.btn_nav_FirstImage, 1, 0);
            this.tlp_ImageBoxTools.Controls.Add(this.btn_nav_PreviousImage, 2, 0);
            this.tlp_ImageBoxTools.Controls.Add(this.btn_nav_NextImage, 4, 0);
            this.tlp_ImageBoxTools.Controls.Add(this.btn_nav_LastImage, 5, 0);
            this.tlp_ImageBoxTools.Controls.Add(this.lbl_ImageIndexDisplay, 3, 0);
            this.tlp_ImageBoxTools.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlp_ImageBoxTools.Location = new System.Drawing.Point(0, 103);
            this.tlp_ImageBoxTools.Name = "tlp_ImageBoxTools";
            this.tlp_ImageBoxTools.RowCount = 1;
            this.tlp_ImageBoxTools.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_ImageBoxTools.Size = new System.Drawing.Size(246, 34);
            this.tlp_ImageBoxTools.TabIndex = 5;
            // 
            // lbl_ImageIndexDisplay
            // 
            this.lbl_ImageIndexDisplay.AutoSize = true;
            this.lbl_ImageIndexDisplay.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ImageIndexDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_ImageIndexDisplay.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ImageIndexDisplay.ForeColor = System.Drawing.Color.DarkGray;
            this.lbl_ImageIndexDisplay.Location = new System.Drawing.Point(105, 0);
            this.lbl_ImageIndexDisplay.Name = "lbl_ImageIndexDisplay";
            this.lbl_ImageIndexDisplay.Size = new System.Drawing.Size(35, 34);
            this.lbl_ImageIndexDisplay.TabIndex = 4;
            this.lbl_ImageIndexDisplay.Text = "0 of 0";
            this.lbl_ImageIndexDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cms_ExplorerListView
            // 
            this.cms_ExplorerListView.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_ExplorerListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_elvw_Copy,
            this.tsmi_elvw_Delete,
            this.tsmi_elvw_Rename,
            this.tss_elvw_02,
            this.tsmi_elvw_SelectAll,
            this.tss_elvw_03,
            this.tsmi_elvw_View,
            this.tss_elvw_04,
            this.tsmi_elvw_CopyPath,
            this.tsmi_elvw_OpenContainingFolder});
            this.cms_ExplorerListView.Name = "cms_ListView";
            this.cms_ExplorerListView.Size = new System.Drawing.Size(188, 176);
            this.cms_ExplorerListView.Opening += new System.ComponentModel.CancelEventHandler(this.cms_ExplorerListView_Opening);
            // 
            // tsmi_elvw_Copy
            // 
            this.tsmi_elvw_Copy.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_elvw_Copy.Image")));
            this.tsmi_elvw_Copy.Name = "tsmi_elvw_Copy";
            this.tsmi_elvw_Copy.ShortcutKeyDisplayString = "Ctrl+C";
            this.tsmi_elvw_Copy.Size = new System.Drawing.Size(187, 22);
            this.tsmi_elvw_Copy.Text = "Copy";
            this.tsmi_elvw_Copy.Click += new System.EventHandler(this.tsmi_elvw_Copy_Click);
            // 
            // tsmi_elvw_Delete
            // 
            this.tsmi_elvw_Delete.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_elvw_Delete.Image")));
            this.tsmi_elvw_Delete.Name = "tsmi_elvw_Delete";
            this.tsmi_elvw_Delete.ShortcutKeyDisplayString = "Del";
            this.tsmi_elvw_Delete.Size = new System.Drawing.Size(187, 22);
            this.tsmi_elvw_Delete.Text = "Delete...";
            this.tsmi_elvw_Delete.Click += new System.EventHandler(this.tsmi_elvw_Delete_Click);
            // 
            // tsmi_elvw_Rename
            // 
            this.tsmi_elvw_Rename.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_elvw_Rename.Image")));
            this.tsmi_elvw_Rename.Name = "tsmi_elvw_Rename";
            this.tsmi_elvw_Rename.Size = new System.Drawing.Size(187, 22);
            this.tsmi_elvw_Rename.Text = "Rename";
            this.tsmi_elvw_Rename.Click += new System.EventHandler(this.tsmi_elvw_Rename_Click);
            // 
            // tss_elvw_02
            // 
            this.tss_elvw_02.Name = "tss_elvw_02";
            this.tss_elvw_02.Size = new System.Drawing.Size(184, 6);
            // 
            // tsmi_elvw_SelectAll
            // 
            this.tsmi_elvw_SelectAll.Name = "tsmi_elvw_SelectAll";
            this.tsmi_elvw_SelectAll.ShortcutKeyDisplayString = "Ctrl+A";
            this.tsmi_elvw_SelectAll.Size = new System.Drawing.Size(187, 22);
            this.tsmi_elvw_SelectAll.Text = "Select All";
            this.tsmi_elvw_SelectAll.Click += new System.EventHandler(this.tsmi_elvw_SelectAll_Click);
            // 
            // tss_elvw_03
            // 
            this.tss_elvw_03.Name = "tss_elvw_03";
            this.tss_elvw_03.Size = new System.Drawing.Size(184, 6);
            // 
            // tss_elvw_04
            // 
            this.tss_elvw_04.Name = "tss_elvw_04";
            this.tss_elvw_04.Size = new System.Drawing.Size(184, 6);
            // 
            // tsmi_elvw_CopyPath
            // 
            this.tsmi_elvw_CopyPath.Name = "tsmi_elvw_CopyPath";
            this.tsmi_elvw_CopyPath.Size = new System.Drawing.Size(187, 22);
            this.tsmi_elvw_CopyPath.Text = "Copy File Path";
            this.tsmi_elvw_CopyPath.Click += new System.EventHandler(this.tsmi_elvw_CopyPath_Click);
            // 
            // tsmi_elvw_OpenContainingFolder
            // 
            this.tsmi_elvw_OpenContainingFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_elvw_OpenContainingFolder.Image")));
            this.tsmi_elvw_OpenContainingFolder.Name = "tsmi_elvw_OpenContainingFolder";
            this.tsmi_elvw_OpenContainingFolder.Size = new System.Drawing.Size(187, 22);
            this.tsmi_elvw_OpenContainingFolder.Text = "Open Containing Folder";
            this.tsmi_elvw_OpenContainingFolder.Click += new System.EventHandler(this.tsmi_elvw_OpenContainingFolder_Click);
            // 
            // imgl_SmallImageList
            // 
            this.imgl_SmallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgl_SmallImageList.ImageStream")));
            this.imgl_SmallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgl_SmallImageList.Images.SetKeyName(0, "image_file_16x16.png");
            // 
            // ts_elvw_Tools
            // 
            this.ts_elvw_Tools.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_elvw_Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_elvw_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_elvw_Close,
            this.tsddb_elvw_Dock,
            this.tsl_elvw_ItemInfo});
            this.ts_elvw_Tools.Location = new System.Drawing.Point(0, 0);
            this.ts_elvw_Tools.Name = "ts_elvw_Tools";
            this.ts_elvw_Tools.Size = new System.Drawing.Size(246, 25);
            this.ts_elvw_Tools.TabIndex = 4;
            // 
            // tsb_elvw_Close
            // 
            this.tsb_elvw_Close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_elvw_Close.BackColor = System.Drawing.Color.Transparent;
            this.tsb_elvw_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_elvw_Close.Image = ((System.Drawing.Image)(resources.GetObject("tsb_elvw_Close.Image")));
            this.tsb_elvw_Close.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_elvw_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_elvw_Close.Name = "tsb_elvw_Close";
            this.tsb_elvw_Close.Size = new System.Drawing.Size(23, 22);
            this.tsb_elvw_Close.Text = "Close";
            this.tsb_elvw_Close.Click += new System.EventHandler(this.tsb_elvw_Close_Click);
            // 
            // tsddb_elvw_Dock
            // 
            this.tsddb_elvw_Dock.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsddb_elvw_Dock.BackColor = System.Drawing.Color.Transparent;
            this.tsddb_elvw_Dock.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsddb_elvw_Dock.DropDown = this.cms_Docking;
            this.tsddb_elvw_Dock.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_elvw_Dock.Image")));
            this.tsddb_elvw_Dock.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsddb_elvw_Dock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_elvw_Dock.Name = "tsddb_elvw_Dock";
            this.tsddb_elvw_Dock.ShowDropDownArrow = false;
            this.tsddb_elvw_Dock.Size = new System.Drawing.Size(20, 22);
            this.tsddb_elvw_Dock.Text = "Window Position";
            // 
            // tsl_elvw_ItemInfo
            // 
            this.tsl_elvw_ItemInfo.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsl_elvw_ItemInfo.Name = "tsl_elvw_ItemInfo";
            this.tsl_elvw_ItemInfo.Size = new System.Drawing.Size(108, 22);
            this.tsl_elvw_ItemInfo.Text = "Items: 0, Selected: 0";
            this.tsl_elvw_ItemInfo.Visible = false;
            // 
            // pan_TasksContainer
            // 
            this.pan_TasksContainer.BackColor = System.Drawing.Color.White;
            this.pan_TasksContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_TasksContainer.Location = new System.Drawing.Point(0, 25);
            this.pan_TasksContainer.Name = "pan_TasksContainer";
            this.pan_TasksContainer.Size = new System.Drawing.Size(188, 222);
            this.pan_TasksContainer.TabIndex = 0;
            // 
            // ts_task_Tools
            // 
            this.ts_task_Tools.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_task_Tools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ts_task_Tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_task_Close,
            this.tsddb_task_Dock,
            this.tsddb_task_Tasks});
            this.ts_task_Tools.Location = new System.Drawing.Point(0, 0);
            this.ts_task_Tools.Name = "ts_task_Tools";
            this.ts_task_Tools.Size = new System.Drawing.Size(188, 25);
            this.ts_task_Tools.TabIndex = 7;
            // 
            // tsb_task_Close
            // 
            this.tsb_task_Close.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsb_task_Close.BackColor = System.Drawing.Color.Transparent;
            this.tsb_task_Close.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_task_Close.Image = ((System.Drawing.Image)(resources.GetObject("tsb_task_Close.Image")));
            this.tsb_task_Close.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsb_task_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_task_Close.Name = "tsb_task_Close";
            this.tsb_task_Close.Size = new System.Drawing.Size(23, 22);
            this.tsb_task_Close.Text = "Close";
            this.tsb_task_Close.Click += new System.EventHandler(this.tsb_task_Close_Click);
            // 
            // tsddb_task_Tasks
            // 
            this.tsddb_task_Tasks.DropDown = this.cms_Tasks;
            this.tsddb_task_Tasks.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsddb_task_Tasks.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsddb_task_Tasks.Name = "tsddb_task_Tasks";
            this.tsddb_task_Tasks.Size = new System.Drawing.Size(69, 22);
            this.tsddb_task_Tasks.Text = "Properties";
            // 
            // cms_Tasks
            // 
            this.cms_Tasks.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cms_Tasks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_task_Crop,
            this.tsmi_task_Resize,
            this.tsmi_task_Shear,
            this.tss_task_01,
            this.tsmi_task_RedEyeCorrection,
            this.tss_task_02,
            this.tsmi_task_Properties});
            this.cms_Tasks.Name = "cms_Tasks";
            this.cms_Tasks.OwnerItem = this.tsddb_task_Tasks;
            this.cms_Tasks.Size = new System.Drawing.Size(168, 126);
            // 
            // tsmi_task_Crop
            // 
            this.tsmi_task_Crop.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_task_Crop.Image")));
            this.tsmi_task_Crop.Name = "tsmi_task_Crop";
            this.tsmi_task_Crop.Size = new System.Drawing.Size(167, 22);
            this.tsmi_task_Crop.Text = "Crop Image";
            this.tsmi_task_Crop.Visible = false;
            // 
            // tsmi_task_Resize
            // 
            this.tsmi_task_Resize.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_task_Resize.Image")));
            this.tsmi_task_Resize.Name = "tsmi_task_Resize";
            this.tsmi_task_Resize.Size = new System.Drawing.Size(167, 22);
            this.tsmi_task_Resize.Text = "Resize Image";
            this.tsmi_task_Resize.Click += new System.EventHandler(this.tsmi_task_Resize_Click);
            // 
            // tsmi_task_Shear
            // 
            this.tsmi_task_Shear.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_task_Shear.Image")));
            this.tsmi_task_Shear.Name = "tsmi_task_Shear";
            this.tsmi_task_Shear.Size = new System.Drawing.Size(167, 22);
            this.tsmi_task_Shear.Text = "Shear Image";
            this.tsmi_task_Shear.Click += new System.EventHandler(this.tsmi_task_Shear_Click);
            // 
            // tss_task_01
            // 
            this.tss_task_01.Name = "tss_task_01";
            this.tss_task_01.Size = new System.Drawing.Size(164, 6);
            // 
            // tsmi_task_RedEyeCorrection
            // 
            this.tsmi_task_RedEyeCorrection.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_task_RedEyeCorrection.Image")));
            this.tsmi_task_RedEyeCorrection.Name = "tsmi_task_RedEyeCorrection";
            this.tsmi_task_RedEyeCorrection.Size = new System.Drawing.Size(167, 22);
            this.tsmi_task_RedEyeCorrection.Text = "Red Eye Correction";
            this.tsmi_task_RedEyeCorrection.Click += new System.EventHandler(this.tsmi_task_RedEyeCorrection_Click);
            // 
            // tss_task_02
            // 
            this.tss_task_02.Name = "tss_task_02";
            this.tss_task_02.Size = new System.Drawing.Size(164, 6);
            // 
            // tsmi_task_Properties
            // 
            this.tsmi_task_Properties.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_task_Properties.Image")));
            this.tsmi_task_Properties.Name = "tsmi_task_Properties";
            this.tsmi_task_Properties.Size = new System.Drawing.Size(167, 22);
            this.tsmi_task_Properties.Text = "Properties";
            this.tsmi_task_Properties.Click += new System.EventHandler(this.tsmi_task_Properties_Click);
            // 
            // tsb_tb_TasksWindow
            // 
            this.tsb_tb_TasksWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_tb_TasksWindow.DropDown = this.cms_Tasks;
            this.tsb_tb_TasksWindow.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tb_TasksWindow.Image")));
            this.tsb_tb_TasksWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tb_TasksWindow.Name = "tsb_tb_TasksWindow";
            this.tsb_tb_TasksWindow.Size = new System.Drawing.Size(32, 22);
            this.tsb_tb_TasksWindow.Text = "Tasks Panel (F4)";
            this.tsb_tb_TasksWindow.ToolTipText = "Tasks Panel (F4)";
            this.tsb_tb_TasksWindow.ButtonClick += new System.EventHandler(this.tsb_tb_TasksWindow_ButtonClick);
            // 
            // ts_Toolbar
            // 
            this.ts_Toolbar.Dock = System.Windows.Forms.DockStyle.None;
            this.ts_Toolbar.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ts_Toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_tb_Open,
            this.tsb_tb_AddFavourite,
            this.tss_tb_01,
            this.tsb_tb_Save,
            this.tsb_tb_02,
            this.tssb_tb_Print,
            this.tss_tb_03,
            this.tscbx_tb_Zoom,
            this.tss_tb_04,
            this.tsb_tb_RotateLeft90,
            this.tsb_tb_RotateRight90,
            this.tss_tb_05,
            this.tsb_tb_SlideShow,
            this.tss_tb_06,
            this.tsb_tb_EyeDropper,
            this.tsl_tb_PixelInfo,
            this.tss_tb_07,
            this.tsb_tb_ExplorerWindow,
            this.tsb_tb_ImageListWindow,
            this.tsb_tb_TasksWindow,
            this.tsddb_tb_AddRemove});
            this.ts_Toolbar.Location = new System.Drawing.Point(3, 0);
            this.ts_Toolbar.Name = "ts_Toolbar";
            this.ts_Toolbar.Size = new System.Drawing.Size(539, 25);
            this.ts_Toolbar.TabIndex = 0;
            this.ts_Toolbar.LayoutStyleChanged += new System.EventHandler(this.ts_Toolbar_LayoutStyleChanged);
            // 
            // tsb_tb_Open
            // 
            this.tsb_tb_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_tb_Open.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tb_Open.Image")));
            this.tsb_tb_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tb_Open.Name = "tsb_tb_Open";
            this.tsb_tb_Open.Size = new System.Drawing.Size(23, 22);
            this.tsb_tb_Open.Text = "Open Image File (Ctrl+O)";
            this.tsb_tb_Open.ToolTipText = "Open Image File (Ctrl+O)";
            this.tsb_tb_Open.Click += new System.EventHandler(this.tsb_tb_Open_Click);
            // 
            // tsb_tb_AddFavourite
            // 
            this.tsb_tb_AddFavourite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_tb_AddFavourite.Enabled = false;
            this.tsb_tb_AddFavourite.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tb_AddFavourite.Image")));
            this.tsb_tb_AddFavourite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tb_AddFavourite.Name = "tsb_tb_AddFavourite";
            this.tsb_tb_AddFavourite.Size = new System.Drawing.Size(23, 22);
            this.tsb_tb_AddFavourite.Text = "Add to Favourites";
            this.tsb_tb_AddFavourite.Click += new System.EventHandler(this.tsb_tb_AddFavourite_Click);
            // 
            // tss_tb_01
            // 
            this.tss_tb_01.Name = "tss_tb_01";
            this.tss_tb_01.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_tb_Save
            // 
            this.tsb_tb_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_tb_Save.Enabled = false;
            this.tsb_tb_Save.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tb_Save.Image")));
            this.tsb_tb_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tb_Save.Name = "tsb_tb_Save";
            this.tsb_tb_Save.Size = new System.Drawing.Size(23, 22);
            this.tsb_tb_Save.Text = "Save (Ctrl+S)";
            this.tsb_tb_Save.Click += new System.EventHandler(this.tsb_tb_Save_Click);
            // 
            // tsb_tb_02
            // 
            this.tsb_tb_02.Name = "tsb_tb_02";
            this.tsb_tb_02.Size = new System.Drawing.Size(6, 25);
            // 
            // tssb_tb_Print
            // 
            this.tssb_tb_Print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssb_tb_Print.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_tb_PageSetup,
            this.tsmi_tb_PrintPreview,
            this.tsmi_tb_Print});
            this.tssb_tb_Print.Enabled = false;
            this.tssb_tb_Print.Image = ((System.Drawing.Image)(resources.GetObject("tssb_tb_Print.Image")));
            this.tssb_tb_Print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssb_tb_Print.Name = "tssb_tb_Print";
            this.tssb_tb_Print.Size = new System.Drawing.Size(32, 22);
            this.tssb_tb_Print.Text = "Print (Ctrl+P)";
            this.tssb_tb_Print.ToolTipText = "Print (Ctrl+P)";
            this.tssb_tb_Print.ButtonClick += new System.EventHandler(this.tssb_tb_Print_ButtonClick);
            // 
            // tsmi_tb_PageSetup
            // 
            this.tsmi_tb_PageSetup.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_tb_PageSetup.Image")));
            this.tsmi_tb_PageSetup.Name = "tsmi_tb_PageSetup";
            this.tsmi_tb_PageSetup.Size = new System.Drawing.Size(146, 22);
            this.tsmi_tb_PageSetup.Text = "Page Setup...";
            this.tsmi_tb_PageSetup.Click += new System.EventHandler(this.tsmi_tb_PageSetup_Click);
            // 
            // tsmi_tb_PrintPreview
            // 
            this.tsmi_tb_PrintPreview.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_tb_PrintPreview.Image")));
            this.tsmi_tb_PrintPreview.Name = "tsmi_tb_PrintPreview";
            this.tsmi_tb_PrintPreview.Size = new System.Drawing.Size(146, 22);
            this.tsmi_tb_PrintPreview.Text = "Print Preview";
            this.tsmi_tb_PrintPreview.Click += new System.EventHandler(this.tsmi_tb_PrintPreview_Click);
            // 
            // tsmi_tb_Print
            // 
            this.tsmi_tb_Print.Image = ((System.Drawing.Image)(resources.GetObject("tsmi_tb_Print.Image")));
            this.tsmi_tb_Print.Name = "tsmi_tb_Print";
            this.tsmi_tb_Print.ShortcutKeyDisplayString = "Ctrl+P";
            this.tsmi_tb_Print.Size = new System.Drawing.Size(146, 22);
            this.tsmi_tb_Print.Text = "Print...";
            this.tsmi_tb_Print.Click += new System.EventHandler(this.tsmi_tb_Print_Click);
            // 
            // tss_tb_03
            // 
            this.tss_tb_03.Name = "tss_tb_03";
            this.tss_tb_03.Size = new System.Drawing.Size(6, 25);
            // 
            // tscbx_tb_Zoom
            // 
            this.tscbx_tb_Zoom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tscbx_tb_Zoom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tscbx_tb_Zoom.Enabled = false;
            this.tscbx_tb_Zoom.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tscbx_tb_Zoom.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tscbx_tb_Zoom.Items.AddRange(new object[] {
            "800.0%",
            "400.0%",
            "200.0%",
            "150.0%",
            "100.0%",
            "75.0%",
            "50.0%",
            "25.0%",
            "12.5%",
            "Auto Scale"});
            this.tscbx_tb_Zoom.Name = "tscbx_tb_Zoom";
            this.tscbx_tb_Zoom.Size = new System.Drawing.Size(80, 25);
            this.tscbx_tb_Zoom.Text = "100.0%";
            this.tscbx_tb_Zoom.ToolTipText = "Zoom";
            this.tscbx_tb_Zoom.SelectedIndexChanged += new System.EventHandler(this.tscbx_tb_Zoom_SelectedIndexChanged);
            this.tscbx_tb_Zoom.Leave += new System.EventHandler(this.tscbx_tb_Zoom_Leave);
            // 
            // tss_tb_04
            // 
            this.tss_tb_04.Name = "tss_tb_04";
            this.tss_tb_04.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_tb_RotateLeft90
            // 
            this.tsb_tb_RotateLeft90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_tb_RotateLeft90.Enabled = false;
            this.tsb_tb_RotateLeft90.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tb_RotateLeft90.Image")));
            this.tsb_tb_RotateLeft90.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tb_RotateLeft90.Name = "tsb_tb_RotateLeft90";
            this.tsb_tb_RotateLeft90.Size = new System.Drawing.Size(23, 22);
            this.tsb_tb_RotateLeft90.Text = "Rotate Left 90º (Ctrl+,)";
            this.tsb_tb_RotateLeft90.Click += new System.EventHandler(this.tsb_tb_RotateLeft90_Click);
            // 
            // tsb_tb_RotateRight90
            // 
            this.tsb_tb_RotateRight90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_tb_RotateRight90.Enabled = false;
            this.tsb_tb_RotateRight90.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tb_RotateRight90.Image")));
            this.tsb_tb_RotateRight90.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tb_RotateRight90.Name = "tsb_tb_RotateRight90";
            this.tsb_tb_RotateRight90.Size = new System.Drawing.Size(23, 22);
            this.tsb_tb_RotateRight90.Text = "Rotate Right 90º (Ctrl+.)";
            this.tsb_tb_RotateRight90.Click += new System.EventHandler(this.tsb_tb_RotateRight90_Click);
            // 
            // tss_tb_05
            // 
            this.tss_tb_05.Name = "tss_tb_05";
            this.tss_tb_05.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_tb_SlideShow
            // 
            this.tsb_tb_SlideShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_tb_SlideShow.Enabled = false;
            this.tsb_tb_SlideShow.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tb_SlideShow.Image")));
            this.tsb_tb_SlideShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tb_SlideShow.Name = "tsb_tb_SlideShow";
            this.tsb_tb_SlideShow.Size = new System.Drawing.Size(23, 22);
            this.tsb_tb_SlideShow.Text = "Play Slide Show (F6)";
            this.tsb_tb_SlideShow.Click += new System.EventHandler(this.tsb_tb_SlideShow_Click);
            // 
            // tss_tb_06
            // 
            this.tss_tb_06.Name = "tss_tb_06";
            this.tss_tb_06.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_tb_EyeDropper
            // 
            this.tsb_tb_EyeDropper.CheckOnClick = true;
            this.tsb_tb_EyeDropper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_tb_EyeDropper.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tb_EyeDropper.Image")));
            this.tsb_tb_EyeDropper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tb_EyeDropper.Name = "tsb_tb_EyeDropper";
            this.tsb_tb_EyeDropper.Size = new System.Drawing.Size(23, 22);
            this.tsb_tb_EyeDropper.Text = "Eye Dropper";
            this.tsb_tb_EyeDropper.Click += new System.EventHandler(this.tsb_tb_EyeDropper_Click);
            // 
            // tsl_tb_PixelInfo
            // 
            this.tsl_tb_PixelInfo.AutoToolTip = true;
            this.tsl_tb_PixelInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsl_tb_PixelInfo.Image")));
            this.tsl_tb_PixelInfo.Margin = new System.Windows.Forms.Padding(3, 1, 0, 2);
            this.tsl_tb_PixelInfo.Name = "tsl_tb_PixelInfo";
            this.tsl_tb_PixelInfo.Size = new System.Drawing.Size(59, 22);
            this.tsl_tb_PixelInfo.Text = "000000";
            this.tsl_tb_PixelInfo.ToolTipText = "Alpha: 0\r\nRed: 0\r\nGreen: 0\r\nBlue: 0";
            this.tsl_tb_PixelInfo.Visible = false;
            // 
            // tss_tb_07
            // 
            this.tss_tb_07.Name = "tss_tb_07";
            this.tss_tb_07.Size = new System.Drawing.Size(6, 25);
            // 
            // tsb_tb_ExplorerWindow
            // 
            this.tsb_tb_ExplorerWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_tb_ExplorerWindow.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tb_ExplorerWindow.Image")));
            this.tsb_tb_ExplorerWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tb_ExplorerWindow.Name = "tsb_tb_ExplorerWindow";
            this.tsb_tb_ExplorerWindow.Size = new System.Drawing.Size(23, 22);
            this.tsb_tb_ExplorerWindow.Text = "Explorer Panel (F2)";
            this.tsb_tb_ExplorerWindow.ToolTipText = "Explorer Panel (F2)";
            this.tsb_tb_ExplorerWindow.Click += new System.EventHandler(this.tsb_tb_ExplorerWindow_Click);
            // 
            // tsb_tb_ImageListWindow
            // 
            this.tsb_tb_ImageListWindow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsb_tb_ImageListWindow.Image = ((System.Drawing.Image)(resources.GetObject("tsb_tb_ImageListWindow.Image")));
            this.tsb_tb_ImageListWindow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_tb_ImageListWindow.Name = "tsb_tb_ImageListWindow";
            this.tsb_tb_ImageListWindow.Size = new System.Drawing.Size(23, 22);
            this.tsb_tb_ImageListWindow.Text = "Image List Panel (F3)";
            this.tsb_tb_ImageListWindow.ToolTipText = "Image List Panel (F3)";
            this.tsb_tb_ImageListWindow.Click += new System.EventHandler(this.tsb_tb_ImageListWindow_Click);
            // 
            // etvw_Directorys
            // 
            this.etvw_Directorys.BackColor = System.Drawing.Color.White;
            this.etvw_Directorys.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.etvw_Directorys.ContextMenuStrip = this.cms_ExplorerTreeView;
            this.etvw_Directorys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etvw_Directorys.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etvw_Directorys.ImageIndex = 0;
            this.etvw_Directorys.Location = new System.Drawing.Point(0, 25);
            this.etvw_Directorys.Name = "etvw_Directorys";
            this.etvw_Directorys.SelectedImageIndex = 0;
            this.etvw_Directorys.ShowLines = false;
            this.etvw_Directorys.ShowNodeToolTips = true;
            this.etvw_Directorys.ShowPlusMinus = false;
            this.etvw_Directorys.ShowRootLines = false;
            this.etvw_Directorys.Size = new System.Drawing.Size(182, 222);
            this.etvw_Directorys.TabIndex = 5;
            this.etvw_Directorys.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.etvw_Directorys_AfterSelect);
            this.etvw_Directorys.MouseClick += new System.Windows.Forms.MouseEventHandler(this.etvw_Directorys_MouseClick);
            // 
            // imgbx_MainImage
            // 
            this.imgbx_MainImage.AllowDrop = true;
            this.imgbx_MainImage.AllowMouseMove = false;
            this.imgbx_MainImage.AllowMouseResize = false;
            this.imgbx_MainImage.AutoScroll = true;
            this.imgbx_MainImage.AutoScrollMinSize = new System.Drawing.Size(3, 3);
            this.imgbx_MainImage.AutoSize = true;
            this.imgbx_MainImage.BackColor = System.Drawing.Color.White;
            this.imgbx_MainImage.ContextMenuStrip = this.cms_ImageBox;
            this.imgbx_MainImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgbx_MainImage.FocusControl = false;
            this.imgbx_MainImage.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imgbx_MainImage.ImageBoxHeight = 1;
            this.imgbx_MainImage.ImageBoxRectangle = new System.Drawing.Rectangle(0, 0, 1, 1);
            this.imgbx_MainImage.ImageBoxSize = new System.Drawing.Size(1, 1);
            this.imgbx_MainImage.ImageBoxSmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            this.imgbx_MainImage.ImageBoxWidth = 1;
            this.imgbx_MainImage.Location = new System.Drawing.Point(0, 25);
            this.imgbx_MainImage.Margin = new System.Windows.Forms.Padding(4);
            this.imgbx_MainImage.Name = "imgbx_MainImage";
            this.imgbx_MainImage.Size = new System.Drawing.Size(246, 78);
            this.imgbx_MainImage.TabIndex = 7;
            this.imgbx_MainImage.ImageBoxImageLoaded += new System.EventHandler<IView.Controls.Library.ImageBoxEventArgs>(this.imgbx_MainImage_ImageBoxImageLoaded);
            this.imgbx_MainImage.ImageBoxMouseEnter += new System.EventHandler<IView.Controls.Library.ImageBoxEventArgs>(this.imgbx_MainImage_ImageBoxMouseEnter);
            this.imgbx_MainImage.ImageBoxMouseLeave += new System.EventHandler<IView.Controls.Library.ImageBoxEventArgs>(this.imgbx_MainImage_ImageBoxMouseLeave);
            this.imgbx_MainImage.ImageBoxMouseDown += new System.EventHandler<IView.Controls.Library.ImageBoxMouseEventArgs>(this.imgbx_MainImage_ImageBoxMouseDown);
            this.imgbx_MainImage.ImageBoxMouseMove += new System.EventHandler<IView.Controls.Library.ImageBoxMouseEventArgs>(this.imgbx_MainImage_ImageBoxMouseMove);
            this.imgbx_MainImage.ImageBoxMouseWheel += new System.EventHandler<System.Windows.Forms.MouseEventArgs>(this.imgbx_MainImage_ImageBoxMouseWheel);
            this.imgbx_MainImage.SizeChanged += new System.EventHandler(this.imgbx_MainImage_SizeChanged);
            this.imgbx_MainImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.imgbx_MainImage_DragDrop);
            this.imgbx_MainImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.imgbx_MainImage_DragEnter);
            this.imgbx_MainImage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.imgbx_MainImage_KeyDown);
            this.imgbx_MainImage.KeyUp += new System.Windows.Forms.KeyEventHandler(this.imgbx_MainImage_KeyUp);
            // 
            // tsddb_imgbx_Directorys
            // 
            this.tsddb_imgbx_Directorys.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddb_imgbx_Directorys.Enabled = false;
            this.tsddb_imgbx_Directorys.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsddb_imgbx_Directorys.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_imgbx_Directorys.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsddb_imgbx_Directorys.Name = "tsddb_imgbx_Directorys";
            this.tsddb_imgbx_Directorys.ShowDropDownArrow = false;
            this.tsddb_imgbx_Directorys.Size = new System.Drawing.Size(58, 22);
            this.tsddb_imgbx_Directorys.Text = "Computer";
            this.tsddb_imgbx_Directorys.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsddb_imgbx_Directorys_DropDownItemClicked);
            // 
            // btn_nav_FirstImage
            // 
            this.btn_nav_FirstImage.BackColor = System.Drawing.Color.Transparent;
            this.btn_nav_FirstImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_nav_FirstImage.Enabled = false;
            this.btn_nav_FirstImage.FlatAppearance.BorderSize = 0;
            this.btn_nav_FirstImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_nav_FirstImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_nav_FirstImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nav_FirstImage.Image = ((System.Drawing.Image)(resources.GetObject("btn_nav_FirstImage.Image")));
            this.btn_nav_FirstImage.Location = new System.Drawing.Point(37, 3);
            this.btn_nav_FirstImage.Name = "btn_nav_FirstImage";
            this.btn_nav_FirstImage.Size = new System.Drawing.Size(28, 28);
            this.btn_nav_FirstImage.TabIndex = 0;
            this.btn_nav_FirstImage.UseVisualStyleBackColor = false;
            this.btn_nav_FirstImage.Click += new System.EventHandler(this.btn_nav_FirstImage_Click);
            // 
            // btn_nav_PreviousImage
            // 
            this.btn_nav_PreviousImage.BackColor = System.Drawing.Color.Transparent;
            this.btn_nav_PreviousImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_nav_PreviousImage.Enabled = false;
            this.btn_nav_PreviousImage.FlatAppearance.BorderSize = 0;
            this.btn_nav_PreviousImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_nav_PreviousImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_nav_PreviousImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nav_PreviousImage.Image = ((System.Drawing.Image)(resources.GetObject("btn_nav_PreviousImage.Image")));
            this.btn_nav_PreviousImage.Location = new System.Drawing.Point(71, 3);
            this.btn_nav_PreviousImage.Name = "btn_nav_PreviousImage";
            this.btn_nav_PreviousImage.Size = new System.Drawing.Size(28, 28);
            this.btn_nav_PreviousImage.TabIndex = 1;
            this.btn_nav_PreviousImage.UseVisualStyleBackColor = false;
            this.btn_nav_PreviousImage.Click += new System.EventHandler(this.btn_nav_PreviousImage_Click);
            // 
            // btn_nav_NextImage
            // 
            this.btn_nav_NextImage.BackColor = System.Drawing.Color.Transparent;
            this.btn_nav_NextImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_nav_NextImage.Enabled = false;
            this.btn_nav_NextImage.FlatAppearance.BorderSize = 0;
            this.btn_nav_NextImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_nav_NextImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_nav_NextImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nav_NextImage.Image = ((System.Drawing.Image)(resources.GetObject("btn_nav_NextImage.Image")));
            this.btn_nav_NextImage.Location = new System.Drawing.Point(146, 3);
            this.btn_nav_NextImage.Name = "btn_nav_NextImage";
            this.btn_nav_NextImage.Size = new System.Drawing.Size(28, 28);
            this.btn_nav_NextImage.TabIndex = 2;
            this.btn_nav_NextImage.UseVisualStyleBackColor = false;
            this.btn_nav_NextImage.Click += new System.EventHandler(this.btn_nav_NextImage_Click);
            // 
            // btn_nav_LastImage
            // 
            this.btn_nav_LastImage.BackColor = System.Drawing.Color.Transparent;
            this.btn_nav_LastImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_nav_LastImage.Enabled = false;
            this.btn_nav_LastImage.FlatAppearance.BorderSize = 0;
            this.btn_nav_LastImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_nav_LastImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_nav_LastImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nav_LastImage.Image = ((System.Drawing.Image)(resources.GetObject("btn_nav_LastImage.Image")));
            this.btn_nav_LastImage.Location = new System.Drawing.Point(180, 3);
            this.btn_nav_LastImage.Name = "btn_nav_LastImage";
            this.btn_nav_LastImage.Size = new System.Drawing.Size(28, 28);
            this.btn_nav_LastImage.TabIndex = 3;
            this.btn_nav_LastImage.UseVisualStyleBackColor = false;
            this.btn_nav_LastImage.Click += new System.EventHandler(this.btn_nav_LastImage_Click);
            // 
            // elvw_Images
            // 
            this.elvw_Images.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.elvw_Images.AllowDrop = true;
            this.elvw_Images.BackColor = System.Drawing.Color.White;
            this.elvw_Images.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.elvw_Images.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_FileName,
            this.ch_Date,
            this.ch_FileType,
            this.ch_FileSize});
            this.elvw_Images.ContextMenuStrip = this.cms_ExplorerListView;
            this.elvw_Images.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elvw_Images.DoubleBuffer = true;
            this.elvw_Images.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elvw_Images.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.elvw_Images.LabelEdit = true;
            this.elvw_Images.Location = new System.Drawing.Point(0, 25);
            this.elvw_Images.Name = "elvw_Images";
            this.elvw_Images.ShowGroups = false;
            this.elvw_Images.ShowItemToolTips = true;
            this.elvw_Images.Size = new System.Drawing.Size(246, 79);
            this.elvw_Images.SmallImageList = this.imgl_SmallImageList;
            this.elvw_Images.TabIndex = 5;
            this.elvw_Images.UseCompatibleStateImageBehavior = false;
            this.elvw_Images.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.elvw_Images_AfterLabelEdit);
            this.elvw_Images.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.elvw_Images_BeforeLabelEdit);
            this.elvw_Images.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.elvw_Images_ItemDrag);
            this.elvw_Images.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.elvw_Images_ItemSelectionChanged);
            this.elvw_Images.DoubleClick += new System.EventHandler(this.elvw_Images_DoubleClick);
            // 
            // ch_FileName
            // 
            this.ch_FileName.Text = "Name";
            this.ch_FileName.Width = 200;
            // 
            // ch_Date
            // 
            this.ch_Date.Text = "Date";
            this.ch_Date.Width = 150;
            // 
            // ch_FileType
            // 
            this.ch_FileType.Text = "Type";
            this.ch_FileType.Width = 100;
            // 
            // ch_FileSize
            // 
            this.ch_FileSize.Text = "Size";
            this.ch_FileSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ch_FileSize.Width = 100;
            // 
            // tsddb_tb_AddRemove
            // 
            this.tsddb_tb_AddRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddb_tb_AddRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsddb_tb_AddRemove.Image")));
            this.tsddb_tb_AddRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddb_tb_AddRemove.Name = "tsddb_tb_AddRemove";
            this.tsddb_tb_AddRemove.Size = new System.Drawing.Size(134, 22);
            this.tsddb_tb_AddRemove.Text = "Add or Remove Buttons";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(634, 323);
            this.Controls.Add(this.tsc_Main);
            this.Controls.Add(this.ss_Main);
            this.Controls.Add(this.ms_Main);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.ms_Main;
            this.MinimumSize = new System.Drawing.Size(400, 350);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Comic Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ms_Main.ResumeLayout(false);
            this.ms_Main.PerformLayout();
            this.cms_ImageListView.ResumeLayout(false);
            this.ss_Main.ResumeLayout(false);
            this.ss_Main.PerformLayout();
            this.tsc_Main.ContentPanel.ResumeLayout(false);
            this.tsc_Main.TopToolStripPanel.ResumeLayout(false);
            this.tsc_Main.TopToolStripPanel.PerformLayout();
            this.tsc_Main.ResumeLayout(false);
            this.tsc_Main.PerformLayout();
            this.sc_Explorer.Panel1.ResumeLayout(false);
            this.sc_Explorer.Panel1.PerformLayout();
            this.sc_Explorer.Panel2.ResumeLayout(false);
            this.sc_Explorer.ResumeLayout(false);
            this.cms_ExplorerTreeView.ResumeLayout(false);
            this.ts_etvw_Tools.ResumeLayout(false);
            this.ts_etvw_Tools.PerformLayout();
            this.cms_Docking.ResumeLayout(false);
            this.sc_Tasks.Panel1.ResumeLayout(false);
            this.sc_Tasks.Panel2.ResumeLayout(false);
            this.sc_Tasks.Panel2.PerformLayout();
            this.sc_Tasks.ResumeLayout(false);
            this.sc_ImageList.Panel1.ResumeLayout(false);
            this.sc_ImageList.Panel1.PerformLayout();
            this.sc_ImageList.Panel2.ResumeLayout(false);
            this.sc_ImageList.Panel2.PerformLayout();
            this.sc_ImageList.ResumeLayout(false);
            this.cms_ImageBox.ResumeLayout(false);
            this.ts_imgbx_Tools.ResumeLayout(false);
            this.ts_imgbx_Tools.PerformLayout();
            this.tlp_ImageBoxTools.ResumeLayout(false);
            this.tlp_ImageBoxTools.PerformLayout();
            this.cms_ExplorerListView.ResumeLayout(false);
            this.ts_elvw_Tools.ResumeLayout(false);
            this.ts_elvw_Tools.PerformLayout();
            this.ts_task_Tools.ResumeLayout(false);
            this.ts_task_Tools.PerformLayout();
            this.cms_Tasks.ResumeLayout(false);
            this.ts_Toolbar.ResumeLayout(false);
            this.ts_Toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip ms_Main;
        private System.Windows.Forms.StatusStrip ss_Main;
        private System.Windows.Forms.ToolStripContainer tsc_Main;
        private System.Windows.Forms.ToolStrip ts_Toolbar;
        private System.Windows.Forms.ToolStripButton tsb_tb_Open;
        private System.Windows.Forms.SplitContainer sc_Explorer;
        private System.Windows.Forms.SplitContainer sc_ImageList;
        private System.Windows.Forms.ToolStrip ts_etvw_Tools;
        private System.Windows.Forms.ToolStrip ts_elvw_Tools;
        private Controls.Library.ExplorerListView elvw_Images;
        private System.Windows.Forms.ToolStripMenuItem tsmi_File;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Edit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_View;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Tools;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Info;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_Open;
        private System.Windows.Forms.ToolStripSeparator tss_file_01;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_SaveAs;
        private System.Windows.Forms.ToolStripSeparator tss_file_02;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_Print;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_PrintPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_PageSetup;
        private System.Windows.Forms.ToolStripSeparator tss_file_03;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_Properties;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_Exit;
        private System.Windows.Forms.TableLayoutPanel tlp_ImageBoxTools;
        private Controls.Library.ImageBox imgbx_MainImage;
        private System.Windows.Forms.ToolStrip ts_imgbx_Tools;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Help;
        private System.Windows.Forms.ToolStripSeparator tss_file_04;
        private System.Windows.Forms.ToolStripMenuItem tsmi_help_Documentation;
        private System.Windows.Forms.ToolStripSeparator tss_help_01;
        private System.Windows.Forms.ToolStripMenuItem tsmi_help_CheckUpdates;
        private System.Windows.Forms.ToolStripMenuItem tsmi_help_Donation;
        private System.Windows.Forms.ToolStripMenuItem tsmi_help_Codeplex;
        private System.Windows.Forms.ToolStripSeparator tss_help_02;
        private System.Windows.Forms.ToolStripMenuItem tsmi_help_About;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Copy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Delete;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Rename;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Paste;
        private System.Windows.Forms.ContextMenuStrip cms_ImageBox;
        private System.Windows.Forms.ToolStripMenuItem tsmi_imgbx_Copy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_imgbx_Paste;
        private System.Windows.Forms.ToolStripMenuItem tsmi_imgbx_Delete;
        private System.Windows.Forms.ToolStripMenuItem tsmi_imgbx_Rename;
        private System.Windows.Forms.ToolStripSeparator tss_imgbx_03;
        private System.Windows.Forms.ToolStripMenuItem tsmi_imgbx_AutoScale;
        private System.Windows.Forms.ToolStripSeparator tss_imgbx_04;
        private System.Windows.Forms.ToolStripMenuItem tsmi_imgbx_Properties;
        private System.Windows.Forms.ToolStripMenuItem tsmi_imgbx_SetBackGround;
        private System.Windows.Forms.ToolStripSeparator tss_imgbx_05;
        private System.Windows.Forms.ToolStripButton tsb_tb_Save;
        private System.Windows.Forms.ToolStripSplitButton tssb_tb_Print;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tb_PageSetup;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tb_PrintPreview;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tb_Print;
        private System.Windows.Forms.ToolStripSeparator tss_view_01;
        private System.Windows.Forms.ToolStripMenuItem tsmi_view_Toolbar;
        private System.Windows.Forms.ToolStripMenuItem tsmi_view_StatusBar;
        private System.Windows.Forms.ToolStripSeparator tss_view_02;
        private System.Windows.Forms.SplitContainer sc_Tasks;
        private System.Windows.Forms.ToolStrip ts_task_Tools;
        private System.Windows.Forms.ToolStripButton tsb_task_Close;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_task_Dock;
        private System.Windows.Forms.ToolStripButton tsb_elvw_Close;
        private System.Windows.Forms.ToolStripButton tsb_etvw_Close;
        private System.Windows.Forms.ToolStripMenuItem tsmi_imgbx_CenterImage;
        private System.Windows.Forms.ToolStripMenuItem tsmi_imgbx_StretchImage;
        private System.Windows.Forms.ToolStripMenuItem tsmi_imgbx_TileImage;
        private System.Windows.Forms.ToolStripMenuItem tsmi_view_Explorer;
        private System.Windows.Forms.ToolStripMenuItem tsmi_view_ImageList;
        private System.Windows.Forms.ToolStripMenuItem tsmi_view_Task;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_Favourite;
        private System.Windows.Forms.ContextMenuStrip cms_ExplorerListView;
        private System.Windows.Forms.ToolStripMenuItem tsmi_elvw_Copy;
        private System.Windows.Forms.ToolStripMenuItem tsmi_elvw_Delete;
        private System.Windows.Forms.ToolStripMenuItem tsmi_elvw_Rename;
        private System.Windows.Forms.ToolStripSeparator tss_elvw_02;
        private System.Windows.Forms.ToolStripMenuItem tsmi_elvw_CopyPath;
        private System.Windows.Forms.ToolStripMenuItem tsmi_elvw_OpenContainingFolder;
        private System.Windows.Forms.ToolStripSeparator tss_tb_01;
        private System.Windows.Forms.ToolStripSeparator tss_tb_03;
        private Controls.Library.AquaButton btn_nav_FirstImage;
        private Controls.Library.AquaButton btn_nav_PreviousImage;
        private Controls.Library.AquaButton btn_nav_NextImage;
        private Controls.Library.AquaButton btn_nav_LastImage;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_elvw_Dock;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_etvw_Dock;
        private System.Windows.Forms.ContextMenuStrip cms_Docking;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dock_DockWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dock_FloatingWindow;
        private System.Windows.Forms.ToolStripSeparator tsb_tb_02;
        private System.Windows.Forms.ToolStripButton tsb_tb_ExplorerWindow;
        private System.Windows.Forms.ToolStripButton tsb_tb_ImageListWindow;
        private System.Windows.Forms.Label lbl_ImageIndexDisplay;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_Save;
        private System.Windows.Forms.ToolStripButton tsb_tb_RotateLeft90;
        private System.Windows.Forms.ToolStripButton tsb_tb_RotateRight90;
        private System.Windows.Forms.ToolStripSeparator tss_tb_04;
        private System.Windows.Forms.ToolStripMenuItem tsmi_help_VisitHome;
        private System.Windows.Forms.ToolStripMenuItem tsmi_dock_Hide;
        private System.Windows.Forms.ImageList imgl_SmallImageList;
        private System.Windows.Forms.ToolStripSeparator tss_view_03;
        private System.Windows.Forms.ToolStripMenuItem tsmi_view_ImageListView;
        private System.Windows.Forms.ToolStripMenuItem tsmi_view_Refresh;
        private System.Windows.Forms.ToolStripStatusLabel tssl_MousePosition;
        private System.Windows.Forms.ToolStripStatusLabel tssl_ImageDimensions;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Undo;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Redo;
        private System.Windows.Forms.ToolStripSeparator tss_edit_01;
        private System.Windows.Forms.ToolStripLabel tsl_elvw_ItemInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_NewFavourite;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_AddFavourite;
        private System.Windows.Forms.ToolStripButton tsb_tb_AddFavourite;
        private System.Windows.Forms.ToolStripSeparator tss_tools_01;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tools_Options;
        private System.Windows.Forms.ToolStripMenuItem tsmi_view_Windows;
        private System.Windows.Forms.ToolStripMenuItem tsmi_win_OpenNew;
        private System.Windows.Forms.ToolStripMenuItem tsmi_win_CloseAll;
        private System.Windows.Forms.ToolStripSeparator tss_win_01;
        private System.Windows.Forms.ContextMenuStrip cms_ExplorerTreeView;
        private System.Windows.Forms.ToolStripMenuItem tsmi_etvw_RemoveFavourite;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tools_ScreenCapture;
        private System.Windows.Forms.ToolStripSeparator tss_tools_02;
        private System.Windows.Forms.ToolStripMenuItem tsmi_elvw_SelectAll;
        private System.Windows.Forms.ToolStripSeparator tss_elvw_03;
        private System.Windows.Forms.ToolStripMenuItem tsmi_etvw_NewFavourite;
        private System.Windows.Forms.ToolStripSeparator tss_help_03;
        private System.Windows.Forms.ToolStripButton tsb_tb_EyeDropper;
        private System.Windows.Forms.ToolStripSeparator tss_tb_05;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tools_EyeDropper;
        private System.Windows.Forms.ToolStripLabel tsl_tb_PixelInfo;
        private System.Windows.Forms.Panel pan_TasksContainer;
        private System.Windows.Forms.ToolStripDropDownButton tsddb_task_Tasks;
        private System.Windows.Forms.ContextMenuStrip cms_Tasks;
        private System.Windows.Forms.ToolStripMenuItem tsmi_task_Properties;
        private System.Windows.Forms.ToolStripMenuItem tsmi_task_Crop;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Filters;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tools_BatchEditor;
        private System.Windows.Forms.ToolStripSeparator tss_tools_03;
        private System.Windows.Forms.ToolStripMenuItem tsmi_filter_Invert;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_ClearChanges;
        private System.Windows.Forms.ToolStripMenuItem tsmi_etvw_RefreshDevices;
        private System.Windows.Forms.ToolStripMenuItem tsmi_etvw_EditFavourite;
        private System.Windows.Forms.ToolStripMenuItem tsmi_etvw_RemoveAllFavourites;
        private System.Windows.Forms.ToolStripMenuItem tsmi_task_RedEyeCorrection;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tools_RedEyeCorrection;
        private System.Windows.Forms.ToolStripSeparator tss_task_01;
        private System.Windows.Forms.ToolStripMenuItem tsmi_elvw_View;
        private System.Windows.Forms.ToolStripSeparator tss_elvw_04;
        private System.Windows.Forms.ContextMenuStrip cms_ImageListView;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ilvw_LargeIcons;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ilvw_MediumIcons;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ilvw_SmallIcons;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ilvw_List;
        private System.Windows.Forms.ToolStripMenuItem tsmi_ilvw_Details;
        private System.Windows.Forms.ToolStripSeparator tss_edit_02;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_SelectAll;
        private System.Windows.Forms.ToolStripMenuItem tsmi_task_Resize;
        private System.Windows.Forms.ColumnHeader ch_FileName;
        private System.Windows.Forms.ColumnHeader ch_FileType;
        private System.Windows.Forms.ColumnHeader ch_FileSize;
        private System.Windows.Forms.ColumnHeader ch_Date;
        private System.Windows.Forms.ToolStripMenuItem tsmi_filter_GreyScale;
        private System.Windows.Forms.ToolStripMenuItem tsmi_filter_BrightnessContrast;
        private System.Windows.Forms.ToolStripMenuItem tsmi_filter_Transparency;
        private System.Windows.Forms.ToolStripMenuItem tsmi_filter_ColourBalance;
        private System.Windows.Forms.ToolStripMenuItem tsmi_filter_PhotoCopy;
        private System.Windows.Forms.ToolStripSeparator tss_filter_01;
        private System.Windows.Forms.ToolStripMenuItem tsmi_filter_Gamma;
        private System.Windows.Forms.ToolStripSeparator tss_edit_03;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Transform;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Rotate90Clockwise;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Rotate90CounterClockwise;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Rotate180;
        private System.Windows.Forms.ToolStripSeparator tss_edit_04;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_FlipHorizontal;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_FlipVertical;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_FreeTransform;
        private System.Windows.Forms.ToolStripSeparator tss_tb_06;
        private Controls.Library.ToolStripAddRemoveButton tsddb_tb_AddRemove;
        private Controls.Library.ToolStripDirectoryButton tsddb_imgbx_Directorys;
        private System.Windows.Forms.ToolStripComboBox tscbx_tb_Zoom;
        private System.Windows.Forms.ToolStripSplitButton tsb_tb_TasksWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tools_ContactSheet;
        private System.Windows.Forms.ToolStripMenuItem tsmi_help_ReadMe;
        private System.Windows.Forms.ToolStripSeparator tss_help_04;
        private System.Windows.Forms.ToolStripSeparator tss_file_05;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tools_AdjustTime;
        private System.Windows.Forms.ToolStripMenuItem tsmi_filter_RotateColour;
        private System.Windows.Forms.ToolStripMenuItem tsmi_view_SlideShow;
        private System.Windows.Forms.ToolStripSeparator tss_view_04;
        private System.Windows.Forms.ToolStripButton tsb_tb_SlideShow;
        private System.Windows.Forms.ToolStripSeparator tss_tb_07;
        private System.Windows.Forms.ToolStripMenuItem tsmi_FullScreen;
        private System.Windows.Forms.ToolStripMenuItem tsmi_view_FullScreen;
        private System.Windows.Forms.ToolStripSeparator tss_view_05;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Exit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_tools_CreateSlideShow;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_OpenImageFile;
        private System.Windows.Forms.ToolStripMenuItem tsmi_file_OpenSlideShowFile;
        private System.Windows.Forms.ToolStripMenuItem tsmi_task_Shear;
        private System.Windows.Forms.ToolStripSeparator tss_task_02;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Resize;
        private System.Windows.Forms.ToolStripMenuItem tsmi_edit_Shear;
        private System.Windows.Forms.ToolStripSeparator tss_edit_05;
        private System.Windows.Forms.ToolStripMenuItem tsmi_filter_Noise;
        private Controls.Library.ExplorerTreeView etvw_Directorys;


    }
}

