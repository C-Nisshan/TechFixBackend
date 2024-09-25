using Microsoft.AspNetCore.Mvc;
using TechFixBackend.Models;
using TechFixBackend.Services;
using System;
using System.Threading.Tasks;
using TechFixBackend.DTOs;

namespace TechFixBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound(); // 404 Not Found
                }
                return Ok(user); // 200 OK
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // 400 Bad Request
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error"); // 500 Internal Server Error
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDTO userDto)
        {
            // Ensure the ID in the URL matches the user's ID in the DTO if necessary
            if (userDto == null)
            {
                return BadRequest("Invalid user data.");
            }

            try
            {
                await _userService.UpdateUserAsync(id, userDto);
                return NoContent(); // 204 No Content on successful update
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message); // 404 Not Found if user does not exist
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error"); // 500 Internal Server Error for unexpected errors
            }
        }

        // Other user management endpoints...
    }
}
