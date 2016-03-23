using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ComicDownloader.Engines.DataExtractor
{
    public class DataExtractor
    {
        public object ioLocker = new object();
        public List<StoryInfo> allStories = new List<StoryInfo>();
        public virtual void UpdateIndex(List<StoryInfo> list)
        {

        }
        public virtual void Log(string message, ConsoleColor bg = ConsoleColor.Black, ConsoleColor color = ConsoleColor.White)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = bg;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();

            //MyLogger.Info(message);
        }
        public void FullExtract(string site="", bool userLocalCache= false, bool incremental = false)
        {
            var downloaders = Downloader.GetAllDownloaders(site);
            Parallel.ForEach(downloaders, new ParallelOptions() { MaxDegreeOfParallelism=8 }, (dl) =>
            {
                try
                {
                    ProcessOneDownloader(userLocalCache, dl, incremental);
                }
                catch(Exception ex) {
                    Log(ex.Message, ConsoleColor.Red);
                }
            });

            Console.WriteLine("FINISHED.");
        }

        private void ProcessOneDownloader(bool userLocalCache, Downloader dl, bool incremental =false)
        {
            Log("Start: " + dl.Name + "...");
            if (!IsProcessed(dl))
            {
                var storiesList = new List<StoryInfo>();
                var list = new List<StoryInfo>();

                if (incremental)
                {
                    storiesList = dl.GetListStories(false);
                    list = dl.GetLastestUpdates();
                    list.ForEach((s) =>
                    {
                        if (!storiesList.Exists(p => p.Url == s.Url))
                        {
                            storiesList.Add(s);
                        }
                    });
                    
                }
                else
                {
                    storiesList =  dl.GetListStories(!userLocalCache);
                    list = storiesList;

                }
                this.StoreList(storiesList, dl);
                list.ForEach((o) =>
                {
                    o.Source = dl.GetSiteDomain();
                });
                Log("Finished: " + dl.Name + " " + list.Count.ToString() + " found.", color: ConsoleColor.Green);
                this.UpdateIndex(list);

                Parallel.ForEach(list,
                    new ParallelOptions() { MaxDegreeOfParallelism = 8 },
                    (s) =>
                {
                    try
                    {
                        ProcessOneStory(dl, s, incremental);
    
                    } catch (Exception ex1) {
                        Log(ex1.Message, ConsoleColor.Red);
                    }

                });
            }
        }

        private void ProcessOneStory(Downloader dl, StoryInfo s, bool incremental = false)
        {
            if (!string.IsNullOrEmpty(s.JsonFileName) || incremental)
            {
                var info = dl.RequestInfo(s.Url);
                this.StoreStory(info, dl);
                Log("+-STORY: " + info.Name);

                Parallel.ForEach(info.Chapters,
                    new ParallelOptions() { MaxDegreeOfParallelism = 8 },
                    (c) =>
                {
                    try
                    {
                        Thread.Sleep(100);
                        ProcessOneChapter(dl, c, incremental);
                    }
                    catch (Exception ex) { }

                });
            }
        }

        private void ProcessOneChapter(Downloader dl, ChapterInfo c, bool incremental = false)
        {
            c.JsonFileName = c.Url.SHA256() + ".json";
            if (!this.IsStored(c, dl))
            {
                c.Pages = dl.GetPages(c.Url);
                this.StoreChapter(c, dl);
                Log("|--- CHAP: " + c.Name, ConsoleColor.Black, ConsoleColor.DarkGreen);
            }
            else
            {
                Log("|--- IGNORED CHAP: " + c.Name, ConsoleColor.Black, ConsoleColor.Magenta);
            }
        }

        public virtual bool IsStored(ChapterInfo c, Downloader dl)
        {
            
            return false;
        }

        public virtual List<StoryInfo> GetList(Downloader dl)
        {
            return null;
        }

        public virtual bool IsProcessed(Downloader dl)
        {
            return false;
        }
        public virtual void StoreList(List<StoryInfo> stories, Downloader dl)
        {
            var json = JsonConvert.SerializeObject(stories);

        }

        public virtual void StoreStory (StoryInfo story, Downloader dl)
        {

        }
        public virtual void StoreChapter(ChapterInfo chapter, Downloader dl)
        {

        }

        internal static void Run(Program.ApplicationArguments args)
        {
            if(args.Full)
            {
                var extractor = new JsonDataExtractor(args.OutputFolder);
                extractor.FullExtract(args.Sites, args.UseLocalCache);

            }
            if (args.Incremental)
            {
                var extractor = new JsonDataExtractor(args.OutputFolder);
                extractor.FullExtract(args.Sites, args.UseLocalCache, true);
            }
        }
    }
}
