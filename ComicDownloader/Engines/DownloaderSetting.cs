using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicDownloader.Engines
{
    public class DownloaderSetting
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseIECookies { get; set; }
        public bool ClipboardMonitor { get; set; }
        public string LastKeyword { get;  set; }

        public DownloaderSetting()
        {
            this.UserName = "";
            this.Password = "";
            this.UseIECookies = true;
            this.ClipboardMonitor = true;
            this.LastKeyword = "Dragon ball";
        }
    }
}
