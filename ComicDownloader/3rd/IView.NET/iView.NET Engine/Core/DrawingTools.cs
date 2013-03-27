//::///////////////////////////////////////////////////////////////////////////
//:: File Name: DrawingTools.cs
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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides common drawing tools such as creating scaled thumbnails.
    /// </summary>
    public static class DrawingTools
    {
        #region Methods

        /// <summary>
        /// Returns a bitmap thumbnail image scaled to fit the specified destination dimensions. 
        /// </summary>
        /// <param name="oImage">Specifies the image to scale.</param>
        /// <param name="nDestWidth">Specifies the destination width.</param>
        /// <param name="nDestHeight">Specifies the destination height.</param>
        /// <param name="bProcess">Specifies whether to apply smoothing when the image is resized.</param>
        /// <param name="bDropShadow">Specifies whether to apply drop shadow to the thumbnail image.</param>
        /// <returns></returns>
        private static Bitmap CreateDropShadowThumbnail(Image oImage, int nDestWidth, int nDestHeight, bool bProcess, bool bDropShadow)
        {
            if (oImage == null)
                return null;

            using (Bitmap oBitmap = new Bitmap(nDestWidth, nDestHeight))
            {
                using (Graphics oGraphics = Graphics.FromImage(oBitmap))
                {
                    int nWidth = (bDropShadow) ? nDestWidth - 3 : nDestWidth;
                    int nHeight = (bDropShadow) ? nDestHeight - 3 : nDestHeight;

                    Size NewSize = ScaleHitTestTools.GetRectangleScaled(
                        oImage.Width, oImage.Height, nWidth, nHeight, false);
                    Point NewPosition = ScaleHitTestTools.GetRectangleCenter(
                        NewSize.Width, NewSize.Height, nWidth, nHeight);
                    Rectangle ImageRect = new Rectangle(NewPosition, NewSize);

                    if ((bDropShadow) && (NewSize.Width > 4) && (NewSize.Height > 4))
                    {
                        using (Bitmap oShadowBmp = new Bitmap(NewSize.Width / 4, NewSize.Height / 4))
                        {
                            using (Graphics oShadowGraphics = Graphics.FromImage(oShadowBmp))
                            {
                                using (SolidBrush oBrush = new SolidBrush(Color.FromArgb(110, 110, 110)))
                                {
                                    NewSize.Width += 3;
                                    NewSize.Height += 3;
                                    oShadowGraphics.FillRectangle(oBrush, 1, 1, oShadowBmp.Width, oShadowBmp.Height);
                                    oGraphics.DrawImage(oShadowBmp, new Rectangle(NewPosition, NewSize));

                                    // Fill the unseen part of the drop shadow with white. Stops transparency issues.
                                    oBrush.Color = Color.White;
                                    oGraphics.FillRectangle(oBrush, ImageRect);

                                    // Apply interpolation options if specified.
                                    if (bProcess)
                                        oGraphics.InterpolationMode = InterpolationMode.High;

                                    // Draw the thumbnail image, with drop shadow.
                                    oGraphics.DrawImage(oImage, ImageRect);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Apply interpolation options if specified.
                        if (bProcess)
                            oGraphics.InterpolationMode = InterpolationMode.High;

                        // Draw the thumbnail image, with no shadow.
                        oGraphics.DrawImage(oImage, ImageRect);
                    }

                    return new Bitmap(oBitmap, nDestWidth, nDestHeight);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oImage"></param>
        /// <param name="nDestWidth"></param>
        /// <param name="nDestHeight"></param>
        /// <returns></returns>
        private static Bitmap CreateSimpleThumbnail(Image oImage, int nDestWidth, int nDestHeight, bool bProcess, bool bFillBackground)
        {
            using (Bitmap oBmp = new Bitmap(nDestWidth, nDestHeight))
            {
                Rectangle Rect = new Rectangle(Point.Empty, oBmp.Size);

                Size NewSize = ScaleHitTestTools.GetRectangleScaled(
                        oImage.Width, oImage.Height, nDestWidth, nDestHeight, false);
                Point NewPosition = ScaleHitTestTools.GetRectangleCenter(
                    NewSize.Width, NewSize.Height, nDestWidth, nDestHeight);

                using (Graphics oGraphics = Graphics.FromImage(oBmp))
                {
                    Rect.Width -= 1;
                    Rect.Height -= 1;

                    if (bFillBackground)
                    {
                        using (LinearGradientBrush oLinearBrush = new LinearGradientBrush(Rect,
                            Color.WhiteSmoke, Color.Gainsboro, LinearGradientMode.Vertical))
                        {
                            oGraphics.FillRectangle(oLinearBrush, Rect);

                            if (bProcess)
                                oGraphics.InterpolationMode = InterpolationMode.High;

                            oGraphics.DrawImage(oImage, new Rectangle(NewPosition, NewSize));
                            oGraphics.DrawRectangle(Pens.DarkGray, Rect);
                        }
                    }
                    else
                    {
                        if (bProcess)
                            oGraphics.InterpolationMode = InterpolationMode.High;

                        oGraphics.DrawImage(oImage, new Rectangle(NewPosition, NewSize));
                        oGraphics.DrawRectangle(Pens.DarkGray, Rect);
                    }
                }

                return new Bitmap(oBmp, oBmp.Size);
            }
        }

        /// <summary>
        /// Creates a bitmap thumbnail image scaled to fit the specified destination dimentions, with options to apply processing and effects.
        /// </summary>
        /// <param name="oImage">Specifies the image to the create the thumbnail image from.</param>
        /// <param name="DestSize">Specifies the destination dimensions to scale the image to.</param>
        /// <param name="bProcess">Specifies whether to apply high quality interpolation.</param>
        /// <param name="nEffect">Specifies whether to apply any effects the thumbnail.</param>
        /// <returns></returns>
        public static Bitmap CreateThumbnail(Image oImage, Size DestSize, bool bProcess, ThumbnailEffect nEffect)
        {
            return CreateThumbnail(oImage, DestSize.Width, DestSize.Height, bProcess, nEffect);
        }

        /// <summary>
        /// Creates a bitmap thumbnail image scaled to fit the specified destination dimentions, with options to apply processing and effects.
        /// </summary>
        /// <param name="oImage">Specifies the image to the create the thumbnail image from.</param>
        /// <param name="nDestWidth">Specifies the destination width to scale the image to.</param>
        /// <param name="nDestHeight">Specifies the destination height to scale the image to.</param>
        /// <param name="bProcess">Specifies whether to apply high quality interpolation.</param>
        /// <param name="nEffect">Specifies whether to apply any effects the thumbnail.</param>
        /// <returns></returns>
        public static Bitmap CreateThumbnail(Image oImage, int nDestWidth, int nDestHeight, bool bProcess, ThumbnailEffect nEffect)
        {
            switch (nEffect)
            {
                case ThumbnailEffect.None:
                    return CreateDropShadowThumbnail(oImage, nDestWidth, nDestHeight, bProcess, false);
                case ThumbnailEffect.DropShadow:
                    return CreateDropShadowThumbnail(oImage, nDestWidth, nDestHeight, bProcess, true);
                case ThumbnailEffect.GradientBackground:
                    return CreateSimpleThumbnail(oImage, nDestWidth, nDestHeight, bProcess, true);
                case ThumbnailEffect.SimpleBorder:
                    return CreateSimpleThumbnail(oImage, nDestWidth, nDestHeight, bProcess, false);
            }

            return null;
        }

        /// <summary>
        /// Creates an icon from the specified image, scaled to fit the specified destination size.
        /// </summary>
        /// <param name="oImage">Specifies the image to create the icon from.</param>
        /// <param name="DestSize">The destination size.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static Icon CreateScaledIconFromImage(Image oImage, Size DestSize)
        {
            return CreateScaledIconFromImage(oImage, DestSize.Width, DestSize.Height);
        }

        /// <summary>
        /// Creates an icon from the specified image, scaled to fit the specified destination dimensions.
        /// </summary>
        /// <param name="oImage">Specifies the image to create the icon from.</param>
        /// <param name="nDestWidth">The destination width.</param>
        /// <param name="nDestHeight">The destination height.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public static Icon CreateScaledIconFromImage(Image oImage, int nDestWidth, int nDestHeight)
        {
            if (oImage != null)
            {
                Size IconSize = ScaleHitTestTools.GetRectangleScaled(
                        oImage.Width, oImage.Height, nDestWidth, nDestHeight, false);

                Point IconPosition = ScaleHitTestTools.GetRectangleCenter(
                    IconSize.Width, IconSize.Height, nDestWidth, nDestHeight);

                using (Bitmap oBmp = new Bitmap(nDestWidth, nDestHeight))
                {
                    using (Graphics oGraphics = Graphics.FromImage(oBmp))
                    {
                        oGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        oGraphics.DrawImage(oImage, new Rectangle(IconPosition, IconSize));
                    }

                    return Icon.FromHandle(oBmp.GetHicon());
                }
            }

            return null;
        }

        /// <summary>
        /// Creates a new 16x16 bitmap that has the specified background colour.
        /// </summary>
        /// <param name="BackColour">Specifies the background colour for the bitmap.</param>
        /// <returns></returns>
        public static Bitmap CreateEyeDropperBitmap(Color BackColour)
        {
            using (Bitmap oBmp = new Bitmap(16, 16))
            {
                Rectangle Rect = new Rectangle(Point.Empty, oBmp.Size - new Size(1, 1));

                using (Graphics oGraphics = Graphics.FromImage(oBmp))
                {
                    using (SolidBrush oBrush = new SolidBrush(BackColour))
                    {
                        oGraphics.FillRectangle(oBrush, Rect);
                        oGraphics.DrawRectangle(Pens.Black, Rect);
                    }
                }

                return new Bitmap(oBmp, oBmp.Size);
            }
        }

        /// <summary>
        /// Resizes the specified image with the specified interpolation quality and returns a new bitmap.
        /// </summary>
        /// <param name="oImage">Specifies the image to resize.</param>
        /// <param name="NewSize">Specifies the new size for the image.</param>
        /// <param name="nQuality">Specifies the quality when resizing.</param>
        /// <returns></returns>
        public static Bitmap ResizeImage(Image oImage, Size NewSize, InterpolationMode nQuality)
        {
            if (oImage == null)
                return null;

            if (NewSize.IsEmpty)
                return null;
            
            // Resize the image with the specified interpolation quality and return a new bitmap.
            using (Bitmap oBmp = new Bitmap(NewSize.Width, NewSize.Height))
            {
                using (Graphics o = Graphics.FromImage(oBmp))
                {
                    o.InterpolationMode = nQuality;
                    o.DrawImage(oImage, new Rectangle(0, 0, oBmp.Width, oBmp.Height));
                }

                return new Bitmap(oBmp, oBmp.Size);
            }
        }

        /// <summary>
        /// Returns a Color structure of the specified pixel coordinates within the specified bitmap.
        /// This method is not accurate as scaling is perfomed to help with performance when getting
        /// a pixel colour from an image that has been scaled up.
        /// </summary>
        /// <param name="oBitmap">Specifies the bitmap to get the pixel colour from.</param>
        /// <param name="ContainerSize">Specifies the size of the bitmaps container or current size when scaled.</param>
        /// <param name="nX">Specifies the X coordinates within the bitmap.</param>
        /// <param name="nY">Specifies the Y coordinates within the bitmap.</param>
        /// <returns></returns>
        public static Color GetColourFromPixel(Bitmap oBitmap, Size ContainerSize, int nX, int nY)
        {
            if (oBitmap == null)
                return Color.Empty;

            if (ContainerSize.IsEmpty)
                return Color.Empty;

            int nImageWidth = oBitmap.Width;
            int nImageHeight = oBitmap.Height;
            int nBoxWidth = ContainerSize.Width;
            int nBoxHeight = ContainerSize.Height;

            // Translate the current x position.
            float fXPercent = 100 / ((float)nBoxWidth / (float)nX);
            float fX = (fXPercent / 100) * nImageWidth;

            // Translate the current y position.
            float fYPercent = 100 / ((float)nBoxHeight / (float)nY);
            float fY = (fYPercent / 100) * nImageHeight;

            nX = (int)fX;
            nY = (int)fY;

            if (nX < 0) nX = 0;
            if (nY < 0) nY = 0;
            if (nX > nImageWidth) nX = nImageWidth;
            if (nY > nImageHeight) nY = nImageHeight;

            return oBitmap.GetPixel(nX, nY);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oImage"></param>
        /// <param name="fRotateAngle"></param>
        /// <returns></returns>
        public static Bitmap RotateImage(Image oImage, float fRotateAngle)
        {
            if (oImage == null)
                return null;

            using (Bitmap oBitmap = new Bitmap(oImage.Width, oImage.Height))
            {
                using (Graphics oGraphics = Graphics.FromImage(oBitmap))
                {
                    oGraphics.TranslateTransform((float)(oImage.Width >> 1), (float)(oImage.Height >> 1));
                    oGraphics.RotateTransform(fRotateAngle);
                    oGraphics.TranslateTransform(-(float)(oImage.Width >> 1), -(float)(oImage.Height >> 1));
                    oGraphics.DrawImage(oImage, Point.Empty);
                }

                return new Bitmap(oBitmap, oBitmap.Size);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oImage"></param>
        /// <param name="nRotateFlipType"></param>
        /// <returns></returns>
        public static Bitmap RotateImage(Image oImage, RotateFlipType nRotateFlipType)
        {
            if (oImage == null)
                return null;

            using (Bitmap oBitmap = new Bitmap(oImage, oImage.Size))
            {
                oBitmap.RotateFlip(nRotateFlipType);

                return new Bitmap(oBitmap, oBitmap.Size);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sText"></param>
        /// <param name="oFont"></param>
        /// <param name="BackColour"></param>
        /// <param name="ForeColour"></param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static Bitmap CreateTextBitmap(string sText, Font oFont, Color BackColour, Color ForeColour)
        {
            if (string.IsNullOrEmpty(sText))
                throw new ArgumentException("The Specified string parameter cannot be null, empty or just white space.", "sText");

            if (oFont == null)
                throw new ArgumentException("The Specified Font parameter cannot be null.", "oFont");

            Size TextSize = System.Windows.Forms.TextRenderer.MeasureText(sText, oFont);

            using (Bitmap oBmp = new Bitmap(TextSize.Width, TextSize.Height))
            {
                using (SolidBrush oBrush = new SolidBrush(BackColour))
                {
                    using (Graphics oGraphics = Graphics.FromImage(oBmp))
                    {
                        oGraphics.FillRectangle(oBrush, new Rectangle(Point.Empty, TextSize));
                        oBrush.Color = ForeColour;
                        oGraphics.DrawString(sText, oFont, oBrush, PointF.Empty);
                    }
                }

                return new Bitmap(oBmp, oBmp.Size);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oImage"></param>
        /// <param name="nShearType"></param>
        /// <param name="BackColour"></param>
        /// <param name="nAmount"></param>
        /// <param name="bResize"></param>
        /// <returns></returns>
        public static Bitmap ShearImage(Image oImage, ShearType nShearType, Color BackColour, int nAmount, bool bResize)
        {
            if (oImage == null)
                return null;

            int nW = oImage.Width;
            int nH = oImage.Height;
            Point[] Points = new Point[3];

            Points[0] = new Point((nShearType == ShearType.Horizontal) ? ((nAmount >= 0) ? nAmount : 0) : 0,
                (nShearType == ShearType.Vertical) ? ((nAmount < 0) ? Math.Abs(nAmount) : 0) : 0);
            Points[1] = new Point((nShearType == ShearType.Horizontal) ? ((nAmount >= 0) ? nW + nAmount : nW) : nW,
                (nShearType == ShearType.Vertical) ? ((nAmount >= 0) ? nAmount : 0) : 0);
            Points[2] = new Point((nShearType == ShearType.Horizontal) ? ((nAmount < 0) ? Math.Abs(nAmount) : 0) : 0,
                (nShearType == ShearType.Vertical) ? ((nAmount < 0) ? nH + Math.Abs(nAmount) : nH) : nH);

            nW = bResize ? ((nShearType == ShearType.Horizontal) ? nW + Math.Abs(nAmount) : nW) : nW;
            nH = bResize ? ((nShearType == ShearType.Vertical) ? nH + Math.Abs(nAmount) : nH) : nH;
            
            using (Bitmap oBitmap = new Bitmap(nW, nH))
            {
                using (Graphics oGraphics = Graphics.FromImage(oBitmap))
                {
                    using (SolidBrush oBrush = new SolidBrush(BackColour))
                        oGraphics.FillRectangle(oBrush, new Rectangle(Point.Empty, oBitmap.Size));

                    oGraphics.SmoothingMode = SmoothingMode.AntiAlias;
                    oGraphics.CompositingQuality = CompositingQuality.HighQuality;
                    oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    oGraphics.DrawImage(oImage, Points);
                }

                return new Bitmap(oBitmap, oBitmap.Size);
            }
        }

        #endregion
    }
}
