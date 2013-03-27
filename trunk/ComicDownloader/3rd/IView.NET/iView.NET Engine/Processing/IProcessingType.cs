//::///////////////////////////////////////////////////////////////////////////
//:: File Name: IProcessingType.cs
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
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Processing
{
    /// <summary>
    /// Defines an image processing type interface.
    /// </summary>
    public interface IProcessingType
    {
        /// <summary>
        /// Gets the type of structure being stored.
        /// </summary>
        ProcessingStructType StructType { get; }
    }
}
