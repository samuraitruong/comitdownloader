using System; using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using ComicDownloader.Engines;

namespace ComicDownloader
{
    public enum DownloadStatus
    {
        Canceled,
        Stoped,
        Completed,
        Downloading,
        Waiting,
        Error
    }

   
   public class QueueDownloadItem
    {
        public long Size { get; set; }

        public string Downloader { get; set; }
        public string StoryUrl { get; set; }
        public string StoryName { get; set; }

        public List<ChapterInfo> SelectedChapters { get; set; }
        public string SaveFolder { get; set; }
        public DownloadStatus Status { get; set; }

        public string ProviderName { get; set; }
        public int  Priority { get; set; }
        public int Sequence { get; set; }
    }
}
