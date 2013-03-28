//::///////////////////////////////////////////////////////////////////////////
//:: File Name: MainWindowSubs.cs
//::///////////////////////////////////////////////////////////////////////////
/*
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 * 
 */
//::///////////////////////////////////////////////////////////////////////////
//:: Contact: sdaily2004@hotmail.com 
//:: Created By: Stephen Daily
//:: Created On: 29 October 2010
//:: Copyright © 2011 Stephen Daily
//::///////////////////////////////////////////////////////////////////////////
//:: Pre Processor Directives
//::///////////////////////////////////////////////////////////////////////////
#define DEBUG_DATA
#define DEVELOPER_VERSION
#define END_USER_VERSION
//::///////////////////////////////////////////////////////////////////////////
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using IView.Controls.Data;
using IView.Controls.Library;
using IView.Engine.ColourTables;
using IView.Engine.Core;
using IView.Engine.Data;
using IView.Engine.Processing;
using IView.UI.Data;
using ComicDownloader.Properties;

//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides the main iView.NET user interface.
    /// </summary>
    public partial class MainWindow
    {
        #region Field and properties

        private const int WM_DEVICECHANGE = 0x219;       // Windows message, device change.
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;

        private const int ICON_LARGE_WIDTH = 120;               // Large icon width.
        private const int ICON_LARGE_HEIGHT = 90;                // Large icon height.
        private const int ICON_MEDIUM_WIDTH = 100;               // Medium icon width.
        private const int ICON_MEDIUM_HEIGHT = 62;                // Medium icon height.
        private const int ICON_SMALL_WIDTH = 50;                // Small icon width.
        private const int ICON_SMALL_HEIGHT = 42;                // Small icon height.

        private const int LVW_ICON_L_W = ICON_LARGE_WIDTH + 5;  // Large icon width with padding.
        private const int LVW_ICON_L_H = ICON_LARGE_HEIGHT + 35; // Large icon height with padding.
        private const int LVW_ICON_M_W = ICON_MEDIUM_WIDTH + 10; // Medium icon width with padding.
        private const int LVW_ICON_M_H = ICON_MEDIUM_HEIGHT + 40; // Medium icon height with padding.
        private const int LVW_ICON_S_W = ICON_SMALL_WIDTH + 30; // Small icon width with padding.
        private const int LVW_ICON_S_H = ICON_SMALL_HEIGHT + 50; // Small icon height with paddig.

        private bool m_bImageEdited;
        private bool m_bShowNoUpdatesFoundDialog;
        private int m_nLastOpenFileIndex;
        private int m_nLastSaveFileIndex;
        private string m_sLastFileOpenedName;
        private string m_sBeforeLabelEditText;
        private Keys m_nImageBoxKeyPressed;
        private Tool m_nCurrentTool;
        private ImageScale m_nImageScale;
        private ImageListViewType m_nImageListViewType;
        private Window m_nSelectedWindow;
        private TaskWindow m_nSelectedTaskWindow;
        private ImageBrowser m_oImageBrowser;
        private PrintDocument m_oPrintDocument;
        private PropertiesPanel m_oPropertiesPanel;
        private RedEyePanel m_oRedEyePanel;
        private ResizePanel m_oResizePanel;
        private ShearPanel m_oShearPanel;
        private FavouritesCollection m_oFavourites;
        private ImageEditManagement m_oUndoRedo;
        private DockingWindow m_oTaskDockWindow;
        private DockingWindow m_oImageListDockWindow;
        private DockingWindow m_oExplorerDockWindow;
        private NewWindow m_oNewWindowForm;
        private SlideShow m_oSlideShowForm;
        private ScreenShot m_oScreenShotForm;
        private FormPixelColour m_oFormPixelColour;
        private ToolStripMenuItem m_oItem;
        private List<NewWindow> m_oNewWindows;

        /// <summary>
        /// Get or set a value indicating whether the current image has been edited in some way.
        /// This property also appends or removes a character from the end of the forms text property
        /// showing that changes have been made to the image.
        /// </summary>
        /// <returns></returns>
        private bool ImageHasBeenEdited
        {
            get { return m_bImageEdited; }
            set
            {
                if (!string.IsNullOrEmpty(this.Text))
                {
                    if (!value)
                        this.Text = this.Text.TrimEnd(new char[] { '*' });
                    else
                    {
                        if (!this.Text.Contains("*"))
                            this.Text += "*";
                    }
                }

                m_bImageEdited = value;
            }
        }

        /// <summary>
        /// Gets or sets the explorer splitter panel collapsed state.
        /// </summary>
        private bool ExplorerSplitterPanelCollapsed
        {
            get { return sc_Explorer.Panel1Collapsed; }
            set
            {
                sc_Explorer.Panel1Collapsed = value;

                if ((value == true) && (m_oExplorerDockWindow.IsDocked))
                {
                    tsddb_imgbx_Directorys.Enabled = true;
                    tsddb_imgbx_Directorys.ShowDropDownArrow = true;
                }
                else
                {
                    tsddb_imgbx_Directorys.Enabled = false;
                    tsddb_imgbx_Directorys.ShowDropDownArrow = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the task splitter panel collapsed state.
        /// </summary>
        private bool TaskSplitterPanelCollapsed
        {
            get { return sc_Tasks.Panel2Collapsed; }
            set { sc_Tasks.Panel2Collapsed = value; }
        }

        /// <summary>
        /// Gets or sets the image list splitter panel collapsed state.
        /// </summary>
        private bool ImageListSplitterPanelCollapsed
        {
            get { return sc_ImageList.Panel2Collapsed; }
            set { sc_ImageList.Panel2Collapsed = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        private Tool CurrentTool
        {
            get { return m_nCurrentTool; }
            set
            {
                m_nCurrentTool = value;
            }
        }

        /// <summary>
        /// Gets the explorer splitter panel.
        /// </summary>
        private SplitterPanel ExplorerSplitterPanel
        {
            get { return sc_Explorer.Panel1; }
        }

        /// <summary>
        /// Gets the task splitter panel.
        /// </summary>
        private SplitterPanel TaskSplitterPanel
        {
            get { return sc_Tasks.Panel2; }
        }

        /// <summary>
        /// Gets the image list splitter panel.
        /// </summary>
        private SplitterPanel ImageListSplitterPanel
        {
            get { return sc_ImageList.Panel2; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Configures the application when the form has been initialized.
        /// </summary>
        /// <returns></returns>
        private void ConfigureApplication()
        {
            // Form designer code initialization.
            InitializeComponent();

            // Make sure certain field members get initialized.
            m_nImageBoxKeyPressed = Keys.None;
            m_nCurrentTool = Tool.None;
            m_nSelectedWindow = Window.None;
            m_nSelectedTaskWindow = IViewSettings.Default.SelectedTaskWindow;
            m_nImageScale = IViewSettings.Default.AutoScale;
            m_nImageListViewType = IViewSettings.Default.ImageListViewType;
            m_oUndoRedo = new ImageEditManagement(IViewSettings.Default.MaxUndos);
            m_oFavourites = new FavouritesCollection(IViewSettings.Default.Favourites);
            m_oNewWindows = new List<NewWindow>();

            // Initialize a new instance of the ImageBrowser class.
            m_oImageBrowser = new ImageBrowser();
            m_oImageBrowser.MaxFiles = IViewSettings.Default.MaxFiles;
            m_oImageBrowser.MaxFileLength = IViewSettings.Default.MaxFileLength;
            m_oImageBrowser.HighQualityThumbnails = IViewSettings.Default.HighQualityThumbnails;
            m_oImageBrowser.Effect = IViewSettings.Default.ThumbnailEffect;
            m_oImageBrowser.FileRenamed +=
                new EventHandler<ImageBrowserRenameEventArgs>(ImageBrowser_FileRenamed);
            m_oImageBrowser.ItemRemoved +=
                new EventHandler<ImageBrowserItemEventArgs>(ImageBrowser_ItemRemoved);

            // Initialize a new docking window for the explorer.
            Rectangle WndRect = IViewSettings.Default.ExplorerWindowRect;
            m_oExplorerDockWindow = new DockingWindow(WndRect, ExplorerSplitterPanel,
                new Control[] { etvw_Directorys, ts_etvw_Tools });
            m_oExplorerDockWindow.Name = "ExplorerDockingWindow";
            m_oExplorerDockWindow.Text = "Explorer";
            m_oExplorerDockWindow.DockChanged +=
                new EventHandler<DockChangedEventArgs>(DockingWindow_DockChanged);

            // Initialize a new docking window for the image list.
            WndRect = IViewSettings.Default.ImageListWindowRect;
            m_oImageListDockWindow = new DockingWindow(WndRect, ImageListSplitterPanel,
                new Control[] { elvw_Images, ts_elvw_Tools });
            m_oImageListDockWindow.Name = "ImageListDockingWindow";
            m_oImageListDockWindow.Text = "Image List";
            m_oImageListDockWindow.DockChanged +=
                new EventHandler<DockChangedEventArgs>(DockingWindow_DockChanged);

            // Initialize a new docking window for the task panel.
            WndRect = IViewSettings.Default.TasksWindowRect;
            m_oTaskDockWindow = new DockingWindow(WndRect, TaskSplitterPanel,
                new Control[] { pan_TasksContainer, ts_task_Tools });
            m_oTaskDockWindow.Name = "TaskDockingWindow";
            m_oTaskDockWindow.Text = "Tasks";
            m_oTaskDockWindow.DockChanged +=
                new EventHandler<DockChangedEventArgs>(DockingWindow_DockChanged);

            // Initialize the PropertiesPanel.
            m_oPropertiesPanel = new PropertiesPanel();
            m_oPropertiesPanel.Dock = DockStyle.Fill;
            m_oPropertiesPanel.HistogramAutoRefresh = IViewSettings.Default.AutoRefreshHistogram;
            m_oPropertiesPanel.HistogramVisible = IViewSettings.Default.HistogramVisible;
            m_oPropertiesPanel.PropertiesToolbarVisible = IViewSettings.Default.PropertiesToolbarVisible;
            m_oPropertiesPanel.PropertiesHelpVisible = IViewSettings.Default.PropertiesHelpVisible;
            int nDist = m_oPropertiesPanel.Height - IViewSettings.Default.HistogramHeight;
            m_oPropertiesPanel.SplitterDistance = (nDist > 0 && nDist < m_oPropertiesPanel.Height) ? nDist : 100;
            m_oPropertiesPanel.HistogramUpdateRequested += delegate(object sender, EventArgs e)
            {
                if (imgbx_MainImage.IsImageLoaded)
                    m_oPropertiesPanel.ProcessImage((Bitmap)imgbx_MainImage.ImageBoxImage);
            };

            // Initialize the ResizePanel.
            m_oResizePanel = new ResizePanel();
            m_oResizePanel.Dock = DockStyle.Fill;
            m_oResizePanel.Enabled = false;
            m_oResizePanel.ApplyButtonClicked += delegate(object sender, EventArgs e)
            {
                SubResizeImage();
            };

            // Initialize the ShearPanel.
            m_oShearPanel = new ShearPanel();
            m_oShearPanel.Dock = DockStyle.Fill;
            m_oShearPanel.Enabled = false;
            m_oShearPanel.ApplyButtonClicked += delegate(object sender, EventArgs e)
            {
                SubShearImage();
            };

            // Initialize the RedEyePanel.
            m_oRedEyePanel = new RedEyePanel();
            m_oRedEyePanel.Dock = DockStyle.Fill;
            m_oRedEyePanel.Enabled = false;
            m_oRedEyePanel.PupilSizeMinimum = 1;
            m_oRedEyePanel.PupilSizeMaximium = 64;
            m_oRedEyePanel.PupilSize = 32;
            m_oRedEyePanel.ActivateClick += delegate(object sender, EventArgs e)
            {
                m_nCurrentTool = Tool.RedEyeCorrection;
            };

            ProfessionalColorTable oColourTable = new ProfessionalColorTable();

            // Assign a custom colour table if specified.
            if (IViewSettings.Default.ColourTable == ColourTable.ArcticSilver)
                oColourTable = new ArcticSilverColourTable();
            else if (IViewSettings.Default.ColourTable == ColourTable.SkyBlue)
                oColourTable = new SkyBlueColourTable();

            // Create and assign a toolstrip renderer with the specified colour table to the toolstrip manager.
            ToolStripProfessionalRenderer oRenderer = new ToolStripProfessionalRenderer(oColourTable);
            ToolStripManager.Renderer = oRenderer;

            // Create another toolstrip renderer but remove the rounded edges.
            oRenderer = new ToolStripProfessionalRenderer(oColourTable);
            oRenderer.RoundedEdges = false;

            // Apply the toolstrip renderer without rounded edges to the smaller toolstrips.
            ts_elvw_Tools.Renderer = oRenderer;
            ts_etvw_Tools.Renderer = oRenderer;
            ts_task_Tools.Renderer = oRenderer;
            ts_imgbx_Tools.Renderer = oRenderer;

            // Set the toolstrip overflow button properties.
            ts_Toolbar.OverflowButton.AutoToolTip = true;
            ts_Toolbar.OverflowButton.DropDownDirection = ToolStripDropDownDirection.BelowRight;
            ts_Toolbar.OverflowButton.ToolTipText = "Toolbar Options";

            // Put the add or remove button on the overflow. VS will cash if implemented at design time.
            tsddb_tb_AddRemove.Overflow = ToolStripItemOverflow.Always;

            // Set the main toolbar and status bar visibility.
            ts_Toolbar.Visible = IViewSettings.Default.ToolbarVisible;
            ss_Main.Visible = IViewSettings.Default.StatusStripVisible;

            // Send the main toolstrip to the specified parent container.
            if (IViewSettings.Default.ToolBarPanel == ToolBarPanel.Top)
                ts_Toolbar.Parent = tsc_Main.TopToolStripPanel;
            else if (IViewSettings.Default.ToolBarPanel == ToolBarPanel.Bottom)
                ts_Toolbar.Parent = tsc_Main.BottomToolStripPanel;
            else if (IViewSettings.Default.ToolBarPanel == ToolBarPanel.Left)
                ts_Toolbar.Parent = tsc_Main.LeftToolStripPanel;
            else if (IViewSettings.Default.ToolBarPanel == ToolBarPanel.Right)
                ts_Toolbar.Parent = tsc_Main.RightToolStripPanel;

            // Configure the forms DesktopBounds property.
            this.DesktopBounds = IViewSettings.Default.MainWindowRect;

            // Configure the state of the main window.
            if (IViewSettings.Default.MainWindowState == MainWindowState.FullScreen)
                SubToggleFullScreenMode();
            else if (IViewSettings.Default.MainWindowState == MainWindowState.Maximized)
                this.WindowState = FormWindowState.Maximized;

            // Set the explorer splitter bar distance.
            nDist = IViewSettings.Default.ExplorerSplitterDist;
            sc_Explorer.SplitterDistance = (nDist > 0 && nDist < (sc_Explorer.Width - sc_Explorer.Panel2MinSize))
                ? nDist : sc_Explorer.Width / 2;

            // Set the image list splitter bar distance.
            nDist = sc_ImageList.Height - IViewSettings.Default.ImageListSplitterDist;
            sc_ImageList.SplitterDistance = (nDist > 0 && nDist < (sc_ImageList.Height - sc_ImageList.Panel2MinSize))
                ? nDist : sc_ImageList.Height / 2;

            // Set the tasks splitter bar distance.
            nDist = sc_Tasks.Width - IViewSettings.Default.TasksSplitterDist;
            sc_Tasks.SplitterDistance = (nDist > 0 && nDist < (sc_Tasks.Width - sc_Tasks.Panel2MinSize))
                ? nDist : sc_Tasks.Width / 2;

            // Configure the dock or collapse state of the explorer window.
            if (!IViewSettings.Default.ExplorerDocked)
                m_oExplorerDockWindow.UnDock(this);
            else
                ExplorerSplitterPanelCollapsed = IViewSettings.Default.ExplorerCollapsed;

            // Configure the dock or collapse state of the image list window.
            if (!IViewSettings.Default.ImageListDocked)
                m_oImageListDockWindow.UnDock(this);
            else
                ImageListSplitterPanelCollapsed = IViewSettings.Default.ImageListCollapsed;

            // Configure the dock or collapse state of the tasks window.
            if (!IViewSettings.Default.TasksDocked)
                m_oTaskDockWindow.UnDock(this);
            else
                TaskSplitterPanelCollapsed = IViewSettings.Default.TasksCollapsed;

            // Configure the explorerlistview, view.
            switch (IViewSettings.Default.ImageListViewType)
            {
                case ImageListViewType.LargeIcons:
                case ImageListViewType.MediumIcons:
                case ImageListViewType.SmallIcons:
                    elvw_Images.View = View.LargeIcon;
                    break;
                case ImageListViewType.List:
                    elvw_Images.View = View.List;
                    break;
                case ImageListViewType.Details:
                    elvw_Images.View = View.Details;
                    break;
            }

            // Set the width of the explorer listview column headers.
            ch_FileName.Width = IViewSettings.Default.NameColumnWidth;
            ch_Date.Width = IViewSettings.Default.DateColumnWidth;
            ch_FileType.Width = IViewSettings.Default.TypeColumnWidth;
            ch_FileSize.Width = IViewSettings.Default.SizeColumnWidth;

            // Update the imagebox back colour.
            imgbx_MainImage.BackColor = IViewSettings.Default.MainDisplayColour;

            // Add the explorer treeview parent nodes.
            etvw_Directorys.AddBaseNodes();

            // Add the favourite nodes to the treeview.
            SubLoadFavourites();

            // Show the last selected task window.
            SubShowTaskWindow(m_nSelectedTaskWindow, false);

            // Check for updates if specified.
            if (IViewSettings.Default.AutomaticUpdates)
                SubCheckForUpdates(false, false);
        }

        /// <summary>
        /// Saves the users settings to the application settings file.
        /// </summary>
        /// <returns></returns>
        private void SaveSettings()
        {
            // Save the main window state.
            if (this.FormBorderStyle == FormBorderStyle.None)
                IViewSettings.Default.MainWindowState = MainWindowState.FullScreen;
            else
            {
                switch (this.WindowState)
                {
                    case FormWindowState.Normal:
                        IViewSettings.Default.MainWindowRect = this.DesktopBounds;
                        IViewSettings.Default.MainWindowState = MainWindowState.Normal;
                        break;
                    case FormWindowState.Maximized:
                        IViewSettings.Default.MainWindowState = MainWindowState.Maximized;
                        break;
                }
            }

            // Save the toolbar position.
            if (ts_Toolbar.Parent == tsc_Main.TopToolStripPanel)
                IViewSettings.Default.ToolBarPanel = ToolBarPanel.Top;
            else if (ts_Toolbar.Parent == tsc_Main.BottomToolStripPanel)
                IViewSettings.Default.ToolBarPanel = ToolBarPanel.Bottom;
            else if (ts_Toolbar.Parent == tsc_Main.LeftToolStripPanel)
                IViewSettings.Default.ToolBarPanel = ToolBarPanel.Left;
            else if (ts_Toolbar.Parent == tsc_Main.RightToolStripPanel)
                IViewSettings.Default.ToolBarPanel = ToolBarPanel.Right;

            // Save other IViewSettings
            IViewSettings.Default.Favourites = m_oFavourites.ToStringCollection();
            IViewSettings.Default.HistogramVisible = m_oPropertiesPanel.HistogramVisible;
            IViewSettings.Default.AutoRefreshHistogram = m_oPropertiesPanel.HistogramAutoRefresh;
            IViewSettings.Default.PropertiesToolbarVisible = m_oPropertiesPanel.PropertiesToolbarVisible;
            IViewSettings.Default.PropertiesHelpVisible = m_oPropertiesPanel.PropertiesHelpVisible;
            IViewSettings.Default.HistogramHeight = m_oPropertiesPanel.Height - m_oPropertiesPanel.SplitterDistance;
            IViewSettings.Default.NameColumnWidth = ch_FileName.Width;
            IViewSettings.Default.DateColumnWidth = ch_Date.Width;
            IViewSettings.Default.TypeColumnWidth = ch_FileType.Width;
            IViewSettings.Default.SizeColumnWidth = ch_FileSize.Width;
            IViewSettings.Default.SelectedTaskWindow = m_nSelectedTaskWindow;
            IViewSettings.Default.ExplorerWindowRect = m_oExplorerDockWindow.WindowBounds;
            IViewSettings.Default.ImageListWindowRect = m_oImageListDockWindow.WindowBounds;
            IViewSettings.Default.TasksWindowRect = m_oTaskDockWindow.WindowBounds;
            IViewSettings.Default.TasksDocked = m_oTaskDockWindow.IsDocked;
            IViewSettings.Default.ImageListDocked = m_oImageListDockWindow.IsDocked;
            IViewSettings.Default.ExplorerDocked = m_oExplorerDockWindow.IsDocked;
            IViewSettings.Default.StatusStripVisible = ss_Main.Visible;
            IViewSettings.Default.ToolbarVisible = ts_Toolbar.Visible;
            IViewSettings.Default.AutoScale = m_nImageScale;
            IViewSettings.Default.ImageListViewType = m_nImageListViewType;

            IViewSettings.Default.ExplorerSplitterDist = sc_Explorer.SplitterDistance;
            IViewSettings.Default.ImageListSplitterDist = sc_ImageList.Height - sc_ImageList.SplitterDistance;
            IViewSettings.Default.TasksSplitterDist = sc_Tasks.Width - sc_Tasks.SplitterDistance;

            IViewSettings.Default.ExplorerCollapsed = ExplorerSplitterPanelCollapsed;
            IViewSettings.Default.ImageListCollapsed = ImageListSplitterPanelCollapsed;
            IViewSettings.Default.TasksCollapsed = TaskSplitterPanelCollapsed;
            IViewSettings.Default.Save();
        }

        /// <summary>
        /// Configures the user interface when the settings have been changed and an update is needed.
        /// </summary>
        private void UpdateChangedSettings()
        {
            ProfessionalColorTable oColourTable = new ProfessionalColorTable();

            // Assign a custom colour table if specified.
            if (IViewSettings.Default.ColourTable == ColourTable.ArcticSilver)
                oColourTable = new ArcticSilverColourTable();
            else if (IViewSettings.Default.ColourTable == ColourTable.SkyBlue)
                oColourTable = new SkyBlueColourTable();

            // Create and assign a toolstrip renderer with the specified colour table to the toolstrip manager.
            ToolStripProfessionalRenderer oRenderer = new ToolStripProfessionalRenderer(oColourTable);
            ToolStripManager.Renderer = oRenderer;

            // Create another toolstrip renderer but remove the rounded edges.
            oRenderer = new ToolStripProfessionalRenderer(oColourTable);
            oRenderer.RoundedEdges = false;

            // Apply the toolstrip renderer without rounded edges to the smaller toolstrips.
            ts_elvw_Tools.Renderer = oRenderer;
            ts_etvw_Tools.Renderer = oRenderer;
            ts_task_Tools.Renderer = oRenderer;
            ts_imgbx_Tools.Renderer = oRenderer;

            // Update the ImageBrowser properties.
            m_oImageBrowser.MaxFiles = IViewSettings.Default.MaxFiles;
            m_oImageBrowser.MaxFileLength = IViewSettings.Default.MaxFileLength;
            m_oImageBrowser.HighQualityThumbnails = IViewSettings.Default.HighQualityThumbnails;
            m_oImageBrowser.Effect = IViewSettings.Default.ThumbnailEffect;

            // Update the imagebox back colour.
            imgbx_MainImage.BackColor = IViewSettings.Default.MainDisplayColour;

            // Update the show listviewitem tooltips.
            elvw_Images.ShowItemToolTips = IViewSettings.Default.ImageListToolTips;

            // Update the listview item spacing.
            AdjustListViewItemSpacing(m_nImageListViewType);
        }

        /// <summary>
        /// Determines whether the print document has been initialized. If not, it will get initialized.
        /// </summary>
        private void InitializePrintDocument()
        {
            if (m_oPrintDocument == null)
            {
                m_oPrintDocument = new PrintDocument();
                m_oPrintDocument.PrintPage +=
                    new PrintPageEventHandler(PrintDocument_PrintPage);
            }
        }

        /// <summary>
        /// Shows the ShowImageEditedDialog dialog, this allows the user to cancel the action,
        /// carry on or save the changes back to the current file.
        /// </summary>
        private DialogResult ShowImageEditedDialog()
        {
            // Don't display the image changes dialog if specified by the application IViewSettings
            if (!IViewSettings.Default.ShowImageChangesDialog)
            {
                ImageHasBeenEdited = false;
                return DialogResult.No;
            }

            string sCaption = "Save Changes";
            string sMessage = "Would you like to save the changes made to this image?";

            DialogResult nDlg = MessageBox.Show(sMessage, sCaption,
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            switch (nDlg)
            {
                case DialogResult.Yes:
                    if (SubSaveImage() == SResult.Canceled)
                        return DialogResult.Cancel;
                    break;
                case DialogResult.No:
                    ImageHasBeenEdited = false;
                    break;
            }

            return nDlg;
        }

        /// <summary>
        /// Cleans up all the field members that implement the IDisposable interface.
        /// (This should only be called from the forms dispose method)
        /// </summary>
        /// <param name="bDispose">True to dispose of managed resources.</param>
        /// <returns></returns>
        private void CleanUpResources(bool bDispose)
        {
            if (bDispose)
            {
                // Clean up and release the print document object.
                if (m_oPrintDocument != null)
                {
                    m_oPrintDocument.Dispose();
                    m_oPrintDocument = null;
                }

                // Clean up the ImageEditManagement object.
                if ((m_oUndoRedo != null) && (!m_oUndoRedo.IsDisposed))
                {
                    m_oUndoRedo.Dispose();
                    m_oUndoRedo = null;
                }

                // Clean up the image browser object.
                if ((m_oImageBrowser != null) && (!m_oImageBrowser.IsDisposed))
                {
                    m_oImageBrowser.Dispose();
                    m_oImageBrowser = null;
                }

                // Clean up the explorer docking window object.
                if ((m_oExplorerDockWindow != null) && (!m_oExplorerDockWindow.IsDisposed))
                {
                    m_oExplorerDockWindow.Dispose();
                    m_oExplorerDockWindow = null;
                }

                // Clean up the image list docking window object.
                if ((m_oImageListDockWindow != null) && (!m_oImageListDockWindow.IsDisposed))
                {
                    m_oImageListDockWindow.Dispose();
                    m_oImageListDockWindow = null;
                }

                // Clean up the task docking window object.
                if ((m_oTaskDockWindow != null) && (!m_oTaskDockWindow.IsDisposed))
                {
                    m_oTaskDockWindow.Dispose();
                    m_oTaskDockWindow = null;
                }

                // Clean up the screen shot form.
                if ((m_oScreenShotForm != null) && (!m_oScreenShotForm.IsDisposed))
                {
                    m_oScreenShotForm.Dispose();
                    m_oScreenShotForm = null;
                }

                // Clean up the new window form.
                if ((m_oNewWindowForm != null) && (!m_oNewWindowForm.IsDisposed))
                {
                    m_oNewWindowForm.Dispose();
                    m_oNewWindowForm = null;
                }

                // Clean up the new window list.
                if ((m_oNewWindows != null) && (m_oNewWindows.Count > 0))
                {
                    m_oNewWindows.Clear();
                    m_oNewWindows = null;
                }

                // Clean up the slide show.
                if ((m_oSlideShowForm != null) && (!m_oSlideShowForm.IsDisposed))
                {
                    m_oSlideShowForm.Close();
                    m_oSlideShowForm = null;
                }

                // Clean up the red eye panel.
                if ((m_oRedEyePanel != null) && (!m_oRedEyePanel.IsDisposed))
                {
                    m_oRedEyePanel.Dispose();
                    m_oRedEyePanel = null;
                }

                // Clean up the resize panel.
                if ((m_oResizePanel != null) && (!m_oResizePanel.IsDisposed))
                {
                    m_oResizePanel.Dispose();
                    m_oResizePanel = null;
                }

                // Clean up the properties panel.
                if ((m_oPropertiesPanel != null) && (!m_oPropertiesPanel.IsDisposed))
                {
                    m_oPropertiesPanel.Dispose();
                    m_oPropertiesPanel = null;
                }
            }
        }

        /// <summary>
        /// Adjusts the spacing between the items in the explorer listview control, depending on the
        /// specified ImageListViewType parameter.
        /// </summary>
        /// <param name="nViewType">Specifies the type of spacing that will be applied to the items.</param>
        private void AdjustListViewItemSpacing(ImageListViewType nViewType)
        {
            switch (nViewType)
            {
                case ImageListViewType.LargeIcons:
                    NativeMethods.SetListViewItemSpacing(elvw_Images, LVW_ICON_L_W, LVW_ICON_L_H);
                    break;
                case ImageListViewType.MediumIcons:
                    NativeMethods.SetListViewItemSpacing(elvw_Images, LVW_ICON_M_W, LVW_ICON_M_H);
                    break;
                case ImageListViewType.SmallIcons:
                    NativeMethods.SetListViewItemSpacing(elvw_Images, LVW_ICON_S_W, LVW_ICON_S_H);
                    break;
            }
        }

        /// <summary>
        /// Starts or reuses a local process specified by the file name.
        /// </summary>
        /// <param name="sFileName">Specifies the full name of the file to start or reuse.</param>
        private static void StartProcess(string sFileName)
        {
            try
            {
                if (!string.IsNullOrEmpty(sFileName))
                {
                    using (System.Diagnostics.Process oProcess = new System.Diagnostics.Process())
                    {
                        oProcess.StartInfo.UseShellExecute = true;
                        oProcess.StartInfo.FileName = sFileName;
                        oProcess.Start();
                    }
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show("Unable to start process.\n\nReason: " + ex.Message, "Error Starting Process",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Unable to start process.\n\nReason: " + ex.Message, "Error Starting Process",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region iView.NET Subroutines

        /// <summary>
        /// iView.NET subroutine. Updates the forms controls displaying data about the image.
        /// </summary>
        private SResult SubUpdateControlsOnImageLoad()
        {
            if (!m_oImageBrowser.IsLoaded)
                return SResult.Void;

            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            string sFileName = m_oImageBrowser.ImageInfo.Name;
            Size ImageSize = imgbx_MainImage.ImageBoxImage.Size;

            // Update the forms title.
            this.Text = ApplicationData.ApplicationName + " - "
                + sFileName + ((ImageHasBeenEdited) ? "*" : string.Empty);

            // Update the main toolstrip control.
            tsb_tb_AddFavourite.Enabled = true;
            tsb_tb_Save.Enabled = true;
            tsb_tb_Save.Text = "Save " + sFileName + " (Ctrl+S)";
            tssb_tb_Print.Enabled = true;
            tsb_tb_RotateLeft90.Enabled = true;
            tsb_tb_RotateRight90.Enabled = true;
            tsb_tb_SlideShow.Enabled = true;
            tscbx_tb_Zoom.Enabled = true;

            // Update image box navigation buttons.
            btn_nav_FirstImage.Enabled = true;
            btn_nav_LastImage.Enabled = true;
            btn_nav_NextImage.Enabled = true;
            btn_nav_PreviousImage.Enabled = true;

            // Update the image list selected items info label.
            tsl_elvw_ItemInfo.Text = "Items: " + elvw_Images.Items.Count
                + ", Selected: " + elvw_Images.SelectedItems.Count;
            tsl_elvw_ItemInfo.Visible = true;

            // Update the status strip.
            tssl_ImageDimensions.Text = ImageSize.Width + " x " + ImageSize.Height;
            tssl_ImageDimensions.Visible = true;

            // Update the index display label.
            lbl_ImageIndexDisplay.Text = (m_oImageBrowser.SelectedIndex + 1)
                + " of " + m_oImageBrowser.FileCount;

            // TEMP
            m_oPropertiesPanel.Properties = m_oImageBrowser.ImageInfo;
            m_oPropertiesPanel.ProcessImage(m_oPropertiesPanel.HistogramAutoRefresh ?
                   (Bitmap)imgbx_MainImage.ImageBoxImage : null);

            // TEMP
            m_oResizePanel.OriginalSize = ImageSize;
            m_oResizePanel.Enabled = true;

            // TEMP
            m_oRedEyePanel.Enabled = true;
            m_oShearPanel.Enabled = true;

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Cleans up and resets all field members and controls.
        /// </summary>
        /// <returns></returns>
        /// <param name="bDoEvents">Specifies whether to call the Application.DoEvents() method.</param>
        private SResult SubCleanUpResetUI(bool bDoEvents)
        {
            // Show image edited save dialog if changes have been made.
            if (ImageHasBeenEdited)
            {
                if (ShowImageEditedDialog() == DialogResult.Cancel)
                    return SResult.Canceled;
            }

            // Reset field members.
            m_oImageBrowser.Clear();
            m_oUndoRedo.Clear();
            m_oResizePanel.OriginalSize = Size.Empty;
            m_oResizePanel.Enabled = false;
            m_oRedEyePanel.Enabled = false;
            m_oShearPanel.Enabled = false;
            m_oPropertiesPanel.Reset();

            // Clean up the listview items.
            if (elvw_Images.Items.Count > 0)
                elvw_Images.Items.Clear();

            // Clean up the listview large imagelist.
            if (elvw_Images.LargeImageList != null)
            {
                elvw_Images.LargeImageList.Dispose();
                elvw_Images.LargeImageList = null;
            }

            // Update forms Text property.
            this.Text = ApplicationData.ApplicationName;

            // Update the main toolstrip control.
            tsb_tb_AddFavourite.Enabled = false;
            tsb_tb_Save.Enabled = false;
            tsb_tb_Save.Text = "Save (Ctrl+S)";
            tssb_tb_Print.Enabled = false;
            tsb_tb_RotateLeft90.Enabled = false;
            tsb_tb_RotateRight90.Enabled = false;
            tsb_tb_SlideShow.Enabled = false;
            tscbx_tb_Zoom.Enabled = false;
            tscbx_tb_Zoom.Text = "100.0%";

            // Update image box navigation buttons.
            btn_nav_FirstImage.Enabled = false;
            btn_nav_LastImage.Enabled = false;
            btn_nav_NextImage.Enabled = false;
            btn_nav_PreviousImage.Enabled = false;

            // Update the image box index label.
            lbl_ImageIndexDisplay.Text = "0 of 0";

            // Update explorer list view selected item label.
            tsl_elvw_ItemInfo.Visible = false;
            tsl_elvw_ItemInfo.Text = "Items: 0, Selected: 0";

            // Update the status strip.
            tssl_Info.Text = "Ready";
            tssl_ImageDimensions.Visible = false;

            // Clean up and reset the display image.            
            imgbx_MainImage.ImageBoxVisible = false;
            imgbx_MainImage.ImageBoxImage = null;
            imgbx_MainImage.ImageBoxSize = Size.Empty;

            // Force the application to process it's events if specified.
            if (bDoEvents)
                Application.DoEvents();

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Prompts the user with a dialog choice to confirm whether to exit the application.
        /// </summary>
        /// <returns></returns>
        private SResult SubExit()
        {
            SResult nResult = SubCleanUpResetUI(false);

            if (nResult == SResult.Completed)
                this.Close();

            return nResult;
        }

        /// <summary>
        /// iView.NET subroutine. Opens an OpenFileDialog control, allowing the user to select
        /// a slide show file to open.
        /// </summary>
        /// <returns></returns>
        private SResult SubOpenSlideShow()
        {
            SResult nResult = SResult.Void;

            using (OpenFileDialog oDlg = new OpenFileDialog())
            {
                oDlg.AutoUpgradeEnabled = true;
                oDlg.InitialDirectory = ApplicationData.SlideShowFolder;
                oDlg.Filter = "Slide Show File (*.ssf)|*.ssf";
                oDlg.Title = "Open Slide Show";

                if (oDlg.ShowDialog(this) == DialogResult.OK)
                {
                    if ((m_oSlideShowForm != null) && (!m_oSlideShowForm.IsDisposed))
                        m_oSlideShowForm.Close();

                    // Open the slide show form.
                    m_oSlideShowForm = new SlideShow(oDlg.FileName);
                    m_oSlideShowForm.Show(this);

                    nResult = SResult.Completed;
                }
            }

            return nResult;
        }

        /// <summary>
        /// iView.NET subroutine. Opens an OpenFileDialog control, allowing the user to select
        /// an image file to open.
        /// </summary>
        private SResult SubOpenDirectory()
        {
            SResult nResult = SResult.Void;

            using (OpenFileDialog oFileDlg = new OpenFileDialog())
            {
                oFileDlg.AutoUpgradeEnabled = true;
                oFileDlg.Title = "Open";
                oFileDlg.Filter = Resources.OpenFileFilter;
                oFileDlg.FileName = m_sLastFileOpenedName;
                oFileDlg.FilterIndex = m_nLastOpenFileIndex;

                if (oFileDlg.ShowDialog(this) == DialogResult.OK)
                {
                    string sFilePath = oFileDlg.FileName;
                    string sFileName = Path.GetFileNameWithoutExtension(sFilePath);
                    string sFolderPath = Path.GetDirectoryName(sFilePath);

                    // Update field members.
                    m_nLastOpenFileIndex = oFileDlg.FilterIndex;
                    m_sLastFileOpenedName = sFileName;

                    // Open the specified folder and load the specified image file types.
                    nResult = SubOpenDirectory(sFolderPath, sFilePath, (ImageFileType)m_nLastOpenFileIndex - 1);
                }
                else
                    nResult = SResult.Void;
            }

            return nResult;
        }

        /// <summary>
        /// iView.NET subroutine. Opens the specified directory and loads the specified image files.
        /// </summary>
        /// <param name="sDirectoryPath">Specifies the directory to open.</param>
        /// <param name="sFilePath">The path of the file to open. Specifiying null will get the first image found.</param>
        /// <param name="nImageFileType">Specifies the type of files to look for.</param>
        private SResult SubOpenDirectory(string sDirectoryPath, string sFilePath, ImageFileType nImageFileType)
        {
            SResult nResult = SResult.Void;

            if (!string.IsNullOrEmpty(sDirectoryPath))
            {
                // Clean up any previous data. Return if the method was canceled.
                if (SubCleanUpResetUI(true) == SResult.Canceled)
                    return nResult;

                // Set the cursor to the wait cursor.
                Cursor.Current = Cursors.WaitCursor;

                // Update the directory button.
                tsddb_imgbx_Directorys.SetDirectory(sDirectoryPath);

                try
                {
                    if (m_nImageListViewType == ImageListViewType.LargeIcons)
                    {
                        // Load the images.
                        m_oImageBrowser.ThumbNailSize = new Size(ICON_LARGE_WIDTH, ICON_LARGE_HEIGHT);
                        m_oImageBrowser.LoadImageFiles(sDirectoryPath, nImageFileType, true);

                        // Update the explorer listview.
                        elvw_Images.ShowItemToolTips = IViewSettings.Default.ImageListToolTips;
                        elvw_Images.LargeImageList = m_oImageBrowser.ThumbNailImages;
                    }
                    else if (m_nImageListViewType == ImageListViewType.MediumIcons)
                    {
                        // Load the images.
                        m_oImageBrowser.ThumbNailSize = new Size(ICON_MEDIUM_WIDTH, ICON_MEDIUM_HEIGHT);
                        m_oImageBrowser.LoadImageFiles(sDirectoryPath, nImageFileType, true);

                        // Update the explorer listview.
                        elvw_Images.ShowItemToolTips = IViewSettings.Default.ImageListToolTips;
                        elvw_Images.LargeImageList = m_oImageBrowser.ThumbNailImages;
                    }
                    else if (m_nImageListViewType == ImageListViewType.SmallIcons)
                    {
                        // Load the images.
                        m_oImageBrowser.ThumbNailSize = new Size(ICON_SMALL_WIDTH, ICON_SMALL_HEIGHT);
                        m_oImageBrowser.LoadImageFiles(sDirectoryPath, nImageFileType, true);

                        // Update the explorer listview.
                        elvw_Images.ShowItemToolTips = IViewSettings.Default.ImageListToolTips;
                        elvw_Images.LargeImageList = m_oImageBrowser.ThumbNailImages;
                    }
                    else if (m_nImageListViewType == ImageListViewType.List)
                    {
                        // Load the images.
                        m_oImageBrowser.LoadImageFiles(sDirectoryPath, nImageFileType, false);

                        // Update the explorer listview.
                        elvw_Images.ShowItemToolTips = IViewSettings.Default.ImageListToolTips;
                    }
                    else if (m_nImageListViewType == ImageListViewType.Details)
                    {
                        // Load the images.
                        m_oImageBrowser.LoadImageFiles(sDirectoryPath, nImageFileType, false);

                        // Update the explorer listview.
                        elvw_Images.ShowItemToolTips = false;
                    }

                    if (m_oImageBrowser.FileCount > 0)
                    {
                        // Add the list view items.
                        elvw_Images.BeginUpdate();
                        elvw_Images.Items.AddRange(m_oImageBrowser.GetListViewItems());
                        elvw_Images.EndUpdate();

                        // Adjust the explorer listview item spacing.
                        AdjustListViewItemSpacing(m_nImageListViewType);

                        // Load the image.
                        if (string.IsNullOrEmpty(sFilePath))
                            nResult = SubLoadImage(Navigate.Index, null, 0);
                        else
                            nResult = SubLoadImage(Navigate.Path, sFilePath, 0);
                    }
                    else
                        SubCleanUpResetUI(false);

                    // Reset the cursor.
                    Cursor.Current = Cursors.Default;
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show("Unable to open a directory for viewing.\n\nReason: " + e.Message, "Load Directory Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException e)
                {
                    MessageBox.Show("Unable to open a directory for viewing.\n\nReason: " + e.Message, "Load Directory Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Security.SecurityException e)
                {
                    MessageBox.Show("Unable to open a directory for viewing.\n\nReason: " + e.Message, "Load Directory Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return nResult;
        }

        /// <summary>
        /// iView.NET subroutine. Loads an image from the image browser.
        /// </summary>
        /// <param name="nNavigate">Specifies which way to navigate the list.</param>
        /// <param name="sFilePath">If the Navigate enum is set to Navigate.Path, you can specifiy the file path.</param>
        /// <param name="nIndex">If the Navigate enum is set to Navigate.Index, you can specifiy the item index.</param>
        /// <returns></returns>
        private SResult SubLoadImage(Navigate nNavigate, string sFilePath, int nIndex)
        {
            if ((m_oImageBrowser != null) && (m_oImageBrowser.IsLoaded))
            {
                if (ImageHasBeenEdited)
                {
                    if (ShowImageEditedDialog() == DialogResult.Cancel)
                        return SResult.Void;
                }

                Image oImage = null;

                try
                {
                    switch (nNavigate)
                    {
                        case Navigate.First:
                            oImage = m_oImageBrowser.NavigateImageList(NavigateList.First);
                            break;
                        case Navigate.Next:
                            oImage = m_oImageBrowser.NavigateImageList(NavigateList.Next);
                            break;
                        case Navigate.Previous:
                            oImage = m_oImageBrowser.NavigateImageList(NavigateList.Previous);
                            break;
                        case Navigate.Last:
                            oImage = m_oImageBrowser.NavigateImageList(NavigateList.Last);
                            break;
                        case Navigate.Index:
                            oImage = m_oImageBrowser.GetImageFromIndex(nIndex);
                            break;
                        case Navigate.Path:
                            oImage = m_oImageBrowser.GetImageFromFilePath(sFilePath);
                            break;
                    }

                    if (oImage != null)
                    {
                        // Reset the image scale flag to auto if its currently set to custom.
                        // This prevents the next image from warping.
                        if (m_nImageScale == ImageScale.Custom)
                            m_nImageScale = ImageScale.Auto;

                        // Update the image box.
                        imgbx_MainImage.ImageBoxImage = oImage;
                        imgbx_MainImage.ImageBoxVisible = true;

                        // Clear the undo list.
                        m_oUndoRedo.Clear();

                        return SResult.Completed;
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show("Unable to load the image.\n\nReason: " + e.Message, "Load Image Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException e)
                {
                    MessageBox.Show("Unable to load the image.\n\nReason: " + e.Message, "Load Image Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Security.SecurityException e)
                {
                    MessageBox.Show("Unable to load the image.\n\nReason: " + e.Message, "Load Image Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return SResult.Void;
        }

        /// <summary>
        /// iView.NET subroutine. Saves the current image to the specified type and file path.
        /// Displays a dialog box allowing the user to specify the save settings for the specified ImageFileType.
        /// </summary>
        /// <param name="nFileType">Specifies the type of image file to save.</param>
        /// <param name="sFilePath">Specifies the path of the image file.</param>
        private SResult SubSave(ImageFileType nFileType, string sFilePath)
        {
            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            try
            {
                using (ImageSaver oImageSaver = new ImageSaver(imgbx_MainImage.ImageBoxImage))
                {
                    oImageSaver.FilePath = sFilePath;

                    switch (nFileType)
                    {
                        case ImageFileType.Bmp:
                            using (BmpSettings oForm = new BmpSettings())
                            {
                                if (oForm.ShowDialog(this) == DialogResult.OK)
                                    oImageSaver.SaveAsBmp(oForm.SelectedBitDepth);
                                else
                                    return SResult.Canceled;
                            }
                            break;
                        case ImageFileType.Gif:
                            oImageSaver.SaveAsGif();
                            break;
                        case ImageFileType.Icon:
                            oImageSaver.SaveAsIcon();
                            break;
                        case ImageFileType.Jpeg:
                            using (JpegSettings oForm = new JpegSettings())
                            {
                                if (oForm.ShowDialog(this) == DialogResult.OK)
                                {
                                    oImageSaver.SaveAsJpeg(oForm.Quality,
                                        oForm.PreserveMetadata ? m_oImageBrowser.PropertyItems : null);
                                }
                                else
                                    return SResult.Canceled;
                            }
                            break;
                        case ImageFileType.Png:
                            oImageSaver.SaveAsPng();
                            break;
                        case ImageFileType.Tiff:
                            using (TiffSettings oForm = new TiffSettings())
                            {
                                if (oForm.ShowDialog(this) == DialogResult.OK)
                                {
                                    oImageSaver.SaveAsTiff(oForm.SelectedBitDepth, oForm.SelectedCompression,
                                        oForm.PreserveMetadata ? m_oImageBrowser.PropertyItems : null);
                                }
                                else
                                    return SResult.Canceled;
                            }
                            break;
                    }
                }

                if ((m_nImageListViewType != ImageListViewType.Details) && (m_nImageListViewType != ImageListViewType.List))
                {
                    int nIndex = m_oImageBrowser.GetIndexFromFilePath(sFilePath);

                    if ((nIndex != -1) && (elvw_Images.LargeImageList.Images.Count > nIndex))
                    {
                        // Update the large image list with the current.
                        elvw_Images.LargeImageList.Images[nIndex] = DrawingTools.CreateThumbnail(
                            imgbx_MainImage.ImageBoxImage,
                            elvw_Images.LargeImageList.ImageSize,
                            IViewSettings.Default.HighQualityThumbnails,
                            IViewSettings.Default.ThumbnailEffect);

                        // Redraw the specified image in the image list.
                        elvw_Images.RedrawItems(nIndex, nIndex, false);
                    }
                }

                // Set the save image edited status to false.
                ImageHasBeenEdited = false;

                return SResult.Completed;
            }
            catch (ArgumentNullException e)
            {
                MessageBox.Show("Unable to save the image.\n\nReason: " + e.Message, "Save Image Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show("Unable to save the image.\n\nReason: " + e.Message, "Save Image Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show("Unable to save the image.\n\nReason: " + e.Message, "Save Image Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException e)
            {
                MessageBox.Show("Unable to save the image.\n\nReason: " + e.Message, "Save Image Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return SResult.Void;
        }

        /// <summary>
        /// iView.NET subroutine. Saves the current image back to it's original file. Displays a dialog box allowing
        /// the user to select overwriting options if a file with the same name already exists.
        /// </summary>
        /// <returns></returns>
        private SResult SubSaveImage()
        {
            if (!m_oImageBrowser.IsLoaded)
                return SResult.Void;

            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            string sFilePath = m_oImageBrowser.SelectedFile;

            if (string.IsNullOrEmpty(sFilePath))
                return SResult.InvalidFilePath;

            ImageFileType nFileType = FileTools.GetImageFileType(Path.GetExtension(sFilePath));

            if (File.Exists(sFilePath))
            {
                if (IViewSettings.Default.ShowConfirmOverwriteDialog)
                {
                    string sCaption = "Confirm Save - " + m_oImageBrowser.ImageInfo.Name;
                    string sMessage = "A file with the same name already exists. Would you like to replace it?";

                    DialogResult nDlg = MessageBox.Show(sMessage, sCaption,
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                    switch (nDlg)
                    {
                        case DialogResult.Yes:
                            return SubSave(nFileType, sFilePath);
                        case DialogResult.No:
                            return SubSaveImageAs();
                        case DialogResult.Cancel:
                            return SResult.Canceled;
                        default:
                            return SResult.Void;
                    }
                }
            }

            return SubSave(nFileType, sFilePath);
        }

        /// <summary>
        /// iView.NET subroutine. Opens the save file dialog and allows the user to save the current image.
        /// </summary>
        /// <returns></returns>
        private SResult SubSaveImageAs()
        {
            if (!m_oImageBrowser.IsLoaded)
                return SResult.Void;

            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            SResult nResult = SResult.Canceled;

            using (SaveFileDialog oDlg = new SaveFileDialog())
            {
                oDlg.AutoUpgradeEnabled = true;
                oDlg.Title = "Save As";
                oDlg.FileName = Path.GetFileNameWithoutExtension(m_oImageBrowser.ImageInfo.Name);
                oDlg.Filter = Resources.SaveFileFilter;
                oDlg.FilterIndex = m_nLastSaveFileIndex;

                if (oDlg.ShowDialog(this) == DialogResult.OK)
                {
                    if ((nResult = SubSave((ImageFileType)oDlg.FilterIndex, oDlg.FileName)) == SResult.Completed)
                        m_nLastSaveFileIndex = oDlg.FilterIndex;
                }
            }

            return nResult;
        }

        /// <summary>
        /// iView.NET subroutine. Opens a new window loaded with the image currently being viewed in the main window.
        /// </summary>
        /// <returns></returns>
        private SResult SubOpenNewWindow()
        {
            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            if (m_oNewWindows.Count >= IViewSettings.Default.MaxWindows)
                return SResult.Void;

            Image oImage = imgbx_MainImage.ImageBoxImage;
            m_oNewWindowForm = new NewWindow(oImage);
            m_oItem = new ToolStripMenuItem();

            // Create a new FormNewWindow object.
            m_oNewWindowForm.Text = Path.GetFileName(m_oImageBrowser.SelectedFile);
            m_oNewWindowForm.Tag = m_oItem;
            m_oNewWindowForm.Icon = DrawingTools.CreateScaledIconFromImage(oImage, 16, 16);
            m_oNewWindowForm.FormClosed += delegate(object oSender, FormClosedEventArgs oEventArgs)
            {
                NewWindow oNewWindow = oSender as NewWindow;

                if (oNewWindow != null)
                {
                    ToolStripMenuItem oItem = (ToolStripMenuItem)oNewWindow.Tag;

                    if ((oItem != null) && (!oItem.IsDisposed))
                        tsmi_view_Windows.DropDown.Items.Remove(oItem);

                    m_oNewWindows.Remove(oNewWindow);
                }
            };
            m_oNewWindowForm.Show();

            // Create a new toolstrip menu item.
            m_oItem.Text = m_oNewWindowForm.Text;
            m_oItem.Tag = m_oNewWindowForm.Handle;
            m_oItem.Image = DrawingTools.CreateThumbnail(oImage, 16, 16, true, ThumbnailEffect.None);
            m_oItem.Click += delegate(object oSender, EventArgs oEventArgs)
            {
                if (oSender != null)
                {
                    IntPtr hWnd = (IntPtr)((ToolStripMenuItem)oSender).Tag;

                    if (hWnd != IntPtr.Zero)
                        Form.FromHandle(hWnd).Focus();
                }
            };

            // Add the new window to the form list.
            m_oNewWindows.Add(m_oNewWindowForm);

            // Add a new item to the windows drop down.
            tsmi_view_Windows.DropDown.Items.Add(m_oItem);

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Copys the specified data to the clipboard.
        /// </summary>
        /// <param name="nDataType">Specifies the type of data to copy.</param>
        /// <returns></returns>
        private SResult SubCopy(CopyDataType nDataType)
        {
            Application.DoEvents();
            DataObject oDataObject = new DataObject();

            switch (nDataType)
            {
                case CopyDataType.File:
                    int nCount = elvw_Images.SelectedItems.Count;
                    if (nCount > 0)
                    {
                        int n = 0;
                        string[] sPaths = new string[nCount];

                        // Iterate through the listview and get the item names.
                        foreach (ListViewItem oItem in elvw_Images.SelectedItems)
                            sPaths[n++] = oItem.Name;

                        // Set the file path array to the data object.
                        oDataObject.SetData(DataFormats.FileDrop, true, sPaths);
                    }
                    break;
                case CopyDataType.PixelData:
                    if (imgbx_MainImage.IsImageLoaded)
                        oDataObject.SetData(imgbx_MainImage.ImageBoxImage);
                    break;
            }

            if (oDataObject != null)
            {
                try
                {
                    Clipboard.Clear();
                    Clipboard.SetDataObject(oDataObject, true);
                }
                catch (System.Runtime.InteropServices.ExternalException e)
                {
                    MessageBox.Show("Unable to copy data to the clipboard.\n\nReason: " + e.Message, "Copy Data Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Pastes the contents of the clipboard (if it contains image data) to the image box.
        /// </summary>
        /// <returns></returns>
        private SResult SubPaste()
        {
            try
            {
                if (Clipboard.ContainsImage())
                {
                    using (Image oImage = Clipboard.GetImage())
                    {
                        if (oImage != null)
                        {
                            // Set the image edit status.
                            ImageHasBeenEdited = true;

                            // No elements in the list? Save the original state first.
                            if (m_oUndoRedo.Count == 0)
                                m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

                            // Set the clipboard image to the main image.
                            imgbx_MainImage.ImageBoxImage = new Bitmap(oImage, oImage.Size);

                            // Save the current image state.
                            m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

                            return SResult.Completed;
                        }
                    }
                }
            }
            catch (System.Runtime.InteropServices.ExternalException e)
            {
                MessageBox.Show("Unable to paste the data on the clipboard.\n\nReason: " + e.Message, "Paste Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return SResult.Void;
        }

        /// <summary>
        /// iView.NET subroutine. Deletes the select file or files.
        /// </summary>
        /// <returns></returns>
        private SResult SubDeleteFiles()
        {
            if (m_oImageBrowser.IsLoaded)
            {
                string sPath = string.Empty;
                int nSelectedItems = elvw_Images.SelectedItems.Count;

                try
                {
                    // If the image box is in focus, call the windows delete dialog.
                    if (imgbx_MainImage.Focused)
                    {
                        sPath = m_oImageBrowser.SelectedFile;

                        if (!string.IsNullOrEmpty(sPath))
                            m_oImageBrowser.DeleteFile(sPath, true, true);

                        return SResult.Completed;
                    }

                    // If the image box is not in focus, use the listview selected items.
                    if (nSelectedItems <= 1)
                    {
                        sPath = m_oImageBrowser.SelectedFile;

                        if (!string.IsNullOrEmpty(sPath))
                            m_oImageBrowser.DeleteFile(sPath, true, true);
                    }
                    else if (nSelectedItems > 1)
                    {
                        string sCaption = "Files to Delete - " + nSelectedItems;
                        string sMessage = "Would you like to send these files to the recycle bin?";

                        DialogResult nDlg = MessageBox.Show(sMessage, sCaption,
                            MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (nDlg == DialogResult.Yes)
                        {
                            foreach (ListViewItem oItem in elvw_Images.SelectedItems)
                            {
                                sPath = oItem.Name;

                                if (!string.IsNullOrEmpty(sPath))
                                    m_oImageBrowser.DeleteFile(sPath, true, false);
                            }

                            return SResult.Completed;
                        }
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show("Unable to delete: " + sPath + "\n\nReason: " + e.Message, "Delete Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException e)
                {
                    MessageBox.Show("Unable to delete: " + sPath + "\n\nReason: " + e.Message, "Delete Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Security.SecurityException e)
                {
                    MessageBox.Show("Unable to delete: " + sPath + "\n\nReason: " + e.Message, "Delete Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return SResult.Void;
        }

        /// <summary>
        /// iView.NET subroutine. Renames the currently selected file.
        /// </summary>
        /// <returns></returns>
        private SResult SubRenameFile()
        {
            if (m_oImageBrowser.IsLoaded)
            {
                using (RenameFile oForm = new RenameFile(m_oImageBrowser))
                    oForm.ShowDialog(this);
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Toggles the image scale mode, from auto to none.
        /// </summary>
        /// <returns></returns>
        private SResult SubToggleScaleMode()
        {
            switch (m_nImageScale)
            {
                case ImageScale.Auto:
                    return SubScaleDisplayImage(ImageScale.None);
                case ImageScale.None:
                case ImageScale.Custom:
                    return SubScaleDisplayImage(ImageScale.Auto);
            }

            return SResult.Void;
        }

        /// <summary>
        /// iView.NET subroutine. Sets the scale mode for the main image.
        /// </summary>
        /// <param name="nScale">Specifies the scale type to apply to the image.</param>
        /// <returns></returns>
        private SResult SubScaleDisplayImage(ImageScale nScale)
        {
            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            bool bAutoScroll = true;
            int nDestWidth = imgbx_MainImage.Width - 2;
            int nDestHeight = imgbx_MainImage.Height - 2;
            int nImageWidth = imgbx_MainImage.ImageBoxImage.Width;
            int nImageHeight = imgbx_MainImage.ImageBoxImage.Height;
            Rectangle Rect = Rectangle.Empty;

            if (nScale == ImageScale.Auto)
            {
                // Update field members.
                m_nImageScale = ImageScale.Auto;

                if ((nImageWidth >= nDestWidth) || (nImageHeight >= nDestHeight))
                {
                    bAutoScroll = false;

                    Rect.Size = ScaleHitTestTools.GetRectangleScaled(nImageWidth, nImageHeight,
                        nDestWidth, nDestHeight, true);
                    Rect.Location = ScaleHitTestTools.GetFixedRectangleCenter(Rect.Width, Rect.Height,
                        nDestWidth, nDestHeight);
                }
                else
                {
                    bAutoScroll = false;

                    Rect.Size = new Size(nImageWidth, nImageHeight);
                    Rect.Location = ScaleHitTestTools.GetFloatingRectangleCenter(Rect.Width, Rect.Height,
                        nDestWidth, nDestHeight);
                }
            }
            else if (nScale == ImageScale.None)
            {
                bAutoScroll = true;

                // Update field members.
                m_nImageScale = ImageScale.None;

                Rect.Size = new Size(nImageWidth, nImageHeight);
                Rect.Location = ScaleHitTestTools.GetFloatingRectangleCenter(Rect.Width, Rect.Height,
                    nDestWidth, nDestHeight);
            }
            else if (nScale == ImageScale.Custom)
            {
                bAutoScroll = true;

                // Update field members.
                m_nImageScale = ImageScale.Custom;

                Rect.Size = imgbx_MainImage.ImageBoxSize;
                Rect.Location = ScaleHitTestTools.GetFloatingRectangleCenter(Rect.Width, Rect.Height,
                    nDestWidth, nDestHeight);
            }

            // Set the auto scroll flag and set the image box rectangle.
            imgbx_MainImage.AutoScroll = bAutoScroll;
            imgbx_MainImage.ImageBoxRectangle = Rect;

            // Update the zoom drop down box text.
            tscbx_tb_Zoom.Text =
                ScaleHitTestTools.GetScalePercentage(nImageWidth, Rect.Width).ToString("n1") + "%";

            // Invalidate the image box.
            imgbx_MainImage.Invalidate();

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subtourine. Refreshes the current directory.
        /// </summary>
        /// <returns></returns>
        private SResult SubRefresh()
        {
            if ((m_oImageBrowser != null) && (m_oImageBrowser.IsLoaded))
            {
                return SubOpenDirectory(m_oImageBrowser.SelectedDirectory, m_oImageBrowser.SelectedFile,
                    ImageFileType.All);
            }

            return SResult.Void;
        }

        /// <summary>
        /// iView.NET subroutine. Sets the image list view to the specified ImageListViewType.
        /// </summary>
        /// <param name="nViewType">Specifies the type of view to set the image list control.</param>
        /// <returns></returns>
        private SResult SubSetImageListView(ImageListViewType nViewType)
        {
            m_nImageListViewType = nViewType;

            switch (nViewType)
            {
                case ImageListViewType.LargeIcons:
                case ImageListViewType.MediumIcons:
                case ImageListViewType.SmallIcons:
                    elvw_Images.View = View.LargeIcon;
                    break;
                case ImageListViewType.List:
                    elvw_Images.View = View.List;
                    break;
                case ImageListViewType.Details:
                    elvw_Images.View = View.Details;
                    break;
            }

            if ((m_oImageBrowser != null) && (m_oImageBrowser.IsLoaded))
            {
                return SubOpenDirectory(m_oImageBrowser.SelectedDirectory, m_oImageBrowser.SelectedFile,
                    ImageFileType.All);
            }

            return SResult.Void;
        }

        /// <summary>
        /// iView.NET subroutine. Toggles the collapsed state of the specified window (splitter panel).
        /// </summary>
        /// <param name="nWindow">Specifies the window to collapse or expand.</param>
        /// <returns></returns>
        private SResult SubToggleWindow(Window nWindow)
        {
            switch (nWindow)
            {
                case Window.Explorer:
                    if ((m_oExplorerDockWindow != null) && (m_oExplorerDockWindow.IsDocked))
                        ExplorerSplitterPanelCollapsed = ExplorerSplitterPanelCollapsed ? false : true;
                    break;
                case Window.ImageList:
                    if ((m_oImageListDockWindow != null) && (m_oImageListDockWindow.IsDocked))
                        ImageListSplitterPanelCollapsed = ImageListSplitterPanelCollapsed ? false : true;
                    break;
                case Window.Tasks:
                    if ((m_oTaskDockWindow != null) && (m_oTaskDockWindow.IsDocked))
                        TaskSplitterPanelCollapsed = TaskSplitterPanelCollapsed ? false : true;
                    break;
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Toggles the dock state of the specified window.
        /// </summary>
        /// <param name="nWindow">Specifies the window to toggle the dock state of.</param>
        /// <returns></returns>
        private SResult SubToggleWindowDocking(Window nWindow)
        {
            switch (nWindow)
            {
                case Window.Explorer:
                    switch (m_oExplorerDockWindow.IsDocked)
                    {
                        case true:
                            m_oExplorerDockWindow.UnDock(this);
                            break;
                        case false:
                            m_oExplorerDockWindow.Dock();
                            break;
                    }
                    break;
                case Window.ImageList:
                    switch (m_oImageListDockWindow.IsDocked)
                    {
                        case true:
                            m_oImageListDockWindow.UnDock(this);
                            break;
                        case false:
                            m_oImageListDockWindow.Dock();
                            break;
                    }
                    break;
                case Window.Tasks:
                    switch (m_oTaskDockWindow.IsDocked)
                    {
                        case true:
                            m_oTaskDockWindow.UnDock(this);
                            break;
                        case false:
                            m_oTaskDockWindow.Dock();
                            break;
                    }
                    break;
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Sets the currently selected image as the desktop wallpaper.
        /// </summary>
        /// <param name="nStyle">Specifies the style for the wallpaper.</param>
        /// <returns></returns>
        private SResult SubSetWallPaper(WallPaperStyle nStyle)
        {
            if (imgbx_MainImage.IsImageLoaded)
            {
                NativeMethods.SetDesktopBackground(ApplicationData.BackgroundsFolder,
                    imgbx_MainImage.ImageBoxImage, nStyle);

                return SResult.Completed;
            }

            return SResult.NullDisplayImage;
        }

        /// <summary>
        /// iView.NET subroutine. Scales the main image to the specified percent value.
        /// </summary>
        /// <param name="fPercent">Specifies the percentage to scale the image to.</param>
        /// <returns></returns>
        private SResult SubZoom(float fPercent)
        {
            if (imgbx_MainImage.IsImageLoaded)
            {
                int nImageWidth = imgbx_MainImage.ImageBoxImage.Width;
                int nImageHeight = imgbx_MainImage.ImageBoxImage.Height;

                // Update field members.
                m_nImageScale = ImageScale.Custom;

                // Update the image box size property.
                imgbx_MainImage.ImageBoxSize =
                    ScaleHitTestTools.ScaleFromPercentage(nImageWidth, nImageHeight, fPercent);

                // Scale the image.
                return SubScaleDisplayImage(m_nImageScale);
            }

            return SResult.NullDisplayImage;
        }

        /// <summary>
        /// iView.NET subroutine. Opens the print dialog control.
        /// </summary>
        /// <returns></returns>
        private SResult SubPrint()
        {
            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            // Initialize the print document.
            InitializePrintDocument();

            // Open the print dialog control.
            using (PrintDialog oPrintDlg = new PrintDialog())
            {
                oPrintDlg.UseEXDialog = true;
                oPrintDlg.Document = m_oPrintDocument;

                if (oPrintDlg.ShowDialog(this) == DialogResult.Yes)
                    m_oPrintDocument.Print();
            }

            return SResult.Completed;
        }

        /// <summary>
        /// Opens the print preview dialog control.
        /// </summary>
        /// <returns></returns>
        private SResult SubPrintPreview()
        {
            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            // Initialize the print document.
            InitializePrintDocument();

            // Open the print preview dialog control.
            using (PrintPreviewDialog oPrintPreviewDlg = new PrintPreviewDialog())
            {
                oPrintPreviewDlg.ShowIcon = false;
                oPrintPreviewDlg.Document = m_oPrintDocument;
                oPrintPreviewDlg.ShowDialog(this);
            }

            return SResult.Completed;
        }

        /// <summary>
        /// Opens the page setup dialog control.
        /// </summary>
        /// <returns></returns>
        private SResult SubPageSetup()
        {
            // Initialize the print document.
            InitializePrintDocument();

            // Open the page setup dialog control.
            using (PageSetupDialog oPageSetupDlg = new PageSetupDialog())
            {
                oPageSetupDlg.Document = m_oPrintDocument;
                oPageSetupDlg.ShowDialog(this);
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Loads the FavouritesCollection into the explorer tree view control.
        /// </summary>
        /// <returns></returns>
        private SResult SubLoadFavourites()
        {
            if (m_oFavourites != null)
            {
                foreach (Favourite oFavourite in m_oFavourites)
                {
                    TreeNode oNode = new TreeNode();
                    oNode.Name = oFavourite.Path;
                    oNode.Text = oFavourite.Name;
                    oNode.Tag = oFavourite;
                    oNode.ImageIndex = (int)NodeImageType.FolderClosed;
                    oNode.SelectedImageIndex = (int)NodeImageType.FolderOpened;
                    oNode.ToolTipText = "Created: " + oFavourite.Created + "\nLocation: " + oFavourite.Path;

                    // Add the node to the explorer tree view control.
                    etvw_Directorys.Nodes[0].Nodes.Add(oNode);
                }

                return SResult.Completed;
            }

            return SResult.NullFavouritesCollection;
        }

        /// <summary>
        /// iView.NET subroutine. Adds a new favourite to the FavouritesCollection.
        /// </summary>
        /// <param name="bUseDialog">Specifies whether to use the dialog or to use the currently selected location.</param>
        /// <returns></returns>
        private SResult SubAddFavourite(bool bUseDialog)
        {
            if (m_oFavourites == null)
                return SResult.NullFavouritesCollection;

            string sName = null;
            string sCreated = null;
            string sPath = (m_oImageBrowser != null) ? m_oImageBrowser.SelectedDirectory : null;
            Favourite oFavourite = null;

            if (!bUseDialog)
            {
                if (!string.IsNullOrEmpty(sPath))
                {
                    oFavourite = new Favourite();
                    oFavourite.Name = new DirectoryInfo(sPath).Name;
                    oFavourite.Path = sPath;
                    oFavourite.Created = DateTime.Now.ToShortDateString();
                }
            }
            else
            {
                // Open the favourite dialog.
                using (FavouriteDialog oForm = new FavouriteDialog(sName, sPath))
                {
                    if (oForm.ShowDialog(this) == DialogResult.OK)
                        oFavourite = oForm.NewFavorite;
                }
            }

            if (oFavourite != null)
            {
                if ((etvw_Directorys.Nodes.Count > 0) && (etvw_Directorys.Nodes[0] != null))
                {
                    sName = oFavourite.Name;
                    sCreated = oFavourite.Created;
                    sPath = oFavourite.Path;

                    // Add a new Favourite object to the FavouritesCollection.
                    m_oFavourites.Add(oFavourite);

                    // Create and add a new tree node to the explorer tree view control.
                    TreeNode oNode = new TreeNode();
                    oNode.Name = sPath;
                    oNode.Text = sName;
                    oNode.Tag = oFavourite;
                    oNode.ImageIndex = (int)NodeImageType.FolderClosed;
                    oNode.SelectedImageIndex = (int)NodeImageType.FolderOpened;
                    oNode.ToolTipText = "Created: " + sCreated + "\nLocation: " + sPath;

                    // Add the new favourite node to the parent.
                    etvw_Directorys.Nodes[0].Nodes.Add(oNode);

                    // Expand the parent node.
                    if (!etvw_Directorys.Nodes[0].IsExpanded)
                        etvw_Directorys.Nodes[0].Expand();

                    return SResult.Completed;
                }
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Removes the currently selected treeview node and favourite from the favourites list.
        /// </summary>
        /// <returns></returns>
        private SResult SubRemoveFavourite()
        {
            TreeNode oNode = etvw_Directorys.SelectedNode;

            if (oNode == null)
                return SResult.Void;

            Favourite oFavourite = oNode.Tag as Favourite;

            if (oFavourite != null)
            {
                if (m_oFavourites != null)
                {
                    string sCaption = "Remove Favourite";
                    string sMessage = "Would you like to remove " + oFavourite.Name + " from the favourites list?";

                    DialogResult nDlg = MessageBox.Show(sMessage, sCaption,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (nDlg == DialogResult.Yes)
                    {
                        // Remove the favourite, if it exists.
                        if (m_oFavourites.Contains(oFavourite))
                            m_oFavourites.Remove(oFavourite);

                        // Remove the node, even if the favourite isn't in the collection.
                        oNode.Remove();
                    }
                }
                else
                    return SResult.NullFavouritesCollection;
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Allows the user to remove all of the treeview favourite nodes.
        /// </summary>
        /// <returns></returns>
        private SResult SubRemoveAllFavourites()
        {
            string sCaption = "Delete All Favourites";
            string sMessage = "You are about to delete all favourites. Would you like to continue?";
            DialogResult nDlg = MessageBox.Show(sMessage, sCaption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (nDlg == DialogResult.Yes)
            {
                // Clear the tree view nodes.
                if (etvw_Directorys.Nodes.Count > 0)
                    etvw_Directorys.Nodes[0].Nodes.Clear();

                // Clear the favourites collection.
                m_oFavourites.Clear();

                return SResult.Completed;
            }

            return SResult.Void;
        }

        /// <summary>
        /// iView.NET subroutine. Allows the user to edit the currently selected treeview favourite node.
        /// </summary>
        /// <returns></returns>
        private SResult SubEditFavourite()
        {
            TreeNode oNode = etvw_Directorys.SelectedNode;

            if (oNode == null)
                return SResult.Void;

            Favourite oFavourite = oNode.Tag as Favourite;

            if (oFavourite != null)
            {
                if (m_oFavourites != null)
                {
                    string sName = oFavourite.Name;
                    string sPath = oFavourite.Path;

                    using (FavouriteDialog oForm = new FavouriteDialog(sName, sPath))
                    {
                        if (oForm.ShowDialog(this) == DialogResult.OK)
                        {
                            // Remove the old favourite.
                            m_oFavourites.Remove(oFavourite);

                            // Add the new favourite to the list.
                            m_oFavourites.Add(oForm.NewFavorite);

                            // Update the related tree view node.
                            oNode.Text = oForm.NewFavorite.Name;
                            oNode.Name = oForm.NewFavorite.Path;
                            oNode.ToolTipText = "Created: " + oForm.NewFavorite.Created
                                + "\nLocation: " + oForm.NewFavorite.Path;

                            // Assign the new favourite to the nodes tag property.
                            oNode.Tag = oForm.NewFavorite;
                        }
                    }
                }
                else
                    return SResult.NullFavouritesCollection;
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Rotates the main image with the specified flip rotate type.
        /// </summary>
        /// <param name="nFlipRotateType">Specifies the flip rotate type to apply to the main image.</param>
        /// <returns></returns>
        private SResult SubRotateImage(RotateFlipType nFlipRotateType)
        {
            if (imgbx_MainImage.IsImageLoaded)
            {
                // Reset the image scale mode if the current mode is set as custom.
                if (m_nImageScale == ImageScale.Custom)
                    m_nImageScale = ImageScale.Auto;

                // Show that the image has been changed.
                ImageHasBeenEdited = true;

                // No elements in the list? Save the original state first.
                if (m_oUndoRedo.Count == 0)
                    m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

                // Rotate the image in the image box.
                imgbx_MainImage.ImageBoxImage =
                    DrawingTools.RotateImage(imgbx_MainImage.ImageBoxImage, nFlipRotateType);

                // Save the current image state.
                m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

                return SResult.Completed;
            }

            return SResult.NullDisplayImage;
        }

        /// <summary>
        /// iView.NET subroutine. Sets the colour and text of the label that shows the pixel information. If the
        /// main toolstrip is not visible, a popup window will show the data.
        /// </summary>
        /// <param name="nX">Specifies the x position within the main image.</param>
        /// <param name="nY">Specifies the y position within the main image.</param>
        /// <returns></returns>
        private SResult SubEyeDropperTool(int nX, int nY)
        {
            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            Color PixelColour = DrawingTools.GetColourFromPixel((Bitmap)imgbx_MainImage.ImageBoxImage,
                imgbx_MainImage.ImageBoxSize, nX, nY);

            byte nA = PixelColour.A;
            byte nR = PixelColour.R;
            byte nG = PixelColour.G;
            byte nB = PixelColour.B;

            tsl_tb_PixelInfo.Image = DrawingTools.CreateEyeDropperBitmap(PixelColour);
            tsl_tb_PixelInfo.Text = (nR.ToString("x2") + nG.ToString("x2") + nB.ToString("x2")).ToUpper();
            tsl_tb_PixelInfo.ToolTipText = "Alpha:\t" + nA + "\nRed:\t" + nR + "\nGreen:\t" + nG + "\nBlue:\t" + nB;

            if (!ts_Toolbar.Visible)
            {
                // Create a new instance of the FormPixelColour class and show it at the specified location.
                if ((m_oFormPixelColour == null) || (m_oFormPixelColour.IsDisposed))
                {
                    m_oFormPixelColour = new FormPixelColour(PixelColour);
                    m_oFormPixelColour.Location = Control.MousePosition;
                    m_oFormPixelColour.Show(this);
                }
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Allows the user to remove or reduce the red eye from the specified region within the specified image.
        /// </summary>
        /// <param name="nX"></param>
        /// <param name="nY"></param>
        /// <returns></returns>
        private SResult SubRedEyeCorrectionTool(int nX, int nY)
        {
            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            int nImageWidth = imgbx_MainImage.ImageBoxImage.Width;
            int nImageHeight = imgbx_MainImage.ImageBoxImage.Height;
            int nBoxWidth = imgbx_MainImage.ImageBoxWidth;
            int nBoxHeight = imgbx_MainImage.ImageBoxHeight;

            // Translate the current x position.
            float fXPercent = 100 / ((float)nBoxWidth / (float)nX);
            float fX = (fXPercent / 100) * nImageWidth;

            // Translate the current y position.
            float fYPercent = 100 / ((float)nBoxHeight / (float)nY);
            float fY = (fYPercent / 100) * nImageHeight;

            int nPos = (m_oRedEyePanel.PupilSize / 2);
            Rectangle Rect = new Rectangle((int)fX - nPos, (int)fY - nPos,
                m_oRedEyePanel.PupilSize, m_oRedEyePanel.PupilSize);

            // Update the image edited status.
            ImageHasBeenEdited = true;

            // No elements in the list? Save the original state first.
            if (m_oUndoRedo.Count == 0)
                m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

            // Process the image.
            using (ImageProcessing oProcess = new ImageProcessing(imgbx_MainImage.ImageBoxImage))
            {
                // Apply the red eye correction.
                oProcess.RedEyeCorrection(Rect, 1.5f);

                // Update the main display image with the edited image.
                imgbx_MainImage.ImageBoxImage = oProcess.GetProcessedImage();
            }

            // Save the current image state.
            m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

            // Reset the current tool and cursor.
            m_nCurrentTool = Tool.None;
            imgbx_MainImage.Cursor = Cursors.Default;

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Resizes the image currently being viewed.
        /// </summary>
        /// <returns></returns>
        private SResult SubResizeImage()
        {
            if (imgbx_MainImage.IsImageLoaded)
            {
                // Set the image edited status.
                ImageHasBeenEdited = true;

                // No elements in the list? Save the original state first.
                if (m_oUndoRedo.Count == 0)
                    m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

                // Resize the image.
                imgbx_MainImage.ImageBoxImage = DrawingTools.ResizeImage(imgbx_MainImage.ImageBoxImage,
                    m_oResizePanel.NewSize, (System.Drawing.Drawing2D.InterpolationMode)m_oResizePanel.Quality);

                // Save the current image state.
                m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);
            }

            return SResult.NullDisplayImage;
        }

        /// <summary>
        /// iView.NET subroutine. Shears the image currently being viewed.
        /// </summary>
        /// <returns></returns>
        private SResult SubShearImage()
        {
            if (imgbx_MainImage.IsImageLoaded)
            {
                if ((m_oShearPanel.HorizontalValue == 0) && (m_oShearPanel.VerticalValue == 0))
                    return SResult.Void;

                // Set the image edited status.
                ImageHasBeenEdited = true;

                // No elements in the list? Save the original state first.
                if (m_oUndoRedo.Count == 0)
                    m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

                Color BackgroundColour = (!m_oShearPanel.TransparentBackground) ?
                    m_oShearPanel.BackgroundColour : Color.Transparent;

                if (m_oShearPanel.HorizontalValue != 0)
                {
                    imgbx_MainImage.ImageBoxImage = DrawingTools.ShearImage(imgbx_MainImage.ImageBoxImage,
                        ShearType.Horizontal,
                        BackgroundColour,
                        m_oShearPanel.HorizontalValue,
                        m_oShearPanel.ResizeImage);
                }

                if (m_oShearPanel.VerticalValue != 0)
                {
                    imgbx_MainImage.ImageBoxImage = DrawingTools.ShearImage(imgbx_MainImage.ImageBoxImage,
                        ShearType.Vertical,
                        BackgroundColour,
                        m_oShearPanel.VerticalValue,
                        m_oShearPanel.ResizeImage);
                }

                // Save the current image state.
                m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

                return SResult.Completed;
            }

            return SResult.Void;
        }

        /// <summary>
        /// iView.NET subroutine. Shows the specified task window.
        /// </summary>
        /// <param name="nWindow">Specifies the task window to show.</param>
        /// <param name="bExpandTaskPanel">Specifies whether to open the task panel if it's currently collapsed.</param>
        /// <returns></returns>
        private SResult SubShowTaskWindow(TaskWindow nWindow, bool bExpandTaskPanel)
        {
            Image oImage = null;
            string sText = string.Empty;

            // Update field members.
            m_nSelectedTaskWindow = nWindow;

            // Clear the tasks container of all controls.
            if (pan_TasksContainer.Controls != null)
                pan_TasksContainer.Controls.Clear();

            switch (nWindow)
            {
                case TaskWindow.Properties:
                    oImage = tsmi_task_Properties.Image;
                    sText = tsmi_task_Properties.Text;
                    pan_TasksContainer.Controls.Add(m_oPropertiesPanel);
                    break;
                case TaskWindow.RedEyeCorrection:
                    oImage = tsmi_task_RedEyeCorrection.Image;
                    sText = tsmi_task_RedEyeCorrection.Text;
                    pan_TasksContainer.Controls.Add(m_oRedEyePanel);
                    break;
                case TaskWindow.Resize:
                    oImage = tsmi_task_Resize.Image;
                    sText = tsmi_task_Resize.Text;
                    pan_TasksContainer.Controls.Add(m_oResizePanel);
                    break;
                case TaskWindow.Shear:
                    oImage = tsmi_task_Shear.Image;
                    sText = tsmi_task_Shear.Text;
                    pan_TasksContainer.Controls.Add(m_oShearPanel);
                    break;
            }

            // Update the text for the drodown button.
            tsddb_task_Tasks.Text = sText;

            // Update the Image and Text property of the dropdown button.
            if (oImage != null)
                tsddb_task_Tasks.Image = new Bitmap(oImage, oImage.Size);

            // Expand the task panel if specified.
            if ((bExpandTaskPanel) && (m_oTaskDockWindow.IsDocked))
            {
                if (TaskSplitterPanelCollapsed)
                    TaskSplitterPanelCollapsed = false;
            }

            //
            if (CurrentTool == Tool.RedEyeCorrection)
            {
                if (nWindow != TaskWindow.RedEyeCorrection)
                    CurrentTool = Tool.None;
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Processes the main display image with the specified processing type.
        /// </summary>
        /// <param name="iProcessingType">Specifies the IProcessingType interface </param>
        /// <returns></returns>
        private SResult SubApplyImageProcessing(IProcessingType iProcessingType)
        {
            if (!imgbx_MainImage.IsImageLoaded)
                return SResult.NullDisplayImage;

            // Show image processing visuals.
            Cursor.Current = Cursors.WaitCursor;

            // Process the image in the main imagebox.
            using (ImageProcessing oImageProcess = new ImageProcessing(imgbx_MainImage.ImageBoxImage))
            {
                switch (iProcessingType.StructType)
                {
                    case ProcessingStructType.GreyScaleFilter:
                        oImageProcess.ApplyGreyScaleFilter();
                        break;
                    case ProcessingStructType.InvertFilter:
                        oImageProcess.ApplyInvertFilter();
                        break;
                    case ProcessingStructType.PhotoCopyFilter:
                        oImageProcess.ApplyPhotoCopyFilter();
                        break;
                    case ProcessingStructType.RotateColourFilter:
                        oImageProcess.ApplyRotateColourFilter();
                        break;
                    case ProcessingStructType.ColourFilter:
                        ColourFilterStruct ColourStruct = (ColourFilterStruct)iProcessingType;
                        oImageProcess.ApplyColourFilter(ColourStruct.Channel, ColourStruct.Value);
                        break;
                    case ProcessingStructType.Transparency:
                        TransparencyStruct TransStruct = (TransparencyStruct)iProcessingType;
                        oImageProcess.AdjustTransparency(TransStruct.Value, 255);
                        break;
                    case ProcessingStructType.Brightness:
                        BrightnessStruct BrightStruct = (BrightnessStruct)iProcessingType;
                        oImageProcess.AdjustBrightness(BrightStruct.Value);
                        break;
                    case ProcessingStructType.Contrast:
                        ContrastStruct ContStruct = (ContrastStruct)iProcessingType;
                        oImageProcess.AdjustContrast(ContStruct.Value);
                        break;
                    case ProcessingStructType.Gamma:
                        GammaStruct GammStruct = (GammaStruct)iProcessingType;
                        oImageProcess.AdjustGamma(GammStruct.Red, GammStruct.Green, GammStruct.Blue);
                        break;
                }

                // Update the image edited status.
                ImageHasBeenEdited = true;

                // No elements in the list? Save the original state first.
                if (m_oUndoRedo.Count == 0)
                    m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

                // Update the main imagebox with the processed image.
                imgbx_MainImage.ImageBoxImage = oImageProcess.GetProcessedImage();

                // Save the current image state.
                m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

                // Reset the cursor.
                Cursor.Current = Cursors.Default;
            }

            return SResult.Completed;
        }


        public SResult SubStartSlideShow()
        {
            return SubStartSlideShow(false);
        }

        /// <summary>
        /// iView.NET subroutine. Starts the slide show with the currently selected files in the explorer listview.
        /// If no files have been selected, all files in the listview will be loaded.
        /// </summary>
        /// <returns></returns>
        public SResult SubStartSlideShow(bool all)
        {
            if (!m_oImageBrowser.IsLoaded)
                return SResult.Void;

            SResult nResult = SResult.Void;
            int n = 0, nSelectedItems = all ? 0 : elvw_Images.SelectedItems.Count;
            string[] sPaths = null;

           
            if (nSelectedItems == 0 )
            {
                sPaths = new string[elvw_Images.Items.Count];

                foreach (ListViewItem oItem in elvw_Images.Items)
                    sPaths[n++] = oItem.Name;
            }
            else
            {
                sPaths = new string[elvw_Images.SelectedItems.Count];

                foreach (ListViewItem oItem in elvw_Images.SelectedItems)
                    sPaths[n++] = oItem.Name;
            }
        
            // Show the SlideShow if files have been loaded.
            if (n != 0)
            {
                // Open the slide show form.
                m_oSlideShowForm = new SlideShow(sPaths);
                m_oSlideShowForm.Show(this);

                nResult = SResult.Completed;
            }
            else
            {
                MessageBox.Show("Unable to start the slide show as there are no files loaded.", "Error Starting Slide Show",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                nResult = SResult.Void;
            }

            return nResult;
        }

        /// <summary>
        /// iView.NET subroutine. Toggles the full screen mode for the main window.
        /// </summary>
        /// <returns></returns>
        private SResult SubToggleFullScreenMode()
        {
            if (this.FormBorderStyle != FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.None;

                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.WindowState = FormWindowState.Maximized;
                }
                else
                    this.WindowState = FormWindowState.Maximized;

                tsmi_FullScreen.Visible = true;
                tsmi_Exit.Visible = true;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                tsmi_FullScreen.Visible = false;
                tsmi_Exit.Visible = false;
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Checks for a new version of iView.NET.
        /// </summary>
        /// <param name="bShowConnectionError">Specifies whether to show any connection error dialogs.</param>
        /// <param name="bShowNoUpdatesFoundDialog">Specifies whether to show the no updates found dialog.</param>
        /// <returns></returns>
        private SResult SubCheckForUpdates(bool bShowConnectionError, bool bShowNoUpdatesFoundDialog)
        {
            // Update field member flags.
            m_bShowNoUpdatesFoundDialog = bShowNoUpdatesFoundDialog;

            if (NativeMethods.IsConnectedToInternet())
            {
                UpdateChecker oUpdate = new UpdateChecker();
                oUpdate.UpdateCheckStarted +=
                    new EventHandler<EventArgs>(UpdateChecker_UpdateCheckStarted);
                oUpdate.UpdateCheckFinished +=
                    new EventHandler<UpdateCheckFinishedEventArgs>(UpdateChecker_UpdateCheckFinished);
                oUpdate.CheckFileUri = ApplicationData.UpdateCheckFileUri;
                oUpdate.StartCheck();
            }
            else
            {
                if (bShowConnectionError)
                {
                    string sCaption = "Connection Attempt Failed.";
                    string sMessage = "A connection could not be established with the server.\n\nPlease check your internet connection IViewSettings";
                    MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            return SResult.Completed;
        }

        /// <summary>
        /// iView.NET subroutine. Shows the processing editor dialog. Allows the user to specifiy the settings
        /// and preview the changes when apply a filter.
        /// </summary>
        /// <param name="nControlSet">Specifies the control set to load when the dialog has been initialized.</param>
        /// <returns></returns>
        private SResult SubShowProcessingEditor(ControlSet nControlSet)
        {
            Image oImage = imgbx_MainImage.ImageBoxImage;

            if (oImage == null)
                return SResult.NullDisplayImage;

            using (ProcessingDialog oForm = new ProcessingDialog(oImage, nControlSet))
            {
                if (oForm.ShowDialog(this) == DialogResult.OK)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    using (ImageProcessing oProcessing = new ImageProcessing(oImage))
                    {
                        // Update the image edited status.
                        ImageHasBeenEdited = true;

                        // No elements in the list? Save the original state first.
                        if (m_oUndoRedo.Count == 0)
                            m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);

                        switch (nControlSet)
                        {
                            case ControlSet.BrightnessContrast:
                                if (oForm.Contrast != 0) oProcessing.AdjustContrast(oForm.Contrast);
                                if (oForm.Brightness != 0) oProcessing.AdjustBrightness(oForm.Brightness);
                                break;
                            case ControlSet.ColourBalance:
                                oProcessing.AdjustColour(oForm.Red, oForm.Green, oForm.Blue);
                                break;
                            case ControlSet.Gamma:
                                oProcessing.AdjustGamma(oForm.Gamma, oForm.Gamma, oForm.Gamma);
                                break;
                            case ControlSet.Transparency:
                                oProcessing.AdjustTransparency(oForm.Transparency, oForm.Threshold);
                                break;
                            case ControlSet.Noise:
                                oProcessing.ApplyNoiseFilter(oForm.Noise);
                                break;
                        }

                        // Update the main image.
                        imgbx_MainImage.ImageBoxImage = oProcessing.GetProcessedImage();

                        // Save the current image state.
                        m_oUndoRedo.Add(imgbx_MainImage.ImageBoxImage);
                    }

                    Cursor.Current = Cursors.Default;

                    return SResult.Completed;
                }
            }

            return SResult.Canceled;
        }

        #endregion
    }
}