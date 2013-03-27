//::///////////////////////////////////////////////////////////////////////////
//:: File Name: Enumerations.cs
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
using System.Drawing.Drawing2D;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Data
{
    /// <summary>
    /// Specifies a colour channel or channels
    /// </summary>
    public enum Channels
    {
        /// <summary>
        /// Specifies all colour channels. Red green and blue.
        /// </summary>
        RGB = 0,

        /// <summary>
        /// Specifies the red channel.
        /// </summary>
        Red,

        /// <summary>
        /// Specifies the green channel.
        /// </summary>
        Green,

        /// <summary>
        /// Specifies the blue channel.
        /// </summary>
        Blue
    }

    /// <summary>
    /// Specifies the bounds of the image box.
    /// </summary>
    public enum ImageBoxBounds
    {
        /// <summary>
        /// Specifies the none bounds image box bounds enumeration.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies the top bounds image box bounds enumeration.
        /// </summary>
        Top,

        /// <summary>
        /// Specifies the bottom bounds image box bounds enumeration.
        /// </summary>
        Bottom,

        /// <summary>
        /// Specifies the left bounds image box bounds enumeration
        /// </summary>
        Left,

        /// <summary>
        /// Specifies the right bounds image box bounds enumeration.
        /// </summary>
        Right,

        /// <summary>
        /// Specifies the top left bounds image box bounds enumeration.
        /// </summary>
        TopLeft,

        /// <summary>
        /// Specifies the top right image box bounds enumeration.
        /// </summary>
        TopRight,

        /// <summary>
        /// Specifies the bottom left image box bounds enumeration.
        /// </summary>
        BottomLeft,

        /// <summary>
        /// Specifies the bottom right image box bounds enumeration.
        /// </summary>
        BottomRight,

        /// <summary>
        /// Specifies the any image box bounds enumeration.
        /// </summary>
        Any
    }

    /// <summary>
    /// Specifies the mode of the image box.
    /// </summary>
    public enum ImageBoxMode
    {
        /// <summary>
        /// Specifies the none image box mode enumeration.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies the move image box mode enumeration.
        /// </summary>
        Move,

        /// <summary>
        /// Specifies the resize image box mode enumeration.
        /// </summary>
        Resize
    }

    /// <summary>
    /// Specifies a node image type.
    /// </summary>
    public enum NodeImageType
    {
        FolderClosed = 0,
        FolderOpened,
        FolderHiddenClosed,
        FolderHiddenOpen,
        Pictures,
        Desktop,
        MyDocuments,
        CDRom,
        HDD,
        Removable,
        Ram,
        NetworkDrive,
        UnknownDrive,
        Computer,
        Favourites
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ResizeQuality
    {
        Default = InterpolationMode.Default,
        Low = InterpolationMode.Low,
        High = InterpolationMode.High,
        Bicubic = InterpolationMode.Bicubic,
        Bilinear = InterpolationMode.Bilinear,
        HighQualityBicubic = InterpolationMode.HighQualityBicubic,
        HighQualityBilinear = InterpolationMode.HighQualityBilinear
    }
}
