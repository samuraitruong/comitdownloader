//::///////////////////////////////////////////////////////////////////////////
//:: File Name: AdjustTime.cs
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
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides the user with a way of adjusting the creation time of files.
    /// </summary>
    public partial class AdjustTime : Form
    {
        #region Fields and properties

        private string[] m_sFilePaths;
        DateTime m_NewCreationTime;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the AdjustTime class initialized with default values.
        /// </summary>
        public AdjustTime()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of the AdjustTime class initialized with the specified values.
        /// </summary>
        /// <param name="sFilePaths">Specifies an array of file paths.</param>
        public AdjustTime(string[] sFilePaths)
        {
            InitializeComponent();

            if ((sFilePaths != null) && (sFilePaths.Length > 0))
            {
                m_sFilePaths = sFilePaths;

                if (!string.IsNullOrEmpty(m_sFilePaths[0]))
                {
                    try
                    {
                        FileInfo oFile = new FileInfo(sFilePaths[0]);

                        if (oFile.Exists)
                            UpdateUI(oFile);
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        MessageBox.Show("Unable to load file.\n\nReason: " + e.Message, "Error Loading File",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show("Unable to load file.\n\nReason: " + e.Message, "Error Loading File",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the controls on the form.
        /// </summary>
        /// <param name="oFile">Specifies a FileInfo object.</param>
        private void UpdateUI(FileInfo oFile)
        {
            DateTime CreationTime = oFile.CreationTime;

            // Update the forms text property.
            this.Text = "Adjust Time - Files: " + m_sFilePaths.Length;

            // Update the hours, minutes and seconds controls.
            nud_Hours.Value = CreationTime.Hour;
            nud_Minutes.Value = CreationTime.Minute;
            nud_Seconds.Value = CreationTime.Second;

            // Update the date time picker control.
            dtp_Date.Value = CreationTime;

            // Update the current date label.
            lbl_CurrentDate.Text = "Current: "
                + CreationTime.ToLongTimeString() + " - " + CreationTime.ToLongDateString();

            // Enable the ok button.
            btn_Ok.Enabled = true;
        }

        #endregion

        #region Control events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (!bgw_ChangeTimeStampWorker.IsBusy)
            {
                // Create a new DateTime struct with the specified date time values set by the UI controls.
                m_NewCreationTime = new DateTime(dtp_Date.Value.Year, dtp_Date.Value.Month, dtp_Date.Value.Day,
                    (int)nud_Hours.Value, (int)nud_Minutes.Value, (int)nud_Seconds.Value);

                // Disable the ok button and update the text.
                btn_Ok.Enabled = false;
                btn_Ok.Text = "Updating...";

                // Run the the background worker.
                bgw_ChangeTimeStampWorker.RunWorkerAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_ChangeTimeStampWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            //
            if (m_sFilePaths == null)
                return;

            //
            if (m_sFilePaths.Length <= 0)
                return;

            //
            foreach (string sPath in m_sFilePaths)
            {
                try
                {
                    if (!string.IsNullOrEmpty(sPath))
                    {
                        FileInfo oFile = new FileInfo(sPath);

                        if (oFile.Exists)
                            oFile.CreationTime = m_NewCreationTime;
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Unable to adjust the time for this file.\n\nReason: " + ex.Message, "Error Adjusting Time",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Unable to adjust the time for this file.\n\nReason: " + ex.Message, "Error Adjusting Time",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_ChangeTimeStampWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
