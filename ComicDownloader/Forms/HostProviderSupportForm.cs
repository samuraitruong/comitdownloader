using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cx.Windows.Forms;
using ComicDownloader.Engines;
using System.Threading;
using ExtendedWebBrowser2;

namespace ComicDownloader
{
    public partial class HostProviderSupportForm : MdiChildForm
    {
        public class ProviderItem
        {
            public string Language { get; set; }
            public string HostUrl { get; set; }
            public string Name { get; set; }
            public int Stories { get; set; }
            public string Status { get; set; }
        }
        public HostProviderSupportForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

        }
        List<ProviderItem> ds = new List<ProviderItem>();
        private void HostProviderSupportForm_Load(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(delegate()
            {
                var downloaders = Downloader.GetAllDownloaders();

                foreach (var item in downloaders)
                {
                    var attrs = item.GetType().GetCustomAttributes(typeof(DownloaderAttribute), true).Cast<DownloaderAttribute>().ToList();

                    foreach (var att in attrs)
                    {
                        try
                        {
                            var dsitem = new ProviderItem()
                            {
                                Language = att.Language,
                                HostUrl = item.HostUrl,
                                Name = item.Name.TrimEnd(" -".ToCharArray()),
                                Stories = item.GetListStories(false).Count
                            };
                            dataListView1.AddObject(dsitem);
                            ds.Add(dsitem);
                        }
                        catch (Exception ex)
                        {
                            
                           
                        }
                       

                    }


                }
                dataListView1.SetObjects(ds.Distinct());
            })).Start();
        }

        private void allProvidersToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Notice: Running batch preload data making your computer haevy load and taking a lot of internet bandwith. Are you sure you want to continue?", "Batch preload list story", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {

                var downloaders = Downloader.GetAllDownloaders();
                ExecuteBatchPreload(downloaders);
            }
        }

        private void ExecuteBatchPreload(List<Downloader> downloaders)
        {
            progressBar.Maximum = downloaders.Count;
            progressBar.Minimum = 0;
            progressBar.Value = 0;

            foreach (var item in downloaders)
            {

                var dsItem = ds.FirstOrDefault(p => p.HostUrl == item.HostUrl);
                dsItem.Status = "Loading...";
                Thread thread = new Thread(new ThreadStart(delegate
                {

                    try
                    {
                        var list = item.GetListStories(true);
                        dsItem.Stories = list.Count;
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        dsItem.Status = "Done!";
                    }

                    lock (ds)
                    {
                        this.Invoke(new MethodInvoker(delegate()
                        {
                            progressBar.Increment(1);

                            int percent = (int)(((double)(progressBar.Value - progressBar.Minimum) /(double)(progressBar.Maximum - progressBar.Minimum)) * 100);
                            
                            using (Graphics gr = progressBar.ProgressBar.CreateGraphics())
                            {
                                gr.DrawString(percent.ToString() + "%",
                                    SystemFonts.DefaultFont,
                                    Brushes.Black,
                                    new PointF(progressBar.Width / 2 - (gr.MeasureString(percent.ToString() + "%",
                                        SystemFonts.DefaultFont).Width / 2.0F),
                                    progressBar.Height / 2 - (gr.MeasureString(percent.ToString() + "%",
                                        SystemFonts.DefaultFont).Height / 2.0F)));
                            }

                        }));
                        dataListView1.RefreshObject(dsItem);
                    }

                }));

                lock (ds)
                {
                    dataListView1.RefreshObject(dsItem);
                }

                thread.Start();
            }
        }

        private void SelectedProviderMenuItem_Click(object sender, EventArgs e)
        {
            //var all = Downloader.GetAllDownloaders();
            List<Downloader> downloaders = new List<Downloader>();

            foreach (ListViewItem item in dataListView1.Items)
            {
                if (item.Selected)
                {
                    string host = item.SubItems[2].Text;
                    downloaders.Add(Downloader.Resolve(host));
                    //MessageBox.Show(
                }
            }
            ExecuteBatchPreload(downloaders);
        }

        private void HostProviderSupportForm_Resize(object sender, EventArgs e)
        {
             progressBar.Size = new Size(this.statusStrip1.Width - 15, progressBar.Height);
        }

        private void progressBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string url = "";
            foreach (ListViewItem item in dataListView1.Items)
            {
                if (item.Selected)
                {
                     url = item.SubItems[2].Text;
                   break;
                    
                }
            }
            BrowserForm form = new BrowserForm();
            form.ShowDialog();

        }
    }
}
