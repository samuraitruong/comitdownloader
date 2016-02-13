//::///////////////////////////////////////////////////////////////////////////
//:: File Name: RedEyePanel.cs
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
using System; using System.Net;
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// Provides a way of allowing the user to adjust the properties of the red eye correction tool.
    /// </summary>
    public partial class RedEyePanel : UserControl
    {
        #region Properties

        /// <summary>
        /// Gets or sets the size of the area used for red eye processing.
        /// </summary>
        public int PupilSize
        {
            get { return tbar_PupilSize.Value; }
            set
            {
                if ((value >= tbar_PupilSize.Minimum) && (value <= tbar_PupilSize.Maximum))
                    tbar_PupilSize.Value = value;
            }
        }

        /// <summary>
        /// Gets or sets the minimum pupil size.
        /// </summary>
        public int PupilSizeMinimum
        {
            get { return tbar_PupilSize.Minimum; }
            set
            {
                if (value <= tbar_PupilSize.Maximum)
                    tbar_PupilSize.Minimum = value;
            }
        }

        /// <summary>
        /// Gets or sets the maximum pupil size.
        /// </summary>
        public int PupilSizeMaximium
        {
            get { return tbar_PupilSize.Maximum; }
            set
            {
                if (value >= tbar_PupilSize.Minimum)
                    tbar_PupilSize.Maximum = value;
            }
        }

        /// <summary>
        /// Fires when the activate button is clicked.
        /// </summary>
        public event EventHandler<EventArgs> ActivateClick;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the RedEyePanel class initialized with default values.
        /// </summary>
        public RedEyePanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Control events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Activate_Click(object sender, EventArgs e)
        {
            if (ActivateClick != null)
                ActivateClick(this, EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_PupilSize_ValueChanged(object sender, EventArgs e)
        {
            float fPercent = 100 / ((float)tbar_PupilSize.Maximum / (float)tbar_PupilSize.Value);

            txtb_PupilSize.Text = (int)fPercent + "%";
        }

        #endregion
    }
}
