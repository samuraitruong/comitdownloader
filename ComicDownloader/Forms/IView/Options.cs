//::///////////////////////////////////////////////////////////////////////////
//:: File Name: Options.cs
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
//:: Created On: 26 April 2011
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
using IView.Engine.Core;
using IView.UI.Data;

using IView.Engine.Data;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides a dialog allowing the user to adjust the applicaton settings.
    /// </summary>
    public partial class Options : Form
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of the Options class initialized with default values.
        /// </summary>
        public Options()
        {
            InitializeComponent();

            //ckb_HighQualityThumbnails.Checked = Settings.Default.HighQualityThumbnails;
            //ckb_AutomaticUpdates.Checked = Settings.Default.AutomaticUpdates;
            //ckb_ImageListTooltips.Checked = Settings.Default.ImageListToolTips;
            //ckb_OpenNewWindowDoubleClick.Checked = Settings.Default.OpenNewWindowDoubleClick;
            //ckb_ShowConfirmOverwriteDialog.Checked = Settings.Default.ShowConfirmOverwriteDialog;
            //ckb_ShowImageChangesDialog.Checked = Settings.Default.ShowImageChangesDialog;

            //cbx_ColourSchemes.Items.AddRange(Enum.GetNames(typeof(ColourTable)));
            //cbx_ColourSchemes.SelectedIndex = (int)Settings.Default.ColourTable;
            //cbx_ThumbnailEffects.Items.AddRange(Enum.GetNames(typeof(ThumbnailEffect)));
            //cbx_ThumbnailEffects.SelectedIndex = (int)Settings.Default.ThumbnailEffect;
            //cpic_MainDisplayColour.SelectedColour = Settings.Default.MainDisplayColour;

            //nud_MaxFiles.Value = Settings.Default.MaxFiles;
            //nud_MaxSize.Value = Settings.Default.MaxFileLength / FileTools.LEN_MEGABYTE;
            //nud_MaxUndos.Value = Settings.Default.MaxUndos;
            //nud_NewWindows.Value = Settings.Default.MaxWindows;
        }

        #endregion

        #region Form controls events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Default_Click(object sender, EventArgs e)
        {
            ckb_HighQualityThumbnails.Checked = false;
            ckb_AutomaticUpdates.Checked = false;
            ckb_ImageListTooltips.Checked = true;
            ckb_OpenNewWindowDoubleClick.Checked = true;
            ckb_ShowConfirmOverwriteDialog.Checked = true;
            ckb_ShowImageChangesDialog.Checked = true;

            cbx_ColourSchemes.SelectedIndex = (int)ColourTable.SkyBlue;
            cbx_ThumbnailEffects.SelectedIndex = (int)ThumbnailEffect.DropShadow;
            cpic_MainDisplayColour.SelectedColour = System.Drawing.Color.White;

            nud_MaxFiles.Value = 1000;
            nud_MaxSize.Value = 5;
            nud_MaxUndos.Value = 10;
            nud_NewWindows.Value = 20;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            //Settings.Default.ColourTable = (ColourTable)cbx_ColourSchemes.SelectedIndex;
            //Settings.Default.ThumbnailEffect = (ThumbnailEffect)cbx_ThumbnailEffects.SelectedIndex;
            //Settings.Default.MainDisplayColour = cpic_MainDisplayColour.SelectedColour;
            //Settings.Default.HighQualityThumbnails = ckb_HighQualityThumbnails.Checked;
            //Settings.Default.AutomaticUpdates = ckb_AutomaticUpdates.Checked;
            //Settings.Default.ImageListToolTips = ckb_ImageListTooltips.Checked;
            //Settings.Default.OpenNewWindowDoubleClick = ckb_OpenNewWindowDoubleClick.Checked;
            //Settings.Default.ShowConfirmOverwriteDialog = ckb_ShowConfirmOverwriteDialog.Checked;
            //Settings.Default.ShowImageChangesDialog = ckb_ShowImageChangesDialog.Checked;
            //Settings.Default.MaxFiles = (int)nud_MaxFiles.Value;
            //Settings.Default.MaxFileLength = ((int)nud_MaxSize.Value * FileTools.LEN_MEGABYTE);
            //Settings.Default.MaxUndos = (int)nud_MaxUndos.Value;
            //Settings.Default.MaxWindows = (int)nud_NewWindows.Value;
            //Settings.Default.Save();
        }

        #endregion
    }
}
