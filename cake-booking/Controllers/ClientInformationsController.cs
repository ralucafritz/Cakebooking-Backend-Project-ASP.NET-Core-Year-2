using cake_booking.DAL;
using cake_booking.DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace cake_booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientInformationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientInformationController(AppDbContext context)
        {
            _context = context;
        }

        //////////////////////////////////////////////// CREATE ////////////////////////////////////////////////////////

        [HttpPost("AddClientInformation")]

        public async Task<IActionResult> AddClientInformation([FromBody] ClientInformation clientInformation)
        {
            //if (string.IsNullOrEmpty(clientInformation.Email) || !IsValidEmail(clientInformation.Email))
            if (string.IsNullOrEmpty(clientInformation.Email))
            {
                return BadRequest("Email is invalid");
            }

            await _context.ClientInformations.AddAsync(clientInformation);
            await _context.SaveChangesAsync();

            return Ok("ClientInformation added successfully.");
        }


        // the IsValidEmail method was inspired from this thread
        // https://www.tutorialspoint.com/how-to-validate-an-email-address-in-chash
        //private bool IsValidEmail(string email)
        //{

        //    Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
        //                                    RegexOptions.CultureInvariant | RegexOptions.Singleline);

        //    return regex.IsMatch(email);
        //}
    }
}
