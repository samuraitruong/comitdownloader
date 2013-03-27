//::///////////////////////////////////////////////////////////////////////////
//:: File Name: Histogram.cs
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
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows.Forms;
using IView.Controls.Data;
using IView.Engine.Core;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// Provides a control that displays the contents of an image as a histogram.
    /// </summary>
    public partial class Histogram : UserControl
    {
        #region Fields and properties

        private int m_nMaxValue;
        private int[] m_nHistogram;
        private Channels m_nChannel;
        private ToolStripControlHost m_oHost;

        /// <summary>
        /// Gets the currently selected colour channel.
        /// </summary>
        public Channels CurrentChannel
        {
            get { return m_nChannel; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether auto refresh has been enabled.
        /// </summary>
        public bool AutoRefreshEnabled
        {
            get { return ckb_AutoRefresh.Checked; }
            set { ckb_AutoRefresh.Checked = value; }
        }

        /// <summary>
        /// Fires when there has been a change made to the control and an update is required to show the new results.
        /// </summary>
        public event EventHandler<EventArgs> UpdateRequested;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the Histogram class.
        /// </summary>
        public Histogram()
        {
            InitializeComponent();

            m_oHost = new ToolStripControlHost(ckb_AutoRefresh);
            m_oHost.Alignment = ToolStripItemAlignment.Right;
            ts_Main.Items.Add(m_oHost);

            tscbx_Channels.Items.AddRange(Enum.GetNames(typeof(Channels)));
            tscbx_Channels.SelectedIndex = 0;

            pan_Histogram.Cursor =
                Tools.CreateCursor(ComicDownloader.Properties.Resources.HistogramCross);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Processes the specified image and creates a histogram displaying the data.
        /// </summary>
        /// <param name="oBitmap">Specifies the image to process. Specifying null will reset the histogram.</param>
        public void ProcessImage(Bitmap oBitmap)
        {
            if (oBitmap != null)
            {
                m_nHistogram = GetHistogram(ref oBitmap, m_nChannel);
                m_nMaxValue = GetMaxBin();
            }
            else
            {
                m_nHistogram = null;
                m_nMaxValue = 0;
            }

            pan_Histogram.Invalidate();
        }

        /// <summary>
        /// Constructs a histogram from the specified Bitmap object.
        /// </summary>
        /// <param name="oBitmap">Specifies the Bitmap object to create the histogram from.</param>
        /// <param name="nChannel">Specifies the channels or channel to read.</param>
        /// <returns></returns>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        private int[] GetHistogram(ref Bitmap oBitmap, Channels nChannel)
        {
            BitmapData oBmpData = oBitmap.LockBits(new Rectangle(Point.Empty, oBitmap.Size),
                ImageLockMode.ReadOnly, oBitmap.PixelFormat);

            IntPtr pScanLine = oBmpData.Scan0;
            int nBytes = oBmpData.Stride * oBmpData.Height;
            byte[] nByteArray = new byte[nBytes];

            // Copy the unmanaged byte array to a managed byte array.
            Marshal.Copy(pScanLine, nByteArray, 0, nBytes);

            int nValue;
            int[] nHistogram = new int[256];

            // Iterate through the byte array.
            for (int n = 0; n < nByteArray.Length; n += 4)
            {
                nValue = 0;

                switch (nChannel)
                {
                    case Channels.RGB:
                        nValue += nByteArray[n]; // Blue
                        nValue += nByteArray[n + 1]; // Green
                        nValue += nByteArray[n + 2]; // Red
                        nValue = nValue / 3;
                        break;
                    case Channels.Red:
                        nValue += nByteArray[n + 2]; // Red
                        break;
                    case Channels.Green:
                        nValue += nByteArray[n + 1]; // Green
                        break;
                    case Channels.Blue:
                        nValue += nByteArray[n]; // Blue
                        break;
                }

                ++nHistogram[nValue];
            }

            // Unlock the bitmap.
            oBitmap.UnlockBits(oBmpData);

            return nHistogram;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetMaxBin()
        {
            int nMax = -1;

            if (m_nHistogram != null)
            {
                for (int n = 0; n < m_nHistogram.Length; n++)
                {
                    if (m_nHistogram[n] > nMax)
                        nMax = m_nHistogram[n];
                }
            }

            return nMax;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnUpdateRequested(object sender, EventArgs e)
        {
            if (UpdateRequested != null)
                UpdateRequested(sender, e);
        }

        #endregion

        #region Toolstrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tscbx_Channels_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_nChannel = (Channels)tscbx_Channels.SelectedIndex;

            OnUpdateRequested(this, EventArgs.Empty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_Refresh_Click(object sender, EventArgs e)
        {
            OnUpdateRequested(this, EventArgs.Empty);
        }

        #endregion

        #region Histogram panel events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pan_Histogram_Paint(object sender, PaintEventArgs e)
        {
            if (m_nHistogram == null)
                return;

            int nClientWidth = pan_Histogram.Width;
            int nClientHeight = pan_Histogram.Height - 10;
            float fWidth = (float)nClientWidth / m_nHistogram.Length;
            float fHeight = 0.0f;
            Color Colour = Color.LightGray;
            RectangleF Rect = new RectangleF();

            using (SolidBrush oBrush = new SolidBrush(Colour))
            {
                for (int n = 0; n < m_nHistogram.Length; n++)
                {
                    fHeight = (float)nClientHeight * ((float)m_nHistogram[n] / m_nMaxValue);

                    Rect.X = fWidth * n;
                    Rect.Y = nClientHeight - fHeight;
                    Rect.Width = fWidth;
                    Rect.Height = fHeight + 1;

                    // Paint each bin in the histogram.
                    oBrush.Color = Color.LightGray;
                    e.Graphics.FillRectangle(oBrush, Rect);
                }
            }

            switch (m_nChannel)
            {
                case Channels.RGB:
                    Colour = Color.White;
                    break;
                case Channels.Red:
                    Colour = Color.FromArgb(255, 0, 0);
                    break;
                case Channels.Green:
                    Colour = Color.FromArgb(0, 255, 0);
                    break;
                case Channels.Blue:
                    Colour = Color.FromArgb(0, 0, 255);
                    break;
            }

            Rect = new Rectangle(0, nClientHeight + 1, nClientWidth + 1, 10);
            using (LinearGradientBrush oBrush = new LinearGradientBrush(Rect, Color.Black, Colour, LinearGradientMode.Horizontal))
                e.Graphics.FillRectangle(oBrush, Rect);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pan_Histogram_SizeChanged(object sender, EventArgs e)
        {
            pan_Histogram.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pan_Histogram_MouseClick(object sender, MouseEventArgs e)
        {
            if ((m_nHistogram != null) && (m_nHistogram.Length > 0))
            {
                int nWidth = pan_Histogram.Width - 3;
                int nPos = (int)((float)e.X / nWidth * 255);

                if ((nPos >= 0) && (nPos < m_nHistogram.Length))
                {
                    tt_HistogramData.SetToolTip(pan_Histogram,
                        "Level:\t" + nPos +
                        "\nCount:\t" + m_nHistogram[nPos] +
                        "\nPercent:\t" + (100 / (255.0f / nPos)).ToString("N2"));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pan_Histogram_MouseLeave(object sender, EventArgs e)
        {
            tt_HistogramData.SetToolTip(pan_Histogram, string.Empty);
        }

        #endregion
    }
}
