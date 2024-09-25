using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechFixBackend.Services;
using TechFixBackend.Models;

namespace TechFixBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationDto registrationDto)
        {
            try
            {
                var user = await _authService.RegisterUserAsync(registrationDto.Username, registrationDto.Password, registrationDto.Role);
                return Ok(user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            try
            {
                var user = await _authService.AuthenticateUserAsync(loginDto.Username, loginDto.Password);
                return Ok(user);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }

    public class UserRegistrationDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // e.g., "admin", "staff"
    }

    public class UserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
