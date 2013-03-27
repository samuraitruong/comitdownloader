//::///////////////////////////////////////////////////////////////////////////
//:: File Name: UpdateChecFinishedEventArgs.cs
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
using System;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides data for the IView.Engine.UpdateChecker.UpdateCheckFinished event handler.
    /// </summary>
    public class UpdateCheckFinishedEventArgs : EventArgs
    {
        #region Fields and properties

        private Version m_oVersion;
        private string[] m_sLocations;

        /// <summary>
        /// Gets the current version. This is read from the xml version check file.
        /// </summary>
        public Version CurrentVersion
        {
            get { return m_oVersion; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the UpdateCheckFinishedEventArgs class initialized with default values.
        /// </summary>
        public UpdateCheckFinishedEventArgs() : base() { }

        /// <summary>
        /// Creates a new instance of the UpdateCheckFinishedEventArgs class initialized with the specified parameters.
        /// </summary>
        /// <param name="oVersion"></param>
        public UpdateCheckFinishedEventArgs(Version oVersion, string[] sLocations)
        {
            m_oVersion = oVersion;
            m_sLocations = sLocations;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns an array of possible iView.NET download locations stored in the version check file.
        /// </summary>
        /// <returns></returns>
        public string[] GetLocations()
        {
            return m_sLocations;
        }

        #endregion
    }
}
