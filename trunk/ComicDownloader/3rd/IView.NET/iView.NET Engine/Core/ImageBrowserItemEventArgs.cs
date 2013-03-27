//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageBrowserItemEventArgs.cs
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
//:: Copyright © 2010 Stephen Daily
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
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides item event data for the ImageBrowser class.
    /// </summary>
    public class ImageBrowserItemEventArgs : EventArgs
    {
        #region Fields and properties

        private int m_nCount;
        private int m_nIndex;
        private string m_sPath;

        /// <summary>
        /// Gets the total number of items currently in the list.
        /// </summary>
        public int Count
        {
            get { return m_nCount; }
        }

        /// <summary>
        /// Gets the zero based index value of the item in the list.
        /// </summary>
        public int Index
        {
            get { return m_nIndex; }
        }

        /// <summary>
        /// Gets the file path that is stored in association with the item.
        /// </summary>
        public string Path
        {
            get { return m_sPath; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ImageBrowserItemEventArgs class initialized with default values.
        /// </summary>
        public ImageBrowserItemEventArgs()
        {

        }

        /// <summary>
        /// Creates a new instance of the ImageBrowserItemEventArgs class initialized with the specified parameters.
        /// </summary>
        /// <param name="nCount">Specifies the total number of item in the list.</param>
        /// <param name="nIndex">Specifies the zero based index of the item.</param>
        /// <param name="sPath">Specifies the file path of the item.</param>
        public ImageBrowserItemEventArgs(int nCount, int nIndex, string sPath)
        {
            m_nCount = nCount;
            m_nIndex = nIndex;
            m_sPath = sPath;
        }

        #endregion
    }
}
