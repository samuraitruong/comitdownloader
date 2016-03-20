using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicWeb.Core
{
    public interface IStoryInfo
    {
        List<ChapterInfo> Chapters { get; set; }
        string Name { get; set; }
        string AliasName { get; set; }
    }

    public interface IChapterInfo
    {
        string AliasName { get; set; }
    }
}
