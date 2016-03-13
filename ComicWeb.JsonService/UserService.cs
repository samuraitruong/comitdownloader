﻿using ComicWeb.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ComicWeb.JsonService
{
    public class UserService : IUserService
    {

        private static string dataFolder;
        private static List<User> cachedUser;
        public void SetDataFolder(string path)
        {
            dataFolder = path;
            Directory.CreateDirectory(dataFolder);
        }
        List<User> AllUsers()
        {
            if (cachedUser != null) return cachedUser;

            string file = Path.Combine(dataFolder, "users.json");
            if(File.Exists(file))
            {
                cachedUser = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(file));
            }

            cachedUser= new List<User>();
            return cachedUser;
        }
        public User CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            var list = AllUsers();
            list.Add(user);
            SaveToFile(list);
            return user;
        }

        private void SaveToFile(List<User> list)
        {
            cachedUser = list;
            var stringObj = JsonConvert.SerializeObject(list);
            string file = Path.Combine(dataFolder, "users.json");
            File.WriteAllText(file,stringObj);
        }
    }
}
