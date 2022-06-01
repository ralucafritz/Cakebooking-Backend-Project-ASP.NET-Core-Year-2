using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Repositories
{
    public class PickUpOrderRepository : IPickUpOrderRepository
    {
        private readonly AppDbContext _context;

        public PickUpOrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<PickUpOrderModel> Create(PickUpOrderModel pickUpOrderModel)
        {
            throw new NotImplementedException();
        }

        public Task<PickUpOrderModel> Delete(PickUpOrderModel pickUpOrderModel)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientPickUpOrderModel>> GetClientOrders(int clientId)
        {
            throw new NotImplementedException();
        }

        public Task<List<PickUpOrderModel>> GetFutureOrders()
        {
            throw new NotImplementedException();
        }

        public Task<PickUpOrderModel> GetOrderInfo(int vendorId, int clientId, int cakeId, DateTime orderTime)
        {
            throw new NotImplementedException();
        }

        public Task<List<PickUpOrderModel>> GetOrdersHistory()
        {
            throw new NotImplementedException();
        }

        public Task<List<VendorPickUpOrderModel>> GetVendorOrders(int vendorId)
        {
            throw new NotImplementedException();
        }

        public Task<PickUpOrderModel> Update(PickUpOrderModel pickUpOrderModel)
        {
            throw new NotImplementedException();
        }
    }
}
