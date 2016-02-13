//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ProcessingDialog.cs
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
//:: Created On: 23 May 2011
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
using IView.Engine.Data;
using IView.Engine.Processing;
using IView.UI.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides a simple dialog allowing the user to adjust settings for image processing.
    /// </summary>
    public partial class ProcessingDialog : Form
    {
        #region Fields and properties

        private ControlSet m_nControlSet;
        private Bitmap m_oBitmap = null;

        /// <summary>
        /// Gets the Red property.
        /// </summary>
        public int Red
        {
            get { return tbar_Red.Value; }
        }

        /// <summary>
        /// Gets the Green property.
        /// </summary>
        public int Green
        {
            get { return tbar_Green.Value; }
        }

        /// <summary>
        /// Gets the Blue property.
        /// </summary>
        public int Blue
        {
            get { return tbar_Blue.Value; }
        }

        /// <summary>
        /// Gets the Brightness property.
        /// </summary>
        public int Brightness
        {
            get { return tbar_Brightness.Value; }
        }

        /// <summary>
        /// Gets the Contrast property.
        /// </summary>
        public int Contrast
        {
            get { return tbar_Contrast.Value; }
        }

        /// <summary>
        /// Gets the Noise property.
        /// </summary>
        public int Noise
        {
            get { return tbar_Noise.Value; }
        }

        /// <summary>
        /// Gets the Gamma property.
        /// </summary>
        public double Gamma
        {
            get { return (double)nud_Gamma.Value; }
        }

        /// <summary>
        /// Gets the Transparency property.
        /// </summary>
        public byte Transparency
        {
            get { return (byte)tbar_Transparency.Value; }
        }

        /// <summary>
        /// Gets the Threshold property.
        /// </summary>
        public byte Threshold
        {
            get { return (byte)tbar_Threshold.Value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public ControlSet CurrentControlSet
        {
            get { return m_nControlSet; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public ProcessingDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oImage"></param>
        /// <param name="nControlSet"></param>
        public ProcessingDialog(Image oImage, ControlSet nControlSet)
        {
            InitializeComponent();

            tc_Main.TabPages.Clear();

            switch (nControlSet)
            {
                case ControlSet.BrightnessContrast:
                    tc_Main.TabPages.Add(tp_BrightnessContrast);
                    break;
                case ControlSet.ColourBalance:
                    tc_Main.TabPages.Add(tp_ColourBalance);
                    break;
                case ControlSet.Gamma:
                    tc_Main.TabPages.Add(tp_Gamma);
                    break;
                case ControlSet.Transparency:
                    tc_Main.TabPages.Add(tp_Transparency);
                    break;
                case ControlSet.Noise:
                    tc_Main.TabPages.Add(tp_Noise);
                    break;
            }

            if (oImage != null)
            {
                m_nControlSet = nControlSet;
                m_oBitmap =
                    DrawingTools.CreateThumbnail(oImage, pan_Before.Size, false, ThumbnailEffect.None);

                pan_Before.BackgroundImage = new Bitmap(m_oBitmap, m_oBitmap.Size);
                pan_After.BackgroundImage = new Bitmap(m_oBitmap, m_oBitmap.Size);
            }
            else
            {
                pan_Before.BackgroundImage =
                    DrawingTools.CreateTextBitmap("No Preview.", this.Font, Color.Black, Color.White);
                pan_After.BackgroundImage =
                    DrawingTools.CreateTextBitmap("No Preview.", this.Font, Color.Black, Color.White);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oImage"></param>
        private void UpdatePreview(Image oImage)
        {
            if (oImage != null)
            {
                if (pan_After.BackgroundImage != null)
                {
                    pan_After.BackgroundImage.Dispose();
                    pan_After.BackgroundImage = null;
                }

                pan_After.BackgroundImage =
                    DrawingTools.CreateThumbnail(oImage, pan_After.Size, false, ThumbnailEffect.None);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CleanUp()
        {
            if (m_oBitmap != null)
            {
                m_oBitmap.Dispose();
                m_oBitmap = null;
            }

            if (pan_Before.BackgroundImage != null)
            {
                pan_Before.BackgroundImage.Dispose();
                pan_Before.BackgroundImage = null;
            }

            if (pan_After.BackgroundImage != null)
            {
                pan_After.BackgroundImage.Dispose();
                pan_After.BackgroundImage = null;
            }
        }

        #endregion

        #region Control events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_Red_ValueChanged(object sender, EventArgs e)
        {
            if (m_oBitmap == null)
                return;

            // Update the associated numeric up down control if the trackbar has focus.
            if (tbar_Red.Focused)
                nud_Red.Value = tbar_Red.Value;

            // Apply the processing.
            using (ImageProcessing oProcessing = new ImageProcessing(m_oBitmap))
            {
                oProcessing.AdjustColour(tbar_Red.Value, tbar_Green.Value, tbar_Blue.Value);
                UpdatePreview(oProcessing.GetProcessedImage());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_Green_ValueChanged(object sender, EventArgs e)
        {
            if (m_oBitmap == null)
                return;

            // Update the associated numeric up down control if the trackbar has focus.
            if (tbar_Green.Focused)
                nud_Green.Value = tbar_Green.Value;

            // Apply the processing.
            using (ImageProcessing oProcessing = new ImageProcessing(m_oBitmap))
            {
                oProcessing.AdjustColour(tbar_Red.Value, tbar_Green.Value, tbar_Blue.Value);
                UpdatePreview(oProcessing.GetProcessedImage());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_Blue_ValueChanged(object sender, EventArgs e)
        {
            if (m_oBitmap == null)
                return;

            // Update the associated numeric up down control if the trackbar has focus.
            if (tbar_Blue.Focused)
                nud_Blue.Value = tbar_Blue.Value;

            // Apply the processing.
            using (ImageProcessing oProcessing = new ImageProcessing(m_oBitmap))
            {
                oProcessing.AdjustColour(tbar_Red.Value, tbar_Green.Value, tbar_Blue.Value);
                UpdatePreview(oProcessing.GetProcessedImage());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Red_ValueChanged(object sender, EventArgs e)
        {
            // Update the associated trackbar if the numeric up down control has focus.
            if (nud_Red.Focused)
                tbar_Red.Value = (int)nud_Red.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Green_ValueChanged(object sender, EventArgs e)
        {
            // Update the associated trackbar if the numeric up down control has focus.
            if (nud_Green.Focused)
                tbar_Green.Value = (int)nud_Green.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Blue_ValueChanged(object sender, EventArgs e)
        {
            // Update the associated trackbar if the numeric up down control has focus.
            if (nud_Blue.Focused)
                tbar_Blue.Value = (int)nud_Blue.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_Brightness_ValueChanged(object sender, EventArgs e)
        {
            if (m_oBitmap == null)
                return;

            // Update the associated numeric up down control if the trackbar has focus.
            if (tbar_Brightness.Focused)
                nud_Brightness.Value = tbar_Brightness.Value;

            // Apply the processing.
            using (ImageProcessing oProcessing = new ImageProcessing(m_oBitmap))
            {
                // Must call first.
                if (tbar_Contrast.Value != 0)
                    oProcessing.AdjustContrast(tbar_Contrast.Value);

                // Must call second.
                oProcessing.AdjustBrightness(tbar_Brightness.Value);

                UpdatePreview(oProcessing.GetProcessedImage());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_Contrast_ValueChanged(object sender, EventArgs e)
        {
            if (m_oBitmap == null)
                return;

            // Update the associated numeric up down control if the trackbar has focus.
            if (tbar_Contrast.Focused)
                nud_Contrast.Value = tbar_Contrast.Value;

            // Apply the processing.
            using (ImageProcessing oProcessing = new ImageProcessing(m_oBitmap))
            {
                // Must call first.
                oProcessing.AdjustContrast(tbar_Contrast.Value);

                // Must call second.
                if (tbar_Brightness.Value != 0)
                    oProcessing.AdjustBrightness(tbar_Brightness.Value);

                UpdatePreview(oProcessing.GetProcessedImage());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Brightness_ValueChanged(object sender, EventArgs e)
        {
            // Update the associated trackbar if the numeric up down control has focus.
            if (nud_Brightness.Focused)
                tbar_Brightness.Value = (int)nud_Brightness.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Contrast_ValueChanged(object sender, EventArgs e)
        {
            // Update the associated trackbar if the numeric up down control has focus.
            if (nud_Contrast.Focused)
                tbar_Contrast.Value = (int)nud_Contrast.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_Gamma_ValueChanged(object sender, EventArgs e)
        {
            if (m_oBitmap == null)
                return;

            double fVal = (double)tbar_Gamma.Value / 100;

            // Update the associated numeric up down control if the trackbar has focus.
            if (tbar_Gamma.Focused)
                nud_Gamma.Value = (decimal)fVal;

            // Apply the processing.
            using (ImageProcessing oProcessing = new ImageProcessing(m_oBitmap))
            {
                oProcessing.AdjustGamma(fVal, fVal, fVal);
                UpdatePreview(oProcessing.GetProcessedImage());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Gamma_ValueChanged(object sender, EventArgs e)
        {
            // Update the associated trackbar if the numeric up down control has focus.
            if (nud_Gamma.Focused)
                tbar_Gamma.Value = (int)(nud_Gamma.Value * 100);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_Transparancy_ValueChanged(object sender, EventArgs e)
        {
            if (m_oBitmap == null)
                return;

            // Update the associated numeric up down control if the trackbar has focus.
            if (tbar_Transparency.Focused)
                nud_Transparency.Value = (decimal)(100 / (255.0f / (float)tbar_Transparency.Value));

            // Apply the processing.
            using (ImageProcessing oProcessing = new ImageProcessing(m_oBitmap))
            {
                oProcessing.AdjustTransparency((byte)tbar_Transparency.Value, (byte)tbar_Threshold.Value);
                UpdatePreview(oProcessing.GetProcessedImage());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Transparency_ValueChanged(object sender, EventArgs e)
        {
            // Update the associated trackbar if the numeric up down control has focus.
            if (nud_Transparency.Focused)
                tbar_Transparency.Value = (int)(((float)nud_Transparency.Value / 100.0f) * 255);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_Threshold_ValueChanged(object sender, EventArgs e)
        {
            if (m_oBitmap == null)
                return;

            byte nValue = (byte)tbar_Transparency.Value;
            byte nThreshold = (byte)tbar_Threshold.Value;

            // Update the associated numeric up down control if the trackbar has focus.
            if (tbar_Threshold.Focused)
                nud_Threshold.Value = nThreshold;

            // Apply the processing.
            using (ImageProcessing oProcessing = new ImageProcessing(m_oBitmap))
            {
                oProcessing.AdjustTransparency(nValue, nThreshold);
                UpdatePreview(oProcessing.GetProcessedImage());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Threshold_ValueChanged(object sender, EventArgs e)
        {
            // Update the associated trackbar if the numeric up down control has focus.
            if (nud_Threshold.Focused)
                tbar_Threshold.Value = (int)nud_Threshold.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbar_Noise_ValueChanged(object sender, EventArgs e)
        {
            // Update the associated numeric up down control if the trackbar has focus.
            if (tbar_Noise.Focused)
                nud_Noise.Value = tbar_Noise.Value;

            // Apply the processing.
            using (ImageProcessing oProcessing = new ImageProcessing(m_oBitmap))
            {
                oProcessing.ApplyNoiseFilter(tbar_Noise.Value);
                UpdatePreview(oProcessing.GetProcessedImage());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nud_Noise_ValueChanged(object sender, EventArgs e)
        {
            // Update the associated trackbar if the numeric up down control has focus.
            if (nud_Noise.Focused)
                tbar_Noise.Value = (int)nud_Noise.Value;
        }

        #endregion
    }
}
