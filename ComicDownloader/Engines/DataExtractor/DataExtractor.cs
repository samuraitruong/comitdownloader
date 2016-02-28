using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.BackgroundColor = bg;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
            MyLogger.Info(message);
        }
        public void FullExtract()
        {
            var downloaders = Downloader.GetAllDownloaders();
            Parallel.ForEach(downloaders, (dl) =>
            {
                Log("Start: " + dl.Name + "...");
                if (!IsProcessed(dl))
                {
                    var list = dl.GetListStories(true);
                    this.StoreList(list, dl);
                    list.ForEach((o) =>
                    {
                        o.Source = dl.GetSiteDomain();
                    });
                    Log("Finished: " + dl.Name + " " + list.Count.ToString() +" found.", color: ConsoleColor.Green);
                    this.UpdateIndex(list);

                    Parallel.ForEach(list, (s) =>
                    {
                        if (!string.IsNullOrEmpty(s.JsonFileName))
                        {
                            var info = dl.RequestInfo(s.Url);
                            this.StoreStory(info, dl);
                            Log("Info: " + info.Name);

                            Parallel.ForEach(info.Chapters, (c) =>
                            {
                                c.JsonFileName = c.Url.SHA256() + ".json";
                                c.Pages = dl.GetPages(c.Url);
                                this.StoreChapter(c, dl);
                                Log("Store Chap: " + c.Name + "\t " + c.JsonFileName, ConsoleColor.Black, ConsoleColor.Blue);
                            });
                        }
                    });
                }
            });
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
                extractor.FullExtract();

            }
        }
    }
}
