using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Diagnostics;


namespace ComicDownloader.Installer
{
    [RunInstaller(true)]
    public partial class SetEnvironment : System.Configuration.Install.Installer
    {
        public SetEnvironment()
        {
            InitializeComponent();
        }
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);

            RegistryHelper register = new RegistryHelper();
            register.WriteRegistry("Software/Comic/ComicDownloaderV1", "ExpiredDate", DateTime.Now.AddDays(10).ToString());
        }
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            Process.Start("http://www.facebook.com/pages/Comic-Downloader/137897009722629");
        }
    }
}
