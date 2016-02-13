//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ExtensionMethods.cs
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
//#define DEBUG_DATA
//#define DEVELOPER_VERSION
#define DEBUG_DATA
#define DEVELOPER_VERSION
#define END_USER_VERSION
//::///////////////////////////////////////////////////////////////////////////
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Extension methods.
    /// </summary>
    public static class ExtensionMethods
    {
        #region Integer array extension methods

        /// <summary>
        /// Reuturns the mean value of a single dimension integer array.
        /// </summary>
        /// <param name="nArray">Specifies the integer array to parse.</param>
        /// <returns></returns>
        public static float Mean(this int[] nArray)
        {
            float fMean = 0.0f;
            
            if (nArray != null)
            {
                for (int n = 0; n < nArray.Length; n++)
                    fMean += nArray[n];

                fMean /= nArray.Length;
            }

            return fMean;
        }

        #endregion
    }
}
