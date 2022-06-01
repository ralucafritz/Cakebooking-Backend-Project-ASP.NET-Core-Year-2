using cake_booking.DAL.Entities;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Interfaces
{
    public interface ICakeRepository
    {
        Task Create(CakeModel cake);
        Task<List<CakeModel>> GetAll();
        Task<CakeModel> GetById(int id);
        Task<IQueryable<Cake>> GetAllQuery();
        Task Update(int id, CakeModel cake);
        Task Delete(int id);
    }
}
