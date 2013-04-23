using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DDay.Update.Scripting
{
    public class DeploymentScriptProvider : IScriptProvider
    {
        #region Private Fields

        string _VersionFolder = "Application Files";
        string _ScriptManifestFilename = "script.manifest";

        #endregion

        #region Public Properties

        public string VersionFolder
        {
            get { return _VersionFolder; }
            set { _VersionFolder = value; }
        }

        public string ScriptManifestFilename
        {
            get { return _ScriptManifestFilename; }
            set { _ScriptManifestFilename = value; }
        }

        #endregion

        #region Constructors

        public DeploymentScriptProvider()
        {
        }

        #endregion

        #region IScriptProvider Members

        public IScript[] Get(DeploymentManifest deploymentManifest)
        {
            List<IScript> scripts = new List<IScript>();

            if (deploymentManifest != null &&
                deploymentManifest.Deployment != null &&
                deploymentManifest.Deployment.DeploymentProvider != null &&
                deploymentManifest.AssemblyIdentity != null)
            {
                // Remove the filename from the deployment provider codebase
                Uri uri = new Uri(deploymentManifest.Deployment.DeploymentProvider.CodeBase);
                List<string> segments = new List<string>(uri.Segments);
                segments.RemoveAt(segments.Count - 1);
                
                // Add the version folder
                string path = Path.Combine(
                    string.Join("", segments.ToArray()),
                    VersionFolder);
                
                // Determine what the version folder will be named
                string folderName = Path.GetFileNameWithoutExtension(deploymentManifest.AssemblyIdentity.Name);
                folderName += "_" + deploymentManifest.AssemblyIdentity.Version.ToString().Replace('.', '_');

                // Combine the path with the version
                path = Path.Combine(path, folderName);

                // Add the script manifest filename to the path
                path = Path.Combine(path, ScriptManifestFilename);

                // Build a new Uri with the path
                UriBuilder uriBuilder = new UriBuilder(
                    uri.Scheme,
                    uri.Host,
                    uri.Port,
                    path);

                // FIXME: load the scripts from the script manifest
                // FIXME: should we even bother with a script manifest?
                // We could load the scripts straight out of the deployment.
                // This could be a problem, however, if we wanted to run
                // scripts *before* the new version was downloaded.
                GC.KeepAlive(uriBuilder);
            }

            return scripts.ToArray();
        }

        #endregion
    }
}
