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
    public class VendorManager : IVendorManager
    {
        private readonly IVendorRepository _vendorRepo;

        public VendorManager(IVendorRepository vendorRepo)
        {
            _vendorRepo = vendorRepo;
        }

        public async Task Create(VendorModel vendorModel)
        {
            await _vendorRepo.Create(vendorModel);
        }

        public async Task Delete(int id)
        {
            await _vendorRepo.Delete(id);
        }

        public async Task<List<VendorModel>> GetAll()
        {
            return await _vendorRepo.GetAll();
        }

        public async Task<VendorModel> GetById(int id)
        {
            return await _vendorRepo.GetById(id);
        }

        public async Task Update(int id, VendorModel vendorModel)
        {
            await _vendorRepo.Update(id, vendorModel);
        }
    }
}
