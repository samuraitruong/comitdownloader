using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DDay.Update
{
    public class ApplicationManifest : Manifest
    {
        #region Private Fields

        private EntryPoint _EntryPoint;
        private List<UpdateFile> _Files = new List<UpdateFile>();        

        #endregion

        #region Public Properties

        public EntryPoint EntryPoint
        {
            get { return _EntryPoint; }
            set { _EntryPoint = value; }
        }

        public List<UpdateFile> Files
        {
            get { return _Files; }
            set { _Files = value; }
        }

        public IEnumerable<IDownloadableFile> DownloadableFiles
        {
            get
            {
                foreach (DependentAssembly da in DependentAssemblies)
                    if (da.DependencyType == DependencyTypes.Install)
                        yield return da;
                foreach (UpdateFile file in Files)
                    yield return file;
            }
        }

        #endregion

        #region Constructors

        public ApplicationManifest() : base() { }
        public ApplicationManifest(Uri uri) : base(uri) {}
        public ApplicationManifest(Uri uri, string username, string password, string domain) 
            : base(uri, username, password, domain) {}
        public ApplicationManifest(Dependency parent, Uri uri, string username, string password, string domain)
            : base(parent, uri, username, password, domain) { }

        #endregion

        #region Overrides

        public override XmlDocument LoadFromUri(Uri uri, string username, string password, string domain)
        {
            XmlDocument doc = base.LoadFromUri(uri, username, password, domain);

            // Load the entry point for the application
            XmlNode node = doc.SelectSingleNode("/asmv1:assembly/asmv2:entryPoint", NamespaceManager);
            if (node != null)
                EntryPoint = new EntryPoint(node, NamespaceManager);

            foreach(XmlNode fileNode in doc.SelectNodes("/asmv1:assembly/asmv2:file", NamespaceManager))
            {
                Files.Add(new UpdateFile(this, fileNode, NamespaceManager));
            }

            return doc;
        }

        #endregion
    }
}
