using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComicWeb.Core
{
    public class User
    {
        public Guid Id
        {
            get; set;
        }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Sex { get; set; }
        public string Phone
        {
            get; set;


        }
    }
    public interface IUserService
    {
            User CreateUser(User user);
        void SetDataFolder(string path);
    }
}
