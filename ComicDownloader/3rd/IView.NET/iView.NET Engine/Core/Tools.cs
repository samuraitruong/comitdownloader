//::///////////////////////////////////////////////////////////////////////////
//:: File Name: Tools.cs
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
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing;
using IView.Engine.Data;
using System.IO;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides some generic tools for iView.NET.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Creates a cursor from the specified byte array. This resource must contain cursor data.
        /// </summary>
        /// <param name="nResource">Specifies an array of bytes containing cursor (.cur) data.</param>
        /// <returns></returns>
        public static Cursor CreateCursor(byte[] nResource)
        {
            Cursor oCursor = Cursors.Default;

            if ((nResource != null) && (nResource.Length > 2))
            {
                try
                {
                    if (nResource[2] == 2)
                    {
                        using (System.IO.MemoryStream oStream = new System.IO.MemoryStream(nResource))
                            oCursor = new Cursor(oStream);
                    }
                    else
                    {
                        MessageBox.Show("Unable to create cursor from resource. The data could be damaged or corrupted.");
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Unable to create cursor from resource. The data could be damaged or corrupted.");
                }
            }

            return oCursor;
        }
    }
}
