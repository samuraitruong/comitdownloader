//::///////////////////////////////////////////////////////////////////////////
//:: File Name: SplitButton.cs
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using IView.Engine.Core;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// 
    /// </summary>
    public class SplitButton : Button
    {
        #region Fields and properties

        private const int RECT_X = 4;
        private const int RECT_Y = 4;
        private const int RECT_WIDTH_OFFSET = 9;
        private const int RECT_HEIGHT_OFFSET = 9;
        //private const int RECT_BACKGROUND_X = 5;
        //private const int RECT_BACKGROUND_Y = 5;
        //private const int RECT_BACKGROUND_WIDTH_OFFSET = 10;
        //private const int RECT_BACKGROUND_HEIGHT_OFFSET = 10;
        private const int SPLIT_BUTTON_DEFAULT_WIDTH = 17;

        private bool m_bSplitButtonEnabled = false;
        private bool m_bShowDisplayColour = false;
        private int m_nSplitButtonWidth = SPLIT_BUTTON_DEFAULT_WIDTH;
        private Color m_DisplayColour = Color.FromKnownColor(KnownColor.Control);
        private Color m_BorderColour = Color.Black;

        /// <summary>
        /// Gets or sets a value indicating whether to show the split button. A small area
        /// for displaying an arrow or small image donating a dropdown extension.
        /// </summary>
        [Category("Split Button Properties")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether to show the split button. A small area" 
            + " for displaying an arrow or small image donating a dropdown extension.")]
        public bool EnableSplitButton
        {
            get { return m_bSplitButtonEnabled; }
            set
            {
                m_bSplitButtonEnabled = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show the buttons display colour.
        /// </summary>
        [Category("Split Button Properties")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether to show the buttons display colour.")]
        public bool ShowDisplayColour
        {
            get { return m_bShowDisplayColour; }
            set
            {
                m_bShowDisplayColour = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the width of the split button.
        /// </summary>
        [Category("Split Button Properties")]
        [DefaultValue(SPLIT_BUTTON_DEFAULT_WIDTH)]
        [Description("Gets or sets the width of the split button.")]
        public int SplitButtonWidth
        {
            get { return m_nSplitButtonWidth; }
            set
            {
                if (value < this.Width)
                    m_nSplitButtonWidth = value;

                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the display colour for the button.
        /// </summary>
        [Category("Split Button Properties")]
        [DefaultValue(typeof(KnownColor), "Control")]
        [Description("Gets or sets the display colour for the button.")]
        public Color DisplayColour
        {
            get { return m_DisplayColour; }
            set
            {
                m_DisplayColour = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the border colour for the displayed background colour.
        /// </summary>
        [Category("Split Button Properties")]
        [DefaultValue(typeof(KnownColor), "Black")]
        [Description("Gets or sets the border colour for the displayed background colour.")]
        public Color BorderColour
        {
            get { return m_BorderColour; }
            set
            {
                m_BorderColour = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Fires when the split button was clicked and released by the mouse.
        /// </summary>
        [Category("Split Button Events")]
        [DefaultValue("")]
        [Description("Fires when the split button was clicked and released by the mouse.")]
        public event MouseEventHandler SplitButtonMouseUp;

        #endregion

        #region Constructors

        /// <summary>
        /// Default ctor.
        /// </summary>
        public SplitButton()
        {

        }

        #endregion

        #region Virtual methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnSplitButtonMouseUp(object sender, MouseEventArgs e)
        {
            if (SplitButtonMouseUp != null)
                SplitButtonMouseUp(sender, e);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle Rect = Rectangle.Empty;
            Rect.X = RECT_X;
            Rect.Y = RECT_Y;

            using (SolidBrush oBrush = new SolidBrush(m_BorderColour))
            {
                using (Pen oPen = new Pen(oBrush, 1.0f))
                {
                    if (m_bShowDisplayColour)
                    {
                        if (!m_bSplitButtonEnabled)
                        {
                            Rect.Width = this.Width - RECT_WIDTH_OFFSET;
                            Rect.Height = this.Height - RECT_HEIGHT_OFFSET;

                            oBrush.Color = m_DisplayColour;
                            e.Graphics.FillRectangle(oBrush, Rect);

                            oBrush.Color = m_BorderColour;
                            e.Graphics.DrawRectangle(oPen, Rect);
                        }
                        else
                        {
                            Rect.Width = this.Width - (m_nSplitButtonWidth + 7);
                            Rect.Height = this.Height - 9;

                            oBrush.Color = m_DisplayColour;
                            e.Graphics.FillRectangle(oBrush, Rect);

                            oBrush.Color = m_BorderColour;
                            e.Graphics.DrawRectangle(oPen, Rect);
                        }
                    }
                }
            }

            // Draw the splitter bar if enabled.
            if (m_bSplitButtonEnabled)
            {
                Rect.X = this.Width - m_nSplitButtonWidth;
                Rect.Y = 2;
                Rect.Width = 1;
                Rect.Height = this.Height - 4;

                using (LinearGradientBrush oGradientBrush = new LinearGradientBrush(Rect,
                    Color.Transparent, Color.Gray, LinearGradientMode.Vertical))
                {
                    e.Graphics.FillRectangle(oGradientBrush, Rect);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            bool bSideButtonClicked = false;

            if (m_bSplitButtonEnabled)
            {
                int nX = e.X;
                int nY = e.Y;
                Rectangle Rect = Rectangle.Empty;

                Rect.X = this.Width - m_nSplitButtonWidth;
                Rect.Y = 1;
                Rect.Width = m_nSplitButtonWidth;
                Rect.Height = this.Height - 1;

                if (ScaleHitTestTools.IsPositionInRectangleBounds(Rect, nX, nY, 0))
                {
                    bSideButtonClicked = true;
                    this.OnSplitButtonMouseUp(this, e);
                }
            }

            // If the split button is enabled and was clicked. Suppress the the main OnMouseUp event.
            if (!bSideButtonClicked)
                base.OnMouseUp(e);
            else
                this.ResetFlagsandPaint();
        }

        #endregion
    }
}
