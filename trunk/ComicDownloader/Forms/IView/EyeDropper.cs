//::///////////////////////////////////////////////////////////////////////////
//:: File Name: EyeDropper.cs
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
using System.Drawing.Drawing2D;
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides a window displaying pixel data.
    /// </summary>
    public partial class FormPixelColour : Form
    {
        #region Fields and properties

        private Color m_Colour;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the EyeDropper class initialized with the specified parameter.
        /// </summary>
        /// <param name="PixelColour">Specifies the colour to display in the window.</param>
        public FormPixelColour(Color PixelColour)
        {
            InitializeComponent();

            m_Colour = PixelColour;
        }

        #endregion

        #region Override

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            byte nA, nR, nG, nB;
            string sColour;
            Rectangle Rect = e.ClipRectangle;
            Rect.Width -= 1;
            Rect.Height -= 1;

            // Fill the background.
            using (LinearGradientBrush oBrush = new LinearGradientBrush(Rect, Color.White, Color.LightGray, LinearGradientMode.Vertical))
                e.Graphics.FillRectangle(oBrush, Rect);

            // Draw the border.
            e.Graphics.DrawRectangle(Pens.Gray, Rect);

            Rect = new Rectangle(3, 3, 20, this.Height - 7);

            // Fill the colour rectangle.
            using (SolidBrush oBrush = new SolidBrush(m_Colour))
                e.Graphics.FillRectangle(oBrush, Rect);

            // Draw the colour rectangle border.
            e.Graphics.DrawRectangle(Pens.Gray, Rect);

            nA = m_Colour.A;
            nR = m_Colour.R;
            nG = m_Colour.G;
            nB = m_Colour.B;

            using (SolidBrush oBrush = new SolidBrush(Color.Black))
            {
                // Draw the colour properties.
                sColour = "A: " + nA + ", R: " + nR + ", G: " + nG + ", B: " + nB;
                e.Graphics.DrawString(sColour, this.Font, oBrush, new Point(Rect.Width + 5, 3));

                // Draw the colour properties in hexadecimal format.
                sColour = "Hexadecimal: " + nR.ToString("x2") + nG.ToString("x2") + nB.ToString("x2");
                e.Graphics.DrawString(sColour, this.Font, oBrush, new Point(Rect.Width + 5, 18));
            }
        }

        #endregion
    }
}
