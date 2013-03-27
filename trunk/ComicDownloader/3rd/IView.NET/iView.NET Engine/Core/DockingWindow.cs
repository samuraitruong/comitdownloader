//::///////////////////////////////////////////////////////////////////////////
//:: File Name: DockingWindow.cs
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
//#define DEBUG_DATA
#define DEVELOPER_VERSION
#define END_USER_VERSION
//::///////////////////////////////////////////////////////////////////////////
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System;
using System.Drawing;
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides properties and methods for creating a dockable window.
    /// </summary>
    public class DockingWindow : IDockable
    {
        #region Fields and properties

        private bool m_bIsDisposed;
        private bool m_bIsDocked;
        private Point m_Location;
        private Size m_Size;
        private Form m_oDockingWindow;
        private Control m_oParent;
        private Control[] m_oControls;

        /// <summary>
        /// Gets a value indicating whether dispose has ben called on this object.
        /// </summary>
        public bool IsDisposed
        {
            get { return m_bIsDisposed; }
        }

        /// <summary>
        /// Gets a value indicating whether the window is currently docked.
        /// </summary>
        public bool IsDocked
        {
            get { return m_bIsDocked; }
        }

        /// <summary>
        /// Gets or sets the name of the docking window.
        /// </summary>
        public string Name
        {
            get { return m_oDockingWindow.Name; }
            set { m_oDockingWindow.Name = value; }
        }

        /// <summary>
        /// Gets or sets the docking window text.
        /// </summary>
        public string Text
        {
            get { return m_oDockingWindow.Text; }
            set { m_oDockingWindow.Text = value; }
        }
        
        /// <summary>
        /// Gets or sets the window state of the docking window.
        /// </summary>
        public FormWindowState WindowState
        {
            get { return m_oDockingWindow.WindowState; }
            set { m_oDockingWindow.WindowState = value; }
        }

        /// <summary>
        /// Gets or sets the position of the docking window.
        /// </summary>
        public Point WindowPosition
        {
            get { return m_oDockingWindow.Location; }
            set { m_oDockingWindow.Location = value; }
        }

        /// <summary>
        /// Gets oe sets the size of the docking window.
        /// </summary>
        public Size WindowSize
        {
            get { return m_oDockingWindow.Size; }
            set { m_oDockingWindow.Size = value; }
        }

        /// <summary>
        /// Gets or sets the desktop bounds of the docking window.
        /// </summary>
        public Rectangle WindowBounds
        {
            get { return m_oDockingWindow.DesktopBounds; }
            set { m_oDockingWindow.DesktopBounds = value; }
        }

        /// <summary>
        /// Gets or sets the form that owns this docking window.
        /// </summary>
        public Form Owner
        {
            get { return m_oDockingWindow.Owner; }
            set { m_oDockingWindow.Owner = value; }
        }

        /// <summary>
        /// Fires when the docking window dock state has changed.
        /// </summary>
        public event EventHandler<DockChangedEventArgs> DockChanged;

        #endregion

        #region Constructors and destructors

        /// <summary>
        /// Creates a new instance of the DockingWindow class initialized with the speicified parameters.
        /// </summary>
        /// <param name="oParent">Specifies the parent control hosting the child controls.</param>
        /// <param name="oControls">Specifies the child controls to move to the docking window.</param>
        public DockingWindow(Control oParent, Control[] oControls)
        {
            m_bIsDocked = true;
            m_oParent = oParent;
            m_oControls = oControls;

            InitDockingWindow();
        }

        /// <summary>
        /// Creates a new instance of the DockingWindow class initialized with the speicified parameters.
        /// </summary>
        /// <param name="Window">Specifies the size and location of the initial window.</param>
        /// <param name="oParent">Specifies the parent control hosting the child controls.</param>
        /// <param name="oControls">Specifies the child controls to move to the docking window.</param>
        public DockingWindow(Rectangle Window, Control oParent, Control[] oControls)
        {
            m_Size = Window.Size;
            m_Location = Window.Location;
            m_bIsDocked = true;
            m_oParent = oParent;
            m_oControls = oControls;

            InitDockingWindow();
        }

        /// <summary>
        /// Class destructor.
        /// </summary>
        ~DockingWindow()
        {
            Dispose(false);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the docking window form.
        /// </summary>
        private void InitDockingWindow()
        {
            m_oDockingWindow = new Form();
            m_oDockingWindow.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            m_oDockingWindow.ShowIcon = false;
            m_oDockingWindow.ShowInTaskbar = false;
            m_oDockingWindow.StartPosition = (m_Location == Point.Empty) ? FormStartPosition.WindowsDefaultLocation : FormStartPosition.Manual;
            m_oDockingWindow.Size = m_Size;
            m_oDockingWindow.MinimumSize = new Size(150, 150);
            m_oDockingWindow.Location = m_Location;
            m_oDockingWindow.FormClosing += delegate(object sender, FormClosingEventArgs e)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;

                    if ((m_oParent != null) && (!m_bIsDocked))
                    {
                        m_bIsDocked = true;
                        m_oDockingWindow.Hide();

                        if (m_oParent != null)
                            m_oParent.Controls.AddRange(m_oControls);

                        // Fire the dock changed event.
                        OnDockChanged(this, new DockChangedEventArgs(true));
                    }
                }
            };
        }

        /// <summary>
        /// Docks the controls back to their parent container.
        /// </summary>
        public void Dock()
        {
            if ((m_oParent != null) && (!m_bIsDocked))
            {
                m_bIsDocked = true;
                m_oDockingWindow.Hide();

                if (m_oParent != null)
                    m_oParent.Controls.AddRange(m_oControls);

                // Fire the dock changed event.
                OnDockChanged(this, new DockChangedEventArgs(false));
            }            
        }

        /// <summary>
        /// Removes the child controls from the parent container to a docking window.
        /// </summary>
        public void UnDock()
        {
            if (m_bIsDocked)
            {
                // Set the dock flag to false
                m_bIsDocked = false;

                // Add the controls to the docking window.
                m_oDockingWindow.Controls.AddRange(m_oControls);
                m_oDockingWindow.Show();

                // Fire the dock changed event.
                OnDockChanged(this, new DockChangedEventArgs());
            }
        }

        /// <summary>
        /// Removes the child controls from the parent container to a docking window that has the specified owner.
        /// </summary>
        /// <param name="oOwner">Specifies the owner of the docking window.</param>
        public void UnDock(Form oOwner)
        {
            if (m_bIsDocked)
            {
                // Set the dock flag to false
                m_bIsDocked = false;

                // Add the controls to the docking window.
                m_oDockingWindow.Controls.AddRange(m_oControls);
                m_oDockingWindow.Show(oOwner);

                // Fire the dock changed event.
                OnDockChanged(this, new DockChangedEventArgs());
            }
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
                    if ((m_oDockingWindow != null) && (!m_oDockingWindow.IsDisposed))
                        m_oDockingWindow.Close();

                    #if DEBUG_DATA
                    System.Diagnostics.Debug.WriteLine(m_oDockingWindow.Name
                        + " docking window has been disposed.");
                    #endif
                }
            }

            m_bIsDisposed = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnDockChanged(object sender, DockChangedEventArgs e)
        {
            if (DockChanged != null)
                DockChanged(sender, e);
        }

        #endregion
    }
}
