using cake_booking.DAL;
using cake_booking.DAL.Entities;
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
        private readonly AppDbContext _context;

        public ClientAdressesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("AddClientAddress")]

        //////////////////////////////////////////////// CREATE ////////////////////////////////////////////////////////

        public async Task<IActionResult> AddClientAddress([FromBody] ClientAddress clientAddress)
        {
            if (string.IsNullOrEmpty(clientAddress.City))
            {
                return BadRequest("City is null");
            }
            if (string.IsNullOrEmpty(clientAddress.Country))
            {
                return BadRequest("Country is null");
            }

            await _context.ClientAddresses.AddAsync(clientAddress);
            await _context.SaveChangesAsync();

            return Ok("ClientAddress added successfully.");
        }
    }
}
