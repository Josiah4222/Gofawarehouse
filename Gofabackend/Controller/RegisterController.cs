using Gofabackend.Data;
using Gofabackend.DTO;
using Gofabackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gofabackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public RegisterController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Registers a new user with the specified role.
        /// </summary>
        /// <param name="registerDto">The registration data transfer object.</param>
        /// <returns>A response indicating success or failure.</returns>
        /// <summary>
/// Registers a new user with the specified role.
/// </summary>
/// <param name="registerDto">The registration data transfer object.</param>
/// <returns>A response indicating success or failure.</returns>
[HttpPost("register")]
public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    // Check if the role exists
    var roleExists = await _roleManager.RoleExistsAsync(registerDto.Role);
    if (!roleExists)
    {
        return BadRequest($"Role '{registerDto.Role}' does not exist.");
    }

    // Create a new user
    var user = new User
    {
        Id = Guid.NewGuid().ToString(),
        UserName = registerDto.Username,
        Email = registerDto.Username, // Assuming email and username are the same
        FirstName = registerDto.FirstName,
        LastName = registerDto.LastName
    };

    // Create the user in the database
    var result = await _userManager.CreateAsync(user, registerDto.Password);
    if (!result.Succeeded)
    {
        return BadRequest(result.Errors);
    }

    // Assign the role to the user
    var addRoleResult = await _userManager.AddToRoleAsync(user, registerDto.Role);
    if (!addRoleResult.Succeeded)
    {
        return BadRequest(addRoleResult.Errors);
    }

    return Ok(new { Message = "User registered successfully." });
}}}