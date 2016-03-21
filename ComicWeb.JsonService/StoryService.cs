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
        public IPagedList<IStoryInfo> SearchStories(string keyword, int page, int pageSize)
        {
            var list = DataManager.AllStories(true);
            var results = list.Where(p => p.Name.ToLower().Contains(keyword.ToLower()));
            return results.ToPagedList(page-1, pageSize);
        }
        public IPagedList<IStoryInfo> GetListStories(string filter, int page, string v, int pageSize)
        {
            
            var list = DataManager.AllStories(true);
            var cloned = list;
            if(filter.ToLower() !="all")
            {
                cloned= cloned.Where(p => p.Group == filter).ToList().Clone();
            }

            return cloned.ToPagedList(page-1, pageSize);
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

            list.Sort((x, y) =>
            {
                if (x == null || y == null) return 1;
                return y.Chapters.Count - x.Chapters.Count;
            });
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
            return DataManager.AllStories(true).FirstOrDefault(p => p.Name.ToLower() == name.ToLower() || p.AliasName.ToLower() == name.ToLower()) ;
        }

        public IChapterInfo GetChapInfo(string name, string chapName)
        {
            var story = GetStoryByName(name);
            var chap = ((StoryInfo)story).Chapters.FirstOrDefault(p => p.Name.ToLower() == chapName.ToLower() || p.AliasName.ToLower() == chapName.ToLower());
            var fullInfo = DataManager.LoadChapter(chap.JsonFileName);
            fullInfo.Story = story;
            return fullInfo;
        }

        public IPagedList<IStoryInfo> GetGenreStories(string name, int page, int pageSize = 20, SortTypes sortType = SortTypes.Name)
        {
            var all = DataManager.GenreStories(name);
            all.Sort((x, y) =>
            {
                if (x == null || y == null) return 0;
                if (sortType == SortTypes.Chapters)
                {
                    return y.Chapters.Count - x.Chapters.Count;
                }

                return string.CompareOrdinal(x.Name, y.Name);
            });
            return all.ToPagedList(page-1, pageSize);
        }

        public void EnsureDBCache()
        {
            DataManager.EnsureDBCache();
        }

        public float RateStory(string name, StoryInfo.UserRate value)
        {
            var story = GetStoryByName(name) as StoryInfo; 
            var index =story.RatingUsers.FindIndex(p => p.UserId == value.UserId);

            if (index >= 0)
            {
                story.RatingUsers[index] = value;
            }
            else
            {
                story.RatingUsers.Add(value);
            }
            var avg = story.RatingUsers.Average(p => p.RateValue);
            story.Rating = (float)avg;
            DataManager.Update(story);
            return story.Rating;
        }
        public void UpdateStory(StoryInfo story)
        {
            DataManager.Update(story);
        }
    }

}
