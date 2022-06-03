using cake_booking.BLL.Interfaces;
using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.BLL.Managers
{
    public class ScheduleManager : IScheduleManager
    {
        private readonly IScheduleRepository _scheduleRepo;

        public ScheduleManager(IScheduleRepository scheduleRepo)
        {
            _scheduleRepo = scheduleRepo;
        }

        public async Task Create(int id, ScheduleModel scheduleModel)
        {
            await _scheduleRepo.Create(id, scheduleModel);
        }

        public async Task Delete(int scheduleId)
        {
            await _scheduleRepo.Delete(scheduleId);
        }

        public async Task<List<ScheduleModel>> GetAll()
        {
            return await _scheduleRepo.GetAll();
        }

        public async Task<ScheduleModel> GetById(int scheduleId)
        {
            return await _scheduleRepo.GetById(scheduleId);
        }

        public async Task Update(int id, ScheduleModel scheduleModel)
        {
            await _scheduleRepo.Update(id, scheduleModel);
        }
    }
}
