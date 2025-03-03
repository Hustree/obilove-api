// obiloveapi.API/Controllers/UserController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using obiloveapi.Application.DTOs;
using obiloveapi.Application.DTOs.User;
using obiloveapi.Application.Interfaces;

namespace obiloveapi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // Create new user profile
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] UserCreateRequest request)
        {
            var result = await _userService.CreateUserAsync(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        // Get user details by id
        [HttpGet("{id:int}")]
        [Authorize] // Only authenticated users
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return NotFound(result);
        }

        // Update user details
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UserUpdateRequest request)
        {
            var result = await _userService.UpdateUserAsync(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        // Delete user profile
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")] // Only admin users can delete
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
