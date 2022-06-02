using cake_booking.BLL.Interfaces;
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
        private readonly ICakeManager _cakeManager;

        public CakeManager(ICakeManager cakeManager)
        {
            _cakeManager = cakeManager;
        }

        public async Task Create(CakeModel cakeModel)
        {
            await _cakeManager.Create(cakeModel);
        }

        public async Task Delete(int id)
        {
            await _cakeManager.Delete(id);
        }

        public async Task<List<CakeModel>> GetAll()
        {
            return await _cakeManager.GetAll();
        }

        public async Task<CakeModel> GetById(int id)
        {
            return await _cakeManager.GetById(id);
        }

        public async Task Update(int id, CakeModel cakeModel)
        {
            await _cakeManager.Update(id, cakeModel);
        }
    }
}
