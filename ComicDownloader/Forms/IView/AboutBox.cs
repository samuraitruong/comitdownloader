//::///////////////////////////////////////////////////////////////////////////
//:: File Name: AboutBox.cs
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
using System.Windows.Forms;
using IView.UI.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides a simple about box dialog.
    /// </summary>
    public partial class AboutBox : Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of the AboutBox class.
        /// </summary>
        public AboutBox()
        {
            InitializeComponent();

            // Update form.
            this.DialogResult = DialogResult.None;
            this.Text = ApplicationData.ApplicationName;

            // Update controls.
            lbl_Version.Text = "Version: " + ApplicationData.EntryAssemblyVersionShort;
        }

        #endregion

        #region Controls events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ViewLicence_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_Email_Click(object sender, EventArgs e)
        {
            try
            {
                using (System.Diagnostics.Process oProcess = new System.Diagnostics.Process())
                {
                    oProcess.StartInfo.UseShellExecute = true;
                    oProcess.StartInfo.FileName = ApplicationData.MailtoAuthor;
                    oProcess.Start();
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
    }
}
