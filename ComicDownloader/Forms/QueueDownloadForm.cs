using System;
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

namespace ComicDownloader.Forms
{
    public partial class QueueDownloadForm : MdiChildForm
    {
        public class DataSourceItem
        {
            
            public string ProviderName { get; set; }
            public string StoryName { get; set; }
            public string ChapterUrl { get; set; }
            public string Status { get; set; }
            public string Size { get; set; }


            public string ChapterName { get; set; }

            public int Progress { get; set; }
        }
        private object updateUIObj = "DUMMY";
        public const string QUEUE_FILE_NAME = "history.000";
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



        internal static void AddDownloadItem(QueueDownloadItem item)
        {
            if (DownloadItems == null)
            {
                DownloadItems = GetHistoryItems();
            }
            DownloadItems.Add(item);
            //doing merge here :)
            SaveHistoryItem(DownloadItems);
        }

        private void QueueDownloadForm_Load(object sender, EventArgs e)
        {
            Settings = SettingForm.GetSetting();
            DownloadItems = GetHistoryItems();
            RefreshData();
        }

        private void RefreshData()
        {
//            DownloadItems = GetHistoryItems();
            lsvItems.SetObjects(ConvertToDataSource(DownloadItems));
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
                        
                        Size = item1.Size.ToKB()
                    };

                    if (item1.Status != DownloadStatus.Downloading)
                    {
                        dsItem.Status = item1.Status.ToString();
                    }
                    else
                    {
                        dsItem.Status = ((float)item1.DownloadedCount / item1.PageCount).ToString("p");
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

            while (hasNextTask)
            {
                

                var chapInfo = GetNextChapter();
                if (chapInfo != null)
                {
                    try
                    {
                        chapInfo.Status = DownloadStatus.Downloading;
                        this.Invoke(new MethodInvoker(delegate() {
                            RefreshData();
                        }));

                        

                        Downloader downloader = GetDownloader(chapInfo);
                        chapInfo.Pages = downloader.GetPages(chapInfo.Url);
                        chapInfo.PageCount = chapInfo.Pages.Count;
                        
                        // display Info on UI
                        //DisplayChap(chapInfo, chapterCount);
                        DownloadChapter(chapInfo, downloader);


                        GeneratePDF(chapInfo);
                        //update chapter info

                        chapInfo.Status = DownloadStatus.Completed;
                    }
                    catch
                    {
                        chapInfo.Status = DownloadStatus.Error;
                    }
                    finally
                    {
                        SaveHistoryItem(DownloadItems);
                        RefreshData();
                    }
                }
                else
                {
                    hasNextTask = false;
                }
            }

        }

        private Downloader GetDownloader(ChapterInfo chapInfo)
        {
            var downloaders = Downloader.GetAllDownloaders();

            foreach (var item in downloaders)
            {
                if(chapInfo.Url.Contains(item.HostUrl)) return item;
            }
            throw new Exception("Downloader now found for this chapter");
        }
        public ComicDownloaderSettings Settings { get; set; }

        private void GeneratePDF(ChapterInfo chapInfo)
        {
            if (!Settings.CreatePDF)
            {
                return;
            }

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(chapInfo.PdfPath));
            }
            finally
            {

            }



            Document pdfDoc = new Document(PageSize.A4);
            float docw = pdfDoc.PageSize.Width;
            float doch = pdfDoc.PageSize.Width;

            PdfDate st = new PdfDate(DateTime.Today);
            try
            {
                var stream = File.Create(chapInfo.PdfPath);
                var writer = PdfWriter.GetInstance(pdfDoc, stream);

                pdfDoc.Open();
                if (Settings.IncludePDFIntroPage && Settings.PdfIntroPagePosition == PagePosition.FirstPage)
                    EmbedeIntroPage(pdfDoc, writer);

                DirectoryInfo di = new DirectoryInfo(chapInfo.Folder);
                var files = di.GetFiles();
                if (files != null)
                {
                    foreach (var fi in files)
                    {
                       iTextSharp.text.Image img =  iTextSharp.text.Image.GetInstance(fi.FullName);
                        float h = img.Height;
                        float w = img.Width;

                        float hp = doch / h;
                        float wp = docw / w;

                        img.ScaleToFit(docw * 1.35f, doch * 1.35f);
                        // img.ScaleToFit(750, 550);
                        pdfDoc.NewPage();
                        pdfDoc.Add(img);

                    }
                    if (Settings.IncludePDFIntroPage && Settings.PdfIntroPagePosition == PagePosition.LastPage)
                        EmbedeIntroPage(pdfDoc, writer);
                }
            }
            catch (Exception ex)
            {
                //Log error;
            }
            finally
            {

                try
                {
                    pdfDoc.Close();
                    //this.Invoke((MethodInvoker)delegate
                    //{
                    //    var listItem = listHistory.Items[listHistory.Items.Count - 1];

                    //    var subItem = listItem.SubItems[6] as EXControlListViewSubItem;
                    //    var pp = subItem.MyControl as Button;
                    //    pp.Enabled = true;
                    //    pp.Tag = chapInfo.PdfPath;

                    //});

                }
                catch
                {
                }
                finally
                {

                }
                //doc.Close();
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
                Directory.CreateDirectory(chapInfo.Folder);
            }
            finally
            {

            }
        }
        private void DownloadChapter(ChapterInfo chapInfo, Downloader downloader)
        {
            if (chapInfo.Pages == null) return;

            CreateChapterFolder(chapInfo);

            int count = 0;
            long size = 0;
            ManualResetEvent resetEvent = new ManualResetEvent(false);
            int toProcess = chapInfo.Pages.Count;
            int index = 1;
            //if (!Settings.UseMultiThreadToDownloadChapter)
            //{
            //   // resetEvent.Set();
            //}
            foreach (string pageUrl in chapInfo.Pages)
            {
                var subThread = new Thread(delegate()
                {
                    string tempUrl = pageUrl;
                    if (tempUrl.Contains("?"))
                    {
                        tempUrl = tempUrl.Substring(0, tempUrl.IndexOf("?"));
                    }

                    string filename = Path.Combine(chapInfo.Folder, (index++).ToString("D2") + ". " + Path.GetFileName(tempUrl));


                    try
                    {
                        downloader.DownloadPage(pageUrl, filename, chapInfo.Url);


                        var file = File.Open(filename, FileMode.Open);

                        lock (updateUIObj)
                        {
                            size += file.Length;
                            //total += file.Length;
                            file.Close();
                            count++;
                            chapInfo.Size = size;
                            RefreshData();
                            chapInfo.DownloadedCount = count;
                            //this.Invoke((MethodInvoker)delegate
                            //{

                            //    this.progess.Value = count;
                            //    lblPageCount.Text = string.Format("{0:D2}/{1:D2}", count, chapInfo.PageCount);

                            //    var listItem = listHistory.Items[listHistory.Items.Count - 1];
                            //    listItem.SubItems[3].Text = size.ToKB();
                            //    lblTotalDownloadCount.Text = total.ToKB();
                            //    var subItem = listItem.SubItems[4] as EXControlListViewSubItem;
                            //    var pp = subItem.MyControl as ProgressBar;
                            //    pp.Value = count;


                            //});
                        }


                    }
                    catch
                    {
                    }
                    finally
                    {

                        if (Interlocked.Decrement(ref toProcess) == 0)
                            resetEvent.Set();
                        RefreshData();
                    }
                });

                //if (!Settings.UseMultiThreadToDownloadChapter)
                //{
                //   // resetEvent.WaitOne();

                //}
                //threads.Add(subThread);
                subThread.Start();
            }

            //if(Settings.UseMultiThreadToDownloadChapter)
            resetEvent.WaitOne();

        }
        private void DisplayChap(ChapterInfo chapInfo, int chapCount)
        {
            //this.Invoke((MethodInvoker)delegate
            //{
            //    this.progess.Minimum = 1;
            //    this.progess.Value = 1;
            //    this.progess.Maximum = chapInfo.PageCount;
            //    var listItem = new EXListViewItem(chapCount.ToString());
            //    listItem.SubItems.Add(chapInfo.Name);
            //    listItem.SubItems.Add(chapInfo.PageCount.ToString());
            //    listItem.SubItems.Add("0");
            //    EXControlListViewSubItem cs = new EXControlListViewSubItem();
            //    ProgressBar b = new ProgressBar();
            //    //b.Tag = item;
            //    b.Minimum = 0;
            //    b.Maximum = chapInfo.PageCount;
            //    b.Step = 1;

            //    listItem.SubItems.Add(cs);
            //    this.listHistory.AddControlToSubItem(b, cs);

            //    //Add button to view folder

            //    EXControlListViewSubItem openFolderCol = new EXControlListViewSubItem();
            //    Button bntOpenFolder = new Button()
            //    {
            //        Image = global::ComicDownloader.Properties.Resources._1364392872_slideshow,
            //        //Location = new System.Drawing.Point(248, 123);
            //        //Name = "button2";
            //        Size = new System.Drawing.Size(24, 24),

            //        TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay,
            //        UseVisualStyleBackColor = true,
            //        Tag = openFolderCol,
            //        //Text = chapInfo.PdfPath,
            //        Enabled = true,

            //    };

            //    bntOpenFolder.Click += new EventHandler(delegate
            //    {
            //        MainWindow window = new MainWindow(new string[] { chapInfo.Folder + "/dum.trick", "0" });
            //        window.WindowState = FormWindowState.Maximized;
            //        window.ShowDialog();
            //        //window.SubStartSlideShow();
            //    });
            //    // llbl.LinkClicked += new LinkLabelLinkClickedEventHandler(llbl_LinkClicked);
            //    listItem.SubItems.Add(openFolderCol);
            //    listHistory.AddControlToSubItem(bntOpenFolder, openFolderCol);


            //    //listItem.SubItems.Add(chapInfo.Folder);

            //    EXControlListViewSubItem pdfLinkCol = new EXControlListViewSubItem();
            //    Button bntOpenPDF = new Button()
            //    {


            //        Image = global::ComicDownloader.Properties.Resources._1364326694_stock_save_pdf_24,
            //        //Location = new System.Drawing.Point(248, 123);
            //        //Name = "button2";
            //        Size = new System.Drawing.Size(24, 24),

            //        TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay,
            //        UseVisualStyleBackColor = true,
            //        Tag = pdfLinkCol,
            //        //Text = chapInfo.PdfPath,
            //        Enabled = false,

            //    };

            //    bntOpenPDF.Click += new EventHandler(bntOpenPDF_Click);

            //    listItem.SubItems.Add(pdfLinkCol);
            //    listHistory.AddControlToSubItem(bntOpenPDF, pdfLinkCol);

            //    listItem.SubItems.Add(chapInfo.PdfPath);
            //    this.listHistory.Items.Add(listItem);
            //    lblPageCount.Text = string.Format("{0:D2}/{1:D2}", "0", chapInfo.PageCount);

            //});
        }

        private ChapterInfo GetNextChapter()
        {
            foreach (var item in DownloadItems)
            {
                var chapter = item.SelectedChapters.FirstOrDefault(p => p.Status == DownloadStatus.Waiting);

                if (chapter != null)
                {
                    return chapter;
                }
            }
            return null;
        }

        private void QueueDownloadForm_MdiChildActivate(object sender, EventArgs e)
        {
            
        }

        private void QueueDownloadForm_Enter(object sender, EventArgs e)
        {
            //Enable or disable button 
            RefreshData();
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
    }
}
