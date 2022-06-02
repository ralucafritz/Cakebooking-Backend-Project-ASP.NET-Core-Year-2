using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.BLL.Interfaces
{
    public interface ICakeManager
    {
        Task Create(CakeModel cakeModel);
        Task<List<CakeModel>> GetAll();
        Task<CakeModel> GetById(int id);
        Task Update(int id, CakeModel cakeModel);
        Task Delete(int id);
    }
}
