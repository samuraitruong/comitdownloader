//::///////////////////////////////////////////////////////////////////////////
//:: File Name: UpdateChecker.cs
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
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
//::///////////////////////////////////////////////////////////////////////////
//:: Implementation
//::///////////////////////////////////////////////////////////////////////////
namespace IView.Engine.Core
{
    /// <summary>
    /// Provides properties and methods for checking an iView.NET version
    /// check file being hosted on a remote server.
    /// </summary>
    public class UpdateChecker
    {
        #region Fields and properties

        private const int MAX_LOCATIONS = 10;
        private const string ROOT_NODE = "/Data";
        private const string VERSION_NODE = ROOT_NODE + "/Version";
        private const string LOCATIONS_NODE = ROOT_NODE + "/Locations";

        private bool m_bIsChecking;
        private string[] m_sLocations;
        private Uri m_oUri;
        private Version m_oVersion;

        /// <summary>
        /// Gets a value indicating wether UpdateChecker is currently checking.
        /// </summary>
        public bool IsChecking
        {
            get { return m_bIsChecking; }
        }

        /// <summary>
        /// Gets or sets the Uri of the current version check file.
        /// </summary>
        public Uri CheckFileUri
        {
            get { return m_oUri; }
            set { m_oUri = value; }
        }

        /// <summary>
        /// Fires when the UpdateChecker has been started.
        /// </summary>
        public event EventHandler<EventArgs> UpdateCheckStarted;

        /// <summary>
        /// Fires when the UpdateChecker has finished it's work.
        /// </summary>
        public event EventHandler<UpdateCheckFinishedEventArgs> UpdateCheckFinished;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of the UpdateChecker class initialized with default values.
        /// </summary>
        public UpdateChecker()
        {

        }

        /// <summary>
        /// Creates a new instance of the UpdateChecker class initialized with the specified Uri parameter.
        /// </summary>
        /// <param name="oVersionCheckFile">Specifies the Uri of the ersion check file.</param>
        public UpdateChecker(Uri oVersionCheckFile)
        {
            m_oUri = oVersionCheckFile;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns a boolean value indicating whether the specified string is a valid version string.
        /// A version string must conform to this standard (0.0.0.0).
        /// </summary>
        /// <param name="sVersion">The version string to validate.</param>
        /// <returns></returns>
        private bool IsVersionStringValid(string sVersion)
        {
            if (!string.IsNullOrEmpty(sVersion))
            {
                string[] sVersionData = sVersion.Split(new char[] { '.' });

                if ((sVersionData != null) && (sVersionData.Length == 4))
                {
                    for (int n = 0; n < sVersionData.Length; n++)
                    {
                        int nVal = 0;
                        if (!int.TryParse(sVersionData[n], out nVal))
                            return false;
                    }

                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (m_oUri == null)
                return;

            try
            {
                // Create a new instance of the XmlDocument class and load the version check file.
                XmlDocument oXmlDocument = new XmlDocument();
                oXmlDocument.Load(m_oUri.ToString());

                // Select the version node and validate it.
                XmlNode oNode = oXmlDocument.SelectSingleNode(VERSION_NODE);

                if ((oNode != null) && (IsVersionStringValid(oNode.InnerText.Trim())))
                {
                    // Initialize the locations array, and store the version read from the file.
                    m_sLocations = new string[MAX_LOCATIONS];
                    m_oVersion = new Version(oNode.InnerText.Trim());

                    // Select the locations node and enumerate through it's child nodes, storing
                    // the locations in an array with the name and the url separated by the pipe delimiter.
                    oNode = oXmlDocument.SelectSingleNode(LOCATIONS_NODE);

                    if (oNode != null)
                    {
                        int nCount = 0;
                        IEnumerator oNodes = oNode.GetEnumerator();
                        while (oNodes.MoveNext())
                        {
                            if (nCount >= MAX_LOCATIONS)
                                break;
                            
                            oNode = (XmlNode)oNodes.Current;
                            m_sLocations[nCount] = oNode.Name + "|" + oNode.InnerText.Trim();
                            ++nCount;
                        }
                    }
                    else
                        MessageBox.Show("Invalid xml element. (Node: Locations)");
                }
                else
                    MessageBox.Show("Invalid xml element. (Node: Version)");
            }
            catch (System.Xml.XPath.XPathException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (XmlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (System.Security.SecurityException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_bIsChecking = false;

            OnUpdateCheckFinished(this, new UpdateCheckFinishedEventArgs(m_oVersion, m_sLocations));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnUpdateCheckStarted(object sender, EventArgs e)
        {
            if (UpdateCheckStarted != null)
                UpdateCheckStarted(sender, e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnUpdateCheckFinished(object sender, UpdateCheckFinishedEventArgs e)
        {
            if (UpdateCheckFinished != null)
                UpdateCheckFinished(sender, e);
        }

        /// <summary>
        /// Starts the update checking process.
        /// </summary>
        public void StartCheck()
        {
            using (BackgroundWorker oWorker = new BackgroundWorker())
            {
                oWorker.DoWork +=
                    new DoWorkEventHandler(Worker_DoWork);
                oWorker.RunWorkerCompleted +=
                    new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);
                oWorker.RunWorkerAsync();

                // Update the is checking flag.
                m_bIsChecking = true;

                // Fire the UpdateCheckStarted event.
                OnUpdateCheckStarted(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
