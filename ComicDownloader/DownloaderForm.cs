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
        public  Downloader Downloader { get; set; }

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

        string url = "";
        List<int> chapters = new List<int>();
        string dir = "";
        long total = 0;
        private void StartDownload()
        {
            dir = txtDir.Text;
            url = txtUrl.Text + "/{0}/doc-truyen/";
            listHistory.Items.Clear();
            chapters.Clear();
            if (txtPages.Text.Contains('-'))
            {
                var arr = txtPages.Text.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = Convert.ToInt32(arr[0]); i <= Convert.ToInt32(arr[1]); i++)
                {
                    chapters.Add(i);
                }
            }
            else
            {
                chapters.Add(Convert.ToInt32(txtPages.Text));
            }
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
            foreach (var item in chapters)
            {
                chapterCount++;
                string path = txtTitle.Text  +" Chapter "+ item.ToString();
                string chapter  = path;
                this.Invoke((MethodInvoker)delegate
                {
                    lblStatus.Text = path;
                });

                string pdfFile = path + ".pdf";
                string pdfPath = dir+"\\PDF";
                pdfFile = Path.Combine(pdfPath, pdfFile);
                
                path = Path.Combine(dir, path);
                try
                {
                    //Directory.Delete(path, true);
                    //Directory.Delete(pdfPath, true);
                }
                catch { }

                var di = Directory.CreateDirectory(path);
                Directory.CreateDirectory(pdfPath);

                var page = string.Format(url, item);
                string html = "";
                using (WebClient client = new WebClient())
                {
                    html = client.DownloadString(page);
                }



                
                Document pdfDoc = new Document(PageSize.A4);
                float docw = pdfDoc.PageSize.Width;
                float doch = pdfDoc.PageSize.Width;

                try
                {
                    var stream = File.Create(pdfFile);
                    PdfWriter.GetInstance(pdfDoc, stream);
                    pdfDoc.Open();
                }
                catch (Exception ex)
                {
                    //Log error;
                }
                finally
                {
                    //doc.Close();
                }

                var matches = Regex.Matches(html, @"/manga/[0-9a-zA-Z//s-]*(?:.png|.jpg|.PNG|.JPG)");
                
                this.Invoke((MethodInvoker)delegate
                {
                    this.progess.Minimum = 1;
                    this.progess.Value = 1;
                    this.progess.Maximum = matches.Count;
                    var listItem = new EXListViewItem(chapterCount.ToString());
                    listItem.SubItems.Add(chapter);
                    listItem.SubItems.Add(matches.Count.ToString());
                    listItem.SubItems.Add("0");
                    EXControlListViewSubItem cs = new EXControlListViewSubItem();
                    ProgressBar b = new ProgressBar();
                    //b.Tag = item;
                    b.Minimum = 0;
                    b.Maximum = matches.Count;
                    b.Step = 1;
                    
                    listItem.SubItems.Add(cs);
                    this.listHistory.AddControlToSubItem(b, cs);

                    
                    listItem.SubItems.Add(di.FullName);

                    EXControlListViewSubItem pdfLinkCol = new EXControlListViewSubItem();
                    LinkLabel llbl = new LinkLabel();
                    llbl.Height = 12;
                    llbl.Text = pdfFile;
                    llbl.Tag = cs;
                    llbl.LinkClicked += new LinkLabelLinkClickedEventHandler(llbl_LinkClicked);
                    listItem.SubItems.Add(pdfLinkCol);
                    listHistory.AddControlToSubItem(llbl, pdfLinkCol);

                    listItem.SubItems.Add(pdfFile);
                    this.listHistory.Items.Add(listItem);
                    lblPageCount.Text = string.Format("{0:D2}/{1:D2}", "0", matches.Count);

                });

                int count = 0;
                long size = 0;
                var links = matches.Cast<Match>()
                    .OrderBy(p => p.Value)
                    .Select(p => p.Value)
                    .ToList();

                foreach (string link in links)
                {


                    var pageUrl = "http://truyentranhtuan.com" + link;

                    string filename = Path.Combine(di.FullName, Path.GetFileName(pageUrl));
                    //Console.WriteLine(pageUrl);

                    using (WebClient client = new WebClient())
                    {
                        try
                        {
                            count++;

                            client.DownloadFile(pageUrl, filename);

                            this.Invoke((MethodInvoker)delegate
                            {
                                this.progess.Value = count;
                                 lblPageCount.Text = string.Format("{0:D2}/{1:D2}", count, links.Count);
                                 

                            });

                            var file = File.Open(filename, FileMode.Open);

                            size += file.Length;
                            total += file.Length;

                            this.Invoke((MethodInvoker)delegate
                            {
                                var listItem = listHistory.Items[listHistory.Items.Count - 1];
                                listItem.SubItems[3].Text = size.ToKB();
                                lblTotalDownloadCount.Text = total.ToKB();
                                var subItem = listItem.SubItems[4] as EXControlListViewSubItem;
                                var pp = subItem.MyControl as ProgressBar;
                                pp.Value = count;
                               
                            });
                            if (file.Length < 20 * 1024)
                            {
                                file.Close();
                                File.Delete(filename);

                            }
                            else
                            {
                                Image img = Image.GetInstance(file);
                                float h = img.Height;
                                float w = img.Width;

                                float hp =  doch/h;
                                float wp = docw/w;

                                img.ScaleToFit(docw * 1.35f, doch * 1.35f);
                               // img.ScaleToFit(750, 550);
                                pdfDoc.Add(img);
                                pdfDoc.NewPage();
                            }
                            file.Close();
                        }
                        catch
                        {
                        }
                        finally
                        {

                        }
                    }

                }
                try
                {
                    pdfDoc.Close();
                }
                catch (Exception ex) { }


            }

            this.Invoke((MethodInvoker)delegate
            {
                bntDownload.Enabled = true;
                lblStatus.Text = "Completed!";
                MessageBox.Show("Download completed!");
            });

        }

        void llbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = sender as LinkLabel;
            Process.Start(string.Format("\"{0}\"",link.Text));
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
myHttpWebRequest.AutomaticDecompression = DecompressionMethods.GZip ;//Or DecompressionMethods.Deflate

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
            var stories = Downloader.GetListStories();

            this.Invoke((MethodInvoker)delegate
            {
                ddlList.Items.Clear();
                ddlList.Items.AddRange(stories.ToArray());
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
        private void bntInfo_Click(object sender, EventArgs e)
        {
            var currentStoryInfo = Downloader.RequestInfo(txtUrl.Text);

            txtPages.Text = "1-" + currentStoryInfo.ChapterCount.ToString();
            txtTitle.Text = ddlList.Text;
            txtTitle.Text = currentStoryInfo.Name;


            tblChapters.Rows.Clear();

            foreach (var item in currentStoryInfo.Chapters)
            {
                int index = tblChapters.Rows.Add(new Row());
                tblChapters.Rows[index].Cells.Add(new Cell(item.ChapId.ToString(), true));
               // tblChapters.Rows[index].Cells.Add(new Cell(item.ChapId));
                tblChapters.Rows[index].Cells.Add(new Cell(item.Name, true));
                tblChapters.Rows[index].Cells.Add(new Cell(item.Url, new CellStyle(){ForeColor= System.Drawing.Color.Green}));
                //tblChapters.Rows[index].Cells[0].Data = true;
            }
             
            //LockControl(true);
        }

        private void LockControl(bool p)
        {
            ddlList.Enabled = p;
            txtTitle.Enabled = p;
            txtUrl.Enabled = p;
            txtPages.Enabled = p;
            
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

        

      


        


    }
}
