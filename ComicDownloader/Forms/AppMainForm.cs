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
using NetduinoLibrary.Toolbox;
using CassiniDev;
using ComicDownloader.Helpers;
using System.Diagnostics;

namespace ComicDownloader
{
    public partial class AppMainForm : Form
    {
        public AppMainForm()
        {
            InitializeComponent();
            var tags = GetRibbonMenuTags();
            
            // build menu
            BuildDropDownMenu();

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
                        var tag = tags.Find(p => p.TagName == att.MenuGroup);
                        if(tag == null){
                            tag = new MenuInfo() ;
                            tags.Add(tag);
                        }
                        tag.TagName = att.MenuGroup;

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

            List<RibbonComboBox> languages = new List<RibbonComboBox>();

            foreach (var downloader in Downloader.GetAllDownloaders())
            {
                var attributes = downloader.GetType().GetCustomAttributes(typeof(DownloaderAttribute), true);
                if (attributes != null)
                {
                    foreach (DownloaderAttribute att in attributes)
                    {
                        var tag = languages.Find(p => p.Tag!=null && p.Tag.ToString() == att.Language);
                        if (tag == null)
                        {
                            tag = new RibbonComboBox()
                            {
                                Text = att.Language,
                                Value = att.Language,
                                Tag = att.Language,
                                TextBoxText= att.Language
                            };
                            languages.Add(tag);
                        }
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

                        tag.DropDownItems.Add(downloaderMenuButton);
                    }
                }
            }
            foreach (var item in languages)
            {
                cobDownloaders.DropDownItems.Add(item);



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
            childForm.WindowState = FormWindowState.Minimized;
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

       
        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            //Form a = new IView.UI.Forms.MainWindow();
            //a.ShowDialog();

            var url =  new AssemblyInfoHelper(this.GetType()).Company;
            Process.Start(url);

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
                
                QueueForm.OnQueueStart += new QueueDownloadForm.ExternalCall(QueueForm_OnQueueStart);
                QueueForm.OnQueueCompleted += new QueueDownloadForm.ExternalCall(QueueForm_OnQueueCompleted);
                QueueForm.OnFormActivate += new QueueDownloadForm.ExternalCall(QueueForm_OnFormActivate);

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

        void QueueForm_OnFormActivate(object obj)
        {
            bntStopQueue.Enabled = true;
            bntStartQueue.Enabled = true;
            bntClearQueue.Enabled = true;
            bntResumeError.Enabled = true;
            //set activate tab
            rbtHome.SetActive(true);
        }

        void QueueForm_OnQueueCompleted(object obj)
        {
            bntStopQueue.Enabled = false;
            bntStartQueue.Enabled = true;
            bntClearQueue.Enabled = true;
            bntResumeError.Enabled = true;

            //if (SettingForm.GetSetting().WhenDoneAction == FinishActions.Nothing)
            {
                Form p = new QueueCompleteForm();
                p.ShowDialog();
            }
        }

        void QueueForm_OnQueueStart(object obj)
        {
            bntStopQueue.Enabled = true;
            bntStartQueue.Enabled = false;
            bntClearQueue.Enabled = false;
            bntResumeError.Enabled = false;
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

        private void bntStopQueue_Click(object sender, EventArgs e)
        {
            QueueForm.AbortQueue();
        }

        private void bntSupports_Click(object sender, EventArgs e)
        {
            HostProviderSupportForm childForm = new HostProviderSupportForm();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Minimized;
            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void btnLastestUpdate_Click(object sender, EventArgs e)
        {
            LastestChapterUpdateForm childForm = new LastestChapterUpdateForm();
            childForm.MdiParent = this;
            childForm.WindowState = FormWindowState.Minimized;

            childForm.Show();
            childForm.WindowState = FormWindowState.Maximized;
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
            StartServerForm serverForm = new StartServerForm();
            serverForm.MdiParent= this;
            serverForm.WindowState = FormWindowState.Minimized;
            serverForm.Show();
            serverForm.WindowState = FormWindowState.Maximized;
        }

        private void bntCasiniServer_Click(object sender, EventArgs e)
        {
            //Server server = new Server(0,"/","c:\\", false, true);
            WebServerFormView form = new WebServerFormView(null);
            form.ShowDialog();
        }

        private void bntSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.MdiParent = this;
            searchForm.WindowState = FormWindowState.Minimized;
            searchForm.Show();
            searchForm.WindowState = FormWindowState.Maximized;
        }



        internal void SetDownloader(Downloader dl)
        {
            AddChildForm(dl.Name, dl);
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
