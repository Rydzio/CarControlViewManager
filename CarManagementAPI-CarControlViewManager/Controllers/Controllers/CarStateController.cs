using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DatabaseConnection;
using DatabaseConnection.Entities;
using Services;
using DatabaseConnection.DTO;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarStateController : ControllerBase
    {
        private readonly ACService _acService;
        private readonly LockService _lockService;

        public CarStateController(ACService acService, LockService lockService)
        {
            _acService = acService;
            _lockService = lockService;
        }

        #region AC
        /// <summary>
        /// Returns current state of AC - inside temp, outside temp, ac temp, level of chair heater and whether ac is on/off
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ac/{id}")]
        public IActionResult GetACState([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carState = _acService.GetACState(id);

            if (carState == null)
            {
                return NotFound(new { message = "Car with given ID not found" });
            }

            return Ok(carState);
        }

        /// <summary>
        /// Updates state of AC for car with given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="acState"></param>
        /// <returns></returns>
        [HttpPut("ac/{id}")]
        public IActionResult PutACState([FromRoute] int id, [FromBody] ACStateDTO acState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(acState == null)
            {
                return NotFound(new { message = "Car with given ID not found" });
            }

            _acService.PutACState(id, acState);

            return NoContent();
        }

        /// <summary>
        /// Turns on/off the AC
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("ac/toggleac/{id}")]
        public IActionResult ToggleAC([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_acService.ToggleAC(id))
            {
                return NotFound(new { message = "Car with given ID not found" });
            }

            return NoContent();
        }

        /// <summary>
        /// Changes level of chair heater
        /// </summary>
        /// <param name="id"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        [HttpPut("ac/hotchairlevel/{id}")]
        public IActionResult ChangeHotChairLevel([FromRoute] int id, [FromBody] HotChairLevel level)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_acService.ChangeHotChairLevel(id, level))
            {
                return NotFound(new { message = "Car with given ID not found" });
            }

            return NoContent();
        }

        /// <summary>
        /// Changes the temperature of AC
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newTemp"></param>
        /// <returns></returns>
        [HttpPut("ac/actemp/{id}")]        
        public IActionResult ChangeACTemp([FromRoute] int id, [FromBody] float newTemp)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_acService.ChangeACTemp(id, newTemp))
            {
                return NotFound(new { message = "Car with given ID not found" });
            }

            return NoContent();
        }
        #endregion

        #region Lock

        /// <summary>
        /// Returns current state of all locks - doors, trunk, hood, roof, fuel filler
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("lockstate/{id}")]
        public IActionResult GetLockState([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lockState = _lockService.GetLockState(id);

            if (lockState == null)
            {
                return NotFound(new { message = "Car with given ID not found" });
            }

            return Ok(lockState);
        }

        /// <summary>
        /// Updates state of locks
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lockState"></param>
        /// <returns></returns>
        [HttpPut("lockstate/{id}")]
        public IActionResult PutLockState([FromRoute] int id, [FromBody] LockStateDTO lockState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (lockState == null)
            {
                return NotFound(new { message = "Car with given ID not found" });
            }

            _lockService.PutLockState(id, lockState);

            return NoContent();
        }
        #endregion

    }
}