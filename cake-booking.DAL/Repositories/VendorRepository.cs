using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        public Task Create(VendorModel vendor)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, VendorModel vendor)
        {
            throw new NotImplementedException();
        }

        public Task<List<VendorModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<VendorModel>> GetAllQuery()
        {
            throw new NotImplementedException();
        }

        public Task<VendorModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, VendorModel vendor)
        {
            throw new NotImplementedException();
        }
    }
}
