//::///////////////////////////////////////////////////////////////////////////
//:: File Name: SSFDescriptor.cs
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
//:: Created On: 17 April 2011
//:: Copyright © 2011 Stephen Daily
//::///////////////////////////////////////////////////////////////////////////
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Represents an iView.NET slide show file descriptor.
    /// </summary>
    public struct SSFDescriptor
    {
        #region Fields and properties

        private byte m_fVersion;
        private int m_nEntryCount;
        private int m_nWaitInterval;
        private TransitionMode m_nTransitionMode;
        private float m_fFadeSpeed;
        private string m_sDate;

        /// <summary>
        /// Represents an iView.NET slide show file descriptor with it's values set to default.
        /// </summary>
        public static readonly SSFDescriptor Empty;

        /// <summary>
        /// Gets or sets the Version property.
        /// </summary>
        public byte Version
        {
            get { return m_fVersion; }
            set { m_fVersion = value; }
        }

        /// <summary>
        /// Gets or sets the EntryCount property.
        /// </summary>
        public int EntryCount
        {
            get { return m_nEntryCount; }
            set { m_nEntryCount = value; }
        }

        /// <summary>
        /// Gets or sets the TransitionMode property.
        /// </summary>
        public TransitionMode TransitionMode
        {
            get { return m_nTransitionMode; }
            set { m_nTransitionMode = value; }
        }

        /// <summary>
        /// Gets or sets the WaitInterval property.
        /// </summary>
        public int WaitInterval
        {
            get { return m_nWaitInterval; }
            set { m_nWaitInterval = value; }
        }

        /// <summary>
        /// Gets or sets the FadeSpeed property.
        /// </summary>
        public float FadeSpeed
        {
            get { return m_fFadeSpeed; }
            set { m_fFadeSpeed = value; }
        }

        /// <summary>
        /// Gets or sets the Date property.
        /// </summary>
        public string Date
        {
            get { return m_sDate; }
            set { m_sDate = value; }
        }

        #endregion
    }
}
