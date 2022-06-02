using cake_booking.BLL.Interfaces;
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
        private readonly IVendorManager _vendorManager;

        public VendorManager(IVendorManager vendorManager)
        {
            _vendorManager = vendorManager;
        }

        public async Task Create(VendorModel vendorModel)
        {
            await _vendorManager.Create(vendorModel);
        }

        public async Task Delete(int id)
        {
            await _vendorManager.Delete(id);
        }

        public async Task<List<VendorModel>> GetAll()
        {
            return await _vendorManager.GetAll();
        }

        public async Task<VendorModel> GetById(int id)
        {
            return await _vendorManager.GetById(id);
        }

        public async Task Update(int id, VendorModel vendorModel)
        {
            await _vendorManager.Update(id, vendorModel);
        }
    }
}
