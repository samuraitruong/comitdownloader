//::///////////////////////////////////////////////////////////////////////////
//:: File Name: PropertiesPanel.cs
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
using System.Drawing;
using System.Windows.Forms;
using IView.Engine.Core;
using IView.Controls.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// Provides a custom, user derived control that displays data about the current image and other properties.
    /// </summary>
    public partial class PropertiesPanel : UserControl
    {
        #region Fields and properties

        private ImageProperties m_oProperties;

        /// <summary>
        /// Gets or sets a value indicating whether Auto Refresh is enabled.
        /// </summary>
        public bool HistogramAutoRefresh
        {
            get { return hp_Histogram.AutoRefreshEnabled; }
            set { hp_Histogram.AutoRefreshEnabled = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the Histogram is visible.
        /// </summary>
        public bool HistogramVisible
        {
            get { return (!sc_Main.Panel2Collapsed); }
            set { sc_Main.Panel2Collapsed = (!value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the properties help bar is visible.
        /// </summary>
        public bool PropertiesToolbarVisible
        {
            get { return pg_Info.ToolbarVisible; }
            set { pg_Info.ToolbarVisible = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the properties help panel is visible.
        /// </summary>
        public bool PropertiesHelpVisible
        {
            get { return pg_Info.HelpVisible; }
            set { pg_Info.HelpVisible = value; }
        }

        /// <summary>
        /// Gets or sets the location of the splitter, in pixels, from the top left edge of the container.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public int SplitterDistance
        {
            get { return sc_Main.SplitterDistance; }
            set
            {
                try
                {
                    sc_Main.SplitterDistance = value;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets a Channels enumeration value specified by the selected item in channels combobox.
        /// </summary>
        public Channels HistogramChannel
        {
            get { return hp_Histogram.CurrentChannel; }
        }

        /// <summary>
        /// Gets or sets the ImageProperties property.
        /// </summary>
        public ImageProperties Properties
        {
            get { return m_oProperties; }
            set
            {
                m_oProperties = value;
                pg_Info.SelectedObject = value;
            }
        }

        /// <summary>
        /// Fires when there is a request from the histogram to update.
        /// </summary>
        public event EventHandler<EventArgs> HistogramUpdateRequested;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the PropertiesPanel initialized with default values.
        /// </summary>
        public PropertiesPanel()
        {
            InitializeComponent();

            m_oProperties = new ImageProperties();
        }

        /// <summary>
        /// Creates a new instance of the PropertiesPanel class initialized with the specified parameters.
        /// </summary>
        /// <param name="oProperties"></param>
        public PropertiesPanel(ImageProperties oProperties)
        {
            InitializeComponent();

            if (oProperties != null)
            {
                m_oProperties = oProperties;
            }
            else
                throw new ArgumentNullException("oProperties", "The specified parameter cannot be null.");
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oBitmap"></param>
        public void ProcessImage(Bitmap oBitmap)
        {
            hp_Histogram.ProcessImage(oBitmap);
        }

        /// <summary>
        /// Resets all the properties information.
        /// </summary>
        public void Reset()
        {
            pg_Info.SelectedObject = null;
            hp_Histogram.ProcessImage(null);
        }

        #endregion

        #region Context menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cms_Main_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            tsmi_PropertiesToolbar.Checked = pg_Info.ToolbarVisible;
            tsmi_PropertiesHelpPanel.Checked = pg_Info.HelpVisible;
            tsmi_Histogram.Checked = (!sc_Main.Panel2Collapsed);
            tsmi_AnchorHistogram.Checked = (sc_Main.FixedPanel == FixedPanel.Panel2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_PropertiesToolbar_Click(object sender, EventArgs e)
        {
            pg_Info.ToolbarVisible = (!pg_Info.ToolbarVisible);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_PropertiesHelpPanel_Click(object sender, EventArgs e)
        {
            pg_Info.HelpVisible = (!pg_Info.HelpVisible);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_Histogram_Click(object sender, EventArgs e)
        {
            sc_Main.Panel2Collapsed = (!sc_Main.Panel2Collapsed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_AnchorHistogram_Click(object sender, EventArgs e)
        {
            sc_Main.FixedPanel = (sc_Main.FixedPanel != FixedPanel.Panel2) ? FixedPanel.Panel2 : FixedPanel.None;
        }

        #endregion

        #region Histogram events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hp_Histogram_UpdateRequested(object sender, EventArgs e)
        {
            if (HistogramUpdateRequested != null)
                HistogramUpdateRequested(sender, e);
        }

        #endregion
    }
}
