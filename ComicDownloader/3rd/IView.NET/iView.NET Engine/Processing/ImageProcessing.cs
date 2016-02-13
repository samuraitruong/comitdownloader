//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageProcessing.cs
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
//:: Copyright © 2010 Stephen Daily
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
using System.Runtime.InteropServices;
using System.Security.Permissions;
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Processing
{
    /// <summary>
    /// Provides properties and methods for a wide range of image filters and adjustments.
    /// </summary>
    public class ImageProcessing : IDisposable
    {
        #region Fields and properties

        private bool m_bIsDisposed;
        Bitmap m_oBitmap;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ImageProcessing class initialized with the specified image object.
        /// </summary>
        /// <param name="oImage"></param>
        public ImageProcessing(Image oImage)
        {
            if (oImage != null)
                m_oBitmap = new Bitmap(oImage, oImage.Size);
            else
                throw new ArgumentNullException("oImage", "The specified parameter cannot be null.");
        }

        #endregion

        #region Destructors

        /// <summary>
        /// Class destructor.
        /// </summary>
        ~ImageProcessing()
        {
            Dispose(false);
        }

        #endregion

        #region Methods

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
                    if (m_oBitmap != null)
                    {
                        m_oBitmap.Dispose();
                        m_oBitmap = null;
                    }
                }
            }

            m_bIsDisposed = true;
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
        /// Gets the current bitmap image being processed.
        /// </summary>
        /// <returns></returns>
        public Bitmap GetProcessedImage()
        {
            return new Bitmap(m_oBitmap, m_oBitmap.Size);
        }

        /// <summary>
        /// 
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void ApplyPhotoCopyFilter()
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            byte nR, nG, nB;
            float fAvarage;

            // Loop through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                nB = nByteArray[n];
                nG = nByteArray[n + 1];
                nR = nByteArray[n + 2];

                fAvarage = ((nB + nG + nR) / 3);

                if (fAvarage > 127.5f)
                {
                    nByteArray[n] = 255;
                    nByteArray[n + 1] = 255;
                    nByteArray[n + 2] = 255;
                }
                else
                {
                    nByteArray[n] = 0;
                    nByteArray[n + 1] = 0;
                    nByteArray[n + 2] = 0;
                }
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void ApplyInvertFilter()
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            byte nR, nG, nB;

            // Loop through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                nB = nByteArray[n];
                nG = nByteArray[n + 1];
                nR = nByteArray[n + 2];

                nByteArray[n] = (byte)(255 - nB);
                nByteArray[n + 1] = (byte)(255 - nG);
                nByteArray[n + 2] = (byte)(255 - nR);
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void ApplyGreyScaleFilter()
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            byte nR, nG, nB, nGrey;

            // loop through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                nB = nByteArray[n];
                nG = nByteArray[n + 1];
                nR = nByteArray[n + 2];
                nGrey = (byte)((nR + nG + nB) / 3);

                nByteArray[n] = nGrey;
                nByteArray[n + 1] = nGrey;
                nByteArray[n + 2] = nGrey;
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void ApplyNoiseFilter(int nAmount)
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            Random oRand = new Random();
            int nR, nG, nB;

            // loop through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                nB = nByteArray[n] + oRand.Next(-nAmount, nAmount + 1);
                nG = nByteArray[n + 1] + oRand.Next(-nAmount, nAmount + 1);
                nR = nByteArray[n + 2] + oRand.Next(-nAmount, nAmount + 1);

                if (nB > 255) nB = 255;
                else if (nB < 0) nB = 0;
                if (nG > 255) nG = 255;
                else if (nG < 0) nG = 0;
                if (nR > 255) nR = 255;
                else if (nR < 0) nR = 0;

                nByteArray[n] = (byte)nB;
                nByteArray[n + 1] = (byte)nG;
                nByteArray[n + 2] = (byte)nR;
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nValue"></param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void AdjustTransparency(byte nValue, byte nThreshold)
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            // loop through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                if (nByteArray[n + 3] >= nThreshold)
                    nByteArray[n + 3] = nValue;
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nFilterColour"></param>
        /// <param name="nMod"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void ApplyColourFilter(FilterColour nFilterColour, byte nMod)
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            int nRed = 0;
            int nGreen = 0;
            int nBlue = 0;

            // Run through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                switch (nFilterColour)
                {
                    case FilterColour.Red:
                        nRed = nByteArray[n + 2] + nMod;
                        if (nRed < 0) nRed = 0;
                        else if (nRed > 255) nRed = 255;
                        nByteArray[n] = 0;
                        nByteArray[n + 1] = 0;
                        nByteArray[n + 2] = (byte)nRed;
                        break;
                    case FilterColour.Green:
                        nGreen = nByteArray[n + 1] + nMod;
                        if (nGreen < 0) nGreen = 0;
                        else if (nGreen > 255) nGreen = 255;
                        nByteArray[n] = 0;
                        nByteArray[n + 1] = (byte)nGreen;
                        nByteArray[n + 2] = 0;
                        break;
                    case FilterColour.Blue:
                        nBlue = nByteArray[n] + nMod;
                        if (nBlue < 0) nBlue = 0;
                        else if (nBlue > 255) nBlue = 255;
                        nByteArray[n] = (byte)nBlue;
                        nByteArray[n + 1] = 0;
                        nByteArray[n + 2] = 0;
                        break;
                }
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void ApplyRotateColourFilter()
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            byte nR, nG, nB;

            // Loop through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                nB = nByteArray[n];
                nG = nByteArray[n + 1];
                nR = nByteArray[n + 2];

                nByteArray[n] = nG;
                nByteArray[n + 1] = nR;
                nByteArray[n + 2] = nB;
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nMod"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void AdjustBrightness(int nMod)
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            byte nR, nG, nB;
            int nRed, nGreen, nBlue;

            // Loop through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                nB = nByteArray[n];
                nG = nByteArray[n + 1];
                nR = nByteArray[n + 2];

                nRed = nR + nMod;
                nGreen = nG + nMod;
                nBlue = nB + nMod;

                if (nRed < 0) nRed = 0;
                else if (nRed > 255) nRed = 255;
                if (nGreen < 0) nGreen = 0;
                else if (nGreen > 255) nGreen = 255;
                if (nBlue < 0) nBlue = 0;
                else if (nBlue > 255) nBlue = 255;

                nByteArray[n] = (byte)nBlue;
                nByteArray[n + 1] = (byte)nGreen;
                nByteArray[n + 2] = (byte)nRed;
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fMod"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void AdjustContrast(float fMod)
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            byte nR, nG, nB;
            float fR, fG, fB;
            float nValue = (100.0f + fMod) / 100.0f;

            // Loop through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                nB = nByteArray[n];
                nG = nByteArray[n + 1];
                nR = nByteArray[n + 2];

                fR = nR / 255.0f;
                fG = nG / 255.0f;
                fB = nB / 255.0f;

                fR -= 0.5f;
                fR *= nValue;
                fR += 0.5f;
                fR *= 255;

                fG -= 0.5f;
                fG *= nValue;
                fG += 0.5f;
                fG *= 255;

                fB -= 0.5f;
                fB *= nValue;
                fB += 0.5f;
                fB *= 255;

                if (fR > 255) fR = 255;
                else if (fR < 0) fR = 0;
                if (fG > 255) fG = 255;
                else if (fG < 0) fG = 0;
                if (fB > 255) fB = 255;
                else if (fB < 0) fB = 0;

                nByteArray[n] = (byte)fB;
                nByteArray[n + 1] = (byte)fG;
                nByteArray[n + 2] = (byte)fR;
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nFilterColour"></param>
        /// <param name="nMod"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void AdjustColour(int nRed, int nGreen, int nBlue)
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            int nR = 0, nG = 0, nB = 0;

            // Run through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                nR = nByteArray[n + 2] + nRed;
                nG = nByteArray[n + 1] + nGreen;
                nB = nByteArray[n] + nBlue;

                if (nR < 0) nR = 0;
                else if (nR > 255) nR = 255;
                if (nG < 0) nG = 0;
                else if (nG > 255) nG = 255;
                if (nB < 0) nB = 0;
                else if (nB > 255) nB = 255;

                nByteArray[n] = (byte)nB;
                nByteArray[n + 1] = (byte)nG;
                nByteArray[n + 2] = (byte)nR;
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fRed"></param>
        /// <param name="fGreen"></param>
        /// <param name="fBlue"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void AdjustGamma(double fRed, double fGreen, double fBlue)
        {
            if (m_oBitmap == null)
                return;

            BitmapData oBmpData = m_oBitmap.LockBits(new Rectangle(Point.Empty, m_oBitmap.Size),
                ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Marshal the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            byte[] bRedGamma = new byte[256];
            byte[] bGreenGamma = new byte[256];
            byte[] bBlueGamma = new byte[256];

            // Create the gamma ramp
            for (int n = 0; n < 256; n++)
            {
                bRedGamma[n] = (byte)Math.Min(255, (int)((255.0
                    * Math.Pow(n / 255.0, 1.0 / fRed)) + 0.5));
                bGreenGamma[n] = (byte)Math.Min(255, (int)((255.0
                    * Math.Pow(n / 255.0, 1.0 / fGreen)) + 0.5));
                bBlueGamma[n] = (byte)Math.Min(255, (int)((255.0
                    * Math.Pow(n / 255.0, 1.0 / fBlue)) + 0.5));
            }

            // Loop through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                nByteArray[n] = bRedGamma[nByteArray[n]];
                nByteArray[n + 1] = bGreenGamma[nByteArray[n + 1]];
                nByteArray[n + 2] = bBlueGamma[nByteArray[n + 2]];
            }

            // Marshal the managed byte array back to an unmanaged byte array.
            Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

            // Unlock the bitmap.
            m_oBitmap.UnlockBits(oBmpData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Rect"></param>
        /// <param name="fRedIntensity"></param>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public void RedEyeCorrection(Rectangle Rect, float fRedIntensity)
        {
            if (m_oBitmap == null)
                return;

            // Make sure we don't run outside of the image.
            if (Rect.X < 0) Rect.X = 0;
            if (Rect.Y < 0) Rect.Y = 0;
            if (Rect.Width > m_oBitmap.Width) Rect.Width = m_oBitmap.Width;
            if (Rect.Height > m_oBitmap.Height) Rect.Height = m_oBitmap.Height;
            if (Rect.Right > m_oBitmap.Width) Rect.X = m_oBitmap.Width - Rect.Width;
            if (Rect.Bottom > m_oBitmap.Height) Rect.Y = m_oBitmap.Height - Rect.Height;

            using (Bitmap oBmpCrop = m_oBitmap.Clone(Rect, m_oBitmap.PixelFormat))
            {
                BitmapData oBmpData = oBmpCrop.LockBits(new Rectangle(Point.Empty, oBmpCrop.Size),
                    ImageLockMode.ReadWrite, m_oBitmap.PixelFormat);

                IntPtr pScanLine = oBmpData.Scan0;
                int nBytes = oBmpData.Stride * oBmpData.Height;
                byte[] nByteArray = new byte[nBytes];

                // Marshal the unmanaged byte array to a managed byte array.
                Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

                byte nR, nG, nB;

                // Enumerate through the byte array.
                for (int n = 0; n < nByteArray.Length; n += 4)
                {
                    nB = nByteArray[n];
                    nG = nByteArray[n + 1];
                    nR = nByteArray[n + 2];

                    float fAvarage = (float)(nG + nB) / 2;
                    float fIntensity = ((float)nR / fAvarage);

                    if (fIntensity > fRedIntensity)
                    {
                        if (fAvarage < 0.0f) fAvarage = 0.0f;
                        if (fAvarage > 255.0f) fAvarage = 255.0f;
                        nByteArray[n + 2] = (byte)fAvarage;
                    }
                }

                // Marshal the managed byte array back to an unmanaged byte array.
                Marshal.Copy(nByteArray, 0, pScanLine, nBytes);

                // Unlock the bitmap.
                oBmpCrop.UnlockBits(oBmpData);

                // Draw the corrected eye onto the main bitmap.
                using (Graphics oGraphics = Graphics.FromImage(m_oBitmap))
                    oGraphics.DrawImage(oBmpCrop, Rect.Location);
            }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct InvertFilterStruct : IProcessingType
    {
        #region Fields and properties

        /// <summary>
        /// Gets an InvertFilterStruct with fields initialized with empty values.
        /// </summary>
        public static readonly InvertFilterStruct Empty;

        /// <summary>
        /// Gets an enum value specifying what type of structure this is.
        /// </summary>
        public ProcessingStructType StructType
        {
            get { return ProcessingStructType.InvertFilter; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct PhotoCopyFilterStruct : IProcessingType
    {
        #region Fields and properties

        /// <summary>
        /// Gets an PhotoCopyFilterStruct with fields initialized with empty values.
        /// </summary>
        public static readonly PhotoCopyFilterStruct Empty;
        
        /// <summary>
        /// Gets an enum value specifying what type of structure this is.
        /// </summary>
        public ProcessingStructType StructType
        {
            get { return ProcessingStructType.PhotoCopyFilter; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct GreyScaleFilterStruct : IProcessingType
    {
        #region Fields and properties

        /// <summary>
        /// Gets an GreyScaleFilterStruct with fields initialized with empty values.
        /// </summary>
        public static readonly GreyScaleFilterStruct Empty;

        /// <summary>
        /// Gets an enum value specifying what type of structure this is.
        /// </summary>
        public ProcessingStructType StructType
        {
            get { return ProcessingStructType.GreyScaleFilter; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct ColourFilterStruct : IProcessingType
    {
        #region Fields and properties

        private byte m_nValue;
        private FilterColour m_nChannel;

        /// <summary>
        /// Gets or sets the modification value property.
        /// </summary>
        public byte Value
        {
            get { return m_nValue; }
            set { m_nValue = value; }
        }

        /// <summary>
        /// Gets or sets the FilterColour property.
        /// </summary>
        public FilterColour Channel
        {
            get { return m_nChannel; }
            set { m_nChannel = value; }
        }

        /// <summary>
        /// Gets an enum value specifying what type of structure this is.
        /// </summary>
        public ProcessingStructType StructType
        {
            get { return ProcessingStructType.ColourFilter; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nValue"></param>
        /// <param name="nChannel"></param>
        public ColourFilterStruct(byte nValue, FilterColour nChannel)
        {
            m_nValue = nValue;
            m_nChannel = nChannel;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct RotateColourFilterStruct : IProcessingType
    {
        #region Fields and properties

        /// <summary>
        /// Gets an RotateColourFilterStruct with fields initialized with empty values.
        /// </summary>
        public static readonly RotateColourFilterStruct Empty;

        /// <summary>
        /// Gets an enum value specifying what type of structure this is.
        /// </summary>
        public ProcessingStructType StructType
        {
            get { return ProcessingStructType.RotateColourFilter; }
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct TransparencyStruct : IProcessingType
    {
        #region Fields and properties

        private byte m_nValue;

        /// <summary>
        /// Gets an TransparencyStruct with fields initialized with empty values.
        /// </summary>
        public static readonly TransparencyStruct Empty;

        /// <summary>
        /// Gets or sets the modification value property.
        /// </summary>
        public byte Value
        {
            get { return m_nValue; }
            set { m_nValue = value; }
        }

        /// <summary>
        /// Gets an enum value specifying what type of structure this is.
        /// </summary>
        public ProcessingStructType StructType
        {
            get { return ProcessingStructType.Transparency; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nValue"></param>
        public TransparencyStruct(byte nValue)
        {
            m_nValue = nValue;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct BrightnessStruct : IProcessingType
    {
        #region Fields and properties

        private int m_nValue;

        /// <summary>
        /// Gets an BrightnessStruct with fields initialized with empty values.
        /// </summary>
        public static readonly BrightnessStruct Empty;

        /// <summary>
        /// Gets or sets the modification value property.
        /// </summary>
        public int Value
        {
            get { return m_nValue; }
            set { m_nValue = value; }
        }

        /// <summary>
        /// Gets an enum value specifying what type of structure this is.
        /// </summary>
        public ProcessingStructType StructType
        {
            get { return ProcessingStructType.Brightness; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nValue"></param>
        public BrightnessStruct(int nValue)
        {
            m_nValue = nValue;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct ContrastStruct : IProcessingType
    {
        #region Fields and properties

        private float m_fValue;

        /// <summary>
        /// Gets an ContrastStruct with fields initialized with empty values.
        /// </summary>
        public static readonly ContrastStruct Empty;

        /// <summary>
        /// Gets or sets the modification value property.
        /// </summary>
        public float Value
        {
            get { return m_fValue; }
            set { m_fValue = value; }
        }

        /// <summary>
        /// Gets an enum value specifying what type of structure this is.
        /// </summary>
        public ProcessingStructType StructType
        {
            get { return ProcessingStructType.Contrast; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fValue"></param>
        public ContrastStruct(float fValue)
        {
            m_fValue = fValue;
        }

        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public struct GammaStruct : IProcessingType
    {
        #region Fields and properties

        private double m_fRed;
        private double m_fGreen;
        private double m_fBlue;

        /// <summary>
        /// Gets an GammaStruct with fields initialized with empty values.
        /// </summary>
        public static readonly GammaStruct Empty;

        /// <summary>
        /// Gets or sets the Red modification value property.
        /// </summary>
        public double Red
        {
            get { return m_fRed; }
            set { m_fRed = value; }
        }

        /// <summary>
        /// Gets or sets the Green modification value property.
        /// </summary>
        public double Green
        {
            get { return m_fGreen; }
            set { m_fGreen = value; }
        }

        /// <summary>
        /// Gets or sets the Blue modification value property.
        /// </summary>
        public double Blue
        {
            get { return m_fBlue; }
            set { m_fBlue = value; }
        }

        /// <summary>
        /// Gets an enum value specifying what type of structure this is.
        /// </summary>
        public ProcessingStructType StructType
        {
            get { return ProcessingStructType.Gamma; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fRed"></param>
        /// <param name="fGreen"></param>
        /// <param name="fBlue"></param>
        public GammaStruct(double fRed, double fGreen, double fBlue)
        {
            m_fRed = fRed;
            m_fGreen = fGreen;
            m_fBlue = fBlue;
        }

        #endregion
    }
}
