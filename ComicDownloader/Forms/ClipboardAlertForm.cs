using ComicDownloader.Engines;
using MetroFramework.Forms;
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
    public partial class ClipboardAlertForm : MetroForm
    {
        private Downloader downloader;
        private AppMainForm mainForm;
        public ClipboardAlertForm()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Hide();
            mainForm.SetDownloader(this.downloader, this.downloader.CurrentStory.Url, true);
            mainForm.Show();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        public void SetNotification()
        {
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.ShowBalloonTip(2000);
        }

        internal void SetData(Downloader dl, AppMainForm mdiForm)
        {
            mainForm = mdiForm;
            downloader = dl;
            SetNotification();
            lblUrl.Text = dl.HostUrl;
            lblName.Text = dl.Name;
            lblMangaName.Text = dl.CurrentStory.Name;
            this.Text = dl.Name + "- " + dl.CurrentStory.Name;
            lnkMangaUrl.Text = dl.CurrentStory.Url;
            lblChapters.Text = dl.CurrentStory.ChapterCount.ToString();
            lblSumary.Text = dl.CurrentStory.Summary;

            Task.Run(() =>
            {
                try
                {
                    //replace by image to story
                    pictureBox1.ImageLocation = dl.Logo;
                    pictureBox1.Load();
                }
                catch (Exception ex)
                {

                }
            });

            this.Show();
            this.SetNotification();
        }
    }
}
