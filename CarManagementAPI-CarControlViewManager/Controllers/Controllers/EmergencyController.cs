using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DatabaseConnection.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergencyController : Controller
    {
        private readonly EmergencyService _emergencyService;
        private readonly UserService _userService;

        public EmergencyController(EmergencyService emergencyService, UserService userSevice)
        {
            _emergencyService = emergencyService;
            _userService = userSevice;
        }

        /// <summary>
        /// Returns all emergency state information
        /// </summary>
        /// <param name="userId">Unique user identification number</param>
        /// <param name="password">User password</param>
        /// <param name="carId">Unique car identification number</param>
        /// <returns>Json with EmergencyStateDTO information</returns>
        // GET /api/emergency/state
        [HttpGet("state")]
        public async Task<IActionResult> GetEmergencyState(
            [FromQuery, Required] int userId,
            [FromQuery, Required] string password,
            [FromQuery, Required] int carId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userService.Authorize(userId, password))
            {
                return Unauthorized();
            }

            var emergencyState = await _emergencyService.GetEmergencyState(carId);
            if (emergencyState == null)
            {
                return NotFound("Provided CarId doesn't exist.");
            }

            return Ok(emergencyState);
        }

        /// <summary>
        /// Changes alarm state of car under carId
        /// </summary>
        /// <param name="userId">Unique user identification number</param>
        /// <param name="password">User password</param>
        /// <param name="alarmState">New alarm state DTO</param>
        /// <returns></returns>
        [HttpPut("alarm")]
        public async Task<IActionResult> UpdateAlarmState(
            [FromQuery, Required] int userId,
            [FromQuery, Required] string password,
            [FromBody] AlarmStateDTO alarmState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userService.Authorize(userId, password))
            {
                return Unauthorized();
            }

            if (!await _emergencyService.UpdateAlarmState(alarmState.CarId, alarmState.State))
            {
                return NotFound("Car not found");
            }

            return Ok();
        }

        /// <summary>
        /// Changes emergency system state of car under carId
        /// </summary>
        /// <param name="userId">Unique user identification number</param>
        /// <param name="password">User password</param>
        /// <param name="emergencySystem">DTO</param>
        /// <returns></returns>
        [HttpPut("emergencySystem/{userId}")]
        public async Task<IActionResult> UpdateEmergencySystem(
            [FromQuery, Required] int userId,
            [FromQuery, Required] string password,
            [FromBody] EmergencySystemDTO emergencySystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userService.Authorize(userId, password))
            {
                return Unauthorized();
            }


            if (!await _emergencyService.UpdateEmergencyState(emergencySystem.CarId, emergencySystem.State))
            {
                return NotFound("Car not found");
            }

            return Ok();
        }

        /// <summary>
        /// Changes blockade state of car under carId
        /// </summary>
        /// <param name="userId">Unique user identification number</param>
        /// <param name="password">User password</param>
        /// <param name="blockade">DTO for blockade state</param>
        /// <returns></returns>
        [HttpPut("blockade/{userId}")]
        public async Task<IActionResult> UpdateBlockadeState(
            [FromQuery, Required] int userId,
            [FromQuery, Required] string password,
            [FromBody] BlockadeDTO blockade)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userService.Authorize(userId, password))
            {
                return Unauthorized();
            }

            if (!await _emergencyService.UpdateEmergencyState( blockade.CarId, blockade.State) )
            {
                return NotFound("Car not found");
            }

            return Ok();
        }

        /// <summary>
        /// Gets emergency notification
        /// </summary>
        /// <param name="userId">Unique user identification number</param>
        /// <param name="password">User password</param>
        /// <param name="carId">Unique car identification number</param>
        /// <returns>notifications</returns>
        [HttpGet("notification")]
        public async Task<IActionResult> GetEmergencyNotification(
            [FromQuery, Required] int userId,
            [FromQuery, Required] string password,
            [FromQuery, Required] int carId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userService.Authorize(userId, password))
            {
                return Unauthorized();
            }

            return Ok(await _emergencyService.GetEmergencyNotification(carId));
        }
    }
}