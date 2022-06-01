using cake_booking.BLL.Interfaces;
using cake_booking.DAL;
using cake_booking.DAL.Entities;
using cake_booking.DAL.Interfaces;
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

        //private readonly AppDbContext _context;

        //public ClientAdressesController(AppDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IClientAddressManager _clientAddressManager;

        public ClientAdressesController(IClientAddressManager clientAddressManager)
        {
            _clientAddressManager = clientAddressManager;
        }

        //[HttpPost("AddClientAddress")]

        //////////////////////////////////////////////// CREATE ////////////////////////////////////////////////////////

        //public async Task<IActionResult> AddClientAddress([FromBody] ClientAddress clientAddress)
        //{
        //    await _clientAddressManager.ClientAddresses.AddAsync(clientAddress);
        //    await _clientAddressManager.SaveChangesAsync();

        //    return Ok("ClientAddress added successfully.");
        //}
    }
}
