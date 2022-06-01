using cake_booking.DAL;
using cake_booking.DAL.Entities;
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
        private readonly AppDbContext _context;

        public ClientsController(AppDbContext context)
        {
            _context = context;
        }

///////////////////////////////////////////////// CREATE ////////////////////////////////////////////////////////

        [HttpPost("AddClient")]
    
        public async Task<IActionResult> AddClient([FromBody] Client client)
        {
            if(string.IsNullOrEmpty(client.FirstName))
            {
                return BadRequest("First name is null.");
            }
            else if(string.IsNullOrEmpty(client.LastName))
            {
                return BadRequest("Last name is null.");
            }

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return Ok("Client added successfully");
        }

//////////////////////////////////////////////// GET ////////////////////////////////////////////////////////

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetClient([FromRoute] int id)
        {
            var client = await _context.Clients
                .Where(x => x.Id == id)
                .Include(x => x.ClientAddress)
                //.Include(x => x.ClientInformation)
                .FirstOrDefaultAsync();

            return Ok(client);
        }
    }
}
