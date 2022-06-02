using cake_booking.BLL.Interfaces;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.BLL.Managers
{
    public class PickUpOrderManager : IPickUpOrderManager
    {
        private readonly IPickUpOrderManager _pickUpOrderManager;

        public PickUpOrderManager(IPickUpOrderManager pickUpOrderManager)
        {
            _pickUpOrderManager = pickUpOrderManager;
        }
        public async Task Create(PickUpOrderModel pickUpOrderModel)
        {
            await _pickUpOrderManager.Create(pickUpOrderModel);
        }

        public async Task Delete(int id)
        {
            await _pickUpOrderManager.Delete(id);
        }

        public async Task<List<PickUpOrderModel>> GetAll()
        {
            return await _pickUpOrderManager.GetAll();
        }

        public async Task<List<ClientPickUpOrderModel>> GetClientOrders(int clientId)
        {
            return await _pickUpOrderManager.GetClientOrders(clientId);
        }

        public async Task<List<PickUpOrderModel>> GetFutureOrders()
        {
            return await _pickUpOrderManager.GetFutureOrders();
        }

        public async Task<PickUpOrderModel> GetOrderInfo(int vendorId, int clientId, int cakeId, DateTime startDay)
        {
            return await _pickUpOrderManager.GetOrderInfo(vendorId, clientId, cakeId, startDay);
        }

        public async Task<List<PickUpOrderModel>> GetOrdersHistory()
        {
            return await _pickUpOrderManager.GetOrdersHistory();
        }

        public async Task<List<VendorPickUpOrderModel>> GetVendorOrders(int vendorId)
        {
            return await _pickUpOrderManager.GetVendorOrders(vendorId);
        }

        public async Task Update(int id, PickUpOrderModel pickUpOrderModel)
        {
            await _pickUpOrderManager.Update(id, pickUpOrderModel);
        }
    }
}
