//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ShearPanel.cs
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
//:: Created On: 21 May 2011
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
using System.Drawing;
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    public partial class ShearPanel : UserControl
    {
        #region Fields and properties

        /// <summary>
        /// Gets a value indicating whether to resize the image when shearing.
        /// </summary>
        public bool ResizeImage
        {
            get { return ckb_ResizeImage.Checked; }
        }

        /// <summary>
        /// Gets a value indicating whether to use a transparent background when shearing.
        /// </summary>
        public bool TransparentBackground
        {
            get { return ckb_TransparentBackground.Checked; }
        }

        /// <summary>
        /// Gets the current HorizontalValue property.
        /// </summary>
        public int HorizontalValue
        {
            get { return slbl_Horizontal.Value; }
        }

        /// <summary>
        /// Gets the current VerticalValue property.
        /// </summary>
        public int VerticalValue
        {
            get { return slbl_Vertical.Value; }
        }

        /// <summary>
        /// Gets the current BackgroundColour property.
        /// </summary>
        public Color BackgroundColour
        {
            get { return cpic_BackgroundColour.SelectedColour; }
        }

        /// <summary>
        /// Fires when the Apply button has been clicked.
        /// </summary>
        public event EventHandler<EventArgs> ApplyButtonClicked;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ShearPanel class initialized with default values.
        /// </summary>
        public ShearPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Child controls events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slbl_Horizontal_ValueChanged(object sender, EventArgs e)
        {
            nud_Horizontal.Value = slbl_Horizontal.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void slbl_Vertical_ValueChanged(object sender, EventArgs e)
        {
            nud_Vertical.Value = slbl_Vertical.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Horizontal_ValueChanged(object sender, EventArgs e)
        {
            slbl_Horizontal.Value = (int)nud_Horizontal.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Vertical_ValueChanged(object sender, EventArgs e)
        {
            slbl_Vertical.Value = (int)nud_Vertical.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckb_TransparentBackground_CheckedChanged(object sender, EventArgs e)
        {
            cpic_BackgroundColour.Enabled = (!ckb_TransparentBackground.Checked);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (ApplyButtonClicked != null)
                ApplyButtonClicked(sender, e);
        }

        #endregion
    }
}
