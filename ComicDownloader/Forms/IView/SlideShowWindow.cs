//::///////////////////////////////////////////////////////////////////////////
//:: File Name: SlideShowWindow.cs
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
//:: Created On: 6 April 2011
//:: Copyright © 2011 Stephen Daily
//::///////////////////////////////////////////////////////////////////////////
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides an image window for the slide show.
    /// </summary>
    public partial class SlideShowWindow : Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of the SlideShowWindow class initialized with the default values.
        /// </summary>
        public SlideShowWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        #endregion
    }
}
