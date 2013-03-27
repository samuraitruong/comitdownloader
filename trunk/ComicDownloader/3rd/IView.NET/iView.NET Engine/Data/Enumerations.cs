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
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System;
using System.Drawing.Imaging;
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Data
{
    /// <summary>
    /// Specifies a NavigateList enumeration.
    /// </summary>
    public enum NavigateList
    {
        /// <summary>
        /// Specifies no navigation.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies the next navigation.
        /// </summary>
        Next,

        /// <summary>
        /// Specifies the previous navigation.
        /// </summary>
        Previous,

        /// <summary>
        /// Specifies the first navigation.
        /// </summary>
        First,

        /// <summary>
        /// Specifies the last navigation.
        /// </summary>
        Last
    }

    /// <summary>
    /// Specifies a channel filter colour.
    /// </summary>
    public enum FilterColour
    {
        /// <summary>
        /// Specifies the red filter.
        /// </summary>
        Red = 0,

        /// <summary>
        /// Specifies the green filter.
        /// </summary>
        Green,

        /// <summary>
        /// Specifies the blue filter.
        /// </summary>
        Blue,
    }

    /// <summary>
    /// Specifies the image file types used by iView.NET.
    /// </summary>
    public enum ImageFileType
    {
        /// <summary>
        /// Specifies all of the image file types. (Default)
        /// </summary>
        All = 0,

        /// <summary>
        /// Specifies a windows bitmap file type.
        /// </summary>
        Bmp,

        /// <summary>
        /// Specifies a graphic interchange format file type.
        /// </summary>
        Gif,

        /// <summary>
        /// Specifies a windows icon file type.
        /// </summary>
        Icon,

        /// <summary>
        /// Specifies a joint photographics experts grounp file type.
        /// </summary>
        Jpeg,

        /// <summary>
        /// Specifies a portable network graphic file type.
        /// </summary>
        Png,

        /// <summary>
        /// Specifies a tagged image file format file type.
        /// </summary>
        Tiff,

        /// <summary>
        /// Specifies that the image type is a unknown type.
        /// </summary>
        Unknown
    }

    /// <summary>
    /// Specifies a desktop wallpaper style.
    /// </summary>
    public enum WallPaperStyle
    {
        /// <summary>
        /// Specifies that the wallpaper should be tiled.
        /// </summary>
        Tile = 0,

        /// <summary>
        /// Specifies that the wallpaper should be centered.
        /// </summary>
        Center,

        /// <summary>
        /// Specifies that the wallpaper should be stretched.
        /// </summary>
        Stretch
    }

    /// <summary>
    /// Specifies the bounds of a rectangle.
    /// </summary>
    public enum RectangleBounds
    {
        /// <summary>
        /// No bounds of the rectangle.
        /// </summary>
        None = 0,

        /// <summary>
        /// Top bounds of the rectangle.
        /// </summary>
        Top = 1,

        /// <summary>
        /// Bottom bounds of the rectangle.
        /// </summary>
        Bottom = 2,

        /// <summary>
        /// Left bounds of the rectangle.
        /// </summary>
        Left = 3,

        /// <summary>
        /// Right bounds of the rectangle.
        /// </summary>
        Right = 4,

        /// <summary>
        /// Top left bounds of the rectangle.
        /// </summary>
        TopLeft = 5,

        /// <summary>
        /// Top right bounds of the rectangle.
        /// </summary>
        TopRight = 6,

        /// <summary>
        /// Bottom left bounds of the rectangle.
        /// </summary>
        BottomLeft = 7,

        /// <summary>
        /// Bottom right bounds of the rectangle.
        /// </summary>
        BottomRight = 8,

        /// <summary>
        /// Any bounds of the rectangle.
        /// </summary>
        Any = 9
    }

    /// <summary>
    /// Specifies a command line argument return type.
    /// </summary>
    public enum CmdResult
    {
        /// <summary>
        /// Specifies no arguments.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies the screen capture tool argument.
        /// </summary>
        OpenScreenCaptureTool,

        /// <summary>
        /// Specifies the convert image file argument.
        /// </summary>
        ConvertImageFile,

        /// <summary>
        /// Specifies the open image file argument.
        /// </summary>
        OpenImageFile,

        /// <summary>
        /// Specifies the open slide show file argument.
        /// </summary>
        OpenSlideShowFile
    }

    /// <summary>
    /// Specifies a processing structure type.
    /// </summary>
    public enum ProcessingStructType
    {
        /// <summary>
        /// Specifies an Invalid processing structure type.
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Specifies an InvertFilter processing structure type.
        /// </summary>
        InvertFilter,

        /// <summary>
        /// Specifies a ColourFilter processing structure type.
        /// </summary>
        ColourFilter,

        /// <summary>
        /// Specifies a RotateColourFilter structure type.
        /// </summary>
        RotateColourFilter,

        /// <summary>
        /// Specifies a PhotoCopy processing structure type.
        /// </summary>
        PhotoCopyFilter,

        /// <summary>
        /// Specifies a Transparency processing structure type.
        /// </summary>
        Transparency,

        /// <summary>
        /// Specifies a GreyScale processing structure type.
        /// </summary>
        GreyScaleFilter,

        /// <summary>
        /// Specifies a Contrast processing structure type.
        /// </summary>
        Contrast,

        /// <summary>
        /// Specifies a Brightness processing structure type.
        /// </summary>
        Brightness,

        /// <summary>
        /// Specifies a Gamma processing structure type.
        /// </summary>
        Gamma,

        /// <summary>
        /// Specifies a RedEyeCorrection processing structure type.
        /// </summary>
        RedEyeCorrection
    }

    /// <summary>
    /// Specifies a bit depth enumeration.
    /// </summary>
    public enum BitDepth
    {
        /// <summary>
        /// Specifies the 32bit colour depth value.
        /// </summary>
        BPP32 = ColorDepth.Depth32Bit,

        /// <summary>
        /// Specifies the 24bit colour depth value.
        /// </summary>
        BPP24 = ColorDepth.Depth24Bit
    }

    /// <summary>
    /// Specifies a tiff compression enumeration.
    /// </summary>
    public enum TiffCompression
    {
        /// <summary>
        /// Specifies no compression.
        /// </summary>
        None = EncoderValue.CompressionNone,

        /// <summary>
        /// Specifies the CCITT3 compression scheme.
        /// </summary>
        CCITT3 = EncoderValue.CompressionCCITT3,

        /// <summary>
        /// Specifies the CCITT4 compression scheme.
        /// </summary>
        CCITT4 = EncoderValue.CompressionCCITT4,

        /// <summary>
        /// Specifies the LZW compression scheme.
        /// </summary>
        LZW = EncoderValue.CompressionLZW,

        /// <summary>
        /// Specifies the Rle compression scheme.
        /// </summary>
        Rle = EncoderValue.CompressionRle
    }

    /// <summary>
    /// Specifies a TransitionMode enumeration.
    /// </summary>
    public enum TransitionMode
    {
        /// <summary>
        /// Specifies a normal transition.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Specifies a fading transition.
        /// </summary>
        Fade
    }

    /// <summary>
    /// Specifies the type of data structure contained within the System.Drawing.Imaging.PropertyItem.Value property.
    /// </summary>
    public enum PropertyItemType : short
    {
        /// <summary>
        /// Specifies that the value data member is null or nothing.
        /// </summary>
        Nothing = 0,

        /// <summary>
        /// Specifies that the value data member is an array of bytes.
        /// </summary>
        Byte = 1,

        /// <summary>
        /// Specifies that the value data member is a null-terminated ASCII string.
        /// </summary>
        ASCII = 2,

        /// <summary>
        /// Specifies that the value data member is an array of unsigned short (16-bit) integers.
        /// </summary>
        Short = 3,

        /// <summary>
        /// Specifies that the value data member is an array of unsigned long (32-bit) integers.
        /// </summary>
        Long = 4,

        /// <summary>
        /// Specifies that the value data member is an array of pairs of unsigned long integers.
        /// </summary>
        Rational = 5,

        /// <summary>
        /// Specifies that the value data member is an array of bytes that can hold values of any data type.
        /// </summary>
        Undefined = 7,

        /// <summary>
        /// Specifies that the value data member is an array of signed long (32-bit) integers.
        /// </summary>
        SLong = 9,

        /// <summary>
        /// Specifies that the value data member is an array of pairs of signed long integers.
        /// </summary>
        SRational = 10
    }

    /// <summary>
    /// Specifies a  System.Drawing.Imaging.PropertyItem identification value.
    /// </summary>
    public enum PropertyItemID
    {
        /// <summary>
        /// Specifies an Invalid PropertyItemID value (0x0).
        /// </summary>
        Invalid = 0x0,

        /// <summary>
        /// Specifies an Artist PropertyItemID value (0x013B).
        /// </summary>
        Artist = 0x013B,

        /// <summary>
        /// Specifies an EquipmentMake PropertyItemID value (0x010F).
        /// </summary>
        EquipmentMake = 0x010F,

        /// <summary>
        /// Specifies an EquipmentModel PropertyItemID value (0x0110).
        /// </summary>
        EquipmentModel = 0x0110,

        /// <summary>
        /// Specifies an ExifVersion PropertyItemID value (0x9000).
        /// </summary>
        ExifVersion = 0x9000,

        /// <summary>
        /// Specifies an ExposureTime PropertyItemID value (0x829A).
        /// </summary>
        ExposureTime = 0x829A,

        /// <summary>
        /// Specifies an ImageDescription PropertyItemID value (0x010E).
        /// </summary>
        ImageDescription = 0x010E,

        /// <summary>
        /// Specifies an ImageTitle PropertyItemID value (0x0320).
        /// </summary>
        ImageTitle = 0x0320,

        /// <summary>
        /// Specifies a Copyright PropertyItemID value (0x8298).
        /// </summary>
        Copyright = 0x8298,

        /// <summary>
        /// Specifies a DocumentName PropertyItemID value (0x010D).
        /// </summary>
        DocumentName = 0x010D,

        /// <summary>
        /// Specifies an DateTaken PropertyItemID value (0x9003).
        /// </summary>
        DateTaken = 0x9003,

        /// <summary>
        /// Specifies an DateDigitized PropertyItemID value (0x9004).
        /// </summary>
        DateDigitized = 0x9004,

        /// <summary>
        /// Specifies an XPComment PropertyItemID value (0x9C9C).
        /// </summary>
        XPComment = 0x9C9C,

        /// <summary>
        /// Specifies an XPSubject PropertyItemID value (0x9C9F).
        /// </summary>
        XPSubject = 0x9C9F,

        /// <summary>
        /// Specifies a Software PropertyItemID value (0x0131).
        /// </summary>
        Software = 0x0131,

        /// <summary>
        /// Specifies a YCbCrPositioning PropertyItemID value (0x0213).
        /// </summary>
        YCbCrPositioning = 0x0213,

        /// <summary>
        /// Specifies a YCbCrSubSampling PropertyItemID value (0x0212).
        /// </summary>
        YCbCrSubSampling = 0x0212,

        /// <summary>
        /// Specifies an Orientation PropertyItemID value (0x0112).
        /// </summary>
        Orientation = 0x0112,

        /// <summary>
        /// Specifies an ISOSpeed PropertyItemID value (0x8827).
        /// </summary>
        ISOSpeed = 0x8827,

        /// <summary>
        /// Specifies an ExposureMode PropertyItemID value (0xA402).
        /// </summary>
        ExposureMode = 0xA402,

        /// <summary>
        /// Specifies an ExposureProgram PropertyItemID value (0x8822).
        /// </summary>
        ExposureProgram = 0x8822,

        /// <summary>
        /// Specifies a Flash PropertyItemID value (0x9209).
        /// </summary>
        Flash = 0x9209,

        /// <summary>
        /// Specifies a MeteringMode PropertyItemID value (0x9207).
        /// </summary>
        MeteringMode = 0x9207,

        /// <summary>
        /// Specifies a ColorSpace PropertyItemID value (0xA001).
        /// </summary>
        ColorSpace = 0xA001,

        /// <summary>
        /// Specifies a ResolutionUnit PropertyItemID value (0x0128).
        /// </summary>
        ResolutionUnit = 0x0128,

        /// <summary>
        /// Specifies a ComponentsConfiguration PropertyItemID value (0x9101).
        /// </summary>
        ComponentsConfiguration = 0x9101,

        /// <summary>
        /// Specifies a Rating PropertyItemID value (0x4746).
        /// </summary>
        Rating = 0x4746,

        /// <summary>
        /// Specifies a WhiteBalance PropertyItemID value (0xA403).
        /// </summary>
        WhiteBalance = 0xA403,

        /// <summary>
        /// Specifies a SceneCaptureType PropertyItemID value (0xA406).
        /// </summary>
        SceneCaptureType = 0xA406,

        /// <summary>
        /// Specifies an FNumber PropertyItemID value (0x829D).
        /// </summary>
        FNumber = 0x829D,

        /// <summary>
        /// Specifies a FocalLength PropertyItemID value (0x920A).
        /// </summary>
        FocalLength = 0x920A,

        /// <summary>
        /// Specifies a MaxAperture PropertyItemID value (0x9205).
        /// </summary>
        MaxAperture = 0x9205,

        /// <summary>
        /// Specifies a CompressedBitsPerPixel PropertyItemID value (0x9102).
        /// </summary>
        CompressedBitsPerPixel = 0x9102,

        /// <summary>
        /// Specifies a ShutterSpeed PropertyItemID value (0x9201).
        /// </summary>
        ShutterSpeed = 0x9201,

        /// <summary>
        /// Specifies a Compression PropertyItemID value (0x0103).
        /// </summary>
        Compression = 0x0103,

        /// <summary>
        /// Specifies a PhotometricInterpretation PropertyItemID value (0x0106).
        /// </summary>
        PhotometricInterpretation = 0x0106,

        /// <summary>
        /// Specifies a Thresholding PropertyItemID value (0x0107).
        /// </summary>
        Thresholding = 0x0107,

        /// <summary>
        /// Specifies a LightSource PropertyItemID value (0x9208).
        /// </summary>
        LightSource = 0x9208,

        /// <summary>
        /// Specifies a Contrast PropertyItemID value (0xA408).
        /// </summary>
        Contrast = 0xA408,

        /// <summary>
        /// Specifies a BrightnessValue PropertyItemID value (0x9203).
        /// </summary>
        BrightnessValue = 0x9203,

        /// <summary>
        /// Specifies a Saturation PropertyItemID value (0xA409).
        /// </summary>
        Saturation = 0xA409,

        /// <summary>
        /// Specifies a Sharpness PropertyItemID value (0xA40A).
        /// </summary>
        Sharpness = 0xA40A
    }

    /// <summary>
    /// Specifies an effect to apply to thumbnails when being created.
    /// </summary>
    [Serializable()]
    public enum ThumbnailEffect
    {
        /// <summary>
        /// Specifies that no effects should be used.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that a drop shadow effect should be used.
        /// </summary>
        DropShadow,

        /// <summary>
        /// Specifies that a gradient background should be used.
        /// </summary>
        GradientBackground,

        /// <summary>
        /// Specifies that a simple border should be used.
        /// </summary>
        SimpleBorder,
    }

    /// <summary>
    /// Specifies a ShearType to use when apply the ShearImage method.
    /// </summary>
    public enum ShearType
    {
        /// <summary>
        /// Specifies a Horizontal shear type.
        /// </summary>
        Horizontal = 0x0,

        /// <summary>
        /// Specifies a Vertical shear type.
        /// </summary>
        Vertical = 0x1
    }
}
