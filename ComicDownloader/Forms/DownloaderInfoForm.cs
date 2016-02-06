using BrightIdeasSoftware;
using ComicDownloader.Engines;
using ComicDownloader.Properties;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComicDownloader.Forms
{
    public partial class DownloaderInfoForm : MetroForm
    {
        private Downloader downloader = null;
        private DownloaderForm downloaderForm = null;

        public DownloaderInfoForm()
        {
            InitializeComponent();
            //this.listLastestUpdate.FormatRow += delegate (object sender, FormatRowEventArgs args) {
            //    args.Item.Text = args.RowIndex.ToString();
            //};
            this.loading.Size = this.listLastestUpdate.Size;
            this.loading.Location = this.listLastestUpdate.Location;
        }
        public void ShowInfo(StoryInfoCacheFile info, Downloader dl , DownloaderForm parentf)
        {
            downloader = dl;
            dl.OnSearchPageFinished += Dl_OnSearchPageFinished
                ;
            txtKeyword.Text = downloader.Settings.LastKeyword;
            lblUrl.Text = dl.HostUrl;
            lblName.Text = dl.Name;
            this.downloaderForm = parentf;
            lblTotal.Text = info.Stories.Count.ToString();
            lblUpdated.Text = info.Updated.ToString();
            lblEllapsedTime.Text = TimeSpan.FromMilliseconds(info.TotalTime).ToFriendlyDisplay(5);
            Task.Run(() =>
            {
                try
                {
                    pictureBox1.ImageLocation = dl.Logo;
                    pictureBox1.Load();
                }
                catch (Exception ex)
                {

                }
            });

            RefreshLastestItem();
        }

        private void Dl_OnSearchPageFinished(List<StoryInfo> listStories)
        {
            //throw new NotImplementedException();
            this.updateSearchResult(listStories);
        }

        private void RefreshLastestItem()
        {
            Task.Run(() =>
            {
                return downloader.GetLastestUpdates();
            })
            .ContinueWith((result) =>
            {
                this.displayLastestUpdateList(result.Result);
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void displayLastestUpdateList(List<StoryInfo> lastest)
        {
            //if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    listLastestUpdate.SetObjects(lastest);
                    this.loading.Visible = false;
                });
            }
            //else
            //{
            //    listLastestUpdate.SetObjects(lastest);
            //}

        }

        private void listLastestUpdate_DoubleClick(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab == tabUpdate)
            {
                OnRowClick(this.listLastestUpdate, true);
            }
            if (metroTabControl1.SelectedTab == tabSearch)
            {
                OnRowClick(this.listSearchResult, true);
            }
        }

        private void SetDownloadStory(StoryInfo info)
        {
            throw new NotImplementedException();
        }
         public void OnRowClick(ObjectListView sender,bool download= false)
        {
            var selected = sender.SelectedItem;
            if (selected != null)
            {
                var info = selected.RowObject as StoryInfo;
                this.downloaderForm.SetDownloadStory(info, download);
                this.Close();

            }

        }
        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(metroTabControl1.SelectedTab == tabUpdate)
            {
                OnRowClick(this.listLastestUpdate,false);
            }
            if (metroTabControl1.SelectedTab == tabSearch)
            {
                OnRowClick(this.listSearchResult, false);
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedTab == tabUpdate)
            {
                OnRowClick(this.listLastestUpdate, true);
            }
            if (metroTabControl1.SelectedTab == tabSearch)
            {
                OnRowClick(this.listSearchResult, true);
            }
        }

        private void listLastestUpdate_SelectionChanged(object sender, EventArgs e)
        {
            var selected = ((ObjectListView)sender).SelectedItem;
            bool hasSelectedItem = selected != null;
            viewToolStripMenuItem.Enabled = hasSelectedItem;
            downloadToolStripMenuItem.Enabled = hasSelectedItem;
            addToQueueToolStripMenuItem.Enabled = hasSelectedItem;
            refreshToolStripMenuItem.Enabled = hasSelectedItem;
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loading.Visible = true;
            RefreshLastestItem();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private List<StoryInfo> searchResults = null;
        private void DisplaySearchCompleteAnimation()
        {
            AnimatedDecoration listAnimation = new AnimatedDecoration(this.listSearchResult);
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

            Sprite text = new TextSprite(string.Format("Search completed : {0} items found!", this.searchResults.Count), new Font("Tahoma", 32), Color.Blue, Color.AliceBlue, Color.Red, 3.0f);
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

        private void metroButton1_Click(object sender, EventArgs e)
        {
            searchResults = new List<StoryInfo>();
            searchLoading.Location = btnSearch.Location;
            searchLoading.Size = btnSearch.Size;
            searchLoading.Visible = true;
            this.listSearchResult.SetObjects(searchResults);
            var keyword = txtKeyword.Text.Trim();
            downloader.Settings.LastKeyword = keyword;
            downloader.SaveSetting(downloader.Settings);

            if (offlineCheck.Checked)
            {
                Task.Run(() =>
                {
                    return this.downloader.Search(keyword, false, false);
                }).ContinueWith((t) => {
                    this.updateSearchResult(t.Result);
                    this.InvokeOnMainThread(() =>
                    {
                        if (!onlineCheck.Checked)
                        {
                            searchLoading.Visible = false;
                            DisplaySearchCompleteAnimation();
                        }
                    });
                });
                
            }
            if (onlineCheck.Checked)
            {
                Task.Run(() =>
                {
                    return this.downloader.OnlineSearch(keyword);
                })
                .ContinueWith((t) =>
                {
                    this.updateSearchResult(t.Result, false);
                    this.InvokeOnMainThread(() =>
                    {
                        searchLoading.Visible = false;
                        DisplaySearchCompleteAnimation();
                    });
                });
            }
        }

        private void updateSearchResult(List<StoryInfo> result, bool appendToList = true)
        {
            lock(searchResults)
            {
                var notExist = result.Where(p => !searchResults.Any(x => x.Url == p.Url)).ToList();

                searchResults.AddRange(notExist);
            }
            if (appendToList)
            {
                this.listSearchResult.InvokeOnMainThread(() =>
                {
                    listSearchResult.AddObjects(result);
                });
            }
        }
    }
}
