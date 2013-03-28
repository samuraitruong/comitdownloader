//::///////////////////////////////////////////////////////////////////////////
//:: File Name: MainWindow.cs
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
#define DEBUG
#define DEVELOPER_VERSION
#define END_USER_VERSION
//::///////////////////////////////////////////////////////////////////////////
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;
using IView.Controls.Library;
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
    public partial class MainWindow : Form
    {
        public string InitPath { get; set; }

        #region Constructors

        /// <summary>
        /// Creates a new instance of the MainWindow class initialized with default values.
        /// </summary>
        public MainWindow()
        {
            // Configure the application.
            ConfigureApplication();
        }

        /// <summary>
        /// Creates a new instance of the MainWindow class initialized with the specified parameters.
        /// </summary>
        /// <param name="sCmdArgs">Command line arguments.</param>
        public MainWindow(string[] sCmdArgs)
        {
            // Configure the application.
            ConfigureApplication();

            // Check for command line arguments.
            if ((sCmdArgs != null) && (sCmdArgs.Length > 0))
            {
                string sPath = sCmdArgs[0];

                if (!string.IsNullOrEmpty(sPath))
                    SubOpenDirectory(Path.GetDirectoryName(sPath), sPath, ImageFileType.All);
                //play playslide show
                if (sCmdArgs[1] == "1")
                {
                    SubStartSlideShow(true);
                    
                    //this.ShowDialog();
                    //foreach (ListViewItem item in elvw_Images.Items)
                    //{
                    //    item.Selected = true;
                    //}
                    
                   
                }
            }
            
        }

        #endregion

        #region Form events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ImageHasBeenEdited)
            {
                if (ShowImageEditedDialog() == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
            }

            // Save the users settings.
            SaveSettings();
        }

        #endregion

        #region Image browser events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageBrowser_FileRenamed(object sender, ImageBrowserRenameEventArgs e)
        {
            string sFileName = Path.GetFileName(e.NewPath);

            // Update the forms text property.
            this.Text = ApplicationData.ApplicationName + " - " + sFileName;

            // Update the save tool strip button text property.
            tsb_tb_Save.Text = "&Save " + sFileName + " (Ctrl+S)";

            // Update the properties. TEMP!
            m_oPropertiesPanel.Properties = m_oImageBrowser.ImageInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageBrowser_ItemRemoved(object sender, ImageBrowserItemEventArgs e)
        {
            if (e.Count > 0)
                SubLoadImage(Navigate.Index, null, m_oImageBrowser.SelectedIndex);
            else
                SubCleanUpResetUI(false);
        }

        #endregion

        #region Update checker events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateChecker_UpdateCheckStarted(object sender, EventArgs e)
        {
            tssl_Info.Text = "Checking for updates...";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateChecker_UpdateCheckFinished(object sender, UpdateCheckFinishedEventArgs e)
        {
            Version oVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            if ((e.CurrentVersion != null) && (oVersion.CompareTo(e.CurrentVersion) < 0))
            {
                // Update the status label.
                tssl_Info.Text = "New update available";

                // Show the update locations form.
                using (UpdateLocations oForm = new UpdateLocations(e.GetLocations()))
                    oForm.ShowDialog();
            }
            else
            {
                // Update the status label.
                tssl_Info.Text = "No updates found";

                if (m_bShowNoUpdatesFoundDialog)
                {
                    MessageBox.Show("There are currently no new updates available.", "Update Check",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            tssl_Info.Text = "Ready";
        }

        #endregion 

        #region Docking window events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DockingWindow_DockChanged(object sender, DockChangedEventArgs e)
        {
            DockingWindow oWnd = sender as DockingWindow;

            if (oWnd != null)
            {
                switch (oWnd.Name)
                {
                    case "ExplorerDockingWindow":
                        switch (oWnd.IsDocked)
                        {
                            case true:
                                tsb_etvw_Close.Visible = true;
                                tsb_tb_ExplorerWindow.Enabled = true;
                                ExplorerSplitterPanelCollapsed = (e.DockingWindowClosed);
                                break;
                            case false:
                                tsb_etvw_Close.Visible = false;
                                tsb_tb_ExplorerWindow.Enabled = false;
                                ExplorerSplitterPanelCollapsed = true;
                                break;
                        }
                        break;
                    case "ImageListDockingWindow":
                        switch (oWnd.IsDocked)
                        {
                            case true:
                                tsb_elvw_Close.Visible = true;
                                tsb_tb_ImageListWindow.Enabled = true;
                                ImageListSplitterPanelCollapsed = (e.DockingWindowClosed);
                                break;
                            case false:
                                tsb_elvw_Close.Visible = false;
                                tsb_tb_ImageListWindow.Enabled = false;
                                ImageListSplitterPanelCollapsed = true;
                                break;
                        }
                        switch (m_nImageListViewType)
                        {
                            case ImageListViewType.LargeIcons:
                                NativeMethods.SetListViewItemSpacing(elvw_Images,
                                    LVW_ICON_L_W, LVW_ICON_L_H);
                                break;
                            case ImageListViewType.MediumIcons:
                                NativeMethods.SetListViewItemSpacing(elvw_Images,
                                    LVW_ICON_M_W, LVW_ICON_M_H);
                                break;
                            case ImageListViewType.SmallIcons:
                                NativeMethods.SetListViewItemSpacing(elvw_Images,
                                    LVW_ICON_S_W, LVW_ICON_S_H);
                                break;
                        }
                        break;
                    case "TaskDockingWindow":
                        switch (oWnd.IsDocked)
                        {
                            case true:
                                tsb_task_Close.Visible = true;
                                tsb_tb_TasksWindow.Enabled = true;
                                TaskSplitterPanelCollapsed = (e.DockingWindowClosed);
                                break;
                            case false:
                                tsb_task_Close.Visible = false;
                                tsb_tb_TasksWindow.Enabled = false;
                                TaskSplitterPanelCollapsed = true;
                                break;
                        }                        
                        break;
                }
            }
        }

        #endregion

        #region Print document events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (imgbx_MainImage.IsImageLoaded)
            {
                int nWidth = imgbx_MainImage.ImageBoxImage.Width;
                int nHeight = imgbx_MainImage.ImageBoxImage.Height;

                Size ImageSize = ScaleHitTestTools.GetRectangleScaled(
                    nWidth, nHeight, e.PageBounds.Width, e.PageBounds.Height, false);

                Point ImagePosition = ScaleHitTestTools.GetRectangleCenter(
                    ImageSize.Width, ImageSize.Height, e.PageBounds.Width, e.PageBounds.Height);

                e.Graphics.DrawImage(imgbx_MainImage.ImageBoxImage, new Rectangle(ImagePosition, ImageSize));
            }
        }

        #endregion

        #region Docking context menutrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_Docking_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip oContextMenuStrip = sender as ContextMenuStrip;

            if (oContextMenuStrip != null)
            {
                bool bDocked = false;

                switch (oContextMenuStrip.OwnerItem.Name)
                {
                    case "tsddb_task_Dock":
                        m_nSelectedWindow = Window.Tasks;
                        bDocked = m_oTaskDockWindow.IsDocked;
                        break;
                    case "tsddb_elvw_Dock":
                        m_nSelectedWindow = Window.ImageList;
                        bDocked = m_oImageListDockWindow.IsDocked;
                        break;
                    case "tsddb_etvw_Dock":
                        m_nSelectedWindow = Window.Explorer;
                        bDocked = m_oExplorerDockWindow.IsDocked;
                        break;
                    default:
                        m_nSelectedWindow = Window.None;
                        break;
                }

                // Enable or disable the tool strip menu items depending on the dock state of the current window.
                tsmi_dock_DockWindow.Enabled = (!bDocked);
                tsmi_dock_FloatingWindow.Enabled = bDocked;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_dock_DockWindow_Click(object sender, EventArgs e)
        {
            SubToggleWindowDocking(m_nSelectedWindow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_dock_FloatingWindow_Click(object sender, EventArgs e)
        {
            SubToggleWindowDocking(m_nSelectedWindow);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_dock_Hide_Click(object sender, EventArgs e)
        {
            switch (m_nSelectedWindow)
            {
                case Window.Explorer:
                    if (m_oExplorerDockWindow.IsDocked)
                        ExplorerSplitterPanelCollapsed = true;
                    else
                        m_oExplorerDockWindow.WindowState = FormWindowState.Minimized;
                    break;
                case Window.ImageList:
                    if (m_oImageListDockWindow.IsDocked)
                        ImageListSplitterPanelCollapsed = true;
                    else
                        m_oImageListDockWindow.WindowState = FormWindowState.Minimized;
                    break;
                case Window.Tasks:
                    if (m_oTaskDockWindow.IsDocked)
                        TaskSplitterPanelCollapsed = true;
                    else
                        m_oTaskDockWindow.WindowState = FormWindowState.Minimized;
                    break;
            }
        }

        #endregion

        #region Explorer treeview context menustrip

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_ExplorerTreeView_Opening(object sender, CancelEventArgs e)
        {
            TreeNode oNode = etvw_Directorys.SelectedNode;

            if (oNode == null)
                return;
            
            if (oNode.Parent == null) // Current node doesn't have a parent node?
            {
                if (oNode.Index == 0) // Favourite base node.
                {
                    tsmi_etvw_NewFavourite.Visible = true;
                    tsmi_etvw_EditFavourite.Visible = false;
                    tsmi_etvw_RemoveAllFavourites.Visible = (m_oFavourites.Count > 1);
                    tsmi_etvw_RemoveFavourite.Visible = false;
                    tsmi_etvw_RefreshDevices.Visible = false;
                }
                else if (oNode.Index == 1) // Computer base node.
                {
                    tsmi_etvw_NewFavourite.Visible = false;
                    tsmi_etvw_EditFavourite.Visible = false;
                    tsmi_etvw_RemoveAllFavourites.Visible = false;
                    tsmi_etvw_RemoveFavourite.Visible = false;
                    tsmi_etvw_RefreshDevices.Visible = true;
                }
                else
                    e.Cancel = true;
            }
            else
            {
                if (oNode.Tag != null) // Favourite nodes
                {
                    tsmi_etvw_NewFavourite.Visible = false;
                    tsmi_etvw_EditFavourite.Visible = true;
                    tsmi_etvw_EditFavourite.Text = "Edit " + oNode.Text + "...";
                    tsmi_etvw_RemoveAllFavourites.Visible = false;
                    tsmi_etvw_RemoveFavourite.Visible = true;
                    tsmi_etvw_RemoveFavourite.Text = "Remove " + oNode.Text;
                    tsmi_etvw_RefreshDevices.Visible = false;
                }
                else // Directory nodes
                    e.Cancel = true;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_etvw_NewFavourite_Click(object sender, EventArgs e)
        {
            SubAddFavourite(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_etvw_EditFavourite_Click(object sender, EventArgs e)
        {
            SubEditFavourite();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_etvw_RemoveAllFavourites_Click(object sender, EventArgs e)
        {
            SubRemoveAllFavourites();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_etvw_RemoveFavourite_Click(object sender, EventArgs e)
        {
            SubRemoveFavourite();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_etvw_RefreshDevices_Click(object sender, EventArgs e)
        {
            if (etvw_Directorys.BaseNodesAdded)
                etvw_Directorys.RefreshDeviceList();
        } 

        #endregion

        #region Explorer tree view toolstrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_etvw_Close_Click(object sender, EventArgs e)
        {
            ExplorerSplitterPanelCollapsed = true;
        }

        #endregion

        #region Explorer tree view events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void etvw_Directorys_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level != 0)
                SubOpenDirectory(e.Node.Name, null, ImageFileType.All);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void etvw_Directorys_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode oNode = etvw_Directorys.GetNodeAt(e.X, e.Y);

                if (oNode != null)
                    etvw_Directorys.SelectedNode = oNode;
            }
        }

        #endregion

        #region Explorer list view toolstrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_elvw_Close_Click(object sender, EventArgs e)
        {
            ImageListSplitterPanelCollapsed = true;
        }

        #endregion

        #region Explorer list view events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elvw_Images_DoubleClick(object sender, EventArgs e)
        {
            if (IViewSettings.Default.OpenNewWindowDoubleClick)
            {
                if ((elvw_Images.SelectedItems != null) && (elvw_Images.SelectedItems.Count == 1))
                    SubOpenNewWindow();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elvw_Images_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            int nSelectedItemCount = elvw_Images.SelectedItems.Count;

            if (e.IsSelected)
            {
                if (nSelectedItemCount == 1)
                    SubLoadImage(Navigate.Path, e.Item.Name, 0);
            }

            tsl_elvw_ItemInfo.Text = "Items: " + elvw_Images.Items.Count + ", Selected: " + nSelectedItemCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elvw_Images_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (elvw_Images.SelectedItems.Count > 0))
            {
                System.Collections.Specialized.StringCollection oPaths =
                    new System.Collections.Specialized.StringCollection();

                foreach (ListViewItem oItem in elvw_Images.SelectedItems)
                {
                    // Add the name of the item if it isn't empty or null to path list
                    if (!string.IsNullOrEmpty(oItem.Name))
                    {
                        if (File.Exists(oItem.Name))
                            oPaths.Add(oItem.Name);
                    }
                }

                if (oPaths.Count > 0)
                {
                    // Create a data object and add the path collection to the file drop list.
                    DataObject oData = new DataObject();
                    oData.SetFileDropList(oPaths);

                    // Perform the drag and drop, with the file path collection and move drag and drop effect.
                    elvw_Images.DoDragDrop(oData, DragDropEffects.Move);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elvw_Images_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            m_sBeforeLabelEditText = e.Label;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void elvw_Images_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (m_sBeforeLabelEditText != e.Label)
            {
                if (elvw_Images.SelectedItems.Count == 1)
                {
                    string sNewName = e.Label;
                    string sCurrentFilePath = elvw_Images.SelectedItems[0].Name;

                    // Cancel and return if the current path is null, empty or white space.
                    if (string.IsNullOrEmpty(sCurrentFilePath))
                    {
                        e.CancelEdit = true;
                        return;
                    }

                    // Cancel and return if the new file name contains invalid characters.
                    if (sNewName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                    {
                        e.CancelEdit = true;
                        return;
                    }

                    // Construct the new file path.
                    string sDirectory = Path.GetDirectoryName(sCurrentFilePath);
                    string sExtension = Path.GetExtension(sCurrentFilePath);
                    string sNewPath = sDirectory + Path.DirectorySeparatorChar + sNewName + sExtension;

                    if (!File.Exists(sNewPath))
                    {
                        if (m_oImageBrowser != null)
                        {
                            // Cancel the edit operation, as the rename method takes
                            // care of updating controls and members.
                            e.CancelEdit = true;

                            try
                            {
                                // Try and rename the file.
                                m_oImageBrowser.RenameFile(sNewName);
                            }
                            catch (UnauthorizedAccessException ex)
                            {
                                MessageBox.Show("Unable to rename file: " + sCurrentFilePath + " to "
                                    + sNewPath + "\n\nReason: " + ex.Message, "Rename File Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (IOException ex)
                            {
                                MessageBox.Show("Unable to rename file: " + sCurrentFilePath + " to "
                                    + sNewPath + "\n\nReason: " + ex.Message, "Rename File Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            catch (System.Security.SecurityException ex)
                            {
                                MessageBox.Show("Unable to rename file: " + sCurrentFilePath + " to "
                                    + sNewPath + "\n\nReason: " + ex.Message, "Rename File Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("A file with the same name already exists.", "Rename Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Explorer list view context menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_ExplorerListView_Opening(object sender, CancelEventArgs e)
        {
            int nSelectedItems = elvw_Images.SelectedItems.Count;

            if (nSelectedItems <= 0)
            {
                tsmi_elvw_Copy.Enabled = false;
                tsmi_elvw_Rename.Enabled = false;
                tsmi_elvw_Delete.Enabled = false;
                tsmi_elvw_View.Enabled = true;
                tsmi_elvw_CopyPath.Enabled = false;
                tsmi_elvw_OpenContainingFolder.Enabled = false;
            }
            else
            {
                tsmi_elvw_Copy.Enabled = true;
                tsmi_elvw_Rename.Enabled = (nSelectedItems == 1);
                tsmi_elvw_Delete.Enabled = true;
                tsmi_elvw_View.Enabled = true;
                tsmi_elvw_CopyPath.Enabled = true;
                tsmi_elvw_CopyPath.Text = "Copy File " + ((nSelectedItems > 1) ? "Paths" : "Path");
                tsmi_elvw_OpenContainingFolder.Enabled = true;
            }

            tsmi_elvw_SelectAll.Enabled = (elvw_Images.Items.Count > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_elvw_Copy_Click(object sender, EventArgs e)
        {
            SubCopy(CopyDataType.File);
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_elvw_Delete_Click(object sender, EventArgs e)
        {
            SubDeleteFiles();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_elvw_Rename_Click(object sender, EventArgs e)
        {
            if (elvw_Images.SelectedItems.Count == 1)
                elvw_Images.SelectedItems[0].BeginEdit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_elvw_CopyPath_Click(object sender, EventArgs e)
        {
            int nSelectedItems = elvw_Images.SelectedItems.Count;

            if (nSelectedItems > 0)
            {
                string sData = string.Empty;

                // Enumerate the selected listview items and append each path to the string.
                foreach (ListViewItem oItem in elvw_Images.SelectedItems)
                    sData += oItem.Name + Environment.NewLine;

                try
                {
                    // Copy the paths to the clipboard.
                    if (!string.IsNullOrEmpty(sData))
                        Clipboard.SetText(sData);
                }
                catch (System.Runtime.InteropServices.ExternalException ex)
                {
                    MessageBox.Show("Unable to copy the data to the clipboard.\n\nReason: " + ex.Message, "Copy Data Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_elvw_OpenContainingFolder_Click(object sender, EventArgs e)
        {
            if (m_oImageBrowser != null)
                StartProcess(m_oImageBrowser.SelectedDirectory);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_elvw_SelectAll_Click(object sender, EventArgs e)
        {
            if (elvw_Images.Items.Count > 0)
            {
                foreach (ListViewItem oItem in elvw_Images.Items)
                    oItem.Selected = true;
            }
        }

        #endregion

        #region View context menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_ImageListView_Opening(object sender, CancelEventArgs e)
        {
            tsmi_ilvw_LargeIcons.Checked = (m_nImageListViewType == ImageListViewType.LargeIcons);
            tsmi_ilvw_MediumIcons.Checked = (m_nImageListViewType == ImageListViewType.MediumIcons);
            tsmi_ilvw_SmallIcons.Checked = (m_nImageListViewType == ImageListViewType.SmallIcons);
            tsmi_ilvw_List.Checked = (m_nImageListViewType == ImageListViewType.List);
            tsmi_ilvw_Details.Checked = (m_nImageListViewType == ImageListViewType.Details);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_ilvw_LargeIcons_Click(object sender, EventArgs e)
        {
            SubSetImageListView(ImageListViewType.LargeIcons);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_ilvw_MediumIcons_Click(object sender, EventArgs e)
        {
            SubSetImageListView(ImageListViewType.MediumIcons);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_ilvw_SmallIcons_Click(object sender, EventArgs e)
        {
            SubSetImageListView(ImageListViewType.SmallIcons);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_ilvw_List_Click(object sender, EventArgs e)
        {
            SubSetImageListView(ImageListViewType.List);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_ilvw_Details_Click(object sender, EventArgs e)
        {
            SubSetImageListView(ImageListViewType.Details);
        }

        #endregion

        #region Menustrip events

        /// <summary>
        /// Enables all toolstrip menu items when the parent drop down is closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ms_tsmi_DropDownClosed(object sender, EventArgs e)
        {
            ToolStripMenuItem oMenuItem = sender as ToolStripMenuItem;

            if ((oMenuItem != null) && (oMenuItem.DropDown != null))
            {
                foreach (ToolStripItem oItem in oMenuItem.DropDown.Items)
                {
                    if (!oItem.Enabled)
                        oItem.Enabled = true;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_FullScreen_Click(object sender, EventArgs e)
        {
            SubToggleFullScreenMode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Exit_Click(object sender, EventArgs e)
        {
            SubExit();
        }

        #endregion

        #region Toolbar events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_Toolbar_LayoutStyleChanged(object sender, EventArgs e)
        {
            switch (ts_Toolbar.Orientation)
            {
                case Orientation.Horizontal:
                    tss_tb_04.Visible = true;
                    tscbx_tb_Zoom.Overflow = ToolStripItemOverflow.AsNeeded;
                    break;
                case Orientation.Vertical:
                    tss_tb_04.Visible = false;
                    tscbx_tb_Zoom.Overflow = ToolStripItemOverflow.Always;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_tb_Open_Click(object sender, EventArgs e)
        {
            SubOpenDirectory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_tb_AddFavourite_Click(object sender, EventArgs e)
        {
            SubAddFavourite(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_tb_Save_Click(object sender, EventArgs e)
        {
            SubSaveImage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssb_tb_Print_ButtonClick(object sender, EventArgs e)
        {
            SubPrint();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscbx_tb_Zoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Return if the combobox does not have focus.
            if (!tscbx_tb_Zoom.Focused)
                return;

            // If the selected item is null, return.
            if (tscbx_tb_Zoom.SelectedItem == null)
                return;

            string sItem = tscbx_tb_Zoom.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(sItem))
            {
                float fPercent = 0.0f;
                string sPercent = sItem.TrimEnd(new char[] { '%' });

                if (float.TryParse(sPercent, out fPercent))
                    SubZoom(fPercent);
                else
                    SubToggleScaleMode();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscbx_tb_Zoom_Leave(object sender, EventArgs e)
        {
            if (!imgbx_MainImage.IsImageLoaded)
                return;

            string sItem = tscbx_tb_Zoom.Text;
            float fZoom = ScaleHitTestTools.GetScalePercentage(
                imgbx_MainImage.ImageBoxImage.Width, imgbx_MainImage.ImageBoxSize.Width);

            if (!string.IsNullOrEmpty(sItem))
            {
                if (tscbx_tb_Zoom.Items.Contains(sItem))
                {
                    if (string.Compare(sItem, "Auto Scale", true) == 0)
                        tscbx_tb_Zoom.Text = fZoom.ToString("n1") + "%";
                }
                else
                    tscbx_tb_Zoom.Text = fZoom.ToString("n1") + "%";
            }
            else
                tscbx_tb_Zoom.Text = fZoom.ToString("n1") + "%";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tb_PageSetup_Click(object sender, EventArgs e)
        {
            SubPageSetup();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tb_PrintPreview_Click(object sender, EventArgs e)
        {
            SubPrintPreview();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tb_Print_Click(object sender, EventArgs e)
        {
            SubPrint();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_tb_RotateLeft90_Click(object sender, EventArgs e)
        {
            SubRotateImage(RotateFlipType.Rotate270FlipNone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_tb_RotateRight90_Click(object sender, EventArgs e)
        {
            SubRotateImage(RotateFlipType.Rotate90FlipNone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_tb_SlideShow_Click(object sender, EventArgs e)
        {
            SubStartSlideShow();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_tb_EyeDropper_Click(object sender, EventArgs e)
        {
            switch (tsb_tb_EyeDropper.Checked)
            {
                case true:
                    CurrentTool = Tool.EyeDropper;
                    tsl_tb_PixelInfo.Visible = true;
                    break;
                case false:
                    CurrentTool = Tool.None;
                    tsl_tb_PixelInfo.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_tb_ExplorerWindow_Click(object sender, EventArgs e)
        {
            SubToggleWindow(Window.Explorer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_tb_ImageListWindow_Click(object sender, EventArgs e)
        {
            SubToggleWindow(Window.ImageList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_tb_TasksWindow_ButtonClick(object sender, EventArgs e)
        {
            SubToggleWindow(Window.Tasks);
        }

        #endregion

        #region File menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_File_DropDownOpening(object sender, EventArgs e)
        {
            bool bEnable = (m_oImageBrowser.IsLoaded) ? (imgbx_MainImage.IsImageLoaded) : false;

            tsmi_file_AddFavourite.Enabled = bEnable;
            tsmi_file_Save.Enabled = bEnable;
            tsmi_file_SaveAs.Enabled = bEnable;
            tsmi_file_PageSetup.Enabled = bEnable;
            tsmi_file_PrintPreview.Enabled = bEnable;
            tsmi_file_Print.Enabled = bEnable;

            if (bEnable)
            {
                string sSave = "&Save " + Path.GetFileName(m_oImageBrowser.SelectedFile);

                tsmi_file_Save.Text = sSave;
                tsmi_file_SaveAs.Text = sSave + " &As...";
            }
            else
            {
                tsmi_file_Save.Text = "&Save";
                tsmi_file_SaveAs.Text = "Save &As...";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_OpenImageFile_Click(object sender, EventArgs e)
        {
            SubOpenDirectory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_OpenSlideShowFile_Click(object sender, EventArgs e)
        {
            SubOpenSlideShow();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_NewFavourite_Click(object sender, EventArgs e)
        {
            SubAddFavourite(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_AddFavourite_Click(object sender, EventArgs e)
        {
            SubAddFavourite(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_Save_Click(object sender, EventArgs e)
        {
            SubSaveImage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_SaveAs_Click(object sender, EventArgs e)
        {
            SubSaveImageAs();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_PageSetup_Click(object sender, EventArgs e)
        {
            SubPageSetup();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_PrintPreview_Click(object sender, EventArgs e)
        {
            SubPrintPreview();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_Print_Click(object sender, EventArgs e)
        {
            SubPrint();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_Properties_Click(object sender, EventArgs e)
        {
            SubShowTaskWindow(TaskWindow.Properties, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_file_Exit_Click(object sender, EventArgs e)
        {
            SubExit();
        }

        #endregion

        #region Edit menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Edit_DropDownOpening(object sender, EventArgs e)
        {
            if (m_oImageBrowser.IsLoaded)
            {
                bool bEnable = imgbx_MainImage.IsImageLoaded;

                tsmi_edit_Undo.Enabled = m_oUndoRedo.CanUndo;
                tsmi_edit_Redo.Enabled = m_oUndoRedo.CanRedo;
                tsmi_edit_ClearChanges.Enabled = (m_oUndoRedo.Count > 0);
                tsmi_edit_Copy.Enabled = bEnable;
                tsmi_edit_Paste.Enabled = Clipboard.ContainsImage();
                tsmi_edit_Delete.Enabled = bEnable;
                tsmi_edit_Rename.Enabled = bEnable;
                tsmi_edit_SelectAll.Enabled = bEnable;
                tsmi_edit_Transform.Enabled = bEnable;
                tsmi_edit_FreeTransform.Enabled = bEnable;
                tsmi_edit_FreeTransform.Checked = imgbx_MainImage.AllowMouseResize;
            }
            else
            {
                tsmi_edit_Undo.Enabled = false;
                tsmi_edit_Redo.Enabled = false;
                tsmi_edit_ClearChanges.Enabled = false;
                tsmi_edit_Copy.Enabled = false;
                tsmi_edit_Paste.Enabled = false;
                tsmi_edit_Delete.Enabled = false;
                tsmi_edit_Rename.Enabled = false;
                tsmi_edit_SelectAll.Enabled = false;
                tsmi_edit_Transform.Enabled = false;
                tsmi_edit_FreeTransform.Enabled = false;
                tsmi_edit_FreeTransform.Checked = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Undo_Click(object sender, EventArgs e)
        {
            if (m_oUndoRedo.CanUndo)
                imgbx_MainImage.ImageBoxImage = m_oUndoRedo.Undo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Redo_Click(object sender, EventArgs e)
        {
            if (m_oUndoRedo.CanRedo)
                imgbx_MainImage.ImageBoxImage = m_oUndoRedo.Redo();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_ClearChanges_Click(object sender, EventArgs e)
        {
            if (m_oUndoRedo.Count > 0)
                m_oUndoRedo.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Copy_Click(object sender, EventArgs e)
        {
            SubCopy(CopyDataType.PixelData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Paste_Click(object sender, EventArgs e)
        {
            SubPaste();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Delete_Click(object sender, EventArgs e)
        {
            SubDeleteFiles();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Rename_Click(object sender, EventArgs e)
        {
            SubRenameFile();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_SelectAll_Click(object sender, EventArgs e)
        {
            if (elvw_Images.Items.Count > 0)
            {
                // Bring the explorer list view into focus.
                elvw_Images.Focus();

                // Select all the items in the list.
                foreach (ListViewItem oItem in elvw_Images.Items)
                    oItem.Selected = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Resize_Click(object sender, EventArgs e)
        {
            SubShowTaskWindow(TaskWindow.Resize, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Shear_Click(object sender, EventArgs e)
        {
            SubShowTaskWindow(TaskWindow.Shear, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Rotate90Clockwise_Click(object sender, EventArgs e)
        {
            SubRotateImage(RotateFlipType.Rotate90FlipNone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Rotate90CounterClockwise_Click(object sender, EventArgs e)
        {
            SubRotateImage(RotateFlipType.Rotate270FlipNone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_Rotate180_Click(object sender, EventArgs e)
        {
            SubRotateImage(RotateFlipType.Rotate180FlipNone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_FlipHorizontal_Click(object sender, EventArgs e)
        {
            SubRotateImage(RotateFlipType.RotateNoneFlipX);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_FlipVertical_Click(object sender, EventArgs e)
        {
            SubRotateImage(RotateFlipType.RotateNoneFlipY);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_edit_FreeTransform_Click(object sender, EventArgs e)
        {
            if (imgbx_MainImage.IsImageLoaded)
                imgbx_MainImage.AllowMouseResize = (!imgbx_MainImage.AllowMouseResize);
        }

        #endregion

        #region View menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_View_DropDownOpening(object sender, EventArgs e)
        {
            bool bImageLoaded = imgbx_MainImage.IsImageLoaded;
            bool bImageBrowserLoaded = m_oImageBrowser.IsLoaded;
            bool bWindowsOpen = (tsmi_view_Windows.DropDown.Items.Count > 3);

            tsmi_win_OpenNew.Enabled = bImageLoaded;
            tsmi_win_CloseAll.Enabled = bWindowsOpen;
            tss_win_01.Visible = bWindowsOpen;
            tsmi_view_SlideShow.Enabled = bImageBrowserLoaded;
            tsmi_view_Explorer.Enabled = m_oExplorerDockWindow.IsDocked;
            tsmi_view_ImageList.Enabled = m_oImageListDockWindow.IsDocked;
            tsmi_view_Task.Enabled = m_oTaskDockWindow.IsDocked;
            tsmi_view_Toolbar.Checked = ts_Toolbar.Visible;
            tsmi_view_StatusBar.Checked = ss_Main.Visible;
            tsmi_view_Refresh.Enabled = bImageBrowserLoaded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void tsmi_win_OpenNew_Click(object sender, EventArgs e)
        {
            SubOpenNewWindow();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_win_CloseAll_Click(object sender, EventArgs e)
        {
            if ((m_oNewWindows != null) && (m_oNewWindows.Count > 0))
            {
                string sCaption = "Close All Windows";
                string sMessage = "Would you like to close all child windows?";
                DialogResult oDlg = MessageBox.Show(sMessage, sCaption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (oDlg == DialogResult.Yes)
                {
                    foreach (NewWindow oForm in m_oNewWindows.ToArray())
                    {
                        if ((oForm != null) && (!oForm.IsDisposed))
                            oForm.Close();
                    }

                    // Clear the form elements from the list.
                    m_oNewWindows.Clear();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_view_SlideShow_Click(object sender, EventArgs e)
        {
            SubStartSlideShow();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_view_Explorer_Click(object sender, EventArgs e)
        {
            SubToggleWindow(Window.Explorer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_view_ImageList_Click(object sender, EventArgs e)
        {
            SubToggleWindow(Window.ImageList);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_view_Task_Click(object sender, EventArgs e)
        {
            SubToggleWindow(Window.Tasks);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_view_Toolbar_Click(object sender, EventArgs e)
        {
            ts_Toolbar.Visible = (ts_Toolbar.Visible) ? false : true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_view_StatusBar_Click(object sender, EventArgs e)
        {
            ss_Main.Visible = (ss_Main.Visible) ? false : true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_view_FullScreen_Click(object sender, EventArgs e)
        {
            SubToggleFullScreenMode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_view_Refresh_Click(object sender, EventArgs e)
        {
            SubRefresh();
        }

        #endregion

        #region Filters menustrip events TEMP!

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Filters_DropDownOpening(object sender, EventArgs e)
        {
            bool bEnabled = imgbx_MainImage.IsImageLoaded;

            tsmi_filter_ColourBalance.Enabled = bEnabled;
            tsmi_filter_Invert.Enabled = bEnabled;
            tsmi_filter_GreyScale.Enabled = bEnabled;
            tsmi_filter_PhotoCopy.Enabled = bEnabled;
            tsmi_filter_RotateColour.Enabled = bEnabled;
            tsmi_filter_BrightnessContrast.Enabled = bEnabled;
            tsmi_filter_Gamma.Enabled = bEnabled;
            tsmi_filter_Noise.Enabled = bEnabled;
            tsmi_filter_Transparency.Enabled = bEnabled;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_filter_Invert_Click(object sender, EventArgs e)
        {
            SubApplyImageProcessing(InvertFilterStruct.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_filter_PhotoCopy_Click(object sender, EventArgs e)
        {
            SubApplyImageProcessing(PhotoCopyFilterStruct.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_filter_GreyScale_Click(object sender, EventArgs e)
        {
            SubApplyImageProcessing(GreyScaleFilterStruct.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_filter_RotateColour_Click(object sender, EventArgs e)
        {
            SubApplyImageProcessing(RotateColourFilterStruct.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_filter_BrightnessContrast_Click(object sender, EventArgs e)
        {
            SubShowProcessingEditor(ControlSet.BrightnessContrast);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_filter_ColourBalance_Click(object sender, EventArgs e)
        {
            SubShowProcessingEditor(ControlSet.ColourBalance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_filter_Gamma_Click(object sender, EventArgs e)
        {
            SubShowProcessingEditor(ControlSet.Gamma);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_filter_Noise_Click(object sender, EventArgs e)
        {
            SubShowProcessingEditor(ControlSet.Noise);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_filter_Transparency_Click(object sender, EventArgs e)
        {
            SubShowProcessingEditor(ControlSet.Transparency);
        }

        #endregion

        #region Tools menutrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Tools_DropDownOpening(object sender, EventArgs e)
        {
            tsmi_tools_EyeDropper.Checked = (CurrentTool == Tool.EyeDropper);
            tsmi_tools_ScreenCapture.Checked = ((m_oScreenShotForm != null) && (!m_oScreenShotForm.IsDisposed));
            tsmi_tools_AdjustTime.Enabled = m_oImageBrowser.IsLoaded;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tools_BatchEditor_Click(object sender, EventArgs e)
        {
            //using (FormBatchEditor oForm = new FormBatchEditor())
                //oForm.ShowDialog(this);

            //MessageBox.Show("Coming Soon!", "Batch Editor",
                //MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tools_ContactSheet_Click(object sender, EventArgs e)
        {
            //using (FormCreateContactSheet oForm = new FormCreateContactSheet())
                //oForm.ShowDialog(this);

            MessageBox.Show("Coming Soon!", "Create Contact Sheet",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tools_CreateSlideShow_Click(object sender, EventArgs e)
        {
            using (CreateSlideShow oForm = new CreateSlideShow())
                oForm.ShowDialog(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tools_AdjustTime_Click(object sender, EventArgs e)
        {
            if (m_oImageBrowser.IsLoaded)
            {
                string[] sFilePaths = null;

                if ((elvw_Images.SelectedItems != null) && (elvw_Images.SelectedItems.Count > 1))
                {
                    // Initialize a new string array with the number of elements
                    // set to the number selected items in the listview control.
                    sFilePaths = new string[elvw_Images.SelectedItems.Count];

                    // Loop through the items and add the name property of the item to the file path array.
                    for (int n = 0; n < elvw_Images.SelectedItems.Count; n++)
                        sFilePaths[n] = elvw_Images.SelectedItems[n].Name;
                }
                else
                {
                    // If only one file is selected get the image browser selected file path.
                    sFilePaths = new string[] { m_oImageBrowser.SelectedFile };
                }

                // Show the AdjustTime form.
                using (AdjustTime oForm = new AdjustTime(sFilePaths))
                    oForm.ShowDialog(this);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tools_EyeDropper_Click(object sender, EventArgs e)
        {
            switch (tsb_tb_EyeDropper.Checked)
            {
                case false:
                    CurrentTool = Tool.EyeDropper;
                    tsb_tb_EyeDropper.Checked = true;
                    tsl_tb_PixelInfo.Visible = true;
                    break;
                case true:
                    CurrentTool = Tool.None;
                    tsb_tb_EyeDropper.Checked = false;
                    tsl_tb_PixelInfo.Visible = false;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tools_ScreenCapture_Click(object sender, EventArgs e)
        {
            if ((m_oScreenShotForm != null) && (!m_oScreenShotForm.IsDisposed))
                m_oScreenShotForm.Focus();
            else
            {
                m_oScreenShotForm = new ScreenShot();
                m_oScreenShotForm.Show();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tools_RedEyeCorrection_Click(object sender, EventArgs e)
        {
            SubShowTaskWindow(TaskWindow.RedEyeCorrection, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_tools_Options_Click(object sender, EventArgs e)
        {
            using (Options oForm = new Options())
            {
                if (oForm.ShowDialog(this) == DialogResult.OK)
                    UpdateChangedSettings();
            }
        }

        #endregion

        #region Help menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_help_Documentation_Click(object sender, EventArgs e)
        {
            //StartProcess(ApplicationData.GetHelpDocumentationFile);

            MessageBox.Show("Help documentation is currently unavailable.", "Help Documentation",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_help_ReadMe_Click(object sender, EventArgs e)
        {
            StartProcess(ApplicationData.ReadMeTextFile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_help_CheckUpdates_Click(object sender, EventArgs e)
        {
            SubCheckForUpdates(true, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_help_Donation_Click(object sender, EventArgs e)
        {
            StartProcess(ApplicationData.DonationUri.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_help_VisitHome_Click(object sender, EventArgs e)
        {
            StartProcess(ApplicationData.HomepageUri.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_help_Codeplex_Click(object sender, EventArgs e)
        {
            StartProcess(ApplicationData.CodeplexUri.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_help_About_Click(object sender, EventArgs e)
        {
            bool bShowLicense = false;

            // Show the application about box form.
            using (AboutBox oForm = new AboutBox())
            {
                if (oForm.ShowDialog(this) == DialogResult.OK)
                    bShowLicense = true;
            }

            // Show the license form if specified.
            if (bShowLicense)
            {
                using (License oForm = new License())
                    oForm.ShowDialog(this);
            }
        }

        #endregion

        #region Image box events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_ImageBoxImageLoaded(object sender, ImageBoxEventArgs e)
        {
            SubUpdateControlsOnImageLoad();

            SubScaleDisplayImage(m_nImageScale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_ImageBoxMouseMove(object sender, ImageBoxMouseEventArgs e)
        {
            int nX = e.X - imgbx_MainImage.AutoScrollPosition.X;
            int nY = e.Y - imgbx_MainImage.AutoScrollPosition.Y;

            tssl_MousePosition.Text = nX + ", " + nY;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_ImageBoxMouseEnter(object sender, ImageBoxEventArgs e)
        {
            // Show the mouse position label.
            tssl_MousePosition.Visible = true;

            // Update the cursor if a tool has been selected.
            switch (CurrentTool)
            {
                case Tool.EyeDropper:
                    imgbx_MainImage.Cursor =
                        Tools.CreateCursor(Resources.EyeDropperCursor);
                    break;
                case Tool.RedEyeCorrection:
                    imgbx_MainImage.Cursor =
                        Tools.CreateCursor(Resources.RedEyeCursor);
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_ImageBoxMouseLeave(object sender, ImageBoxEventArgs e)
        {
            // Hide the mouse position label.
            tssl_MousePosition.Visible = false;
            
            if (CurrentTool != Tool.None)
                imgbx_MainImage.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_ImageBoxMouseDown(object sender, ImageBoxMouseEventArgs e)
        {
            if (e.MouseButton == MouseButtons.Left)
            {
                int nX = e.X - imgbx_MainImage.AutoScrollPosition.X;
                int nY = e.Y - imgbx_MainImage.AutoScrollPosition.Y;

                switch (CurrentTool)
                {
                    case Tool.EyeDropper:
                        SubEyeDropperTool(nX, nY);
                        break;
                    case Tool.RedEyeCorrection:
                        SubRedEyeCorrectionTool(nX, nY);
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_ImageBoxMouseWheel(object sender, MouseEventArgs e)
        {
            if (m_nImageBoxKeyPressed == Keys.ShiftKey)
            {
                // Load the image depending on the wheel delta value.
                SubLoadImage((e.Delta >= 120) ? Navigate.Next : Navigate.Previous, null, 0);
            }
            else if (m_nImageBoxKeyPressed == Keys.ControlKey)
            {
                float fZoom = ScaleHitTestTools.GetScalePercentage(imgbx_MainImage.ImageBoxImage.Width,
                    imgbx_MainImage.ImageBoxSize.Width);

                // Increment or decrement the zoom value depending on the wheel delta value.
                fZoom = (e.Delta >= 120) ? fZoom += 10.0f : fZoom -= 10.0f;

                // Clamp the zooming values.
                if (fZoom < 12.5f) fZoom = 12.5f;
                if (fZoom > 800.0f) fZoom = 800.0f;

                // Zoom the image to the specified percentage.
                SubZoom(fZoom);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_KeyDown(object sender, KeyEventArgs e)
        {
            m_nImageBoxKeyPressed = e.KeyCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_KeyUp(object sender, KeyEventArgs e)
        {
            m_nImageBoxKeyPressed = Keys.None;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_SizeChanged(object sender, EventArgs e)
        {
            SubScaleDisplayImage(m_nImageScale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
                return;

            string[] sPaths = (string[])e.Data.GetData(DataFormats.FileDrop);

            if ((sPaths != null) && (sPaths.Length > 0))
            {
                if (!string.IsNullOrEmpty(sPaths[0]))
                {
                    if (FileTools.IsFileExtensionValid(Path.GetExtension(sPaths[0])))
                        e.Effect = DragDropEffects.Link;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_MainImage_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect != DragDropEffects.Link)
                return;

            string[] sPaths = (string[])e.Data.GetData(DataFormats.FileDrop);

            if ((sPaths != null) && (sPaths.Length > 0))
            {
                if (!string.IsNullOrEmpty(sPaths[0]))
                {
                    if (FileTools.IsFileExtensionValid(Path.GetExtension(sPaths[0])))
                    {
                        // Get the parent folder of the file.
                        string sDirectory = Path.GetDirectoryName(sPaths[0]);

                        // Open the parent directory.
                        SubOpenDirectory(sDirectory, sPaths[0], ImageFileType.All);
                    }
                }
            }
        }

        #endregion

        #region Image box toolstrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsddb_imgbx_Directorys_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            SubOpenDirectory(e.ClickedItem.Name, string.Empty, ImageFileType.All);
        }

        #endregion

        #region Image box navigate button events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_nav_NextImage_Click(object sender, EventArgs e)
        {
            SubLoadImage(Navigate.Next, null, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_nav_PreviousImage_Click(object sender, EventArgs e)
        {
            SubLoadImage(Navigate.Previous, null, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_nav_FirstImage_Click(object sender, EventArgs e)
        {
            SubLoadImage(Navigate.First, null, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_nav_LastImage_Click(object sender, EventArgs e)
        {
            SubLoadImage(Navigate.Last, null, 0);
        }

        #endregion

        #region Image box context menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_ImageBox_Opening(object sender, CancelEventArgs e)
        {
            if (m_oImageBrowser.IsLoaded)
            {
                bool bImageLoaded = false;

                if (imgbx_MainImage.IsImageLoaded)
                    bImageLoaded = true;

                tsmi_imgbx_Copy.Enabled = bImageLoaded;
                tsmi_imgbx_Delete.Enabled = bImageLoaded;
                tsmi_imgbx_Paste.Enabled = Clipboard.ContainsImage();
                tsmi_imgbx_Rename.Enabled = bImageLoaded;
                tsmi_imgbx_AutoScale.Enabled = bImageLoaded;
                tsmi_imgbx_AutoScale.Checked = (m_nImageScale == ImageScale.Auto);
                tsmi_imgbx_SetBackGround.Enabled = bImageLoaded;
            }
            else
            {
                tsmi_imgbx_Copy.Enabled = false;
                tsmi_imgbx_Delete.Enabled = false;
                tsmi_imgbx_Paste.Enabled = false;
                tsmi_imgbx_Rename.Enabled = false;
                tsmi_imgbx_AutoScale.Enabled = false;
                tsmi_imgbx_AutoScale.Checked = (m_nImageScale == ImageScale.Auto);
                tsmi_imgbx_SetBackGround.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_imgbx_Copy_Click(object sender, EventArgs e)
        {
            SubCopy(CopyDataType.PixelData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_imgbx_Paste_Click(object sender, EventArgs e)
        {
            SubPaste();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_imgbx_Rename_Click(object sender, EventArgs e)
        {
            SubRenameFile();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_imgbx_Delete_Click(object sender, EventArgs e)
        {
            SubDeleteFiles();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_imgbx_AutoScale_Click(object sender, EventArgs e)
        {
            SubToggleScaleMode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_imgbx_CenterImage_Click(object sender, EventArgs e)
        {
            SubSetWallPaper(WallPaperStyle.Center);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_imgbx_StretchImage_Click(object sender, EventArgs e)
        {
            SubSetWallPaper(WallPaperStyle.Stretch);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_imgbx_TileImage_Click(object sender, EventArgs e)
        {
            SubSetWallPaper(WallPaperStyle.Tile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_imgbx_Properties_Click(object sender, EventArgs e)
        {
            SubShowTaskWindow(TaskWindow.Properties, true);
        }

        #endregion

        #region Task toolstrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_task_Close_Click(object sender, EventArgs e)
        {
            TaskSplitterPanelCollapsed = true;
        }

        #endregion                        

        #region Task context menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_task_Properties_Click(object sender, EventArgs e)
        {
            SubShowTaskWindow(TaskWindow.Properties, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_task_Colour_Click(object sender, EventArgs e)
        {
            SubShowTaskWindow(TaskWindow.ColourEditor, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_task_RedEyeCorrection_Click(object sender, EventArgs e)
        {
            SubShowTaskWindow(TaskWindow.RedEyeCorrection, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_task_Resize_Click(object sender, EventArgs e)
        {
            SubShowTaskWindow(TaskWindow.Resize, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_task_Shear_Click(object sender, EventArgs e)
        {
            SubShowTaskWindow(TaskWindow.Shear, true);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    switch ((int)m.WParam)
                    {
                        case DBT_DEVICEARRIVAL:
                        case DBT_DEVICEREMOVECOMPLETE:
                            if (etvw_Directorys.BaseNodesAdded)
                                etvw_Directorys.RefreshDeviceList();
                            break;
                    }
                    break;
            }

            base.WndProc(ref m);
        }

        #endregion                

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InitPath))
            {

            }
        }
    }
}