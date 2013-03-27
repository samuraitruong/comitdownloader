//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ExplorerTreeView.cs
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
using System.Collections;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using IView.Controls.Data;
using ComicDownloader.Properties;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// Provides a windows explorer type tree view control, allowing the user to select system
    /// drives and directorys.
    /// </summary>
    public class ExplorerTreeView : TreeView
    {
        #region Fields and properties

        private const int NODE_COMPUTER_INDEX = 1;

        private bool m_bBaseNodesAdded;
        private string m_sCurrentPath;
        private ArrayList m_oMappedDrives;
        private ArrayList m_oCurrentDrives;
        private ImageList m_oImageList;

        /// <summary>
        /// Gets a value indicating whether the base nodes have been added to the explorer tree view control.
        /// </summary>
        public bool BaseNodesAdded
        {
            get { return m_bBaseNodesAdded; }
        }

        /// <summary>
        /// Gets the full path of the currently selected tree node item.
        /// </summary>
        public string CurrentPath
        {
            get { return m_sCurrentPath; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the DirectoryTreeView class.
        /// </summary>
        public ExplorerTreeView()
        {
            m_oMappedDrives = new ArrayList();
            m_oCurrentDrives = new ArrayList();
            m_oImageList = new ImageList();
            m_oImageList.ImageSize = new Size(16, 16);
            m_oImageList.ColorDepth = ColorDepth.Depth24Bit;
            m_oImageList.Images.Add(Resources.folder_closed_16x16);
            m_oImageList.Images.Add(Resources.folder_opened_16x16);
            m_oImageList.Images.Add(Resources.folder_hidden_closed_16x16);
            m_oImageList.Images.Add(Resources.folder_hidden_opened_16x16);
            m_oImageList.Images.Add(Resources.pictures_16x16);
            m_oImageList.Images.Add(Resources.desktop_16x16);
            m_oImageList.Images.Add(Resources.documents_16x16);
            m_oImageList.Images.Add(Resources.cd_rom_16x16);
            m_oImageList.Images.Add(Resources.hard_drive_16x16);
            m_oImageList.Images.Add(Resources.removable_disk_16x16);
            m_oImageList.Images.Add(Resources.ram_16x16);
            m_oImageList.Images.Add(Resources.network_drive_16x16);
            m_oImageList.Images.Add(Resources.unknown_drive_16x16);
            m_oImageList.Images.Add(Resources.computer_16x16);
            m_oImageList.Images.Add(Resources.favourites_16x16);

            this.ShowPlusMinus = false;
            this.ShowLines = false;
            this.ShowRootLines = false;
            this.ImageList = m_oImageList;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a NodeImageType enumeration specified by the drive type.
        /// </summary>
        /// <param name="nDriveType">Specifies the DriveType enumeration.</param>
        /// <returns></returns>
        private NodeImageType GetNodeImageFromDriveType(DriveType nDriveType)
        {
            switch (nDriveType)
            {
                case DriveType.CDRom:
                    return NodeImageType.CDRom;
                case DriveType.Fixed:
                    return NodeImageType.HDD;
                case DriveType.Removable:
                    return NodeImageType.Removable;
                case DriveType.Ram:
                    return NodeImageType.Ram;
                case DriveType.Network:
                    return NodeImageType.NetworkDrive;
                case DriveType.Unknown:
                    return NodeImageType.UnknownDrive;
                default:
                    return NodeImageType.UnknownDrive;
            }
        }

        /// <summary>
        /// Adds the specified drive as a tree node to the tree view control.
        /// </summary>
        /// <param name="oDrive">Specifies the DriveInfo object.</param>
        /// <param name="oNode">Specifies the parent tree node.</param>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        private void AddDriveNode(DriveInfo oDrive, TreeNode oNode)
        {
            if ((oDrive != null) && (oDrive.IsReady))
            {
                try
                {
                    string sDriveName = oDrive.Name;
                    string sDriveDisplayName = oDrive.VolumeLabel + " ("
                        + sDriveName.TrimEnd(new char[] { Path.DirectorySeparatorChar }) + ")";
                    string sUsed = "Free: " + IView.Engine.Core.FileTools.ConvertBytes(oDrive.TotalFreeSpace);
                    string sTotal = "Total: " + IView.Engine.Core.FileTools.ConvertBytes(oDrive.TotalSize);

                    int nImageIndex = (int)GetNodeImageFromDriveType(oDrive.DriveType);

                    TreeNode oDriveNode = new TreeNode();
                    oDriveNode.Name = sDriveName;
                    oDriveNode.Text = sDriveDisplayName;
                    oDriveNode.ToolTipText = sUsed + "\n" + sTotal;
                    oDriveNode.ImageIndex = nImageIndex;
                    oDriveNode.SelectedImageIndex = nImageIndex;

                    // Add the drive to the mapped drives array list.
                    m_oMappedDrives.Add(sDriveName);

                    // Add the node to the treeview control.
                    oNode.Nodes.Add(oDriveNode);
                }
                catch (UnauthorizedAccessException e)
                {
                    throw new UnauthorizedAccessException(e.Message, e);
                }
                catch (IOException e)
                {
                    throw new IOException(e.Message, e);
                }
                catch (System.Security.SecurityException e)
                {
                    throw new System.Security.SecurityException(e.Message, e);
                }
            }
        }

        /// <summary>
        /// Adds the base parent nodes to the explorer tree view.
        /// </summary>
        public void AddBaseNodes()
        {
            try
            {
                int nImageIndex = (int)NodeImageType.FolderClosed;
                string sPath = null;

                // Clear any previous nodes and reset member data.
                if (this.Nodes.Count > 0)
                {
                    this.Nodes.Clear();
                    m_oMappedDrives.Clear();
                    m_sCurrentPath = null;
                }

                // Create and add the favourites parent node.
                nImageIndex = (int)NodeImageType.Favourites;
                sPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                TreeNode oNode = new TreeNode("Favourites", nImageIndex, nImageIndex);
                this.Nodes.Add(oNode);

                // Add the computer root node.
                nImageIndex = (int)NodeImageType.Computer;                
                oNode = new TreeNode("Computer", nImageIndex, nImageIndex);

                // Desktop parent node.
                nImageIndex = (int)NodeImageType.Desktop;
                sPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                oNode.Nodes.Add(sPath, "Desktop", nImageIndex, nImageIndex);
                
                // My documents parent node.
                nImageIndex = (int)NodeImageType.MyDocuments;
                sPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                oNode.Nodes.Add(sPath, "Documents", nImageIndex, nImageIndex);

                // My pictures parent node.
                nImageIndex = (int)NodeImageType.Pictures;
                sPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                oNode.Nodes.Add(sPath, "Pictures", nImageIndex, nImageIndex);

                // Map drives.
                foreach (DriveInfo oDrive in DriveInfo.GetDrives())
                    AddDriveNode(oDrive, oNode);

                // Add the nodes to the treeview control.
                this.Nodes.Add(oNode);

                // Set the base nodes added flag to true.
                m_bBaseNodesAdded = true;
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show("Unable to add base nodes.\n\nReason: " + e.Message, "Error Mapping Devices",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show("Unable to add base nodes.\n\nReason: " + e.Message, "Error Mapping Devices",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException e)
            {
                MessageBox.Show("Unable to add base nodes.\n\nReason: " + e.Message, "Error Mapping Devices",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Refreshes the device list in the explorer tree view control.
        /// </summary>
        public void RefreshDeviceList()
        {
            // Clear any previous elements from the current drives list.
            m_oCurrentDrives.Clear();

            try
            {
                // Map the drives on the system and add any that do not exist in
                // the mapped drives array list.
                foreach (DriveInfo oDrive in DriveInfo.GetDrives())
                {
                    if (oDrive.IsReady)
                    {
                        string sDriveName = oDrive.Name;

                        if (!m_oMappedDrives.Contains(sDriveName))
                        {
                            // Add the node to the treeview control.
                            AddDriveNode(oDrive, this.Nodes[NODE_COMPUTER_INDEX]);
                        }

                        // Add the drive to the current drives array list.
                        m_oCurrentDrives.Add(sDriveName);
                    }
                }

                // Interate through the mapped drives array list. If the current drives array list
                // contains any of the mapped drive elements, if not remove them.
                for (int n = 0; n < m_oMappedDrives.Count; n++)
                {
                    string sDrive = (string)m_oMappedDrives[n];

                    if (!m_oCurrentDrives.Contains(sDrive))
                    {
                        // Remove the item from the mapped drives array list.
                        m_oMappedDrives.Remove(sDrive);

                        // Remove the node from the treeview control.
                        this.Nodes[NODE_COMPUTER_INDEX].Nodes.RemoveByKey(sDrive);
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show("Unable to refresh device list.\n\nReason: " + e.Message, "Error Mapping Devices",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show("Unable to refresh device list.\n\nReason: " + e.Message, "Error Mapping Devices",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException e)
            {
                MessageBox.Show("Unable to refresh device list.\n\nReason: " + e.Message, "Error Mapping Devices",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            bool bCallEvent = false;
            string sNodePath = e.Node.Name;

            // Return if the selected node is a root base node.
            if (e.Node.Level == 0)
            {
                base.OnAfterSelect(e);
                return;
            }

            // Return and remove the node if the node path is null or empty.
            if (string.IsNullOrEmpty(sNodePath))
            {
                e.Node.Remove();
                base.OnAfterSelect(e);
                return;
            }

            // If the node tag is not null return.
            if (e.Node.Tag != null)
            {
                base.OnAfterSelect(e);
                return;
            }

            try
            {
                DirectoryInfo oDirectory = new DirectoryInfo(sNodePath);

                if (!e.Node.IsExpanded)
                {
                    if (e.Node.Nodes.Count > 0)
                        e.Node.Nodes.Clear();

                    if (oDirectory.Exists)
                    {
                        foreach (DirectoryInfo oDir in oDirectory.GetDirectories())
                        {
                            bool bSystemFolder =
                                Convert.ToBoolean(oDir.Attributes & FileAttributes.System);
                            bool bHiddenFolder =
                                Convert.ToBoolean(oDir.Attributes & FileAttributes.Hidden);

                            // Add the node, if the folder isn't a system or hidden folder.
                            if ((!bSystemFolder) && (!bHiddenFolder))
                            {
                                e.Node.Nodes.Add(oDir.FullName, oDir.Name,
                                    (int)NodeImageType.FolderClosed, (int)NodeImageType.FolderOpened);
                            }
                        }

                        // Loop completed with no exceptions. Set the CallEvent flag to true.
                        bCallEvent = true;
                    }
                    else
                    {
                        // Only remove nodes that have a null tag property.
                        if (e.Node.Tag == null)
                        {
                            // If the mapped drives array list contains an element with the same name remove it.
                            if (m_oMappedDrives.Contains(sNodePath))
                                m_oMappedDrives.Remove(sNodePath);

                            // Remove the node.
                            e.Node.Remove();                            
                        }

                        // Directory not found. Set the CallEvent flag to false.
                        bCallEvent = false;
                    }
                }
                else
                {
                    if (!oDirectory.Exists)
                    {
                        // Only remove nodes that have a null tag property.
                        if (e.Node.Tag == null)
                        {
                            // If the mapped drives array list contains an element with the same name remove it.
                            if (m_oMappedDrives.Contains(sNodePath))
                                m_oMappedDrives.Remove(sNodePath);

                            // Remove the node.
                            e.Node.Remove();
                        }
                    }

                    // Node already expanded. Set the CallEvent flag to true.
                    bCallEvent = true;
                }
            }
            catch (System.Security.SecurityException ex)
            {
                string sCaption = "Map Directory Error";
                string sMessage = "Unable to map directory.\n\nReason: " + ex.Message;
                MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                string sCaption = "Map Directory Error";
                string sMessage = "Unable to map directory.\n\nReason: " + ex.Message;
                MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                string sCaption = "Map Directory Error";
                string sMessage = "Unable to map directory.\n\nReason: " + ex.Message;
                MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                string sCaption = "Map Directory Error";
                string sMessage = "Unable to map directory.\n\nReason: " + ex.Message;
                MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (bCallEvent)
                {
                    m_sCurrentPath = e.Node.Name;
                    base.OnAfterSelect(e);
                }
                else
                    m_sCurrentPath = null;
            }
        }

        /// <summary>
        /// Cleans up all resources used by this class.
        /// </summary>
        /// <param name="disposing">Specifies whether to dispose of managed resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_oImageList != null)
                {
                    m_oImageList.Dispose();
                    m_oImageList = null;
                }
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
