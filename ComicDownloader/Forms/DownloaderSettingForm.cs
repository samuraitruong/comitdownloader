using ComicDownloader.Engines;
using MetroFramework.Forms;
using System; using System.Net;
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
    public partial class DownloaderSettingForm : MetroForm
    {
        private Downloader downloader;
        private DownloaderSetting setting;

        public DownloaderSettingForm()
        {
            InitializeComponent();
        }
        public DownloaderSettingForm(Downloader dl)
        {
            InitializeComponent();
            downloader = dl;
            this.DisplayData(dl);
        }

        private void DisplayData(Downloader dl)
        {
            this.downloader = dl;
            this.setting = downloader.Settings;
            if(this.setting == null || setting.UserName == null)
            {
                setting = new DownloaderSetting();
            }

             txtUserName.Text = this.setting.UserName;
            txtPassword.Text = this.setting.Password ;
            chkIECookie.Checked = this.setting.UseIECookies;
            toggleClipboard.Checked = this.setting.ClipboardMonitor;
            chkMySite.Checked = this.setting.ShowOnMySiteTab;
            txtUserName.Enabled = true;
            txtUserName.ReadOnly = false;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.setting.UserName = txtUserName.Text;
            this.setting.Password = txtPassword.Text;
            this.setting.UseIECookies = chkIECookie.Checked;
            this.setting.ClipboardMonitor = toggleClipboard.Checked;
            this.setting.ShowOnMySiteTab = chkMySite.Checked;
            downloader.SaveSetting(this.setting);
            this.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

            var logged = this.downloader.Login();
        }
    }
}
