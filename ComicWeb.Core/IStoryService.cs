using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicWeb.Core
{
    public interface IStoryService
    {
        float RateStory(string name, StoryInfo.UserRate value);
        IStoryInfo GetTopStory();
        List<IStoryInfo> GetTopStories(int number);
        List<IStoryInfo> GetMostPopularTodayStories(int number);
        List<IStoryInfo> GetLatestUpdatedStories(int count);
        List<IStoryInfo> GetLatestPostedStories(int count);
        IStoryInfo GetStoryByName(string name);
        IChapterInfo GetChapInfo(string name, string chapName);
        IPagedList<IStoryInfo> GetGenreStories(string name, int page, int pageSize = 20);
        List<GenreInfo> GetGenres();

        void EnsureDBCache();
        IPagedList<IStoryInfo> GetListStories(string filter, int page, string v, int pageSize);
        IPagedList<IStoryInfo> SearchStories(string keyword, int page, int pageSize);
        void UpdateStory(StoryInfo story);
    }
}
