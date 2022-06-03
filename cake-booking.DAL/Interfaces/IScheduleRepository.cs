using cake_booking.DAL.Entities;
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
        Task Create(int vendorId, ScheduleModel scheduleModel);
        Task Update(int id, ScheduleModel scheduleModel);
        Task Delete(int scheduleId);
        Task<List<ScheduleModel>> GetAll();
        Task<ScheduleModel> GetById(int scheduleId);
        Task<IQueryable<Schedule>> GetAllQuery();
    }
}
