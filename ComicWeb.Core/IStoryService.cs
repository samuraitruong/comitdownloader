using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicWeb.Core
{
    public interface IStoryService
    {
        IStoryInfo GetTopStory();
        List<IStoryInfo> GetTopStories(int number);
    }
}
