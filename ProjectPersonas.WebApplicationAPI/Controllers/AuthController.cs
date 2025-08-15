using Microsoft.AspNetCore.Mvc;
using ProjectPersonas.Application.DTOs;
using ProjectPersonas.Application.Services;

namespace ProjectPersonas.WebApplicationAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AuthResultDto>> Register([FromBody] RegisterDto request)
        {
            if (request == null)
            {
                return BadRequest("Invalid registration data.");
            }
            try
            {
                var result = await _authService.RegisterAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResultDto>> Login([FromBody] LoginDto request)
        {
            if (request == null)
            {
                return BadRequest("Invalid login data.");
            }
            try
            {
                var result = await _authService.LoginAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
    }
}
