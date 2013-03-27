//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ResizePanel.cs
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
using System.Windows.Forms;
using IView.Controls.Data;
using ComicDownloader.Properties;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// Provides a series of controls allowing the user to specify a new size for an image.
    /// </summary>
    public partial class ResizePanel : UserControl
    {
        #region Fields and properties

        private const int MIN_IMAGE_WIDTH = 0;
        private const int MIN_IMAGE_HEIGHT = 0;
        private const int MAX_IMAGE_WIDTH = 10000;
        private const int MAX_IMAGE_HEIGHT = 10000;

        private bool m_bLockScale = true;
        private Size m_OriginalSize;
        private Size m_NewSize;
        private ResizeQuality m_nQuality;

        /// <summary>
        /// Gets or sets the original size property. Setting this member to empty will reset the controls data and child controls.
        /// </summary>
        public Size OriginalSize
        {
            get { return m_OriginalSize; }
            set
            {
                if (!value.IsEmpty)
                {
                    m_OriginalSize = value;

                    rbtn_OriginalSize.Text = "Original size: ("
                        + value.Width + " x " + value.Height + ")";

                    num_Width.Value = value.Width;
                    num_Height.Value = value.Height;

                    rbtn_OriginalSize.Enabled = true;
                    rbtn_PredefinedSize.Enabled = true;
                    rbtn_CustomSize.Enabled = true;
                }
                else
                {
                    rbtn_OriginalSize.Text = "Original size";
                    rbtn_OriginalSize.Enabled = false;
                    rbtn_OriginalSize.Checked = true;
                    rbtn_PredefinedSize.Enabled = false;
                    rbtn_CustomSize.Enabled = false;
                    btn_Apply.Enabled = false;
                    cbx_Interpolation.Enabled = false;
                    cbx_PredefinedSizes.Enabled = false;
                    num_Width.Enabled = false;
                    num_Width.Value = MIN_IMAGE_WIDTH;
                    num_Height.Enabled = false;
                    num_Height.Value = MIN_IMAGE_HEIGHT;
                    btn_LockScale.Enabled = false;
                    lbl_NewSize.Text = "Size: 0 x 0 px";
                }
            }
        }

        /// <summary>
        /// Gets the new size for the image to be resized.
        /// </summary>
        public Size NewSize
        {
            get { return m_NewSize; }
        }

        /// <summary>
        /// Gets the resize quality for the image to be resized.
        /// </summary>
        public ResizeQuality Quality
        {
            get { return m_nQuality; }
            set { m_nQuality = value; }
        }

        /// <summary>
        /// Fires when the OK button has been clicked.
        /// </summary>
        public event EventHandler<EventArgs> ApplyButtonClicked;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ResizePanel class initialized with default values.
        /// </summary>
        public ResizePanel()
        {
            InitializeComponent();

            m_nQuality = ResizeQuality.Default;

            num_Height.Minimum = MIN_IMAGE_HEIGHT;
            num_Height.Maximum = MAX_IMAGE_HEIGHT;

            num_Width.Minimum = MIN_IMAGE_WIDTH;
            num_Width.Maximum = MAX_IMAGE_WIDTH;

            // Add the predefined size items to the combobox.
            cbx_PredefinedSizes.Items.AddRange(new string[]
            {
                "1360 x 768 px",
                "1280 x 720 px",
                "1024 x 768 px",
                "800 x 600 px",
                "640 x 480 px",
                "256 x 256 px",
                "128 x 128 px",
                "64 x 64 px",
                "48 x 48 px",
                "32 x 32 px",
                "16 x 16 px"
            });
            cbx_PredefinedSizes.SelectedIndex = 0;

            // Add the interpolation items to the combobox.
            cbx_Interpolation.Items.AddRange(Enum.GetNames(typeof(ResizeQuality)));
            cbx_Interpolation.SelectedIndex = 0;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nWidth"></param>
        /// <param name="nHeight"></param>
        /// <param name="nDestWidth"></param>
        /// <param name="nDestHeight"></param>
        /// <returns></returns>
        public static Size ScaleTest(int nWidth, int nHeight, int nDestWidth, int nDestHeight)
        {
            float fNewWidth = 0.0f;
            float fNewHeight = 0.0f;
            float fWidthPercent = (float)nWidth / nDestWidth;
            float fHeightPercent = (float)nHeight / nDestHeight;

            fNewWidth = nWidth / fHeightPercent;
            fNewHeight = nHeight / fWidthPercent;

            return new Size((int)Math.Round(fNewWidth), (int)Math.Round(fNewHeight));
        }

        /// <summary>
        /// Returns a size structure by parsing the predefined size string. The format of this string should be (width x height px).
        /// </summary>
        /// <param name="sPredefinedSize">Specifies the string to parse.</param>
        /// <returns></returns>
        private Size ParsePredefinedSize(string sPredefinedSize)
        {
            if (!string.IsNullOrEmpty(sPredefinedSize))
            {
                string[] sSize = sPredefinedSize.Trim().Split(new char[] { ' ' });

                if (sSize.Length == 4)
                {
                    int nWidth = 0;
                    int nHeight = 0;

                    // Validate the values
                    if (!int.TryParse(sSize[0], out nWidth))
                        return Size.Empty;
                    if (!int.TryParse(sSize[2], out nHeight))
                        return Size.Empty;

                    // return the size.
                    return new Size(nWidth, nHeight);
                }
            }

            return Size.Empty;
        }

        #endregion

        #region Control events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton oRadioButton = sender as RadioButton;

            if (oRadioButton == null)
                return;

            switch (oRadioButton.Name)
            {
                case "rbtn_OriginalSize":
                    m_NewSize = Size.Empty;
                    btn_Apply.Enabled = false;
                    cbx_Interpolation.Enabled = false;
                    cbx_PredefinedSizes.Enabled = false;
                    num_Width.Enabled = false;
                    num_Height.Enabled = false;
                    btn_LockScale.Enabled = false;
                    break;
                case "rbtn_PredefinedSize":
                    m_NewSize = ParsePredefinedSize((string)cbx_PredefinedSizes.SelectedItem);
                    btn_Apply.Enabled = true;
                    cbx_Interpolation.Enabled = true;
                    cbx_PredefinedSizes.Enabled = true;
                    num_Width.Enabled = false;
                    num_Height.Enabled = false;
                    btn_LockScale.Enabled = false;
                    break;
                case "rbtn_CustomSize":
                    m_NewSize = new Size((int)num_Width.Value, (int)num_Height.Value);
                    btn_Apply.Enabled = true;
                    cbx_Interpolation.Enabled = true;
                    cbx_PredefinedSizes.Enabled = false;
                    num_Width.Enabled = true;
                    num_Height.Enabled = true;
                    btn_LockScale.Enabled = true;
                    break;
            }

            lbl_NewSize.Text = "Size: " + m_NewSize.Width + " x " + m_NewSize.Height + " px";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void num_Width_ValueChanged(object sender, EventArgs e)
        {
            if (rbtn_CustomSize.Checked)
            {
                if (m_bLockScale)
                {
                    m_NewSize = ScaleTest(m_OriginalSize.Width, m_OriginalSize.Height,
                        (int)num_Width.Value, (int)num_Height.Value);
                    
                    num_Height.Value = m_NewSize.Height;
                }
                else
                    m_NewSize = new Size((int)num_Width.Value, (int)num_Height.Value);

                lbl_NewSize.Text = "Size: " + m_NewSize.Width + " x " + m_NewSize.Height + " px";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void num_Height_ValueChanged(object sender, EventArgs e)
        {
            if (rbtn_CustomSize.Checked)
            {
                if (m_bLockScale)
                {
                    m_NewSize = ScaleTest(m_OriginalSize.Width, m_OriginalSize.Height,
                        (int)num_Width.Value, (int)num_Height.Value);

                    num_Width.Value = m_NewSize.Width;
                }
                else
                    m_NewSize = new Size((int)num_Width.Value, (int)num_Height.Value);

                lbl_NewSize.Text = "New Size: " + m_NewSize.Width + " x " + m_NewSize.Height + " px";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LockScale_Click(object sender, EventArgs e)
        {
            switch (m_bLockScale = (!m_bLockScale))
            {
                case true:
                    btn_LockScale.Image = Resources.locked_16x16;
                    break;
                case false:
                    btn_LockScale.Image = Resources.unlocked_16x16;
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_PredefinedSizes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_PredefinedSizes.Focused)
            {
                string sItem = (string)cbx_PredefinedSizes.SelectedItem;

                // Update field members.
                m_NewSize = ParsePredefinedSize(sItem);

                // Update controls and labels.
                lbl_NewSize.Text = "Size: " + m_NewSize.Width + " x " + m_NewSize.Height + " px";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbx_Interpolation_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sItem = (string)cbx_Interpolation.SelectedItem;

            foreach (string sResizeMode in Enum.GetNames(typeof(ResizeQuality)))
            {
                if (sItem == sResizeMode)
                {
                    m_nQuality = (ResizeQuality)Enum.Parse(typeof(ResizeQuality), sResizeMode);
                    lbl_Quality.Text = "Quality: " + sResizeMode;
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (ApplyButtonClicked != null)
                ApplyButtonClicked(sender, EventArgs.Empty);
        }

        #endregion 
    }
}
