using Gofabackend.DTO;
using Gofabackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gofabackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AdminController(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// Get a list of all users with their roles.
        /// </summary>
        /// <returns>A list of users and their roles.</returns>
        [HttpGet("users")]
        [AllowAnonymous] // Allow unauthenticated users to access this method
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRoles = new List<UserRoleViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                userRoles.Add(new UserRoleViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.UserName,
                    Roles = roles
                });
            }

            return Ok(userRoles);
        }

        /// <summary>
        /// Delete all users from the database.
        /// </summary>
        /// <returns>A success or error message.</returns>
        [HttpDelete("delete-all-users")]
        [AllowAnonymous] // Allow unauthenticated users to access this method
        public async Task<IActionResult> DeleteAllUsers()
        {
            // Retrieve all users from the database
            var users = await _userManager.Users.ToListAsync();

            // Check if there are any users to delete
            if (users.Count == 0)
            {
                return Ok(new { Message = "No users found to delete." });
            }

            // Delete each user
            foreach (var user in users)
            {
                // Remove all roles for the user
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Any())
                {
                    var removeRolesResult = await _userManager.RemoveFromRolesAsync(user, roles);
                    if (!removeRolesResult.Succeeded)
                    {
                        Console.WriteLine($"Failed to remove roles for user {user.UserName}:");
                        foreach (var error in removeRolesResult.Errors)
                        {
                            Console.WriteLine(error.Description);
                        }
                        return BadRequest(removeRolesResult.Errors);
                    }
                }

                // Delete the user
                var deleteResult = await _userManager.DeleteAsync(user);
                if (!deleteResult.Succeeded)
                {
                    Console.WriteLine($"Failed to delete user {user.UserName}:");
                    foreach (var error in deleteResult.Errors)
                    {
                        Console.WriteLine(error.Description);
                    }
                    return BadRequest(deleteResult.Errors);
                }
                else
                {
                    Console.WriteLine($"User {user.UserName} deleted successfully.");
                }
            }

            return Ok(new { Message = "All users deleted successfully." });
        }



        [HttpDelete("delete-by-username/{username}")]
[AllowAnonymous] // Allow unauthenticated access (remove in production)
public async Task<IActionResult> DeleteUserByUsername(string username)
{
    Console.WriteLine($"Attempting to delete user with username: {username}");
    var user = await _userManager.FindByNameAsync(username);
    if (user == null)
    {
        return NotFound($"User with username '{username}' not found.");
    }

    var result = await _userManager.DeleteAsync(user);
    if (!result.Succeeded)
    {
        return BadRequest(result.Errors);
    }

    return Ok(new { Message = $"User '{username}' deleted successfully." });
}
}}