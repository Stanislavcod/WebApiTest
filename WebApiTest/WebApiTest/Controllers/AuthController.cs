using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCompany.BusinessLogic.Services.Contracts;
using UserCompany.Model.ModelsDto;
using UserCompany.Model.ViewModels;

namespace WebApiTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Post([FromBody] LoginDto loginDto)
        {
            return Ok(_authService.Token(loginDto));
        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult Put([FromBody] RefreshTokenDto model)
        {
            return Ok(_authService.Refresh(model));
        }
    }
}
