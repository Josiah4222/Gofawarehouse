// using Gofabackend.DTO;
// using Gofabackend.Models;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;
// using System.Threading.Tasks;

// namespace Gofabackend.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     [Authorize]
//     public class ProfileController : ControllerBase
//     {
//         private readonly UserManager<User> _userManager;
//         private readonly SignInManager<User> _signInManager;

//         public ProfileController(UserManager<User> userManager, SignInManager<User> signInManager)
//         {
//             _userManager = userManager;
//             _signInManager = signInManager;
//         }

//         /// <summary>
//         /// Get the current user's profile information.
//         /// </summary>
//         /// <returns>User profile details.</returns>
//         [HttpGet("me")]
//         [Authorize]
//         public async Task<IActionResult> GetProfile()
//         {
//             var user = await _userManager.GetUserAsync(User);
//             if (user == null)
//             {
//                 return Unauthorized(new { Message = "User not found." });
//             }

//             return Ok(new
//             {
//                 Id = user.Id,
//                 FirstName = user.FirstName,
//                 LastName = user.LastName,
//                 Username = user.UserName,
//                 Email = user.Email
//             });
//         }

//         /// <summary>
//         /// Update the current user's profile information.
//         /// </summary>
//         /// <param name="updateProfileDto">The updated profile data transfer object.</param>
//         /// <returns>A response indicating success or failure.</returns>
//         [HttpPut("update-profile")]
//         public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto updateProfileDto)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             var user = await _userManager.GetUserAsync(User);
//             if (user == null)
//             {
//                 return Unauthorized(new { Message = "User not found." });
//             }

//             // Update user properties
//             user.FirstName = updateProfileDto.FirstName;
//             user.LastName = updateProfileDto.LastName;

//             var result = await _userManager.UpdateAsync(user);
//             if (!result.Succeeded)
//             {
//                 return BadRequest(result.Errors);
//             }

//             return Ok(new { Message = "Profile updated successfully." });
//         }

//         /// <summary>
//         /// Change the current user's password.
//         /// </summary>
//         /// <param name="changePasswordDto">The change password data transfer object.</param>
//         /// <returns>A response indicating success or failure.</returns>
//         [HttpPut("change-password")]
//         public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             var user = await _userManager.GetUserAsync(User);
//             if (user == null)
//             {
//                 return Unauthorized(new { Message = "User not found." });
//             }

//             // Validate the old password
//             var passwordChangeResult = await _userManager.ChangePasswordAsync(user, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
//             if (!passwordChangeResult.Succeeded)
//             {
//                 return BadRequest(passwordChangeResult.Errors);
//             }

//             // Sign in the user again after changing the password
//             await _signInManager.RefreshSignInAsync(user);

//             return Ok(new { Message = "Password changed successfully." });
//         }
//     }
// }