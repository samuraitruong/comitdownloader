//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageBrowserItem.cs
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
using System; using System.Net;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides an ImageBrowser item that can be added to the ImageBrowser item collection.
    /// The item represents an image file and holds a few peices of data that will be displayed
    /// in the ImageBrowser.
    /// </summary>
    public class ImageBrowserItem
    {
        #region Fields and properties

        private string m_sName;
        private string m_sPath;
        private string m_sType;
        private string m_sCreated;
        private string m_sSize;

        /// <summary>
        /// Gets or sets the name of the item. (The file name)
        /// </summary>
        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        /// <summary>
        /// Gets or sets the path of the item. (The path of the file)
        /// </summary>
        public string Path
        {
            get { return m_sPath; }
            set { m_sPath = value; }
        }

        /// <summary>
        /// Gets or sets the Type property. (The type of file)
        /// </summary>
        public string FileType
        {
            get { return m_sType; }
            set { m_sType = value; }
        }

        /// <summary>
        /// Gets or sets the Created property. (The file creation date)
        /// </summary>
        public string Created
        {
            get { return m_sCreated; }
            set { m_sCreated = value; }
        }

        /// <summary>
        /// Gets or sets the Length property. (The file size)
        /// </summary>
        public string Length
        {
            get { return m_sSize; }
            set { m_sSize = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ImageBrowserItem class initialized with default values.
        /// </summary>
        public ImageBrowserItem()
        {

        }

        #endregion
    }
}