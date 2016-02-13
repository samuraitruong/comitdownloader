//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageBrowserRenameEventArgs.cs
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
    /// Provides rename event data for the ImageBrowser class.
    /// </summary>
    public class ImageBrowserRenameEventArgs : EventArgs
    {
        #region Fields and properties

        private int m_nIndex;
        private string m_sOldPath;
        private string m_sNewPath;

        /// <summary>
        /// Gets the index of the item that was renamed.
        /// </summary>
        public int Index
        {
            get { return m_nIndex; }
        }

        /// <summary>
        /// Gets the old name of the item and file that was renamed.
        /// </summary>
        public string OldPath
        {
            get { return m_sOldPath; }
        }

        /// <summary>
        /// Gets the new path of the item and file that was renamed.
        /// </summary>
        public string NewPath
        {
            get { return m_sNewPath; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ImageBrowserRenameEventArgs class initialized with default values.
        /// </summary>
        public ImageBrowserRenameEventArgs()
        {

        }

        /// <summary>
        /// Creates a new instance of the ImageBrowserRenameEventArgs class initialized with the specified parameters.
        /// </summary>
        /// <param name="nIndex">Index of the item in the list.</param>
        /// <param name="sOldPath">The old path of the item or file.</param>
        /// <param name="sNewPath">The new path of the item or file.</param>
        public ImageBrowserRenameEventArgs(int nIndex, string sOldPath, string sNewPath)
        {
            m_nIndex = nIndex;
            m_sOldPath = sOldPath;
            m_sNewPath = sNewPath;
        }

        #endregion
    }
}
