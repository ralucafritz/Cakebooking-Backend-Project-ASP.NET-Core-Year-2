using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.BLL.Interfaces
{
    public interface IScheduleManager
    {
        Task<List<ScheduleModel>> GetAll();
        Task Create(int id, ScheduleModel scheduleModel);
        Task Update(int id, ScheduleModel scheduleModel);
        Task<ScheduleModel> GetById(int scheduleId);
        Task Delete(int scheduleId);
    }
}
