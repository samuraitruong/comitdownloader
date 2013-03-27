//::///////////////////////////////////////////////////////////////////////////
//:: File Name: UpdateLocations.cs
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
    /// Displays a list of valid download locations for iView.NET.
    /// </summary>
    public partial class UpdateLocations : Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of the UpdateLocations class initialized with default values.
        /// </summary>
        public UpdateLocations()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates a new instance of the UpdateLocations class initialized with the specified parameters.
        /// </summary>
        /// <param name="sLocations"></param>
        public UpdateLocations(string[] sLocations)
        {
            InitializeComponent();

            this.Text = ApplicationData.ApplicationName + " - Download Locations";

            if (sLocations == null)
                return;

            for (int n = 0; n < sLocations.Length; n++)
            {
                if (!string.IsNullOrEmpty(sLocations[n]))
                {
                    string[] sValues = sLocations[n].Split(new char[] { '|' });

                    if (sValues.Length == 2)
                    {
                        lvw_Locations.Items.Add(sValues[0]);
                        lvw_Locations.Items[n].SubItems.Add(sValues[1]);
                    }
                }
            }
        }

        #endregion

        #region Control events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvw_Locations_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_Ok.Enabled = (lvw_Locations.SelectedItems.Count > 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvw_Locations_DoubleClick(object sender, EventArgs e)
        {
            btn_Ok.PerformClick();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if ((lvw_Locations.SelectedItems.Count == 1) && (lvw_Locations.SelectedItems[0].SubItems.Count == 2))
            {
                string sLocation = lvw_Locations.SelectedItems[0].SubItems[1].Text;

                if (!string.IsNullOrEmpty(sLocation))
                {
                    try
                    {
                        using (System.Diagnostics.Process oProcess = new System.Diagnostics.Process())
                        {
                            oProcess.StartInfo.UseShellExecute = true;
                            oProcess.StartInfo.FileName = sLocation;
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

        #endregion
    }
}
