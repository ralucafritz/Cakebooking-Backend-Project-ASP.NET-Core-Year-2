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
    public class ClientAddressRepository : IClientAddressRepository
    {
        private readonly AppDbContext _context;

        public ClientAddressRepository(AppDbContext context)
        {
            _context = context;
        }

        // C R U D
        public async Task Create(int ClientId, ClientAddressModel clientAddressModel)
        {
            // check if the client already has an address in the DB or not
            if ((await _context.ClientAddresses.FirstOrDefaultAsync(x => x.ClientId == ClientId)) != null)
                return;
            ClientAddress clientAddress = new ClientAddress
            {
                City = clientAddressModel.City,
                Country = clientAddressModel.Country,
                ClientId = ClientId
            };

            await _context.ClientAddresses.AddAsync(clientAddress);
            await _context.SaveChangesAsync();
        }

        public async Task<ClientAddressModel> GetById(int id)
        {
            ClientAddress clientAddresses = await _context.ClientAddresses.FindAsync(id);
            ClientAddressModel clientAddressModel = new ClientAddressModel
            {
                City = clientAddresses.City, 
                Country = clientAddresses.Country,
            };
            return clientAddressModel;
        }
        public async Task<List<ClientAddressModel>> GetAll()
        {
            var clientAddresses = await (await GetAllQuery()).ToListAsync();
            var list = new List<ClientAddressModel>();
            foreach (var clientAddress in clientAddresses)
            {
                var clientAddressModel = new ClientAddressModel
                {
                    City = clientAddress.City,
                    Country = clientAddress.Country,
                };
                list.Add(clientAddressModel);
            }
            return list;
        }

        public async Task<IQueryable<ClientAddress>> GetAllQuery()
        {
            var query = _context.ClientAddresses.AsQueryable();
            return query;
        }

        public async Task Update(int ClientId, ClientAddressModel clientAddressModel)
        {
            ClientAddress clientAddress = await _context.ClientAddresses.FindAsync(ClientId);

            clientAddress.City = clientAddressModel.City;
            clientAddress.Country = clientAddressModel.Country;

            _context.ClientAddresses.Update(clientAddress);
            await _context.SaveChangesAsync();
        }

        public async  Task Delete(int id)
        {
            ClientAddress clientAddress = await _context.ClientAddresses.FindAsync(id);
            _context.ClientAddresses.Remove(clientAddress);
            await _context.SaveChangesAsync();
        }




    }
}
