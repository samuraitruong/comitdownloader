using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Threading;

namespace DDay.Update
{
    public class UpdateFile : IDownloadableFile
    {
        #region Private Fields

        private string _Name;
        private long _Size;
        private string _Group;
        private bool _Optional;
        private ApplicationManifest _Parent;
        private string _Hash;

        #endregion

        #region Public Properties

        /// <summary>
        /// Required. Identifies the name of the file.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Required. Specifies the size, in bytes, of the file.
        /// </summary>
        public long Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        /// <summary>
        /// Optional, if the optional attribute is not specified
        /// or set to false; required if optional is true. The
        /// name of the group to which this file belongs. The
        /// name can be any Unicode string value chosen by the
        /// developer, and is used for downloading files on demand
        /// with the ApplicationDeployment class.
        /// </summary>
        public string Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

        /// <summary>
        /// Optional. Specifies whether this file must download
        /// when the application is first run, or whether the file
        /// should reside only on the server until the application
        /// requests it on demand. If false or undefined, the file
        /// is downloaded when the application is first run or
        /// installed. If true, a group must be specified for the
        /// application manifest to be valid. optional cannot be
        /// true if writeableType is specified with the value
        /// applicationData.
        /// </summary>
        public bool Optional
        {
            get { return _Optional; }
            set { _Optional = value; }
        }

        /// <summary>
        /// Optional. Specifies that this file is a data file.
        /// Currently the only valid value is applicationData.
        /// </summary>
        public string WriteableType
        {
            get { return "applicationData"; }
        }

        public ApplicationManifest Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
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

        /// <summary>
        /// A string representation of the file hash for the file
        /// </summary>
        public string Hash
        {
            get { return _Hash; }
            set { _Hash = value; }
        }

        #endregion

        #region Constructors

        public UpdateFile(ApplicationManifest parent)
        {
            Parent = parent;
        }

        public UpdateFile(ApplicationManifest parent, XmlNode elm, XmlNamespaceManager nsmgr)
            : this(parent)
        {
            if (elm.Attributes["name"] != null)
                Name = elm.Attributes["name"].Value;
            if (elm.Attributes["size"] != null)
                Size = long.Parse(elm.Attributes["size"].Value);
            if (elm.Attributes["group"] != null)
                Group = elm.Attributes["group"].Value;
            if (elm.Attributes["optional"] != null)
                Optional = Convert.ToBoolean(elm.Attributes["optional"].Value);

            // NOTE: fixes a bug where files aren't always updated, due to
            // a change in the file hash.  Thanks to Dan Dixon for the fix.

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

        #region IDownloadableFile Members

        public FileDownloader GetDownloader()
        {
            // NOTE: Fixes bug #1831194 - URI segments already contain a slash.
            string path = string.Join("", Parent.Uri.Segments);
            path = Path.GetDirectoryName(path);
            path = Path.Combine(path, Name);

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
                Name,                
                null,
                Parent.Username,
                Parent.Password,
                Parent.Domain);
        }

        #endregion
    }
}
