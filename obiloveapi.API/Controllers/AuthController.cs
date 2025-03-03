// obiloveapi.API/Controllers/AuthController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using obiloveapi.Application.DTOs.Auth;
using obiloveapi.Application.Interfaces;

namespace obiloveapi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.LoginAsync(request);
            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { Message = "Invalid credentials" });
            return Ok(new { Token = token });
        }
    }
}
