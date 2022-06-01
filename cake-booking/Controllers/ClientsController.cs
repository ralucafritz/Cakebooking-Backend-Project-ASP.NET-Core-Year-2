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
            else if(checkInvalidNumber(client.PhoneNumber)!=null)
            {
                return BadRequest(checkInvalidNumber(client.PhoneNumber));
            }

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return Ok("Client added successfully");
        }

        // check valid phonenumber
        private string checkInvalidNumber(string phoneNumber)
        {
            string checkError = null;
            if (phoneNumber.Length != 10)
            
                checkError = "The phone number must have 10 digits.";
     
            if (!phoneNumber.StartsWith("07"))
         
                checkError = "The phone number is invalid. The phone number should start with the digits `07`.";

            return checkError;
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
