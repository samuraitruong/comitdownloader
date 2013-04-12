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

namespace ComicDownloader.Forms
{
    public partial class ModernUIForm : MetroForm
    {
        public ModernUIForm()
        {
            InitializeComponent();
            var tabs = GetRibbonMenuTags();
            foreach (var item in tabs)
            {
                var tab = new MetroTabPage();
                
                tab.Enabled = true;
                tab.HorizontalScrollbar = true;
                tab.HorizontalScrollbarBarColor = true;
                tab.HorizontalScrollbarHighlightOnWheel = false;
                tab.HorizontalScrollbarSize = 10;
                tab.Location = new System.Drawing.Point(4, 35);
                tab.Name = item.Name;
                tab.Padding = new System.Windows.Forms.Padding(25);
                tab.Size = new System.Drawing.Size(522, 253);
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
                    
                    x += title.Width +2;
                    if (x >= maxwith)
                    {
                        x = 5;
                        y = y + title.Height + 2;
                    }
                }
                metroTabControl1.TabPages.Add(tab);
            }
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

                        var m = new Random((int)DateTime.Now.Ticks % 100);
                        int next = m.Next(0, 13);


                        var title = new MetroFramework.Controls.MetroTile();
                        title.ActiveControl = null;
                        title.Tag = downloader;
                        title.Location = new System.Drawing.Point(20, 150);
                        //this.metroTile2.Name = "metroTile1";
                        title.Size = new System.Drawing.Size(150, 120);
                        title.Style = (MetroFramework.MetroColorStyle)(tag.Titles.Count%13);
                        title.TabIndex = 2;
                        
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


                        //title.Click += new EventHandler(delegate(object sender, EventArgs e)
                        //{
                        //    //var dl = ((RibbonButton)sender).Tag as Downloader;
                        //    //AddChildForm(dl.Name, dl);
                        //    MessageBox.Show("name");
                        //});

                        //tag.Titles.Add(metroTile2);
                        tag.Titles.Add(title);
                    }
                }

            }
            return tags;
        }



    }
}
