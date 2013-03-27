//::///////////////////////////////////////////////////////////////////////////
//:: File Name: RenameFile.cs
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
using System.IO;
using System.Windows.Forms;
using IView.Engine.Core;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides a way of allowing the user to rename a file.
    /// </summary>
    public partial class RenameFile : Form
    {
        #region Fields and properties

        private const int MAX_NAME_LENGTH = 100;

        private const string ERR_MSG_FILE_ALREADY_EXISTS = "A file with the same name already exists.";
        private const string ERR_MSG_NAME_TO_LONG = "A file name should not contain more than 100 characters.";
        private const string ERR_MSG_NAME_NULL = "A file name should not be null, empty or just white space.";
        private const string ERR_MSG_INVALID_CHAR = "A file name should not contain any of the following characters: \\ / : * ? \" < > |";

        private string m_sCurrentFilePath;
        private ImageBrowser m_oImageBrowser;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the RenameFile class initialized with the specified parameters.
        /// </summary>
        /// <param name="oImageBrowser">Specifies an ImageBrowser object to be passed in.</param>
        public RenameFile(ImageBrowser oImageBrowser)
        {
            InitializeComponent();

            if (oImageBrowser != null)
            {
                m_oImageBrowser = oImageBrowser;

                string sName = "Untitled";
                string sPath = m_oImageBrowser.SelectedFile;

                if (!string.IsNullOrEmpty(sPath))
                    sName = Path.GetFileNameWithoutExtension(sPath);

                // Initialize data.
                m_sCurrentFilePath = sPath;
                txtb_FileName.Text = sName;
                txtb_FileName.MaxLength = MAX_NAME_LENGTH;

                this.Text = "Rename - " + sName;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtb_FileName_TextChanged(object sender, EventArgs e)
        {
            string sError = string.Empty;
            string sName = txtb_FileName.Text;

            if (!string.IsNullOrEmpty(sName))
            {
                if (sName.Length < MAX_NAME_LENGTH)
                {
                    if (sName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                        sError = ERR_MSG_INVALID_CHAR;
                }
                else
                    sError = ERR_MSG_NAME_TO_LONG;
            }
            else
                sError = ERR_MSG_NAME_NULL;

            // Show the error if requested.
            if (!string.IsNullOrEmpty(sError))
            {
                tt_Error.SetToolTip(pan_Error, sError);
                pan_Error.Visible = true;
                btn_Ok.Enabled = false;
            }
            else
            {
                pan_Error.Visible = false;
                btn_Ok.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_sCurrentFilePath))
                return;

            string sNewName = txtb_FileName.Text;
            string sNewPath = Path.GetDirectoryName(m_sCurrentFilePath)
                + Path.DirectorySeparatorChar + sNewName + Path.GetExtension(m_sCurrentFilePath);

            if (!File.Exists(sNewPath))
            {
                try
                {
                    // Try and rename the file.
                    m_oImageBrowser.RenameFile(sNewName);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Unable to rename file: " + m_sCurrentFilePath + " to "
                        + sNewPath + "\n\nReason: " + ex.Message, "Rename File Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Unable to rename file: " + m_sCurrentFilePath + " to "
                        + sNewPath + "\n\nReason: " + ex.Message, "Rename File Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Security.SecurityException ex)
                {
                    MessageBox.Show("Unable to rename file: " + m_sCurrentFilePath + " to "
                        + sNewPath + "\n\nReason: " + ex.Message, "Rename File Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                tt_Error.SetToolTip(pan_Error, ERR_MSG_FILE_ALREADY_EXISTS);
                pan_Error.Visible = true;
                btn_Ok.Enabled = false;
            }
        }

        #endregion
    }
}
