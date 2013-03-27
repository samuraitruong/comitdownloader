//::///////////////////////////////////////////////////////////////////////////
//:: File Name: CreateSlideShow.cs
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
//:: Created On: 13 April 2011
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
    /// Provides a way of allowing a user to create, edit and save iView.NET slide show files.
    /// </summary>
    public partial class CreateSlideShow : Form
    {
        #region Fields and properties

        private const int MAX_NAME_LENGTH = 100;

        private const string FILE_FILTER = "Slide Show File (*.ssf)|*.ssf";
        private const string ERR_MSG_FILE_ALREADY_EXISTS = "A file with the same name already exists.";
        private const string ERR_MSG_NAME_TO_LONG = "A file name should not contain more than 100 characters.";
        private const string ERR_MSG_NAME_NULL = "A file name should not be null, empty or just white space.";
        private const string ERR_MSG_INVALID_CHAR = "A file name should not contain any of the following characters: \\ / : * ? \" < > |";

        private static int m_nImageViewTime = 2;
        private static string m_sSaveLocation = string.Empty;
        private static FadeSpeed m_nFadeSpeed = FadeSpeed.Normal;
        private static TransitionMode m_nTransitionMode = TransitionMode.Normal;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the CreateSlideShow class initialized with default values.
        /// </summary>
        public CreateSlideShow()
        {
            InitializeComponent();

            ToolStripProfessionalRenderer oRenderer = new ToolStripProfessionalRenderer();
            oRenderer.RoundedEdges = false;

            // Apply the a standard renderer without rounded edges to the toolstrip.
            ts_FileOptions.Renderer = oRenderer;

            // Update the image view time numericupdown.
            nud_Seconds.Value = m_nImageViewTime;

            // Update the transiton mode combobox.
            cbx_TransitionMode.Items.AddRange(Enum.GetNames(typeof(TransitionMode)));
            cbx_TransitionMode.SelectedIndex = (int)m_nTransitionMode;

            // Update the fade speed combobox.
            cbx_FadeSpeed.Items.AddRange(Enum.GetNames(typeof(FadeSpeed)));
            cbx_FadeSpeed.SelectedIndex = (int)m_nFadeSpeed;

            // Update the save location textbox.
            txtb_SaveLocation.Text = (string.IsNullOrEmpty(m_sSaveLocation)) ?
                ApplicationData.SlideShowFolder : m_sSaveLocation;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Updates the controls related to items being added and removed from the files list view control.
        /// </summary>
        private void ListViewItemsChanged()
        {
            bool bListViewHasItems = (lvw_Files.Items.Count > 0);

            tsddb_Sort.Enabled = bListViewHasItems;
            btn_OK.Enabled = bListViewHasItems;
            tsl_FilesInfo.Text = "Items: " + lvw_Files.Items.Count;
        }

        /// <summary>
        /// Gets a floating point value that represents the current FadeSpeed parameter.
        /// </summary>
        /// <param name="nFadeSpeed">Specifies the FadeSpeed enum value to convert.</param>
        /// <returns></returns>
        private float GetFadeSpeed(FadeSpeed nFadeSpeed)
        {
            switch (nFadeSpeed)
            {
                case FadeSpeed.Normal:
                    return 0.005F;
                case FadeSpeed.Fast:
                    return 0.01F;
                case FadeSpeed.Slow:
                    return 0.002F;
            }

            return 0.01F;
        }

        /// <summary>
        /// Gets a FadeSpeed enumeration value that represents the current floating point value.
        /// </summary>
        /// <param name="nFadeSpeed">Specifies the floating point value to convert.</param>
        /// <returns></returns>
        private FadeSpeed GetFadeSpeed(float fFadeSpeed)
        {
            if (fFadeSpeed >= 0.01F)
                return FadeSpeed.Fast;
            else if (fFadeSpeed <= 0.002)
                return FadeSpeed.Slow;
            else
                return FadeSpeed.Normal;
        }

        /// <summary>
        /// Creates a string array containing the current file entries in the listview control.
        /// </summary>
        /// <returns></returns>
        private string[] GetFileEntries()
        {
            int nCount = lvw_Files.Items.Count;

            if (nCount > 0)
            {
                string[] sEntries = new string[nCount];

                for (int n = 0; n < nCount; n++)
                    sEntries[n] = lvw_Files.Items[n].Text;

                return sEntries;
            }

            return null;
        }

        #endregion

        #region Toolbar events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_Add_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oDlg = new OpenFileDialog())
            {
                oDlg.AutoUpgradeEnabled = true;
                oDlg.Filter = Resources.OpenFileFilter;
                oDlg.Multiselect = true;
                oDlg.Title = "Add Files";

                if (oDlg.ShowDialog(this) == DialogResult.OK)
                {
                    foreach (string sPath in oDlg.FileNames)
                        lvw_Files.Items.Add(sPath);

                    // Update the changes.
                    ListViewItemsChanged();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_Remove_Click(object sender, EventArgs e)
        {
            if ((lvw_Files.SelectedItems != null) && (lvw_Files.SelectedItems.Count > 0))
            {
                for (int n = 0; n < lvw_Files.Items.Count; n++)
                {
                    if (lvw_Files.Items[n].Selected)
                        lvw_Files.Items[n--].Remove();
                }

                // Update the changes.
                ListViewItemsChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_MoveUp_Click(object sender, EventArgs e)
        {
            int nIndex = lvw_Files.SelectedItems[0].Index;

            if (nIndex > 0)
            {
                string sTemp = lvw_Files.Items[nIndex].Text;

                lvw_Files.Items[nIndex].Selected = false;
                lvw_Files.Items[nIndex].Text = lvw_Files.Items[--nIndex].Text;

                lvw_Files.Items[nIndex].Text = sTemp;
                lvw_Files.Items[nIndex].Selected = true;

                lvw_Files.Items[nIndex].Focused = true;
                lvw_Files.Items[nIndex].EnsureVisible();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsb_MoveDown_Click(object sender, EventArgs e)
        {
            int nIndex = lvw_Files.SelectedItems[0].Index;

            if (nIndex < lvw_Files.Items.Count - 1)
            {
                string sTemp = lvw_Files.Items[nIndex].Text;

                lvw_Files.Items[nIndex].Selected = false;
                lvw_Files.Items[nIndex].Text = lvw_Files.Items[++nIndex].Text;

                lvw_Files.Items[nIndex].Text = sTemp;
                lvw_Files.Items[nIndex].Selected = true;

                lvw_Files.Items[nIndex].Focused = true;
                lvw_Files.Items[nIndex].EnsureVisible();
            }
        }

        #endregion

        #region Sort context menustrip events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_sort_Ascending_Click(object sender, EventArgs e)
        {
            lvw_Files.Sorting = SortOrder.Ascending;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_sort_Descending_Click(object sender, EventArgs e)
        {
            lvw_Files.Sorting = SortOrder.Descending;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmi_sort_Randomize_Click(object sender, EventArgs e)
        {
            int nCount = lvw_Files.Items.Count;
            
            if (nCount > 0)
            {
                int nRand;
                string sTemp;
                Random oRand = new Random(DateTime.Now.Second);

                foreach (ListViewItem oItem in lvw_Files.Items)
                {
                    // Generate a random number less than the number of items.
                    nRand = oRand.Next(nCount);

                    // Hold a the text of the current item in the loop.
                    sTemp = oItem.Text;

                    // Update the text of the current item with a random item.
                    oItem.Text = lvw_Files.Items[nRand].Text;

                    // Update the text of the random item with the backing store value.
                    lvw_Files.Items[nRand].Text = sTemp;
                }
            }
        }

        #endregion

        #region Listview events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvw_Files_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvw_Files.SelectedItems.Count == 0)
            {
                if (pan_ImagePreview.BackgroundImage != null)
                {
                    pan_ImagePreview.BackgroundImage.Dispose();
                    pan_ImagePreview.BackgroundImage = null;
                }

                tsb_Remove.Enabled = false;
                tsb_MoveUp.Enabled = false;
                tsb_MoveDown.Enabled = false;
                tsl_FilesInfo.Text = "Items: " + lvw_Files.Items.Count;
                lbl_PreviewFileName.Text = string.Empty;

                return;
            }
            else if (lvw_Files.SelectedItems.Count > 1)
            {
                if (pan_ImagePreview.BackgroundImage != null)
                {
                    pan_ImagePreview.BackgroundImage.Dispose();
                    pan_ImagePreview.BackgroundImage = null;
                }

                tsb_Remove.Enabled = true;
                tsb_MoveUp.Enabled = false;
                tsb_MoveDown.Enabled = false;
                tsl_FilesInfo.Text = "Items: " + lvw_Files.Items.Count + ", Selected: " + lvw_Files.SelectedItems.Count;
                lbl_PreviewFileName.Text = string.Empty;

                return;
            }

            string sInfo = "Items: " + lvw_Files.Items.Count;
            string sFilePath = e.Item.Text;

            if ((!string.IsNullOrEmpty(sFilePath)) && (File.Exists(sFilePath)))
            {
                // Insert the play index if an item has been slected.
                sInfo = sInfo.Insert(0, "Index: " + (e.ItemIndex + 1) + ", ");

                // Update the preview file name label.
                lbl_PreviewFileName.Text = Path.GetFileName(sFilePath);

                if (ckb_ShowPreview.Checked)
                {
                    try
                    {
                        using (Image oImage = Image.FromFile(sFilePath))
                        {
                            int nWidth = pan_ImagePreview.Width - 1;
                            int nHeight = pan_ImagePreview.Height - 1;

                            // Load the pewview image.
                            pan_ImagePreview.BackgroundImage =
                                DrawingTools.CreateThumbnail(oImage, nWidth, nHeight, false, ThumbnailEffect.None);
                        }
                    }
                    catch (OutOfMemoryException ex)
                    {
                        // Load a no preview image.
                        pan_ImagePreview.BackgroundImage =
                            DrawingTools.CreateTextBitmap("No Preview.", this.Font, Color.Black, Color.White);

                        // Reset the preview file name to empty.
                        lbl_PreviewFileName.Text = string.Empty;

                        // Show error message box.
                        MessageBox.Show("Unable to load the specified file.\n\nReason: " + ex.Message, "Error Loading Image",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Update the image index.
                e.Item.ImageIndex = 1;

                // Load a no preview image.
                pan_ImagePreview.BackgroundImage =
                    DrawingTools.CreateTextBitmap("No Preview.", this.Font, Color.Black, Color.White);

                // Reset the preview file name to empty.
                lbl_PreviewFileName.Text = string.Empty;
            }
            
            // Update buttons and labels.
            tsl_FilesInfo.Text = sInfo;
            tsb_Remove.Enabled = true;
            tsb_MoveUp.Enabled = true;
            tsb_MoveDown.Enabled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvw_Files_DragEnter(object sender, DragEventArgs e)
        {
            string[] sPaths = (string[])e.Data.GetData(DataFormats.FileDrop, true);

            if ((sPaths != null) && (sPaths.Length > 0))
            {
                if ((!string.IsNullOrEmpty(sPaths[0])) && (FileTools.IsFileExtensionValid(Path.GetExtension(sPaths[0]))))
                    e.Effect = DragDropEffects.Link;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvw_Files_DragDrop(object sender, DragEventArgs e)
        {
            string[] sPaths = (string[])e.Data.GetData(DataFormats.FileDrop, true);

            if ((sPaths != null) && (sPaths.Length > 0))
            {
                foreach (string sPath in sPaths)
                {
                    if (!string.IsNullOrEmpty(sPath))
                    {
                        if (FileTools.IsFileExtensionValid(Path.GetExtension(sPath)))
                            lvw_Files.Items.Add(sPath);
                    }
                }

                // Update the changes.
                ListViewItemsChanged();
            }
        }

        #endregion

        #region Button events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Import_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog oDlg = new OpenFileDialog())
            {
                oDlg.AutoUpgradeEnabled = true;
                oDlg.Filter = FILE_FILTER;
                oDlg.Title = "Import Slide Show";

                if (oDlg.ShowDialog(this) == DialogResult.OK)
                {
                    string sCaption = "Confirm Import Slide Show";
                    string sMessage = "Importing a slide show will cause any current settings to be lost. Would you like to continue?";
                    DialogResult nDlg = MessageBox.Show(sMessage, sCaption,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (nDlg == DialogResult.No)
                        return;

                    if ((!string.IsNullOrEmpty(oDlg.FileName)) && (File.Exists(oDlg.FileName)))
                    {
                        try
                        {
                            DateTime Date;
                            SlideShowDocument oDoc = new SlideShowDocument();
                            oDoc.Load(oDlg.FileName);

                            if (DateTime.TryParse(oDoc.Date, out Date))
                                dtp_Created.Value = Date;

                            nud_Seconds.Value = oDoc.WaitInterval;
                            cbx_TransitionMode.SelectedIndex = (int)oDoc.TransitionMode;
                            cbx_FadeSpeed.SelectedIndex = (int)GetFadeSpeed(oDoc.FadeSpeed);
                            txtb_FileName.Text = Path.GetFileNameWithoutExtension(oDlg.FileName);

                            // Clear any previous items.
                            if (lvw_Files.Items.Count > 0)
                                lvw_Files.Items.Clear();

                            // Add the entries to the files list view control.
                            foreach (string sEntry in oDoc.GetEntries())
                                lvw_Files.Items.Add(sEntry);

                            // Update the changes.
                            ListViewItemsChanged();
                        }
                        catch (FileFormatException ex)
                        {
                            MessageBox.Show("Unable to create the specified slide show.\n\nReason: " + ex.Message, "Error Creating File",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            MessageBox.Show("Unable to create the specified slide show.\n\nReason: " + ex.Message, "Error Creating File",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (System.Security.SecurityException ex)
                        {
                            MessageBox.Show("Unable to create the specified slide show.\n\nReason: " + ex.Message, "Error Creating File",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("Unable to create the specified slide show.\n\nReason: " + ex.Message, "Error Creating File",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                string sPath = txtb_SaveLocation.Text
                    + Path.DirectorySeparatorChar + txtb_FileName.Text + FileTools.SSF;

                SlideShowDocument oDoc = new SlideShowDocument();
                SSFDescriptor Descriptor = SSFDescriptor.Empty;
                Descriptor.Version = 1;
                Descriptor.WaitInterval = (int)nud_Seconds.Value;
                Descriptor.TransitionMode = (TransitionMode)cbx_TransitionMode.SelectedIndex;
                Descriptor.FadeSpeed = GetFadeSpeed((FadeSpeed)cbx_FadeSpeed.SelectedIndex);
                Descriptor.EntryCount = lvw_Files.Items.Count;
                Descriptor.Date = dtp_Created.Value.ToLongDateString();

                if (File.Exists(sPath))
                {
                    string sCaption = "Confirm Save";
                    string sMessage = "A file with the same name already exists. Would you like to replace it?";

                    DialogResult nDlg = MessageBox.Show(sMessage, sCaption,
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (nDlg == DialogResult.Yes)
                        oDoc.Create(sPath, Descriptor, GetFileEntries());
                }
                else
                    oDoc.Create(sPath, Descriptor, GetFileEntries());
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Unable to create the specified slide show.\n\nReason: " + ex.Message, "Error Creating File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Security.SecurityException ex)
            {
                MessageBox.Show("Unable to create the specified slide show.\n\nReason: " + ex.Message, "Error Creating File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Unable to create the specified slide show.\n\nReason: " + ex.Message, "Error Creating File",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                oDlg.SelectedPath = txtb_SaveLocation.Text;
                oDlg.ShowNewFolderButton = true;
                oDlg.Description = "Please select a location to save the slide show file into.";

                if (oDlg.ShowDialog(this) == DialogResult.OK)
                    txtb_SaveLocation.Text = oDlg.SelectedPath;
            }
        }

        #endregion

        #region Mixed controls events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckb_ShowPreview_CheckedChanged(object sender, EventArgs e)
        {
            if (!ckb_ShowPreview.Checked)
            {
                if (pan_ImagePreview.BackgroundImage != null)
                {
                    pan_ImagePreview.BackgroundImage.Dispose();
                    pan_ImagePreview.BackgroundImage = null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtb_FileName_TextChanged(object sender, EventArgs e)
        {
            string sError = string.Empty;
            string sName = txtb_FileName.Text;

            if (!string.IsNullOrEmpty(sName))
            {
                if (sName.Length < MAX_NAME_LENGTH)
                {
                    if (sName.IndexOfAny(Path.GetInvalidFileNameChars()) != -1)
                        sError = ERR_MSG_INVALID_CHAR;
                }
                else
                    sError = ERR_MSG_NAME_TO_LONG;
            }
            else
                sError = ERR_MSG_NAME_NULL;

            // Show the error if requested.
            if (!string.IsNullOrEmpty(sError))
            {
                tt_Info.SetToolTip(pan_NameError, sError);
                pan_NameError.Visible = true;
                btn_OK.Enabled = false;
            }
            else
            {
                pan_NameError.Visible = false;
                btn_OK.Enabled = true;
            }
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            m_nImageViewTime = (int)nud_Seconds.Value;
            m_nFadeSpeed = (FadeSpeed)cbx_FadeSpeed.SelectedIndex;
            m_nTransitionMode = (TransitionMode)cbx_TransitionMode.SelectedIndex;
            m_sSaveLocation = txtb_SaveLocation.Text;

            base.OnFormClosed(e);
        }

        #endregion
    }
}
