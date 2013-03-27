//::///////////////////////////////////////////////////////////////////////////
//:: File Name: FileTools.cs
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
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides properties and methods to manage files for iView.NET.
    /// </summary>
    public class FileTools
    {
        #region Fields and properties

        /// <summary>
        /// Specifies the length of a kilobyte in bytes. (1024)
        /// </summary>
        public const int LEN_KILOBYTE = 1024;

        /// <summary>
        /// Specifies the length of a megabyte in bytes. (1048576)
        /// </summary>
        public const int LEN_MEGABYTE = 1048576;

        /// <summary>
        /// Specifies the length of a gigabyte in bytes. (1073741824)
        /// </summary>
        public const int LEN_GIGABYTE = 1073741824;

        /// <summary>
        /// Specifies the length of a terabyte in bytes. (1099511627776)
        /// </summary>
        public const long LEN_TERABYTE = 1099511627776;

        public const string BMP = ".bmp";
        public const string GIF = ".gif";
        public const string ICON = ".ico";
        public const string JPE = ".jpe";
        public const string JPG = ".jpg";
        public const string JPEG = ".jpeg";
        public const string PNG = ".png";
        public const string TIF = ".tif";
        public const string TIFF = ".tiff";
        public const string SSF = ".ssf";

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor.
        /// </summary>
        private FileTools() { }

        #endregion

        #region Methods

        /// <summary>
        /// Gets a value indicating whether the specified file extension is an EXIF file type extension.
        /// </summary>
        /// <param name="sExtension">Specifies the file extension to test for.</param>
        /// <returns></returns>
        public static bool IsExifFileType(string sExtension)
        {
            string[] sExtensions = new string[] { JPE, JPEG, JPG, TIF, TIFF };

            for (int n = 0; n < sExtensions.Length; n++)
            {
                if (sExtension.Equals(sExtensions[n], StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Returns true if the specified file extension is a valid extension type
        /// used by iView.NET.
        /// </summary>
        /// <param name="sExtension">Specifies the file extension to validate.</param>
        /// <returns></returns>
        public static bool IsFileExtensionValid(string sExtension)
        {
            string[] sExtensions = GetFileExtensions(ImageFileType.All);

            for (int n = 0; n < sExtensions.Length; n++)
            {
                if (sExtension.Equals(sExtensions[n], StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            
            return false;
        }

        /// <summary>
        /// Gets an array of valid file extensions used by iView.NET, specified by
        /// the image file type enumeration.
        /// </summary>
        /// <param name="nImageType">Specifies the type of file extensions to return.</param>
        /// <returns></returns>
        public static string[] GetFileExtensions(ImageFileType nImageType)
        {
            switch (nImageType)
            {
                case ImageFileType.All:
                    return new string[] { BMP, GIF, ICON, JPE, JPG, JPEG, PNG, TIF, TIFF };
                case ImageFileType.Bmp:
                    return new string[] { BMP };
                case ImageFileType.Gif:
                    return new string[] { GIF };
                case ImageFileType.Icon:
                    return new string[] { ICON };
                case ImageFileType.Jpeg:
                    return new string[] { JPE, JPG, JPEG };
                case ImageFileType.Png:
                    return new string[] { PNG };
                case ImageFileType.Tiff:
                    return new string[] { TIF, TIFF };
            }

            return null;
        }

        /// <summary>
        /// Returns a description string for the specified file extension.
        /// </summary>
        /// <param name="sExtension">Specifies the file extension.</param>
        /// <returns></returns>
        public static string GetFileExtensionDescription(string sExtension)
        {
            string sName = string.Empty;

            switch (sExtension.ToLower())
            {
                case BMP:
                    sName = "BMP File";
                    break;
                case GIF:
                    sName = "GIF File";
                    break;
                case ICON:
                    sName = "ICON File";
                    break;
                case JPE:
                    sName = "JPE File";
                    break;
                case JPG:
                    sName = "JPG File";
                    break;
                case JPEG:
                    sName = "JPEG File";
                    break;
                case PNG:
                    sName = "PNG File";
                    break;
                case TIF:
                    sName = "TIF File";
                    break;
                case TIFF:
                    sName = "TIFF File";
                    break;
                default:
                    sName = "Unknown file extension: *" + sExtension;
                    break;
            }
            
            return sName;
        }

        /// <summary>
        /// Converts the specified number of bytes to a string with the correct format.
        /// </summary>
        /// <param name="nBytes">Specifies the number of bytes to convert.</param>
        /// <returns></returns>
        public static string ConvertBytes(long nBytes)
        {
            string sString = string.Empty;

            if (nBytes <= LEN_KILOBYTE)
                sString = nBytes + " Bytes";
            else if ((nBytes >= LEN_KILOBYTE) & (nBytes < LEN_MEGABYTE))
                sString = nBytes / LEN_KILOBYTE + " KB";
            else if ((nBytes >= LEN_MEGABYTE) & (nBytes < LEN_GIGABYTE))
                sString = (Convert.ToDouble(nBytes) / LEN_MEGABYTE).ToString("N1") + " MB";
            else if ((nBytes >= LEN_GIGABYTE) & (nBytes < LEN_TERABYTE))
                sString = (Convert.ToDouble(nBytes) / LEN_GIGABYTE).ToString("N1") + " GB";
            else if (nBytes >= LEN_TERABYTE)
                sString = (Convert.ToDouble(nBytes) / LEN_TERABYTE).ToString("N2") + " TB";

            return sString;
        }

        /// <summary>
        /// Gets an ImageFileType value from the specified file extension.
        /// </summary>
        /// <param name="sExtension">Specifies a valid file extension.</param>
        /// <returns></returns>
        public static ImageFileType GetImageFileType(string sExtension)
        {
            if (IsFileExtensionValid(sExtension))
            {
                switch (sExtension)
                {
                    case BMP:
                        return ImageFileType.Bmp;
                    case GIF:
                        return ImageFileType.Gif;
                    case ICON:
                        return ImageFileType.Icon;
                    case JPE:
                    case JPG:
                    case JPEG:
                        return ImageFileType.Jpeg;
                    case PNG:
                        return ImageFileType.Png;
                    case TIF:
                    case TIFF:
                        return ImageFileType.Tiff;
                    default:
                        return ImageFileType.Unknown;
                }
            }

            return ImageFileType.Unknown;
        }

        #endregion
    }
}
