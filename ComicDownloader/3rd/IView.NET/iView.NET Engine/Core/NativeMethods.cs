//::///////////////////////////////////////////////////////////////////////////
//:: File Name: NativeMethods.cs
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
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IView.Engine.Data;
using Microsoft.Win32;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides function wrappers for code that implement WinApi calls.
    /// </summary>
    public static class NativeMethods
    {
        #region Fields

        // Winapi constants.
        private const int LVM_FIRST = 0x1000;
        private const int LVM_SETICONSPACING = LVM_FIRST + 53;
        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;
        private const int SPIF_SENDCHANGE = SPIF_SENDWININICHANGE;

        private const int MAX_FILES = 65535;
        
        private const string FILE_NAME_PREFIX = "bimg_";
        private const string RKEY_DESKTOP = @"Control Panel\Desktop\";

        #endregion

        #region WinApi declarations

        /// <summary>
        /// Destroys the specified icon and releases all resources used by this object.
        /// </summary>
        /// <param name="hIcon">Specifies the icon handle.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern int DestroyIcon(IntPtr hIcon);

        /// <summary>
        /// WinAPI call. Sends a message with the specified parameters to the specified window.
        /// </summary>
        /// <param name="hWnd">Specifies the window handle.</param>
        /// <param name="wMsg">Specifies the message to send to the window.</param>
        /// <param name="wParam">Additional parameters.</param>
        /// <param name="lParam">Additional parameters.</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uAction"></param>
        /// <param name="uParam"></param>
        /// <param name="lpvParam"></param>
        /// <param name="fuWinIni"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet=CharSet.Unicode)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpdwFlags"></param>
        /// <param name="dwReserved"></param>
        /// <returns></returns>
        [DllImport("wininet.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool InternetGetConnectedState(out int lpdwFlags, int dwReserved);

        #endregion

        #region WinApi function implementation

        /// <summary>
        /// Destroy and release the resources used by the specified icon. Returns 0 or -1 if the operations fails.
        /// </summary>
        /// <param name="oIcon">Specifies the icon to release.</param>
        public static int ReleaseIcon(Icon oIcon)
        {
            if (oIcon != null)
                return DestroyIcon(oIcon.Handle);
            return -1;
        }

        /// <summary>
        /// Adjusts the list view item spacing by the specified amount.
        /// </summary>
        /// <param name="oListView">Specicies the list view control.</param>
        /// <param name="nWidth">Specifies the width of the list view item.</param>
        /// <param name="nHeight">Specifies the height of the list view item.</param>
        public static void SetListViewItemSpacing(ListView oListView, int nWidth, int nHeight)
        {
            if (oListView != null)
            {
                IntPtr a = new IntPtr(nHeight * 65536);
                IntPtr b = new IntPtr(a.ToInt64() + nWidth);
                //(IntPtr)(nHeight * 65536) + nWidth;
                SendMessage(oListView.Handle, LVM_SETICONSPACING, IntPtr.Zero, b);
            }
        }

        /// <summary>
        /// Sets the users desktop wallpaper to the specified image, with the specified style.
        /// </summary>
        /// <param name="sDirectory">Specifies the directory path of the background image copy to be saved in.</param>
        /// <param name="oImage">Specifies the image to set as the desktop wallpaper.</param>
        /// <param name="nStyle">Specifies the wallpaper style.</param>
        public static int SetDesktopBackground(string sDirectory, Image oImage, WallPaperStyle nStyle)
        {
            try
            {
                if ((oImage != null) && (!string.IsNullOrEmpty(sDirectory)))
                {
                    sDirectory += Path.DirectorySeparatorChar;

                    bool bSave = false;
                    string sFilePath = string.Empty;
                    DirectoryInfo oDirectory = new DirectoryInfo(sDirectory);

                    // Create the directory if it doesn't exist.
                    if (!oDirectory.Exists)
                        oDirectory.Create();

                    // Generate a file path.
                    for (int n = 0; n < MAX_FILES; n++)
                    {
                        sFilePath = sDirectory + FILE_NAME_PREFIX + n.ToString("x4") + ".bmp";

                        if (!File.Exists(sFilePath))
                        {
                            bSave = true;
                            break;
                        }
                    }

                    // Save the image and set the desktop background.
                    if (bSave)
                    {
                        using (Bitmap oBitmap = new Bitmap(oImage))
                            oBitmap.Save(sFilePath, System.Drawing.Imaging.ImageFormat.Bmp);

                        RegistryKey oKey = Registry.CurrentUser.OpenSubKey(RKEY_DESKTOP, true);

                        switch (nStyle)
                        {
                            case WallPaperStyle.Center:
                                oKey.SetValue("WallpaperStyle", "1");
                                oKey.SetValue("TileWallpaper", "0");
                                break;
                            case WallPaperStyle.Stretch:
                                oKey.SetValue("WallpaperStyle", "2");
                                oKey.SetValue("TileWallpaper", "0");
                                break;
                            case WallPaperStyle.Tile:
                                oKey.SetValue("WallpaperStyle", "1");
                                oKey.SetValue("TileWallpaper", "1");
                                break;
                        }

                        oKey.Flush();
                        oKey.Close();

                        return SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, sFilePath,
                            SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
                    }
                }
            }
            catch (System.Security.SecurityException e)
            {
                MessageBox.Show(e.Message, "SecurityException",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message, "IOException",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return 0;
        }

        /// <summary>
        /// Returns a boolean value indicating whether the computer is currently connected to the internet.
        /// </summary>
        /// <returns></returns>
        public static bool IsConnectedToInternet()
        {
            int n = 0;
            return InternetGetConnectedState(out n, 0);
        }

        #endregion
    }
}
