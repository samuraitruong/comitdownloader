//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ColourPicker.cs
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
//:: Created On: 18 May 2011
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
    /// <summary>
    /// Provides a simple control allowing the user to select a colour.
    /// </summary>
    public partial class ColourPicker : UserControl
    {
        #region Fields and properties

        /// <summary>
        /// Fires when the selected colour has been changed.
        /// </summary>
        public event EventHandler<EventArgs> ColourChanged;

        /// <summary>
        /// Gets the currently selected colour.
        /// </summary>
        public Color SelectedColour
        {
            get { return sbtn_Colour.DisplayColour; }
            set
            {
                sbtn_Colour.DisplayColour = value;
                cbx_Colours.Text =
                    value.R + ", " +
                    value.G + ", " +
                    value.B;

                OnColourChanged(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ColourPicker class initialized with default values.
        /// </summary>
        public ColourPicker()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                foreach (string sColour in Enum.GetNames(typeof(KnownColor)))
                    cbx_Colours.Items.Add(sColour);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnColourChanged(object sender, EventArgs e)
        {
            if (ColourChanged != null)
                ColourChanged(sender, e);
        }

        #endregion

        #region Control events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbtn_Colour_Click(object sender, EventArgs e)
        {
            using (ColorDialog oDlg = new ColorDialog())
            {
                oDlg.AllowFullOpen = true;
                oDlg.Color = sbtn_Colour.DisplayColour;
                oDlg.FullOpen = true;

                if (oDlg.ShowDialog(this) == DialogResult.OK)
                {
                    sbtn_Colour.DisplayColour = oDlg.Color;
                    cbx_Colours.Text =
                        oDlg.Color.R + ", " +
                        oDlg.Color.G + ", " +
                        oDlg.Color.B;
                    
                    OnColourChanged(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_Colours_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            // Get the text of the item being drawn.
            string sItemText = cbx_Colours.Items[e.Index].ToString();

            // Create a new rectangle for the colour.
            Rectangle Rect =
                new Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, 12, e.Bounds.Height - 5);

            using (SolidBrush oBrush = new SolidBrush(Color.FromName(sItemText)))
            {
                // Fill a rectangle with the specified colour.
                e.Graphics.FillRectangle(oBrush, Rect);

                // Draw a border.
                oBrush.Color = Color.Gray;
                using (Pen oPen = new Pen(oBrush))
                    e.Graphics.DrawRectangle(oPen, Rect);

                // Draw the text.
                oBrush.Color = Color.Black;
                e.Graphics.DrawString(sItemText, this.Font, oBrush, e.Bounds.X + 16, e.Bounds.Y);
            }

            e.DrawFocusRectangle();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_Colours_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_Colours_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sText = cbx_Colours.Text;

            if ((cbx_Colours.Focused) && (!string.IsNullOrEmpty(sText)))
            {
                sbtn_Colour.DisplayColour = Color.FromName(sText);

                OnColourChanged(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
