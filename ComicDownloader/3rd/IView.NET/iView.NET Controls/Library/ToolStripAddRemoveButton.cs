//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ToolStripAddRemoveButton.cs
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
using System.Linq;
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Controls.Library
{
    /// <summary>
    /// Provides a ToolStripDropDownButton that simulates the functionallity of windows application toolbars,
    /// allowing the user to select which items they prefer to be on the toolbar.
    /// </summary>
    public class ToolStripAddRemoveButton : ToolStripDropDownButton
    {
        #region Fields and properties

        private ContextMenuStrip m_oMenuStrip;
        private ToolStripMenuItem m_oToolStripItem;
        private ToolStripSeparator m_oSeparator;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the ToolStripAddRemoveButton class initialized with default values.
        /// </summary>
        public ToolStripAddRemoveButton()
        {
            // Initialize field members.
            m_oMenuStrip = new ContextMenuStrip();
            m_oMenuStrip.ShowCheckMargin = true;
            m_oMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(MenuStrip_ItemClicked);
            m_oMenuStrip.Closing += new ToolStripDropDownClosingEventHandler(MenuStrip_Closing);

            // Add the context menustrip to the buttons dropdown property.
            this.DropDown = m_oMenuStrip;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverflowButton_DropDownOpening(object sender, EventArgs e)
        {
            if (!DesignMode)
                CreateItems();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OverflowButton_DropDownClosed(object sender, EventArgs e)
        {
            if (!DesignMode)
                RemoveItems();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuStrip_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            if (e.CloseReason == ToolStripDropDownCloseReason.ItemClicked)
                e.Cancel = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripMenuItem oMenuItem = e.ClickedItem as ToolStripMenuItem;

            if (oMenuItem != null)
            {
                ToolStripItem oItem = e.ClickedItem.Tag as ToolStripItem;

                if (oItem != null)
                {
                    switch (oItem.Visible)
                    {
                        case true:
                            oItem.Visible = false;
                            oMenuItem.Checked = false;
                            break;
                        case false:
                            oItem.Visible = true;
                            oMenuItem.Checked = true;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CreateItems()
        {
            foreach (ToolStripItem oItem in this.Owner.Items)
            {
                if (!(oItem is ToolStripAddRemoveButton) && (!(oItem is ToolStripLabel)))
                {
                    if (oItem is ToolStripSeparator)
                    {
                        m_oSeparator = new ToolStripSeparator();

                        //
                        m_oMenuStrip.Items.Add(m_oSeparator);
                    }
                    else
                    {
                        m_oToolStripItem = new ToolStripMenuItem();
                        m_oToolStripItem.Tag = oItem;
                        m_oToolStripItem.Image = oItem.Image;
                        m_oToolStripItem.Checked = oItem.Visible;

                        // If the item is a combox, get the tooltip text instead.
                        if (oItem is ToolStripComboBox)
                            m_oToolStripItem.Text = oItem.ToolTipText;
                        else
                            m_oToolStripItem.Text = oItem.Text;

                        // If the the text contains an open bracket, it will specifiy that it contains
                        // a shortcut key. Add the short cut display string to the new menu item being created.
                        if (!string.IsNullOrEmpty(m_oToolStripItem.Text) && (m_oToolStripItem.Text.Contains('(')))
                        {
                            string[] sSplit = oItem.Text.Split('(');

                            if (sSplit.Length > 0)
                            {
                                m_oToolStripItem.Text = sSplit[0];
                                m_oToolStripItem.ShortcutKeyDisplayString =
                                    sSplit[1].TrimEnd(')');
                            }
                        }

                        //
                        m_oMenuStrip.Items.Add(m_oToolStripItem);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void RemoveItems()
        {
            m_oMenuStrip.Items.Clear();
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnOwnerChanged(EventArgs e)
        {
            if (!DesignMode)
            {
                this.Owner.OverflowButton.DropDownOpening +=
                    new EventHandler(OverflowButton_DropDownOpening);
                this.Owner.OverflowButton.DropDownClosed +=
                    new EventHandler(OverflowButton_DropDownClosed);
            }

            base.OnOwnerChanged(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((m_oMenuStrip != null) && (!m_oMenuStrip.IsDisposed))
                {
                    m_oMenuStrip.Items.Clear();

                    m_oMenuStrip.Dispose();
                    m_oMenuStrip = null;
                }

                if ((m_oSeparator != null) && (!m_oSeparator.IsDisposed))
                {
                    m_oSeparator.Dispose();
                    m_oSeparator = null;
                }

                if ((m_oToolStripItem != null) && (!m_oToolStripItem.IsDisposed))
                {
                    m_oToolStripItem.Dispose();
                    m_oToolStripItem = null;
                }
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
