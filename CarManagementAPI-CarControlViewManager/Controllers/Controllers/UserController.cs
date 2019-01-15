using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Endpoint for user authorization
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// JSON with userId:int and isFirstLogin:bool, to enforce password changing
        /// during first login
        /// </returns>
        // GET - Example URL: /api/user/login?username=xyz&password=abc
        [HttpGet("login")]
        public async Task<IActionResult> Login([Required, FromQuery] string username,
            [Required, FromQuery] string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            var loginSuccess = await _userService.Login(username, password);
            if (loginSuccess.Item1 == null)
            {
                return NotFound($@"User with username:""{username}"" not found");
            }

            dictionary.Add("userId:", loginSuccess.Item1);
            dictionary.Add("isFirstLogIn:", loginSuccess.Item2);

            return Ok(dictionary);
        }
        /// <summary>
        /// Endpoint for changing password
        /// </summary>
        /// <param name="id">Unique user identification number</param>
        /// <param name="password">Old password</param>
        /// <param name="newPassword">New password with at least 6 characters</param>
        /// <returns> Returns 200 if change was successful</returns>
        // PUT - Example URL: /api/user?id=xyz&password=abc&newPassword=abcdef
        [HttpPut]
        public async Task<IActionResult> ChangePassword(
            [Required, FromQuery] int id,
            [Required, FromQuery] string password, 
            [Required, FromQuery, MinLength(6)] string newPassword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (! await _userService.Authorize( id, password))
            {
                return Unauthorized();
            }

            await _userService.UpdatePassword( id, newPassword);

            //TODO: use EmailService to notify user that password has been changed

            return Ok();
        }

        /// <summary>
        /// Endpoint for getting all cars belonging to user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// GET - Example URL /api/getcars/1
        [HttpGet("getcars/{userId}")]
        public async Task<IActionResult> GetCarsForUser([FromRoute] int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userCars = await _userService.GetUsersCarsAsync(userId);
            if (userCars == null)
            {
                return NotFound(new { message = $"None of the users matched id = {userId}" });
            }
            return Ok(userCars);
        }
    }
}