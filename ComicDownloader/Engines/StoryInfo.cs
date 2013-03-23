﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComicDownloader.Engines
{
    public class ChapterInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Page { get; set; }

        public int ChapId { get; set; }
    }
    public class StoryInfo
    {
        public string Name { get; set; }
        public string AltName { get; set; }
        public string Author { get; set; }
        public string Categories { get; set; }

        public string Url { get; set; }
        public List<ChapterInfo> Chapters { get; set; }
        public int ChapterCount { get; set; }


        public string UrlSegment { get; set; }

        public StoryInfo()
        {
            Chapters = new List<ChapterInfo>();
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
