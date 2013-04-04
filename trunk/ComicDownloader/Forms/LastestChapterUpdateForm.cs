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
        }

        
        private void LastestChapterUpdateForm_Load(object sender, EventArgs e)
        {
            lvLastestUpdates.SetObjects(DataSource);

            var downloaders = ComicDownloader.Engines.Downloader.GetAllDownloaders();

            ManualResetEvent[] doneEvents = new ManualResetEvent[downloaders.Count];
            
            for (int i = 0; i < downloaders.Count; i++)
            {
                //doneEvents[i] = new ManualResetEvent(false);
                
                ThreadPool.QueueUserWorkItem(this.GetUpdateChapters, downloaders[i]);
            }
            
        }
        private void GetUpdateChapters(object obj)
        {
            Downloader dl = obj as Downloader;

            List<StoryInfo> list = new List<StoryInfo>();

            try
            {
                list = dl.GetLastestUpdates();

                lock (DataSource)
                {
                    foreach (var item in list)
                    
                    {
                        foreach (var chap in item.Chapters)
                        {

                            DataSource.Add(new UpdatedChapterItem()
                            {
                                Provider = dl.Name,
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
                lvLastestUpdates.SetObjects(DataSource);
            }


        }

        private void addChapterToQueueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
