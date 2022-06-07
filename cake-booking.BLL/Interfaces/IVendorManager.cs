using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.BLL.Interfaces
{
    public interface IVendorManager
    {
        Task<List<VendorModel>> GetAll();
        Task<VendorModel> GetById(int id);
        Task Create(VendorModel vendorModel);
        Task Update(int id, VendorModel vendorModel);
        Task Delete(int id);
        Task<List<VendorModel>> GetWithSchedules();
    }
}
