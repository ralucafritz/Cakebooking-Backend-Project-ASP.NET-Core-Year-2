using cake_booking.DAL.Entities;
using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Repositories
{
    public class VendorRepository : IVendorRepository
    {
        private readonly AppDbContext _context;

        public VendorRepository(AppDbContext context)
        {
            _context = context;
        }
        // C R U D
        public async Task Create(VendorModel vendorModel)
        {
            var vendor = new Vendor
            {
                Name = vendorModel.Name
            };

            await _context.Vendors.AddAsync(vendor);
            await _context.SaveChangesAsync();
            
        }
        public async Task<List<VendorModel>> GetAll()
        {
            var vendors = await(await GetAllQuery()).ToListAsync();
            var list = new List<VendorModel>();
            foreach (var vendor in vendors)
            {
                VendorModel vendorModel = new VendorModel
                {
                    Name = vendor.Name
                };
                list.Add(vendorModel);
            }

            return list;
        }

        public async Task<IQueryable<Vendor>> GetAllQuery()
        {
            var query = _context.Vendors.AsQueryable();
            return query;
        }

        public async Task<VendorModel> GetById(int id)
        {
            Vendor vendor = await _context.Vendors.FindAsync(id);
            VendorModel vendorModel = new VendorModel
            {
                Name = vendor.Name
            };
            return vendorModel;
        }

        public async Task Update(int id, VendorModel vendorModel)
        {
            var vendor = await _context.Vendors.FindAsync(id);
            
            vendor.Name = vendorModel.Name;
            
            _context.Vendors.Update(vendor);

            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            Vendor vendor = await _context.Vendors.FindAsync(id);

            _context.Vendors.Remove(vendor);

            await _context.SaveChangesAsync();
        }
    }
}
