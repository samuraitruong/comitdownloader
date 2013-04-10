using System;
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

namespace ComicDownloader.Forms
{
    public partial class SearchForm : MdiChildForm
    {
        public class SeaerchItem
        {
            public string Provider { get; set; }
            public string StoryName { get; set; }
            //public string ChapterName { get; set; }
            //public string ChapterUrl { get; set; }
            public string StoryUrl { get; set; }
        }
        private List<SeaerchItem> DataSource = new List<SeaerchItem>();

        public SearchForm()
        {
            InitializeComponent();
            LoadingCircle ci = new LoadingCircle();
            
            this.Controls.Add(ci);
            ci.BringToFront();
            ci.Active = true;
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

        private void GetSearchItems(object obj)
        {
            SearchThreadParam param = (SearchThreadParam)obj;

            List<StoryInfo> list = new List<StoryInfo>();
            var tempLst = new List<SeaerchItem>();

            try
            {
                list = param.Downloader.Search(param.Keyword, param.Online, param.Recache);

                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        tempLst.Add(new SeaerchItem()
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
                        DataSource.AddRange(tempLst);
                        lvLastestUpdates.SetObjects(DataSource);
                    }
                }

                param.ResetEvent.Set();
                this.Invoke(new MethodInvoker(delegate()
                {
                    progressBar.Increment(1);

                    //this.Text = "Lastest updates - Loading[" + ((float)progressBar.Value / progressBar.Maximum).ToString("p") +"]";
                }));
            }


        }

        private void addChapterToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LastestChapterUpdateForm_Resize(object sender, EventArgs e)
        {
            progressBar.Size = new Size(this.statusStrip1.Width - 15, progressBar.Height);

            
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

        private void DoSearch(string keyword, bool online, bool recache)
        {
            DataSource.Clear();

            lvLastestUpdates.SetObjects(DataSource);
            
            var downloaders = ComicDownloader.Engines.Downloader.GetAllDownloaders();
            progressBar.Maximum = downloaders.Count;
            progressBar.Step = 1;
            progressBar.Value = 0;

            ManualResetEvent[] doneEvents = new ManualResetEvent[downloaders.Count];
            new Thread(delegate()
            {

                for (int i = 0; i < downloaders.Count; i++)
                {
                    doneEvents[i] = new ManualResetEvent(false);

                    ThreadPool.QueueUserWorkItem(this.GetSearchItems, new SearchThreadParam()
                    {
                        Downloader = downloaders[i],
                        ResetEvent = doneEvents[i],
                        Keyword = keyword,
                        Online = online, 
                        Recache = recache
                    });
                }
                foreach (var doneEvent in doneEvents) doneEvent.WaitOne();
            }).Start();
        }

        private void btnOnlineSearch_Click(object sender, EventArgs e)
        {
            DoSearch(txtKeyword.Text, true, false);
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
    }
}
