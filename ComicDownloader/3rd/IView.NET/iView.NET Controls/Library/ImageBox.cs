//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ImageBox.cs
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
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using IView.Controls.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// Provides properties and methods for drawing an image box that can be moved and resized during runtime.
    /// </summary>
    public partial class ImageBox : UserControl
    {
        #region Fields and properties

        private const int IN_RECTBOUNDS_OFFSET = 2;

        private bool m_bMouseEnteredImageBox = false;
        private bool m_bMouseLeaveImageBox = true;
        private bool m_bIsImageLoaded = false;
        private bool m_bAllowMouseMove = true;
        private bool m_bAllowMouseResize = true;
        private bool m_bFocusControl = false;
        private bool m_bVisible = true;
        private bool m_bDisplayInfo = false;
        private int m_nRectMousePosX = 0;
        private int m_nRectMousePosY = 0;
        private Image m_oImageBoxImage = null;
        private Rectangle m_ImageBoxRect;
        private Point m_MouseDownPosition;
        private ImageBoxBounds m_nBoundsSelected = 0;
        private ImageBoxMode m_nImageBoxMode = ImageBoxMode.None;
        private MouseButtons m_nRectMoveMouseButton = MouseButtons.Middle;
        private MouseButtons m_nRectResizeMouseButton = MouseButtons.Left;
        private CompositingQuality m_nCompostingQuality = CompositingQuality.Default;
        private InterpolationMode m_nInterpolatioMode = InterpolationMode.Default;
        private SmoothingMode m_nSmoothingMode = SmoothingMode.Default;
        
        /// <summary>
        /// Gets or sets the image to be drawn in the image box. Do not call dispose! Just dereference.
        /// </summary>
        [Category("ImageBox Properties")]
        [DefaultValue(null)]
        [Description("Gets or sets the image to be drawn in the image box.")]
        public Image ImageBoxImage
        {
            get { return m_oImageBoxImage; }
            set
            {
                if (m_oImageBoxImage != null)
                {
                    m_oImageBoxImage.Dispose();
                    m_oImageBoxImage = null;
                }

                m_oImageBoxImage = value;

                if (m_bIsImageLoaded = (value != null))
                {
                    OnImageBoxImageLoaded(this,
                        new ImageBoxEventArgs(m_ImageBoxRect));
                }

                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the current location of the image box.
        /// </summary>
        /// <returns></returns>
        [Category("ImageBox Properties")]
        [DefaultValue(typeof(Point), "0, 0")]
        [Description("Gets or sets the current location of the image box.")]
        public Point ImageBoxLocation
        {
            get { return m_ImageBoxRect.Location; }
            set
            {
                m_ImageBoxRect.Location = value;

                UpdateAutoScroll();
            }
        }

        /// <summary>
        /// Gets or sets the current size of the image box.
        /// </summary>
        /// <returns></returns>
        [Category("ImageBox Properties")]
        [DefaultValue(typeof(Size), "0, 0")]
        [Description("Gets or sets the current size of the image box.")]
        public Size ImageBoxSize
        {
            get { return m_ImageBoxRect.Size; }
            set
            {
                m_ImageBoxRect.Size = value;

                UpdateAutoScroll();
            }
        }

        /// <summary>
        /// Gets or sets the width of the image box.
        /// </summary>
        [Browsable(false)]
        public int ImageBoxWidth
        {
            get { return m_ImageBoxRect.Width; }
            set
            {
                if (value > 0)
                    m_ImageBoxRect.Width = value;
                else
                    m_ImageBoxRect.Width = 1;

                UpdateAutoScroll();
            }
        }

        /// <summary>
        /// Gets or sets the height of the image box.
        /// </summary>
        [Browsable(false)]
        public int ImageBoxHeight
        {
            get { return m_ImageBoxRect.Height; }
            set
            {
                if (value > 0)
                    m_ImageBoxRect.Height = value;
                else
                    m_ImageBoxRect.Height = 1;

                UpdateAutoScroll();
            }
        }

        /// <summary>
        /// Gets or sets the image box rectangle of this current instance.
        /// </summary>
        [Browsable(false)]
        public Rectangle ImageBoxRectangle
        {
            get { return m_ImageBoxRect; }
            set
            {
                m_ImageBoxRect = value;

                UpdateAutoScroll();
            }
        }

        /// <summary>
        /// Gets or sets the mouse button to use when moving the image box.
        /// </summary>
        [Category("ImageBox Properties")]
        [DefaultValue(typeof(MouseButtons), "Middle")]
        [Description("Gets or sets the mouse button to use when moving the image box.")]
        public MouseButtons ImageBoxMoveMouseButton
        {
            get { return m_nRectMoveMouseButton; }
            set { m_nRectMoveMouseButton = value; }
        }

        /// <summary>
        /// Gets or sets the mouse button to use when resizing the image box.
        /// </summary>
        [Category("ImageBox Properties")]
        [DefaultValue(typeof(MouseButtons), "Left")]
        [Description("Gets or sets the mouse button to use when resizing the image box.")]
        public MouseButtons ImageBoxResizeMouseButton
        {
            get { return m_nRectResizeMouseButton; }
            set { m_nRectResizeMouseButton = value; }
        }

        /// <summary>
        /// Gets or sets the InterpolationMode to be used on the image.
        /// </summary>
        [Category("ImageBox Properties")]
        [DefaultValue(typeof(InterpolationMode), "Default")]
        [Description("Gets or sets the InterpolationMode to be used on the image.")]
        public InterpolationMode ImageBoxInterpolationMode
        {
            get { return m_nInterpolatioMode; }
            set
            {
                m_nInterpolatioMode = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the CompositingQuality to be used on the image.
        /// </summary>
        [Category("ImageBox Properties")]
        [DefaultValue(typeof(CompositingQuality), "Default")]
        [Description("Gets or sets the CompositingQuality to be used on the image.")]
        public CompositingQuality ImageBoxCompositingQuality
        {
            get { return m_nCompostingQuality; }
            set
            {
                m_nCompostingQuality = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the SmoothingMode to be used on the image.
        /// </summary>
        [Category("ImageBox Properties")]
        [DefaultValue(typeof(InterpolationMode), "Default")]
        [Description("Gets or sets the SmoothingMode to be used on the image.")]
        public SmoothingMode ImageBoxSmoothingMode
        {
            get { return m_nSmoothingMode; }
            set
            {
                m_nSmoothingMode = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets a value indicating whether an image is loaded into 
        /// the image box.
        /// </summary>
        [Browsable(false)]
        public bool IsImageLoaded
        {
            get { return m_bIsImageLoaded; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the image box 
        /// can be moved by the mouse.
        /// </summary>
        [Category("ImageBox Properties")]
        [DefaultValue(true)]
        [Description("Gets or sets a value indicating whether the image box can be moved by the mouse.")]
        public bool AllowMouseMove
        {
            get { return m_bAllowMouseMove; }
            set { m_bAllowMouseMove = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the image box 
        /// can be resized by the mouse.
        /// </summary>
        [Category("ImageBox Properties")]
        [DefaultValue(true)]
        [Description("Gets or sets a value indicating whether the image box can be resized by the mouse.")]
        public bool AllowMouseResize
        {
            get { return m_bAllowMouseResize; }
            set 
            { 
                m_bAllowMouseResize = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Specifies whether the control hosting the image box should be focused 
        /// when the image box object is clicked.
        /// </summary>
        [Browsable(false)]
        public bool FocusControl
        {
            get { return m_bFocusControl; }
            set { m_bFocusControl = value; }
        }

        /// <summary>
        /// Gets or sets the visibility of the image box.
        /// </summary>
        [Category("ImageBox Properties")]
        [DefaultValue(true)]
        [Description("Gets or sets the visibility of the image box.")]
        public bool ImageBoxVisible
        {
            get { return m_bVisible; }
            set
            {
                if (value != m_bVisible)
                {
                    m_bVisible = value;

                    OnImageBoxVisibilityChanged(this,
                        new ImageBoxEventArgs(m_ImageBoxRect));

                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to display the image box
        /// info in the top left corner.
        /// </summary>
        [Category("ImageBox Properties")]
        [DefaultValue(false)]
        [Description("Gets or sets a value indicating whether to display the image box info in the top left corner.")]
        public bool DisplayInfo
        {
            get { return m_bDisplayInfo; }
            set
            {
                m_bDisplayInfo = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Fires when a new image has been loaded into the image box.
        /// </summary>
        [Category("ImageBox Events")]
        [DefaultValue("")]
        [Description("Fires when a new image has been loaded into the image box.")]
        public event EventHandler<ImageBoxEventArgs> ImageBoxImageLoaded;

        /// <summary>
        /// Fires when the visibility of the image box has changed.
        /// </summary>
        [Category("ImageBox Events")]
        [DefaultValue("")]
        [Description("Fires when the visibility of the image box has changed.")]
        public event EventHandler<ImageBoxEventArgs> ImageBoxVisibilityChanged;

        /// <summary>
        /// Fires when the mouse pointer enters the image box.
        /// </summary>
        [Category("ImageBox Events")]
        [DefaultValue("")]
        [Description("Fires when the mouse pointer enters the image box.")]
        public event EventHandler<ImageBoxEventArgs> ImageBoxMouseEnter;

        /// <summary>
        /// Fires when the mouse pointer leaves the image box.
        /// </summary>
        [Category("ImageBox Events")]
        [DefaultValue("")]
        [Description("Fires when the mouse pointer leaves the image box.")]
        public event EventHandler<ImageBoxEventArgs> ImageBoxMouseLeave;

        /// <summary>
        /// Fires when the mouse pointer is over the image box and the
        /// mouse button is pressed.
        /// </summary>
        [Category("ImageBox Events")]
        [DefaultValue("")]
        [Description("Fires when the mouse pointer is over the image box and the mouse button is pressed.")]
        public event EventHandler<ImageBoxMouseEventArgs> ImageBoxMouseDown;

        /// <summary>
        /// Fires when the mouse pointer is over the image box and the
        /// mouse button is released.
        /// </summary>
        [Category("ImageBox Events")]
        [DefaultValue("")]
        [Description("Fires when the mouse pointer is over the image box and the mouse button is released.")]
        public event EventHandler<ImageBoxMouseEventArgs> ImageBoxMouseUp;

        /// <summary>
        /// Fires when the mouse is moved inside the image box.
        /// </summary>
        [Category("ImageBox Events")]
        [DefaultValue("")]
        [Description("Fires when the mouse is moved inside the image box.")]
        public event EventHandler<ImageBoxMouseEventArgs> ImageBoxMouseMove;

        /// <summary>
        /// Fires when the mouse is over the image box and the mouse 
        /// button is double clicked.
        /// </summary>
        [Category("ImageBox Events")]
        [DefaultValue("")]
        [Description("Fires when the mouse is over the image box and the mouse button is double clicked.")]
        public event EventHandler<ImageBoxMouseEventArgs> ImageBoxDoubleClick;

        /// <summary>
        /// Fires when the image box is resized by the mouse.
        /// </summary>
        [Category("ImageBox Events")]
        [DefaultValue("")]
        [Description("Fires when the image box is resized by the mouse.")]
        public event EventHandler<ImageBoxMouseEventArgs> ImageBoxMouseResize;

        /// <summary>
        /// Fires when the mouse wheel is moved.
        /// </summary>
        [Category("ImageBox Events")]
        [DefaultValue("")]
        [Description("Fires when the mouse wheel is moved.")]
        public event EventHandler<MouseEventArgs> ImageBoxMouseWheel;

        #endregion
        
        #region Constructors

        /// <summary>
        /// Creates a new instance of the ImageBox class initialized with default parameters.
        /// </summary>
        public ImageBox()
        {
            InitializeComponent();

            //this.MouseWheel += delegate(object sender, MouseEventArgs e)
            //{
            //    ((HandledMouseEventArgs)e).Handled = true;
            //};
        }

        #endregion

        #region Event wrappers

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnImageBoxMouseWheel(object sender, MouseEventArgs e)
        {
            if (ImageBoxMouseWheel != null)
                ImageBoxMouseWheel(sender, e);
        }

        /// <summary>
        /// Overridable OnImageBoxMouseEnter event wrapper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnImageBoxMouseEnter(object sender, ImageBoxEventArgs e)
        {
            if (ImageBoxMouseEnter != null)
                ImageBoxMouseEnter(sender, e);
        }

        /// <summary>
        /// Overridable OnImageBoxMouseLeave event wrapper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnImageBoxMouseLeave(object sender, ImageBoxEventArgs e)
        {
            if (ImageBoxMouseLeave != null)
                ImageBoxMouseLeave(sender, e);
        }

        /// <summary>
        /// Overridable OnImageBoxMouseDown event wrapper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnImageBoxMouseDown(object sender, ImageBoxMouseEventArgs e)
        {
            if (ImageBoxMouseDown != null)
                ImageBoxMouseDown(sender, e);
        }

        /// <summary>
        /// Overridable OnImageBoxMouseUp event wrapper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnImageBoxMouseUp(object sender, ImageBoxMouseEventArgs e)
        {
            if (ImageBoxMouseUp != null)
                ImageBoxMouseUp(sender, e);
        }

        /// <summary>
        /// Overridable OnImageBoxMouseDoubleClick event wrapper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnImageBoxMouseDoubleClick(object sender, ImageBoxMouseEventArgs e)
        {
            if (ImageBoxDoubleClick != null)
                ImageBoxDoubleClick(sender, e);
        }

        /// <summary>
        /// Overridable OnImageBoxMouseMove event wrapper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnImageBoxMouseMove(object sender, ImageBoxMouseEventArgs e)
        {
            if (ImageBoxMouseMove != null)
                ImageBoxMouseMove(sender, e);
        }

        /// <summary>
        /// Overridable OnImageBoxMouseResize event wrapper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnImageBoxMouseResize(object sender, ImageBoxMouseEventArgs e)
        {
            if (ImageBoxMouseResize != null)
                ImageBoxMouseResize(sender, e);
        }

        /// <summary>
        /// Overridable OnImageBoxImageLoaded event wrapper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnImageBoxImageLoaded(object sender, ImageBoxEventArgs e)
        {
            if (ImageBoxImageLoaded != null)
                ImageBoxImageLoaded(sender, e);
        }

        /// <summary>
        /// Overridable OnImageBoxVisibilityChanged event wrapper.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnImageBoxVisibilityChanged(object sender, ImageBoxEventArgs e)
        {
            if (ImageBoxVisibilityChanged != null)
                ImageBoxVisibilityChanged(sender, e);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            //base.OnMouseWheel(e);

            // Fire the mouse move event.
            OnImageBoxMouseWheel(this, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeave(EventArgs e)
        {
            // Allow the event from the base class to be called.
            base.OnMouseLeave(e);

            // Return if the visible flag is false.
            if (!m_bVisible) return;

            if (!m_bMouseLeaveImageBox)
            {
                m_bMouseLeaveImageBox = true;
                m_bMouseEnteredImageBox = false;

                OnImageBoxMouseLeave(this,
                    new ImageBoxEventArgs(m_ImageBoxRect));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!m_bVisible) return;

            int nX = e.X - this.AutoScrollPosition.X;
            int nY = e.Y - this.AutoScrollPosition.Y;
            int nRectPosX = m_ImageBoxRect.X - this.AutoScrollPosition.X;
            int nRectPosY = m_ImageBoxRect.Y - this.AutoScrollPosition.Y;
            int nRectWidth = m_ImageBoxRect.Width;
            int nRectHeight = m_ImageBoxRect.Height;

            if (e.Button == MouseButtons.Left)
            {
                if (!m_MouseDownPosition.IsEmpty)
                {
                    int nPosX = e.X - m_MouseDownPosition.X;
                    int nPosY = e.Y - m_MouseDownPosition.Y;

                    nPosX -= (nPosX * 2);
                    nPosY -= (nPosY * 2);

                    if (nPosX < 0)
                        nPosX = 0;
                    if (nPosX > this.HorizontalScroll.Maximum)
                        nPosX = this.HorizontalScroll.Maximum;
                    if (nPosY < 0)
                        nPosY = 0;
                    if (nPosY > this.VerticalScroll.Maximum)
                        nPosY = this.VerticalScroll.Maximum;

                    this.HorizontalScroll.Value = nPosX;
                    this.VerticalScroll.Value = nPosY;
                }
            }

            if (IsMouseInImageBoxBounds(nX, nY, 0))
            {
                if (!m_bMouseEnteredImageBox)
                {
                    m_bMouseEnteredImageBox = true;
                    m_bMouseLeaveImageBox = false;

                    OnImageBoxMouseEnter(this,
                        new ImageBoxEventArgs(m_ImageBoxRect));
                }
            }
            else
            {
                if (!m_bMouseLeaveImageBox)
                {
                    m_bMouseLeaveImageBox = true;
                    m_bMouseEnteredImageBox = false;

                    OnImageBoxMouseLeave(this,
                        new ImageBoxEventArgs(m_ImageBoxRect));
                }
            }

            if ((e.Button != m_nRectMoveMouseButton) && (e.Button != m_nRectResizeMouseButton))
            {
                if (m_bAllowMouseResize)
                {
                    ImageBoxBounds nOnBounds;

                    if (IsMouseOnImageBoxBounds(nX, nY, ImageBoxBounds.Any, out nOnBounds))
                    {
                        switch (nOnBounds)
                        {
                            case ImageBoxBounds.None:
                                Cursor.Current = Cursors.Default;
                                break;
                            case ImageBoxBounds.Top:
                                Cursor.Current = Cursors.SizeNS;
                                break;
                            case ImageBoxBounds.Bottom:
                                Cursor.Current = Cursors.SizeNS;
                                break;
                            case ImageBoxBounds.Left:
                                Cursor.Current = Cursors.SizeWE;
                                break;
                            case ImageBoxBounds.Right:
                                Cursor.Current = Cursors.SizeWE;
                                break;
                            case ImageBoxBounds.TopLeft:
                                Cursor.Current = Cursors.SizeNWSE;
                                break;
                            case ImageBoxBounds.TopRight:
                                Cursor.Current = Cursors.SizeNESW;
                                break;
                            case ImageBoxBounds.BottomLeft:
                                Cursor.Current = Cursors.SizeNESW;
                                break;
                            case ImageBoxBounds.BottomRight:
                                Cursor.Current = Cursors.SizeNWSE;
                                break;
                        }
                    }
                }

                if (IsMouseInImageBoxBounds(nX, nY, 0))
                {
                    OnImageBoxMouseMove(this,
                        new ImageBoxMouseEventArgs(e, m_ImageBoxRect));
                }
            }
            else
            {
                if (e.Button == m_nRectMoveMouseButton)
                {
                    if ((m_nImageBoxMode == ImageBoxMode.Move) && (m_bAllowMouseMove))
                    {
                        m_ImageBoxRect.X = nX - m_nRectMousePosX;
                        m_ImageBoxRect.Y = nY - m_nRectMousePosY;
                    }
                }
                else if (e.Button == m_nRectResizeMouseButton)
                {
                    if ((m_nImageBoxMode == ImageBoxMode.Resize) && (m_bAllowMouseResize))
                    {
                        int nLastPosX = m_ImageBoxRect.X;
                        int nLastPosY = m_ImageBoxRect.Y;

                        switch (m_nBoundsSelected)
                        {
                            case ImageBoxBounds.Top:
                                m_ImageBoxRect.Height = m_ImageBoxRect.Bottom - nY;
                                m_ImageBoxRect.Y = nY;
                                break;
                            case ImageBoxBounds.Left:
                                m_ImageBoxRect.Width = m_ImageBoxRect.Right - nX;
                                m_ImageBoxRect.X = nX;
                                break;
                            case ImageBoxBounds.Right:
                                m_ImageBoxRect.Width = nX - m_ImageBoxRect.X;
                                break;
                            case ImageBoxBounds.Bottom:
                                m_ImageBoxRect.Height = nY - m_ImageBoxRect.Y;
                                break;
                            case ImageBoxBounds.TopLeft:
                                m_ImageBoxRect.Width = m_ImageBoxRect.Right - nX;
                                m_ImageBoxRect.Height = m_ImageBoxRect.Bottom - nY;
                                m_ImageBoxRect.X = nX;
                                m_ImageBoxRect.Y = nY;
                                break;
                            case ImageBoxBounds.TopRight:
                                m_ImageBoxRect.Width = nX - m_ImageBoxRect.X;
                                m_ImageBoxRect.Height = m_ImageBoxRect.Bottom - nY;
                                m_ImageBoxRect.Y = nY;
                                break;
                            case ImageBoxBounds.BottomLeft:
                                m_ImageBoxRect.Width = m_ImageBoxRect.Right - nX;
                                m_ImageBoxRect.Height = nY - m_ImageBoxRect.Y;
                                m_ImageBoxRect.X = nX;
                                break;
                            case ImageBoxBounds.BottomRight:
                                m_ImageBoxRect.Width = nX - m_ImageBoxRect.X;
                                m_ImageBoxRect.Height = nY - m_ImageBoxRect.Y;
                                break;
                        }

                        if (m_ImageBoxRect.Width < 1)
                        {
                            m_ImageBoxRect.Width = 1;
                            m_ImageBoxRect.X = nLastPosX;
                        }

                        if (m_ImageBoxRect.Height < 1)
                        {
                            m_ImageBoxRect.Height = 1;
                            m_ImageBoxRect.Y = nLastPosY;
                        }

                        // Fire resize event.
                        OnImageBoxMouseResize(this,
                            new ImageBoxMouseEventArgs(e, m_ImageBoxRect));
                    }
                }

                this.Invalidate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (!m_bVisible) return;

            // Set flags.
            m_nImageBoxMode = ImageBoxMode.None;
            m_nBoundsSelected = ImageBoxBounds.None;
            m_MouseDownPosition = Point.Empty;

            if (IsMouseInImageBoxBounds(e.X - this.AutoScrollPosition.X, e.Y - this.AutoScrollPosition.Y, 2))
            {
                OnImageBoxMouseUp(this,
                    new ImageBoxMouseEventArgs(e, m_ImageBoxRect));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (!m_bVisible) return;

            int nX = e.X - this.AutoScrollPosition.X;
            int nY = e.Y - this.AutoScrollPosition.Y;

            //
            m_MouseDownPosition = new Point(nX, nY);

            if (IsMouseInImageBoxBounds(nX, nY, 2))
            {
                if (e.Button == m_nRectMoveMouseButton)
                {
                    if (m_bAllowMouseMove)
                    {
                        m_nImageBoxMode = ImageBoxMode.Move;
                        m_nRectMousePosX = nX - m_ImageBoxRect.X;
                        m_nRectMousePosY = nY - m_ImageBoxRect.Y;
                        Cursor.Current = Cursors.SizeAll;
                    }
                }

                // Fire rectangle mouse down event.
                OnImageBoxMouseDown(this,
                    new ImageBoxMouseEventArgs(e, m_ImageBoxRect));
            }
            else
            {
                if (e.Button == m_nRectResizeMouseButton)
                {
                    if (m_bAllowMouseResize)
                    {
                        ImageBoxBounds nOnBounds;

                        if (IsMouseOnImageBoxBounds(nX, nY, ImageBoxBounds.Any, out nOnBounds))
                        {
                            m_nImageBoxMode = ImageBoxMode.Resize;
                            m_nBoundsSelected = nOnBounds;

                            switch (nOnBounds)
                            {
                                case ImageBoxBounds.None:
                                    Cursor.Current = Cursors.Default;
                                    break;
                                case ImageBoxBounds.Top:
                                    Cursor.Current = Cursors.SizeNS;
                                    break;
                                case ImageBoxBounds.Bottom:
                                    Cursor.Current = Cursors.SizeNS;
                                    break;
                                case ImageBoxBounds.Left:
                                    Cursor.Current = Cursors.SizeWE;
                                    break;
                                case ImageBoxBounds.Right:
                                    Cursor.Current = Cursors.SizeWE;
                                    break;
                                case ImageBoxBounds.TopLeft:
                                    Cursor.Current = Cursors.SizeNWSE;
                                    break;
                                case ImageBoxBounds.TopRight:
                                    Cursor.Current = Cursors.SizeNESW;
                                    break;
                                case ImageBoxBounds.BottomLeft:
                                    Cursor.Current = Cursors.SizeNESW;
                                    break;
                                case ImageBoxBounds.BottomRight:
                                    Cursor.Current = Cursors.SizeNWSE;
                                    break;
                            }
                        }
                    }
                }
            }

            if (m_bFocusControl)
            {
                if (!this.Focused)
                    this.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            if (!m_bVisible) return;

            Point stNewPoint = this.AutoScrollPosition;
            int nX = e.X - stNewPoint.X;
            int nY = e.Y - stNewPoint.Y;

            if (IsMouseInImageBoxBounds(nX, nY, 2))
            {
                OnImageBoxMouseDoubleClick(this,
                    new ImageBoxMouseEventArgs(e, m_ImageBoxRect));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Return if the visible flag is false.
            if (!m_bVisible) return;

            Rectangle Rect = new Rectangle(m_ImageBoxRect.Location +
                new Size(this.AutoScrollPosition), m_ImageBoxRect.Size);

            // Draw the image if one has been provided.
            if (m_bIsImageLoaded)
            {
                // Update the graphics properties.
                e.Graphics.CompositingQuality = m_nCompostingQuality;
                e.Graphics.InterpolationMode = m_nInterpolatioMode;
                e.Graphics.SmoothingMode = m_nSmoothingMode;

                e.Graphics.DrawImage(m_oImageBoxImage,
                    Rect.X + 1, Rect.Y + 1, Rect.Width, Rect.Height);
            }

            // Draw the resizing border if resizing is enabled.
            if (m_bAllowMouseResize)
            {
                using (SolidBrush oBrush = new SolidBrush(Color.Black))
                {
                    using (Pen oPen = new Pen(oBrush, 1.0f))
                    {
                        oPen.DashStyle = DashStyle.Dash;
                        e.Graphics.DrawRectangle(oPen,
                            Rect.X, Rect.Y, Rect.Width + 1, Rect.Height + 1);
                    }                       
                }
            }
        }

        #endregion

        #region Subroutines

        /// <summary>
        /// 
        /// </summary>
        private void UpdateAutoScroll()
        {
            // Adjust the controls auto scroll minimum size property.
            if (!this.AutoScroll)
                this.AutoScrollMinSize = Size.Empty;
            else
                this.AutoScrollMinSize = new Size(m_ImageBoxRect.Right + 2, m_ImageBoxRect.Bottom + 2);
        }

        /// <summary>
        /// Returns true if the specified coordinates are on the specified bounds 
        /// of the image box.
        /// </summary>
        /// <param name="nX">Specifies the X position.</param>
        /// <param name="nY">Specifies the Y position.</param>
        /// <param name="nBounds">Specifies the bounds to check for.</param>
        /// <returns></returns>
        private bool IsMouseOnImageBoxBounds(int nX, int nY, ImageBoxBounds nBounds)
        {
            int nWidthOffset = 1;
            int nLengthOffset = 2;
            int nRectBottom = m_ImageBoxRect.Bottom;
            int nRectRight = m_ImageBoxRect.Right;
            int nRectPosX = m_ImageBoxRect.X;
            int nRectPosY = m_ImageBoxRect.Y;
            int nRectWidth = m_ImageBoxRect.Width;
            int nRectHeight = m_ImageBoxRect.Height;

            if ((nRectWidth > 0) & (nRectHeight > 0))
            {
                if (nBounds == ImageBoxBounds.Top)
                {
                    // Top bounds width check.
                    if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                    {
                        // Top bounds length check.
                        if ((nX >= nRectPosX + nLengthOffset) && (nX <= nRectRight - nLengthOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.Bottom)
                {
                    // Bottom bounds width check.
                    if ((nY <= nRectBottom + nWidthOffset) && (nY >= nRectBottom - nWidthOffset))
                    {
                        // Bottom bounds length check.
                        if ((nX >= nRectPosX + nLengthOffset) && (nX <= nRectRight - nLengthOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.Left)
                {
                    // Left bounds width check.
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // Left bounds length check.
                        if ((nY >= nRectPosY + nLengthOffset) && (nY <= nRectBottom - nLengthOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.Right)
                {
                    // Right bounds width check.
                    if ((nX <= nRectRight + nWidthOffset) && (nX >= nRectRight - nWidthOffset))
                    {
                        // Right bounds length check.
                        if ((nY >= nRectPosY + nLengthOffset) && (nY <= nRectBottom - nLengthOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.TopLeft)
                {
                    // Top left bounds width check
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // Top left bounds height check
                        if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.TopRight)
                {
                    // Top right bounds width check
                    if ((nX >= nRectRight - nWidthOffset) && (nX <= nRectRight + nWidthOffset))
                    {
                        // Top right bounds height check.
                        if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.BottomLeft)
                {
                    // Bottom left bounds width check
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // bottom left bounds height check.
                        if ((nY >= nRectBottom - nWidthOffset) && (nY <= nRectBottom + nWidthOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.BottomRight)
                {
                    // Bottom right bounds width check.
                    if ((nX >= nRectRight - nWidthOffset) && (nX <= nRectRight + nWidthOffset))
                    {
                        // bottom right bounds height check.
                        if ((nY >= nRectBottom - nWidthOffset) && (nY <= nRectBottom + nWidthOffset))
                        {
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.Any)
                {
                    // Top bounds width check.
                    if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                    {
                        // Top bounds length check.
                        if ((nX >= nRectPosX + nLengthOffset) && (nX <= nRectRight - nLengthOffset))
                        {
                            return true;
                        }
                    }

                    // Bottom bounds width check.
                    if ((nY <= nRectBottom + nWidthOffset) && (nY >= nRectBottom - nWidthOffset))
                    {
                        // Bottom bounds length check.
                        if ((nX >= nRectPosX + nLengthOffset) && (nX <= nRectRight - nLengthOffset))
                        {
                            return true;
                        }
                    }

                    // Left bounds width check.
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // Left bounds length check.
                        if ((nY >= nRectPosY + nLengthOffset) && (nY <= nRectBottom - nLengthOffset))
                        {
                            return true;
                        }
                    }

                    // Right bounds width check.
                    if ((nX <= nRectRight + nWidthOffset) && (nX >= nRectRight - nWidthOffset))
                    {
                        // Right bounds length check.
                        if ((nY >= nRectPosY + nLengthOffset) && (nY <= nRectBottom - nLengthOffset))
                        {
                            return true;
                        }
                    }

                    // Top left bounds width check
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // Top left bounds height check
                        if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                        {
                            return true;
                        }
                    }

                    // Top right bounds width check
                    if ((nX >= nRectRight - nWidthOffset) && (nX <= nRectRight + nWidthOffset))
                    {
                        // Top right bounds height check.
                        if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                        {
                            return true;
                        }
                    }

                    // Bottom left bounds width check
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // bottom left bounds height check.
                        if ((nY >= nRectBottom - nWidthOffset) && (nY <= nRectBottom + nWidthOffset))
                        {
                            return true;
                        }
                    }

                    // Bottom right bounds width check.
                    if ((nX >= nRectRight - nWidthOffset) && (nX <= nRectRight + nWidthOffset))
                    {
                        // bottom right bounds height check.
                        if ((nY >= nRectBottom - nWidthOffset) && (nY <= nRectBottom + nWidthOffset))
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
        /// of the image box. If you are checking for any bounds, the out parameter
        /// can provide the bounds the coordinates are on.
        /// </summary>
        /// <param name="nX">Specifies the X position.</param>
        /// <param name="nY">Specifies the Y position.</param>
        /// <param name="nBounds">Specifies the bounds to check for.</param>
        /// <param name="nOnBounds">Returns the bounds the mouse pointer is on.</param>
        /// <returns></returns>
        private bool IsMouseOnImageBoxBounds(int nX, int nY, ImageBoxBounds nBounds, out ImageBoxBounds nOnBounds)
        {
            int nWidthOffset = 1;
            int nLengthOffset = 2;
            int nRectBottom = m_ImageBoxRect.Bottom;
            int nRectRight = m_ImageBoxRect.Right;
            int nRectPosX = m_ImageBoxRect.X;
            int nRectPosY = m_ImageBoxRect.Y;
            int nRectWidth = m_ImageBoxRect.Width;
            int nRectHeight = m_ImageBoxRect.Height;

            if ((nRectWidth > 0) & (nRectHeight > 0))
            {
                if (nBounds == ImageBoxBounds.Top)
                {
                    // Top bounds width check.
                    if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                    {
                        // Top bounds length check.
                        if ((nX >= nRectPosX + nLengthOffset) && (nX <= nRectRight - nLengthOffset))
                        {
                            nOnBounds = ImageBoxBounds.Top;
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.Bottom)
                {
                    // Bottom bounds width check.
                    if ((nY <= nRectBottom + nWidthOffset) && (nY >= nRectBottom - nWidthOffset))
                    {
                        // Bottom bounds length check.
                        if ((nX >= nRectPosX + nLengthOffset) && (nX <= nRectRight - nLengthOffset))
                        {
                            nOnBounds = ImageBoxBounds.Bottom;
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.Left)
                {
                    // Left bounds width check.
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // Left bounds length check.
                        if ((nY >= nRectPosY + nLengthOffset) && (nY <= nRectBottom - nLengthOffset))
                        {
                            nOnBounds = ImageBoxBounds.Left;
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.Right)
                {
                    // Right bounds width check.
                    if ((nX <= nRectRight + nWidthOffset) && (nX >= nRectRight - nWidthOffset))
                    {
                        // Right bounds length check.
                        if ((nY >= nRectPosY + nLengthOffset) && (nY <= nRectBottom - nLengthOffset))
                        {
                            nOnBounds = ImageBoxBounds.Right;
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.TopLeft)
                {
                    // Top left bounds width check
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // Top left bounds height check
                        if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                        {
                            nOnBounds = ImageBoxBounds.TopLeft;
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.TopRight)
                {
                    // Top right bounds width check
                    if ((nX >= nRectRight - nWidthOffset) && (nX <= nRectRight + nWidthOffset))
                    {
                        // Top right bounds height check.
                        if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                        {
                            nOnBounds = ImageBoxBounds.TopRight;
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.BottomLeft)
                {
                    // Bottom left bounds width check
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // bottom left bounds height check.
                        if ((nY >= nRectBottom - nWidthOffset) && (nY <= nRectBottom + nWidthOffset))
                        {
                            nOnBounds = ImageBoxBounds.BottomLeft;
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.BottomRight)
                {
                    // Bottom right bounds width check.
                    if ((nX >= nRectRight - nWidthOffset) && (nX <= nRectRight + nWidthOffset))
                    {
                        // bottom right bounds height check.
                        if ((nY >= nRectBottom - nWidthOffset) && (nY <= nRectBottom + nWidthOffset))
                        {
                            nOnBounds = ImageBoxBounds.BottomRight;
                            return true;
                        }
                    }
                }
                else if (nBounds == ImageBoxBounds.Any)
                {
                    // Top bounds width check.
                    if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                    {
                        // Top bounds length check.
                        if ((nX >= nRectPosX + nLengthOffset) && (nX <= nRectRight - nLengthOffset))
                        {
                            nOnBounds = ImageBoxBounds.Top;
                            return true;
                        }
                    }

                    // Bottom bounds width check.
                    if ((nY <= nRectBottom + nWidthOffset) && (nY >= nRectBottom - nWidthOffset))
                    {
                        // Bottom bounds length check.
                        if ((nX >= nRectPosX + nLengthOffset) && (nX <= nRectRight - nLengthOffset))
                        {
                            nOnBounds = ImageBoxBounds.Bottom;
                            return true;
                        }
                    }

                    // Left bounds width check.
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // Left bounds length check.
                        if ((nY >= nRectPosY + nLengthOffset) && (nY <= nRectBottom - nLengthOffset))
                        {
                            nOnBounds = ImageBoxBounds.Left;
                            return true;
                        }
                    }

                    // Right bounds width check.
                    if ((nX <= nRectRight + nWidthOffset) && (nX >= nRectRight - nWidthOffset))
                    {
                        // Right bounds length check.
                        if ((nY >= nRectPosY + nLengthOffset) && (nY <= nRectBottom - nLengthOffset))
                        {
                            nOnBounds = ImageBoxBounds.Right;
                            return true;
                        }
                    }

                    // Top left bounds width check
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // Top left bounds height check
                        if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                        {
                            nOnBounds = ImageBoxBounds.TopLeft;
                            return true;
                        }
                    }

                    // Top right bounds width check
                    if ((nX >= nRectRight - nWidthOffset) && (nX <= nRectRight + nWidthOffset))
                    {
                        // Top right bounds height check.
                        if ((nY >= nRectPosY - nWidthOffset) && (nY <= nRectPosY + nWidthOffset))
                        {
                            nOnBounds = ImageBoxBounds.TopRight;
                            return true;
                        }
                    }

                    // Bottom left bounds width check
                    if ((nX >= nRectPosX - nWidthOffset) && (nX <= nRectPosX + nWidthOffset))
                    {
                        // bottom left bounds height check.
                        if ((nY >= nRectBottom - nWidthOffset) && (nY <= nRectBottom + nWidthOffset))
                        {
                            nOnBounds = ImageBoxBounds.BottomLeft;
                            return true;
                        }
                    }

                    // Bottom right bounds width check.
                    if ((nX >= nRectRight - nWidthOffset) && (nX <= nRectRight + nWidthOffset))
                    {
                        // bottom right bounds height check.
                        if ((nY >= nRectBottom - nWidthOffset) && (nY <= nRectBottom + nWidthOffset))
                        {
                            nOnBounds = ImageBoxBounds.BottomRight;
                            return true;
                        }
                    }
                }
            }

            nOnBounds = ImageBoxBounds.None;

            return false;
        }

        /// <summary>
        /// Returns true if the specified coordinates (X, Y) are within the bounds 
        /// of the image box.
        /// </summary>
        /// <param name="nX">Specified X position.</param>
        /// <param name="nY">Specified Y position.</param>
        /// <returns></returns>
        private bool IsMouseInImageBoxBounds(int nX, int nY, int nOffset)
        {
            int nRectBottom = m_ImageBoxRect.Bottom;
            int nRectRight = m_ImageBoxRect.Right;
            int nRectPosX = m_ImageBoxRect.X;
            int nRectPosY = m_ImageBoxRect.Y;
            int nRectWidth = m_ImageBoxRect.Width;
            int nRectHeight = m_ImageBoxRect.Height;

            if ((nRectWidth > 0) & (nRectHeight > 0))
            {
                if ((nX >= nRectPosX + nOffset) && (nX <= nRectRight - nOffset))
                {
                    if ((nY >= nRectPosY + nOffset) && (nY <= nRectBottom - nOffset))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion
    }
}