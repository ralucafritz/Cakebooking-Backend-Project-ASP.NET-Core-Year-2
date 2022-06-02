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
    public class CakeManager : ICakeManager
    {
        private readonly ICakeRepository _cakeRepo;

        public CakeManager(ICakeRepository cakeRepo)
        {
            _cakeRepo = cakeRepo;
        }

        public async Task Create(CakeModel cakeModel)
        {
            await _cakeRepo.Create(cakeModel);
        }

        public async Task Delete(int id)
        {
            await _cakeRepo.Delete(id);
        }

        public async Task<List<CakeModel>> GetAll()
        {
            return await _cakeRepo.GetAll();
        }

        public async Task<CakeModel> GetById(int id)
        {
            return await _cakeRepo.GetById(id);
        }

        public async Task Update(int id, CakeModel cakeModel)
        {
            await _cakeRepo.Update(id, cakeModel);
        }
    }
}
