// obiloveapi.API/Controllers/CitizenController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using obiloveapi.Application.DTOs;
using obiloveapi.Application.DTOs.Citizen;
using obiloveapi.Application.Interfaces;

namespace obiloveapi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitizenController : ControllerBase
    {
        private readonly ICitizenService _citizenService;
        public CitizenController(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        // Create new citizen profile
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CitizenCreateRequest request)
        {
            var result = await _citizenService.CreateCitizenAsync(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        // Get citizen details by id
        [HttpGet("{id:int}")]
        [Authorize] // Only authenticated users
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _citizenService.GetCitizenByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return NotFound(result);
        }

        // Update citizen details
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] CitizenUpdateRequest request)
        {
            var result = await _citizenService.UpdateCitizenAsync(request);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        // Delete citizen profile
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")] // Only admin users can delete
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _citizenService.DeleteCitizenAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
