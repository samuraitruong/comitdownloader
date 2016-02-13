using System; using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ComicDownloader.Properties;
using Cx.Windows.Forms;
using System.Threading;
using ComicDownloader.Engines;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Diagnostics;
using IView.UI.Forms;
using ComicDownloader.Helpers;
using System.Text.RegularExpressions;
using Amib.Threading;

namespace ComicDownloader.Forms
{
    public partial class QueueDownloadForm : MdiChildForm
    {
        public delegate void ExternalCall(object obj);
        public event ExternalCall OnQueueCompleted;
        public event ExternalCall OnQueueStart;
        public event ExternalCall OnFormActivate;

        public class DataSourceItem
        {
            
            public string ProviderName { get; set; }
            public string StoryName { get; set; }
            public string ChapterUrl { get; set; }
            public string Status { get; set; }
            public string Size { get; set; }


            public string ChapterName { get; set; }

            public int Progress { get; set; }

            public Guid Identify { get; set; }

            public int Pages { get; set; }
        }
        private object updateUIObj = "DUMMY";
        public  static string QUEUE_FILE_NAME = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\ComicDownloader\\" + "history.000";
        public QueueDownloadForm()
        {
            InitializeComponent();
        }
        private static List<QueueDownloadItem> DownloadItems { get; set; }

        public static void SaveHistoryItem(List<QueueDownloadItem> items)
        {
            var temp = Path.GetTempPath() + Path.GetRandomFileName();
            var xml = SerializationHelper.SerializeToXml<List<QueueDownloadItem>>(items);
            using (var file = new StreamWriter(File.Open(temp, FileMode.OpenOrCreate)))
            {
                file.Write(xml);
            }
            Directory.CreateDirectory(Path.GetDirectoryName(QUEUE_FILE_NAME));

            SecureHelper.EncryptFile(temp, QUEUE_FILE_NAME, Resources.SecureKey);
        }

        public static List<QueueDownloadItem> GetHistoryItems()
        {
            if (File.Exists(QUEUE_FILE_NAME))
            {
                var temp = Path.GetTempPath() + Path.GetRandomFileName();

                SecureHelper.DecryptFile(QUEUE_FILE_NAME, temp, Resources.SecureKey);

                using (var file = File.OpenText(temp))
                {
                    return SerializationHelper.DeserializeFromXml<List<QueueDownloadItem>>(file.ReadToEnd());
                }
            }
            return new List<QueueDownloadItem>();
        }


        private static object locker = "DUM";
        internal static void AddDownloadItem(QueueDownloadItem item)
        {
            lock (locker)
            {
                if (DownloadItems == null)
                {
                    DownloadItems = GetHistoryItems();
                }

                item.Sequence = DownloadItems.Count + 1;
                item.Priority = 3;
                DownloadItems.Add(item);
                //doing merge here :)
                SaveHistoryItem(DownloadItems);
            }
        }

        private void QueueDownloadForm_Load(object sender, EventArgs e)
        {
            Settings = SettingForm.GetSetting();
            DownloadItems = GetHistoryItems();
            RefreshData();
        }
        List<DataSourceItem> DataSource;
        private void RefreshData(ChapterInfo chap)
        {
            var dsItem = DataSource.FirstOrDefault(p => p.Identify == chap.UniqueIdentify);
            if (dsItem != null)
            {
                    //Progress = (new Random()).Next(1,100),
                    dsItem.ChapterUrl = chap.Url;
                    dsItem.Pages = chap.PageCount;
                    dsItem.Size = chap.Size.ToKB();
                    dsItem.Status = ((float)chap.DownloadedCount / chap.PageCount).ToString("p");
                    if (chap.Status != DownloadStatus.Downloading)
                    {
                        dsItem.Status = chap.Status.ToString();
                    }
                    else
                    {
                        dsItem.Status = ((float)chap.DownloadedCount / chap.PageCount).ToString("p");
                        if (dsItem.Status == "NaN") dsItem.Status = "Initializing...";
                    }
                    lsvItems.RefreshObject(dsItem);
            }
            
        }
        private void RefreshData()
        {
            //            DownloadItems = GetHistoryItems();
            // if (isContextMenuShowing) return;


            DataSource = ConvertToDataSource(DownloadItems);
            lsvItems.SetObjects(DataSource);

        }

        private List<DataSourceItem> ConvertToDataSource(List<QueueDownloadItem> DownloadItems)
        {
            List<DataSourceItem> results = new List<DataSourceItem>();
            foreach (var item in DownloadItems)
            {
                foreach (var item1 in item.SelectedChapters)
                {
                    var dsItem = new DataSourceItem()
                    {
                        StoryName = item.StoryName,
                        ProviderName = item.ProviderName,
                        //Progress = (new Random()).Next(1,100),
                        ChapterUrl = item1.Url,
                        ChapterName = item1.Name,
                        Pages = item1.PageCount,
                        Size = item1.Size.ToKB(),
                        Identify = item1.UniqueIdentify
                    };

                    if (item1.Status != DownloadStatus.Downloading)
                    {
                        dsItem.Status = item1.Status.ToString();
                    }
                    else
                    {
                        dsItem.Status = ((float)item1.DownloadedCount / item1.PageCount).ToString("p");
                        if(dsItem.Status =="NaN") dsItem.Status = "Initializing...";
                    }

                    results.Add(dsItem);
                }
                
            }
            return results;
        }

        private void treeListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        internal void StartQueue()
        {
            if (queueDownloadThread != null && queueDownloadThread.IsAlive) return;
            queueDownloadThread = new Thread(new ThreadStart(this.DownloadQueueItems));
            queueDownloadThread.Start();
        }

        Thread queueDownloadThread = null;
       
        
        public void DownloadQueueItems()
        {
            bool hasNextTask = true;
            if(OnQueueStart!= null)
            OnQueueStart(DownloadItems);
            while (hasNextTask)
            {
                

                var chapInfo = GetNextChapter();
                if (chapInfo != null)
                {
                    DownloadChapterCallback(chapInfo);
                }
                else
                {
                    hasNextTask = false;
                }
            }
            if(OnQueueCompleted!= null)
            OnQueueCompleted(DownloadItems);

        }

        private object DownloadChapterCallback(object objState)
        {
            var chapInfo = (ChapterInfo)objState;
            try
            {
                chapInfo.Status = DownloadStatus.Downloading;
                this.Invoke(new MethodInvoker(delegate()
                {
                    RefreshData(chapInfo);
                }));



                Downloader downloader = GetDownloader(chapInfo);
                if (downloader != null)
                {
                    chapInfo.Pages = downloader.GetPages(chapInfo.Url);
                    chapInfo.PageCount = chapInfo.Pages.Count;


                    DownloadChapter(chapInfo, downloader);


                    GeneratePDF(chapInfo);
                    chapInfo.Status = DownloadStatus.Completed;

                }
                else
                {
                    chapInfo.Status = DownloadStatus.Error;
                }
                //update chapter info

            }
            catch
            {
                chapInfo.Status = DownloadStatus.Error;
            }
            finally
            {
                lock (DownloadItems)
                {
                    SaveHistoryItem(DownloadItems);
                    RefreshData(chapInfo);
                }
            }
            return objState;
        }

        private Downloader GetDownloader(ChapterInfo chapInfo)
        {
            var downloaders = Downloader.GetAllDownloaders();
            string pattern = @"https?://(?<DOMAIN>.*.com|me|net|info)";
            foreach (var item in downloaders)
            {
                var m = Regex.Match(item.HostUrl, pattern);
                string domain = m.Groups["DOMAIN"].Value;

                var arr = domain.Split(".".ToCharArray());
                var root = arr[arr.Length - 2] + "." + arr[arr.Length - 1];

                if(m!=null) {

                    if (chapInfo.Url.Contains(root)) return item;
                }
            }
            throw new Exception("No Downloader found for this chapter with url "+ chapInfo.Url);
        }
        public ComicDownloaderSettings Settings { get; set; }

        private void GeneratePDF(ChapterInfo chapInfo)
        {
            if (!Settings.CreatePDF)
            {
                return;
            }
            try{
                PDFHelper.CreatePDF(chapInfo.Folder, chapInfo.PdfPath, chapInfo.Name, Settings);
            }
            catch (Exception ex)
            {
                MyLogger.Log(ex);
            }
            finally
            {
            }

        }

        private static void EmbedeIntroPage(Document pdfDoc, PdfWriter writer)
        {
            pdfDoc.NewPage();
            PdfReader reader = new PdfReader(Resources.Intro);
            PdfContentByte cb = writer.DirectContent;
            PdfImportedPage page = writer.GetImportedPage(reader, 1); ;

            //cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(1).Height);
            cb.AddTemplate(page, 0, 0);
        }
        private void CreateChapterFolder(ChapterInfo chapInfo)
        {
            try
            {
                if (Directory.Exists(chapInfo.Folder))
                {
                    Directory.Delete(chapInfo.Folder, true);
                }
                Directory.CreateDirectory(chapInfo.Folder);
            }
            finally
            {

            }
        }
        private void DownloadChapter(ChapterInfo chapInfo, Downloader downloader)
        {
            if (chapInfo.Pages == null) return;

            SmartThreadPool smartThreadPool = new SmartThreadPool()
            {
                MaxThreads = Settings.UseMultiThreadToDownloadChapter?Settings.Threads:1
            };

            List<IWorkItemResult> workerItems = new List<IWorkItemResult>();

           CreateChapterFolder(chapInfo);

           this.Invoke(new MethodInvoker(delegate()
           {
               lblStatus.Text = "Downloading : " + chapInfo.Name + "[" + chapInfo.Url + "]";
           }));
            int count = 0;
            long size = 0;
            
            int toProcess = chapInfo.Pages.Count;
            int index = 1;
           
            foreach (string pageUrl in chapInfo.Pages)
            {
                IWorkItemResult wir1 = smartThreadPool.QueueWorkItem(new
                        WorkItemCallback(delegate(object state)
                        {

                            try
                            {
                                string filename = downloader.DownloadPage(state.ToString(), Settings.RenamePattern.Replace("{{PAGENUM}}", (index++).ToString("D2")), chapInfo.Folder, chapInfo.Url);

                                var file = File.Open(filename, FileMode.Open);

                                lock (updateUIObj)
                                {
                                    size += file.Length;
                                    //total += file.Length;
                                    file.Close();
                                    count++;
                                    chapInfo.Size = size;
                                    chapInfo.DownloadedCount = count;
                                    RefreshData(chapInfo);
                                }
                            }
                            catch{
                            }
                            finally
                            {
                                RefreshData(chapInfo);
                            }
                            return 0;
                        }), pageUrl);
                workerItems.Add(wir1);

            }

            bool success = SmartThreadPool.WaitAll(workerItems.ToArray());

            smartThreadPool.Shutdown();
        }
        
        private ChapterInfo GetNextChapter()
        {
            var waitingList = new List<ChapterInfo>();
            
            foreach (var item in DownloadItems)
            {
                var chapters = item.SelectedChapters.Where(p=>p.Status == DownloadStatus.Waiting);

                waitingList.AddRange(chapters);
            }
            var groups = waitingList.GroupBy(p => p.Priority).Select(p => p);
            foreach (var group in groups.OrderByDescending(p=>p.Key))
            {
                return group.OrderByDescending(p => p.Sequence).FirstOrDefault();
                break;
            }
            return null;
        }

        private void QueueDownloadForm_MdiChildActivate(object sender, EventArgs e)
        {
            
        }

        private void QueueDownloadForm_Enter(object sender, EventArgs e)
        {
            RefreshData();
            if (OnFormActivate != null)
            {
                OnFormActivate(DownloadItems);
            }
            
        }

        private void QueueDownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           // e.Cancel = true;
        }

        internal void ClearQueue()
        {
            //Abort thread on deleted item
            //delete only select item

            DownloadItems.Clear();
            SaveHistoryItem(DownloadItems);

            RefreshData();
        }
        public List<ChapterInfo> GetAllChapter(DownloadStatus status)
        {
            List<ChapterInfo> chaps = new List<ChapterInfo>();
            foreach (var item in DownloadItems)
            {
                var ranges = item.SelectedChapters.Where(p => p.Status == status).ToList();
                chaps.AddRange(ranges);
            }
            return chaps;
        }
        internal void ResumeDownloadItems(DownloadStatus downloadStatus)
        {
             List<ChapterInfo> errorItems = GetAllChapter(downloadStatus);
             foreach (var item in errorItems)
	        {
                item.Status = DownloadStatus.Waiting;
	        }
             SaveHistoryItem(DownloadItems);
             RefreshData();

             StartQueue();
        }

        private void mnuRemovAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to remove all chapters?", "Remove al", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DownloadItems.Clear();
                //Stop Thread
                RefreshData();
                SaveHistoryItem(DownloadItems);
            }
        }
        
        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            var selectedItems = this.lsvItems.SelectedItems[0];
            var col = selectedItems.ListView.Columns.Cast<ColumnHeader>().FirstOrDefault(p => p.Text == "Status");
            var value = selectedItems.SubItems[col.Index].Text;
            if (value == DownloadStatus.Completed.ToString())
            {
                viewPDFToolStripMenuItem.Enabled = true;
            }
            else
            {
                viewPDFToolStripMenuItem.Enabled = false;
            }
            

        }

        private void contextMenuStrip1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            
        }

        private ChapterInfo GetChapterByIdentity(Guid Identity)
        {
            ChapterInfo chap = null;

            foreach (var item in DownloadItems)
            {
                chap = item.SelectedChapters.FirstOrDefault(p => p.UniqueIdentify == Identity);
                if (chap != null) break;
            }
            return chap;
        }
        private void viewPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectedItems = this.lsvItems.SelectedItems[0];
            var col = selectedItems.ListView.Columns.Cast<ColumnHeader>().FirstOrDefault(p => p.Text == "Identify");
            var value = selectedItems.SubItems[col.Index].Text;
            var chap = GetChapterByIdentity(new Guid(value));
            if(File.Exists(chap.PdfPath)){
            Process.Start(string.Format("\"{0}\"", chap.PdfPath));
            }
            else{
                MessageBox.Show(string.Format("File {0} was moved or deleted!", chap.PdfPath));
            }


        }

        

        internal void AbortQueue()
        {
            if (queueDownloadThread != null && queueDownloadThread.IsAlive)
            {
                queueDownloadThread.Abort();
                SaveHistoryItem(DownloadItems);
                if (OnQueueCompleted != null)
                {
                    OnQueueCompleted(DownloadItems);
                }
            }
        }

        private void readChapterToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var chap = GetSelectedChapterInfo();
            SlideShow slideshow = new SlideShow(chap.Folder);
            slideshow.Show(this);
        }

        private ChapterInfo GetSelectedChapterInfo()
        {
            var selectedItems = this.lsvItems.SelectedItems[0];
            var col = selectedItems.ListView.Columns.Cast<ColumnHeader>().FirstOrDefault(p => p.Text == "Identify");
            var value = selectedItems.SubItems[col.Index].Text;
            var chap = GetChapterByIdentity(new Guid(value));
            return chap;
        }

        private void exploreChapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var chapInfo = GetSelectedChapterInfo();
            MainWindow window = new MainWindow(new string[] { chapInfo.Folder + "/dum.trick", "0" });
            window.WindowState = FormWindowState.Maximized;
            window.ShowDialog();

        }

        private void allCompletedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DownloadStatus status = DownloadStatus.Completed;

            foreach (var item in DownloadItems)
            {
                var chapterRemoves = item.SelectedChapters.RemoveAll(p => p.Status == status);
            }
            DownloadItems.RemoveAll(p => p.SelectedChapters.Count == 0);
            SaveHistoryItem(DownloadItems);

            RefreshData();
        }

        private void mnuPriorityChange(object sender, EventArgs e)
        {
            int priority = Convert.ToInt32( ((ToolStripMenuItem)sender).Tag);

            var selectedItems = this.lsvItems.SelectedItems;
            lock (DownloadItems)
            {
                foreach (ListViewItem item in selectedItems)
                {
                    var col = item.ListView.Columns.Cast<ColumnHeader>().FirstOrDefault(p => p.Text == "Identify");
                    var value = item.SubItems[col.Index].Text;
                    var chap = GetChapterByIdentity(new Guid(value));

                    chap.Priority = priority;
                    chap.LastModified = DateTime.Now;
                }
            }
            SaveHistoryItem(DownloadItems);
           

        }

        private void mnuForceDownload_Click(object sender, EventArgs e)
        {
            var selectedItems = this.lsvItems.SelectedItems;
            SmartThreadPool pool = new SmartThreadPool()
            {
                MaxThreads = 3,
            };

            lock (DownloadItems)
            {
                foreach (ListViewItem item in selectedItems)
                {
                    var col = item.ListView.Columns.Cast<ColumnHeader>().FirstOrDefault(p => p.Text == "Identify");
                    var value = item.SubItems[col.Index].Text;
                    var chap = GetChapterByIdentity(new Guid(value));

                    chap.Priority = 10;
                    chap.LastModified = DateTime.Now;
                    chap.Status = DownloadStatus.Waiting;
                    pool.QueueWorkItem(new WorkItemCallback(DownloadChapterCallback), chap);
                }
            }
            SaveHistoryItem(DownloadItems); //StartQueue();
        }
    }
}
