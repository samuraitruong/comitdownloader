//::///////////////////////////////////////////////////////////////////////////
//:: File Name: JpegSettings.cs
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
//:: Created On: 4 April 2011
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
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides the user with a dialog form allowing them to adjust the Jpeg save settings.
    /// </summary>
    public partial class JpegSettings : Form
    {
        #region Fields and properties

        private static bool m_bPreserveMetadata = true;
        private static int m_nLastQualityValue = 80;

        /// <summary>
        /// Gets a value indicating whether to preserve any EXIF meta data.
        /// </summary>
        public bool PreserveMetadata
        {
            get { return m_bPreserveMetadata; }
        }

        /// <summary>
        /// Gets the quality value property.
        /// </summary>
        public int Quality
        {
            get { return tbar_QualityValue.Value; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the JpegSettings class initialized with default values.
        /// </summary>
        public JpegSettings()
        {
            InitializeComponent();

            ckb_PreserveData.Checked = m_bPreserveMetadata;
            tbar_QualityValue.Value = m_nLastQualityValue;
        }

        #endregion

        #region Form control events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_QualityValue_ValueChanged(object sender, EventArgs e)
        {
            lbl_ValueInfo.Text = "Value: " + tbar_QualityValue.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            // Preserve meta data.
            m_bPreserveMetadata = ckb_PreserveData.Checked;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            m_nLastQualityValue = tbar_QualityValue.Value;

            base.OnFormClosed(e);
        }

        #endregion
    }
}
