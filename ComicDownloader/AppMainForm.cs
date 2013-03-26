using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ComicDownloader.Engines;

namespace ComicDownloader
{
    public partial class AppMainForm : Form
    {
        public AppMainForm()
        {
            InitializeComponent();
        }

        private void btnAddNewTTT_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new TruyenTranhTuanDownloader();
            childForm.Text = "Truyen Tranh Tuan";
            childForm.Show();
        }

        public void UpdateActiveTabTitle(string title)
        {
            mdiTabStrip1.SelectedTab.Text = title;
        }
        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
        }

       

        private void ribbonOrbMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AppMainForm_Load(object sender, EventArgs e)
        {
            Intro childForm = new Intro();
            childForm.MdiParent = this;
            //childForm.WindowState = FormWindowState.Maximized;
            childForm.Text = "Introduction";
            childForm.Show();
        }

        private void ribbonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bntRefeshList_Click(object sender, EventArgs e)
        {
            
        }

       

        private void btnVechaiForm_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new VechaiDownloader();
            childForm.Text = "Vechai.Info";
            childForm.Show();
        }

        private void btnBlogTruyenAdd_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new BlogTruyenDownloader();
            childForm.Text = "BlogTruyen.com";
            childForm.Show();
        }

        private void btnTruyenVietBoomAdd_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new TruyenVietBoomDownloader();
            childForm.Text = "Truyen.VietBoom.com";
            childForm.Show();
        }

        private void btnTT8Add_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new TruyenTranh8Downloader();
            childForm.Text = "Truyentranh8.com";
            childForm.Show();
        }

        private void btnTVNSAdd_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new TruyenVnSharingDownloader();
            childForm.Text = "Truyen.VnSharing.net";
            childForm.Show();
        }

        private void btnTTNAdd_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new TruyenTranhNhanhDownloader();
            childForm.Text = "TruyenTranhNhanh.com";
            childForm.Show();
        }

        private void btnVuiLenAdd_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new ComicVuiLenDownloader();
            childForm.Text = "Comic.Vuilen.com";
            childForm.Show();
        }

        private void bntMangaKungAdd_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new MangaKungDownloader();
            childForm.Text = "MangaKung.com";
            childForm.Show();
        }

        

        private void btnXomTruyenAdd_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new XomTruyenDownloader();
            childForm.Text = "XomTruyen.com";
            childForm.Show();
        }

        private void bntMangaFCAdd_Click(object sender, EventArgs e)
        {
            AddChildForm("Manga FC", new MangaFcDownloader());
        }

        private void AddChildForm(string title, Downloader dl)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = dl;
            childForm.Text = title;
            childForm.Show();
        }

        private void btnTruyen18_Click(object sender, EventArgs e)
        {
            AddChildForm("Truyen 18", new Truyen18Downloader());
        }

        private void btnLauPhimAdd_Click(object sender, EventArgs e)
        {
            AddChildForm("Truyen Alo8", new TruyenLauPhimDownloader());
        }

      

        private void bntNTruyenAdd_Click(object sender, EventArgs e)
        {
            AddChildForm("NTruyen", new NTruyenDownloader());
        }

        private void bntMangaReaderAdd_Click(object sender, EventArgs e)
        {
            AddChildForm("Manga Reader", new MangaReaderDownloader());
        
        }
    }
}
