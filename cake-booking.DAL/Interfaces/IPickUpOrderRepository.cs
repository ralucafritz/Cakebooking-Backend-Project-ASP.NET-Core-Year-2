using cake_booking.DAL.Entities;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Interfaces
{
    public interface IPickUpOrderRepository
    {
        Task Create(PickUpOrderModel pickUpOrderModel);
        Task<List<PickUpOrderModel>> GetOrdersHistory();
        Task<List<PickUpOrderModel>> GetFutureOrders();
        Task<List<PickUpOrderModel>> GetAll();
        Task<IQueryable<PickUpOrder>> GetAllQuery();
        Task<List<VendorPickUpOrderModel>> GetVendorOrders(int vendorId);
        Task<List<ClientPickUpOrderModel>> GetClientOrders(int clientId);
        Task Update(int id, PickUpOrderModel pickUpOrderModel);
        Task Delete(int id);

    }
}
