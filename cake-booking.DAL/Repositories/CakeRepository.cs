using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Repositories
{
    public class CakeRepository : ICakeRepository
    {
        private readonly AppDbContext _context;

        public CakeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task Create(CakeModel cake)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CakeModel cake)
        {
            throw new NotImplementedException();
        }

        public Task<List<CakeModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<CakeModel>> GetAllQuery()
        {
            throw new NotImplementedException();
        }

        public Task<CakeModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, CakeModel cake)
        {
            throw new NotImplementedException();
        }
    }
}
