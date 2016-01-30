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
        public void ShowInfo(StoryInfoCacheFile info)
        {

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
    }
}
