using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Interfaces
{
    public interface IScheduleRepository
    {
        Task Create(ScheduleModel schedule);
        Task<List<ScheduleModel>> GetAll();
        Task<IQueryable<ScheduleModel>> GetAllQuery();
        Task<ScheduleModel> GetById(int id);
        Task Update(int id, ScheduleModel schedule);
        Task Delete(int id, ScheduleModel schedule);
    }
}
