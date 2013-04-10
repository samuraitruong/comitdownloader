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
        public string CachedFile { get {
            
            return Environment.GetFolderPath(
    Environment.SpecialFolder.ApplicationData)+"\\ComicDownloader\\"+ this.GetType().Name + ".CACHED";
        
        } }

        public virtual List<StoryInfo> GetLastestUpdates()
        {
            return new List<StoryInfo>();
        }

        public virtual List<StoryInfo> OnlineSearch(string keyword)
        {
            return new List<StoryInfo>();
        }
        /// <summary>
        /// online = true, will search online, false will search on cache data load before.
        /// Recache = true,
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="online"></param>
        /// <param name="recache"></param>
        /// <returns></returns>
        public List<StoryInfo> Search(string keyword, bool online, bool recache)
        {
            if (online) return OnlineSearch(keyword);

            List<StoryInfo> results = new List<StoryInfo>();

            if (recache)
            {
                File.Delete(CachedFile);
                results = GetListStories();
            }
            else
            {
                results = ReloadChachedData();
            }


            if (results != null)
                {
                    results = results.Where(p => p.Name.Contains(keyword)).ToList();
                }
            
            return results;
        }

        public virtual string DownloadPage(string pageUrl, string renamePattern, string folder, string httpReferer)
        {
            string filename = Path.GetFileName(pageUrl);
            if(filename.Contains("?"))
            {
                filename = filename.Substring(0, filename.IndexOf("?"));
            }

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
            MyLogger.Info(CachedFile);
            MyLogger.Info(temp);
            Directory.CreateDirectory(Path.GetDirectoryName(CachedFile));
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
        private static List<Downloader> _downloaders;

        public static Downloader Resolve(string url)
        {
            return GetAllDownloaders().FirstOrDefault(p => url.Contains(p.HostUrl));
        }
        public static List<Downloader> GetAllDownloaders()
        {
           
            if (_downloaders != null) return _downloaders;
            _downloaders = new List<Downloader>();
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var item in types)
            {
                if (item.BaseType == typeof(Downloader))
                {
                    
                    Downloader instance = (Downloader)Activator.CreateInstance(item);
                    _downloaders.Add(instance);
                }
            }
            return _downloaders;
        }



        public List<StoryInfo> GetListStories(bool force)
        {
            if (force)
            {
                File.Delete(this.CachedFile);
                return GetListStories();
            }
            else
            {
                if (!File.Exists(CachedFile)) return new List<StoryInfo>();


            }

            return ReloadChachedData();

        }
    }
}
