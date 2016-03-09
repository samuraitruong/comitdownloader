﻿using System;
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
