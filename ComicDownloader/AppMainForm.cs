using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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
            TruyenTranhTuanForm childForm = new TruyenTranhTuanForm();
            childForm.MdiParent = this;
            childForm.Show();
            //childForm.TabCtrl = this.tabControl1;
            //TabPage tp = new TabPage();
            //tp.Parent = tabControl1;
            //tp.Text = childForm.Text;
            //tp.Show();
            //childForm.TabPag = tp;
            //childForm.Show();
            
            //tabControl1.SelectedTab = tp;

            
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //foreach (FormBase childForm in this.MdiChildren)
            //{
            //    //if (childForm.TabPag.Equals(tabControl1.SelectedTab))
            //    //{
            //    //    childForm.Select();
            //    //}
            //}
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
    }
}
