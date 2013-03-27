//::///////////////////////////////////////////////////////////////////////////
//:: File Name: RecentPlace.cs
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
    /// 
    /// </summary>
    public class RecentPlace
    {
        #region Fields and properties

        private string m_sDisplayName;
        private string m_sLocation;

        /// <summary>
        /// Gets or sets the display name of the recent place.
        /// </summary>
        public string DisplayName
        {
            get { return m_sDisplayName; }
            set { m_sDisplayName = value; }
        }

        /// <summary>
        /// Gets or sets the path of recent place.
        /// </summary>
        public string Location
        {
            get { return m_sLocation; }
            set { m_sLocation = value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public RecentPlace()
        {
            m_sDisplayName = string.Empty;
            m_sLocation = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sDisplayName"></param>
        /// <param name="sLocation"></param>
        public RecentPlace(string sDisplayName, string sLocation)
        {
            m_sDisplayName = sDisplayName;
            m_sLocation = sLocation;
        }

        #endregion
    }
}
