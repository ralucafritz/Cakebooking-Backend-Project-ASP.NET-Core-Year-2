using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _context;

        public ScheduleRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task Create(ScheduleModel schedule)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, ScheduleModel schedule)
        {
            throw new NotImplementedException();
        }

        public Task<List<ScheduleModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<ScheduleModel>> GetAllQuery()
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, ScheduleModel schedule)
        {
            throw new NotImplementedException();
        }
    }
}
