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

namespace ComicDownloader.Forms
{
    public partial class LastestChapterUpdateForm : MdiChildForm
    {
        public class UpdatedChapterItem
        {
            public string Provider { get; set; }
            public string StoryName { get; set; }
            public string ChapterName { get; set; }
            public string ChapterUrl { get; set; }
            public string StoryUrl { get; set; }
        }
        private List<UpdatedChapterItem> DataSource = new List<UpdatedChapterItem>();

        public LastestChapterUpdateForm()
        {
            InitializeComponent();
            LoadingCircle ci = new LoadingCircle();
            
            this.Controls.Add(ci);
            ci.BringToFront();
            ci.Active = true;
        }
        struct ThreadParam
        {
            public Downloader Downloader { get; set; }
            public ManualResetEvent ResetEvent { get; set; }
            
        }
             
        private void LastestChapterUpdateForm_Load(object sender, EventArgs e)
        {
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

                    ThreadPool.QueueUserWorkItem(this.GetUpdateChapters, new ThreadParam()
                    {
                        Downloader = downloaders[i],
                        ResetEvent = doneEvents[i]
                    });
                }
                foreach (var doneEvent in doneEvents) doneEvent.WaitOne();
            }).Start();

            
        }
        private void GetUpdateChapters(object obj)
        {
            ThreadParam param = (ThreadParam)obj;

            List<StoryInfo> list = new List<StoryInfo>();
            var tempLst = new List<UpdatedChapterItem>();
            try
            {
                list = param.Downloader.GetLastestUpdates();
                if (list.Count > 0)
                {
                    foreach (var item in list)
                    {
                        foreach (var chap in item.Chapters)
                        {

                            tempLst.Add(new UpdatedChapterItem()
                            {
                                Provider = param.Downloader.Name,
                                StoryName = item.Name,
                                ChapterName = chap.Name,
                                ChapterUrl = chap.Url
                            });
                        }
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
                        //lvLastestUpdates.SetObjects(DataSource);
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            lvLastestUpdates.AddObjects(DataSource);
                        }));
                    }
                }

                param.ResetEvent.Set();
                this.Invoke(new MethodInvoker(delegate()
                {
                    progressBar.Increment(1);

                    this.Text = "Lastest updates - Loading[" + ((float)progressBar.Value / progressBar.Maximum).ToString("p") +"]";
                }));
            }


        }

        private void addChapterToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void LastestChapterUpdateForm_Resize(object sender, EventArgs e)
        {
            progressBar.Size = new Size(this.statusStrip1.Width - 15, statusStrip1.Height);

            
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
    }
}
