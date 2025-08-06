using Business.Abstract;
using Business.Constants;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserForRegisterDto dto)
        {
            var token = _authService.Register(dto);

            if (token == null)
                return BadRequest();

            return Ok(new { token });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserForLoginDto dto)
        {
            var token = _authService.Login(dto);

            if (token == null)
                return Unauthorized();

            return Ok(new { token });
        }
    }
}

