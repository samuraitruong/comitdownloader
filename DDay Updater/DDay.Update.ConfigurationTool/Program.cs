using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DDay.Update.ConfigurationTool.Forms;
using System.Globalization;
using System.IO;
using System.Net;

namespace DDay.Update.ConfigurationTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static public DeploymentManifest ValidateUpdateUri(DeploymentManifest dp, string updateUri)
        {
            return ValidateUpdateUri(dp, updateUri, null, null, null);
        }

        static public DeploymentManifest ValidateUpdateUri(
            DeploymentManifest dp,
            string updateUri,
            string username,
            string password,
            string domain)
        {
            DeploymentManifest deploymentManifest = null;

            try
            {
                deploymentManifest = new DeploymentManifest(new Uri(updateUri), username, password, domain);
                if (deploymentManifest == null)
                    throw new Exception("A deployment manifest could not be found at the URI provided.");
            }
            catch (WebException ex)
            {
                if (string.IsNullOrEmpty(username) &&
                    string.IsNullOrEmpty(password))
                {
                    // No username/password were provided,
                    // let's see if this was an "Unauthorized" message.
                    HttpWebResponse response = ex.Response as HttpWebResponse;
                    if (response != null &&
                        response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        // Gather credentials and try again.
                        CredentialsForm cf = new CredentialsForm();
                        if (cf.ShowDialog() == DialogResult.OK)
                            deploymentManifest = ValidateUpdateUri(dp, updateUri, cf.Username, cf.Password, cf.Domain);
                    }
                }
                else throw ex;
            }
            catch (Exception ex)
            {
                if (dp != null)
                {
                    // Append the deployment manifest name to the end of the
                    // update uri, if it isn't already provided
                    if (!updateUri.Trim().EndsWith(dp.AssemblyIdentity.Name, true, CultureInfo.CurrentCulture))
                    {
                        UriBuilder uriBuilder = new UriBuilder(updateUri);
                        uriBuilder.Path = Path.Combine(uriBuilder.Path, dp.AssemblyIdentity.Name);
                        deploymentManifest = ValidateUpdateUri(dp, uriBuilder.Uri.AbsoluteUri, username, password, domain);                        

                        if (deploymentManifest == null)
                            throw ex;
                    }
                }
                else throw ex;
            }

            if (deploymentManifest != null)
            {
                // Load the application manifest
                deploymentManifest.LoadApplicationManifest();
            }

            return deploymentManifest;
        }
    }
}