using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ComicDownloader.Engines
{
    public class ChapterInfo
    {
        public string Downloader { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Page { get; set; }
        
        public Guid UniqueIdentify { get; set; }

        public int ChapId { get; set; }

        public string Folder { get; set; }

        public string FolderName { get; set; }

        public string PdfFileName { get; set; }

        public string PdfPath { get; set; }
        public DownloadStatus Status { get; set; }
        public List<string> Pages { get; set; }

        public int PageCount { get; set; }

        public long Size { get; set; }

        public int Priority { get; set; }
        public int Sequence { get; set; }

        public int DownloadedCount { get; set; }
        public ChapterInfo() {
            DownloadedCount = 0;
            Status = DownloadStatus.Waiting;
            UniqueIdentify = new Guid();
        }

        public DateTime LastModified { get; set; }
    }
    public class StoryInfo
    {
        public string Group
        {
            get
            {
                //return "A";
                var firstChar = Name.Trim().FirstOrDefault();
                if (char.IsLetterOrDigit(firstChar))
                {
                    return firstChar.ToString().ToUpper();
                }

                return "#";
            }
        }
        public string Name { get; set; }
        public string AltName { get; set; }
        public string Author { get; set; }
        public string Categories { get; set; }

        public string Url { get; set; }
        public List<ChapterInfo> Chapters { get; set; }
        public int ChapterCount { get; set; }

        
        public string UrlSegment { get; set; }
        public string Summary { get; set; }

        public StoryInfo()
        {
            Chapters = new List<ChapterInfo>();
        }
        public override string ToString()
        {
            return Name;
        }

        public void Beautifier()
        {
            Name = Regex.Replace(Name, @"&\w{4};?", string.Empty);
            Url = Url.Trim();
            Url = Url.TrimStart("{}[(".ToCharArray());
            Url = Url.TrimEnd("]){}".ToCharArray());
        }
    }

    public enum CrawlTypes
    {
        Manual,
        Clould
    }
    public class StoryInfoCacheFile
    {
        public List<StoryInfo> Stories { get; set; }
        public DateTime Updated { get; set; }
        public long TotalTime { get; set; }
        public CrawlTypes Type { get; set; }
        public StoryInfoCacheFile()
        {
            Stories = new List<StoryInfo>();
            Updated = DateTime.Now;
        }

    }
}
