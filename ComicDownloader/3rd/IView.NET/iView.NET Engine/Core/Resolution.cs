//::///////////////////////////////////////////////////////////////////////////
//:: File Name: Resolution.cs
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
using System.ComponentModel;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Represents a resolution of an image as a structure.
    /// </summary>
    [TypeConverterAttribute(typeof(ResolutionTypeConverter))]
    public struct Resolution
    {
        #region Fields and properties

        private float m_fHorizontal;
        private float m_fVertical;

        /// <summary>
        /// Gets a Resolution structure with the fields initialized with empty values.
        /// </summary>
        public static readonly Resolution Empty;

        /// <summary>
        /// Gets or sets the Horizontal resolution property.
        /// </summary>
        [ReadOnly(true)]
        public float Horizontal
        {
            get { return m_fHorizontal; }
            set { m_fHorizontal = value; }
        }

        /// <summary>
        /// Gets or sets the Vertical resolution property.
        /// </summary>
        [ReadOnly(true)]
        public float Vertical
        {
            get { return m_fVertical; }
            set { m_fVertical = value; }
        }

        #endregion

        #region Costructors

        /// <summary>
        /// Creates a new instance of the Resolution structure initialized with the specified resolution values.
        /// </summary>
        /// <param name="fHorizontal">Specifies the horizontal resolution.</param>
        /// <param name="fVertical">Specifies the vertical resolution.</param>
        public Resolution(float fHorizontal, float fVertical)
        {
            m_fHorizontal = fHorizontal;
            m_fVertical = fVertical;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Gets a string representation of the current structure.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Horizontal=" + m_fHorizontal + ", Vertical=" + m_fVertical;
        }

        #endregion
    }
}
