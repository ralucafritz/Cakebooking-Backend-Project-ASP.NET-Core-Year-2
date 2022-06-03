using cake_booking.BLL.Interfaces;
using cake_booking.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cake_booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CakesController : ControllerBase
    {
        private readonly ICakeManager _cakeManager;

        public CakesController(ICakeManager cakeManager)
        {
            _cakeManager = cakeManager;
        }

        ///////////////////////////////////////////////// CREATE ////////////////////////////////////////////////////////

        [HttpPost("add-cake")]

        public async Task<IActionResult> AddCake([FromBody] CakeModel cakeModel)
        {
            if (isValid(cakeModel) != null)
            {
                return BadRequest(isValid(cakeModel));
            }

            // passes validation

            await _cakeManager.Create(cakeModel);

            return Ok("Cake added successfully.");

        }

        //////////////////////////////////////////////// GET ////////////////////////////////////////////////////////

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetCakeById([FromRoute] int id)
        {
            var cakeModel = await _cakeManager.GetById(id);

            return Ok(cakeModel);
        }


        [HttpGet("get-cakes")]
        public async Task<IActionResult> GetCakes()
        {
            var cakeModels = await _cakeManager.GetAll();

            return Ok(cakeModels);
        }

        //////////////////////////////////////////////// UPLOAD  ////////////////////////////////////////////////////////

        [HttpPut("update-cake/{id}")]

        public async Task<IActionResult> UpdateCake([FromRoute] int id, [FromBody] CakeModel cakeModel)
        {
            if (isValid(cakeModel) != null)
            {
                return BadRequest(isValid(cakeModel));
            }

            await _cakeManager.Update(id, cakeModel);
            return Ok($"Cake #{id} has been updated");
        }

        //////////////////////////////////////////////// DELETE ////////////////////////////////////////////////////////

        [HttpDelete("delete")] // ?id=1
        public async Task<IActionResult> DeleteCake([FromQuery] int id)
        {
            await _cakeManager.Delete(id);

            return Ok($"Cake #{id} has been deleted");
        }

        //////////////////////////////////////////////// EXTRA  ////////////////////////////////////////////////////////

        // validation method
        private string isValid(CakeModel cakeModel)
        {
            string checkError = null;
            if (string.IsNullOrEmpty(cakeModel.Name))
            {
                checkError = "Cake name is null.";
            }
            else if (string.IsNullOrEmpty(cakeModel.Description))
            {
                checkError ="Description is null.";
            }
            else if (cakeModel.Price == 0)
            {
                checkError = "Price cannot be equal to 0.";
            }

            return checkError;
        }

    }
}
