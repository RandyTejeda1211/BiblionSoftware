using Biblion.Application.Dtos.Auth;
using Biblion.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Biblion.Api.Controllers
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

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
            await _authService.RegisterAsync(registerUserDto);
            return Ok("Usuario registrado exitosamente");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginUserDto)
        {
            var user = await _authService.LoginAsync(loginUserDto);
            if (user == null)
                return Unauthorized("Los datos no concuerdan");

            return Ok();
        }
    }
}
