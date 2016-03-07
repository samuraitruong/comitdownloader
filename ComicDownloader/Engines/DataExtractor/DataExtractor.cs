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
        public void FullExtract(string site="", bool userLocalCache= false)
        {
            var downloaders = Downloader.GetAllDownloaders(site);
            Parallel.ForEach(downloaders, new ParallelOptions() { MaxDegreeOfParallelism=8 }, (dl) =>
            {
                try
                {
                    ProcessOneDownloader(userLocalCache, dl);
                }
                catch(Exception ex) { }
            });
        }

        private void ProcessOneDownloader(bool userLocalCache, Downloader dl)
        {
            Log("Start: " + dl.Name + "...");
            if (!IsProcessed(dl))
            {
                var list = dl.GetListStories(!userLocalCache);
                this.StoreList(list, dl);
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
                        ProcessOneStory(dl, s);
    
                    } catch (Exception ex1) { }

                });
            }
        }

        private void ProcessOneStory(Downloader dl, StoryInfo s)
        {
            if (!string.IsNullOrEmpty(s.JsonFileName))
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
                        ProcessOneChapter(dl, c);
                    }
                    catch (Exception ex) { }

                });
            }
        }

        private void ProcessOneChapter(Downloader dl, ChapterInfo c)
        {
            c.JsonFileName = c.Url.SHA256() + ".json";
            if (!this.IsStored(c, dl))
            {
                c.Pages = dl.GetPages(c.Url);
                this.StoreChapter(c, dl);
                Log("|--- CHAP: " + c.Name, ConsoleColor.Black, ConsoleColor.DarkGreen);
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
        }
    }
}
