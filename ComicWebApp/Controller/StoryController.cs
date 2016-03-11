using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ComicWeb.Core;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ComicWebApp
{
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

        [HttpGet("detail/{name}")]
        public IStoryInfo GetStoryByName(string name)
        {
            return service.GetStoryByName(name);
        }

        [HttpGet("detail/{name}/{chapName}")]
        public IChapterInfo GetChap(string name, string chapName)
        {
            return service.GetChapInfo(name, chapName);
        }

        [HttpGet("genre/{name}/{page}")]
        public object GetGenreStories(string name, int page)
        {
            var paged = service.GetGenreStories(name, page);
            return new
            {
                Stories = paged.ToList(),
                PageCount = paged.PageCount
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
