using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain;
using Hash = BCrypt.Net.BCrypt;

namespace TestApp.Application.DTOs.Requests
{
    public class UserRegisterRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public static User ToEntity(UserRegisterRequest userModel)
        {
            return new User
            {
                Username = userModel.Username,
                Password = Hash.HashPassword(userModel.Password),
                Email = userModel.Email,
            };
        }
    }
}
