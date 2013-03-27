//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ArcticSilverColourTable.cs
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
using System.Drawing;
using System.Windows.Forms;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.ColourTables
{
    /// <summary>
    /// Provides a professional arctic silver colour table.
    /// </summary>
    public class ArcticSilverColourTable : ProfessionalColorTable
    {
        #region Toolstrip colour region

        // Toolstrip.
        public override Color ToolStripGradientBegin
        { get { return Color.White; } }
        public override Color ToolStripGradientMiddle
        { get { return Color.WhiteSmoke; } }
        public override Color ToolStripGradientEnd
        { get { return Color.Gainsboro; } }

        // Toolstrip border.
        public override Color ToolStripBorder
        { get { return Color.LightGray; } }

        // Toolstrip dropdown background.
        public override Color ToolStripDropDownBackground
        { get { return Color.White; } }

        // Toolstrip panel.
        public override Color ToolStripPanelGradientBegin
        { get { return Color.Gainsboro; } }
        public override Color ToolStripPanelGradientEnd
        { get { return Color.White; } }

        // Toolstrp content panel.
        public override Color ToolStripContentPanelGradientBegin
        { get { return Color.Gainsboro; } }
        public override Color ToolStripContentPanelGradientEnd
        { get { return Color.White; } }

        #endregion

        #region Menustrip colour region

        // Menu item.
        public override Color MenuItemBorder
        { get { return Color.LightGray; } }

        // Menu item selection.
        public override Color MenuItemSelected
        { get { return Color.WhiteSmoke; } }
        public override Color MenuItemSelectedGradientBegin
        { get { return Color.WhiteSmoke; } }
        public override Color MenuItemSelectedGradientEnd
        { get { return Color.WhiteSmoke; } }

        // Menu item pressed.
        public override Color MenuItemPressedGradientBegin
        { get { return Color.White; } }
        public override Color MenuItemPressedGradientMiddle
        { get { return Color.WhiteSmoke; } }
        public override Color MenuItemPressedGradientEnd
        { get { return Color.Gainsboro; } }

        // Image margin.
        public override Color ImageMarginGradientBegin
        { get { return Color.WhiteSmoke; } }
        public override Color ImageMarginGradientMiddle
        { get { return Color.WhiteSmoke; } }
        public override Color ImageMarginGradientEnd
        { get { return Color.WhiteSmoke; } }

        // Menustrip.
        public override Color MenuStripGradientBegin
        { get { return Color.Gainsboro; } }
        public override Color MenuStripGradientEnd
        { get { return Color.White; } }

        // Menu border.
        public override Color MenuBorder
        { get { return Color.LightGray; } }

        #endregion

        #region Mixed controls colour region

        // Separator colour.
        public override Color SeparatorDark
        { get { return Color.LightGray; } }
        public override Color SeparatorLight
        { get { return Color.White; } }

        // Overflow.
        public override Color OverflowButtonGradientBegin
        { get { return Color.White; } }
        public override Color OverflowButtonGradientMiddle
        { get { return Color.Gainsboro; } }
        public override Color OverflowButtonGradientEnd
        { get { return Color.LightGray; } }

        // Grip
        public override Color GripDark
        { get { return Color.LightGray; } }
        public override Color GripLight
        { get { return Color.White; } }

        // Status strip.
        public override Color StatusStripGradientBegin
        { get { return Color.Gainsboro; } }
        public override Color StatusStripGradientEnd
        { get { return Color.White; } }

        #endregion

        #region Button colour region

        // Button pressed colour.
        public override Color ButtonPressedBorder
        { get { return Color.LightGray; } }
        public override Color ButtonPressedGradientBegin
        { get { return Color.Gainsboro; } }
        public override Color ButtonPressedGradientMiddle
        { get { return Color.Gainsboro; } }
        public override Color ButtonPressedGradientEnd
        { get { return Color.Gainsboro; } }

        // Button select colour
        public override Color ButtonSelectedBorder
        { get { return Color.LightGray; } }
        public override Color ButtonSelectedGradientBegin
        { get { return Color.WhiteSmoke; } }
        public override Color ButtonSelectedGradientMiddle
        { get { return Color.WhiteSmoke; } }
        public override Color ButtonSelectedGradientEnd
        { get { return Color.WhiteSmoke; } }

        // Button checked colour.
        public override Color CheckBackground
        { get { return Color.WhiteSmoke; } }
        public override Color CheckSelectedBackground
        { get { return Color.LightGray; } }
        public override Color CheckPressedBackground
        { get { return Color.WhiteSmoke; } }

        // Button checked colour.
        public override Color ButtonCheckedGradientBegin
        { get { return Color.Gainsboro; } }
        public override Color ButtonCheckedGradientMiddle
        { get { return Color.Gainsboro; } }
        public override Color ButtonCheckedGradientEnd
        { get { return Color.Gainsboro; } }

        #endregion
    }
}
