using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCompany.BusinessLogic.Services.Contracts;
using UserCompany.Model.ViewModels;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto userDto)
        {
            if (_userService.UserExists(userDto.Login))
                return BadRequest("UserName Is Already Taken");
            if (!_userService.Register(userDto)) return BadRequest();
            return Ok("user was registered");
        }
    }
}
