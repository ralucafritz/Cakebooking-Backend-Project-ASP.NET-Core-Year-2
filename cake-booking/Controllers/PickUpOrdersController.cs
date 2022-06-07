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
    public class PickUpOrdersController : ControllerBase
    {
        private readonly IPickUpOrderManager _pickUpOrderManager;

        public PickUpOrdersController(IPickUpOrderManager pickUpOrderManager)
        {
            _pickUpOrderManager = pickUpOrderManager;
        }

        ///////////////////////////////////////////////// CREATE ////////////////////////////////////////////////////////

        [HttpPost("addOrder/")]

        public async Task<IActionResult> AddOrder([FromBody] PickUpOrderModel pickUpOrderModel)
        {
            if (isValid(pickUpOrderModel) != null)
            {
                return BadRequest(isValid(pickUpOrderModel));
            }

            // passes validation

            await _pickUpOrderManager.Create(pickUpOrderModel);

            return Ok($"PickUP Order added successfully: \n" +
                $"\t Vendor #{pickUpOrderModel.VendorId}. \n" +
                $"\t Client #{pickUpOrderModel.ClientId}. \n" +
                $"\t Cake #{pickUpOrderModel.CakeId}");
        }

        //////////////////////////////////////////////// GET ////////////////////////////////////////////////////////

        //[HttpGet("get-orders-history")]

        //public async Task<IActionResult> GetOrdersHistory()
        //{
        //    var pickUpOrderModels = await _pickUpOrderManager.GetOrdersHistory();

        //    return Ok(pickUpOrderModels);
        //}

        [HttpGet("get-orders")]

        public async Task<IActionResult> GetOrders()
        {
            var pickUpOrderModels = await _pickUpOrderManager.GetAll();

            return Ok(pickUpOrderModels);
        }

        [HttpGet("get-future-orders")]

        public async Task<IActionResult> GetFutureOrders()
        {
            var pickUpOrderModels = await _pickUpOrderManager.GetFutureOrders();

            return Ok(pickUpOrderModels);
        }

        [HttpGet("get-vendorId={id}-orders")]

        public async Task<IActionResult> GetVendorOrders([FromRoute] int id)
        {
            var pickUpOrderModels = await _pickUpOrderManager.GetVendorOrders(id);

            return Ok(pickUpOrderModels);
        }

        [HttpGet("get-clientId={id}-orders")]

        public async Task<IActionResult> GetClientOrders([FromRoute] int id)
        {
            var pickUpOrderModels = await _pickUpOrderManager.GetClientOrders(id);

            return Ok(pickUpOrderModels);
        }

        //////////////////////////////////////////////// UPLOAD  ////////////////////////////////////////////////////////
        ///
        // cannot update order, a client has to cancel/delete and make another order

        //[HttpPut("update-order/{id}")]

        //public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] PickUpOrderModel pickUpOrderModel)
        //{
        //    if (isValid(pickUpOrderModel) != null)
        //    {
        //        return BadRequest(isValid(pickUpOrderModel));
        //    }

        //    await _pickUpOrderManager.Update(id, pickUpOrderModel);
        //    return Ok($"PickUp Order #{id} has been updated");
        //}

        ////////////////////////////////////////////////// DELETE ////////////////////////////////////////////////////////

        // orders get deleted only if one of the main elements of the key are deleted -> client / cake / vendor


        //[HttpDelete("delete")] // ?id=1
        //public async Task<IActionResult> DeleteOrder([FromQuery] int id)
        //{
        //    await _pickUpOrderManager.Delete(id);

        //    return Ok($"PickUpOrder #{id} has been deleted");
        //}

        //////////////////////////////////////////////// EXTRA  ////////////////////////////////////////////////////////

        // validation method

        private string isValid(PickUpOrderModel pickUpOrderModel)
        {
            string checkError = null;

            if (pickUpOrderModel.EndDay < DateTime.Now)
            {
                checkError = "The orded is past due to be picked up. Please throw it away.";
            }
            else if (pickUpOrderModel.EndDay < pickUpOrderModel.StartDay)
            {
                checkError = "The orded pick up dates are not valid.";
            }

            return checkError;
        }
    }
}
