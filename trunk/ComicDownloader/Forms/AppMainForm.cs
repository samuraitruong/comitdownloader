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

namespace ComicDownloader
{
    public partial class AppMainForm : Form
    {
        public AppMainForm()
        {
            InitializeComponent();
            cobDownloaders.DropDownItems.Clear();
            // build menu
            BuildDropDownMenu();

            ribbon1.Tabs.Add(new RibbonTab() { Text = "sss" });

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

        private void bntMangaFoxAdd_Click(object sender, EventArgs e)
        {
            AddChildForm("Manga Fox", new MangaFoxDownloader());
        }

        private void bntMangaEdenAdd_Click(object sender, EventArgs e)
        {
            AddChildForm("Manga Eden", new MangaEdenDownloader());
        }

        private void bntMangaHereAdd_Click(object sender, EventArgs e)
        {
            AddChildForm("Manga Here", new MangaHereDownloader());
        }

        private void ribbonButton1_Click(object sender, EventArgs e)
        {
            Form a = new IView.UI.Forms.MainWindow();
            a.ShowDialog();
        }

        private void bntMangaparkAdd_Click(object sender, EventArgs e)
        {
            AddChildForm("Mangapark", new MangaParkDownloader());
        }
    }
}
