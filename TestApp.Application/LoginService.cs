using System.Linq;
using TestApp.Application.DTOs.Requests;
using TestApp.Application.DTOs.Responses;
using TestApp.Application.Exceptions;
using TestApp.Data;
using TestApp.Domain;

namespace TestApp.Application
{
    public class LoginService
    {
        private readonly UserService _userService;

        public LoginService(UserService userService)
        {     
            _userService = userService;
        }
        public LoginResponse LoginUser(LoginRequest loginModel)
        {
            var user = GetUserByCredentials(loginModel.Username, loginModel.Password);

            var response = new LoginResponse();
            if (user is null)
            {
                /*throw new NotFoundException("User doesn't exist");*/
                response = null;
                return response;
            }
 
            response.Email = user.Email;
            return response;
        }

        public bool IsValidPassword(string loginPassword, string dbPassword)
        {
            return (BCrypt.Net.BCrypt.Verify(loginPassword, dbPassword));
        }

        public User GetUserByCredentials(string username, string password)
        {
            var users = _userService.GetUsers();

            var result = (from user in users where user.Username.Equals(username) && IsValidPassword(password, user.Password) select user).ToList();

            if (result.Count() != 1)
                return null;
            
            return users[0];
        }
    }
}
