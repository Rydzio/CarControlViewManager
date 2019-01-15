using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DatabaseConnection.Entities;
using Services;
using System;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarService _carService;

        public CarController(CarService carService)
        {
            _carService = carService;
        }

        [HttpGet("{id}")]
        public ActionResult<Car> GetCar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = _carService.GetCar(id);
            if (car == null)
            {
                return NotFound(new { message = $"Car with id = {id} doesn't exists" });
            }

            return car;
        }

        #region Checkers
        /// <summary>
        /// Returns percentage level of brake fluids
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("control/brakefluids/{id}")]
        public ActionResult<float> CheckBrakeFluids([FromRoute]int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            float? fluidLevel = _carService.GetBrakeFluidLevel(id);
            if (fluidLevel == null)
            {
                return NotFound(new { message = $"Car with id = {id} doesn't exists" });
            }
            return Ok(fluidLevel.Value);
        }

        /// <summary>
        /// Return percentage level of battery level
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("control/battery/{id}")]
        public ActionResult<float> CheckBattery([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            float? batteryLevel = _carService.GetBatteryLevel(id);
            if (batteryLevel == null)
            {
                return NotFound(new { message = $"Car with id = {id} doesn't exists" });
            }
            return Ok(batteryLevel);
        }

        /// <summary>
        /// Returns percentage level of coolant
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("control/coolant/{id}")]
        public ActionResult<float> CheckCoolant([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            float? coolantLevel = _carService.GetCoolantLevel(id);
            if (coolantLevel == null)
            {
                return NotFound(new { message = $"Car with id = {id} doesn't exists" });
            }
            return Ok(coolantLevel);
        }

        /// <summary>
        /// Return percentage level of all tyres
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Key like FrontRight or RearLeft, value pressure level for tyre</returns>
        [HttpGet("control/tyres/{id}")]
        public ActionResult<Dictionary<string, float>> CheckTyres([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tyresLevels = _carService.GetTyresLevels(id);
            if (tyresLevels == null)
            {
                return NotFound(new { message = $"Car with id = {id} doesn't exists" });
            }
            
            return Ok(tyresLevels);
        }

        /// <summary>
        /// Return percentage level of motor oil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("control/motoroil/{id}")]
        public ActionResult<float> CheckMotorOil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            float? oilLevel = _carService.GetMotorOilLevel(id);
            if (oilLevel == null)
            {
                return NotFound(new { message = $"Car with id = {id} doesn't exists" });
            }
            return Ok(oilLevel);
        }

        /// <summary>
        /// Return percentage level of motor oil
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("control/windscreenwasher/{id}")]
        public ActionResult<float> CheckWindscreenWasher([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            float? car = _carService.GetWindscreenWasherLevel(id);
            if (car == null)
            {
                return NotFound(new { message = $"Car with id = {id} doesn't exists" });
            }
            return Ok(car);
        }

        /// <summary>
        /// Return previous service date
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("control/prevservicedate/{id}")]
        public ActionResult<DateTime> CheckPreviousServiceDate([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            DateTime? prevServiceDate = _carService.GetPreviousServiceDate(id);
            if (prevServiceDate == null)
            {
                return NotFound(new { message = $"Car with id = {id} doesn't exists" });
            }
            return Ok(prevServiceDate);
        }
        #endregion
    }
}