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
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        // C
        public async Task Create(ClientModel clientModel)
        {
            var client = new Client {
                FirstName = clientModel.FirstName,
                LastName = clientModel.LastName,
                PhoneNumber = clientModel.PhoneNumber,
                Gender = clientModel.Gender
            };

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
        }
        // R
        public async Task<List<ClientModel>> GetAll()
        {
            var clients = await (await GetAllQuery()).ToListAsync();
            var list = new List<ClientModel>();
            foreach (var client in clients)
            {
                ClientModel clientModel = new ClientModel
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    PhoneNumber = client.PhoneNumber,
                    Gender = client.Gender
                };
                list.Add(clientModel);
            }

            return list;
        }
        public async Task<ClientModel> GetById(int id)
        {
            Client client = await _context.Clients.FindAsync(id);
            ClientModel clientModel = new ClientModel
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                Gender = client.Gender
            };
            return clientModel;
        }

        public async Task<List<ClientJoinClientAddressModel>> GetAddress()
        {
            var result = await (await GetAllQuery())
                .Include(x => x.ClientAddress)
                .Where(x => x.ClientAddress != null)
                .ToListAsync();

            var list = new List<ClientJoinClientAddressModel>();

            foreach(var res in result)
            {
                ClientJoinClientAddressModel clientJoinClientAddressModel = new ClientJoinClientAddressModel
                {
                    FirstName = res.FirstName,
                    LastName = res.LastName,
                    PhoneNumber = res.PhoneNumber,
                    Gender = res.Gender,
                    City = res.ClientAddress.City,
                    Country = res.ClientAddress.Country
                };
                list.Add(clientJoinClientAddressModel); 
            }

            return list;
        }

        public async Task<IQueryable<Client>> GetAllQuery()
        {
            var query = _context.Clients.AsQueryable();
            return query;
        }

        // U
        public async Task Update(int id, ClientModel clientModel)
        {
            Client client = await _context.Clients.FindAsync(id);

            client.FirstName = clientModel.FirstName;
            client.LastName = clientModel.LastName;
            client.PhoneNumber = clientModel.PhoneNumber;
            client.Gender = clientModel.Gender;

            _context.Clients.Update(client);

            await _context.SaveChangesAsync();
        }
        // D
        public async Task Delete(int id)
        {
            Client client = await _context.Clients.FindAsync(id);

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();
        }

    }
}
