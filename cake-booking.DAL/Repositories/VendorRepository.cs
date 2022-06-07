using cake_booking.DAL.Entities;
using cake_booking.DAL.Helpers;
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
        // orderby and join 
        public async Task<List<string>> GetVendorsWithMoreSchedules()
        {
            var vendors = await _context
                .Vendors
                .Include(x => x.Schedules)
                .Where(x => x.Schedules.Count > 1)
                .OrderByDescending(x => x.Name)
                .Select(x => x.Name)
                .ToListAsync();

            return vendors;
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

        public async Task<List<VendorModel>> GetWithSchedules()
        {
            var vendors = await (await GetAllQuery()).IncludeSchedule().ToListAsync();
            var list = new List<VendorModel>();
            foreach (var vendor in vendors)
            {
                VendorModel vendorModel = new VendorModel
                {
                    Name = vendor.Name

                };
                
                list.Add(vendorModel);
            }

            //var returnList = 
            
            return list;
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

            // CASCADE DELETE
            var schedules = _context.Schedules.OrderBy(x => x.VendorId).Include(x => x.Vendor).First();
            

            try
            {
                var orders = _context.PickUpOrders.OrderBy(x => x.VendorId).First();
                _context.PickUpOrders.Remove(orders);
            }
            catch (Exception e)
            {
                // skip;
            }

            _context.Schedules.Remove(schedules);
           

            _context.Vendors.Remove(vendor);

            await _context.SaveChangesAsync();
        }


    }
}
