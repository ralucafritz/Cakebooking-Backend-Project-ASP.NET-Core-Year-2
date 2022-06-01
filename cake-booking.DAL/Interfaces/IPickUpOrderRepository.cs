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
        Task<PickUpOrderModel> Create(PickUpOrderModel pickUpOrderModel);
        Task<List<PickUpOrderModel>> GetOrdersHistory();
        Task<List<PickUpOrderModel>> GetFutureOrders();
        Task<PickUpOrderModel> GetOrderInfo(int vendorId, int clientId, int cakeId, DateTime orderTime);
        Task<List<VendorPickUpOrderModel>> GetVendorOrders(int vendorId);
        Task<List<ClientPickUpOrderModel>> GetClientOrders(int clientId);
        Task<PickUpOrderModel> Update(PickUpOrderModel pickUpOrderModel);
        Task<PickUpOrderModel> Delete(PickUpOrderModel pickUpOrderModel);

    }
}
