//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageProperties.cs
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
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides a container for holding the standard properties of an image file.
    /// </summary>
    [DefaultProperty("Name")]
    public class ImageProperties
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the file is an archive file.
        /// </summary>
        [Category("File Attributes")]
        [Description("Displays a boolean value specifying whether the file is an archive file.")]
        [ReadOnly(true)]
        public virtual bool Archive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the file is a hidden file.
        /// </summary>
        [Category("File Attributes")]
        [Description("Displays a boolean value specifying whether the file is a hidden file.")]
        [ReadOnly(true)]
        public virtual bool Hidden { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the file is a normal file.
        /// </summary>
        [Category("File Attributes")]
        [Description("Displays a boolean value specifying whether the file is a normal file.")]
        [ReadOnly(true)]
        public virtual bool Normal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the file is a read only file.
        /// </summary>
        [Category("File Attributes")]
        [Description("Displays a boolean value specifying whether the file is a read only file.")]
        [ReadOnly(true)]
        public virtual bool ReadOnly { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the file is a system file.
        /// </summary>
        [Category("File Attributes")]
        [Description("Displays a boolean value specifying whether the file is a system file.")]
        [ReadOnly(true)]
        public virtual bool System { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the file is a temporary file.
        /// </summary>
        [Category("File Attributes")]
        [Description("Displays a boolean value specifying whether the file is a temporary file.")]
        [ReadOnly(true)]
        public virtual bool Temporary { get; set; }

        /// <summary>
        /// Gets or sets the Name property.
        /// </summary>
        [Category("File Properties")]
        [Description("Displays the full name of the file.")]
        [ReadOnly(true)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the file type property.
        /// </summary>
        [Category("File Properties")]
        [Description("Displays the file type.")]
        [ReadOnly(true)]
        public virtual string Type { get; set; }

        /// <summary>
        /// Gets or sets the file path property.
        /// </summary>
        [Category("File Properties")]
        [Description("Displays the full path of the file.")]
        [ReadOnly(true)]
        public virtual string Path { get; set; }

        /// <summary>
        /// Gets or sets the Size property.
        /// </summary>
        [Category("File Properties")]
        [Description("Displays the size of the file.")]
        [ReadOnly(true)]
        public virtual string Size { get; set; }

        /// <summary>
        /// Gets or sets the Accessed property.
        /// </summary>
        [Category("File Properties")]
        [Description("Displays the date and time when the file was last accessed.")]
        [ReadOnly(true)]
        public virtual string Accessed { get; set; }

        /// <summary>
        /// Gets or sets the Created property.
        /// </summary>
        [Category("File Properties")]
        [Description("Displays the date and time when the file was created.")]
        [ReadOnly(true)]
        public virtual string Created { get; set; }

        /// <summary>
        /// Gets or sets the last Modified property.
        /// </summary>
        [Category("File Properties")]
        [Description("Displays the date and time when the file was last modified.")]
        [ReadOnly(true)]
        public virtual string Modified { get; set; }

        /// <summary>
        /// Gets or sets the Resolution property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the resolution of the image in dots per inch. (dpi)")]
        [ReadOnly(true)]
        public virtual Resolution Resolution { get; set; }

        /// <summary>
        /// Gets or sets the PixelFormat property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the pixel format of the image.")]
        [ReadOnly(true)]
        public virtual PixelFormat PixelFormat { get; set; }

        /// <summary>
        /// Gets or sets the image dimensions property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the dimensions of the image in pixels.")]
        [ReadOnly(true)]
        public virtual Size Dimensions { get; set; }

        /// <summary>
        /// Gets or sets the BitDepth property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the bit depth of the image in bits per pixel. (bpp)")]
        [ReadOnly(true)]
        public virtual int BitDepth { get; set; }

        /// <summary>
        /// Gets or sets the Frames property.
        /// </summary>
        [Category("Image Properties")]
        [Description("Displays the number of frames.")]
        [ReadOnly(true)]
        public virtual int Frames { get; set; }

        #endregion

        #region Overrides

        /// <summary>
        /// Gets a string representation of the current object.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder oString = new StringBuilder();

            oString.Append("Archive=" + this.Archive);
            oString.Append(Environment.NewLine);
            oString.Append("Hidden=" + this.Hidden);
            oString.Append(Environment.NewLine);
            oString.Append("Normal=" + this.Normal);
            oString.Append(Environment.NewLine);
            oString.Append("ReadOnly=" + this.ReadOnly);
            oString.Append(Environment.NewLine);
            oString.Append("System=" + this.System);
            oString.Append(Environment.NewLine);
            oString.Append("Temporary=" + this.Temporary);
            oString.Append(Environment.NewLine);
            oString.Append("Name=" + this.Name);
            oString.Append(Environment.NewLine);
            oString.Append("Type=" + this.Type);
            oString.Append(Environment.NewLine);
            oString.Append("Path=" + this.Path);
            oString.Append(Environment.NewLine);
            oString.Append("Size=" + this.Size);
            oString.Append(Environment.NewLine);
            oString.Append("Accessed=" + this.Accessed);
            oString.Append(Environment.NewLine);
            oString.Append("Created=" + this.Created);
            oString.Append(Environment.NewLine);
            oString.Append("Modified=" + this.Modified);
            oString.Append(Environment.NewLine);
            oString.Append("Resolution=" + this.Resolution);
            oString.Append(Environment.NewLine);
            oString.Append("PixelFormat=" + this.PixelFormat);
            oString.Append(Environment.NewLine);
            oString.Append("Dimensions=" + this.Dimensions);
            oString.Append(Environment.NewLine);
            oString.Append("BitDepth=" + this.BitDepth);
            oString.Append(Environment.NewLine);
            oString.Append("Frames=" + this.Frames);
            oString.Append(Environment.NewLine);

            return oString.ToString();
        }

        #endregion
    }
}
