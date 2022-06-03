using cake_booking.BLL.Interfaces;
using cake_booking.DAL.Interfaces;
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
        private readonly IPickUpOrderRepository _pickUpOrderRepo;

        public PickUpOrderManager(IPickUpOrderRepository pickUpOrderRepo)
        {
            _pickUpOrderRepo = pickUpOrderRepo;
        }
        public async Task Create(PickUpOrderModel pickUpOrderModel)
        {
            await _pickUpOrderRepo.Create(pickUpOrderModel);
        }

        public async Task Delete(int id)
        {
            await _pickUpOrderRepo.Delete(id);
        }

        public async Task<List<PickUpOrderModel>> GetAll()
        {
            return await _pickUpOrderRepo.GetAll();
        }

        public async Task<List<ClientPickUpOrderModel>> GetClientOrders(int clientId)
        {
            return await _pickUpOrderRepo.GetClientOrders(clientId);
        }

        public async Task<List<PickUpOrderModel>> GetFutureOrders()
        {
            return await _pickUpOrderRepo.GetFutureOrders();
        }

        public async Task<List<PickUpOrderModel>> GetOrdersHistory()
        {
            return await _pickUpOrderRepo.GetOrdersHistory();
        }

        public async Task<List<VendorPickUpOrderModel>> GetVendorOrders(int vendorId)
        {
            return await _pickUpOrderRepo.GetVendorOrders(vendorId);
        }

        public async Task Update(int id, PickUpOrderModel pickUpOrderModel)
        {
            await _pickUpOrderRepo.Update(id, pickUpOrderModel);
        }
    }
}
