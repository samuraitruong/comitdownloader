//::///////////////////////////////////////////////////////////////////////////
//:: File Name: FileFormatException.cs
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
//:: Created On: 9 April 2011
//:: Copyright © 2011 Stephen Daily
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
    /// The exception that is throw when trying to read an unknown file format.
    /// </summary>
    [Serializable]
    public class FileFormatException : Exception
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of the FileFormatException class initialized with default values.
        /// </summary>
        public FileFormatException() { }

        /// <summary>
        /// Creates a new instance of the FileFormatException class initialized with the specified message parameter.
        /// </summary>
        /// <param name="message">Specifies a user friendly message of the exception.</param>
        public FileFormatException(string message)
            : base(message) { }

        /// <summary>
        /// Creates a new instance of the FileFormatException class initialized with the specified message and inner exception parameters.
        /// </summary>
        /// <param name="message">Specifies a user friendly message of the exception.</param>
        /// <param name="inner">Specifies the inner exception that caused this exception.</param>
        public FileFormatException(string message, Exception inner)
            : base(message, inner) { }

        #endregion
    }
}
