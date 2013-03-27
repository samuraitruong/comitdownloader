//::///////////////////////////////////////////////////////////////////////////
//:: File Name: AquaButton.cs
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
using System.Drawing;
using System.Windows.Forms;
using ComicDownloader.Properties;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// 
    /// </summary>
    public class AquaButton : Button
    {
        #region Fields and properties

        private Image m_oButtonFocusImage;
        private Image m_oButtonPressedImage;

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public AquaButton()
        {
            m_oButtonFocusImage =
                new Bitmap(Resources.aqua_button_focus_24x241);
            m_oButtonPressedImage =
                new Bitmap(Resources.aqua_button_pressed_24x241);

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Center;
            this.SetStyle(ControlStyles.Selectable, false);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseEnter(EventArgs e)
        {
            if (this.Enabled)
                this.BackgroundImage = m_oButtonFocusImage;

            base.OnMouseEnter(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            if (this.Enabled)
                this.BackgroundImage = null;

            base.OnMouseLeave(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mevent"></param>
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (this.Enabled)
                this.BackgroundImage = m_oButtonPressedImage;

            base.OnMouseDown(mevent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mevent"></param>
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (this.Enabled)
                this.BackgroundImage = m_oButtonFocusImage;

            base.OnMouseUp(mevent);
        }

        /// <summary>
        /// Cleans up all recources used by this object.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_oButtonFocusImage != null)
                {
                    m_oButtonFocusImage.Dispose();
                    m_oButtonFocusImage = null;
                }

                if (m_oButtonPressedImage != null)
                {
                    m_oButtonPressedImage.Dispose();
                    m_oButtonPressedImage = null;
                }
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
