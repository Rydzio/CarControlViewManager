using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : Controller
    {
        private LocalizationService _localizationService;
        private UserService _userService;

        public LocalizationController(LocalizationService localizationService, UserService userService)
        {
            _userService = userService;
            _localizationService = localizationService;
        }

        /// <summary>
        /// Returns current localization of a car
        /// </summary>
        /// <param name="userId">Unique identification number of user</param>
        /// <param name="password">User's password</param>
        /// <param name="carId">Unique identification number of car</param>
        /// <returns>x and y coordinates</returns>
        // GET Example URL: /api/localization?userId=0&password=hash&carId=0
        [HttpGet]
        public async Task<IActionResult> Localization(
            [Required, FromQuery] int userId,
            [Required, FromQuery] string password,
            [Required, FromQuery] int carId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if ( !await _userService.Authorize( userId, password ) )
            {
                return Unauthorized();
            }

            var location = await _localizationService.GetLocalization(carId);
            if (location == null)
            {
                return NotFound("Provided CarId doesn't exist.");
            }

            return Ok($"x: {location.Item1}, y: {location.Item2}");
        }
    }
}