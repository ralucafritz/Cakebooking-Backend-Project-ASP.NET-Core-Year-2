using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
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

        public async Task Create(int StudentId, ClientAddressModel clientAddressModel)
        {

        }

        public async Task<ClientAddressModel> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<ClientAddressModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<ClientAddressModel>> GetAllQuery()
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, ClientAddressModel clientAddressModel)
        {
            throw new NotImplementedException();
        }

        public async  Task Delete(int id)
        {
            throw new NotImplementedException();
        }




    }
}
