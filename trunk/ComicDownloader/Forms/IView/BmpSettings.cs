//::///////////////////////////////////////////////////////////////////////////
//:: File Name: BmpSettings.cs
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
//:: Created On: 4 April 2011
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
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides the user with a dialog form allowing them to adjust the Windows Bitmap save settings.
    /// </summary>
    public partial class BmpSettings : Form
    {
        #region Fields and properties

        private static BitDepth m_nBitDepth = BitDepth.BPP32;

        /// <summary>
        /// Gets the currently selected BitDepth property.
        /// </summary>
        public BitDepth SelectedBitDepth
        {
            get { return m_nBitDepth; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the BmpSettings class initialized with default values.
        /// </summary>
        public BmpSettings()
        {
            InitializeComponent();

            switch (m_nBitDepth)
            {
                case BitDepth.BPP32:
                    rbtn_32Bit.Checked = true;
                    break;
                case BitDepth.BPP24:
                    rbtn_24Bit.Checked = true;
                    break;
            }
        }

        #endregion

        #region Form control events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (rbtn_32Bit.Checked)
                m_nBitDepth = BitDepth.BPP32;
            else if (rbtn_24Bit.Checked)
                m_nBitDepth = BitDepth.BPP24;

            this.Close();
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
