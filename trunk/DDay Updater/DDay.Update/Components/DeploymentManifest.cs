using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DDay.Update
{
    public class DeploymentManifest : Manifest
    {
        #region Private Fields

        private Deployment _Deployment;
        private ApplicationManifest _ApplicationManifest;
        private Description _Description;        

        #endregion

        #region Public Properties

        /// <summary>
        /// Optional. Identifies the attributes used for the deployment
        /// of updates and exposure to the system.
        /// </summary>
        public Deployment Deployment
        {
            get { return _Deployment; }
            set { _Deployment = value; }
        }

        /// <summary>
        /// The application manifest that belongs to the deployment
        /// manifest.  This is only valid after loading the application
        /// manifest via a call to LoadApplicationManifest().
        /// </summary>
        public ApplicationManifest ApplicationManifest
        {
            get { return _ApplicationManifest; }
            set { _ApplicationManifest = value; }
        }

        /// <summary>
        /// Required. Identifies application information used to
        /// create a shell presence and the Add or Remove Programs
        /// item in Control Panel.
        /// </summary>
        public Description Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        #endregion

        #region Constructors

        public DeploymentManifest() : base() { }
        public DeploymentManifest(Uri uri) : base(uri) {}
        public DeploymentManifest(Uri uri, string username, string password, string domain) 
            : base(uri, username, password, domain) {}
        public DeploymentManifest(Dependency parent, Uri uri, string username, string password, string domain)
            : base(parent, uri, username, password, domain) { }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads all dependencies that may contain an application manifest.
        /// </summary>
        virtual public void LoadApplicationManifest()
        {
            if (ApplicationManifest == null)
            {
                foreach (Dependency dependency in Dependencies)
                {
                    // Load the base dependency
                    if (dependency is IManifestDependency)
                        ((IManifestDependency)dependency).Load();

                    // Load all child dependencies
                    foreach (Dependency child in dependency.Dependencies)
                    {
                        if (child is IManifestDependency)
                            ((IManifestDependency)child).Load();
                    }
                }
            }
        }

        #endregion

        #region Overrides

        public override XmlDocument LoadFromUri(Uri uri, string username, string password, string domain)
        {
            // Normalize our parameters
            if (string.Empty.Equals(username))
                username = null;
            if (string.Empty.Equals(password))
                password = null;
            if (string.Empty.Equals(domain))
                domain = null;

            XmlDocument doc = base.LoadFromUri(uri, username, password, domain);

            // Assign the deployment section in the manifest            
            XmlNode node = doc.SelectSingleNode(
                "/asmv1:assembly/asmv2:deployment",
                NamespaceManager);
            
            // Get a new deployment object from the manifest
            if (node != null)            
                Deployment = new Deployment(this, node, NamespaceManager);            

            // Assign the description section to the manifest
            node = doc.SelectSingleNode(
                "/asmv1:assembly/asmv1:description",
                NamespaceManager);
            if (node != null)
                Description = new Description(node, NamespaceManager);

            return doc;
        }

        #endregion
    }
}
