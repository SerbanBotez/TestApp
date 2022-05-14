using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestApp.Application;
using TestApp.Application.DTOs.Requests;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService  _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost("login")]
        public IActionResult Post([FromBody] LoginRequest loginModel)
        {
            var response = _loginService.LoginUser(loginModel);

            if(response == null)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok();
        }
    }
}
