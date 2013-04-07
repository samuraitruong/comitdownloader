using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Threading;
using System.Linq.Expressions;
using System.Reflection;
using System.Diagnostics;
using Cx.Windows.Forms;
using ComicDownloader.Engines;
using XPTable.Models;
using ComicDownloader.Properties;
using ComicDownloader.Forms;
using IView.UI.Forms;
using System.Runtime.InteropServices;
using ComicDownoader.Forms;


namespace ComicDownloader
{
   
    public partial class DownloaderForm : MdiChildForm
    {
       
        public ComicDownloaderSettings Settings { get; set; }

        List<Thread> threads = new List<Thread>();
        public Downloader Downloader { get; set; }
        EventWaitHandle waitHandle = new EventWaitHandle(false, EventResetMode.ManualReset);
        private Object updateUIObj = "DUMMY";

        public DownloaderForm()
        {
            InitializeComponent();
            Settings = SettingForm.GetSetting();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = txtDir.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtDir.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void bntDownload_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(txtDir.Text);
            if (txtTitle.Text.AsEnumerable().Any(p => Path.GetInvalidFileNameChars().Contains(p)))
            {
                errInvalidFileName.SetError(txtTitle, "Invalided");
                return;
            }
            StartDownload();

        }


        private List<ChapterInfo> toBeDownloadedChapters = new List<ChapterInfo>();


        long total = 0;
        private void StartDownload()
        {
            //clear UI
            listHistory.Items.Clear();
            CollectChaptersToBeDownloaded();

            bntDownload.Enabled = false;
            bntPauseThread.Enabled = true;
            btnExitThread.Enabled = true;
            downloadThread = new Thread(new ThreadStart(this.DownloadProcess));
            downloadThread.Start();
            threads.Clear();
            threads.Add(downloadThread);
            

        }

        private Thread downloadThread;

        private void DownloadProcess()
        {
            int chapterCount = 0;
            foreach (var chapInfo in toBeDownloadedChapters)
            {
                try
                {
                    chapterCount++;
                    
                    this.Invoke((MethodInvoker)delegate
                    {
                        lblStatus.Text = chapInfo.Name;
                    });

                    chapInfo.Pages = Downloader.GetPages(chapInfo.Url);
                    chapInfo.PageCount = chapInfo.Pages.Count;

                    // display Info on UI
                    DisplayChap(chapInfo, chapterCount);
                    DownloadChapter(chapInfo);

                    GeneratePDF(chapInfo);

                }
                finally
                {

                }


            }

            this.Invoke((MethodInvoker)delegate
            {
                bntDownload.Enabled = true;
                lblStatus.Text = "Completed!";
                //MessageBox.Show("Download completed!");
            });

        }

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
                if(Settings.IncludePDFIntroPage && Settings.PdfIntroPagePosition == PagePosition.FirstPage)
                EmbedeIntroPage(pdfDoc, writer);

                DirectoryInfo di = new DirectoryInfo(chapInfo.Folder);
                var files = di.GetFiles();
                if (files != null)
                {
                    foreach (var fi in files)
                    {
                        Image img = Image.GetInstance(fi.FullName);
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
                MyLogger.Log(ex);
            }
            finally
            {

                try
                {
                    pdfDoc.Close();
                    this.Invoke((MethodInvoker)delegate
                    {
                        var listItem = listHistory.Items[listHistory.Items.Count - 1];
                       
                        var subItem = listItem.SubItems[6] as EXControlListViewSubItem;
                        var pp = subItem.MyControl as Button;
                        pp.Enabled = true;
                        pp.Tag = chapInfo.PdfPath;

                    });

                }
                catch(Exception ex)
                {
                    MyLogger.Log(ex);
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

        private void DownloadChapter(ChapterInfo chapInfo)
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

                    //string filename = Path.Combine(chapInfo.Folder, (index++).ToString("D2") + ". " + Path.GetFileName(tempUrl));


                    try
                    {
                        string filename = Downloader.DownloadPage(pageUrl, Settings.RenamePattern.Replace("{{PAGENUM}}", (index++).ToString("D2")), chapInfo.Folder, chapInfo.Url);
                        
                        
                        var file = File.Open(filename, FileMode.Open);

                        lock (updateUIObj)
                        {
                            size += file.Length;
                            total += file.Length;
                            file.Close();
                            count++;
                            this.Invoke((MethodInvoker)delegate
                            {

                                this.progess.Value = count;
                                lblPageCount.Text = string.Format("{0:D2}/{1:D2}", count, chapInfo.PageCount);

                                var listItem = listHistory.Items[listHistory.Items.Count - 1];
                                listItem.SubItems[3].Text = size.ToKB();
                                lblTotalDownloadCount.Text = total.ToKB();
                                var subItem = listItem.SubItems[4] as EXControlListViewSubItem;
                                var pp = subItem.MyControl as ProgressBar;
                                pp.Value = count;


                            });
                        }

                       
                    }
                    catch(Exception ex)
                    {
                        MyLogger.Log(ex);
                    }
                    finally
                    {

                        if (Interlocked.Decrement(ref toProcess) == 0)
                            resetEvent.Set();
                    }
                });

                //if (!Settings.UseMultiThreadToDownloadChapter)
                //{
                //   // resetEvent.WaitOne();

                //}
                threads.Add(subThread);
                subThread.Start();
            }
           
            //if(Settings.UseMultiThreadToDownloadChapter)
            resetEvent.WaitOne();
            
        }

        private void DisplayChap(ChapterInfo chapInfo, int chapCount)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.progess.Minimum = 1;
                this.progess.Value = 1;
                this.progess.Maximum = chapInfo.PageCount;
                var listItem = new EXListViewItem(chapCount.ToString());
                listItem.SubItems.Add(chapInfo.Name.Replace('"',' ').Replace('.',' '));
                listItem.SubItems.Add(chapInfo.PageCount.ToString());
                listItem.SubItems.Add("0");
                EXControlListViewSubItem cs = new EXControlListViewSubItem();
                ProgressBar b = new ProgressBar();
                //b.Tag = item;
                b.Minimum = 0;
                b.Maximum = chapInfo.PageCount;
                b.Step = 1;

                listItem.SubItems.Add(cs);
                this.listHistory.AddControlToSubItem(b, cs);

                //Add button to view folder

                EXControlListViewSubItem openFolderCol = new EXControlListViewSubItem();
                Button bntOpenFolder = new Button()
                {
                    Image = global::ComicDownloader.Properties.Resources._1364392872_slideshow,
                    //Location = new System.Drawing.Point(248, 123);
                    //Name = "button2";
                    Size = new System.Drawing.Size(24, 24),

                    TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay,
                    UseVisualStyleBackColor = true,
                    Tag = openFolderCol,
                    //Text = chapInfo.PdfPath,
                    Enabled = true,

                };

                bntOpenFolder.Click += new EventHandler(delegate
                {
                     MainWindow window = new MainWindow(new string[] { chapInfo.Folder+"/dum.trick","0"});
                     window.WindowState = FormWindowState.Maximized;
                    window.ShowDialog();
                    //window.SubStartSlideShow();
                });
                // llbl.LinkClicked += new LinkLabelLinkClickedEventHandler(llbl_LinkClicked);
                listItem.SubItems.Add(openFolderCol);
                listHistory.AddControlToSubItem(bntOpenFolder, openFolderCol);


                //listItem.SubItems.Add(chapInfo.Folder);

                EXControlListViewSubItem pdfLinkCol = new EXControlListViewSubItem();
                Button bntOpenPDF = new Button()
                {


                    Image = global::ComicDownloader.Properties.Resources._1364326694_stock_save_pdf_24,
                    //Location = new System.Drawing.Point(248, 123);
                    //Name = "button2";
                    Size = new System.Drawing.Size(24, 24),

                    TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay,
                    UseVisualStyleBackColor = true,
                    Tag = pdfLinkCol,
                    //Text = chapInfo.PdfPath,
                    Enabled = false,
                    
                };

                bntOpenPDF.Click += new EventHandler(bntOpenPDF_Click);
               
                listItem.SubItems.Add(pdfLinkCol);
                listHistory.AddControlToSubItem(bntOpenPDF, pdfLinkCol);

                listItem.SubItems.Add(chapInfo.PdfPath);
                this.listHistory.Items.Add(listItem);
                lblPageCount.Text = string.Format("{0:D2}/{1:D2}", "0", chapInfo.PageCount);

            });
        }

        void bntOpenPDF_Click(object sender, EventArgs e)
        {
            Button link = sender as Button;
            Process.Start(string.Format("\"{0}\"", link.Tag.ToString()));
        }

        private List<ChapterInfo> CollectChaptersToBeDownloaded()
        {
            string rootPath = txtDir.Text;
            toBeDownloadedChapters.Clear();
            using (new LongOperation())
            {
                foreach (Row item in tblChapters.Rows)
                {
                    if (item.Cells[0].Checked)
                    {
                        Guid id = new Guid((item.Cells[1].Text));
                        var chap = this.currentStoryInfo.Chapters.FirstOrDefault(p => p.UniqueIdentify == id);
                        chap.FolderName = txtTitle.Text + " " + chap.ChapId.ToString();
                        chap.Folder = Path.Combine(rootPath, chap.FolderName);
                        chap.PdfFileName = chap.FolderName + ".pdf";
                        chap.PdfPath = Path.Combine(rootPath, "PDF\\" + chap.PdfFileName);
                        chap.Status = DownloadStatus.Waiting;
                        toBeDownloadedChapters.Add(chap);
                    }
                }
            }
            return toBeDownloadedChapters;
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

        void llbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = sender as LinkLabel;
            Process.Start(string.Format("\"{0}\"", link.Text));
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

       
        
        private void bntPauseThread_Click(object sender, EventArgs e)
        {
            threads.RemoveAll(p => p.ThreadState == System.Threading.ThreadState.Stopped);
            
            foreach (var thread in threads)
            {

                if (thread != null && thread.ThreadState == System.Threading.ThreadState.Running)
                //|| 
                //                      thread.ThreadState == System.Threading.ThreadState.WaitSleepJoin)
                {

                    try
                    {
                        thread.Suspend();
                        thread.Suspend();
                    }
                    catch (Exception ex)
                    {
                        MyLogger.Log(ex);
                        
                    }
                    
                }
                else
                {
                    if (thread != null && thread.ThreadState == System.Threading.ThreadState.Suspended || 
                                          thread.ThreadState == System.Threading.ThreadState.WaitSleepJoin ||
                                          thread.ThreadState == System.Threading.ThreadState.SuspendRequested 
                        )
                    {
                        try
                        {
                            thread.Resume();
                            thread.Resume();
                            thread.Resume();
                            thread.Resume();
                        }
                        catch (Exception ex)
                        {
                            MyLogger.Log(ex);

                        }
                        finally
                        {
                            try
                            {
                                thread.Resume();
                                thread.Resume();
                                thread.Resume();
                                thread.Resume();
                            }
                            catch (Exception ex)
                            {

                                MyLogger.Log(ex);
                            }
                        }
                        
                        
                    }
                }
               
                
            }
            

            bntPauseThread.Text = bntPauseThread.Text == "Pause" ? "Resume" : "Pause";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(this.LoadStoryList));
            thread.Start();
        }


        List<StoryInfo> stories = new List<StoryInfo>();

        public static string GetHtml(string url)
        {
            if (url.Length > 0)
            {
                Uri myUri = new Uri(url);
                // Create a 'HttpWebRequest' object for the specified url. 
                HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(myUri);
                myHttpWebRequest.Method = "GET";
                myHttpWebRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                myHttpWebRequest.AutomaticDecompression = DecompressionMethods.GZip;//Or DecompressionMethods.Deflate

                // Set the user agent as if we were a web browser
                myHttpWebRequest.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.4) Gecko/20060508 Firefox/1.5.0.4";

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                var stream = myHttpWebResponse.GetResponseStream();
                var reader = new StreamReader(stream);
                var html = reader.ReadToEnd();
                // Release resources of response object.
                myHttpWebResponse.Close();

                return html;
            }
            else { return "NO URL"; }
        }

        private void LoadStoryList()
        {
            this.Invoke((MethodInvoker)delegate
            {
                loading.Visible = true;
                loading.Location = ddlList.Location;
                loading.Size = ddlList.Size;
                ddlList.Text = "Loading....";
                bntRefresh.Enabled = false;
                ddlList.Enabled = false;
            });

            var stories = Downloader.GetListStories();

            this.Invoke((MethodInvoker)delegate
            {
                ddlList.Enabled = true;
                ddlList.Items.Clear();
                ddlList.Items.AddRange(stories.ToArray());
                lblStoriesCount.Text = "Stories : " + stories.Count.ToString();
                ddlList.Text = string.Format("There are {0} stories in list", stories.Count);
                bntRefresh.Enabled = true;
                loading.Visible = false;
            });

        }

        private void ddlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var info = (ddlList.SelectedItem as StoryInfo);
            string url = info.Url;
            txtUrl.Text = url;
            bntInfo.Enabled = true;
        }

        StoryInfo currentStoryInfo = null;

        public void UpdateTabTitle(string title)
        {
            var form = this.MdiParent as AppMainForm;
            form.UpdateActiveTabTitle(title);
            
        }

        private void bntInfo_Click(object sender, EventArgs e)
        {
            using (new LongOperation())
            {
                this.Invoke(new MethodInvoker(delegate() {

                    this.Text = "Loading...";

                    loading.Location = new System.Drawing.Point(gpbChapters.Location.X + lstChapters.Location.X, gpbChapters.Location.Y + lstChapters.Location.Y);
                    loading.Size = lstChapters.Size;
                    loading.Visible = true;

                }));
                currentStoryInfo = Downloader.RequestInfo(txtUrl.Text);

               
                txtTitle.Text = ddlList.Text;
                txtTitle.Text = currentStoryInfo.Name.Replace('"',' ').Replace('.',' ');

                this.Text = Downloader.Name + currentStoryInfo.Name;

                tblChapters.Rows.Clear();

                foreach (var item in currentStoryInfo.Chapters)
                {
                    item.UniqueIdentify = Guid.NewGuid();

                    int index = tblChapters.Rows.Add(new Row());
                    
                    tblChapters.Rows[index].Cells.Add(new Cell(item.ChapId.ToString(), true));
                    tblChapters.Rows[index].Cells.Add(new Cell(item.UniqueIdentify.ToString(), true));
                    tblChapters.Rows[index].Cells.Add(new Cell(item.ChapId));
                    tblChapters.Rows[index].Cells.Add(new Cell(item.Name.Replace('"', ' ').Replace('.', ' '), true));
                    tblChapters.Rows[index].Cells.Add(new Cell(item.Url, new CellStyle() { ForeColor = System.Drawing.Color.Green }));

                }


                this.Invoke(new MethodInvoker(delegate()
                {
                    loading.Visible = false;

                }));

                ToggleControl(true);
            }
        }

        private void ToggleControl(bool state)
        {
            mnuSelectAll.Enabled = state;
            mnuSelectInverse.Enabled = state;
            mnuSelectNone.Enabled = state;
            mnuAddQueue.Enabled = state;
        }

        private void LockControl(bool p)
        {
            ddlList.Enabled = p;
            txtTitle.Enabled = p;
            txtUrl.Enabled = p;
            

            bntDownload.Enabled = p;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var th = this.downloadThread;
        }

        private void btnExitThread_Click(object sender, EventArgs e)
        {
            foreach (var item in threads)
	        {
		         if (item != null && item.IsAlive)
            {
                item.Abort();
            }
	        }
           
            bntDownload.Enabled = true;
            bntPauseThread.Text = "Pause";
            bntPauseThread.Enabled = false;
            btnExitThread.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (Row item in tblChapters.Rows)
            {
                Console.WriteLine(item.Cells[0].Data);
                item.Cells[0].Checked = false;
            }
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            foreach (Row item in tblChapters.Rows)
            {
                item.Cells[0].Checked = true;
            }
        }

        private void mnuSelectNone_Click(object sender, EventArgs e)
        {
            foreach (Row item in tblChapters.Rows)
            {
                item.Cells[0].Checked = false;
            }
        }

        private void mnuSelectInverse_Click(object sender, EventArgs e)
        {
            foreach (Row item in tblChapters.Rows)
            {
                item.Cells[0].Checked = !item.Cells[0].Checked;
            }
        }

        private void mnuSelectSelected_Click(object sender, EventArgs e)
        {
            foreach (Row item in tblChapters.Rows)
            {
                if (item.Cells[0].Selected)
                    item.Cells[0].Checked = !item.Cells[0].Checked;
            }
        }

        private void lstChapters_SelectionChanged(object sender, XPTable.Events.SelectionEventArgs e)
        {
            mnuSelectSelected.Enabled = true;
        }

       

        private void bntRefresh_Click(object sender, EventArgs e)
        {
            Downloader.DeleteCached();
            Thread thread = new Thread(new ThreadStart(this.LoadStoryList));
            thread.Start();
        }

        private void lstChapters_CellCheckChanged(object sender, XPTable.Events.CellCheckBoxEventArgs e)
        {
            ToggleDownloadButtonBySelected();
            
        }

        private void ToggleDownloadButtonBySelected()
        {
            int count = tblChapters.Rows.Cast<Row>().Count(p => p.Cells[0].Checked);

            if (count > 0)
            {
                bntDownload.Enabled = true;
                lblSelected.Text = "Selected Chapter : " + count.ToString();
            }
            else
            {
                bntDownload.Enabled = false;
                lblSelected.Text = "No chapters selected";
            }
        }

        private void lstChapters_ContextMenuStripChanged(object sender, EventArgs e)
        {
            
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            string urlPattern = @"^(http|https|ftp)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)?((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.[a-zA-Z]{2,4})(\:[0-9]+)?(/[^/][a-zA-Z0-9\.\,\?\'\\/\+&amp;%\$#\=~_\-@]*)*$";
            if (!string.IsNullOrEmpty(txtUrl.Text) &&
                Regex.IsMatch(txtUrl.Text, urlPattern))
            {

                bntInfo.Enabled = true;
                if (Settings.AutoLoadChapter) bntInfo.PerformClick();
            }
            else
            {
                bntInfo.Enabled = false;
            }
        }

        private void lstChapters_CellClick(object sender, XPTable.Events.CellMouseEventArgs e)
        {
            ToggleDownloadButtonBySelected();
        }

      

        private void tblChapters_RowAdded(object sender, XPTable.Events.TableModelEventArgs e)
        {
            bntDownload.Enabled = true;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            this.Text = txtTitle.Text;
            if (txtTitle.Text.AsEnumerable().Any(p => Path.GetInvalidFileNameChars().Contains(p)))
            {
                errInvalidFileName.SetError(txtTitle, "Invalided");
            }
            else
            {
                errInvalidFileName.Clear();
            }
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            
        }

        private void DownloaderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnExitThread.PerformClick();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void mnuAddQueue_Click(object sender, EventArgs e)
        {
            AddToQueue(false);

        }

        private void AddToQueue(bool start)
        {
            QueueDownloadItem item = new QueueDownloadItem()
            {
                ProviderName = Downloader.Name,
                Downloader = Downloader.GetType().FullName,
                StoryUrl = txtUrl.Text,
                StoryName = txtTitle.Text.Trim(),
                Status = DownloadStatus.Waiting,
                SaveFolder = txtDir.Text,
                SelectedChapters = CollectChaptersToBeDownloaded()


            };

            QueueDownloadForm.AddDownloadItem(item);

            var parent = this.MdiParent as AppMainForm;
            parent.ShowQueueForm(start);

        }

        private void addOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddToQueue(false);
        }

        private void mnuAddandStartQueue_Click(object sender, EventArgs e)
        {
            AddToQueue(true);
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            foreach (Row item in tblChapters.Rows)
            {
                if (item.Cells[0].Selected)
                {
                    string url = item.Cells[4].Text;
                    ReadOnlineForm form = new ReadOnlineForm(url);
                    form.Show(this);
                }
            }
        }

        









    }
}
