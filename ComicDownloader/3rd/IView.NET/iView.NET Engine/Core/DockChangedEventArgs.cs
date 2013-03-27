//::///////////////////////////////////////////////////////////////////////////
//:: File Name: DockChangedEventArgs.cs
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
#define DEBUG_DATA
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
    /// Provides data about the docking changed event.
    /// </summary>
    public class DockChangedEventArgs : EventArgs
    {
        #region Fields and properties

        private bool m_bParentClosed;

        /// <summary>
        /// Gets a value indicating whether the dock changed event was called
        /// by the user clicking the windows close button.
        /// </summary>
        public bool DockingWindowClosed
        {
            get { return m_bParentClosed; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the DockChangedEventArgs class initialized with default values.
        /// </summary>
        public DockChangedEventArgs()
        {

        }

        /// <summary>
        /// Creates a new instance of the DockChangedEventArgs class initialized with the specified parameters.
        /// </summary>
        /// <param name="bParentClosed">Specifies whether the dock changed event was called by the user clicking the dockable windows close button.</param>
        public DockChangedEventArgs(bool bParentClosed)
        {
            m_bParentClosed = bParentClosed;
        }

        #endregion
    }
}
