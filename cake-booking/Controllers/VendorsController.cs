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
    public class VendorsController : ControllerBase
    {
        private readonly IVendorManager _vendorManager;

        public VendorsController(IVendorManager vendorManager)
        {
            _vendorManager = vendorManager;
        }
        ///////////////////////////////////////////////// CREATE ////////////////////////////////////////////////////////

        [HttpPost("AddVendor")]

        public async Task<IActionResult> AddVendor([FromBody] VendorModel vendorModel)
        {
            if (string.IsNullOrEmpty(vendorModel.Name))
            {
                return BadRequest("Vendor name is null.");
            }

            await _vendorManager.Create(vendorModel);

            return Ok("Vendor added successfully.");
        }

        //////////////////////////////////////////////// GET ////////////////////////////////////////////////////////

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetVendorById([FromRoute] int id)
        {
            var clientModel = await _vendorManager.GetById(id);

            return Ok(clientModel);
        }


        [HttpGet("get-vendors")]
        public async Task<IActionResult> GetVendors()
        {
            var vendorModels = await _vendorManager.GetAll();

            return Ok(vendorModels);
        }

        //////////////////////////////////////////////// UPLOAD  ////////////////////////////////////////////////////////

        [HttpPut("update-vendor/{id}")]

        public async Task<IActionResult> UpdateVendor([FromRoute] int id, [FromBody] VendorModel vendorModel)
        {
            if (string.IsNullOrEmpty(vendorModel.Name))
            {
                return BadRequest("Vendor name is null.");
            }

            await _vendorManager.Update(id, vendorModel);
            return Ok($"Vendor #{id} has been updated");
        }

        //////////////////////////////////////////////// DELETE ////////////////////////////////////////////////////////

        [HttpDelete("delete")] // ?id=1
        public async Task<IActionResult> DeleteVendor([FromQuery] int id)
        {
            await _vendorManager.Delete(id);

            return Ok($"Vendor #{id} has been deleted");
        }

        //////////////////////////////////////////////// EXTRA  ////////////////////////////////////////////////////////


    }
}
