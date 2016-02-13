//::///////////////////////////////////////////////////////////////////////////
//:: File Name: FavouriteDialog.cs
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
using System.Windows.Forms;
using IView.Engine.Core;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Forms
{
    /// <summary>
    /// Provides a way of adding or editing a favourite, by opening a dialog form and
    /// allowing the user to create a name and select a location.
    /// </summary>
    public partial class FavouriteDialog : Form
    {
        #region Fields and properties

        private Favourite m_oFavourite;

        /// <summary>
        /// Gets the new favourite that has been created by the user. Otherwise it returns null.
        /// </summary>
        public Favourite NewFavorite
        {
            get { return m_oFavourite; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the FavouriteDialog class initialized with the specified parameters.
        /// Path validation is not performed in this class. This should be done prior to adding a new Favourite to the collection.
        /// </summary>
        /// <param name="sName">Specifies a name for the favourite.</param>
        /// <param name="sPath">Specifies a directory path for the favourite.</param>
        public FavouriteDialog(string sName, string sPath)
        {
            InitializeComponent();

            // Create a name if one hasen't been supplied.
            if (string.IsNullOrEmpty(sName))
                sName = "New favourite";

            // Update location text if a value has not ben supplied.
            if (string.IsNullOrEmpty(sPath))
                sPath = "Select a location";

            // Update text boxes.
            txtb_Name.Text = sName;
            txtb_Location.Text = sPath;
        }

        #endregion

        #region Control events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtb_Name_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtb_Name.Text))
            {
                tt_Error.SetToolTip(pan_Error, "A file name should not be null, empty or just white space.");
                pan_Error.Visible = true;
                btn_OK.Enabled = false;
                
            }
            else
            {
                pan_Error.Visible = false;
                btn_OK.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            m_oFavourite = new Favourite();
            m_oFavourite.Name = txtb_Name.Text;
            m_oFavourite.Created = DateTime.Now.ToShortDateString();
            m_oFavourite.Path = txtb_Location.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            m_oFavourite = null;

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Browse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog oDlg = new FolderBrowserDialog())
            {
                oDlg.ShowNewFolderButton = true;

                if (oDlg.ShowDialog(this) == DialogResult.OK)
                    txtb_Location.Text = oDlg.SelectedPath;
            }
        }

        #endregion
    }
}
