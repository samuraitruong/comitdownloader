using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ComicDownloader.Engines
{
    [AttributeUsage(AttributeTargets.Class,  AllowMultiple = true)]
    public class DownloaderAttribute : Attribute
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Image32 { get; set; }
        public string Image24 { get; set; }
        public string Image16 { get; set; }

        public DownloaderAttribute(string name)
        {
            Name = name;
        }
    }
}

