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


namespace ComicDownloader
{
    public partial class DownloaderForm : MdiChildForm
    {
        public Downloader Downloader { get; set; }

        private const string HOST_URL = "http://truyentranhtuan.com";
        public DownloaderForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            bntStop.Enabled = true;
            btnExitThread.Enabled = true;
            downloadThread = new Thread(new ThreadStart(this.DownloadProcess));
            downloadThread.Start();

            //DownloadProcess();

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
            //create PDF folder

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

            try
            {
                var stream = File.Create(chapInfo.PdfPath);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

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
                        pdfDoc.Add(img);
                        pdfDoc.NewPage();
                    }
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

        private void DownloadChapter(ChapterInfo chapInfo)
        {
            CreateChapterFolder(chapInfo);

            int count = 0;
            long size = 0;

            foreach (string pageUrl in chapInfo.Pages)
            {
                string tempUrl = pageUrl;
                if (tempUrl.Contains("?"))
                {
                    tempUrl = tempUrl.Substring(0, tempUrl.IndexOf("?"));
                }

                string filename = Path.Combine(chapInfo.Folder, Path.GetFileName(tempUrl));


                try
                {
                    count++;

                    Downloader.DownloadPage(pageUrl, filename, chapInfo.Url);

                    var file = File.Open(filename, FileMode.Open);

                    size += file.Length;
                    total += file.Length;
                    file.Close();

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
                catch
                {
                }
                finally
                {

                }


            }
        }

        private void DisplayChap(ChapterInfo chapInfo, int chapCount)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.progess.Minimum = 1;
                this.progess.Value = 1;
                this.progess.Maximum = chapInfo.PageCount;
                var listItem = new EXListViewItem(chapCount.ToString());
                listItem.SubItems.Add(chapInfo.Name);
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


                listItem.SubItems.Add(chapInfo.Folder);

                EXControlListViewSubItem pdfLinkCol = new EXControlListViewSubItem();
                LinkLabel llbl = new LinkLabel();
                llbl.Height = 12;
                llbl.Text = chapInfo.PdfPath;
                llbl.Tag = cs;
                llbl.LinkClicked += new LinkLabelLinkClickedEventHandler(llbl_LinkClicked);
                listItem.SubItems.Add(pdfLinkCol);
                listHistory.AddControlToSubItem(llbl, pdfLinkCol);

                listItem.SubItems.Add(chapInfo.PdfPath);
                this.listHistory.Items.Add(listItem);
                lblPageCount.Text = string.Format("{0:D2}/{1:D2}", "0", chapInfo.PageCount);

            });
        }

        private void CollectChaptersToBeDownloaded()
        {
            string rootPath = txtDir.Text;
            toBeDownloadedChapters.Clear();
            using (new LongOperation())
            {
                foreach (Row item in tblChapters.Rows)
                {
                    if (item.Cells[0].Checked)
                    {
                        int id = Convert.ToInt32(item.Cells[1].Data);
                        var chap = this.currentStoryInfo.Chapters.FirstOrDefault(p => p.ChapId == id);
                        chap.FolderName = txtTitle.Text + " " + chap.ChapId.ToString();
                        chap.Folder = Path.Combine(rootPath, chap.FolderName);
                        chap.PdfFileName = chap.FolderName + ".pdf";
                        chap.PdfPath = Path.Combine(rootPath, "PDF\\" + chap.PdfFileName);
                        toBeDownloadedChapters.Add(chap);
                    }
                }
            }
        }

        private void CreateChapterFolder(ChapterInfo chapInfo)
        {
            try
            {
                Directory.CreateDirectory(chapInfo.Folder);
                //Directory.CreateDirectory(Path.GetFullPath(chapInfo.PdfPath));
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

        private void Form1_Leave(object sender, EventArgs e)
        {

            //if (downloadThread != null)
            //{
            //    downloadThread.Abort();
            //}
        }

        private void bntStop_Click(object sender, EventArgs e)
        {
            if (downloadThread != null && downloadThread.ThreadState == System.Threading.ThreadState.Running)
            {
                downloadThread.Suspend();
                bntStop.Text = "Resume";
            }
            else
            {
                if (downloadThread != null && downloadThread.ThreadState == System.Threading.ThreadState.Suspended)
                {
                    downloadThread.Resume();
                    bntStop.Text = "Pause";
                }
            }

            //bntDownload.Enabled = true;

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
                ddlList.Text = string.Format("There are {0} in list", stories.Count);
                bntRefresh.Enabled = true;
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
                }));
                currentStoryInfo = Downloader.RequestInfo(txtUrl.Text);

               
                txtTitle.Text = ddlList.Text;
                txtTitle.Text = currentStoryInfo.Name;

                this.Text = Downloader.Name + currentStoryInfo.Name;

                tblChapters.Rows.Clear();

                foreach (var item in currentStoryInfo.Chapters)
                {
                    int index = tblChapters.Rows.Add(new Row());
                    tblChapters.Rows[index].Cells.Add(new Cell(item.ChapId.ToString(), true));
                    tblChapters.Rows[index].Cells.Add(new Cell(item.ChapId));
                    tblChapters.Rows[index].Cells.Add(new Cell(item.Name, true));
                    tblChapters.Rows[index].Cells.Add(new Cell(item.Url, new CellStyle() { ForeColor = System.Drawing.Color.Green }));

                }


                ToggleControl(true);
            }
        }

        private void ToggleControl(bool state)
        {
            mnuSelectAll.Enabled = state;
            mnuSelectInverse.Enabled = state;
            mnuSelectNone.Enabled = state;
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
            if (downloadThread != null && downloadThread.ThreadState == System.Threading.ThreadState.Running)
            {
                downloadThread.Abort();
            }
            bntDownload.Enabled = true;
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

        private void button2_Click_2(object sender, EventArgs e)
        {
           // this.BeginAsyncIndication();
        }

        private void bntRefresh_Click(object sender, EventArgs e)
        {
            Downloader.DeleteCached();
            Thread thread = new Thread(new ThreadStart(this.LoadStoryList));
            thread.Start();
        }

        private void lstChapters_CellCheckChanged(object sender, XPTable.Events.CellCheckBoxEventArgs e)
        {
            //foreach (Row item in tblChapters.Rows)
            //{
            //    if (item.Cells[0].Selected)
            //        MessageBox.Show(item.Cells[0].Text);
            //}
        }

        private void lstChapters_ContextMenuStripChanged(object sender, EventArgs e)
        {
            
        }

        









    }
}
