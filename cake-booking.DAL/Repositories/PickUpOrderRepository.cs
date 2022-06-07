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
    public class PickUpOrderRepository : IPickUpOrderRepository
    {
        private readonly AppDbContext _context;

        public PickUpOrderRepository(AppDbContext context)
        {
            _context = context;
        }
        // C R U D
        public async Task Create(PickUpOrderModel pickUpOrderModel)
        {
            var pickUpOrder = new PickUpOrder
            {
                ClientId = pickUpOrderModel.ClientId,
                VendorId = pickUpOrderModel.VendorId,
                CakeId = pickUpOrderModel.CakeId,
                StartDay = pickUpOrderModel.StartDay,
                EndDay = pickUpOrderModel.EndDay
            };
            await _context.PickUpOrders.AddAsync(pickUpOrder);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            PickUpOrder pickUpOrder= await _context.PickUpOrders.FindAsync(id);

            _context.PickUpOrders.Remove(pickUpOrder);

            await _context.SaveChangesAsync();
        }

        public async Task<List<ClientPickUpOrderModel>> GetClientOrders(int clientId)
        {
            var clientPickUpOrderModel = await _context.PickUpOrders
                                                .Include(x => x.Client)
                                                .Include(x => x.Vendor)
                                                .Include(x => x.Cake)
                                                .Where(x => x.ClientId == clientId)
                                                .Select(x => new ClientPickUpOrderModel
                                                {
                                                    VendorName = x.Vendor.Name,
                                                    CakeName = x.Cake.Name,
                                                    CakeDescription = x.Cake.Description,
                                                    Price = x.Cake.Price,
                                                    StartDay = x.StartDay,
                                                    EndDay = x.EndDay

                                                })
                                                .OrderBy(x => x.StartDay)
                                                .ToListAsync();

            return clientPickUpOrderModel;
        }

        public async Task<List<PickUpOrderModel>> GetFutureOrders()
        {
            var pickUpOrderModel = await _context.PickUpOrders
                .Include(x => x.Client)
                .Include(x => x.Vendor)
                .Include(x => x.Cake)
                .Where(x => x.EndDay > DateTime.Now)
                .Select(x => new PickUpOrderModel
                {
                    StartDay = x.StartDay,
                    EndDay = x.EndDay,
                    ClientId = x.Client.Id,
                    VendorId = x.Vendor.Id,
                    CakeId = x.CakeId
                })
                .OrderBy(x => x.StartDay)
                .ToListAsync();

            return pickUpOrderModel;
        }


        public async Task<List<PickUpOrderModel>> GetOrdersHistory()
        {
            var pickUpOrderModel = await _context.PickUpOrders
                                            .Include(x => x.Client)
                                            .Include(x => x.Vendor)
                                            .Include(x => x.Cake)
                                            .Where(x => x.EndDay < DateTime.Now)
                                            .Select(x => new PickUpOrderModel
                                            {
                                                StartDay = x.StartDay,
                                                EndDay = x.EndDay,
                                                ClientId = x.Client.Id,
                                                VendorId = x.Vendor.Id,
                                                CakeId = x.CakeId
                                            })
                                            .OrderBy(x => x.StartDay)
                                            .ToListAsync();

            return pickUpOrderModel;
        }

        public async Task<List<VendorPickUpOrderModel>> GetVendorOrders(int vendorId)
        {
            var vendorPickUpOrderModel = await _context.PickUpOrders
                                    .Include(x => x.Client)
                                    .Include(x => x.Vendor)
                                    .Include(x => x.Cake)
                                    .Where(x => x.VendorId == vendorId)
                                    .Select(x => new VendorPickUpOrderModel
                                    {
                                        ClientFirstName = x.Client.FirstName,
                                        ClientLastName = x.Client.LastName,
                                        CakeName = x.Cake.Name,
                                        CakeDescription = x.Cake.Description,
                                        Price = x.Cake.Price,
                                        StartDay = x.StartDay,
                                        EndDay = x.EndDay

                                    })
                                    .OrderBy(x => x.StartDay)
                                    .ToListAsync();

            return vendorPickUpOrderModel;
        }

        public async Task Update(int id, PickUpOrderModel pickUpOrderModel)
        {
            PickUpOrder pickUpOrder = await _context.PickUpOrders.FindAsync(id);

            pickUpOrder.ClientId = pickUpOrderModel.ClientId;
            pickUpOrder.VendorId = pickUpOrderModel.VendorId;
            pickUpOrder.CakeId = pickUpOrderModel.CakeId;
            pickUpOrder.StartDay = pickUpOrderModel.StartDay;
            pickUpOrder.EndDay = pickUpOrderModel.EndDay;

            _context.PickUpOrders.Update(pickUpOrder);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PickUpOrderModel>> GetAll()
        {
            var pickUpOrders = await (await GetAllQuery()).ToListAsync();
            var list = new List<PickUpOrderModel>();
            foreach (var pickUpOrder in pickUpOrders)
            {
                var pickUpOrderModel = new PickUpOrderModel
                {
                    ClientId = pickUpOrder.ClientId,
                    VendorId = pickUpOrder.VendorId,
                    CakeId = pickUpOrder.CakeId,
                    StartDay = pickUpOrder.StartDay,
                    EndDay = pickUpOrder.EndDay
                };
                list.Add(pickUpOrderModel);
            }
            return list;
        }

        public async Task<IQueryable<PickUpOrder>> GetAllQuery()
        {
            var query = _context.PickUpOrders.AsQueryable();
            return query;
        }

    }
}
