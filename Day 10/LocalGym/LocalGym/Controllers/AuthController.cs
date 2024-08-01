using Microsoft.AspNetCore.Mvc;

namespace LocalGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            // Validate the user credentials (this is just a simple example, use a real user store)
            if (login.Username == "test" && login.Password == "test")
            {
                var token = _tokenService.GenerateToken(login.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
