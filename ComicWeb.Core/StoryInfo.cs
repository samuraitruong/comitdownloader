﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ComicWeb.Core
{
    public class ChapterInfo : InfoObj, IChapterInfo
    {
        public string Downloader { get; set; }
        public string Name { get; set; }
        public string AliasName{ get; set; }
        public string Url { get; set; }
        public string Page { get; set; }

        public DateTime Updated { get; set; }
        public Guid UniqueIdentify { get; set; }

        public int ChapId { get; set; }
        public List<string> Pages { get; set; }
        public List<string> DownloadedPages { get; set; }

        public int PageCount { get; set; }

        public float Rating { get; set; }

        public int ViewCounts { get; set; }

        public ChapterInfo() {
            UniqueIdentify = new Guid();
            DownloadedPages = new List<string>();
        }

        public DateTime LastModified { get; set; }
        public IStoryInfo Story { get; set; }
    }
    public class StoryInfo : InfoObj, IStoryInfo
    {
        public class UserRate
        {
            public Guid  UserId { get; set; }
            public int RateValue { get; set; }
        }
        public string Group
        {
            get
            {
                //return "A";
                var firstChar = Name.Trim().FirstOrDefault();
                if (char.IsLetterOrDigit(firstChar))
                {
                    return firstChar.ToString().ToUpper();
                }

                return "#";
            }
        }
        public List<UserRate> RatingUsers { get; set; }


        public string Name { get; set; }
        public string AliasName { get; set; }
        public string AltName { get; set; }
        public string Author { get; set; }
        public List<string> Categories { get; set; }

        public string CategoriesAsString
        {
            get
            {
                if (Categories == null) return "Unknown";
                return string.Join("; ", this.Categories);
            }
        }
        //json file
        public string Url { get; set; }
        public List<ChapterInfo> Chapters { get; set; }
        public int ChapterCount { get; set; }


        public string UrlSegment { get; set; }
        public string Summary { get; set; }
        public string CoverUrl { get; set; }
        public string Source { get; set; }
        public float Rating { get; set; }
        public int ViewCounts { get; set; }

        public DateTime Updated
        {
            get;

            set;
        }

        public StoryInfo()
        {
            Chapters = new List<ChapterInfo>();
            RatingUsers = new List<UserRate>();
            ViewCounts = 0;
            
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public class GenreInfo{
        public int Id { get; set; }
        public string Name { get; set; }

        public int StoriesCount { get; set; }
        public List<IStoryInfo> Stories { get; set; }

    }
    
}
