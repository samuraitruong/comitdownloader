using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicDownloader.Engines
{
    public class ChapterInfo
    {
        public string Downloader { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Page { get; set; }

        public int ChapId { get; set; }

        public string Folder { get; set; }

        public string FolderName { get; set; }

        public string PdfFileName { get; set; }

        public string PdfPath { get; set; }
        public DownloadStatus Status { get; set; }
        public List<string> Pages { get; set; }

        public int PageCount { get; set; }

        public long Size { get; set; }

        public int DownloadedCount { get; set; }
        public ChapterInfo() {
            DownloadedCount = 0;
        }
    }
    public class StoryInfo
    {
        public string Name { get; set; }
        public string AltName { get; set; }
        public string Author { get; set; }
        public string Categories { get; set; }

        public string Url { get; set; }
        public List<ChapterInfo> Chapters { get; set; }
        public int ChapterCount { get; set; }

        
        public string UrlSegment { get; set; }

        public StoryInfo()
        {
            Chapters = new List<ChapterInfo>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
