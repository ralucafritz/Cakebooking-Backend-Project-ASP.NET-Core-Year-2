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
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AppDbContext _context;

        public ScheduleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(int vendorId, ScheduleModel scheduleModel)
        {
            var schedule = new Schedule
            {
                StartHour = TimeSpan.Parse(scheduleModel.StartHour),
                EndHour = TimeSpan.Parse(scheduleModel.EndHour),
                VendorId = vendorId
            };

            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int scheduleId)
        {
            Schedule schedule = await _context.Schedules.FindAsync(scheduleId);

            _context.Schedules.Remove(schedule);

            await _context.SaveChangesAsync();
        }

        public async Task<List<ScheduleModel>> GetAll()
        {
            var schedules = await (await GetAllQuery()).ToListAsync();
            var list = new List<ScheduleModel>();
            foreach (var schedule in schedules)
            {
                ScheduleModel scheduleModel = new ScheduleModel
                {
                    StartHour = schedule.StartHour.ToString(),
                    EndHour = schedule.EndHour.ToString()
                };
                list.Add(scheduleModel);
            }

            return list;
        }

        public async Task<ScheduleModel> GetById(int scheduleId)
        {
            Schedule schedule = await _context.Schedules.FindAsync(scheduleId);
            ScheduleModel scheduleModel = new ScheduleModel
            {
                StartHour = schedule.StartHour.ToString(),
                EndHour = schedule.EndHour.ToString()
            };
            return scheduleModel;
        }

        public async Task Update(int id, ScheduleModel scheduleModel)
        {
            Schedule schedule = await _context.Schedules.FindAsync(id);

            schedule.StartHour = TimeSpan.Parse(scheduleModel.StartHour);
            schedule.EndHour = TimeSpan.Parse(scheduleModel.EndHour);

            _context.Schedules.Update(schedule);

            await _context.SaveChangesAsync();
        }
        public async Task<IQueryable<Schedule>> GetAllQuery()
        {
            var query = _context.Schedules.AsQueryable();
            return query;
        }
    }
}
