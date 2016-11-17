using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using reactchatAPI.Models;

namespace reactchatAPI.ViewModels
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string LastConnectionId { get; set; }

        public static explicit operator UserModel(User v)
        {
            UserModel userModel;
            return userModel = new UserModel()
            {
                UserId = v.UserId,
                UserName = v.UserName,
                Password = v.Password,
                Email = v.Email,
                Salt = v.Salt,
                LastConnectionId = v.LastConnectionId
            };
        }
    }
}