using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using DatabaseConnection.DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using DatabaseConnection;
using DatabaseConnection.Entities;
using Microsoft.EntityFrameworkCore;
using Services.DTO;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarStateAlertController : Controller
    {
        private readonly CarStateAlertService _alertService;
        private readonly UserService _userService;
		private readonly LocalizationService _localizationService;
		private readonly EmergencyService _emergencyService;

		public CarStateAlertController(CarStateAlertService alertService, UserService userSevice, LocalizationService localizationService, EmergencyService emergencyService)
        {
            _alertService = alertService;
            _userService = userSevice;
			_localizationService = localizationService;
			_emergencyService = emergencyService;
        }


        [HttpGet("state")]
        public async Task<IActionResult> GetAlertState(
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

            var alertState = await _alertService.GetEmergencyState(carId);
            if (alertState == null)
            {
                return NotFound("Provided CarId doesn't exist.");
            }

            return Ok(alertState);
        }

        
        

        /// <summary>
        /// Changes emergency system state of car under carId
        /// </summary>
        /// <param name="userId">Unique user identification number</param>
        /// <param name="password">User password</param>
        /// <param name="emergencySystem">DTO</param>
        /// <returns></returns>
        [HttpPut("alertSystem/{userId}")]
        public async Task<IActionResult> UpdateAlertSystem(
            [FromQuery, Required] int userId,
            [FromQuery, Required] string password,
            [FromBody] AlertSystemDTO alertSystem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userService.Authorize(userId, password))
            {
                return Unauthorized();
            }


            if (!await _alertService.UpdateCarAlertState(alertSystem.CarId, alertSystem.State))
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
        public async Task<IActionResult> GetAlertNotification(
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

            return Ok(await _alertService.GetAlertNotification(carId));
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

            if (!await _emergencyService.UpdateEmergencyState(blockade.CarId, blockade.State))
            {
                return NotFound("Car not found");
            }

            return Ok();
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
            [FromBody] AlarmStateDTO alertState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _userService.Authorize(userId, password))
            {
                return Unauthorized();
            }

            if (!await _alertService.UpdateCarAlertState(alertState.CarId, alertState.State))
            {
                return NotFound("Car not found");
            }

            return Ok();
        }


        
        public async Task<string> GetEmergencyNotification(int carId) 
        {
            var actualLocation = await _localizationService.GetLocalization( carId );
            var blockedLocation = await _emergencyService.GetBlockedLocation( carId );
            var distance = _emergencyService.Distance(actualLocation.Item1, actualLocation.Item2, blockedLocation.Item1, blockedLocation.Item2, 'K');
            if (distance > 0.5)
            {
                return "ALARM! Someone may be stealing your car!";
            }

            return null;
        }
    }
}
