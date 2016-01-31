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
using ComicDownloader.Helpers;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ComicDownloader.Forms
{
    public partial class ModernUIForm : MetroForm
    {
        Thread updateThread;
        public static event EventHandler ClipboardUpdate;
        ClipboardAlertForm clipboardForm = null;

        public ModernUIForm()
        {
            clipboardForm = new ClipboardAlertForm();
            InitializeComponent();
            InitializeTabAndTitles();
            ClipboardUpdate = this.onClipboarChanged;
        }

        private void onClipboarChanged(object sender, EventArgs args)
        {
            var text = Clipboard.GetText();
            if (text.StartsWith("http"))
            {
                Task.Run(() =>
                {
                    var dl = Downloader.Resolve(text, true);
                    if (dl != null)
                    {
                        if (dl.CurrentStory != null)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                if (mainApp == null) mainApp = new AppMainForm();

                                clipboardForm.SetData(dl, mainApp);
                                //clipboardForm.WindowState = FormWindowState.Minimized;
                                //clipboardForm.Show();
                                Win32NativeMethods.SetForegroundWindow(clipboardForm.Handle);
                                //clipboardForm.WindowState = FormWindowState.Normal;
                            });

                            
                        }
                    }
                });
            }
        }
        private Color[] colorArray = 
        {
            ColorTranslator.FromHtml("#2c89ee"),
            ColorTranslator.FromHtml("#6cb71e"),
            ColorTranslator.FromHtml("#bb1d48"),
            ColorTranslator.FromHtml("#00a21b"),
            ColorTranslator.FromHtml("#5434ae"),
            ColorTranslator.FromHtml("#002a6e"),
            ColorTranslator.FromHtml("#d44a28"),
            ColorTranslator.FromHtml("#1e7983"),
            ColorTranslator.FromHtml("#fcdb1c"),
            ColorTranslator.FromHtml("#94bd79"),
            ColorTranslator.FromHtml("#7f3978"),
            ColorTranslator.FromHtml("#ff0000"),
            ColorTranslator.FromHtml("#ff6600")
        };

        private void InitializeTabAndTitles()
        {
            metroTabPage1.CustomBackground = true;
            metroTabPage1.BackColor = ColorTranslator.FromHtml("#001941");

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

                tab.CustomBackground = true;
                tab.BackColor = ColorTranslator.FromHtml("#001941");

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
            metroTabControl1.SelectedTab = metroTabControl1.TabPages[0];
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
                        var listNames = new List<String>() { att.MetroTab, att.Name.Substring(0, 1).ToUpper() };
                        listNames.ForEach((name) =>
                        {
                            var tag = tags.Find(p => p.Name == name);

                            if (tag == null)
                            {
                                tag = new TabInfo();
                                tags.Add(tag);
                            }
                            tag.Name = name;

                            //global::System.Resources.ResourceManager resourceMan = new global::System.Resources.ResourceManager("ComicDownloader.Properties.Resources", typeof(ComicDownloader.Properties.Resources).Assembly);

                            Thread.Sleep(new Random().Next(1, 10));
                            var m = new Random(DateTime.Now.Millisecond);
                            int next = m.Next(0, int.MaxValue);

                            var title = new MetroFramework.Controls.MetroTile();
                            title.ActiveControl = null;
                            title.Tag = downloader;
                            title.Location = new System.Drawing.Point(20, 150);
                            title.Cursor = System.Windows.Forms.Cursors.Hand;
                            title.Size = new System.Drawing.Size(150, 120);

                            title.CustomBackground = true;
                            var index = next % colorArray.Length;
                            title.BackColor = colorArray[index];

                            title.CustomForeColor = true;
                            title.ForeColor = ColorTranslator.FromHtml("#ffffff");

                            title.TileTextFontSize = MetroTileTextSize.Medium;
                            title.TileTextFontWeight = MetroTileTextWeight.Bold;

                            //title.Style = (MetroFramework.MetroColorStyle)(next%13);
                            title.TabIndex = 2;
                            //if (title.Style == MetroColorStyle.White) title.Style = MetroColorStyle.Red;
                            title.Text = downloader.Name;
                            title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                            title.Theme = MetroFramework.MetroThemeStyle.Dark;
                            title.Click += new System.EventHandler(delegate (object sender, System.EventArgs e)
                            {
                                var dl = ((MetroTile)sender).Tag as Downloader;
                                if (mainApp == null) mainApp = new AppMainForm();

                                mainApp.Show();
                                mainApp.SetDownloader(dl);
                                mainApp.WindowState = FormWindowState.Maximized;

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
                        });
                    }
                }

            }
            // pool.Start();
            tags.Sort((x, y) => {
                if(x.Name.Length == 1  && x.Name.Length == 1)
                {
                    return string.CompareOrdinal(x.Name, y.Name);
                }

                if(x.Name.Length>1)
                {
                    return -1;
                }
                return x.Name.Length - y.Name.Length;
            });
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
            int maxheight = metroTabControl1.Height - 120;
            double square = maxheight * maxwith / titles.Count;

            int height = (int)Math.Sqrt(square) - 1;
            int width = (int)square / height - 1;
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
        private ComicDownloaderSettings Settings = SettingForm.GetSetting();

        private void ModernUIForm_Load(object sender, EventArgs e)
        {
            //updateThread = new Thread(new ThreadStart(this.BackgroundUpdate));
            //updateThread.Start();
             if (Settings != null && Settings.AutoUpdateListOnStart)
            {
                BackgroundUpdate();
             }

             DisplayInfo();
             DisplayListSupport();
            RegisterClipboardMonitoring();
        }
        private IntPtr _clipboardViewerNext;
        private void RegisterClipboardMonitoring()
        {
            //Win32NativeMethods.SetParent(Handle, Win32NativeMethods.HWND_MESSAGE);
            // Win32NativeMethods.AddClipboardFormatListener(Handle);

            _clipboardViewerNext = Win32NativeMethods.SetClipboardViewer(this.Handle);
        }
        private static void OnClipboardUpdate(EventArgs e)
        {
            var handler = ClipboardUpdate;
            if (handler != null)
            {
                handler(null, e);
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);    // Process the message 

            if (m.Msg == Win32NativeMethods.WM_DRAWCLIPBOARD)
            {
                OnClipboardUpdate(null);

                //IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data

                //if (iData.GetDataPresent(DataFormats.Text))
                //{
                //    string text = (string)iData.GetData(DataFormats.Text);      // Clipboard text
                //                                                                // do something with it
                //}
                //else if (iData.GetDataPresent(DataFormats.Bitmap))
                //{
                //    Bitmap image = (Bitmap)iData.GetData(DataFormats.Bitmap);   // Clipboard image
                //                                                                // do something with it
                //}
            }
        }

        //protected override void WndProc(ref Message m)
        //{
        //    //if (m.Msg == Win32NativeMethods.WM_CLIPBOARDUPDATE)
        //    //{
        //    //    OnClipboardUpdate(null);
        //    //}
        //    base.WndProc(ref m);
        //}

        public void DisplayListSupport()
        {
            //objectListView1.SetObjects(Downloader.GetAllDownloaders());
            
        }
        private void DisplayInfo()
        {
            AssemblyInfoHelper info= new AssemblyInfoHelper(this.GetType());

            lnkAbout.Text = string.Format("{0} v{1}  Release On {2}[{3}]",info.Title, info.AssemblyVersion, info.ReleaseDate, info.Copyright);
        }
        private object locker = DateTime.Now;
        public void BackgroundUpdate()
        {
            metroButton1.Enabled = false;
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            BackgroundUpdate();
        }

        private void ModernUIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Win32NativeMethods.ChangeClipboardChain(this.Handle, _clipboardViewerNext);
            if (mainApp != null) mainApp.ApplicationBeiningExited = true;
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            DisplayFormOnMainApp((new SearchForm()));
            
        }

        private void DisplayFormOnMainApp(Form form)
        {
            if (mainApp == null) mainApp = new AppMainForm();
            mainApp.Show();
            mainApp.ShowForm(form);
            mainApp.WindowState = FormWindowState.Maximized;
        }

        private void tlSetting_Click(object sender, EventArgs e)
        {
            DisplayFormOnMainApp(new SettingForm());
        }

        private void QueueDownload_Click(object sender, EventArgs e)
        {
            DisplayFormOnMainApp(new QueueDownloadForm());
        }

        private void tlLastestUpdate_Click(object sender, EventArgs e)
        {
            DisplayFormOnMainApp(new LastestChapterUpdateForm());
        }

        private void bntSearch_Click(object sender, EventArgs e)
        {
            SearchForm frm = new SearchForm(txtKeyword.Text);
            
            DisplayFormOnMainApp(frm);
        }

        private void txtKeyword_TextChanged(object sender, EventArgs e)
        {
            bntSearch.Enabled = !string.IsNullOrEmpty(txtKeyword.Text);
        }

        private void metroTile1_Click_1(object sender, EventArgs e)
        {
            /* AutoUpdater.Start function takes following Arguments
             * 1. url of the appcast xml file that specifies download url, changelog url, application Version and title
             * 2. If you want user to select remind later interval then set lateUserSelectRemindLater as true. If you select true third and fourth arguments will be ignored.
             * 3. reminderLaterTime is a remind later timespan value if user choose Remind Later.
             * 4. reminderLaterTimeFormat is a time format enum that specifies if you want to take remind later time span value as minutes, hours or days.
             * AutoUpdater.Start(string appcastURL, bool lateUserSelectRemindLater, int reminderLaterTime, int reminderLaterTimeFormat)
            */
            //AutoUpdater.AutoUpdater.Start("http://10.195.131.124:8080/ComicDownloader/updates.xml");
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=QP7B8JQTQY2ZU&lc=VN&item_name=Comic%20Downloader&currency_code=USD&bn=PP%2dDonationsBF%3abtn_donateCC_LG%2egif%3aNonHosted");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
    }
}
