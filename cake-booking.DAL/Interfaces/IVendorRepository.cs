using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Interfaces
{
    public interface IVendorRepository
    {
        Task<List<VendorModel>> GetAll();
        Task<VendorModel> GetById(int id);
        Task<IQueryable<VendorModel>> GetAllQuery();
        Task Create(VendorModel vendor);
        Task Delete(int id, VendorModel vendor);
        Task Update(int id, VendorModel vendor);

    }
}
