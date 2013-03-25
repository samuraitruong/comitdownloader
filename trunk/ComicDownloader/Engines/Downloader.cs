using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;
using System.Net;

namespace ComicDownloader.Engines
{
    public abstract class Downloader
    {
        public List<StoryInfo> AllStories { get; set; }
        public abstract string Name { get; }
        public abstract  string ListStoryURL { get;  }
        public abstract string HostUrl { get; }
        public abstract string StoryUrlPattern { get; }

        public abstract List<StoryInfo> GetListStories();
        public abstract StoryInfo RequestInfo(string storyUrl);

        public abstract List<string> GetPages(string chapUrl);
        public string CachedFile { get {return this.GetType().Name + ".CACHED"; } }

        public virtual void DownloadPage(string pageUrl, string filename, string httpReferer)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Referer", httpReferer);
                try
                {
                    client.DownloadFile(pageUrl, filename);
                }
                catch
                {
                }
            }
        }
        public void SaveCache(List<StoryInfo> stories)
        {
            var xml = SerializationHelper.SerializeToXml<List<StoryInfo>>(stories);
            using (var file = new StreamWriter(File.Open(CachedFile, FileMode.OpenOrCreate)))
            {
                file.Write(xml);
            }
        }

        public List<StoryInfo> ReloadChachedData()
        {

            if (File.Exists(this.CachedFile))
            {
                using (var file = File.OpenText(CachedFile))
                {
                    return SerializationHelper.DeserializeFromXml<List<StoryInfo>>(file.ReadToEnd());
                }
            }
            return null;
        }

        public int ExtractID(string name, string pattern)
        {
            var match = Regex.Match(name, pattern, RegexOptions.IgnoreCase);
            if (match != null)
            {
                int id = 0;
                int.TryParse(match.Groups[1].Value, out id);
                return id;
            }
            return 0;

        }

        public int ExtractID(string name)
        {
            return ExtractID(name, @".*\s(\d*)$");
            
        }

        internal  void DeleteCached()
        {
            try
            {
                File.Delete(this.CachedFile);
            }
            finally
            {

            }
        }
    }
}
