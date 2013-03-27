//::///////////////////////////////////////////////////////////////////////////
//:: File Name: Favourite.cs
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
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides a simple container to hold the properties of a favourited item.
    /// </summary>
    public class Favourite
    {
        #region Fields and properties

        private string m_sName;
        private string m_sCreated;
        private string m_sPath;

        /// <summary>
        /// Gets or sets the name of the favourite item.
        /// </summary>
        public string Name
        {
            get { return m_sName; }
            set { m_sName = value; }
        }

        /// <summary>
        /// Gets or sets the creation date of the favourite item.
        /// </summary>
        public string Created
        {
            get { return m_sCreated; }
            set { m_sCreated = value; }
        }

        /// <summary>
        /// Gets or sets the path of the favourite item.
        /// </summary>
        public string Path
        {
            get { return m_sPath; }
            set { m_sPath = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the Favourite class initialized with default values.
        /// </summary>
        public Favourite()
        {

        }

        /// <summary>
        /// Creates a new instance of the Favourite class initialized with the specified name and path parameters.
        /// </summary>
        /// <param name="sName">Specifies the name of the favourited item.</param>
        /// <param name="sCreated">Specifies the creation date of the favourite item.</param>
        /// <param name="sPath">Specified the path of the favourited item.</param>
        public Favourite(string sName, string sCreated, string sPath)
        {
            m_sName = sName;
            m_sCreated = sCreated;
            m_sPath = sPath;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Returns a string representaion of the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return m_sName + "|" + m_sCreated + "|" + m_sPath;
        }

        #endregion
    }
}
