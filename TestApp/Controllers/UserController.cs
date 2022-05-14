using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApp.Application;
using TestApp.Application.DTOs.Requests;
using TestApp.Domain;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService weatherService)
        {
            _userService = weatherService;
        }

        [HttpPost("register")]
        public IActionResult Post([FromBody] UserRegisterRequest userModel)
        {
            
            var responseMessage = _userService.RegisterUser(userModel);

            if (responseMessage != null)
                return BadRequest(new { message = responseMessage });

            return Ok();

        }
    }
}
