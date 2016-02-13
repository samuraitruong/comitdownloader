using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ComicDownloader.Engines
{
    [AttributeUsage(AttributeTargets.Class,  AllowMultiple = true)]
    public class DownloaderAttribute : Attribute
    {
        public string MetroTab { get; set; }
        public string Name { get; set; }
        public string MenuGroup { get; set; }
        public string Language { get; set; }
        public string Image32 { get; set; }
        public string Image24 { get; set; }
        public string Image16 { get; set; }
        public bool Offline { get; set; }

        public bool Enable { get; set; }
        public DownloaderAttribute(string name)
        {
            Name = name;
            Image32 = "load_download";
        }
    }
}

