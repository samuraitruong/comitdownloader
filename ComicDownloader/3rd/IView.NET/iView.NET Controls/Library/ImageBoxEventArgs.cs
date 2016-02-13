//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageBoxEventArgs.cs
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
using System.Drawing;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// Provides properties and methods for creating image box event data.
    /// This is the base class for all image box event data. All other event
    /// classes made for the image box should derive from this base class.
    /// </summary>
    public class ImageBoxEventArgs : EventArgs
    {
        #region Fields and properties

        protected int m_nRectTop;
        protected int m_nRectLeft;
        protected int m_nRectRight;
        protected int m_nRectBottom;
        protected int m_nRectWidth;
        protected int m_nRectHeight;
        protected Rectangle m_ImageBoxRect;

        /// <summary>
        /// Gets the the width of the image box.
        /// </summary>
        public int Width
        {
            get { return m_nRectWidth; }
        }

        /// <summary>
        /// Gets the height of the image box.
        /// </summary>
        public int Height
        {
            get { return m_nRectHeight; }
        }

        /// <summary>
        /// Gets the top position (X) of the image box.
        /// </summary>
        public int Top
        {
            get { return m_nRectTop; }
        }

        /// <summary>
        /// Gets the left position (Y) of the image box.
        /// </summary>
        public int Left
        {
            get { return m_nRectLeft; }
        }

        /// <summary>
        /// Gets the right position (Top + Width) of the image box.
        /// </summary>
        public int Right
        {
            get { return m_nRectRight; }
        }

        /// <summary>
        /// Gets the bottom position (Left + Height) of the image box.
        /// </summary>
        public int Bottom
        {
            get { return m_nRectBottom; }
        }

        /// <summary>
        /// Gets the image box rectangle.
        /// </summary>
        public Rectangle ImageBoxRectangle
        {
            get { return m_ImageBoxRect; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the image box event class initialized with default parameters.
        /// </summary>
        public ImageBoxEventArgs()
        {
            m_nRectTop = 0;
            m_nRectLeft = 0;
            m_nRectRight = 0;
            m_nRectBottom = 0;
            m_nRectWidth = 0;
            m_nRectHeight = 0;
            m_ImageBoxRect = new Rectangle();
        }

        /// <summary>
        /// Creates an instance of the image box event class initialized with the specified parameters.
        /// </summary>
        /// <param name="ImageBoxRect">Specifies the image box rectangle to construct the data from.</param>
        public ImageBoxEventArgs(Rectangle ImageBoxRect)
        {
            m_nRectTop = ImageBoxRect.X;
            m_nRectLeft = ImageBoxRect.Y;
            m_nRectRight = ImageBoxRect.Right;
            m_nRectBottom = ImageBoxRect.Bottom;
            m_nRectWidth = ImageBoxRect.Width;
            m_nRectHeight = ImageBoxRect.Height;
            m_ImageBoxRect = ImageBoxRect;
        }

        #endregion
    }
}
