//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ExifReader.cs
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
//:: Created On: 23 April 2011
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
using System; using System.Net;
using System.Drawing.Imaging;
using System.Text;
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides properties and methods for reading EXIF property items.
    /// </summary>
    public class ExifReader
    {
        #region Fields and properties

        private const short PROP_TYPE_BYTE = 1;
        private const short PROP_TYPE_ASCII = 2;
        private const short PROP_TYPE_SHORT = 3;
        private const short PROP_TYPE_LONG = 4;
        private const short PROP_TYPE_RATIONAL = 5;
        private const short PROP_TYPE_UNDEFINED = 7;
        private const short PROP_TYPE_SLONG = 9;
        private const short PROP_TYPE_SRATIONAL = 10;

        private PropertyItem[] m_oPropertyItems;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ExifReader class initialized with the specified PropertyItem array.
        /// </summary>
        /// <param name="oPropertyItems">Specifies an array of property items to read from.</param>
        public ExifReader(PropertyItem[] oPropertyItems)
        {
            if (oPropertyItems != null)
                m_oPropertyItems = oPropertyItems;
            else
                throw new ArgumentNullException("oPropertyItems", "The specified parameter cannot be null.");
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetColourSpace(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0x1:
                    return "sRGB";
                case 0x2:
                    return "Adobe RGB";
                case 0xfffd:
                    return "Wide Gamut RGB";
                case 0xfffe:
                    return "ICC Profile";
                case 0xffff:
                    return "Uncalibrated";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetCompression(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 1:
                    return "Uncompressed";
                case 2:
                    return "CCITT 1D";
                case 3:
                    return "T4/Group 3 Fax";
                case 4:
                    return "T6/Group 4 Fax";
                case 5:
                    return "LZW";
                case 6:
                    return "JPEG (old-style)";
                case 7:
                    return "JPEG";
                case 8:
                    return "Adobe Deflate";
                case 9:
                    return "JBIG B&W";
                case 10:
                    return "JBIG Color";
                case 99:
                    return "JPEG";
                case 262:
                    return "Kodak 262";
                case 32766:
                    return "Next";
                case 32767:
                    return "Sony ARW Compressed";
                case 32769:
                    return "Packed RAW";
                case 32770:
                    return "Samsung SRW Compressed";
                case 32771:
                    return "CCIRLEW";
                case 32773:
                    return "PackBits";
                case 32809:
                    return "Thunderscan";
                case 32867:
                    return "Kodak KDC Compressed";
                case 32895:
                    return "IT8CTPAD";
                case 32896:
                    return "IT8LW";
                case 32897:
                    return "IT8MP";
                case 32898:
                    return "IT8BL";
                case 32908:
                    return "PixarFilm";
                case 32909:
                    return "PixarLog";
                case 32946:
                    return "Deflate";
                case 32947:
                    return "DCS";
                case 34661:
                    return "JBIG";
                case 34676:
                    return "SGILog";
                case 34677:
                    return "SGILog24";
                case 34712:
                    return "JPEG 2000";
                case 34713:
                    return "Nikon NEF Compressed";
                case 34715:
                    return "JBIG2 TIFF FX";
                case 34718:
                    return "Microsoft Document Imaging (MDI) Binary Level Codec";
                case 34719:
                    return "Microsoft Document Imaging (MDI) Progressive Transform Codec";
                case 34720:
                    return "Microsoft Document Imaging (MDI) Vector";
                case 65000:
                    return "Kodak DCR Compressed";
                case 65535:
                    return "Pentax PEF Compressed";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetComponentsConfiguration(PropertyItem oPropertyItem)
        {
            if ((oPropertyItem.Value != null) && (oPropertyItem.Value.Length == 4))
            {
                ushort n = oPropertyItem.Value[0], i = oPropertyItem.Value[1],
                    j = oPropertyItem.Value[2], k = oPropertyItem.Value[3];

                string[] sItems = new string[] { string.Empty, "Y", "Cb", "Cr", "R", "G", "B" };

                if (n < sItems.Length && i < sItems.Length && j < sItems.Length && k < sItems.Length)
                    return string.Concat(sItems[n], sItems[i], sItems[j], sItems[k]);
            }
            
            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetMeteringMode(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0:
                    return "(0) Unknown";
                case 1:
                    return "(1) Average";
                case 2:
                    return "(2) Center-weighted average";
                case 3:
                    return "(3) Spot";
                case 4:
                    return "(4) Multi-spot";
                case 5:
                    return "(5) Multi-segment";
                case 6:
                    return "(6) Partial";
                case 255:
                    return "(255) Other";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetFlash(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0x0:
                    return "(0) No Flash";
                case 0x1:
                    return "(1) Fired";
                case 0x5:
                    return "(5) Fired, Return not detected";
                case 0x7:
                    return "(7) Fired, Return detected";
                case 0x8:
                    return "(8) On, Did not fire";
                case 0x9:
                    return "(9) On, Fired";
                case 0xd:
                    return "(13) On, Return not detected";
                case 0xf:
                    return "(15) On, Return detected";
                case 0x10:
                    return "(16) Off, Did not fire";
                case 0x14:
                    return "(20) Off, Did not fire, Return not detected";
                case 0x18:
                    return "(24) Auto, Did not fire";
                case 0x19:
                    return "(25) Auto, Fired";
                case 0x1d:
                    return "(29) No Flash";
                case 0x1f:
                    return "(31) Auto, Fired, Return detected";
                case 0x20:
                    return "(32) No flash function";
                case 0x30:
                    return "(48) Off, No flash function";
                case 0x41:
                    return "(65) Fired, Red-eye reduction";
                case 0x45:
                    return "(69) Fired, Red-eye reduction, Return not detected";
                case 0x47:
                    return "(71) Fired, Red-eye reduction, Return detected";
                case 0x49:
                    return "(73) On, Red-eye reduction";
                case 0x4d:
                    return "(77) On, Red-eye reduction, Return not detected";
                case 0x4f:
                    return "(79) On, Red-eye reduction, Return detected";
                case 0x50:
                    return "(80) Off, Red-eye reduction";
                case 0x58:
                    return "(88) Auto, Did not fire, Red-eye reduction";
                case 0x59:
                    return "(89) Auto, Fired, Red-eye reduction";
                case 0x5d:
                    return "(93) Auto, Fired, Red-eye reduction, Return not detected";
                case 0x5f:
                    return "(95) Auto, Fired, Red-eye reduction, Return detected";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetExposureMode(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0:
                    return "(0) Auto";
                case 1:
                    return "(1) Manual";
                case 2:
                    return "(2) Auto bracket";
                default:
                    return string.Empty;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetExposureProgram(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0:
                    return "(0) Not Defined";
                case 1:
                    return "(1) Manual";
                case 2:
                    return "(2) Program AE";
                case 3:
                    return "(3) Aperture-priority AE";
                case 4:
                    return "(4) Shutter speed priority AE";
                case 5:
                    return "(5) Creative (Slow speed)";
                case 6:
                    return "(6) Action (High speed)";
                case 7:
                    return "(7) Portrait";
                case 8:
                    return "(8) Landscape";
                case 9:
                    return "(9) Bulb";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetOrientation(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 1:
                    return "(1) Horizontal (normal)";
                case 2:
                    return "(2) Mirror horizontal";
                case 3:
                    return "(3) Rotate 180";
                case 4:
                    return "(4) Mirror vertical";
                case 5:
                    return "(5) Mirror horizontal and rotate 270 CW";
                case 6:
                    return "(6) Rotate 90 CW";
                case 7:
                    return "(7) Mirror horizontal and rotate 90 CW";
                case 8:
                    return "(8) Rotate 270 CW";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetResolutionUnit(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 1:
                    return "(1) None";
                case 2:
                    return "(2) Inches";
                case 3:
                    return "(3) Centimeters";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetYCbCrSubSampling(PropertyItem oPropertyItem)
        {
            if (oPropertyItem.Value.Length == 2)
            {
                ushort n = oPropertyItem.Value[0], i = oPropertyItem.Value[1];

                if (n == 1 && i == 1)
                    return "(1, 1) YCbCr4:4:4";
                if (n == 1 && i == 2)
                    return "(1, 2) YCbCr4:4:0";
                if (n == 1 && i == 4)
                    return "(1, 4) YCbCr4:4:1";
                if (n == 2 && i == 1)
                    return "(2, 1) YCbCr4:2:2";
                if (n == 2 && i == 2)
                    return "(2, 2) YCbCr4:2:0";
                if (n == 2 && i == 4)
                    return "(2, 4) YCbCr4:2:1";
                if (n == 4 && i == 1)
                    return "(4, 1) YCbCr4:1:1";
                if (n == 4 && i == 2)
                    return "(4, 2) YCbCr4:1:0";
            }

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetYCbCrPositioning(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 1:
                    return "(1) Centered";
                case 2:
                    return "(2) Co-sited";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetRating(PropertyItem oPropertyItem)
        {
            ushort nValue = (ushort)oPropertyItem.Value[0];

            if (nValue > 0)
                return nValue + ((nValue > 1) ? " Stars" : " Star");

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetSceneCaptureType(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0:
                    return "(0) Standard";
                case 1:
                    return "(1) Landscape";
                case 2:
                    return "(2) Portrait";
                case 3:
                    return "(3) Night";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetWhiteBalance(PropertyItem oPropertyItem)
        {
            ushort nValue = (ushort)oPropertyItem.Value[0];

            if (nValue >= 0)
                return "(" + nValue + ")" + ((nValue > 0) ? " Manual" : " Auto");

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetPhotometricInterpretation(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0:
                    return "(0) WhiteIsZero";
                case 1:
                    return "(1) BlackIsZero";
                case 2:
                    return "(2) RGB";
                case 3:
                    return "(3) RGB Palette";
                case 4:
                    return "(4) Transparency Mask";
                case 5:
                    return "(5) CMYK";
                case 6:
                    return "(6) YCbCr";
                case 8:
                    return "(8) CIELab";
                case 9:
                    return "(9) ICCLab";
                case 10:
                    return "(10) ITULab";
                case 32803:
                    return "(32803) Color Filter Array";
                case 32844:
                    return "(32844) Pixar LogL";
                case 32845:
                    return "(32845) Pixar LogLuv";
                case 34892:
                    return "(34892) Linear Raw";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetThresholding(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 1:
                    return "(1) No dithering or halftoning";
                case 2:
                    return "(2) Ordered dither or halftone";
                case 3:
                    return "(3) Randomized dither";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetLightSource(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0:
                    return "(0) Unknown";
                case 1:
                    return "(1) Daylight";
                case 2:
                    return "(2) Fluorescent";
                case 3:
                    return "(3) Tungsten (Incandescent)";
                case 4:
                    return "(4)	Flash";
                case 9:
                    return "(9) Fine Weather";
                case 10:
                    return "(10) Cloudy";
                case 11:
                    return "(11) Shade";
                case 12:
                    return "(12) Daylight Fluorescent";
                case 13:
                    return "(13) Day White Fluorescent";
                case 14:
                    return "(14) Cool White Fluorescent";
                case 15:
                    return "(15) White Fluorescent";
                case 16:
                    return "(16) Warm White Fluorescent";
                case 17:
                    return "(17) Standard Light A";
                case 18:
                    return "(18) Standard Light B";
                case 19:
                    return "(19) Standard Light C";
                case 20:
                    return "(20) D55";
                case 21:
                    return "(21) D65";
                case 22:
                    return "(22) D75";
                case 23:
                    return "(23) D50";
                case 24:
                    return "(24) ISO Studio Tungsten";
                case 255:
                    return "(255) Other";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetContrast(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0:
                    return "(0) Normal ";
                case 1:
                    return "(1) Low";
                case 2:
                    return "(2) High";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetSaturation(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0:
                    return "(0) Normal ";
                case 1:
                    return "(1) Low";
                case 2:
                    return "(2) High";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <returns></returns>
        private string GetSharpness(PropertyItem oPropertyItem)
        {
            switch ((ushort)oPropertyItem.Value[0])
            {
                case 0:
                    return "(0) Normal ";
                case 1:
                    return "(1) Soft";
                case 2:
                    return "(2) Hard";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <param name="nID"></param>
        /// <returns></returns>
        private string FormatTypeShortValue(PropertyItem oPropertyItem, PropertyItemID nID)
        {
            switch (nID)
            {
                case PropertyItemID.Compression:
                    return GetCompression(oPropertyItem);
                case PropertyItemID.Rating:
                    return GetRating(oPropertyItem);
                case PropertyItemID.ColorSpace:
                    return GetColourSpace(oPropertyItem);
                case PropertyItemID.ExposureMode:
                    return GetExposureMode(oPropertyItem);
                case PropertyItemID.ExposureProgram:
                    return GetExposureProgram(oPropertyItem);
                case PropertyItemID.Orientation:
                    return GetOrientation(oPropertyItem);
                case PropertyItemID.Flash:
                    return GetFlash(oPropertyItem);
                case PropertyItemID.MeteringMode:
                    return GetMeteringMode(oPropertyItem);
                case PropertyItemID.ResolutionUnit:
                    return GetResolutionUnit(oPropertyItem);
                case PropertyItemID.SceneCaptureType:
                    return GetSceneCaptureType(oPropertyItem);
                case PropertyItemID.WhiteBalance:
                    return GetWhiteBalance(oPropertyItem);
                case PropertyItemID.YCbCrPositioning:
                    return GetYCbCrPositioning(oPropertyItem);
                case PropertyItemID.YCbCrSubSampling:
                    return GetYCbCrSubSampling(oPropertyItem);
                case PropertyItemID.PhotometricInterpretation:
                    return GetPhotometricInterpretation(oPropertyItem);
                case PropertyItemID.Thresholding:
                    return GetThresholding(oPropertyItem);
                case PropertyItemID.LightSource:
                    return GetLightSource(oPropertyItem);
                case PropertyItemID.Contrast:
                    return GetContrast(oPropertyItem);
                case PropertyItemID.Saturation:
                    return GetSaturation(oPropertyItem);
                case PropertyItemID.Sharpness:
                    return GetSharpness(oPropertyItem);
                case PropertyItemID.ISOSpeed:
                    return oPropertyItem.Value[0].ToString();
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <param name="nID"></param>
        /// <returns></returns>
        private string FormatTypeRationalValue(PropertyItem oPropertyItem, PropertyItemID nID)
        {
            if (oPropertyItem.Len == 8)
            {
                uint n = BitConverter.ToUInt32(oPropertyItem.Value, 0);
                uint d = BitConverter.ToUInt32(oPropertyItem.Value, 4);

                switch (nID)
                {
                    case PropertyItemID.CompressedBitsPerPixel:
                    case PropertyItemID.ExposureTime:
                        return ((float)n / d).ToString("N2");
                    case PropertyItemID.FNumber:
                        return ((float)n / d).ToString("N1");
                    case PropertyItemID.MaxAperture:
                        return (n / d).ToString();
                    case PropertyItemID.FocalLength:
                        return (n / d).ToString() + " mm";
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <param name="nID"></param>
        /// <returns></returns>
        private string FormatTypeSRationalValue(PropertyItem oPropertyItem, PropertyItemID nID)
        {
            if (oPropertyItem.Len == 8)
            {
                int n = BitConverter.ToInt32(oPropertyItem.Value, 0);
                int d = BitConverter.ToInt32(oPropertyItem.Value, 4);

                switch (nID)
                {
                    case PropertyItemID.ShutterSpeed:
                    case PropertyItemID.BrightnessValue:
                        return ((float)n / d).ToString("N2");
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <param name="nID"></param>
        /// <returns></returns>
        private string FormatTypeASCIIValue(PropertyItem oPropertyItem, PropertyItemID nID)
        {
            switch (nID)
            {
                case PropertyItemID.XPComment:
                case PropertyItemID.XPSubject:
                    return UnicodeEncoding.Unicode.GetString(oPropertyItem.Value);
                default:
                    return ASCIIEncoding.ASCII.GetString(oPropertyItem.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oPropertyItem"></param>
        /// <param name="nID"></param>
        /// <returns></returns>
        private string FormatTypeUndefinedValue(PropertyItem oPropertyItem, PropertyItemID nID)
        {
            switch (nID)
            {
                case PropertyItemID.ComponentsConfiguration:
                    return GetComponentsConfiguration(oPropertyItem);
                case PropertyItemID.ExifVersion:
                    return ASCIIEncoding.ASCII.GetString(oPropertyItem.Value);
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Reads a property item specified by the PropertyItemID value and returns it as a string value.
        /// </summary>
        /// <param name="nPropertyID">Specifies the PropertyItem to get and read.</param>
        /// <returns></returns>
        public string GetExifProperty(PropertyItemID nPropertyID)
        {
            // Return an empty value if the PropertyItems array is null.
            if (m_oPropertyItems == null)
                return string.Empty;
            
            int nID = (int)nPropertyID;
            string sData = string.Empty;

            foreach (PropertyItem oPropertyItem in m_oPropertyItems)
            {
                if ((oPropertyItem != null) && (oPropertyItem.Id == nID))
                {
                    switch (oPropertyItem.Type)
                    {
                        case PROP_TYPE_BYTE:
                        case PROP_TYPE_ASCII:
                            sData = FormatTypeASCIIValue(oPropertyItem, nPropertyID);
                            break;
                        case PROP_TYPE_RATIONAL:
                            sData = FormatTypeRationalValue(oPropertyItem, nPropertyID);
                            break;
                        case PROP_TYPE_SRATIONAL:
                            sData = FormatTypeSRationalValue(oPropertyItem, nPropertyID);
                            break;
                        case PROP_TYPE_SHORT:
                            sData = FormatTypeShortValue(oPropertyItem, nPropertyID);
                            break;
                        case PROP_TYPE_UNDEFINED:
                            sData = FormatTypeUndefinedValue(oPropertyItem, nPropertyID);
                            break;
                    }

                    break;
                }
            }

            return sData;
        }

        #endregion
    }
}
