//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ScreenShot.cs
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
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using IView.Engine.Core;
using IView.Engine.Data;
using IView.UI.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides a window that can moved and resized to capture images of the desktop.
    /// </summary>
    public partial class ScreenShot : Form
    {
        #region Fields and properties

        private const int BORDER_WIDTH = 5;
        private const int MAX_FILES = 65535;
        private const int SEG_SMALL = 3;
        private const int SEG_LARGE = 6;
        private const string FILE_NAME_PREFIX = "cimg_";

        private bool m_bShowRuler;
        private bool m_bIsActive;
        private int m_nClickPosX;
        private int m_nClickPosY;
        private Mode m_nMode;
        private RectangleBounds m_nSelectedBounds;
        private StringFormat m_oStringFormat;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ScreenShot class initialized with default values.
        /// </summary>
        public ScreenShot()
        {
            InitializeComponent();

            m_bShowRuler = true;
            m_bIsActive = true;
            m_nMode = Mode.None;
            m_nSelectedBounds = RectangleBounds.None;
            m_oStringFormat = new StringFormat();
            m_oStringFormat.FormatFlags = StringFormatFlags.DirectionVertical;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Copys the contents of the window to the clipboard.
        /// </summary>
        private void CopyToClipboard()
        {
            try
            {
                using (Bitmap oBitmap = new Bitmap(this.Width, this.Height))
                {
                    using (Graphics oGraphics = Graphics.FromImage(oBitmap))
                    {
                        this.Visible = false;
                        oGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
                        this.Visible = true;

                        Clipboard.Clear();
                        Clipboard.SetImage(oBitmap);
                    }
                }
            }
            catch (System.Runtime.InteropServices.ExternalException ex)
            {
                MessageBox.Show("Unable to copy image to the clipboard.\n\nReason: " + ex.Message, "Copy Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Saves the contents of the window to a bitmap file stored in the users documents folder.
        /// </summary>
        private void SaveToFile()
        {
            try
            {
                bool bSave = false;
                string sFilePath = string.Empty;
                string sDirectory = ApplicationData.CapturedImagesFolder + Path.DirectorySeparatorChar;
                DirectoryInfo oDirectory = new DirectoryInfo(sDirectory);

                // Create the directory if it doesn't exist.
                if (!oDirectory.Exists)
                    oDirectory.Create();

                // Generate a file path.
                for (int n = 0; n < MAX_FILES; n++)
                {
                    sFilePath = sDirectory + FILE_NAME_PREFIX + n.ToString("x4") + ".bmp";

                    if (!File.Exists(sFilePath))
                    {
                        bSave = true;
                        break;
                    }
                }

                // If the file path generated was successfull, save the image.
                if (bSave)
                {
                    using (Bitmap oBitmap = new Bitmap(this.Width, this.Height))
                    {
                        using (Graphics oGraphics = Graphics.FromImage(oBitmap))
                        {
                            this.Visible = false;
                            oGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
                            this.Visible = true;

                            using (ImageSaver oImageSaver = new ImageSaver(oBitmap))
                            {
                                oImageSaver.FilePath = sFilePath;
                                oImageSaver.SaveAsBmp(BitDepth.BPP32);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Unable to save the image.\n\nThe maximum file count (" + MAX_FILES + ") has been reached.", "Save Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Unable to save image.\n\nReason: " + e.Message, "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show("Unable to save image.\n\nReason: " + e.Message, "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show("Unable to save image.\n\nReason: " + e.Message, "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException e)
            {
                MessageBox.Show("Unable to save image.\n\nReason: " + e.Message, "Save Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnActivated(EventArgs e)
        {
            m_bIsActive = true;

            // Invalidate the drawing surface.
            this.Invalidate();

            base.OnActivated(e);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnDeactivate(EventArgs e)
        {
            m_bIsActive = false;

            // Invalidate the drawing surface.
            this.Invalidate();

            base.OnDeactivate(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            Rectangle Rect = Screen.GetBounds(Point.Empty);

            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        CopyToClipboard();
                        break;
                    case Keys.S:
                        SaveToFile();
                        break;
                    case Keys.Right:
                        if (this.Right < Rect.Width)
                            ++this.Width;
                        break;
                    case Keys.Left:
                        --this.Width;
                        break;
                    case Keys.Down:
                        if (this.Bottom < Rect.Height)
                            ++this.Height;
                        break;
                    case Keys.Up:
                        --this.Height;
                        break;
                }

                // Invalidate the drawing surface;
                this.Invalidate();

                return;
            }

            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (this.Right < Rect.Width)
                        ++this.Left;
                    break;
                case Keys.Left:
                    if (this.Left > 0)
                        --this.Left;
                    break;
                case Keys.Down:
                    if (this.Bottom < Rect.Height)
                        ++this.Top;
                    break;
                case Keys.Up:
                    if (this.Top > 0)
                        --this.Top;
                    break;
            }

            // Invalidate the drawing surface.
            this.Invalidate();

            base.OnKeyDown(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            Rectangle Rect = Screen.GetBounds(Point.Empty);

            if ((this.Width < Rect.Width) || (this.Height < Rect.Height))
            {
                this.Location = Point.Empty;
                this.Size = Rect.Size;
            }
            else
            {
                this.Location = new Point((Rect.Width >> 1) - 100, (Rect.Height >> 1) - 100);
                this.Size = new Size(200, 200);
            }

            this.Invalidate();

            base.OnMouseDoubleClick(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            m_nClickPosX = e.X;
            m_nClickPosY = e.Y;

            RectangleBounds nBounds;
            Rectangle Rect = new Rectangle(0, 0, this.Width, this.Height);

            if (ScaleHitTestTools.IsPositionInRectangleBounds(Rect, e.X, e.Y, BORDER_WIDTH))
                m_nMode = Mode.Move;
            else if (ScaleHitTestTools.IsPositionOnRectangleBounds(Rect, e.X, e.Y, BORDER_WIDTH, RectangleBounds.Any, out nBounds))
            {
                m_nMode = Mode.Resize;
                m_nSelectedBounds = nBounds;
            }          

            base.OnMouseDown(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            m_nMode = Mode.None;

            base.OnMouseUp(e);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            int nX = e.X;
            int nY = e.Y;
            int nMouseX = Control.MousePosition.X;
            int nMouseY = Control.MousePosition.Y;
            int nPosX = nMouseX - m_nClickPosX;
            int nPosY = nMouseY - m_nClickPosY;
            Rectangle Rect;

            if (m_nMode == Mode.Move)
            {
                if (e.Button != MouseButtons.Left)
                    return;

                Rect = Screen.GetBounds(Point.Empty);

                if (nPosX < 0) nPosX = 0;
                if (nPosY < 0) nPosY = 0;
                if (nPosX + this.Width > Rect.Width) nPosX = Rect.Width - this.Width;
                if (nPosY + this.Height > Rect.Height) nPosY = Rect.Height - this.Height;

                // Set the forms location.
                this.SetDesktopLocation(nPosX, nPosY);
            }
            else if (m_nMode == Mode.Resize)
            {
                if (e.Button != MouseButtons.Left)
                    return;

                switch (m_nSelectedBounds)
                {
                    case RectangleBounds.Left:
                        if (nMouseX < this.Right)
                        {
                            this.Width = this.Right - nMouseX;
                            this.Left = nMouseX;
                        }
                        break;
                    case RectangleBounds.BottomLeft:
                        if (nMouseX < this.Right)
                        {
                            this.Width = this.Right - nMouseX;
                            this.Height = nMouseY - this.Top + 1;
                            this.Left = nMouseX;
                            m_nClickPosY = nY;
                        }
                        break;
                    case RectangleBounds.Bottom:
                        this.Height = nMouseY - this.Top + 1;
                        m_nClickPosY = nY;
                        break;
                    case RectangleBounds.BottomRight:
                        this.Width = nMouseX - this.Left + 1;
                        this.Height = nMouseY - this.Top + 1;
                        m_nClickPosX = nX;
                        m_nClickPosY = nY;
                        break;
                    case RectangleBounds.Right:
                        this.Width = nMouseX - this.Left + 1;
                        m_nClickPosX = nX;
                        break;
                    case RectangleBounds.TopRight:
                        if (nMouseY < this.Bottom)
                        {
                            this.Width = nMouseX - this.Left + 1;
                            this.Height = this.Bottom - nMouseY;
                            this.Top = nMouseY;
                            m_nClickPosX = nX;
                            m_nClickPosY = nY;
                        }
                        break;
                    case RectangleBounds.Top:
                        if (nMouseY < this.Bottom)
                        {
                            this.Height = this.Bottom - nMouseY;
                            this.Top = nMouseY;
                            m_nClickPosY = nY;
                        }
                        break;
                    case RectangleBounds.TopLeft:
                        if ((nMouseX < this.Right) && (nMouseY < this.Bottom))
                        {
                            this.Height = this.Bottom - nMouseY;
                            this.Width = this.Right - nMouseX;
                            this.Top = nMouseY;
                            this.Left = nMouseX;
                            m_nClickPosX = nX;
                            m_nClickPosY = nY;
                        }
                        break;
                }

                // Invalide the drawing surface.
                this.Invalidate();
            }
            else if (m_nMode == Mode.None)
            {
                RectangleBounds nBounds;
                Rect = new Rectangle(0, 0, this.Width, this.Height);

                if (ScaleHitTestTools.IsPositionInRectangleBounds(Rect, e.X, e.Y, BORDER_WIDTH))
                    this.Cursor = Cursors.SizeAll;
                else if (ScaleHitTestTools.IsPositionOnRectangleBounds(Rect, nX, nY, BORDER_WIDTH, RectangleBounds.Any, out nBounds))
                {
                    switch (nBounds)
                    {
                        case RectangleBounds.Left:
                            this.Cursor = Cursors.SizeWE;
                            break;
                        case RectangleBounds.BottomLeft:
                            this.Cursor = Cursors.SizeNESW;
                            break;
                        case RectangleBounds.Bottom:
                            this.Cursor = Cursors.SizeNS;
                            break;
                        case RectangleBounds.BottomRight:
                            this.Cursor = Cursors.SizeNWSE;
                            break;
                        case RectangleBounds.Right:
                            this.Cursor = Cursors.SizeWE;
                            break;
                        case RectangleBounds.TopRight:
                            this.Cursor = Cursors.SizeNESW;
                            break;
                        case RectangleBounds.Top:
                            this.Cursor = Cursors.SizeNS;
                            break;
                        case RectangleBounds.TopLeft:
                            this.Cursor = Cursors.SizeNWSE;
                            break;
                    }
                }
            }

            base.OnMouseMove(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Color Colour = (m_bIsActive) ? Color.Blue : Color.Gray;

            using (SolidBrush oBrush = new SolidBrush(Colour))
            {
                using (Pen oPen = new Pen(oBrush))
                {
                    int nX = (this.Width >> 1) - 1;
                    int nY = (this.Height >> 1) - 1;

                    e.Graphics.DrawLine(oPen, nX, nY - 12, nX, nY + 12);
                    e.Graphics.DrawLine(oPen, nX - 12, nY, nX + 12, nY);
                    e.Graphics.DrawRectangle(oPen, 0, 0, this.Width - 1, this.Height - 1);

                    if (!m_bShowRuler)
                        return;

                    int nXSegment = 0;
                    int nYSegment = 0;
                    string sPixels = string.Empty;
                    Point[] Lines = new Point[2];
                    PointF StringPos = PointF.Empty;
                    SizeF StringSize = SizeF.Empty;

                    for (nX = -1; nX < this.Width; nX += 10)
                    {
                        if (nXSegment == 0)
                        {
                            nXSegment = 4;
                            Lines[0].X = nX;
                            Lines[0].Y = 0;
                            Lines[1].X = nX;
                            Lines[1].Y = SEG_LARGE;

                            if (nX != -1)
                            {
                                sPixels = (nX + 1).ToString();
                                StringSize = e.Graphics.MeasureString(sPixels, this.Font);
                                StringPos.X = nX - ((int)StringSize.Width >> 1);
                                StringPos.Y = SEG_LARGE;
                                e.Graphics.DrawString(sPixels, this.Font, oBrush, StringPos);
                            }
                        }
                        else
                        {
                            --nXSegment;
                            Lines[0].X = nX;
                            Lines[0].Y = 0;
                            Lines[1].X = nX;
                            Lines[1].Y = SEG_SMALL;
                        }

                        e.Graphics.DrawLine(oPen, Lines[0], Lines[1]);
                    }

                    for (nY = -1; nY < this.Height; nY += 10)
                    {
                        if (nYSegment == 0)
                        {
                            nYSegment = 4;
                            Lines[0].X = 0;
                            Lines[0].Y = nY;
                            Lines[1].X = SEG_LARGE;
                            Lines[1].Y = nY;

                            if (nY != -1)
                            {
                                sPixels = (nY + 1).ToString();
                                StringSize = e.Graphics.MeasureString(sPixels, this.Font);
                                StringPos.X = SEG_LARGE;
                                StringPos.Y = nY - ((int)StringSize.Width >> 1);
                                e.Graphics.DrawString(sPixels, this.Font,
                                    oBrush, StringPos, m_oStringFormat);
                            }
                        }
                        else
                        {
                            --nYSegment;
                            Lines[0].X = 0;
                            Lines[0].Y = nY;
                            Lines[1].X = SEG_SMALL;
                            Lines[1].Y = nY;
                        }

                        e.Graphics.DrawLine(oPen, Lines[0], Lines[1]);
                    }
                }
            }

            base.OnPaint(e);
        }

        #endregion

        #region Form context menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_Main_Opening(object sender, CancelEventArgs e)
        {
            tsmi_Ruler.Checked = m_bShowRuler;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Copy_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Save_Click(object sender, EventArgs e)
        {
            SaveToFile();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Ruler_Click(object sender, EventArgs e)
        {
            m_bShowRuler = (!m_bShowRuler);

            // Invalidate the drawing surface.
            this.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_FitToScreen_Click(object sender, EventArgs e)
        {
            Rectangle Rect = Screen.GetBounds(Point.Empty);

            this.Left = 0;
            this.Top = 0;
            this.Width = Rect.Width;
            this.Height = Rect.Height;

            // Invalidate the drawing surface.
            this.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_OpenCaptureFolder_Click(object sender, EventArgs e)
        {
            try
            {
                string sDirectory = ApplicationData.CapturedImagesFolder;

                if (Directory.Exists(sDirectory))
                {
                    using (System.Diagnostics.Process oProcess = new System.Diagnostics.Process())
                    {
                        oProcess.StartInfo.UseShellExecute = true;
                        oProcess.StartInfo.FileName = sDirectory;
                        oProcess.Start();
                    }
                }
                else
                {
                    MessageBox.Show("Unable to locate the specified directory.\n\n" + sDirectory, "Error Starting Process",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show("Unable to start process.\n\nReason: " + ex.Message, "Error Starting Process",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("Unable to start process.\n\nReason: " + ex.Message, "Error Starting Process",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}