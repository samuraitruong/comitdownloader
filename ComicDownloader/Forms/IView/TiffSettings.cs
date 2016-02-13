//::///////////////////////////////////////////////////////////////////////////
//:: File Name: TiffSettings.cs
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
using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides the user with a dialog form allowing them to adjust the Tiff save settings.
    /// </summary>
    public partial class TiffSettings : Form
    {
        #region Fields and properties

        private static bool m_bPreserveMetadata = true;
        private static BitDepth m_nBitDepth = BitDepth.BPP32;
        private static TiffCompression m_nCompression = TiffCompression.None;

        /// <summary>
        /// Gets a value indicating whether to preserve any EXIF meta data.
        /// </summary>
        public bool PreserveMetadata
        {
            get { return m_bPreserveMetadata; }
        }

        /// <summary>
        /// Gets the currently selected BitDepth property.
        /// </summary>
        public BitDepth SelectedBitDepth
        {
            get { return m_nBitDepth; }
        }

        /// <summary>
        /// Gets the currently selected TiffCompression property.
        /// </summary>
        public TiffCompression SelectedCompression
        {
            get { return m_nCompression; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the TiffSettings class initialized with default values.
        /// </summary>
        public TiffSettings()
        {
            InitializeComponent();

            ckb_PreserveData.Checked = m_bPreserveMetadata;

            // Update the BitDepth radio buttons.
            switch (m_nBitDepth)
            {
                case BitDepth.BPP32:
                    rbtn_32Bits.Checked = true;
                    break;
                case BitDepth.BPP24:
                    rbtn_24Bits.Checked = true;
                    break;
            }

            // Update the compression radio buttons.
            switch (m_nCompression)
            {
                case TiffCompression.None:
                    rbtn_CompressionNone.Checked = true;
                    break;
                case TiffCompression.CCITT3:
                    rbtn_CompressionCCITT3.Checked = true;
                    break;
                case TiffCompression.CCITT4:
                    rbtn_CompressionCCITT4.Checked = true;
                    break;
                case TiffCompression.LZW:
                    rbtn_CompressionLZW.Checked = true;
                    break;
                case TiffCompression.Rle:
                    rbtn_CompressionRle.Checked = true;
                    break;
            }
        }

        #endregion

        #region Form control events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            // Preserve meta data.
            m_bPreserveMetadata = ckb_PreserveData.Checked;

            // Bit depth.
            if (rbtn_32Bits.Checked)
                m_nBitDepth = BitDepth.BPP32;
            else if (rbtn_24Bits.Checked)
                m_nBitDepth = BitDepth.BPP24;

            //Compression.
            if (rbtn_CompressionNone.Checked)
                m_nCompression = TiffCompression.None;
            else if (rbtn_CompressionCCITT3.Checked)
                m_nCompression = TiffCompression.CCITT3;
            else if (rbtn_CompressionCCITT4.Checked)
                m_nCompression = TiffCompression.CCITT4;
            else if (rbtn_CompressionLZW.Checked)
                m_nCompression = TiffCompression.LZW;
            else if (rbtn_CompressionRle.Checked)
                m_nCompression = TiffCompression.Rle;

            this.Close();
        }

        #endregion
    }
}
