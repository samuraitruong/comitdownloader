//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageSaver.cs
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
using System; using System.Net;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides properties and methods for saving image objects and files to different formats.
    /// </summary>
    public class ImageSaver : IDisposable
    {
        #region Fields and properties

        private bool m_bIsDisposed;
        private string m_sFilePath;
        private Bitmap m_oBitmap;

        /// <summary>
        /// Gets a value indicating whether dispose has been called on this object.
        /// </summary>
        public bool IsDisposed
        {
            get { return m_bIsDisposed; }
        }

        /// <summary>
        /// Gets or sets the full path of the image file that is about to be saved.
        /// </summary>
        public string FilePath
        {
            get { return m_sFilePath; }
            set { m_sFilePath = value; }
        }

        #endregion

        #region Constructors and destructor

        /// <summary>
        /// Creates a new instance of the ImageSaver class initialized with the specified image parameter.
        /// </summary>
        /// <param name="oImage">Specifies the image to save.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public ImageSaver(Image oImage)
        {
            if (oImage != null)
                m_oBitmap = new Bitmap(oImage, oImage.Size);
            else
                throw new ArgumentNullException("oImage", "The specified parameter cannot be null.");
        }

        /// <summary>
        /// Class destructor.
        /// </summary>
        ~ImageSaver()
        {
            Dispose(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns an ImageFormat enumeration from the specified ImageFileType enumeration.
        /// </summary>
        /// <param name="nFileType">Specifies the ImageFileType enumeration.</param>
        /// <returns></returns>
        private ImageFormat GetImageFormat(ImageFileType nFileType)
        {
            switch (nFileType)
            {
                case ImageFileType.Bmp:
                    return ImageFormat.Bmp;
                case ImageFileType.Gif:
                    return ImageFormat.Gif;
                case ImageFileType.Icon:
                    return ImageFormat.Icon;
                case ImageFileType.Jpeg:
                    return ImageFormat.Jpeg;
                case ImageFileType.Png:
                    return ImageFormat.Png;
                case ImageFileType.Tiff:
                    return ImageFormat.Tiff;
                default:
                    return ImageFormat.Bmp;
            }
        }

        /// <summary>
        /// Gets an ImageCodecInfo object from the specified ImageFormat object parameter.
        /// </summary>
        /// <param name="oFormat">Specifies an ImageFormat object that will be used to find, compare and return a ImageCodecInfo object.</param>
        /// <returns></returns>
        private ImageCodecInfo GetImageEncoderInfo(ImageFormat oFormat)
        {
            foreach (ImageCodecInfo oCodec in ImageCodecInfo.GetImageEncoders())
            {
                if (oCodec.FormatID == oFormat.Guid)
                    return oCodec;
            }

            return null;
        }

        /// <summary>
        /// Validates the currently set file path. Returns an empty string if the path is empty,
        /// null, white space or has invalid path characters. This method also validates and appends a file extension,
        /// if validation fails or one hasen't been provided.
        /// </summary>
        /// <param name="sPath">Specifies the full path of the file.</param>
        /// <param name="nFileType">Specifies the type of image file.</param>
        /// <returns></returns>
        private string ValidateFilePath(string sPath, ImageFileType nFileType)
        {
            if (string.IsNullOrEmpty(sPath))
                return string.Empty;

            if (sPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return string.Empty;

            if (Path.HasExtension(sPath))
            {
                bool bValidExtension = false;

                // Validate the file extension.
                foreach (string sExt in FileTools.GetFileExtensions(nFileType))
                {
                    if (string.Compare(sExt, Path.GetExtension(sPath), true) == 0)
                    {
                        bValidExtension = true;
                        break;
                    }
                }

                // Append a default extension if validation fails.
                if (!bValidExtension)
                    sPath += FileTools.GetFileExtensions(nFileType)[0];
            }
            else
            {
                // If the file extension has not been provided, append a default extension.
                sPath += FileTools.GetFileExtensions(nFileType)[0];
            }

            return sPath;
        }

        /// <summary>
        /// Cleans up managed and unmanaged objects.
        /// </summary>
        /// <param name="bDispose">Specifies whether to clean up managed objects.</param>
        protected virtual void Dispose(bool bDispose)
        {
            if (!m_bIsDisposed)
            {
                if (bDispose)
                {
                    if (m_oBitmap != null)
                    {
                        m_oBitmap.Dispose();
                        m_oBitmap = null;
                    }
                }

                m_bIsDisposed = true;
            }
        }

        /// <summary>
        /// Cleans up all resources used by this class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Saves the current image object as a Windows Bitmap file with the specified BitDepth settings.
        /// </summary>
        /// <param name="nBitDepth">Specifies the bit depth to use when saving.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void SaveAsBmp(BitDepth nBitDepth)
        {
            string sFilePath = ValidateFilePath(m_sFilePath, ImageFileType.Bmp);

            if (string.IsNullOrEmpty(sFilePath))
            {
                MessageBox.Show("The file path provided is invalid.", "Error Saving File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PixelFormat nFormat = (nBitDepth == BitDepth.BPP32) ?
                PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb;
            FileStream oStream = null;

            try
            {
                oStream = new FileStream(sFilePath, FileMode.Create, FileAccess.Write);

                using (Bitmap oBmp = new Bitmap(m_oBitmap.Width, m_oBitmap.Height, nFormat))
                {
                    using (Graphics oGraphics = Graphics.FromImage(oBmp))
                        oGraphics.DrawImage(m_oBitmap, Point.Empty);

                    oBmp.Save(oStream, ImageFormat.Bmp);
                }
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message, e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message, e);
            }
            catch (IOException e)
            {
                throw new IOException(e.Message, e);
            }
            catch (System.Security.SecurityException e)
            {
                throw new System.Security.SecurityException(e.Message, e);
            }
            finally
            {
                if (oStream != null)
                    oStream.Close();
            }
        }

        /// <summary>
        /// Saves the current image object as a Graphics Interchange Format file.
        /// </summary>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void SaveAsGif()
        {
            string sFilePath = ValidateFilePath(m_sFilePath, ImageFileType.Gif);

            if (string.IsNullOrEmpty(sFilePath))
            {
                MessageBox.Show("The file path provided is invalid.", "Error Saving File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileStream oStream = null;

            try
            {
                oStream = new FileStream(sFilePath, FileMode.Create, FileAccess.Write);

                // Save the bitmap to the FileStream.
                m_oBitmap.Save(oStream, ImageFormat.Gif);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message, e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message, e);
            }
            catch (IOException e)
            {
                throw new IOException(e.Message, e);
            }
            catch (System.Security.SecurityException e)
            {
                throw new System.Security.SecurityException(e.Message, e);
            }
            finally
            {
                if (oStream != null)
                    oStream.Close();
            }
        }

        /// <summary>
        /// Saves the current image object as a Joint Photographics Experts Group file with the specified quality settings.
        /// </summary>
        /// <param name="nQuality">Specifies the quality to use when saving. Values range from 0 to 100.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void SaveAsIcon()
        {
            string sFilePath = ValidateFilePath(m_sFilePath, ImageFileType.Icon);

            if (string.IsNullOrEmpty(sFilePath))
            {
                MessageBox.Show("The file path provided is invalid.", "Error Saving File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileStream oStream = null;

            try
            {
                oStream = new FileStream(sFilePath, FileMode.Create, FileAccess.Write);

                using (Bitmap oBmp = new Bitmap(m_oBitmap.Width, m_oBitmap.Height, PixelFormat.Format24bppRgb))
                {
                    using (Graphics oGraphics = Graphics.FromImage(oBmp))
                    {
                        //oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        oGraphics.DrawImage(m_oBitmap, Point.Empty);
                    }

                    // Create an icon from the bitmap and save it to the file stream.
                    Icon oIcon = Icon.FromHandle(oBmp.GetHicon());
                    oIcon.Save(oStream);

                    // Clean up unmanaged resources.
                    NativeMethods.ReleaseIcon(oIcon);
                }
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message, e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message, e);
            }
            catch (IOException e)
            {
                throw new IOException(e.Message, e);
            }
            catch (System.Security.SecurityException e)
            {
                throw new System.Security.SecurityException(e.Message, e);
            }
            finally
            {
                if (oStream != null)
                    oStream.Close();
            }
        }

        /// <summary>
        /// Saves the current image object as a Joint Photographics Experts Group file with the specified quality settings.
        /// </summary>
        /// <param name="nQuality">Specifies the quality to use when saving. Values range from 0 to 100.</param>
        /// <param name="oPropertyItems">Specifies an array of property items to write to the image file.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void SaveAsJpeg(int nQuality, PropertyItem[] oPropertyItems)
        {
            string sFilePath = ValidateFilePath(m_sFilePath, ImageFileType.Jpeg);

            if (string.IsNullOrEmpty(sFilePath))
            {
                MessageBox.Show("The file path provided is invalid.", "Error Saving File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileStream oStream = null;

            try
            {
                oStream = new FileStream(sFilePath, FileMode.Create, FileAccess.Write);

                using (EncoderParameter oEncodeParam = new EncoderParameter(Encoder.Quality, (long)nQuality))
                {
                    using (EncoderParameters oEncodeParams = new EncoderParameters(1))
                    {
                        oEncodeParams.Param[0] = oEncodeParam;

                        // Set the property items. If there are any.
                        if ((oPropertyItems != null) && (oPropertyItems.Length > 0))
                        {
                            foreach (PropertyItem oPropItem in oPropertyItems)
                                m_oBitmap.SetPropertyItem(oPropItem);
                        }

                        // Save the bitmap to the FileStream with the specified ImageCodecInfo and EncoderParameters.
                        m_oBitmap.Save(oStream, GetImageEncoderInfo(ImageFormat.Jpeg), oEncodeParams);
                    }
                }
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message, e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message, e);
            }
            catch (IOException e)
            {
                throw new IOException(e.Message, e);
            }
            catch (System.Security.SecurityException e)
            {
                throw new System.Security.SecurityException(e.Message, e);
            }
            finally
            {
                if (oStream != null)
                    oStream.Close();
            }
        }

        /// <summary>
        /// Saves the current image object as a Portable Network Graphic file.
        /// </summary>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void SaveAsPng()
        {
            string sFilePath = ValidateFilePath(m_sFilePath, ImageFileType.Png);

            if (string.IsNullOrEmpty(sFilePath))
            {
                MessageBox.Show("The file path provided is invalid.", "Error Saving File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileStream oStream = null;

            try
            {
                oStream = new FileStream(sFilePath, FileMode.Create, FileAccess.Write);

                // Save the bitmap to the FileStream.
                m_oBitmap.Save(oStream, ImageFormat.Png);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message, e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message, e);
            }
            catch (IOException e)
            {
                throw new IOException(e.Message, e);
            }
            catch (System.Security.SecurityException e)
            {
                throw new System.Security.SecurityException(e.Message, e);
            }
            finally
            {
                if (oStream != null)
                    oStream.Close();
            }
        }

        /// <summary>
        /// Saves the current image object as a Tagged Image File Format file with the specified BitDepth and TiffCompression settings.
        /// </summary>
        /// <param name="nBitDepth">Specifies the BitDepth to use when saving.</param>
        /// <param name="nTiffCompression">Specifies the type of compression to use when saving.</param>
        /// <param name="oPropertyItems">Specifies an array of property items to write to the image file.</param>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void SaveAsTiff(BitDepth nBitDepth, TiffCompression nTiffCompression, PropertyItem[] oPropertyItems)
        {
            string sFilePath = ValidateFilePath(m_sFilePath, ImageFileType.Tiff);

            if (string.IsNullOrEmpty(sFilePath))
            {
                MessageBox.Show("The file path provided is invalid.", "Error Saving File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileStream oStream = null;

            try
            {
                oStream = new FileStream(sFilePath, FileMode.Create, FileAccess.Write);

                using (EncoderParameter oBitDepthParam = new EncoderParameter(Encoder.ColorDepth, (long)nBitDepth))
                {
                    using (EncoderParameter oCompressionParam = new EncoderParameter(Encoder.Compression, (long)nTiffCompression))
                    {
                        using (EncoderParameters oEncodeParams = new EncoderParameters(2))
                        {
                            oEncodeParams.Param[0] = oBitDepthParam;
                            oEncodeParams.Param[1] = oCompressionParam;

                            // Set the property items. If there are any.
                            if ((oPropertyItems != null) && (oPropertyItems.Length > 0))
                            {
                                foreach (PropertyItem oPropItem in oPropertyItems)
                                    m_oBitmap.SetPropertyItem(oPropItem);
                            }
                            
                            // Save the bitmap to the FileStream with the specified ImageCodecInfo and EncoderParameters.
                            m_oBitmap.Save(oStream, GetImageEncoderInfo(ImageFormat.Tiff), oEncodeParams);
                        }
                    }
                }
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message, e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message, e);
            }
            catch (IOException e)
            {
                throw new IOException(e.Message, e);
            }
            catch (System.Security.SecurityException e)
            {
                throw new System.Security.SecurityException(e.Message, e);
            }
            finally
            {
                if (oStream != null)
                    oStream.Close();
            }
        }

        #endregion
    }
}
