//::///////////////////////////////////////////////////////////////////////////
//:: File Name: SlideShow.cs
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
//:: Created On: 8 April 2011
//:: Copyright © 2011 Stephen Daily
//::///////////////////////////////////////////////////////////////////////////
//:: Pre Processor Directives
//::///////////////////////////////////////////////////////////////////////////
#define DEBUG
#define DEVELOPER_VERSION
#define END_USER_VERSION
//::///////////////////////////////////////////////////////////////////////////
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System; using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using IView.Engine.Core;
using IView.Engine.Data;
using IView.UI.Data;
using ComicDownloader.Properties;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Providies a window that can display images as a slide show.
    /// </summary>
    public partial class SlideShow : Form
    {
        #region Fields and properties

        private const int MOUSE_WAIT_HIDE = 1500;

        private bool m_bPathsValidated = false;
        private bool m_bHoldContextMenuOpen = false;
        private bool m_bCursorHidden = false;
        private bool m_bFadeIn = true;
        private int m_nIndex = 0;
        private int m_nSpinWait = 0;
        private int m_WaitInterval = 2;
        private int m_nMouseWaitHide = MOUSE_WAIT_HIDE;
        private float m_fFadeSpeed = 0.005F;
        private Point m_LastMousePosition = Point.Empty;
        private static TransitionMode m_nTransitionMode = TransitionMode.Normal;
        private Cursor m_oBlankCursor = Tools.CreateCursor(ComicDownloader.Properties.Resources.BlankCursor);
        private SlideShowWindow m_oImageForm;
        private List<string> m_sFilePaths;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the SlideShow class initialized with default values.
        /// </summary>
        public SlideShow()
        {
            InitializeComponent();
            InitializeChildForm();

            m_sFilePaths = new List<string>();
        }

        /// <summary>
        /// Creates a new instance of the SlideShow class and loads the specified slide show file.
        /// </summary>
        /// <param name="sFilePath">Specifies the full path of the slide show file to load.</param>
        public SlideShow(string sFilePath)
        {
            InitializeComponent();
            InitializeChildForm();

            if (Directory.Exists(sFilePath))
            {
                m_sFilePaths = new List<string>();

                DirectoryInfo di= new DirectoryInfo(sFilePath);
                string[] extensions = new[] { ".jpg", ".tiff", ".bmp" };

                FileInfo[] files =
                    di.GetFiles()
                         .Where(f => extensions.Contains(f.Extension.ToLower()))
                         .ToArray();

                //var files = di.GetFiles("*.jpg;*.png");
                if(files!=null)
                foreach (var fi in files)
                {
                    m_sFilePaths.Add(fi.FullName);
                }

            }
            else
            {
                LoadSlideShowFile(sFilePath);
            }
        }

        /// <summary>
        /// Creates a new instance of the FormSlideShow class initialized with the specified file paths.
        /// </summary>
        /// <param name="sFilePaths">Specifies an array of image file paths to display in the slide show.</param>
        public SlideShow(string[] sFilePaths)
        {
            InitializeComponent();
            InitializeChildForm();

            m_sFilePaths = new List<string>(sFilePaths);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a new Bitmap object from the specified file path.
        /// This method validates the file path, any errors raised will return a null Bitmap object.
        /// </summary>
        /// <param name="sPath">Specifies the path of the file.</param>
        /// <returns></returns>
        private Bitmap GetImage(string sPath)
        {
            try
            {
                if (File.Exists(sPath))
                {
                    using (Image oImage = Image.FromFile(sPath))
                        return new Bitmap(oImage, oImage.Size);
                }
            }
            catch (OutOfMemoryException)
            {
                // Log error.
            }
            catch (FileNotFoundException)
            {
                // Log error.
            }
            catch (ArgumentException)
            {
                // Log error.
            }

            return null;
        }

        /// <summary>
        /// Initializes the child form that will be holding currently viewed image.
        /// </summary>
        private void InitializeChildForm()
        {
            m_oImageForm = new SlideShowWindow();
            m_oImageForm.BackColor = this.BackColor;
            m_oImageForm.BackgroundImageLayout = ImageLayout.Stretch;
            m_oImageForm.FormBorderStyle = FormBorderStyle.None;
            m_oImageForm.MinimizeBox = false;
            m_oImageForm.MaximizeBox = false;
            m_oImageForm.Opacity = 0.0f;
            m_oImageForm.ShowIcon = false;
            m_oImageForm.ShowInTaskbar = false;
            m_oImageForm.StartPosition = FormStartPosition.Manual;
            m_oImageForm.MouseClick += delegate(object sender, MouseEventArgs e)
            {
                ShowCursor(true);

                ManageContextMenuOnMouseClick(e);
            };
            m_oImageForm.MouseMove += delegate(object sender, MouseEventArgs e)
            {
                ShowCursor(false);
            };
            m_oImageForm.Show(this);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ValidatePathList()
        {
            if ((!m_bPathsValidated) && (m_sFilePaths != null) && (m_sFilePaths.Count > 0))
            {
                for (int n = 0; n < m_sFilePaths.Count; n++)
                {
                    if ((string.IsNullOrEmpty(m_sFilePaths[n])) ||
                        (!FileTools.IsFileExtensionValid(Path.GetExtension(m_sFilePaths[n]))))
                    {
                        m_sFilePaths.RemoveAt(n);
                    }
                }

                m_bPathsValidated = true;
            }
        }

        /// <summary>
        /// Manages the context menustrip when the user clicks either the main slide show form
        /// or the child form. This is essential as hiding and showing the child form causes focus
        /// to be lost closing the context menustrip. Bugs :/
        /// </summary>
        /// <param name="e"></param>
        private void ManageContextMenuOnMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_bHoldContextMenuOpen = true;
                cms_Options.Show(MousePosition);
            }
            else
            {
                m_bHoldContextMenuOpen = false;
                cms_Options.Visible = false;
            }
        }

        /// <summary>
        /// Starts or stops the slide show. This method also calls ScreenPathList().
        /// </summary>
        private void StartStop()
        {
            // Make sure only valid paths are contained in the list.
            ValidatePathList();

            if (!tim_SlideShowTimer.Enabled)
                tim_SlideShowTimer.Start();
            else
                tim_SlideShowTimer.Stop();
        }

        /// <summary>
        /// Loads the next image in the list.
        /// </summary>
        /// <param name="bHideWindow">Specifies whether to hide the child window when loading a new image.</param>
        private void LoadNextImage(bool bHideWindow)
        {
            if ((m_sFilePaths == null) || (m_sFilePaths.Count == 0))
                return;

            Image oImage = null;

            if (bHideWindow)
                m_oImageForm.Visible = false;

            if (m_nIndex < m_sFilePaths.Count - 1)
            {
                oImage = GetImage(m_sFilePaths[++m_nIndex]);

                if (oImage == null)
                {
                    // Remove the item from the list.
                    m_sFilePaths.RemoveAt(m_nIndex);

                    // Provide a no preview image.
                    oImage = DrawingTools.CreateTextBitmap("No preview available.",
                        this.Font, Color.Black, Color.White);
                }

                // Load the image to the child form.
                m_oImageForm.BackgroundImage = oImage;
            }
            else
            {
                oImage = GetImage(m_sFilePaths[m_nIndex = 0]);

                if (oImage == null)
                {
                    // Remove the item from the list.
                    m_sFilePaths.RemoveAt(m_nIndex);

                    // Provide a no preview image.
                    oImage = DrawingTools.CreateTextBitmap("No preview available.",
                        this.Font, Color.Black, Color.White);
                }

                // Load the image to the child form.
                m_oImageForm.BackgroundImage = oImage;
            }

            AdjustForm();

            if (bHideWindow)
                m_oImageForm.Visible = true;
        }

        /// <summary>
        /// Loads the previous image in the list.
        /// </summary>
        /// <param name="bHideWindow">Specifies whether to hide the child window when loading a new image.</param>
        private void LoadPreviousImage(bool bHideWindow)
        {
            if ((m_sFilePaths == null) || (m_sFilePaths.Count == 0))
                return;

            Image oImage = null;

            if (bHideWindow)
                m_oImageForm.Visible = false;

            if (m_nIndex > 0)
            {
                oImage = GetImage(m_sFilePaths[--m_nIndex]);

                if (oImage == null)
                {
                    // Remove the item from the list.
                    m_sFilePaths.RemoveAt(m_nIndex);

                    // Provide a no preview image.
                    oImage = DrawingTools.CreateTextBitmap("No preview available.",
                        this.Font, Color.Black, Color.White);
                }

                // Load the image to the child form.
                m_oImageForm.BackgroundImage = oImage;
            }
            else
            {
                oImage = GetImage(m_sFilePaths[m_nIndex = m_sFilePaths.Count - 1]);

                if (oImage == null)
                {
                    // Remove the item from the list.
                    m_sFilePaths.RemoveAt(m_nIndex);

                    // Provide a no preview image.
                    oImage = DrawingTools.CreateTextBitmap("No preview available.",
                        this.Font, Color.Black, Color.White);
                }

                // Load the image to the child form.
                m_oImageForm.BackgroundImage = oImage;
            }

            AdjustForm();

            if (bHideWindow)
                m_oImageForm.Visible = true;
        }

        /// <summary>
        /// Loads a slide show file from the specified file path.
        /// </summary>
        /// <param name="sFilePath">Specifies the full path of the slide show file.</param>
        private void LoadSlideShowFile(string sFilePath)
        {
            if ((!string.IsNullOrEmpty(sFilePath)) && (File.Exists(sFilePath)))
            {
                try
                {
                    SlideShowDocument oDoc = new SlideShowDocument();
                    oDoc.Load(sFilePath);

                    m_WaitInterval = oDoc.WaitInterval;
                    m_nTransitionMode = oDoc.TransitionMode;
                    m_fFadeSpeed = oDoc.FadeSpeed;
                    m_sFilePaths = new List<string>(oDoc.GetEntries());
                }
                catch (FileFormatException e)
                {
                    MessageBox.Show("Unable to load the specified slide show file.\n\nReason: " + e.Message, "Load File Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show("Unable to load the specified slide show file.\n\nReason: " + e.Message, "Load File Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (System.Security.SecurityException e)
                {
                    MessageBox.Show("Unable to load the specified slide show file.\n\nReason: " + e.Message, "Load File Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException e)
                {
                    MessageBox.Show("Unable to load the specified slide show file.\n\nReason: " + e.Message, "Load File Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Scales and positions the child form that holds the current image to fit the desktop bounds.
        /// </summary>
        private void AdjustForm()
        {
            if (m_oImageForm.BackgroundImage == null)
                return;

            Rectangle Rect = Screen.GetBounds(Point.Empty);

            int nDestWidth = Rect.Width;
            int nDestHeight = Rect.Height;
            int nImageWidth = m_oImageForm.BackgroundImage.Width;
            int nImageHeight = m_oImageForm.BackgroundImage.Height;
            
            if ((nImageWidth >= nDestWidth) || (nImageHeight >= nDestHeight))
            {
                Rect.Size = ScaleHitTestTools.GetRectangleScaled(nImageWidth, nImageHeight,
                    nDestWidth, nDestHeight, false);
                Rect.Location = ScaleHitTestTools.GetFixedRectangleCenter(Rect.Width, Rect.Height,
                    nDestWidth, nDestHeight);
            }
            else
            {
                Rect.Size = new Size(nImageWidth, nImageHeight);
                Rect.Location = ScaleHitTestTools.GetFloatingRectangleCenter(Rect.Width, Rect.Height,
                    nDestWidth, nDestHeight);
            }

            m_oImageForm.SetDesktopBounds(Rect.X, Rect.Y, Rect.Width, Rect.Height);
        }

        /// <summary>
        /// Shows the cursor if it's currently hidden and has moved from the last place it was hidden.
        /// </summary>
        /// <param name="bOverride">Specifies whether to override the condition checking when showing the cursor.</param>
        private void ShowCursor(bool bOverride)
        {
            if (bOverride)
            {
                m_bCursorHidden = false;
                m_oImageForm.Cursor = Cursors.Default;
                this.Cursor = Cursors.Default;
            }
            else
            {
                if ((m_bCursorHidden) && (!m_LastMousePosition.Equals(MousePosition)))
                {
                    m_bCursorHidden = false;
                    m_oImageForm.Cursor = Cursors.Default;
                    this.Cursor = Cursors.Default;
                }
            }

            m_nMouseWaitHide = MOUSE_WAIT_HIDE;
        }

        /// <summary>
        /// 
        /// </summary>
        private void NormalTransition()
        {
            if (m_oImageForm.Opacity != 1.00F)
                m_oImageForm.Opacity = 1.00F;

            LoadNextImage(true);

            m_nSpinWait = (100 * m_WaitInterval) * tim_SlideShowTimer.Interval;
        }

        /// <summary>
        /// 
        /// </summary>
        private void FadeTransition()
        {
            if (m_bFadeIn)
            {
                if (m_oImageForm.Opacity < 1.00F)
                    m_oImageForm.Opacity += m_fFadeSpeed;
                else
                {
                    m_bFadeIn = false;
                    m_nSpinWait = (100 * m_WaitInterval) * tim_SlideShowTimer.Interval;
                }
            }
            else
            {
                if (m_oImageForm.Opacity > 0.00F)
                    m_oImageForm.Opacity -= m_fFadeSpeed;
                else
                {
                    m_bFadeIn = true;
                    m_nSpinWait = 500;

                    LoadNextImage((m_nTransitionMode == TransitionMode.Normal));
                }
            }
        }

        #endregion

        #region Timer events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tim_SlideShowTimer_Tick(object sender, EventArgs e)
        {
            
            // Hide the cursor if the context menu is hidden, the cursor is visible
            // and when the mouse hide wait counter has reached 0.
            if ((!cms_Options.Visible) && (!m_bCursorHidden))
            {
                if ((m_nMouseWaitHide -= tim_SlideShowTimer.Interval) <= 0)
                {
                    m_LastMousePosition = MousePosition;
                    m_nMouseWaitHide = 0;
                    m_bCursorHidden = true;
                    m_oImageForm.Cursor = m_oBlankCursor;
                    this.Cursor = m_oBlankCursor;
                }
            }

            // If the spin wait counter is more then zero, decrement and return.
            if (m_nSpinWait > 0)
            {
                if ((m_nSpinWait -= tim_SlideShowTimer.Interval) < 0)
                    m_nSpinWait = 0;

                return;
            }

            // Run the specified image transition mode.
            switch (m_nTransitionMode)
            {
                case TransitionMode.Normal:
                    NormalTransition();
                    break;
                case TransitionMode.Fade:
                    FadeTransition();
                    break;
            }
        }

        #endregion

        #region Context menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_Options_Opening(object sender, CancelEventArgs e)
        {
            if (tim_SlideShowTimer.Enabled)
            {
                tsmi_PlayPause.Text = "Pause";
                tsmi_PlayPause.Image = Resources.pause_16x16;
            }
            else
            {
                tsmi_PlayPause.Text = "Play";
                tsmi_PlayPause.Image = Resources.play_16x16;
            }

            tsmi_NormalTransition.Checked = (m_nTransitionMode == TransitionMode.Normal);
            tsmi_FadeTransition.Checked = (m_nTransitionMode == TransitionMode.Fade);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_Options_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason != ToolStripDropDownCloseReason.ItemClicked)
            {
                if (m_bHoldContextMenuOpen)
                    e.Cancel = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_PlayPause_Click(object sender, EventArgs e)
        {
            StartStop();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Next_Click(object sender, EventArgs e)
        {
            LoadNextImage((m_nTransitionMode == TransitionMode.Normal));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Previous_Click(object sender, EventArgs e)
        {
            LoadPreviousImage((m_nTransitionMode == TransitionMode.Normal));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_NormalTransition_Click(object sender, EventArgs e)
        {
            m_nTransitionMode = TransitionMode.Normal;
            m_bFadeIn = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_FadeTransition_Click(object sender, EventArgs e)
        {
            m_nTransitionMode = TransitionMode.Fade;
            m_nSpinWait = 0;
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

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            // Load an image right away unless the transition mode is currently set to normal.
            if (m_nTransitionMode != TransitionMode.Normal)
                LoadNextImage(false);

            // Start the slide show.
            StartStop();

            base.OnLoad(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            tim_SlideShowTimer.Stop();
            Cursor.Current = Cursors.Default;

            base.OnFormClosed(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            ShowCursor(true);

            ManageContextMenuOnMouseClick(e);

            base.OnMouseClick(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            ShowCursor(false);

            base.OnMouseMove(e);
        }

        #endregion

        private void SlideShow_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void SlideShow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                LoadPreviousImage((m_nTransitionMode == TransitionMode.Normal));
            }

            if (e.KeyCode == Keys.Right)
            {
                LoadNextImage((m_nTransitionMode == TransitionMode.Normal));
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
               //this.par.ParentForm.Show();
            }
        }
    }
}
