using ComicWeb.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicWeb.JsonService
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class StoryService   : IStoryService
    {
        public StoryService()
        {
        }
        public IPagedList<IStoryInfo> GetListStories(string filter, int page, string v, int pageSize = 25)
        {
            
            var list = DataManager.AllStories(true);
            var cloned = list.Clone();
            if(filter !="all")
            {
                list.Where(p => p.Group == filter).ToList();
            }

            return null;

        }
        public List<GenreInfo> GetGenres()
        {
            return DataManager.AllGenres(false);
            return null;
        }
        public List<IStoryInfo> GetLatestUpdatedStories(int count)
        {
            IEnumerable<IStoryInfo> list = GetRandomStoriesList(count);

            return list.ToList(); ;
        }

        public List<IStoryInfo> GetMostPopularTodayStories(int number = 20)
        {
            IEnumerable<IStoryInfo> list = GetRandomStoriesList(number);

            return list.ToList(); ;
        }

        private static IEnumerable<IStoryInfo> GetRandomStoriesList(int number)
        {
            Random random = new Random();
            var stories = DataManager.AllStories(true);

            var list = Enumerable.Range(0, number).Select(p =>
            {
                int index = random.Next(1, stories.Count);
                return (IStoryInfo)stories.ElementAt(index);
            });
            return list;
        }

        public List<IStoryInfo> GetTopStories(int number)
        {
            var list = DataManager.AllStories(true);

            return list.Take(number).Select(p => (IStoryInfo)p).ToList();
        }

        public IStoryInfo GetTopStory()
        {
            var list = DataManager.AllStories(true);
            var index = (new Random()).Next(list.Count);
            var info = list.ElementAt(index);
            return DataManager.LoadStory(info.JsonFileName);
        }

        public List<IStoryInfo> GetLatestPostedStories(int count)
        {
            IEnumerable<IStoryInfo> list = GetRandomStoriesList(count);

            return list.ToList();
        }

        public IStoryInfo GetStoryByName(string name)
        {
            return DataManager.AllStories(true).FirstOrDefault(p => p.Name.ToLower() == name.ToLower()) ;
        }

        public IChapterInfo GetChapInfo(string name, string chapName)
        {
            var story = GetStoryByName(name);
            var chap = ((StoryInfo)story).Chapters.FirstOrDefault(p => p.Name.ToLower() == chapName.ToLower());
            var fullInfo = DataManager.LoadChapter(chap.JsonFileName);
            fullInfo.Story = story;
            return fullInfo;
        }

        public IPagedList<IStoryInfo> GetGenreStories(string name, int page, int pageSize = 20)
        {
            var all = DataManager.GenreStories(name);
            return all.ToPagedList(page, pageSize);
        }

        public void EnsureDBCache()
        {
            DataManager.EnsureDBCache();
        }
    }
}
