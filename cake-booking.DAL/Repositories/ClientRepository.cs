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

                 // CASCADE DELETE
            var addresses = _context.ClientAddresses.OrderBy(x => x.ClientId).Include(x => x.Client).First();
            try
            {
                var orders = _context.PickUpOrders.OrderBy(x => x.ClientId).First();
                _context.PickUpOrders.Remove(orders);
            }catch (Exception e)
            {
                // skip;
            }

            _context.ClientAddresses.Remove(addresses);

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();
        }

        // join linq

        public async Task<List<string>> GetClientAndCity()
        {
            var clients = _context.Clients;
            var clientsAddressesJoin = await _context
                .ClientAddresses
                .Join(clients, b => b.ClientId, a => a.Id, (b, a) => new
                {
                    a.FirstName,
                    b.City
                }).ToListAsync();

            var list = new List<string>();
            foreach (var group in clientsAddressesJoin)
            {
                list.Add($"{group.FirstName}: {group.City}");
            }


            return list;
        }
        // groupby 
        public async Task<List<string>> GroupClientsByGender()
        {
            var clients = await this.GetAll();
            var clientsGrouped = clients.GroupBy(x => x.Gender);
            var list = new List<string>();
            foreach (var group in clientsGrouped)
            {
                list.Add($"{group.Key}: {group.Count()}");

                foreach(var client in group)
                {
                    list.Add($"\t Name: {client.LastName} {client.FirstName}");
                }
            }


            return list;
        }

    }
}
