using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cx.Windows.Forms;
using ComicDownloader.Engines;

namespace ComicDownloader
{
    public partial class HostProviderSupportForm : MdiChildForm
    {
        public HostProviderSupportForm()
        {
            InitializeComponent();
        }

        private void HostProviderSupportForm_Load(object sender, EventArgs e)
        {
            var downloaders = Downloader.GetAllDownloaders();
            List<object> ds = new List<object>();
            foreach (var item in downloaders)
            {
                var attrs = item.GetType().GetCustomAttributes(typeof(DownloaderAttribute),true).Cast<DownloaderAttribute>().ToList();

                foreach (var att in attrs)
                {
                    ds.Add(new { 
                        Language = att.Language,
                        HostUrl = item.HostUrl,
                        Name= item.Name.TrimEnd(" -".ToCharArray())
                    });
                }
                
                
            }
            dataListView1.SetObjects(ds.Distinct());
        }
    }
}
