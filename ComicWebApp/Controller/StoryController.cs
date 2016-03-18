using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ComicWeb.Core;
using Microsoft.AspNet.Authorization;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ComicWebApp
{
    public class RateRequest{
        public string Name { get; set; }
        public int RateValue { get; set; }
    }
    [Route("api/[controller]")]
    public class StoryController : Microsoft.AspNet.Mvc.Controller
    {
        private IStoryService service;

        public StoryController(IStoryService service)
        {
            this.service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("Rate")]
        [Authorize("Bearer")]
        public IActionResult PostRateStory([FromBody]RateRequest rate)
        {

            var currentUser = HttpContext.User;
            if (currentUser != null && currentUser.Identity.IsAuthenticated)
            {
                var userId= new Guid(currentUser.Claims.First(p => p.Type == ClaimTypes.Sid).Value);
                return new ObjectResult(service.RateStory(rate.Name, new StoryInfo.UserRate()
                {
                    UserId = userId,
                    RateValue = rate.RateValue
                }));
                
            }
            return HttpBadRequest();

        }


        [HttpGet("detail/{name}")]
        public IStoryInfo GetStoryByName(string name)
        {
            var story= service.GetStoryByName(name) as StoryInfo;

            story.ViewCounts++;
            service.UpdateStory(story);
            return story;
        }
        [HttpGet("list/{filter}/{page}")]
        public object GetListStories(string filter, int page)
        {
            int pageSize = 25;
            var paged = service.GetListStories(filter, page, "", pageSize);
            foreach (StoryInfo item in paged)
            {
                var last = item.Chapters.FirstOrDefault();
                item.Chapters = new List<ChapterInfo>(); 
                if(last!= null)
                {
                    item.Chapters.Add(last);
                }
            }
            return new
            {
                Stories = paged.ToList(),
                PageCount = paged.PageCount,
                TotalItems = paged.TotalItemCount,
                PageSize = pageSize
            };
        }

        [HttpGet("search/{keyword}/{page}")]
        public object SearchStories(string keyword, int page)
        {
            int pageSize = 25;
            var paged = service.SearchStories(keyword, page,  pageSize);
            foreach (StoryInfo item in paged)
            {
                var last = item.Chapters.FirstOrDefault();
                item.Chapters = new List<ChapterInfo>();
                if (last != null)
                {
                    item.Chapters.Add(last);
                }
            }
            return new
            {
                Stories = paged.ToList(),
                PageCount = paged.PageCount,
                TotalItems = paged.TotalItemCount,
                PageSize = pageSize
            };
        }

        [HttpGet("genres")]
        public List<GenreInfo> GetGenres()
        {

            return service.GetGenres();
        }

        [HttpGet("detail/{name}/{chapName}")]
        public IChapterInfo GetChap(string name, string chapName)
        {
            return service.GetChapInfo(name, chapName);
        }

        [HttpGet("genre/{name}/{page}")]
        public object GetGenreStories(string name, int page)
        {
            int pageSize = 20;
            var paged = service.GetGenreStories(name, page, pageSize);
            return new
            {
                Stories = paged.ToList(),
                PageCount = paged.PageCount,
                TotalItems = paged.TotalItemCount,
                PageSize = pageSize
            };
        }


        [HttpGet("top")]
        public IStoryInfo GetTop()
        {
            return service.GetTopStory();
        }
        [HttpGet("top10")]
        public List<IStoryInfo> GetTop10()
        {
            return service.GetTopStories(10);
        }
        [HttpGet("updated")]
        public List<IStoryInfo> UpdatedStories()
        {
            return service.GetLatestUpdatedStories(30);
        }

        [HttpGet("latest")]
        public List<IStoryInfo> PostedStories()
        {
            return service.GetLatestPostedStories(30);
        }

        [HttpGet("toptoday")]
        public List<IStoryInfo> GetTopToday()
        {
            return service.GetMostPopularTodayStories(20);
        }



        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
