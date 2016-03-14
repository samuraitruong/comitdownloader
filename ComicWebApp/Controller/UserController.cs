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
    public class UserController : Microsoft.AspNet.Mvc.Controller
    {
        private IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public User Post([FromBody]User user)
        {
            return service.CreateUser(user);
        }

        [HttpPost("check")]
        public IActionResult CheckUser([FromBody]User model)
        {
            bool isExist = false;

            if(!string.IsNullOrEmpty(model.Username) && service.GetUserByUserName(model.Username) != null)
            {
                isExist = true;
            }

            if (!string.IsNullOrEmpty(model.Email) && service.GetUserByEmail(model.Email) != null)
            {
                isExist = true;
            }

            return new ObjectResult( new { exist = isExist });
        }

        [HttpPost("login")]
        public IActionResult PostLogin([FromBody]User user)
        {
            var logged = service.Login(user.Username, user.Password);
            if (logged != null)
            {
                return new ObjectResult(logged);
            }
            return HttpNotFound(new
            {
                code = "NOTFOUND",
                message = "username or password incorect"
            });
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
