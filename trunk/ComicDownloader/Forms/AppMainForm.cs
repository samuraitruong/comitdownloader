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
using ComicDownloader.Forms;
using ComicDownloader.Properties;
using System.Reflection;
using System.Threading;
using Cx.Windows.Forms;

namespace ComicDownloader
{
    public partial class AppMainForm : Form
    {
        public AppMainForm()
        {
            InitializeComponent();
            // build menu
            BuildDropDownMenu();
            var tags = GetRibbonMenuTags();

            AddTagsToRibbonMenu(tags);
        }

        public class MenuInfo
        {
            public string TagName { get; set; }
            public List<RibbonButton> Downloaders { get; set; }
            public MenuInfo()
            {
                Downloaders = new List<RibbonButton>();
            }
            
        }
        private void AddTagsToRibbonMenu(List<MenuInfo> tags)
        {
            foreach (var tag in tags)
            {
                RibbonTab tab = new RibbonTab()
                {
                    Text = tag.TagName
                };
                ribbon1.Tabs.Add(tab);
                
                foreach (var button in tag.Downloaders)
                {
                    var pnl = new RibbonPanel()
                    {
                       Text = (button.Tag as Downloader).Name,
                    };

                   


                    pnl.Items.Add(button);
                    tab.Panels.Add(pnl);

                }

                
            }
            this.ResumeLayout(false);
            this.PerformLayout();
        }

      

        private List<MenuInfo> GetRibbonMenuTags()
        {
            List<MenuInfo> tags = new List<MenuInfo>();
            foreach (var downloader in Downloader.GetAllDownloaders())
            {
                var attributes = downloader.GetType().GetCustomAttributes(typeof(DownloaderAttribute),true);
                if (attributes != null)
                {
                    foreach (DownloaderAttribute att in attributes)
                    {
                        var tag = tags.Find(p => p.TagName == att.Category);
                        if(tag == null){
                            tag = new MenuInfo() ;
                            tags.Add(tag);
                        }
                        tag.TagName = att.Category;

                        global::System.Resources.ResourceManager resourceMan = new global::System.Resources.ResourceManager("ComicDownloader.Properties.Resources", typeof(Resources).Assembly);

                        RibbonButton button = new RibbonButton()
                        {
                            Image =  resourceMan.GetObject(att.Image32) as Image,
                            Tag = downloader,
                            //Text = downloader.Name
                        };

                        button.Click += new EventHandler(delegate(object sender, EventArgs e)
                        {
                            var dl = ((RibbonButton)sender).Tag as Downloader;
                            AddChildForm(dl.Name, dl);
                        });

                        tag.Downloaders.Add(button);
                    }
                }

            }
            return tags;
        }

        private void BuildDropDownMenu()
        {
            cobDownloaders.DropDownItems.Clear();

            foreach (var downloader in Downloader.GetAllDownloaders().OrderBy(p => p.Name))
            {
                //cobDownloaders.DropDownItems.Add(
                RibbonButton downloaderMenuButton = new RibbonButton()
                {
                    MaximumSize = new System.Drawing.Size(0, 0),
                    MinimumSize = new System.Drawing.Size(0, 0),
                    Text = downloader.Name,
                    Tag = downloader
                };
                downloaderMenuButton.Click += new EventHandler(delegate(object sender, EventArgs e)
                {
                    var dl = ((RibbonButton)sender).Tag as Downloader;

                    AddChildForm(dl.Name, dl);
                });

                cobDownloaders.DropDownItems.Add(downloaderMenuButton);



            }
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

       

        private void AddChildForm(string title, Downloader dl)
        {
            DownloaderForm childForm = new DownloaderForm();
            childForm.MdiParent = this;
            childForm.Downloader = dl;
            childForm.Text = title;
            childForm.Show();
        }

       
        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            Form a = new IView.UI.Forms.MainWindow();
            a.ShowDialog();
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            Form form = new SettingForm();
            form.MdiParent = this;
            form.Show();
        }
        public QueueDownloadForm QueueForm { get; set; } 

        private void bntQueueDownload_Click(object sender, EventArgs e)
        {
            ShowQueueForm(false);
        }

        public void ShowQueueForm(bool start)
        {
            if (QueueForm == null)
            {
                QueueForm = new QueueDownloadForm();
                QueueForm.MdiParent = this;
                QueueForm.Tag = mdiTabStrip1.SelectedTab;
                QueueForm.Show();
            }
            else
            {
                bool found = false;
                foreach (MdiTabStripButton item in mdiTabStrip1.Items)
                {
                    if (item.GetMdiChild() == QueueForm)
                    {
                        item.PerformButtonClick();
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    QueueForm = new QueueDownloadForm();
                    QueueForm.MdiParent = this;
                    QueueForm.Tag = mdiTabStrip1.SelectedTab;
                    QueueForm.Show();
                }
                
               
            }

            if (start)
            {
                QueueForm.StartQueue();
            }
            ribbon1.Tabs[0].SetActive(true);
                    
        }

        
        private void bntStartQueue_Click(object sender, EventArgs e)
        {
            ShowQueueForm(true);
            //QueueForm.StartQueue();
            
        }

        private void mdiTabStrip1_TabIndexChanged(object sender, EventArgs e)
        {
            var item = mdiTabStrip1.Items[mdiTabStrip1.TabIndex];
            
        }

        private void bntClearQueue_Click(object sender, EventArgs e)
        {
           // ShowQueueForm();
            QueueForm.ClearQueue();
        }

        private void bntResumeError_Click(object sender, EventArgs e)
        {
            //ShowQueueForm();
            QueueForm.ResumeDownloadItems(DownloadStatus.Error);
        }

        
    }
}
