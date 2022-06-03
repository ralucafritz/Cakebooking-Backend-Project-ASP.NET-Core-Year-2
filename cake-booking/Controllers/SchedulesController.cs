using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cake_booking.BLL.Interfaces;
using cake_booking.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cake_booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleManager _scheduleManager;

        public SchedulesController(IScheduleManager scheduleManager)
        {
            _scheduleManager = scheduleManager;
        }

        ///////////////////////////////////////////////// CREATE ////////////////////////////////////////////////////////

        [HttpPost("AddClientAddress/studentId={studentId}")]

        public async Task<IActionResult> AddSchedule([FromRoute] int vendorId, [FromBody] ScheduleModel scheduleModel)
        {
            if (isValid(scheduleModel) != null)
            {
                return BadRequest(isValid(scheduleModel));
            }
            // passes validation

            await _scheduleManager.Create(vendorId, scheduleModel);

            return Ok($"Schedule added successfully for Vendor #{vendorId}.");
        }

        //////////////////////////////////////////////// GET ////////////////////////////////////////////////////////

        // needs formating
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetScheduleById([FromRoute] int id)
        {
            var scheduleModel = await _scheduleManager.GetById(id);

            return Ok(scheduleModel);
        }

        // needs formating

        [HttpGet("get-addresses")]
        public async Task<IActionResult> GetSchedules()
        {
            var scheduleModels = await _scheduleManager.GetAll();

            return Ok(scheduleModels);
        }

        //////////////////////////////////////////////// UPLOAD  ////////////////////////////////////////////////////////

        [HttpPut("update-schedule-{id}")]
        public async Task<IActionResult> UpdateSchedules([FromRoute] int id, [FromBody] ScheduleModel scheduleModel)
        {
            if (isValid(scheduleModel) != null)
            {
                return BadRequest(isValid(scheduleModel));
            }

            await _scheduleManager.Update(id, scheduleModel);
            return Ok($"Schedule #{id} has been updated.");
        }

        //////////////////////////////////////////////// DELETE ////////////////////////////////////////////////////////

        [HttpDelete("delete")] // ?id=1
        public async Task<IActionResult> DeleteSchedules([FromQuery] int id)
        {
            await _scheduleManager.Delete(id);

            return Ok($"Schedule #{id} has been deleted");
        }

        //////////////////////////////////////////////// EXTRA  ////////////////////////////////////////////////////////

        // validation method

        private string isValid(ScheduleModel scheduleModel)
        {
            string checkError = null;

            if (string.IsNullOrEmpty(scheduleModel.StartHour) || scheduleModel.StartHour.Length > 5) // 00:00 -> 5 characters
            {
                checkError = "StartHour is null or invald. Try again with the format: `12:34`.";
            }
            else if (string.IsNullOrEmpty(scheduleModel.EndHour) || scheduleModel.EndHour.Length > 5) // 00:00 -> 5 characters
            {
                checkError = "EndHour is null or invald. Try again with the format: `12:34`.";
            }

            return checkError;
        }

    }
}
