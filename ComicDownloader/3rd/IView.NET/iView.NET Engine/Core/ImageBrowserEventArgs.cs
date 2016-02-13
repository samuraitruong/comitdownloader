//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageBrowserEventArgs.cs
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
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides image browser event data for the ImageBrowser class.
    /// </summary>
    public class ImageBrowserEventArgs : EventArgs
    {
        #region Fields and properties

        private int m_nCount;

        /// <summary>
        /// Gets the total number of items currently in the list.
        /// </summary>
        public int Count
        {
            get { return m_nCount; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ImageBrowserEventArgs class initialized with default values.
        /// </summary>
        public ImageBrowserEventArgs()
        {

        }

        /// <summary>
        /// Creates a new instance of the ImageBrowserEventsArgs class initialized with the specified parameters.
        /// </summary>
        /// <param name="nCount">Specifies the current item count in the list.</param>
        public ImageBrowserEventArgs(int nCount)
        {
            m_nCount = nCount;
        }

        #endregion
    }
}
