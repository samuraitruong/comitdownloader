﻿using System;
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

        private void btnVCAdd_Click(object sender, EventArgs e)
        {
            VeChaiForm childForm = new VeChaiForm();
            childForm.MdiParent = this;
            

            childForm.ListStoryURL = txtVSList._textBoxText;
            childForm.HostUrl = txtVCHost._textBoxText;
            childForm.Text = "VeChai.Info";
            childForm.Show();
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
            File.Delete(VeChaiForm.CACHED_FILE);
        }

        private void btnAddTTTGeneric_Click(object sender, EventArgs e)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = new TruyenTranhTuanDownloader();
            childForm.Text = "Generic Form Tester";
            childForm.Show();
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
    }
}
