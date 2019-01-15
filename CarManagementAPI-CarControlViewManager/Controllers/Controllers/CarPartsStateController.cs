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
    public class CarPartsStateController : ControllerBase
    {
        private readonly ACService _acService;
        private readonly CarPartStateService _stateService;

        public CarPartsStateController(ACService acService, CarPartStateService Service)
        {
            _acService = acService;
            _stateService = Service;
        }

        /// <summary>
        /// Returns current state of all locks - doors, trunk, hood, roof, fuelcap
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("lockstate/{id}")]
        public IActionResult GetCarPartsState([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carPartsState = _stateService.GetLockState(id);

            if (carPartsState == null)
            {
                return NotFound(new { message = "Car with given ID not found" });
            }

            return Ok(carPartsState);
        }

        /// <summary>
        /// Updates state of locks
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lockState"></param>
        /// <returns></returns>
        [HttpPut("lockstate/{id}")]
        public IActionResult PutLockState([FromRoute] int id, [FromBody] CarPartStateDTO partsState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (partsState == null)
            {
                return NotFound(new { message = "Car with given ID not found" });
            }

            _stateService.PutLockState(id, partsState);

            return NoContent();
        }

    }
}