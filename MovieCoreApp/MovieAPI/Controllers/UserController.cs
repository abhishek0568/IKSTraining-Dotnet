using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Business.Services;
using MovieApp.Entity;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // HTTPGET, HTTPPUT restapi w/o view support(restful api or stateless)

    // from api controller layer we will acess the business layer
    public class UserController : ControllerBase
    {
        UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("SelectUsers")]
        public IActionResult SelectUsers()
        {
            return Ok(_userService.SelectUsers());
        }

        [HttpPost("Register")]
        public IActionResult Register(UserModel userModel)
        {
            return Ok(_userService.Register(userModel));
            
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            return Ok(_userService.DeleteUser(userId));

        }

        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(UserModel userModel)
        {
            return Ok(_userService.UpdateUser(userModel));

        }


        [HttpPost("Login")]
        public IActionResult Login([FromBody ]UserModel userModel)
        {
            return Ok(_userService.Login(userModel));

        }

        [HttpGet("SelectUserById")]
        public IActionResult SelectUserById(int userId)
        {
            return Ok(_userService.SelectUserById(userId));
        }
    }
}
