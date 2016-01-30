using ComicDownloader.Engines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicDownloader.Forms
{
    public partial class DownloaderInfoForm : Form
    {
        public DownloaderInfoForm()
        {
            InitializeComponent();
        }
        public void ShowInfo(StoryInfoCacheFile info, Downloader dl)
        {
            lblUrl.Text = dl.HostUrl;
            lblName.Text = dl.Name;
            lblTotal.Text = info.Stories.Count.ToString();
            lblUpdated.Text = info.Updated.ToString();
            lblEllapsedTime.Text = TimeSpan.FromMilliseconds(info.TotalTime).ToFriendlyDisplay(5);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
