using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace DDay.Update
{
    public class DependentAssembly : Dependency, IManifestDependency, IDownloadableFile
    {
        #region Private Fields

        private XmlElement _XmlElement;
        private XmlNamespaceManager _XmlNsMgr;
        private string _CodeBase;
        private string _Visible;        
        private bool _Prerequisite;
        private DependencyTypes _DependencyType;
        private long _Size = long.MinValue;
        private ApplicationManifest _ApplicationManifest;
        private AssemblyIdentity _AssemblyIdentity;
        private string _Hash = string.Empty;        

        #endregion

        #region Public Properties

        /// <summary>
        /// Optional when part of a deployment manifest.
        /// Required when part of an application manifest.
        /// When part of a deployment manifest, 
        /// it is the full path to the application manifest.
        /// When part of an application manifest, it is
        /// the full path to the assembly referenced by this
        /// assembly.
        /// </summary>
        public string CodeBase
        {
            get { return _CodeBase; }
            set
            {
                _CodeBase = value;

                if (_XmlElement != null)
                {
                    _XmlElement.Attributes["codebase"].Value = value;
                }
            }
        }
        
        /// <summary>
        /// Optional. Identifies the top-level application
        /// identity, including its dependencies. Used
        /// internally by ClickOnce to manage application
        /// storage and activation.        
        /// </summary>
        public string Visible
        {
            get { return _Visible; }
            set
            {
                _Visible = value;
                if (_XmlElement != null)
                {
                    _XmlElement.Attributes["visible"].Value = value;
                }
            }
        }
            
        /// <summary>
        /// Optional. Specifies that this assembly should
        /// already exist in the GAC. Valid values are true
        /// and false. If true, and the specified assembly
        /// does not exist in the GAC, the application fails
        /// to run.
        /// </summary>
        public bool Prerequisite
        {
            get { return _Prerequisite; }
            set
            {
                _Prerequisite = value;

                if (_XmlElement != null)
                {
                    _XmlElement.Attributes["preRequisite"].Value = value.ToString();
                }
            }
        }

        /// <summary>
        /// Required when part of a deployment manifest.
        /// Optional when part of an application manifest.
        /// The relationship between this dependency
        /// and the application.
        /// </summary>
        public DependencyTypes DependencyType
        {
            get { return _DependencyType; }
            set
            {
                _DependencyType = value;

                if (_XmlElement != null)
                {
                    _XmlElement.Attributes["dependencyType"].Value = value.ToString();
                }
            }
        }    
    
        /// <summary>
        /// Optional when part of a deployment manifest.
        /// Required when part of an application manifest.
        /// Optional. The size of the application manifest, in bytes.
        /// </summary>
        public long Size
        {
            get { return _Size; }
            set
            {
                _Size = value;

                if (_XmlElement != null)
                {
                    _XmlElement.Attributes["size"].Value = value.ToString();
                }
            }
        }

        /// <summary>        
        /// Optional. The Hash of the dependent assembly.
        /// </summary>
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }

        /// <summary>
        /// Represents the manifest declared in the
        /// CodeBase property.  This property is only
        /// relevant when the dependency is contained
        /// in a deployment manifest.
        /// </summary>
        public ApplicationManifest ApplicationManifest
        {
            get { return _ApplicationManifest; }
            set { _ApplicationManifest = value; }
        }

        public AssemblyIdentity AssemblyIdentity
        {
            get { return _AssemblyIdentity; }
            set { _AssemblyIdentity = value; }
        }

        public string DestinationFolder
        {
            get
            {
                if (Parent != null &&
                    Parent.DeploymentManifest != null &&
                    Parent.DeploymentManifest.CurrentPublishedVersion != null)
                {
                    return Path.Combine(
                        UpdateManager.VersionRepositoryFolder,
                        Parent.DeploymentManifest.CurrentPublishedVersion.ToString()
                    );
                }
                return string.Empty;
            }
        }

        #endregion

        #region Constructors

        public DependentAssembly(Manifest parent) : base(parent) { }
        public DependentAssembly(Manifest parent, XmlNode elm, XmlNamespaceManager nsmgr)
            : base(parent, elm, nsmgr)
        {
            _XmlElement = elm as XmlElement;
            _XmlNsMgr = nsmgr;

            if (elm.Attributes["codebase"] != null)
                CodeBase = elm.Attributes["codebase"].Value;
            if (elm.Attributes["visible"] != null)
                Visible = elm.Attributes["visible"].Value;
            if (elm.Attributes["preRequisite"] != null)
                Prerequisite = Convert.ToBoolean(elm.Attributes["preRequisite"].Value); 
            if (elm.Attributes["dependencyType"] != null)
                DependencyType = (DependencyTypes)Enum.Parse(typeof(DependencyTypes), elm.Attributes["dependencyType"].Value, true);
            if (elm.Attributes["size"] != null)
                Size = long.Parse(elm.Attributes["size"].Value);

            // Load assembly identity
            XmlNode aiNode =
                elm.SelectSingleNode("asmv2:assemblyIdentity", nsmgr);
            if (aiNode != null)
            {
                AssemblyIdentity = new AssemblyIdentity(this, aiNode, nsmgr);
            }

            // Load the assembly hash
            XmlNode hashNode = elm.SelectSingleNode(@"asmv2:hash", nsmgr);
            if (hashNode != null)
            {
                XmlNode hashValueNode = hashNode.SelectSingleNode(@"dsig:DigestValue", nsmgr);
                if (hashValueNode != null && hashValueNode.HasChildNodes)
                {
                    Hash = hashValueNode.FirstChild.Value;
                }
            }
        }

        #endregion

        #region IManifestDependency Members

        public void Load()
        {
            try
            {
                if (!string.IsNullOrEmpty(CodeBase))
                {
                    // NOTE: Fixes bug #1831194 - URI segments already contain a slash.
                    string path = string.Join("", Parent.Uri.Segments);
                    path = Path.GetDirectoryName(path);
                    path = Path.Combine(path, CodeBase);
                    path += Parent.Uri.Query;

                    if (Parent is DeploymentManifest)
                    {
                        UriBuilder uriBuilder = new UriBuilder(
                            Parent.Uri.Scheme,
                            Parent.Uri.Host,
                            Parent.Uri.Port,
                            path);

                        ApplicationManifest = new ApplicationManifest(
                            this,
                            uriBuilder.Uri,
                            Parent.Username,
                            Parent.Password,
                            Parent.Domain);

                        // Add the application manifest to the deployment manifest
                        ((DeploymentManifest)Parent).ApplicationManifest = ApplicationManifest;
                    }
                }
            }
            catch
            {
                throw new ManifestException();
            }
        }         

        #endregion

        #region IDownloadableFile Members

        public FileDownloader GetDownloader()
        {
            string path = string.Join("/", Parent.Uri.Segments);
            path = Path.GetDirectoryName(path);
            path = Path.Combine(path, CodeBase);   
         
            // Determine if a .deploy extension is used for filenames
            if (Parent.DeploymentManifest.Deployment != null &&
                Parent.DeploymentManifest.Deployment.MapFileExtensions)
            {
                path += ".deploy";
            }

            path += Parent.Uri.Query;

            UriBuilder uriBuilder = new UriBuilder(
                Parent.Uri.Scheme,
                Parent.Uri.Host,
                Parent.Uri.Port,
                path);

            return new FileDownloader(
                uriBuilder.Uri,
                Size,
                Hash,
                DestinationFolder,
                CodeBase,
                AssemblyIdentity.Version,                
                Parent.Username,
                Parent.Password,
                Parent.Domain);
        }

        #endregion
    }

    #region DependencyTypes Enum

    public enum DependencyTypes
    {
        Install,        // Component represents a separate installation from the current application.
        Prerequisite    // Component is required by the current application.
    }

    #endregion
}
