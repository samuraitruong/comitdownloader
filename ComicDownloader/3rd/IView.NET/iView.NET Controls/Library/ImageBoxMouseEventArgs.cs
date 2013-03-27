//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageBoxMouseEventArgs.cs
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
using System.Drawing;
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// Provides properties and methods for creating image box mouse event data.
    /// Inherits from: ImageBoxEventArgs.
    /// </summary>
    public class ImageBoxMouseEventArgs : ImageBoxEventArgs
    {
        #region Fields & Properties

        private int m_nX;
        private int m_nY;
        private int m_nClicks;
        private int m_nDelta;
        private MouseButtons m_nMouseButton;

        /// <summary>
        /// Gets the X Coordinate of the mouse position within the current image box.
        /// </summary>
        public int X
        {
            get { return m_nX; }
        }

        /// <summary>
        /// Gets the Y Coordinate of the mouse position within the current image box.
        /// </summary>
        public int Y
        {
            get { return m_nY; }
        }

        /// <summary>
        /// Gets the number of times the mouse button was pressed and released.
        /// </summary>
        public int Clicks
        {
            get { return m_nClicks; }
        }

        /// <summary>
        /// Gets a signed count of the number of detents the mouse wheel was rotated.
        /// </summary>
        public int Delta
        {
            get { return m_nDelta; }
        }

        /// <summary>
        /// Get which mouse button was pressed in the image box.
        /// </summary>
        public MouseButtons MouseButton
        {
            get { return m_nMouseButton; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the image box mouse event class initialized with deault parameters.
        /// </summary>
        public ImageBoxMouseEventArgs()
        {
            m_nX = 0;
            m_nY = 0;
            m_nClicks = 0;
            m_nDelta = 0;
            m_nRectTop = 0;
            m_nRectLeft = 0;
            m_nRectRight = 0;
            m_nRectBottom = 0;
            m_nRectWidth = 0;
            m_nRectHeight = 0;
            m_ImageBoxRect = new Rectangle();
            m_nMouseButton = MouseButtons.None;
        }

        /// <summary>
        /// Creates a new instance of the image box mouse event class initialized with the specified parameters.
        /// </summary>
        /// <param name="e">This event should be passed from the underlying control.</param>
        /// <param name="ImageBoxRect">Specifies the image box rectangle to construct the data from.</param>
        public ImageBoxMouseEventArgs(MouseEventArgs e, Rectangle ImageBoxRect)
        {
            m_nX = e.X - ImageBoxRect.X;
            m_nY = e.Y - ImageBoxRect.Y;
            m_nClicks = e.Clicks;
            m_nDelta = e.Delta;
            m_nRectTop = ImageBoxRect.X;
            m_nRectLeft = ImageBoxRect.Y;
            m_nRectRight = ImageBoxRect.Right;
            m_nRectBottom = ImageBoxRect.Bottom;
            m_nRectWidth = ImageBoxRect.Width;
            m_nRectHeight = ImageBoxRect.Height;
            m_ImageBoxRect = ImageBoxRect;
            m_nMouseButton = e.Button;
        }

        #endregion
    }
}
