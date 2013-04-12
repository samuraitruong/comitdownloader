using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using ComicDownloader.Engines;
using MetroFramework.Controls;
using MetroFramework;
using System.Threading;
using Amib.Threading;
using ComicDownloader.Extensions;

namespace ComicDownloader.Forms
{
    public partial class ModernUIForm : MetroForm
    {
        Thread updateThread;
        public ModernUIForm()
        {
            InitializeComponent();
            InitializeTabAndTitles();
        }

        private void InitializeTabAndTitles()
        {
            var tabs = GetRibbonMenuTags();
            foreach (var item in tabs)
            {
                var tab = new MetroTabPage();
                tab.AutoScroll = true;
                tab.Enabled = true;
                tab.HorizontalScrollbar = true;
                tab.HorizontalScrollbarBarColor = true;
                tab.HorizontalScrollbarHighlightOnWheel = false;
                tab.HorizontalScrollbarSize = 10;
                //tab.Location = new System.Drawing.Point(4, 35);
                tab.Name = item.Name;
                tab.Padding = new System.Windows.Forms.Padding(25);
                //tab.Size = new System.Drawing.Size(522, 253);
                tab.TabIndex = 0;
                tab.Text = item.Name;
                tab.VerticalScrollbar = true;
                tab.VerticalScrollbarBarColor = true;
                tab.VerticalScrollbarHighlightOnWheel = false;
                tab.VerticalScrollbarSize = 10;
                tab.Visible = true;

                int maxwith = metroTabControl1.Width;
                int x = 5;
                int y = 5;
                foreach (var title in item.Titles)
                {
                    title.Location = new Point(x, y);
                    tab.Controls.Add(title);

                    x += title.Width + 2;
                    if (x >= maxwith)
                    {
                        x = 5;
                        y = y + title.Height + 2;
                    }
                }
                metroTabControl1.TabPages.Add(tab);
            }
            metroTabControl1.SelectedTab = metroTabControl1.TabPages[1];
        }
        private AppMainForm mainApp = new AppMainForm();

        public class TabInfo
        {
            public string Name { get; set; }
            public List<MetroTile> Titles { get; set; }
            public TabInfo()
            {
                Titles = new List<MetroTile>();
            }

        }
        public List<TabInfo> GetRibbonMenuTags()
        {
            //SmartThreadPool pool = new SmartThreadPool();
            List<TabInfo> tags = new List<TabInfo>();
            foreach (var downloader in Downloader.GetAllDownloaders())
            {
                var attributes = downloader.GetType().GetCustomAttributes(typeof(DownloaderAttribute), true);
                if (attributes != null)
                {
                    foreach (DownloaderAttribute att in attributes)
                    {
                        var tag = tags.Find(p => p.Name == att.MetroTab);
                        if (tag == null)
                        {
                            tag = new TabInfo();
                            tags.Add(tag);
                        }
                        tag.Name = att.MetroTab;

                        //global::System.Resources.ResourceManager resourceMan = new global::System.Resources.ResourceManager("ComicDownloader.Properties.Resources", typeof(ComicDownloader.Properties.Resources).Assembly);

                       Thread.Sleep(new Random().Next(1,10));
                        var m = new Random(DateTime.Now.Millisecond);
                        int next = m.Next(0, int.MaxValue);

                        var title = new MetroFramework.Controls.MetroTile();
                        title.ActiveControl = null;
                        title.Tag = downloader;
                        title.Location = new System.Drawing.Point(20, 150);
                        //this.metroTile2.Name = "metroTile1";
                        title.Size = new System.Drawing.Size(150, 120);
                        title.Style = (MetroFramework.MetroColorStyle)(next%13);
                        title.TabIndex = 2;
                        if (title.Style == MetroColorStyle.White) title.Style = MetroColorStyle.Red;
                        title.Text = downloader.Name;
                        title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        title.Theme = MetroFramework.MetroThemeStyle.Dark;
                        title.Click += new System.EventHandler(delegate(object sender, System.EventArgs e)
                        {
                            var dl = ((MetroTile)sender).Tag as Downloader;
                            if (mainApp == null) mainApp = new AppMainForm();
                            mainApp.Show();
                            mainApp.SetDownloader(dl);
                        });

                        
                        this.metroToolTip1.SetToolTip(title, downloader.Name);

                        //pool.QueueWorkItem(delegate(object obj) {

                        //    TitleLogoUpdate data = (TitleLogoUpdate)obj;
                        //    if(!string.IsNullOrEmpty(data.Downloader.Logo) ){

                        //        var img = data.Downloader.Logo.DownloadAsImage();
                        //        img = img.Clip(data.Title.Width, data.Title.Height);
                        //        data.Title.TileImage = img;
                        //        data.Title.UseTileImage = true;
                        //        data.Title.TileImageAlign = ContentAlignment.MiddleCenter;
                        //        data.Title.TextAlign = ContentAlignment.BottomCenter;
                            
                        //    }
                        
                        
                        //}, 
                        //new TitleLogoUpdate()
                        //{
                        //    Title = title,
                        //    Downloader = downloader
                        //});
                       

                        //tag.Titles.Add(metroTile2);
                        tag.Titles.Add(title);
                    }
                }

            }
           // pool.Start();
            return tags;
        }
        public struct TitleLogoUpdate
        {
            public MetroTile Title { get; set; }
            public Downloader Downloader { get; set; }
        }
        private void metroTile1_Click(object sender, EventArgs e)
        {
            if (mainApp == null) mainApp = new AppMainForm();
            mainApp.Show();
            mainApp.WindowState = FormWindowState.Maximized;
        }

        private void ModernUIForm_Resize(object sender, EventArgs e)
        {
            foreach (MetroTabPage tab in metroTabControl1.TabPages)
            {
                ReCaculatedTitlesSize(tab);

            }
        }

        private  void ReCaculatedTitlesSize(MetroTabPage tab)
        {
            var titles = tab.Controls.Cast<Control>().Where(p => p is MetroTile && p.Tag is Downloader).ToList();

            if (titles.Count == 0) return;
            int x = 5;
            int y = 5;



            int maxwith = metroTabControl1.Width - 100 ;
            int maxheight = metroTabControl1.Height - 15;
            double square = maxheight * maxwith / titles.Count;

            int height = (int)Math.Sqrt(square) - 2;
            int width = (int)square / height - 2;
            SmartThreadPool pool = new SmartThreadPool();

            foreach (var item in titles)
            {
                MetroTile metroTitle = item as MetroTile;

                
        

                //metroTitle.Style = MetroColorStyle.Red;
                metroTitle.Size = new System.Drawing.Size(width, height);


                metroTitle.Location = new Point(x, y);


                x += metroTitle.Width + 2;
                if (x >= maxwith)
                {
                    x = 5;
                    y = y + metroTitle.Height + 2;
                }



                pool.QueueWorkItem(delegate(object obj)
                                                    {

                                                        TitleLogoUpdate data = (TitleLogoUpdate)obj;
                                                        if (!string.IsNullOrEmpty(data.Downloader.Logo))
                                                        {

                                                            var img = data.Downloader.Logo.DownloadAsImage();
                                                            img = img.Clip(data.Title.Width, data.Title.Height);
                                                            data.Title.TileImage = img;
                                                            data.Title.UseTileImage = true;
                                                            data.Title.TileImageAlign = ContentAlignment.MiddleCenter;
                                                            data.Title.TextAlign = ContentAlignment.BottomCenter;

                                                        }


                                                    },
                                                    new TitleLogoUpdate()
                                                    {
                                                        Title = metroTitle,
                                                        Downloader = (Downloader)metroTitle.Tag
                                                    });

            }
            pool.Start();
        }

        private void metroTabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            ReCaculatedTitlesSize(metroTabControl1.SelectedTab as MetroTabPage);
        }

        private void metroTabControl1_Selected(object sender, TabControlEventArgs e)
        {
            ReCaculatedTitlesSize(e.TabPage as MetroTabPage);
        }

        private void ModernUIForm_Load(object sender, EventArgs e)
        {
            //updateThread = new Thread(new ThreadStart(this.BackgroundUpdate));
            //updateThread.Start();
            
            BackgroundUpdate();
        }
        private object locker = DateTime.Now;
        public void BackgroundUpdate()
        {
            SmartThreadPool pool = new SmartThreadPool();
            
            pool.MaxThreads = 8;
            var downloaders = Downloader.GetAllDownloaders();
            updateProgressBar.Minimum = 0;
            updateProgressBar.Maximum = downloaders.Count;
            updateProgressBar.Value = 0;
            lblStatus.Text = "Update database running......";

            foreach (var dl in Downloader.GetAllDownloaders())
            {
                pool.QueueWorkItem(delegate(object objectState)
                {
                    try
                    {
                        Downloader downloader = (Downloader)objectState;
                        downloader.GetListStories(true);
                    }
                    catch (Exception ex)
                    {
                        MyLogger.Log(ex);
                    }
                    finally
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            lock (locker)
                            {
                                updateProgressBar.Increment(1);
                            }
                        }));
                    }

                }, dl);

               

            }
            pool.Start();
            
        }

    }
}
