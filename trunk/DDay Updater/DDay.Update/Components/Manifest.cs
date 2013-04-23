using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;

namespace DDay.Update
{
    public class Manifest
    {
        #region Static Protected Methods

        static protected XmlNamespaceManager GetNamespaceManager(XmlDocument doc)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace(string.Empty, "urn:schemas-microsoft-com:asm.v2");
            nsmgr.AddNamespace("dsig", "http://www.w3.org/2000/09/xmldsig#");
            nsmgr.AddNamespace("asmv1", "urn:schemas-microsoft-com:asm.v1");
            nsmgr.AddNamespace("asmv2", "urn:schemas-microsoft-com:asm.v2");
            nsmgr.AddNamespace("xrml", "urn:mpeg:mpeg21:2003:01-REL-R-NS");
            nsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            return nsmgr;
        }

        #endregion

        #region Private Fields

        private XmlDocument _Document;
        private XmlNamespaceManager _NamespaceManager;
        private List<Dependency> _Dependencies;
        private Uri _Uri;
        private string _Username;
        private string _Password;
        private string _Domain;        
        private Dependency _Parent = null;
        private AssemblyIdentity _AssemblyIdentity;
        private bool _SuccessfullyLoaded = false;        

        #endregion

        #region Protected Properties

        protected XmlDocument Document
        {
            get { return _Document; }
            set { _Document = value; }
        }

        protected XmlNamespaceManager NamespaceManager
        {
            get { return _NamespaceManager; }
            set { _NamespaceManager = value; }
        }        

        #endregion

        #region Public Properties

        public List<Dependency> Dependencies
        {
            get { return _Dependencies; }
            set { _Dependencies = value; }
        }

        public IEnumerable<DependentAssembly> DependentAssemblies
        {
            get
            {
                foreach (Dependency dependency in Dependencies)
                {
                    if (dependency is DependentAssembly)
                        yield return (DependentAssembly)dependency;
                    foreach (DependentAssembly d in dependency.DependentAssemblies)
                        yield return d;
                }
            }
        }

        public Uri Uri
        {
            get { return _Uri; }
            set { _Uri = value; }
        }

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string Domain
        {
            get { return _Domain; }
            set { _Domain = value; }
        }

        public Dependency Parent
        {
            get { return _Parent; }
            set { _Parent = value; }
        }
        
        public AssemblyIdentity AssemblyIdentity
        {
            get { return _AssemblyIdentity; }
            set { _AssemblyIdentity = value; }
        }

        public Version CurrentPublishedVersion
        {
            get
            {
                if (Document != null)
                {                    
                    // Determine the version of the application from the server
                    XmlElement elm = Document.SelectSingleNode(
                        "/asmv1:assembly/asmv1:assemblyIdentity",
                        NamespaceManager) as XmlElement;

                    return new Version(elm.Attributes["version"].Value);
                }
                return new Version(0, 0, 0, 0);
            }
        }

        public DeploymentManifest DeploymentManifest
        {
            get
            {
                Manifest manifest = this;
                while (manifest.Parent != null &&
                    !(manifest is DeploymentManifest))
                    manifest = manifest.Parent.Parent;

                if (manifest is DeploymentManifest)
                    return (DeploymentManifest)manifest;
                else return null;
            }
        }

        public bool SuccessfullyLoaded
        {
            get { return _SuccessfullyLoaded; }
        }

        #endregion

        #region Constructors

        public Manifest()
        {
            Dependencies = new List<Dependency>();
        }
        public Manifest(Uri uri) : this(null, uri, null, null, null) {}
        public Manifest(Uri uri, string username, string password, string domain)
            : this(null, uri, username, password, domain) {}
        public Manifest(Dependency parent, Uri uri, string username, string password, string domain)
            : this()
        {
            Parent = parent;
            LoadFromUri(uri, username, password, domain);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Given a URI downloads the XML Manifest file
        /// </summary>
        /// <returns>An XML Document with the contents of the manifest</returns>
        public XmlDocument LoadFromUri(Uri uri) { return LoadFromUri(uri, null, null, null); }
        virtual public XmlDocument LoadFromUri(Uri uri, string username, string password, string domain)
        {
            WebClient client = new WebClient();
            if (username != null &&
                password != null)
                client.Credentials = new NetworkCredential(username, password, domain);

            // Create an XPath document using the downloaded manifest
            Stream clientStream = client.OpenRead(uri);
            Document = new XmlDocument();
            Document.Load(clientStream);
            clientStream.Close();

            // Load a namespace manager for this Manifest
            NamespaceManager = GetNamespaceManager(Document);

            // Record Uri, username, password, and domain
            Uri = uri;
            Username = username;
            Password = password;
            Domain = domain;

            // Load assembly identity
            XmlNode aiNode = Document.SelectSingleNode(
                "/asmv1:assembly/asmv1:assemblyIdentity",
                NamespaceManager);
            if (aiNode != null)
            {
                AssemblyIdentity = new AssemblyIdentity(this, aiNode, NamespaceManager);
            }

            // Load each dependency
            foreach (XmlNode node in Document.SelectNodes(
                "/asmv1:assembly/asmv2:dependency",
                NamespaceManager))
            {
                Dependencies.Add(new Dependency(this, node, NamespaceManager));
            }

            _SuccessfullyLoaded = true;
            return Document;
        }

        virtual public void Save(string filePath)
        {
            // Create the directory, if it doesn't exist!
            string directoryName = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);

            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            XmlTextWriter xtw = new XmlTextWriter(fs, Encoding.UTF8);
            xtw.Formatting = Formatting.Indented;
            xtw.Indentation = 4;
            xtw.IndentChar = ' ';
            Document.WriteTo(xtw);
            xtw.Close();
        }

        #endregion
    }
}
