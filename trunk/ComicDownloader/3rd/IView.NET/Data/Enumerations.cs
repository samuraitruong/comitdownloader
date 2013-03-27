//::///////////////////////////////////////////////////////////////////////////
//:: File Name: Enumerations.cs
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
//:: Using Statements
//::///////////////////////////////////////////////////////////////////////////
using System;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Data
{
    /// <summary>
    /// Specifies the mode of the screen capture tool form.
    /// </summary>
    public enum Mode
    {
        /// <summary>
        /// Indicates that the form is not in any mode.
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that the form is in move mode.
        /// </summary>
        Move,

        /// <summary>
        /// Indicates that the form is in resize mode.
        /// </summary>
        Resize
    }

    /// <summary>
    /// Specifies an iView.NET subroutine return value.
    /// </summary>
    public enum SResult
    {
        /// <summary>
        /// The subroutine exited and did not execute the main part of it's task.
        /// </summary>
        Void = 0,

        /// <summary>
        /// The subroutine completed it's task and exited with no errors.
        /// </summary>
        Completed,

        /// <summary>
        /// The subroutine was canceled by the user and did not complete it's task.
        /// </summary>
        Canceled,

        /// <summary>
        /// The subroutine failed to complete it's task because of an invalid file path.
        /// </summary>
        InvalidFilePath,

        /// <summary>
        /// The subroutine failed to complete it's task because of an invalid folder path.
        /// </summary>
        InvalidFolderPath,

        /// <summary>
        /// The subroutine exited with a null display image object error.
        /// </summary>
        NullDisplayImage,

        /// <summary>
        /// The subroutine returned and exited with a null FavouritesCollection object error.
        /// </summary>
        NullFavouritesCollection,
    }

    /// <summary>
    ///  Specifies the type of scaling to apply to an image.
    /// </summary>
    [Serializable()]
    public enum ImageScale
    {
        /// <summary>
        /// No scaling will be applied to the image.
        /// </summary>
        None = 0,

        /// <summary>
        /// Auto scaling will be applied to the image.
        /// </summary>
        Auto,

        /// <summary>
        /// A custom set scale will be applied to the image.
        /// </summary>
        Custom,
    }

    /// <summary>
    /// Specifies the type of data to copy to the clipboard.
    /// </summary>
    public enum CopyDataType
    {
        /// <summary>
        /// Copys the bitmap image to the clipboard.
        /// </summary>
        PixelData = 0,

        /// <summary>
        /// Copys the selected file(s) to the clipboard.
        /// </summary>
        File
    }

    /// <summary>
    /// Specifies the type of navigation to use when selecting an image from the image browser.
    /// </summary>
    public enum Navigate
    {
        /// <summary>
        /// Specifies that an image will be loaded by it's index value.
        /// </summary>
        Index = 0,

        /// <summary>
        /// Specifies that an image will be loaded by it's file path.
        /// </summary>
        Path,

        /// <summary>
        /// Specifies that the first image will be loaded.
        /// </summary>
        First,

        /// <summary>
        /// Specifies that the next image will be loaded.
        /// </summary>
        Next,

        /// <summary>
        /// Specifies that the previous image will be loaded.
        /// </summary>
        Previous,

        /// <summary>
        /// Specifies that the last image will be loaded.
        /// </summary>
        Last
    }

    /// <summary>
    /// Specifies a type of window used by iView.NET to hold controls.
    /// </summary>
    public enum Window
    {
        /// <summary>
        /// Specifies no window.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies the folder explorer window.
        /// </summary>
        Explorer,

        /// <summary>
        /// Specifies the image list window.
        /// </summary>
        ImageList,

        /// <summary>
        /// Specifies the tasks window.
        /// </summary>
        Tasks
    }

    /// <summary>
    /// Specifies the type of view the image list uses.
    /// </summary>
    [Serializable()]
    public enum ImageListViewType
    {
        /// <summary>
        /// Specifies the large icons view.
        /// </summary>
        LargeIcons = 0,

        /// <summary>
        /// Specifies the medium icons view.
        /// </summary>
        MediumIcons,

        /// <summary>
        /// Specifies the small icons view.
        /// </summary>
        SmallIcons,

        /// <summary>
        /// Specifies the details view.
        /// </summary>
        Details,

        /// <summary>
        /// Specifies the list view.
        /// </summary>
        List
    }

    /// <summary>
    /// Specifies a tool used by iView.NET.
    /// </summary>
    public enum Tool
    {
        /// <summary>
        /// Specifies no tool.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies the eye dropper tool.
        /// </summary>
        EyeDropper,

        /// <summary>
        /// Specifies the red eye correction tool.
        /// </summary>
        RedEyeCorrection,
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable()]
    public enum TaskWindow
    {
        /// <summary>
        /// 
        /// </summary>
        Properties = 0,

        /// <summary>
        /// 
        /// </summary>
        ColourEditor,

        /// <summary>
        ///  
        /// </summary>
        BrightnessContrast,

        /// <summary>
        /// 
        /// </summary>
        RedEyeCorrection,

        /// <summary>
        /// 
        /// </summary>
        Resize,

        /// <summary>
        /// 
        /// </summary>
        Shear
    }

    /// <summary>
    /// Specifies a toolstrip container panel.
    /// </summary>
    [Serializable()]
    public enum ToolBarPanel
    {
        /// <summary>
        /// Specifies the top panel of the toolstrip container.
        /// </summary>
        Top = 0,

        /// <summary>
        /// Specifies the bottom panel of the toolstrip container.
        /// </summary>
        Bottom,

        /// <summary>
        /// Specifies the left panel of the toolstrip container.
        /// </summary>
        Left,

        /// <summary>
        /// Specifies the right panel of the toolstrip container.
        /// </summary>
        Right
    }

    /// <summary>
    /// Specifies a custom colour table.
    /// </summary>
    [Serializable()]
    public enum ColourTable
    {
        /// <summary>
        /// Specifies no colour table.
        /// </summary>
        Default = 0,

        /// <summary>
        /// Specifies the SkyBlue professional colour table.
        /// </summary>
        SkyBlue,

        /// <summary>
        /// Specifies the ArcticSilver professional colour table.
        /// </summary>
        ArcticSilver
    }

    /// <summary>
    /// Specifies a window state enumeration value for the main window.
    /// </summary>
    [Serializable()]
    public enum MainWindowState
    {
        /// <summary>
        /// Specifies that the main window is in it's normal state.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Specifies that the main window is in it's maximized state.
        /// </summary>
        Maximized,

        /// <summary>
        /// Specifies that the main window is in it's minimized state.
        /// </summary>
        Minimized,

        /// <summary>
        /// Specifies that the main window is in it's full screen state.
        /// </summary>
        FullScreen
    }

    /// <summary>
    /// Specifies a slide show FadeSpeed enumeration value.
    /// </summary>
    public enum FadeSpeed
    {
        /// <summary>
        /// Specifies a normal fade speed.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Specifies a fast fade speed.
        /// </summary>
        Fast,

        /// <summary>
        /// Specifies a slow fade speed.
        /// </summary>
        Slow,
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ControlSet
    {
        /// <summary>
        /// 
        /// </summary>
        BrightnessContrast = 0,

        /// <summary>
        /// 
        /// </summary>
        ColourBalance,

        /// <summary>
        /// 
        /// </summary>
        Gamma,

        /// <summary>
        /// 
        /// </summary>
        Noise,

        /// <summary>
        /// 
        /// </summary>
        Transparency
    }
}