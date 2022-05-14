using System;
using System.Collections.Generic;
using System.Linq;
using TestApp.Application.DTOs.Requests;
using TestApp.Data;
using TestApp.Domain;

namespace TestApp.Application
{
    public class UserService
    {
        private readonly TestAppContext _dbContext;

        public UserService(TestAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool hasValidCredentials(UserRegisterRequest userModel)
        {
            return true;
        }

        public bool hasNewPassword(string password)
        {
            return true;
        }

        public string RegisterUser(UserRegisterRequest userModel)
        {
            var user = UserRegisterRequest.ToEntity(userModel);

            if(!hasValidCredentials(userModel))
                return "Invalid Username or Password";

            if (!hasNewPassword(userModel.Password))
                return "The password has been already used before";

            _dbContext.Add(user);
            _dbContext.SaveChanges();

            return null;
        }

        public List<User> GetUsers()
        {
            return _dbContext.Users.ToList();
        }
    }
}
