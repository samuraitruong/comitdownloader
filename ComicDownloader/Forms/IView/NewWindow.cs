//::///////////////////////////////////////////////////////////////////////////
//:: File Name: NewWindow.cs
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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using IView.Engine.Core;
using IView.UI.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides a new window with the specified image loaded into it.
    /// </summary>
    public partial class NewWindow : Form
    {
        #region Fields and properties

        private ImageScale m_nImageScale;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the NewWindow class initialized with the specified image.
        /// </summary>
        /// <param name="oImage"></param>
        public NewWindow(Image oImage)
        {
            if (oImage != null)
            {
                InitializeComponent();

                // Update field members.
                m_nImageScale = ImageScale.Auto;
                
                // Load the main image;
                imgbx_DisplayImage.ImageBoxImage = new Bitmap(oImage, oImage.Width, oImage.Height);
                imgbx_DisplayImage.ImageBoxVisible = true;

                // Update the dimensions label.
                tssl_Dimensions.Text = oImage.Width + " x " + oImage.Height;                
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Auto scales the main display image.
        /// </summary>
        private void AutoScaleImage()
        {
            switch (m_nImageScale)
            {
                case ImageScale.Auto:
                    ScaleDisplayImage(ImageScale.None);
                    break;
                case ImageScale.None:
                case ImageScale.Custom:
                    ScaleDisplayImage(ImageScale.Auto);
                    break;
            }
        }

        /// <summary>
        /// Sets the scale mode for the main image.
        /// </summary>
        /// <param name="nScale">Specifies the scale type to apply to the image.</param>
        /// <returns></returns>
        private void ScaleDisplayImage(ImageScale nScale)
        {
            if (!imgbx_DisplayImage.IsImageLoaded)
                return;

            bool bAutoScroll = true;
            int nDestWidth = imgbx_DisplayImage.Width - 2;
            int nDestHeight = imgbx_DisplayImage.Height - 2;
            int nImageWidth = imgbx_DisplayImage.ImageBoxImage.Width;
            int nImageHeight = imgbx_DisplayImage.ImageBoxImage.Height;
            Size ImageSize = new Size();
            Point ImagePosition = new Point();

            if (nScale == ImageScale.Auto)
            {
                // Update field members.
                m_nImageScale = ImageScale.Auto;

                if ((nImageWidth >= nDestWidth) || (nImageHeight >= nDestHeight))
                {
                    bAutoScroll = false;

                    // Scale and position the image box rectangle, based on the image size.
                    ImageSize = ScaleHitTestTools.GetRectangleScaled(nImageWidth, nImageHeight,
                        nDestWidth, nDestHeight, true);
                    ImagePosition = ScaleHitTestTools.GetFixedRectangleCenter(ImageSize.Width, ImageSize.Height,
                        nDestWidth, nDestHeight);
                }
                else
                {
                    bAutoScroll = false;

                    // Set the size and position of the image box rectangle, based on the image size.
                    ImageSize = new Size(nImageWidth, nImageHeight);
                    ImagePosition = ScaleHitTestTools.GetFloatingRectangleCenter(ImageSize.Width, ImageSize.Height,
                        nDestWidth, nDestHeight);
                }
            }
            else if (nScale == ImageScale.None)
            {
                bAutoScroll = true;

                // Update field members.
                m_nImageScale = ImageScale.None;

                // Set the size and position of the image box rectangle, based on the image size.
                ImageSize = new Size(nImageWidth, nImageHeight);
                ImagePosition = ScaleHitTestTools.GetFloatingRectangleCenter(ImageSize.Width, ImageSize.Height,
                    nDestWidth, nDestHeight);
            }

            else if (nScale == ImageScale.Custom)
            {
                bAutoScroll = true;

                // Update field members.
                m_nImageScale = ImageScale.Custom;

                // Set the size and position of the image box rectangle, based on the image size.
                ImageSize = imgbx_DisplayImage.ImageBoxSize;
                ImagePosition = ScaleHitTestTools.GetFloatingRectangleCenter(ImageSize.Width, ImageSize.Height,
                    nDestWidth, nDestHeight);
            }

            // Set the auto scroll flag to true and set the image box rectangle.
            imgbx_DisplayImage.AutoScroll = bAutoScroll;
            imgbx_DisplayImage.ImageBoxRectangle = new Rectangle(ImagePosition, ImageSize);

            // Update the zoom drop down box text.
            tsddb_Zoom.Text =
                ScaleHitTestTools.GetScalePercentage(nImageWidth, ImageSize.Width).ToString("N1") + "%";

            // Invalidate the image box.
            imgbx_DisplayImage.Invalidate();
        }

        #endregion

        #region Zoom context menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_Zoom_Opening(object sender, CancelEventArgs e)
        {
            tsmi_zoom_AutoScale.Checked = (m_nImageScale == ImageScale.Auto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_zoom_Generic_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem oItem = sender as ToolStripMenuItem;

            if (oItem != null)
            {
                float fPercent = 0.0f;
                string sPercent = oItem.Text.TrimEnd(new char[] { '%' });

                if (float.TryParse(sPercent, out fPercent))
                {
                    if (imgbx_DisplayImage.IsImageLoaded)
                    {
                        int nImageWidth = imgbx_DisplayImage.ImageBoxImage.Width;
                        int nImageHeight = imgbx_DisplayImage.ImageBoxImage.Height;

                        // Update field members.
                        m_nImageScale = ImageScale.Custom;

                        // Update the image box size property.
                        imgbx_DisplayImage.ImageBoxSize =
                            ScaleHitTestTools.ScaleFromPercentage(nImageWidth, nImageHeight, fPercent);

                        // Scale the image.
                        ScaleDisplayImage(ImageScale.Custom);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_zoom_AutoScale_Click(object sender, EventArgs e)
        {
            AutoScaleImage();
        }

        #endregion

        #region Imagebox context menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_ImageBox_Opening(object sender, CancelEventArgs e)
        {
            tsmi_Copy.Enabled = imgbx_DisplayImage.IsImageLoaded;
            tsmi_AutoScale.Checked = (m_nImageScale == ImageScale.Auto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Copy_Click(object sender, EventArgs e)
        {
            try
            {
                if (imgbx_DisplayImage.IsImageLoaded)
                {
                    Clipboard.Clear();
                    Clipboard.SetImage(imgbx_DisplayImage.ImageBoxImage);
                }
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                MessageBox.Show(this, ApplicationData.ApplicationName + " was unable to copy the data to the clipboard.\n\nReason: " + ex.Message, "Copy Data Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }       
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_AutoScale_Click(object sender, EventArgs e)
        {
            AutoScaleImage();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Imagebox events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_DisplayImage_ImageBoxImageLoaded(object sender, Controls.Library.ImageBoxEventArgs e)
        {
            ScaleDisplayImage(m_nImageScale);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgbx_DisplayImage_SizeChanged(object sender, EventArgs e)
        {
            ScaleDisplayImage(m_nImageScale);
        }

        #endregion
    }
}