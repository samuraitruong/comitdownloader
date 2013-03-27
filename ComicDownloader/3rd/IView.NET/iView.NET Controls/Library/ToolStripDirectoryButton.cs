//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ToolStripDirectoryButton.cs
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
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;
using ComicDownloader.Properties;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// Provides a toolstrip drop down button with directory listing features.
    /// </summary>
    public class ToolStripDirectoryButton : ToolStripDropDownButton
    {
        #region Fields and properties

        private string m_sDirectoryPath;
        private ToolStripItem m_oToolStripItem;
        private List<ToolStripItem> m_oItems;

        /// <summary>
        /// Gets the currently selected directory path.
        /// </summary>
        [Browsable(false)]
        public string DirectoryPath
        {
            get { return m_sDirectoryPath; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ToolStripDirectoryButton class initialized with default values.
        /// </summary>
        public ToolStripDirectoryButton()
        {
            m_oItems = new List<ToolStripItem>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns an image relevent to the specified DriveType enumeration.
        /// </summary>
        /// <param name="nDriveType">Specifies the DriveType enumeration.</param>
        /// <returns></returns>
        private Image GetImageFromDriveType(DriveType nDriveType)
        {
            switch (nDriveType)
            {
                case DriveType.CDRom:
                    return Resources.cd_rom_16x16;
                case DriveType.Fixed:
                    return Resources.hard_drive_16x16;
                case DriveType.Removable:
                    return Resources.removable_disk_16x16;
                case DriveType.Ram:
                    return Resources.ram_16x16;
                case DriveType.Network:
                    return Resources.network_drive_16x16;
                case DriveType.Unknown:
                    return Resources.unknown_drive_16x16;
                default:
                    return Resources.unknown_drive_16x16;
            }
        }

        /// <summary>
        /// Maps the device list on the current computer and creates the relevent ToolStripMenuItems
        /// adding them to this instance of the drop down button.
        /// </summary>
        private void CreateDeviceListItems()
        {
            try
            {
                foreach (DriveInfo oDrive in DriveInfo.GetDrives())
                {
                    if (oDrive.IsReady)
                    {
                        m_oToolStripItem = new ToolStripMenuItem();
                        m_oToolStripItem.Name = oDrive.Name;
                        m_oToolStripItem.Text = oDrive.VolumeLabel + " ("
                            + oDrive.Name.TrimEnd(new char[] { Path.DirectorySeparatorChar }) + ")";
                        m_oToolStripItem.Image = GetImageFromDriveType(oDrive.DriveType);

                        m_oItems.Add(m_oToolStripItem);
                    }
                }

                //
                this.DropDownItems.AddRange(m_oItems.ToArray());
                this.DropDown.Visible = true;
                this.Text = "Computer";
            }
            catch (IOException e)
            {
                string sCaption = "Map Devices Error";
                string sMessage = "Unable to map devices.\n\nReason: " + e.Message;
                MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException e)
            {
                string sCaption = "Map Devices Error";
                string sMessage = "Unable to map devices.\n\nReason: " + e.Message;
                MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Creates the items for the list.
        /// </summary>
        private void CreateItems()
        {
            // Return if the DropDownItems count is more than zero.
            if (this.DropDownItems.Count > 0)
                return;

            // Return and create the device list if the path provided is invalid.
            if (string.IsNullOrEmpty(m_sDirectoryPath))
            {
                CreateDeviceListItems();
                return;
            }

            try
            {
                DirectoryInfo oDirectory = new DirectoryInfo(m_sDirectoryPath);

                // Return and create the device list if the directory doesn't exist.
                if (!oDirectory.Exists)
                {
                    CreateDeviceListItems();
                    return;
                }

                // Create the directory items for the list.
                foreach (DirectoryInfo oFolder in oDirectory.GetDirectories())
                {
                    bool bHiddenFolder =
                        Convert.ToBoolean(oFolder.Attributes & FileAttributes.Hidden);
                    bool bSystemFolder =
                        Convert.ToBoolean(oFolder.Attributes & FileAttributes.System);

                    if ((!bHiddenFolder) && (!bSystemFolder))
                    {
                        // Create a folder item and add it to the list.
                        m_oToolStripItem = new ToolStripMenuItem();
                        m_oToolStripItem.Name = oFolder.FullName;
                        m_oToolStripItem.Text = oFolder.Name;
                        m_oToolStripItem.Image = Resources.folder_closed_16x16;
                        m_oItems.Add(m_oToolStripItem);
                    }
                }

                // If the current directory has a parent add the up folder item, otherwise
                // add the computer item to the list.
                if (oDirectory.Parent != null)
                {
                    // Create the up folder toolstrip menu item and insert it into the list.
                    m_oToolStripItem = new ToolStripMenuItem();
                    m_oToolStripItem.Name = oDirectory.Parent.FullName;
                    m_oToolStripItem.Text = oDirectory.Parent.Name;
                    m_oToolStripItem.Image = Resources.folder_up_16x16;
                    m_oItems.Insert(0, m_oToolStripItem);

                    // Create the computer toolstrip menu item and insert it into the list.
                    m_oToolStripItem = new ToolStripMenuItem();
                    m_oToolStripItem.Name = null;
                    m_oToolStripItem.Text = "Computer";
                    m_oToolStripItem.Image = Resources.computer_16x16;
                    m_oItems.Insert(0, m_oToolStripItem);

                    if (m_oItems.Count > 2)
                    {
                        // If more than one item exists in the list create and insert the separator.
                        m_oToolStripItem = new ToolStripSeparator();
                        m_oToolStripItem.Name = "tss_dbtn_01";
                        m_oItems.Insert(2, m_oToolStripItem);
                    }
                }
                else
                {
                    // Create the computer toolstrip menu item and insert it into the list.
                    m_oToolStripItem = new ToolStripMenuItem();
                    m_oToolStripItem.Name = null;
                    m_oToolStripItem.Text = "Computer";
                    m_oToolStripItem.Image = Resources.computer_16x16;
                    m_oItems.Insert(0, m_oToolStripItem);

                    if (m_oItems.Count > 1)
                    {
                        // If more than one item exists in the list create and insert the separator.
                        m_oToolStripItem = new ToolStripSeparator();
                        m_oToolStripItem.Name = "tss_dbtn_01";
                        m_oItems.Insert(1, m_oToolStripItem);
                    }
                }

                // Add the items to the dropdown items collection and show the dropdown.
                this.DropDownItems.AddRange(m_oItems.ToArray());
                this.DropDown.Visible = true;
            }
            catch (UnauthorizedAccessException e)
            {
                string sCaption = "Map Directory Error";
                string sMessage = "Unable to map directory. (" + m_sDirectoryPath + ")\n\nReason: " + e.Message;
                MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                string sCaption = "Map Directory Error";
                string sMessage = "Unable to map directory. (" + m_sDirectoryPath + ")\n\nReason: " + e.Message;
                MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException e)
            {
                string sCaption = "Map Directory Error";
                string sMessage = "Unable to map directory. (" + m_sDirectoryPath + ")\n\nReason: " + e.Message;
                MessageBox.Show(sMessage, sCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Removes the items from the list.
        /// </summary>
        private void RemoveItems()
        {
            this.DropDownItems.Clear();

            if (m_oItems != null)
            {
                for (int n = 0; n < m_oItems.Count; n++)
                {
                    if ((m_oItems[n] != null) && (!m_oItems[n].IsDisposed))
                    {
                        m_oItems[n].Dispose();
                        m_oItems[n] = null;
                    }
                }

                m_oItems.Clear();
                m_oItems.Capacity = 0;
            }
        }

        /// <summary>
        /// Sets the directory path string, passing a null or empty value will reset the control
        /// to the computer base path.
        /// </summary>
        /// <param name="sPath"></param>
        public void SetDirectory(string sPath)
        {
            bool bSet = false;

            if (!string.IsNullOrEmpty(sPath))
            {
                string[] sPathArray = sPath.Split(new char[] { Path.DirectorySeparatorChar });

                if (sPathArray.Length > 1)
                {
                    bSet = true;

                    // Update the directory path.
                    m_sDirectoryPath = sPath;

                    string sItemText = sPathArray[(sPathArray.Length >= 2) ? sPathArray.Length - 1 : 0];

                    if (string.IsNullOrEmpty(sItemText))
                        sItemText = sPathArray[0];

                    // Set the text and tooltip text.
                    this.Text = sItemText;
                    this.ToolTipText = sPath;
                }
            }

            if (!bSet)
            {
                // Null the directory path.
                m_sDirectoryPath = null;

                // Set the text and tooltip text to the default values.
                this.Text = "Computer";
                this.ToolTipText = "Computer";
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDropDownItemClicked(ToolStripItemClickedEventArgs e)
        {
            if ((e.ClickedItem != null) && (!(e.ClickedItem is ToolStripSeparator)))
            {
                if (string.IsNullOrEmpty(e.ClickedItem.Name))
                {
                    //
                    m_sDirectoryPath = null;

                    //
                    this.Text = "Computer";
                    this.ToolTipText = "Computer";
                }

                base.OnDropDownItemClicked(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClick(EventArgs e)
        {
            if (!DesignMode)
                CreateItems();

            base.OnClick(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDropDownClosed(EventArgs e)
        {
            if (!DesignMode)
                RemoveItems();

            base.OnDropDownClosed(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //
                RemoveItems();

                //
                m_oItems = null;
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}