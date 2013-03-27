//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageBrowser.cs
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
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides properties and methods for loading and managing image files.
    /// </summary>
    public class ImageBrowser : IDisposable
    {
        #region Fields and properties

        private const int MAX_FILES = 10000;
        private const long MAX_FILE_LENGTH = (FileTools.LEN_MEGABYTE * 10);

        private bool m_bIsDisposed;
        private bool m_bThumbNailsInitialized;
        private bool m_bHighQualityThumbnails;
        private int m_nMaxFiles;
        private int m_nFileCount;
        private int m_nSelectedIndex;
        private long m_lMaxFileLength;
        private string m_sSelectedFilePath;
        private string m_sSelectedDirectoryPath;
        private ThumbnailEffect m_nThumbnailEffect;
        private Size m_ThumbNailSize;
        private ImageProperties m_oImageInfo;
        private ImageList m_oImageList;
        private List<string> m_sFilePaths;
        private List<ListViewItem> m_oListViewItems;
        private PropertyItem[] m_oPropertyItems;

        /// <summary>
        /// Gets a value indicating whether dispose has been called on this object.
        /// </summary>
        public bool IsDisposed
        {
            get { return m_bIsDisposed; }
        }

        /// <summary>
        /// Gets a value indicating whether any files have been loaded by the image browser.
        /// </summary>
        public bool IsLoaded
        {
            get { return (m_nFileCount > 0); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to use high quality thumbnail images.
        /// </summary>
        public bool HighQualityThumbnails
        {
            get { return m_bHighQualityThumbnails; }
            set { m_bHighQualityThumbnails = value; }
        }

        /// <summary>
        /// Gets or sets the maximium number of files that can be loaded into the ImageBrowser.
        /// </summary>
        public int MaxFiles
        {
            get { return m_nMaxFiles; }
            set
            {
                if ((value >= 0) && (value <= MAX_FILES))
                    m_nMaxFiles = value;
                else
                    m_nMaxFiles = MAX_FILES;
            }
        }

        /// <summary>
        /// Gets the number of files that have been loaded from the current directory.
        /// </summary>
        public int FileCount
        {
            get { return m_nFileCount; }
        }

        /// <summary>
        /// Gets the currently selected index.
        /// </summary>
        public int SelectedIndex
        {
            get { return m_nSelectedIndex; }
        }

        /// <summary>
        /// Gets or sets the maximum length of a file that should be loaded into the ImageBrowser.
        /// </summary>
        public long MaxFileLength
        {
            get { return m_lMaxFileLength; }
            set
            {
                if ((value >= 0) && (value <= MAX_FILE_LENGTH))
                    m_lMaxFileLength = value;
                else
                    m_lMaxFileLength = MAX_FILE_LENGTH;
            }
        }

        /// <summary>
        /// Gets the currently selected image file path.
        /// </summary>
        public string SelectedFile
        {
            get { return m_sSelectedFilePath; }
        }

        /// <summary>
        /// Gets the currently selected directory path.
        /// </summary>
        public string SelectedDirectory
        {
            get { return m_sSelectedDirectoryPath; }
        }        

        /// <summary>
        /// Get the currently loaded image file path list.
        /// </summary>
        public string[] FilePathList
        {
            get { return (string[])m_sFilePaths.ToArray(); }
        }

        /// <summary>
        /// Gets an array of property items (if any are present) that are assoiciated with the currrently selected image.
        /// </summary>
        public PropertyItem[] PropertyItems
        {
            get { return m_oPropertyItems; }
        }

        /// <summary>
        /// Gets or sets the effect that will be applied to the thumbnail images.
        /// </summary>
        public ThumbnailEffect Effect
        {
            get { return m_nThumbnailEffect; }
            set { m_nThumbnailEffect = value; }
        }

        /// <summary>
        /// Gets or sets the size of the thumbnail image list.
        /// </summary>
        public Size ThumbNailSize
        {
            get { return m_ThumbNailSize; }
            set { m_ThumbNailSize = value; }
        }

        /// <summary>
        /// Gets the properties of the image currently selected.
        /// </summary>
        public ImageProperties ImageInfo
        {
            get { return m_oImageInfo; }
        }

        /// <summary>
        /// Gets the image list containing the thumbnail images.
        /// </summary>
        public ImageList ThumbNailImages
        {
            get { return m_oImageList; }
        }

        /// <summary>
        /// Fires when loading of the image files has started.
        /// </summary>
        public event EventHandler<ImageBrowserEventArgs> LoadStarted;

        /// <summary>
        /// Fires when loading of the images files has finished.
        /// </summary>
        public event EventHandler<ImageBrowserEventArgs> LoadFinished;

        /// <summary>
        /// Fires when an item has been added to the image browser.
        /// </summary>
        public event EventHandler<ImageBrowserItemEventArgs> ItemAdded;

        /// <summary>
        /// Fires when an item has been removed from the image browser.
        /// </summary>
        public event EventHandler<ImageBrowserItemEventArgs> ItemRemoved;

        /// <summary>
        /// Fires when an image file has been renamed.
        /// </summary>
        public event EventHandler<ImageBrowserRenameEventArgs> FileRenamed;

        #endregion

        #region Contructors and destructors

        /// <summary>
        /// Creates a new instance of the ImageBrowser class initialized with default values.
        /// </summary>
        public ImageBrowser()
        {
            m_nMaxFiles = MAX_FILES;
            m_lMaxFileLength = MAX_FILE_LENGTH;
            m_ThumbNailSize = new Size(64, 64);
            m_sFilePaths = new List<string>();
            m_oListViewItems = new List<ListViewItem>();
        }

        /// <summary>
        /// Class destructor.
        /// </summary>
        ~ImageBrowser()
        {
            Dispose(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes a new instance of the image list.
        /// </summary>
        private void InitializeImageList()
        {
            if (m_oImageList != null)
                m_oImageList.Dispose();

            m_oImageList = new ImageList();
            m_oImageList.ColorDepth = ColorDepth.Depth24Bit;
            m_oImageList.ImageSize = m_ThumbNailSize;

            m_bThumbNailsInitialized = true;
        }

        /// <summary>
        /// Loads all of the image files with the specified extensions from the specified directory.
        /// </summary>
        /// <param name="sDirectory">Specifies the directory to load.</param>
        /// <param name="nType">Specifies the image types to load.</param>
        /// <param name="bLoadThumbNails">Specifies whether to load the thumbnail images.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void LoadImageFiles(string sDirectory, ImageFileType nType, bool bLoadThumbNails)
        {
            if (string.IsNullOrEmpty(sDirectory))
                return;

            try
            {
                // Fire the load started event.
                OnLoadStarted(this, new ImageBrowserEventArgs());

                DirectoryInfo oDirectory = new DirectoryInfo(sDirectory);

                if (oDirectory.Exists)
                {
                    // Update the selected directory path.
                    m_sSelectedDirectoryPath = sDirectory;

                    // Initialize the image list if specified.
                    if (bLoadThumbNails)
                        InitializeImageList();

                    bool bBreak = false;
                    string[] sExtensions = FileTools.GetFileExtensions(nType);
                    ImageBrowserItem oItem = new ImageBrowserItem();

                    var allfiles = oDirectory.GetFiles().OrderBy(p=>p.Name);
                    foreach (FileInfo oFile in allfiles)
                    {
                        foreach (string sExtension in sExtensions)
                        {
                            if ((oFile.Length <= m_lMaxFileLength) && (sExtension.Equals(oFile.Extension, StringComparison.OrdinalIgnoreCase)))
                            {
                                oItem.Name = Path.GetFileNameWithoutExtension(oFile.Name);
                                oItem.Path = oFile.FullName;
                                oItem.FileType = FileTools.GetFileExtensionDescription(sExtension);
                                oItem.Created = oFile.CreationTime.ToShortDateString()
                                    + " - " + oFile.CreationTime.ToShortTimeString();
                                oItem.Length = FileTools.ConvertBytes(oFile.Length);

                                // Add the item to the list.
                                Add(oItem, bLoadThumbNails);

                                // Break from the inner loop if the max file count has been reached.
                                if (m_nFileCount >= m_nMaxFiles)
                                {
                                    bBreak = true;
                                    break;
                                }
                            }
                        }

                        // Break from outer loop, if specified.
                        if (bBreak)
                            break;
                    }
                }

                // Fire the load finished event.
                OnLoadFinished(this, new ImageBrowserEventArgs());
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message, e);
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
        }
        
        /// <summary>
        /// Adds a new item to the image browser item collection.
        /// </summary>
        /// <param name="oBrowserItem">Specifies the item to add to the end of the collection.</param>
        /// <param name="bAddThumbNail">Specifies whether to create and add a thumbnail to the image list.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="System.IO.FileNotFoundException"></exception>        
        public void Add(ImageBrowserItem oBrowserItem, bool bAddThumbNail)
        {
            try
            {
                if (oBrowserItem == null)
                    throw new ArgumentNullException("oBrowserItem", "The specified parameter cannot be null.");

                if (m_nFileCount < m_nMaxFiles)
                {
                    string sDimensions = string.Empty;

                    if (bAddThumbNail)
                    {
                        using (Image oImage = Image.FromFile(oBrowserItem.Path))
                        {
                            // Make sure the image list gets initialized.
                            if (!m_bThumbNailsInitialized)
                                InitializeImageList();

                            // Add the thumbnail to the image list.
                            m_oImageList.Images.Add(oBrowserItem.Path, DrawingTools.CreateThumbnail(oImage,
                                m_oImageList.ImageSize, m_bHighQualityThumbnails, m_nThumbnailEffect));

                            // Append tooltip data.
                            sDimensions = "\nDimensions: " + oImage.Width + " x " + oImage.Height + " Pixels";
                        }
                    }

                    // Create a new listview item.
                    ListViewItem oItem = new ListViewItem(oBrowserItem.Name, bAddThumbNail ? m_nFileCount : 0);
                    oItem.Name = oBrowserItem.Path;
                    oItem.ToolTipText = oBrowserItem.Name + "\nType: " + oBrowserItem.FileType
                        + "\nSize: " + oBrowserItem.Length + sDimensions;

                    // Add subitems only if thumbnails are not specified.
                    if (!bAddThumbNail)
                    {
                        oItem.SubItems.AddRange(new string[]
                        {
                            oBrowserItem.Created,
                            oBrowserItem.FileType,
                            oBrowserItem.Length
                        });
                    }

                    // Add the listview item to the list.
                    m_oListViewItems.Add(oItem);

                    // Add the image file path to the file path list.
                    m_sFilePaths.Add(oBrowserItem.Path);

                    // Increase the file counter.
                    ++m_nFileCount;

                    // Fire the item added event.
                    OnItemAdded(this, new ImageBrowserItemEventArgs(m_nFileCount, m_nFileCount - 1, oBrowserItem.Path));
                }
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Error trying to load image. (" + oBrowserItem.Path + ")\n\nThe contents of this file could be damaged or corrupted.", "Load Image Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message, e);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message, e);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.Message, e);
            }
        }

        /// <summary>
        /// Removes an item from the image browser and reorders the selected index and selected path members.
        /// </summary>
        /// <param name="sFilePath"></param>
        public void Remove(string sFilePath)
        {
            int nCount = m_sFilePaths.Count;
            int nIndex = GetIndexFromFilePath(sFilePath);

            if ((nCount > 0) && (nIndex >= 0))
            {
                // Decrement the file counter.
                if (m_nFileCount > 0)
                    --m_nFileCount;

                // Update the selected index member.
                if ((m_nSelectedIndex > 0) && (m_nSelectedIndex == nCount - 1))
                    --m_nSelectedIndex;

                // Update the selected file path member.
                m_sSelectedFilePath = m_sFilePaths[m_nSelectedIndex].ToString();
                
                // Remove the data from the lists.
                m_sFilePaths.RemoveAt(nIndex);
                m_oListViewItems[nIndex].Remove();
                m_oListViewItems.RemoveAt(nIndex);
                    
                // Fire the item removed event.
                OnItemRemoved(this, new ImageBrowserItemEventArgs(m_nFileCount, nIndex, sFilePath));
            }            
        }

        /// <summary>
        /// Clears all the items in the image browser.
        /// </summary>
        public void Clear()
        {
            m_nFileCount = 0;
            m_nSelectedIndex = 0;
            m_sSelectedDirectoryPath = string.Empty;
            m_sSelectedFilePath = string.Empty;
            m_oImageInfo = null;
            m_oPropertyItems = null;

            // Clear the file path list.
            if (m_sFilePaths != null)
                m_sFilePaths.Clear();

            // Clear the list view item list.
            if (m_oListViewItems != null)
                m_oListViewItems.Clear();

            // Clear the image list.
            if (m_oImageList != null)
                m_oImageList.Images.Clear();
        }

        /// <summary>
        /// Deletes the specified file with options to send to the recycle bin and display progress dialog.
        /// This will also call the Remove method if the item exists in the image browser list.
        /// </summary>
        /// <param name="sFilePath">Specifies the path of the file to delete.</param>
        /// <param name="bRecycle">Specifies whether to send the file to the recycle bin or delete permanently.</param>
        /// <param name="bShowProgressDialog">Specifies whether to show the progress dialog.</param>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public void DeleteFile(string sFilePath, bool bRecycle, bool bShowProgressDialog)
        {
            if (string.IsNullOrEmpty(sFilePath))
                return;

            try
            {
                if (File.Exists(sFilePath))
                {
                    // Delete the file.
                    FileSystem.DeleteFile(sFilePath,
                        bShowProgressDialog ? UIOption.AllDialogs : UIOption.OnlyErrorDialogs,
                        bRecycle ? RecycleOption.SendToRecycleBin : RecycleOption.DeletePermanently,
                        UICancelOption.ThrowException);                    
                }

                // Remove the item from the list.
                Remove(sFilePath);
            }
            catch (OperationCanceledException)
            {
                // Let this exception go.
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
        }

        /// <summary>
        /// Allows the user to rename the currently selected file.
        /// </summary>
        /// <param name="sNewName">Specifies a new name for the file.</param>
        /// <exception cref="System.Security.SecurityException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        public void RenameFile(string sNewName)
        {
            // Return if any of the strings are null or empty or contain invalid characters.
            if ((string.IsNullOrEmpty(m_sSelectedFilePath)) ||
                (string.IsNullOrEmpty(sNewName)) ||
                (sNewName.IndexOfAny(Path.GetInvalidPathChars()) != -1))
                return;

            try
            {
                FileInfo oFile = new FileInfo(m_sSelectedFilePath);

                if (oFile.Exists)
                {
                    // Construct the new file path.
                    string sOldPath = m_sSelectedFilePath;
                    string sNewPath = oFile.Directory.FullName + Path.DirectorySeparatorChar + sNewName + oFile.Extension;

                    if (!File.Exists(sNewPath))
                    {
                        // Attempt to move the file.
                        oFile.MoveTo(sNewPath);

                        // Update field members.
                        if (m_sFilePaths.Contains(sOldPath))
                        {
                            int nIndex = m_sFilePaths.IndexOf(sOldPath);
                            string[] sToolTips = m_oListViewItems[nIndex].ToolTipText.Split(new char[] { '\n' });

                            if (sToolTips.Length > 0)
                            {
                                switch (sToolTips.Length)
                                {
                                    case 3:
                                        sToolTips[0] = sNewName + oFile.Extension + "\n";
                                        sToolTips[1] += "\n";
                                        break;
                                    case 4:
                                        sToolTips[0] = sNewName + oFile.Extension + "\n";
                                        sToolTips[1] += "\n";
                                        sToolTips[2] += "\n";
                                        break;
                                }
                            }

                            m_oImageInfo.Name = sNewName + oFile.Extension;
                            m_oImageInfo.Path = sNewPath;
                            m_sSelectedFilePath = sNewPath;
                            m_sFilePaths[nIndex] = sNewPath;
                            m_oListViewItems[nIndex].Text = sNewName;
                            m_oListViewItems[nIndex].Name = sNewPath;
                            m_oListViewItems[nIndex].ToolTipText = string.Concat(sToolTips);

                            // Fire the file rename event.
                            OnFileRenamed(this, new ImageBrowserRenameEventArgs(nIndex, sOldPath, sNewPath));
                        }
                    }
                }
            }
            catch (System.Security.SecurityException e)
            {
                throw new System.Security.SecurityException(e.Message, e);
            }
            catch (UnauthorizedAccessException e)
            {
                throw new UnauthorizedAccessException(e.Message, e);
            }
            catch (IOException e)
            {
                throw new IOException(e.Message, e);
            }
        }

        /// <summary>
        /// Gets the zero based index position of the specified file path within the file path list.
        /// Returns -1 if a match could not be found.
        /// </summary>
        /// <param name="sFilePath">Specifies the file path to search for.</param>
        /// <returns></returns>
        public int GetIndexFromFilePath(string sFilePath)
        {
            if (!string.IsNullOrEmpty(sFilePath))
            {
                if (m_sFilePaths.Contains(sFilePath))
                    return m_sFilePaths.IndexOf(sFilePath);
            }

            return -1;
        }

        /// <summary>
        /// Looks for a file path in the path list. If found and the path points to a file that exists,
        /// the image will be extracted from the file.
        /// </summary>
        /// <param name="nIndex">Specifies the index of the file path in the path list,</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public Image GetImageFromIndex(int nIndex)
        {
            int nPathCount = m_sFilePaths.Count;
            string sFilePath = string.Empty;
            Image oImage = null;

            try
            {
                if ((nPathCount > 0) && (nIndex >= 0) && (nIndex < nPathCount))
                {
                    sFilePath = (string)m_sFilePaths[nIndex];

                    if (string.IsNullOrEmpty(sFilePath))
                        return null;

                    FileInfo oFile = new FileInfo(sFilePath);

                    if (oFile.Exists)
                    {
                        using (Image oImg = Image.FromFile(sFilePath))
                        {
                            FileAttributes nAttributes = oFile.Attributes;
                            
                            // Update the ImageProperties member.
                            m_oImageInfo = new ImageProperties();
                            m_oImageInfo.Archive = Convert.ToBoolean(nAttributes & FileAttributes.Archive);
                            m_oImageInfo.Hidden = Convert.ToBoolean(nAttributes & FileAttributes.Hidden);
                            m_oImageInfo.Normal = Convert.ToBoolean(nAttributes & FileAttributes.Normal);
                            m_oImageInfo.ReadOnly = Convert.ToBoolean(nAttributes & FileAttributes.ReadOnly);
                            m_oImageInfo.System = Convert.ToBoolean(nAttributes & FileAttributes.System);
                            m_oImageInfo.Temporary = Convert.ToBoolean(nAttributes & FileAttributes.Temporary);
                            m_oImageInfo.Frames = oImg.GetFrameCount(new FrameDimension(oImg.FrameDimensionsList[0]));
                            m_oImageInfo.Dimensions = oImg.Size;
                            m_oImageInfo.PixelFormat = oImg.PixelFormat;
                            m_oImageInfo.Size = FileTools.ConvertBytes(oFile.Length);
                            m_oImageInfo.Resolution = new Resolution(oImg.HorizontalResolution, oImg.VerticalResolution);
                            m_oImageInfo.Name = oFile.Name;
                            m_oImageInfo.Path = oFile.FullName;
                            m_oImageInfo.Type = FileTools.GetFileExtensionDescription(oFile.Extension);
                            m_oImageInfo.Accessed = oFile.LastAccessTime.ToShortDateString()
                                + " - " + oFile.LastAccessTime.ToShortTimeString();
                            m_oImageInfo.Modified = oFile.LastWriteTime.ToShortDateString()
                                + " - " + oFile.LastWriteTime.ToShortTimeString();
                            m_oImageInfo.Created = oFile.CreationTime.ToShortDateString()
                                + " - " + oFile.CreationTime.ToShortTimeString();
                            m_oImageInfo.BitDepth = Bitmap.GetPixelFormatSize(oImg.PixelFormat);
                            
                            if (FileTools.IsExifFileType(oFile.Extension))
                            {
                                ExifReader oExifReader = new ExifReader(oImg.PropertyItems);
                                ExifImageProperties oExifInfo = new ExifImageProperties(m_oImageInfo);
                                oExifInfo.Artist = oExifReader.GetExifProperty(PropertyItemID.Artist);
                                oExifInfo.Title = oExifReader.GetExifProperty(PropertyItemID.ImageDescription);
                                oExifInfo.Subject = oExifReader.GetExifProperty(PropertyItemID.XPSubject);
                                oExifInfo.Comment = oExifReader.GetExifProperty(PropertyItemID.XPComment);
                                oExifInfo.CameraMaker = oExifReader.GetExifProperty(PropertyItemID.EquipmentMake);
                                oExifInfo.CameraModel = oExifReader.GetExifProperty(PropertyItemID.EquipmentModel);
                                oExifInfo.Copyright = oExifReader.GetExifProperty(PropertyItemID.Copyright);
                                oExifInfo.ExifVersion = oExifReader.GetExifProperty(PropertyItemID.ExifVersion);
                                oExifInfo.DateTaken = oExifReader.GetExifProperty(PropertyItemID.DateTaken);
                                oExifInfo.DateDigitized = oExifReader.GetExifProperty(PropertyItemID.DateDigitized);
                                oExifInfo.Software = oExifReader.GetExifProperty(PropertyItemID.Software);
                                oExifInfo.YCbCrSubSampling = oExifReader.GetExifProperty(PropertyItemID.YCbCrSubSampling);
                                oExifInfo.YCbCrPositioning = oExifReader.GetExifProperty(PropertyItemID.YCbCrPositioning);
                                oExifInfo.Orientation = oExifReader.GetExifProperty(PropertyItemID.Orientation);
                                oExifInfo.ISOSpeed = oExifReader.GetExifProperty(PropertyItemID.ISOSpeed);
                                oExifInfo.ExposureMode = oExifReader.GetExifProperty(PropertyItemID.ExposureMode);
                                oExifInfo.ExposureProgram = oExifReader.GetExifProperty(PropertyItemID.ExposureProgram);
                                oExifInfo.Flash = oExifReader.GetExifProperty(PropertyItemID.Flash);
                                oExifInfo.MeteringMode = oExifReader.GetExifProperty(PropertyItemID.MeteringMode);
                                oExifInfo.ColourSpace = oExifReader.GetExifProperty(PropertyItemID.ColorSpace);
                                oExifInfo.ResolutionUnit = oExifReader.GetExifProperty(PropertyItemID.ResolutionUnit);
                                oExifInfo.ComponentsConfiguration = oExifReader.GetExifProperty(PropertyItemID.ComponentsConfiguration);
                                oExifInfo.Rating = oExifReader.GetExifProperty(PropertyItemID.Rating);
                                oExifInfo.WhiteBalance = oExifReader.GetExifProperty(PropertyItemID.WhiteBalance);
                                oExifInfo.SceneCaptureType = oExifReader.GetExifProperty(PropertyItemID.SceneCaptureType);
                                oExifInfo.ExposureTime = oExifReader.GetExifProperty(PropertyItemID.ExposureTime);
                                oExifInfo.FNumber = oExifReader.GetExifProperty(PropertyItemID.FNumber);
                                oExifInfo.FocalLength = oExifReader.GetExifProperty(PropertyItemID.FocalLength);
                                oExifInfo.MaxAperture = oExifReader.GetExifProperty(PropertyItemID.MaxAperture);
                                oExifInfo.CompressedBitsPerPixel = oExifReader.GetExifProperty(PropertyItemID.CompressedBitsPerPixel);
                                oExifInfo.ShutterSpeed = oExifReader.GetExifProperty(PropertyItemID.ShutterSpeed);
                                oExifInfo.Compression = oExifReader.GetExifProperty(PropertyItemID.Compression);
                                oExifInfo.PhotometricInterpretation = oExifReader.GetExifProperty(PropertyItemID.PhotometricInterpretation);
                                oExifInfo.LightSource = oExifReader.GetExifProperty(PropertyItemID.LightSource);
                                oExifInfo.Brightness = oExifReader.GetExifProperty(PropertyItemID.BrightnessValue);
                                oExifInfo.Contrast = oExifReader.GetExifProperty(PropertyItemID.Contrast);
                                oExifInfo.Saturation = oExifReader.GetExifProperty(PropertyItemID.Saturation);
                                oExifInfo.Sharpness = oExifReader.GetExifProperty(PropertyItemID.Sharpness);

                                m_oImageInfo = oExifInfo;
                            }

                            // Update field members.
                            m_nSelectedIndex = nIndex;
                            m_sSelectedFilePath = sFilePath;
                            m_oPropertyItems = oImg.PropertyItems;

                            // create a new bitmap from the image.
                            oImage = new Bitmap(oImg, oImg.Size);
                        }
                    }
                    else
                        Remove(sFilePath);
                }
            }
            catch (OutOfMemoryException)
            {
                Remove(sFilePath);

                MessageBox.Show("Error trying to load image. (" + sFilePath + ")\n\nThe contents of this file could be damaged or corrupted.", "Load Image Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message, e);
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

            return oImage;
        }

        /// <summary>
        /// Gets an image from the specified file path, stored in the image browser.
        /// </summary>
        /// <param name="sFilePath">Specifies the file path in the path list.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public Image GetImageFromFilePath(string sFilePath)
        {
            Image oImage = null;

            try
            {
                int nIndex = GetIndexFromFilePath(sFilePath);

                if (nIndex != -1)
                    oImage = GetImageFromIndex(nIndex);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message, e);
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

            return oImage;
        }

        /// <summary>
        /// Navigates the list of files stored in the path list and returns the associated image.
        /// </summary>
        /// <param name="nNavigate">Specifies the direction when navigating the list.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        /// <exception cref="System.UnauthorizedAccessException"></exception>
        /// <exception cref="System.IO.IOException"></exception>
        /// <exception cref="System.Security.SecurityException"></exception>
        public Image NavigateImageList(NavigateList nNavigate)
        {
            Image oImage = null;
            int nIndex = m_nSelectedIndex;

            try
            {
                switch (nNavigate)
                {
                    case NavigateList.Next:
                        oImage = GetImageFromIndex(++nIndex);
                        break;
                    case NavigateList.Previous:
                        oImage = GetImageFromIndex(--nIndex);
                        break;
                    case NavigateList.First:
                        oImage = GetImageFromIndex(0);
                        break;
                    case NavigateList.Last:
                        oImage = GetImageFromIndex(m_nFileCount - 1);
                        break;
                }
            }
            catch (ArgumentNullException e)
            {
                throw new ArgumentNullException(e.Message, e);
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

            return oImage;
        }

        /// <summary>
        /// Gets the list view items which represent the image files located in the
        /// directory currently being viewed.
        /// </summary>
        public ListViewItem[] GetListViewItems()
        {
            return m_oListViewItems.ToArray();
        }

        /// <summary>
        /// Releases all of the resources used by this class.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all of the resources used by this class.
        /// </summary>
        /// <param name="bDispose">Specifies whether to dispose of managed resources.</param>
        protected virtual void Dispose(bool bDispose)
        {
            if (!m_bIsDisposed)
            {
                if (bDispose)
                {
                    // Release managed resource that implement IDisposable.

                    // Clean up the image list.
                    if (m_oImageList != null)
                    {
                        m_oImageList.Dispose();
                        m_oImageList = null;
                    }

                    // Clean up the listview items.
                    if (m_oListViewItems != null)
                    {
                        m_oListViewItems.Clear();
                        m_oListViewItems = null;
                    }
                }

                m_bIsDisposed = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnLoadStarted(object sender, ImageBrowserEventArgs e)
        {
            if (LoadStarted != null)
                LoadStarted(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnLoadFinished(object sender, ImageBrowserEventArgs e)
        {
            if (LoadFinished != null)
                LoadFinished(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnItemAdded(object sender, ImageBrowserItemEventArgs e)
        {
            if (ItemAdded != null)
                ItemAdded(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnItemRemoved(object sender, ImageBrowserItemEventArgs e)
        {
            if (ItemRemoved != null)
                ItemRemoved(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnFileRenamed(object sender, ImageBrowserRenameEventArgs e)
        {
            if (FileRenamed != null)
                FileRenamed(sender, e);
        }

        #endregion
    }
}
