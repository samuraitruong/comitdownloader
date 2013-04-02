using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using System.IO;
using System.Net;
using ComicDownloader.Properties;

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

        public virtual string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            string filename = Path.GetFileName(pageUrl);
            filename = filename.Substring(0, filename.IndexOf("?"));

            using (WebClient client = new WebClient())
            {
                client.Headers.Add("Referer", httpReferer);
                try
                {

                    string replaceFileName = renamePattern.Replace("{FILENAME}", filename);

                    filename = Path.Combine(folder, replaceFileName);
                    client.DownloadFile(pageUrl, filename);
                }
                catch
                {
                }
            }
            return filename;
        }
        public void SaveCache(List<StoryInfo> stories)
        {
            var temp = Path.GetTempPath() + Path.GetRandomFileName();
            var xml = SerializationHelper.SerializeToXml<List<StoryInfo>>(stories);
            using (var file = new StreamWriter(File.Open(temp, FileMode.OpenOrCreate)))
            {
                file.Write(xml);
            }

            SecureHelper.EncryptFile(temp, CachedFile, Resources.SecureKey);
        }

        public List<StoryInfo> ReloadChachedData()
        {

            if (File.Exists(this.CachedFile))
            {
                var temp = Path.GetTempPath()+ Path.GetRandomFileName();

                SecureHelper.DecryptFile(CachedFile, temp, Resources.SecureKey);

                using (var file = File.OpenText(temp))
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

        public static List<Downloader> GetAllDownloaders()
        {
            List<Downloader> list = new List<Downloader>();
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var item in types)
            {
                if (item.BaseType == typeof(Downloader))
                {
                    
                    Downloader instance = (Downloader)Activator.CreateInstance(item);
                    list.Add(instance);
                }
            }
            return list;
        }
    }
}
