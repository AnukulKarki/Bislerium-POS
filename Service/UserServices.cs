using Bislerium.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bislerium.Data.Models;
using Bislerium.Data.Enums;

namespace Bislerium.Service
{
    public class UserServices
    {

        private List<User> _seedUsersList = new()
        {
            new User()
            {
                Password = "admin",
                Role = Role.Administrator,
            },

            new User()
            {
                Password = "staff",
                Role = Role.Staff
            }
        };

        public User loginCheck(String Password)
        {
            User user = _seedUsersList.FirstOrDefault(_user => _user.Password == Password);
            if (user == null)
            {
                throw new Exception("Invalid Password");

            }
            return user;

        }


    }
}
