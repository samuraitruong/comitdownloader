//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ExifImageProperties.cs
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
using System.ComponentModel;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides a container for holding EXIF properties of an image file.
    /// </summary>
    [DefaultProperty("Name")]
    public class ExifImageProperties : ImageProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets the Title property.
        /// </summary>
        [Category("EXIF Description")]
        [Description("Displays the title of the image.")]
        [ReadOnly(true)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the Subject property.
        /// </summary>
        [Category("EXIF Description")]
        [Description("Displays the subject of the image.")]
        [ReadOnly(true)]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the Comment property.
        /// </summary>
        [Category("EXIF Description")]
        [Description("Displays the comment of the image.")]
        [ReadOnly(true)]
        public string Comment { get; set; }

        /// <summary>
        /// Gets or sets the Rating property.
        /// </summary>
        [Category("EXIF Description")]
        [Description("Displays the rating given to the image.")]
        [ReadOnly(true)]
        public string Rating { get; set; }

        /// <summary>
        /// Gets or sets the Artist property.
        /// </summary>
        [Category("EXIF Origin")]
        [Description("Displays the name of the person who created the image.")]
        [ReadOnly(true)]
        public string Artist { get; set; }

        /// <summary>
        /// Gets or sets the DateTaken property.
        /// </summary>
        [Category("EXIF Origin")]
        [Description("Displays the date and time when the original image data was generated.")]
        [ReadOnly(true)]
        public string DateTaken { get; set; }

        /// <summary>
        /// Gets or sets the DateDigitized property.
        /// </summary>
        [Category("EXIF Origin")]
        [Description("Displays the date and time when the image was stored as digital data.")]
        [ReadOnly(true)]
        public string DateDigitized { get; set; }

        /// <summary>
        /// Gets or sets the Copyright property.
        /// </summary>
        [Category("EXIF Origin")]
        [Description("Displays the copyright information.")]
        [ReadOnly(true)]
        public string Copyright { get; set; }

        /// <summary>
        /// Gets or sets the Software property.
        /// </summary>
        [Category("EXIF Origin")]
        [Description("Displays the name and version of the software or firmware of the device used to generate the image.")]
        [ReadOnly(true)]
        public string Software { get; set; }

        /// <summary>
        /// Gets or sets the CameraMaker property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the manufacturer of the equipment used to record the image.")]
        [ReadOnly(true)]
        public string CameraMaker { get; set; }

        /// <summary>
        /// Gets or sets the CameraModel property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the model name or model number of the equipment used to record the image.")]
        [ReadOnly(true)]
        public string CameraModel { get; set; }

        /// <summary>
        /// Gets or sets the ExposureMode property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the exposure mode used by the camera when the picture was taken.")]
        [ReadOnly(true)]
        public string ExposureMode { get; set; }

        /// <summary>
        /// Gets or sets the ExposureTime property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the exposure time, measured in seconds.")]
        [ReadOnly(true)]
        public string ExposureTime { get; set; }

        /// <summary>
        /// Gets or sets the Flash property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the flash status.")]
        [ReadOnly(true)]
        public string Flash { get; set; }

        /// <summary>
        /// Gets or sets the FNumber property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the F number.")]
        [ReadOnly(true)]
        public string FNumber { get; set; }

        /// <summary>
        /// Gets or sets the FocalLength property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the actual focal length, in millimeters, of the lens.")]
        [ReadOnly(true)]
        public string FocalLength { get; set; }

        /// <summary>
        /// Gets or sets the MaxAperture property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the smallest F number of the lens.")]
        [ReadOnly(true)]
        public string MaxAperture { get; set; }

        /// <summary>
        /// Gets or sets the MeteringMode property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the metering mode used by the camera.")]
        [ReadOnly(true)]
        public string MeteringMode { get; set; }

        /// <summary>
        /// Gets or sets the ISOSpeed property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the ISO speed and ISO latitude of the camera or input device as specified in ISO 12232.")]
        [ReadOnly(true)]
        public string ISOSpeed { get; set; }

        /// <summary>
        /// Gets or sets the Orientation property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the image orientation viewed in terms of rows and columns.")]
        [ReadOnly(true)]
        public string Orientation { get; set; }

        /// <summary>
        /// Gets or sets the ShutterSpeed property.
        /// </summary>
        [Category("EXIF Camera")]
        [Description("Displays the shutter speed. The unit is the additive system of photographic exposure (APEX) value.")]
        [ReadOnly(true)]
        public string ShutterSpeed { get; set; }

        /// <summary>
        /// Gets or sets the ExposureProgram property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays the class of the program used by the camera to set exposure when the picture is taken.")]
        [ReadOnly(true)]
        public string ExposureProgram { get; set; }

        /// <summary>
        /// Gets or sets the ExifVersion property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays the Exif version.")]
        [ReadOnly(true)]
        public string ExifVersion { get; set; }

        /// <summary>
        /// Gets or sets the Brightness property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays the brightness value.")]
        [ReadOnly(true)]
        public string Brightness { get; set; }

        /// <summary>
        /// Gets or sets the Contrast property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays the contrast type.")]
        [ReadOnly(true)]
        public string Contrast { get; set; }

        /// <summary>
        /// Gets or sets the Saturation property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays the saturation type.")]
        [ReadOnly(true)]
        public string Saturation { get; set; }

        /// <summary>
        /// Gets or sets the Sharpness property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays the sharpness type.")]
        [ReadOnly(true)]
        public string Sharpness { get; set; }

        /// <summary>
        /// Gets or sets the LightSource property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays the type of light source.")]
        [ReadOnly(true)]
        public string LightSource { get; set; }

        /// <summary>
        /// Gets or sets the ResolutionUnit property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays the unit of measure for the horizontal resolution and the vertical resolution.")]
        [ReadOnly(true)]
        public string ResolutionUnit { get; set; }

        /// <summary>
        /// Gets or sets the WhiteBalance property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays the white balance.")]
        [ReadOnly(true)]
        public string WhiteBalance { get; set; }

        /// <summary>
        /// Gets or sets the PhotometricInterpretation property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays how the pixel data will be interpreted.")]
        [ReadOnly(true)]
        public string PhotometricInterpretation { get; set; }

        /// <summary>
        /// Gets or sets the SceneCaptureType property.
        /// </summary>
        [Category("EXIF Advanced Photo")]
        [Description("Displays the scene capture type.")]
        [ReadOnly(true)]
        public string SceneCaptureType { get; set; }

        /// <summary>
        /// Gets or sets the ColourSpace property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the colour space specifier.")]
        [ReadOnly(true)]
        public string ColourSpace { get; set; }

        /// <summary>
        /// Gets or sets the ComponentsConfiguration property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the information specific to compressed data.")]
        [ReadOnly(true)]
        public string ComponentsConfiguration { get; set; }

        /// <summary>
        /// Gets or sets the CompressedBitsPerPixel property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the number of compressed bits per pixel.")]
        [ReadOnly(true)]
        public string CompressedBitsPerPixel { get; set; }

        /// <summary>
        /// Gets or sets the YCbCrSubSampling property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the sampling ratio of chrominance components in relation to the luminance component.")]
        [ReadOnly(true)]
        public string YCbCrSubSampling { get; set; }

        /// <summary>
        /// Gets or sets the YCbCrPositioning property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the position of chrominance components in relation to the luminance component.")]
        [ReadOnly(true)]
        public string YCbCrPositioning { get; set; }

        /// <summary>
        /// Gets or sets the Compression property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the compression scheme used for the image data.")]
        [ReadOnly(true)]
        public string Compression { get; set; }

        #endregion

        #region constructors

        /// <summary>
        /// Creates a new instance of the ExifImageProperties class initialized with default values.
        /// </summary>
        public ExifImageProperties()
        {

        }

        /// <summary>
        /// Creates a new instace of the ExifImageProperties class initialized with the specified ImageProperties object.
        /// </summary>
        /// <param name="oImageProperties"></param>
        public ExifImageProperties(ImageProperties oImageProperties)
        {
            if (oImageProperties != null)
            {
                this.Accessed = oImageProperties.Accessed;
                this.Archive = oImageProperties.Archive;
                this.BitDepth = oImageProperties.BitDepth;
                this.Created = oImageProperties.Created;
                this.Dimensions = oImageProperties.Dimensions;
                this.Frames = oImageProperties.Frames;
                this.Hidden = oImageProperties.Hidden;
                this.Size = oImageProperties.Size;
                this.Modified = oImageProperties.Modified;
                this.Name = oImageProperties.Name;
                this.Normal = oImageProperties.Normal;
                this.Path = oImageProperties.Path;
                this.PixelFormat = oImageProperties.PixelFormat;
                this.ReadOnly = oImageProperties.ReadOnly;
                this.Resolution = oImageProperties.Resolution;
                this.System = oImageProperties.System;
                this.Temporary = oImageProperties.Temporary;
                this.Type = oImageProperties.Type;
            }
        }

        #endregion
    }
}
