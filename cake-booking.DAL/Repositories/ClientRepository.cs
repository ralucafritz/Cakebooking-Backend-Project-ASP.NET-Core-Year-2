using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Repositories
{
    public class ClientManager : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientManager(AppDbContext context)
        {
            _context = context;
        }
        // C
        public Task Create(ClientModel client)
        {
            throw new NotImplementedException();
        }
        // R
        public Task<List<ClientModel>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<ClientModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
        // U
        public Task Update(int id, ClientModel client)
        {
            throw new NotImplementedException();
        }
        // D
        public Task Delete(int id, ClientModel client)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientJoinClientAddressModel>> GetAddress()
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientModel>> GetNameAndNumber()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<ClientModel>> GetAllQuery()
        {
            throw new NotImplementedException();
        }
    }
}
