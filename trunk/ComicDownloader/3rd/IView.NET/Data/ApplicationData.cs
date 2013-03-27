//::///////////////////////////////////////////////////////////////////////////
//:: File Name: ApplicationData.cs
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
using System.IO;
using System.Reflection;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.UI.Data
{
    /// <summary>
    /// iView.NET data class. Contains environmet flags and information related to the application
    /// version and other important info. This class cannot be inherited.
    /// </summary>
    public sealed class ApplicationData
    {
        #region Fields and properties

        private const int MAX_INSTANCES = 1;

        private const string USER_FOLDER_IVIEW = "\\iView.NET";
        private const string USER_FOLDER_CAPTURED_IMG = USER_FOLDER_IVIEW + "\\Captured Images";
        private const string USER_FOLDER_DESKTOP_BACKGROUND = USER_FOLDER_IVIEW + "\\Backgrounds";
        private const string USER_FOLDER_SLIDE_SHOW = USER_FOLDER_IVIEW + "\\Slide Shows";
        
        /// <summary>
        /// Gets the maximum number of application instances allowed to run.
        /// </summary>
        public static int MaxInstances
        {
            get { return MAX_INSTANCES; }
        }

        /// <summary>
        /// Gets the applications display name.
        /// </summary>
        public static string ApplicationName
        {
            get { return "Comic Viewer"; }
        }

        /// <summary>
        /// Gets the path of the help documentation html file.
        /// </summary>
        public static string HelpDocumentationFile
        {
            get { return EntryAssemblyParentDirectory + @"\iView.NET Documentation.html"; }
        }

        /// <summary>
        /// Gets the path of the read me text file.
        /// </summary>
        public static string ReadMeTextFile
        {
            get { return EntryAssemblyParentDirectory + "\\Read Me.txt"; }
        }

        /// <summary>
        /// Gets the authors email address. sdaily2004@hotmail.com.
        /// </summary>
        public static string AuthorEmail
        {
            get { return "sdaily2004@hotmail.com"; }
        }

        /// <summary>
        /// Gets the application authors email address. prefixed with the "mailto" macro.
        /// </summary>
        public static string MailtoAuthor
        {
            get { return "mailto:sdaily2004@hotmail.com"; }
        }

        /// <summary>
        /// Gets the path of the captured images directory.
        /// </summary>
        public static string CapturedImagesFolder
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    + USER_FOLDER_CAPTURED_IMG;
            }
        }

        /// <summary>
        /// Gets the path of the backgrounds directory.
        /// </summary>
        public static string BackgroundsFolder
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    + USER_FOLDER_DESKTOP_BACKGROUND;
            }
        }

        /// <summary>
        /// Gets the path of the slide show directory.
        /// </summary>
        public static string SlideShowFolder
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                    + USER_FOLDER_SLIDE_SHOW;
            }
        }

        /// <summary>
        /// Gets the parent directory of the entry assembly. Without the ending path seperator.
        /// </summary>
        public static string EntryAssemblyParentDirectory
        {
            get
            {
                string sPath = string.Empty;

                try
                {
                    sPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
                }
                catch (IOException e)
                {
                    sPath = "Error trying to obtain entry assembly path.\n\nReason: " + e.Message;
                }
                
                return sPath;
            }
        }

        /// <summary>
        /// Gets the full path, file name and extension of the entry assembly.
        /// </summary>
        public static string EntryAssemblyFullPath
        {
            get
            {
                string sPath = string.Empty;

                try
                {
                    return Path.GetFullPath(Assembly.GetEntryAssembly().Location);
                }
                catch (IOException e)
                {
                    sPath = "Error trying to obtain entry assembly full path.\n\nReason: " + e.Message;
                }
                catch (System.Security.SecurityException e)
                {
                    sPath = "Error trying to obtain entry assembly full path.\n\nReason: " + e.Message;
                }

                return sPath;
            }
        }

        /// <summary>
        /// Gets the full version of the entry assembly.
        /// </summary>
        public static string EntryAssemblyVersionFull
        {
            get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); }
        }

        /// <summary>
        /// Gets the short entry assembly version number.
        /// </summary>
        public static string EntryAssemblyVersionShort
        {
            get { return GetAssemblyVersionShort(); }
        }

        /// <summary>
        /// Gets the build number of the entry assembly.
        /// </summary>
        public static string EntryAssemblyBuild
        {
            get { return GetAssemblyBuild(); }
        }

        /// <summary>
        /// Gets the codeplex uri.
        /// </summary>
        public static Uri CodeplexUri
        {
            get { return new Uri("http://iviewdotnet.codeplex.com/"); }
        }

        /// <summary>
        /// Gets the iView.NET home page uri.
        /// </summary>
        public static Uri HomepageUri
        {
            get { return new Uri("https://sites.google.com/site/iviewdotnet/"); }
        }

        /// <summary>
        /// Gets the donation uri.
        /// </summary>
        public static Uri DonationUri
        {
            get { return new Uri("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=3184254"); }
        }

        /// <summary>
        /// Gets the update check file uri.
        /// </summary>
        public static Uri UpdateCheckFileUri
        {
            get { return new Uri("https://sites.google.com/site/iviewdotnet/ivdn_version.xml"); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Private constructor.
        /// </summary>
        private ApplicationData() { }

        #endregion

        #region Methods

        /// <summary>
        /// Splits the entry assembly long version and returns the major and minor version
        /// without the build or revision numbers.
        /// </summary>
        /// <returns></returns>
        private static string GetAssemblyVersionShort()
        {
            string sVersionShort = "";
            string sVersionFull = EntryAssemblyVersionFull;

            if (!string.IsNullOrEmpty(sVersionFull))
            {
                string[] sSplitVersion = sVersionFull.Split('.');

                if (sSplitVersion.Length == 4)
                    sVersionShort = sSplitVersion[0] + "." + sSplitVersion[1];
            }

            return sVersionShort;
        }

        /// <summary>
        /// Gets the entry assembly build number.
        /// </summary>
        /// <returns></returns>
        private static string GetAssemblyBuild()
        {
            string sBuild = "";
            string sVersionFull = EntryAssemblyVersionFull;

            if (!string.IsNullOrEmpty(sVersionFull))
            {
                string[] sSplitVersion = sVersionFull.Split('.');

                if (sSplitVersion.Length == 4)
                    sBuild = sSplitVersion[2];
            }

            return sBuild;
        }

        #endregion
    }
}
