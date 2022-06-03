using cake_booking.BLL.Interfaces;
using cake_booking.DAL;
using cake_booking.DAL.Entities;
using cake_booking.DAL.Interfaces;
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
    public class ClientAdressesController : ControllerBase
    {
        private readonly IClientAddressManager _clientAddressManager;

        public ClientAdressesController(IClientAddressManager clientAddressManager)
        {
            _clientAddressManager = clientAddressManager;
        }

        [HttpPost("/add-client-address-for-clientId={clientId}")]

        ////////////////////////////////////////////// CREATE ////////////////////////////////////////////////////////

        public async Task<IActionResult> AddClientAddress([FromRoute] int clientId,[FromBody] ClientAddressModel clientAddressModel)
        {

            if (isValid(clientAddressModel) != null)
            {
                return BadRequest(isValid(clientAddressModel));
            }

            // passes validation

            await _clientAddressManager.Create(clientId, clientAddressModel);

            return Ok($"ClientAddress added successfully for Client #{clientId}.");
        }

        //////////////////////////////////////////////// GET ////////////////////////////////////////////////////////
        
        // needs formating
        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetAddressById([FromRoute] int id)
        {
            var clientAddressModel = await _clientAddressManager.GetById(id);

            return Ok(clientAddressModel);
        }

        // needs formating

        [HttpGet("get-addresses")]
        public async Task<IActionResult> GetAddresses()
        {
            var clientAddressModels = await _clientAddressManager.GetAll();

            return Ok(clientAddressModels);
        }

        //////////////////////////////////////////////// UPLOAD  ////////////////////////////////////////////////////////

        [HttpPut("update-address-{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ClientAddressModel clientAddressModel)
        {
            if (isValid(clientAddressModel) != null)
            {
                return BadRequest(isValid(clientAddressModel));
            }

            await _clientAddressManager.Update(id, clientAddressModel);
            return Ok($"ClientAddress #{id} has been updated.");
        }

        //////////////////////////////////////////////// DELETE ////////////////////////////////////////////////////////

        [HttpDelete("delete")] // ?id=1
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _clientAddressManager.Delete(id);

            return Ok($"ClientAddress #{id} has been deleted");
        }

        //////////////////////////////////////////////// EXTRA ////////////////////////////////////////////////////////

        // validation extra method
        private string isValid(ClientAddressModel clientAddressModel)
        {
            string checkError = null;
            if (string.IsNullOrEmpty(clientAddressModel.City))
            {
                checkError = "City field is null.";
            }
            else if (string.IsNullOrEmpty(clientAddressModel.Country))
            {
                checkError = "Country field is null.";
            }
            return checkError;
        }
    }
}
