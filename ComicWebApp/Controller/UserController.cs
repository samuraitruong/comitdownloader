using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ComicWeb.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ComicWebApp
{

    public class AuthRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string AuthToken { get; set; }
    }

    [Route("api/[controller]")]
    public class UserController : Microsoft.AspNet.Mvc.Controller
    {
        private IUserService service;
        private TokenAuthOptions tokenOptions;

        public class AppUser : ClaimsPrincipal
        {
            public AppUser(ClaimsPrincipal principal)
                : base(principal)
            {
            }

            public string Username
            {
                get
                {
                    return this.FindFirst(ClaimTypes.Name).Value;
                }
            }

            public Guid UserID
            {
                get
                {
                    return Guid.Parse(this.FindFirst(ClaimTypes.Sid).Value);
                }
            }
        }
        public AppUser CurrentUser
        {
            get
            {
                return new AppUser(this.User as ClaimsPrincipal);
            }
        }

        public UserController(IUserService service, TokenAuthOptions tokenOptions)
        {
            this.tokenOptions = tokenOptions;
            this.service = service;
        }
        private string GetToken(User user, DateTime? expires)
        {
            var handler = new JwtSecurityTokenHandler()
            {
                TokenLifetimeInMinutes = 300
            };

            // Here, you should create or look up an identity for the user which is being authenticated.
            // For now, just creating a simple generic identity.

            ClaimsIdentity identity = new ClaimsIdentity(new GenericIdentity(user.Username, "TokenAuth1"),
                new[] {
                    new Claim(ClaimTypes.Sid, user.Id.ToString(), ClaimValueTypes.Sid),
                    new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email)
                });

            var securityToken = handler.CreateToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                signingCredentials: tokenOptions.SigningCredentials,
                subject: identity,
                expires: expires
                );
            return handler.WriteToken(securityToken);
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
            return "values...";
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

            if (!string.IsNullOrEmpty(model.Username) && service.GetUserByUserName(model.Username) != null)
            {
                isExist = true;
            }

            if (!string.IsNullOrEmpty(model.Email) && service.GetUserByEmail(model.Email) != null)
            {
                isExist = true;
            }

            return new ObjectResult(new { exist = isExist });
        }

        [HttpPost("login")]
        public IActionResult PostLogin([FromBody] AuthRequest user)
        {
            var currentUser = HttpContext.User;

            if (currentUser!= null && currentUser.Identity.IsAuthenticated)
            {
                var email = currentUser.Claims.First(p => p.Type == ClaimTypes.Email).Value;
                var restoreUser = service.GetUserByEmail(email);
                return new ObjectResult(new
                {
                    AuthToken = GetToken(restoreUser, DateTime.Now.AddMinutes(2)),
                    User = restoreUser
                });
            }
            else {
                var logged = service.Login(user.Username, user.Password);
                if (logged != null)
                {
                    var authenticated = new
                    {
                        AuthToken = GetToken(logged, DateTime.Now.AddMinutes(2)),
                        User = logged
                    };
                    return new ObjectResult(authenticated);
                }
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
