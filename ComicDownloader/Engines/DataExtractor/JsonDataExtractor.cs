using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicDownloader.Engines.DataExtractor
{
    public class JsonDataExtractor  : DataExtractor
    {
        private string folder;
        Dictionary<string, List<StoryInfo>> internalCache = new Dictionary<string, List<StoryInfo>>();
        public string IndexFile
        {
            get
            {
                return Path.Combine(this.folder, "index.json");
            }
        }

        public JsonDataExtractor (string destination): base()
        {
            this.folder = destination;
        }
        private object myLocker = new object();
        public override void UpdateIndex(List<StoryInfo> list)
        {
            foreach (var item in list)
            {
                item.JsonFileName = item.Url.SHA256() + ".json";
            }
            lock (myLocker)
            {
                this.allStories.AddRange(list);
                File.WriteAllText(this.IndexFile, JsonConvert.SerializeObject(this.allStories),Encoding.UTF8);
            }
        }
        public string GetBaseFolder(string name, string nested="")
        {
            Directory.CreateDirectory(folder);
            Uri uri = new Uri(name);
            string path = Path.Combine(folder, uri.Host);
            Directory.CreateDirectory(path);
            return path;
        }
        public override bool IsStored(ChapterInfo c, Downloader dl)
        {
            var file = Path.Combine(this.GetBaseFolder(dl.HostUrl), c.JsonFileName);
            return File.Exists(file);
        }
        public override List<StoryInfo> GetList(Downloader dl)
        {
            var file = Path.Combine(this.GetBaseFolder(dl.HostUrl), "stories.json");
            if(internalCache[file.SHA256()] != null)
            {
                return internalCache[file.SHA256()];
            }
            var json = File.ReadAllText(file);
            var list = JsonConvert.DeserializeObject<List<StoryInfo>>(json);
            internalCache[file.SHA256()] = list;
            return list;
        }
        public override void StoreStory(StoryInfo story , Downloader dl)
        {
            story.JsonFileName = story.Url.SHA256() + ".json";
            foreach (var item in story.Chapters)
            {
                item.JsonFileName = item.Url.SHA256() + ".json";
            }

            var file = Path.Combine(GetBaseFolder(dl.HostUrl), story.JsonFileName);
            File.WriteAllText(file, JsonConvert.SerializeObject(story));

            //var list = GetList(dl);
            //var index = list.FindIndex(p => p.Url == story.Url);
            //lock(myLocker)
            //{
            //    list[index] = story;
            //    StoreList(list, dl);
            //}
        }
        public override void StoreList(List<StoryInfo> stories, Downloader dl)
        {
            lock (ioLocker)
            {
                var path = GetBaseFolder(dl.HostUrl);
                Parallel.ForEach(stories, (s) =>
                {
                    s.JsonFileName = s.Url.SHA256() + ".json";
                });
                var json = JsonConvert.SerializeObject(stories);
                var file = Path.Combine(path, "stories.json");
                this.internalCache[file.SHA256()] = stories;
                try
                {
                    File.WriteAllText(file, json);
                }
                catch(Exception ex)
                {
                    Log("ERROR: can't save stories list ", ConsoleColor.Black, ConsoleColor.Red);
                }
            }
        }
        public override void StoreChapter(ChapterInfo chapter, Downloader dl)
        {
            chapter.JsonFileName = chapter.Url.SHA256() + ".json";
            var path = GetBaseFolder(dl.HostUrl);
            var json = JsonConvert.SerializeObject(chapter);
            var file = Path.Combine(path, chapter.JsonFileName);
            File.WriteAllText(file, json, Encoding.UTF8);
        }
    }
}
