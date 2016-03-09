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
    }
}
