using System; using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cx.Windows.Forms;
using System.Threading;
using ComicDownloader.Engines;
using MRG.Controls.UI;
using ComicDownoader.Forms;
using ExtendedWebBrowser2;
using Amib.Threading;
using ComicDownloader.Extensions;
using System.IO;
using BrightIdeasSoftware;
using ComicDownloader.Properties;
namespace ComicDownloader.Forms
{
    public partial class SearchForm : MdiChildForm
    {
        public class SearchItem
        {
            public string Provider { get; set; }
            public string StoryName { get; set; }
            //public string ChapterName { get; set; }
            //public string ChapterUrl { get; set; }
            public string StoryUrl { get; set; }
        }
        private List<SearchItem> DataSource = new List<SearchItem>();

        public SearchForm()
        {
            InitializeComponent();
            LoadingCircle ci = new LoadingCircle();
            
            this.Controls.Add(ci);
            ci.BringToFront();
            ci.Active = true;
        }

        public SearchForm(string keyword)
        {
            InitializeComponent();
            LoadingCircle ci = new LoadingCircle();

            this.Controls.Add(ci);
            ci.BringToFront();
            ci.Active = true;
            txtKeyword.Text = keyword;

            if(!string.IsNullOrEmpty(keyword)) bntCacheSearch.PerformClick();
        }

        
        struct SearchThreadParam
        {
            public Downloader Downloader { get; set; }
            public ManualResetEvent ResetEvent { get; set; }
            public string Keyword { get; set; }
            public bool Online { get; set; }
            public bool Recache { get; set; }
            
        }
             
        private void LastestChapterUpdateForm_Load(object sender, EventArgs e)
        {
            
        }

        private bool contextMenuShowing = false;
        private object GetSearchItems(object obj)
        {
            SearchThreadParam param = (SearchThreadParam)obj;

            List<StoryInfo> list = new List<StoryInfo>();
            var tempLst = new List<SearchItem>();

            try
            {
                list = param.Downloader.Search(param.Keyword, param.Online, param.Recache);

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        tempLst.Add(new SearchItem()
                        {
                            Provider = param.Downloader.Name.TrimStart(" -".ToCharArray()),
                            StoryName = item.Name,
                            StoryUrl = item.Url
                        });
                    }
                }
            }
            catch(Exception ex)
            {
                MyLogger.Log(ex);
            }
            finally
            {
                if (tempLst.Count > 0)
                {
                    
                    lock (DataSource)
                    {
                        itemCounts += tempLst.Count;
                        DataSource.AddRange(tempLst);
                       // if (!contextMenuShowing)
                        {
                            lvLastestUpdates.AddObjects(tempLst);
                        }

                        hasChanged = true;
                    }
                }

                param.ResetEvent.Set();
                this.Invoke(new MethodInvoker(delegate()
                {
                    progressBar.Increment(1);
                    lblStatus.Text = "Item(s) found : " + itemCounts.ToString();
                    //this.Text = "Lastest updates - Loading[" + ((float)progressBar.Value / progressBar.Maximum).ToString("p") +"]";
                }));
            }

            return null;
        }

        private void addChapterToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LastestChapterUpdateForm_Resize(object sender, EventArgs e)
        {
            //progressBar.Size = new Size(this.statusStrip1.Width - 15, progressBar.Height);

            
        }

        private void readThisChapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
             var selectedItems = this.lvLastestUpdates.SelectedItems[0];
            var col = selectedItems.ListView.Columns.Cast<ColumnHeader>().FirstOrDefault(p => p.Text == "ChapterUrl");
            var value = selectedItems.SubItems[col.Index].Text;
            
            ReadOnlineForm form = new ReadOnlineForm(value);
            form.Show(this);

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var selectedItems = this.lvLastestUpdates.SelectedItems[0];
            var col = selectedItems.ListView.Columns.Cast<ColumnHeader>().FirstOrDefault(p => p.Text == "ChapterUrl");
            var value = selectedItems.SubItems[col.Index].Text;

            BrowserForm form = new BrowserForm(value);
            form.ShowDialog(this);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lvLastestUpdates_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bntCacheSearch_Click(object sender, EventArgs e)
        {
            DoSearch(txtKeyword.Text, false,false);
        }
        int itemCounts = 0;
        private void DoSearch(string keyword, bool online, bool recache)
        {
            if(string.IsNullOrEmpty(keyword) || keyword.Length<3) {

                if (MessageBox.Show("Keyword is empty of too short will have a lot of result. It will take long time to complete action. Do you want to continue?", "Short keyword search", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            loadingCircle1.Active = true;
            loadingCircle1.Visible = true;
            itemCounts = 0;
            this.Text = "Search  - [" + (string.IsNullOrEmpty(keyword)?"All": keyword )+ "]";
            DataSource.Clear();

            TextMatchFilter filter = TextMatchFilter.Contains(this.lvLastestUpdates, keyword);
            this.lvLastestUpdates.ModelFilter = filter;
            this.lvLastestUpdates.DefaultRenderer = new HighlightTextRenderer(filter);
            
            lvLastestUpdates.SetObjects(DataSource);
            
            var downloaders = ComicDownloader.Engines.Downloader.GetAllDownloaders();
            progressBar.Maximum = downloaders.Count;
            progressBar.Step = 1;
            progressBar.Value = 0;

            

            //ManualResetEvent[] doneEvents = new ManualResetEvent[downloaders.Count];


            new Thread(delegate()
            {

                SmartThreadPool pool = new SmartThreadPool()
                {
                    MaxThreads = SettingForm.GetSetting().SearchThreads
                };
                List<IWorkItemResult> workers = new List<IWorkItemResult>();
                for (int i = 0; i < downloaders.Count; i++)
                {
                   
                    workers.Add(pool.QueueWorkItem(new WorkItemCallback(this.GetSearchItems), new SearchThreadParam()
                    {
                        Downloader = downloaders[i],
                        //ResetEvent = doneEvents[i],
                        Keyword = keyword,
                        Online = online, 
                        Recache = recache
                    }));
                }
                
                SmartThreadPool.WaitAll(workers.ToArray());
                this.Invoke(new MethodInvoker(delegate() {
                    loadingCircle1.Visible = false;
                    loadingCircle1.Active = false;
                    lblStatus.Text = "Searching completed";

                    DisplaySearchCompleteAnimation();
                }));

                pool.Shutdown();
                

            }).Start();
        }

        private void DisplaySearchCompleteAnimation()
        {
            AnimatedDecoration listAnimation = new AnimatedDecoration(this.lvLastestUpdates);
            Animation animation = listAnimation.Animation;

            //Sprite image = new ImageSprite(Resource1.largestar);
            //image.FixedLocation = Locators.SpriteAligned(Corner.MiddleCenter);
            //image.Add(0, 2000, Effects.Rotate(0, 360 * 2f));
            //image.Add(1000, 1000, Effects.Fade(1.0f, 0.0f));
            //animation.Add(0, image);

            Sprite image = new ImageSprite(Resources.star);
            image.Add(0, 500, Effects.Move(Corner.BottomCenter, Corner.MiddleCenter));
            image.Add(0, 500, Effects.Rotate(0, 180));
            image.Add(500, 1500, Effects.Rotate(180, 360 * 2.5f));
            image.Add(500, 1000, Effects.Scale(1.0f, 3.0f));
            image.Add(500, 1000, Effects.Goto(Corner.MiddleCenter));
            image.Add(1000, 900, Effects.Fade(1.0f, 0.0f));
            animation.Add(0, image);

            Sprite text = new TextSprite(string.Format("Search completed : {0} items found!", itemCounts), new Font("Tahoma", 32), Color.Blue, Color.AliceBlue, Color.Red, 3.0f);
            text.Opacity = 0.0f;
            text.FixedLocation = Locators.SpriteAligned(Corner.MiddleCenter);
            text.Add(900, 900, Effects.Fade(0.0f, 1.0f));
            text.Add(1000, 800, Effects.Rotate(180, 1440));
            text.Add(2000, 500, Effects.Scale(1.0f, 0.5f));
            text.Add(3500, 1000, Effects.Scale(0.5f, 3.0f));
            text.Add(3500, 1000, Effects.Fade(1.0f, 0.0f));
            animation.Add(0, text);

            animation.Start();
        }

        private void btnOnlineSearch_Click(object sender, EventArgs e)
        {
            DoSearch(txtKeyword.Text, true, false);
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var selected = lvLastestUpdates.SelectedObjects[0] as SearchItem;
            DownloaderForm form = new DownloaderForm(selected.StoryUrl);

            form.MdiParent = this.MdiParent;

            form.WindowState = FormWindowState.Minimized;
            form.Show();
            form.WindowState = FormWindowState.Maximized;
        }

        private void addThisStoryToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SmartThreadPool pool = new SmartThreadPool();
            foreach (SearchItem item in lvLastestUpdates.SelectedObjects)
            {
                
                //pool.QueueWorkItem(this.AddToQueue, item);
            }

            pool.Start();
        }

        private void AddToQueue(object obj)
        {
            string url = ((SearchItem)obj).StoryUrl;

            Downloader dl = Downloader.Resolve(url);
            var story = dl.RequestInfo(url);

            string saveFolder = SettingForm.GetSetting().StogareFolder +"\\"+ story.Name.ConvertToValidFileName();


            foreach (var chap in story.Chapters)
            {

                chap.FolderName = chap.Name.ConvertToValidFileName();
                chap.Folder = Path.Combine(saveFolder, chap.FolderName);
                chap.PdfFileName = chap.FolderName + ".pdf";
                chap.PdfPath = Path.Combine(saveFolder, "PDF\\" + chap.PdfFileName);
                chap.Status = DownloadStatus.Waiting;
            }
            QueueDownloadItem item = new QueueDownloadItem()
            {
                ProviderName = dl.Name,
                Downloader = dl.GetType().FullName,
                StoryUrl = url,
                StoryName = story.Name,
                SelectedChapters = story.Chapters,
                Status = DownloadStatus.Waiting,
                SaveFolder = SettingForm.GetSetting().StogareFolder,
            };

            QueueDownloadForm.AddDownloadItem(item);

            this.Invoke(new MethodInvoker(delegate() {
                lblStatus.Text = string.Format("Added {0}[{1} Chapters]", story.Name, story.Chapters.Count);
            }));

        }

        private void txtKeyword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bntCacheSearch.PerformClick();
            }
        }

        private bool hasChanged = false;
        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            //contextMenuShowing = false;
            //if (hasChanged)
            //{
            //    hasChanged = false;

            //    lvLastestUpdates.SetObjects(DataSource);
            //}
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            //hasChanged = false;
            //contextMenuShowing = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchItem item = new SearchItem()
            {
                Provider="aa",
                StoryName= "aaa",
                StoryUrl = "url"
            };
            lvLastestUpdates.AddObject(item);
            lvLastestUpdates.EnsureModelVisible(item);
        }


        internal void SetKeyword(string p)
        {
            throw new NotImplementedException();
        }
    }
}
