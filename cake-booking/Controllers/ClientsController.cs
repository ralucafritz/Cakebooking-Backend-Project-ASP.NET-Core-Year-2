using cake_booking.BLL.Interfaces;
using cake_booking.DAL;
using cake_booking.DAL.Entities;
using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cake_booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {

        private readonly IClientManager _clientManager;

        public ClientsController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }

        ///////////////////////////////////////////////// CREATE ////////////////////////////////////////////////////////

        [HttpPost("add-client")]

        public async Task<IActionResult> AddClient([FromBody] ClientModel clientModel)
        {
            if(isValid(clientModel)!=null)
            {
                return BadRequest(isValid(clientModel));
            }
            // passes validation

            await _clientManager.Create(clientModel);

            return Ok($"Client {clientModel.FirstName} {clientModel.LastName} added successfully.");
        }

        //////////////////////////////////////////////// GET ////////////////////////////////////////////////////////

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetClientById([FromRoute] int id)
        {
            var clientModel = await _clientManager.GetById(id);

            return Ok(clientModel);
        }

        [HttpGet("get-clients")]
        [Authorize("Admin")]
        public async Task<IActionResult> GetClients()
        {
            var clientModels = await _clientManager.GetAll();

            return Ok(clientModels);
        }

        [HttpGet("getClientAndCity")]
        public async Task<List<string>> GetClientAndCity()
        {
            return await _clientManager.GetClientAndCity();
        }

        [HttpGet("getClientsByGender")]
        public async Task<List<string>> GroupClientsByGender()
        {
            return await _clientManager.GroupClientsByGender();
        }


        //////////////////////////////////////////////// UPLOAD  ////////////////////////////////////////////////////////

        [HttpPut("update-client/{id}")] 

        public async Task<IActionResult> UpdateClient([FromRoute] int id, [FromBody] ClientModel clientModel)
        {
            if (isValid(clientModel) != null)
            {
                return BadRequest(isValid(clientModel));
            }

            await _clientManager.Update(id, clientModel);
            return Ok($"Client #{id} has been updated");
        }

        //////////////////////////////////////////////// DELETE ////////////////////////////////////////////////////////

        [HttpDelete("delete")] // ?id=1
        public async Task<IActionResult> DeleteClient([FromQuery] int id)
        {

            await _clientManager.Delete(id);

            return Ok($"Client #{id} has been deleted");
        }

        //////////////////////////////////////////////// EXTRA  ////////////////////////////////////////////////////////


        // check valid clientmodel method
        private string isValid(ClientModel clientModel)
        {
            string checkError = null;
            if (string.IsNullOrEmpty(clientModel.FirstName))
            {
                checkError = "First name is null.";
            }
            else if (string.IsNullOrEmpty(clientModel.LastName))
            {
                checkError = "Last name is null.";
            }
            else if (clientModel.Gender is not (char)'F'
                                        and not (char)'M')
            {
                checkError = "Invalid gender.";
            }
            else if (clientModel.PhoneNumber.Length != 10)
            {
                checkError = "The phone number must have 10 digits.";
            }
            else if (!clientModel.PhoneNumber.StartsWith("07"))
            {
                checkError = "The phone number is invalid. The phone number should start with the digits `07`.";
            }

            return checkError;
        }
    }
}
