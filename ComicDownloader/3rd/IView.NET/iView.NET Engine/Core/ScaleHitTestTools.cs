//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ScaleHitTestTools.cs
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
using System.Drawing;
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides common tools such as centering, scale and hit detection methods.
    /// </summary>
    public static class ScaleHitTestTools
    {
        #region Methods

        /// <summary>
        /// Returns true if the specified coordinates are within the bounds of the specified rectangle.
        /// </summary>
        /// <param name="nX">Specified X position.</param>
        /// <param name="nY">Specified Y position.</param>
        /// <returns></returns>
        public static bool IsPositionInRectangleBounds(Rectangle Rect, int nX, int nY, int nOffset)
        {
            if ((Rect.Width > 0) & (Rect.Height > 0))
            {
                if ((nX >= Rect.X + nOffset) && (nX <= Rect.Right - nOffset))
                {
                    if ((nY >= Rect.Y + nOffset) && (nY <= Rect.Bottom - nOffset))
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true if the specified coordinates are within the bounds of the specified rectangle.
        /// </summary>
        /// <param name="Position">Specifies the position.</param>
        /// <returns></returns>
        public static bool IsPositionInRectangleBounds(Rectangle Rect, Point Position, int nOffset)
        {
            return IsPositionInRectangleBounds(Rect, Position.X, Position.Y, nOffset);
        }

        /// <summary>
        /// Returns true if the specified coordinates are on the specified bounds of a rectangle.
        /// </summary>
        /// <param name="Rect">Specifies the rectangle to check.</param>
        /// <param name="nX">Specifies the X position.</param>
        /// <param name="nY">Specifies the Y position.</param>
        /// <param name="nBorderWidth">Specifies the width of the rectangle border.</param>
        /// <param name="nBounds">Specifies the bounds to check for.</param>
        /// <returns></returns>
        public static bool IsPositionOnRectangleBounds(Rectangle Rect, int nX, int nY, int nBorderWidth, RectangleBounds nBounds)
        {
            int nWOffset = nBorderWidth;
            int nLOffset = nWOffset + 1;
            int nBottom = Rect.Bottom;
            int nRight = Rect.Right;
            int nRectX = Rect.X;
            int nRectY = Rect.Y;
            int nWidth = Rect.Width;
            int nHeight = Rect.Height;

            if ((nWidth > 0) & (nHeight > 0))
            {
                if (nBounds == RectangleBounds.Top)
                {
                    // Top bounds width check.
                    if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                    {
                        // Top bounds length check.
                        if ((nX >= nRectX + nLOffset) && (nX <= nRight - nLOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.Bottom)
                {
                    // Bottom bounds width check.
                    if ((nY <= nBottom + nWOffset) && (nY >= nBottom - nWOffset))
                    {
                        // Bottom bounds length check.
                        if ((nX >= nRectX + nLOffset) && (nX <= nRight - nLOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.Left)
                {
                    // Left bounds width check.
                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        // Left bounds length check.
                        if ((nY >= nRectY + nLOffset) && (nY <= nBottom - nLOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.Right)
                {
                    // Right bounds width check.
                    if ((nX <= nRight + nWOffset) && (nX >= nRight - nWOffset))
                    {
                        // Right bounds length check.
                        if ((nY >= nRectY + nLOffset) && (nY <= nBottom - nLOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.TopLeft)
                {
                    // Top left bounds width check
                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        // Top left bounds height check
                        if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.TopRight)
                {
                    // Top right bounds width check
                    if ((nX >= nRight - nWOffset) && (nX <= nRight + nWOffset))
                    {
                        // Top right bounds height check.
                        if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.BottomLeft)
                {
                    // Bottom left bounds width check
                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        // bottom left bounds height check.
                        if ((nY >= nBottom - nWOffset) && (nY <= nBottom + nWOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.BottomRight)
                {
                    // Bottom right bounds width check.
                    if ((nX >= nRight - nWOffset) && (nX <= nRight + nWOffset))
                    {
                        // bottom right bounds height check.
                        if ((nY >= nBottom - nWOffset) && (nY <= nBottom + nWOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.Any)
                {
                    // Top bounds width check.
                    if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                    {
                        // Top bounds length check.
                        if ((nX >= nRectX + nLOffset) && (nX <= nRight - nLOffset))
                        {
                            return true;
                        }
                    }

                    // Bottom bounds width check.
                    if ((nY <= nBottom + nWOffset) && (nY >= nBottom - nWOffset))
                    {
                        // Bottom bounds length check.
                        if ((nX >= nRectX + nLOffset) && (nX <= nRight - nLOffset))
                        {
                            return true;
                        }
                    }

                    // Left bounds width check.
                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        // Left bounds length check.
                        if ((nY >= nRectY + nLOffset) && (nY <= nBottom - nLOffset))
                        {
                            return true;
                        }
                    }

                    // Right bounds width check.
                    if ((nX <= nRight + nWOffset) && (nX >= nRight - nWOffset))
                    {
                        // Right bounds length check.
                        if ((nY >= nRectY + nLOffset) && (nY <= nBottom - nLOffset))
                        {
                            return true;
                        }
                    }

                    // Top left bounds width check
                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        // Top left bounds height check
                        if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                        {
                            return true;
                        }
                    }

                    // Top right bounds width check
                    if ((nX >= nRight - nWOffset) && (nX <= nRight + nWOffset))
                    {
                        // Top right bounds height check.
                        if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                        {
                            return true;
                        }
                    }

                    // Bottom left bounds width check
                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        // bottom left bounds height check.
                        if ((nY >= nBottom - nWOffset) && (nY <= nBottom + nWOffset))
                        {
                            return true;
                        }
                    }

                    // Bottom right bounds width check.
                    if ((nX >= nRight - nWOffset) && (nX <= nRight + nWOffset))
                    {
                        // bottom right bounds height check.
                        if ((nY >= nBottom - nWOffset) && (nY <= nBottom + nWOffset))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true if the specified coordinates are on the specified bounds 
        /// of a rectangle. If you are checking for any bounds, the out parameter
        /// can provide the bounds the coordinates are on.
        /// </summary>
        /// <param name="Rect">Specifies the rectangle to check.</param>
        /// <param name="nX">Specifies the X position.</param>
        /// <param name="nY">Specifies the Y position.</param>
        /// <param name="nBorderWidth">Specifies the width of the rectangle border.</param>
        /// <param name="nBounds">Specifies the bounds to check for.</param>
        /// <param name="nOnBounds">Returns the bounds the mouse pointer is on.</param>
        /// <returns></returns>
        public static bool IsPositionOnRectangleBounds(Rectangle Rect, int nX, int nY, int nBorderWidth, RectangleBounds nBounds, out RectangleBounds nOnBounds)
        {
            int nWOffset = nBorderWidth;
            int nLOffset = nWOffset + 1;
            int nBottom = Rect.Bottom;
            int nRight = Rect.Right;
            int nRectX = Rect.X;
            int nRectY = Rect.Y;
            int nWidth = Rect.Width;
            int nHeight = Rect.Height;

            if ((nWidth > 0) & (nHeight > 0))
            {
                if (nBounds == RectangleBounds.Top)
                {
                    if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                    {
                        if ((nX >= nRectX + nLOffset) && (nX <= nRight - nLOffset))
                        {
                            nOnBounds = RectangleBounds.Top;
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.Bottom)
                {
                    if ((nY <= nBottom + nWOffset) && (nY >= nBottom - nWOffset))
                    {
                        if ((nX >= nRectX + nLOffset) && (nX <= nRight - nLOffset))
                        {
                            nOnBounds = RectangleBounds.Bottom;
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.Left)
                {
                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        if ((nY >= nRectY + nLOffset) && (nY <= nBottom - nLOffset))
                        {
                            nOnBounds = RectangleBounds.Left;
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.Right)
                {
                    if ((nX <= nRight + nWOffset) && (nX >= nRight - nWOffset))
                    {
                        if ((nY >= nRectY + nLOffset) && (nY <= nBottom - nLOffset))
                        {
                            nOnBounds = RectangleBounds.Right;
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.TopLeft)
                {
                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                        {
                            nOnBounds = RectangleBounds.TopLeft;
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.TopRight)
                {
                    if ((nX >= nRight - nWOffset) && (nX <= nRight + nWOffset))
                    {
                        if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                        {
                            nOnBounds = RectangleBounds.TopRight;
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.BottomLeft)
                {
                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        if ((nY >= nBottom - nWOffset) && (nY <= nBottom + nWOffset))
                        {
                            nOnBounds = RectangleBounds.BottomLeft;
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.BottomRight)
                {
                    if ((nX >= nRight - nWOffset) && (nX <= nRight + nWOffset))
                    {
                        if ((nY >= nBottom - nWOffset) && (nY <= nBottom + nWOffset))
                        {
                            nOnBounds = RectangleBounds.BottomRight;
                            return true;
                        }
                    }
                }
                else if (nBounds == RectangleBounds.Any)
                {
                    if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                    {
                        if ((nX >= nRectX + nLOffset) && (nX <= nRight - nLOffset))
                        {
                            nOnBounds = RectangleBounds.Top;
                            return true;
                        }
                    }

                    if ((nY <= nBottom + nWOffset) && (nY >= nBottom - nWOffset))
                    {
                        if ((nX >= nRectX + nLOffset) && (nX <= nRight - nLOffset))
                        {
                            nOnBounds = RectangleBounds.Bottom;
                            return true;
                        }
                    }

                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        if ((nY >= nRectY + nLOffset) && (nY <= nBottom - nLOffset))
                        {
                            nOnBounds = RectangleBounds.Left;
                            return true;
                        }
                    }

                    if ((nX <= nRight + nWOffset) && (nX >= nRight - nWOffset))
                    {
                        if ((nY >= nRectY + nLOffset) && (nY <= nBottom - nLOffset))
                        {
                            nOnBounds = RectangleBounds.Right;
                            return true;
                        }
                    }

                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                        {
                            nOnBounds = RectangleBounds.TopLeft;
                            return true;
                        }
                    }

                    if ((nX >= nRight - nWOffset) && (nX <= nRight + nWOffset))
                    {
                        if ((nY >= nRectY - nWOffset) && (nY <= nRectY + nWOffset))
                        {
                            nOnBounds = RectangleBounds.TopRight;
                            return true;
                        }
                    }

                    if ((nX >= nRectX - nWOffset) && (nX <= nRectX + nWOffset))
                    {
                        if ((nY >= nBottom - nWOffset) && (nY <= nBottom + nWOffset))
                        {
                            nOnBounds = RectangleBounds.BottomLeft;
                            return true;
                        }
                    }

                    if ((nX >= nRight - nWOffset) && (nX <= nRight + nWOffset))
                    {
                        if ((nY >= nBottom - nWOffset) && (nY <= nBottom + nWOffset))
                        {
                            nOnBounds = RectangleBounds.BottomRight;
                            return true;
                        }
                    }
                }
            }

            nOnBounds = RectangleBounds.None;

            return false;
        }

        /// <summary>
        /// Calculates the percent of two values. Eg Passing in an images original width and its current width after being scaled.
        /// </summary>
        /// <param name="nOriginalValue">The original value. (The width or height of an image)</param>
        /// <param name="nCurrentValue">The current value. (The width or height of an image)</param>
        /// <returns></returns>
        public static float GetScalePercentage(int nOriginalValue, int nCurrentValue)
        {
            if (nCurrentValue <= nOriginalValue)
                return 100 / ((float)nOriginalValue / (float)nCurrentValue);
            else
                return ((float)nCurrentValue / (float)nOriginalValue) * 100;
        }

        /// <summary>
        /// Returns a new Size structure scaled to the specified percentage floating point value.
        /// </summary>
        /// <param name="nWidth">Specifies the width of the rectangle being scaled.</param>
        /// <param name="nHeight">Specifies the height of the rectangle being scaled.</param>
        /// <param name="fPercent">Specifies the percent to scale to.</param>
        /// <returns></returns>
        public static Size ScaleFromPercentage(int nWidth, int nHeight, float fPercent)
        {
            float fHeight = 0.0f;
            float fWidth = 0.0f;

            if ((nWidth > 0) & (nHeight > 0))
            {
                float fMod = 0.0f;

                if ((fPercent > 0.0) & (fPercent <= 100.0))
                {
                    fMod = (100.0f / fPercent);
                    fWidth = nWidth / fMod;
                    fHeight = nHeight / fMod;
                }
                else
                {
                    fMod = (fPercent / 100.0f);
                    fWidth = nWidth * fMod;
                    fHeight = nHeight * fMod;
                }
            }

            return new Size((int)fWidth, (int)fHeight);
        }

        /// <summary>
        /// Returns a new Size structure scaled to the specified percentage value.
        /// </summary>
        /// <param name="SizeToScale">Specifies the size structure to scale.</param>
        /// <param name="fPercent">Specifies the percent to scale to.</param>
        /// <returns></returns>
        public static Size ScaleFromPercentage(Size SizeToScale, float fPercent)
        {
            return ScaleFromPercentage(SizeToScale.Width, SizeToScale.Height, fPercent);
        }

        /// <summary>
        /// Returns a new size structure from the child ractangle scaled to fit the parent rectangle.
        /// </summary>
        /// <param name="nChildWidth">Specifies the width of the child rectangle inside the parent rectangle.</param>
        /// <param name="nChildHeight">Specifies the height of the child rectangle inside the parent rectangle.</param>
        /// <param name="nParentWidth">Specifies the width of the parent rectangle hosting the child rectangle</param>
        /// <param name="nParentHeight">Specifies the height of the parent rectangle hosting the child rectangle.</param>
        /// <param name="bStretch">Specifies whether to stretch the child rectangle if it's width and height are smaller than it's parent size.</param>
        /// <returns></returns>
        public static Size GetRectangleScaled(int nChildWidth, int nChildHeight, int nParentWidth, int nParentHeight, bool bStretch)
        {
            byte nImageType = 0;
            float fNewWidth = nParentWidth;
            float fNewHeight = nParentHeight;
            float fWidthPercent = (float)nChildWidth / nParentWidth;
            float fHeightPercent = (float)nChildHeight / nParentHeight;

            if (nChildWidth > nChildHeight)
                nImageType = 1;                   // Landscape
            else if (nChildWidth < nChildHeight)
                nImageType = 2;                   // Portrait
            else
                nImageType = 0;                   // Square.

            if (nParentWidth > nParentHeight)
            {
                fNewWidth = nChildWidth / fHeightPercent;
                fNewHeight = nParentHeight;

                if (fNewWidth > nParentWidth)
                {
                    if (nImageType == 1)
                    {
                        fNewHeight = nChildHeight / fWidthPercent;
                        fNewWidth = nParentWidth;

                    }
                    else if (nImageType == 2)
                    {
                        fNewHeight = nChildHeight / fHeightPercent;
                        fNewWidth = nParentWidth;
                    }
                }
            }
            else if (nParentWidth < nParentHeight)
            {
                fNewWidth = nParentWidth;
                fNewHeight = nChildHeight / fWidthPercent;

                if (fNewHeight > nParentHeight)
                {
                    if (nImageType == 1)
                    {
                        fNewHeight = nParentHeight;
                        fNewWidth = nChildWidth / fWidthPercent;

                    }
                    else if (nImageType == 2)
                    {
                        fNewHeight = nParentHeight;
                        fNewWidth = nChildWidth / fHeightPercent;
                    }
                }
            }
            else
            {
                if (nImageType == 1)
                {
                    fNewHeight = nChildHeight / fWidthPercent;
                    fNewWidth = nChildWidth / fWidthPercent;
                }
                else if (nImageType == 2)
                {
                    fNewHeight = nChildHeight / fHeightPercent;
                    fNewWidth = nChildWidth / fHeightPercent;
                }
            }

            if (!bStretch)
            {
                if ((nChildWidth < nParentWidth) & (nChildHeight < nParentHeight))
                {
                    fNewWidth = nChildWidth;
                    fNewHeight = nChildHeight;
                }
            }

            return new Size((int)fNewWidth, (int)fNewHeight);
        }

        /// <summary>
        /// Auto center method. Returns a centering point structure based on the size of a rectangle inside another rectangle.
        /// </summary>
        /// <param name="ChildRect">Specifies the child rectangle inside the parent rectangle.</param>
        /// <param name="ParentRect">Specifies the parent rectangle hosting the child rectangle</param>
        /// <returns></returns>
        public static Point GetRectangleCenter(Rectangle ChildRect, Rectangle ParentRect)
        {
            int nChildWidth = ChildRect.Width;
            int nChildHeight = ChildRect.Height;
            int nParentWidth = ParentRect.Width;
            int nParentHeight = ParentRect.Height;

            if ((nChildWidth < nParentWidth) & (nChildHeight < nParentHeight))
                return GetFloatingRectangleCenter(nChildWidth, nChildHeight,
                    nParentWidth, nParentHeight);
            else
                return GetFixedRectangleCenter(nChildWidth, nChildHeight,
                    nParentWidth, nParentHeight);
        }

        /// <summary>
        /// Auto center method. Returns a centering point structure based on the size of a rectangles dimensions, inside another rectangles dimensions.
        /// </summary>
        /// <param name="nChildWidth">Specifies the width of the child rectangle inside the parent rectangle.</param>
        /// <param name="nChildHeight">Specifies the height of the child rectangle inside the parent rectangle.</param>
        /// <param name="nParentWidth">Specifies the width of the parent rectangle hosting the child rectangle</param>
        /// <param name="nParentHeight">Specifies the height of the parent rectangle hosting the child rectangle.</param>
        /// <returns></returns>
        public static Point GetRectangleCenter(int nChildWidth, int nChildHeight, int nParentWidth, int nParentHeight)
        {
            if ((nChildWidth < nParentWidth) & (nChildHeight < nParentHeight))
                return GetFloatingRectangleCenter(nChildWidth, nChildHeight,
                    nParentWidth, nParentHeight);
            else
                return GetFixedRectangleCenter(nChildWidth, nChildHeight,
                    nParentWidth, nParentHeight);
        }

        /// <summary>
        /// Returns a centering point structure for a fixed rectangle inside another rectangle.
        /// This should be used when the child rectangle is fixed within the parent rectangle.
        /// </summary>
        /// <param name="ChildRect">Specifies the child rectangle inside the parent rectangle.</param>
        /// <param name="ParentRect">Specifies the parent rectangle hosting the child rectangle</param>
        /// <returns></returns>
        public static Point GetFixedRectangleCenter(Rectangle ChildRect, Rectangle ParentRect)
        {
            int nChildWidth = ChildRect.Width;
            int nChildHeight = ChildRect.Height;
            int nParentWidth = ParentRect.Width;
            int nParentHeight = ParentRect.Height;

            return GetFixedRectangleCenter(nChildWidth, nChildHeight, nParentWidth, nParentHeight);
        }

        /// <summary>
        /// Returns a centering point structure for a fixed rectangle inside another rectangle.
        /// This should be used when the child rectangle is fixed within the parent rectangle.
        /// </summary>
        /// <param name="nChildWidth">Specifies the width of the child rectangle inside the parent rectangle.</param>
        /// <param name="nChildHeight">Specifies the height of the child rectangle inside the parent rectangle.</param>
        /// <param name="nParentWidth">Specifies the width of the parent rectangle hosting the child rectangle</param>
        /// <param name="nParentHeight">Specifies the height of the parent rectangle hosting the child rectangle.</param>
        /// <returns></returns>
        public static Point GetFixedRectangleCenter(int nChildWidth, int nChildHeight, int nParentWidth, int nParentHeight)
        {
            int nPosX = 0, nPosY = 0;

            if (nChildWidth < nParentWidth)
                nPosX = (nParentWidth >> 1) - (nChildWidth >> 1);
            else if (nChildHeight < nParentHeight)
                nPosY = (nParentHeight >> 1) - (nChildHeight >> 1);

            return new Point(nPosX, nPosY);
        }

        /// <summary>
        /// Returns a centering point structure for a floating rectangle inside another rectangle.
        /// This should be used when the child rectangle is free floating within the parent rectangle.
        /// </summary>
        /// <param name="ChildRect">Specifies the child rectangle inside the parent rectangle.</param>
        /// <param name="ParentRect">Specifies the parent rectangle hosting the child rectangle</param>
        /// <returns></returns>
        public static Point GetFloatingRectangleCenter(Rectangle ChildRect, Rectangle ParentRect)
        {
            int nChildWidth = ChildRect.Width;
            int nChildHeight = ChildRect.Height;
            int nParentWidth = ParentRect.Width;
            int nParentHeight = ParentRect.Height;

           return GetFloatingRectangleCenter(nChildWidth, nChildHeight, nParentWidth, nParentHeight);
        }

        /// <summary>
        /// Returns a centering point structure for a floating rectangle inside another rectangle.
        /// This should be used when the child rectangle is free floating within the parent rectangle.
        /// </summary>
        /// <param name="nChildWidth">Specifies the width of the child rectangle inside the parent rectangle.</param>
        /// <param name="nChildHeight">Specifies the height of the child rectangle inside the parent rectangle.</param>
        /// <param name="nParentWidth">Specifies the width of the parent rectangle hosting the child rectangle</param>
        /// <param name="nParentHeight">Specifies the height of the parent rectangle hosting the child rectangle.</param>
        /// <returns></returns>
        public static Point GetFloatingRectangleCenter(int nChildWidth, int nChildHeight, int nParentWidth, int nParentHeight)
        {
            int nPosX = 0, nPosY = 0;

            if ((nChildWidth > 0) & (nParentWidth > 0))
            {
                if (nChildWidth <= nParentWidth)
                    nPosX = (nParentWidth >> 1) - (nChildWidth >> 1);
                else
                    nPosX = 0;
            }

            if ((nChildHeight > 0) & (nParentHeight > 0))
            {
                if (nChildHeight <= nParentHeight)
                    nPosY = (nParentHeight >> 1) - (nChildHeight >> 1);
                else
                    nPosY = 0;
            }

            return new Point(nPosX, nPosY);
        }

        #endregion
    }
}
