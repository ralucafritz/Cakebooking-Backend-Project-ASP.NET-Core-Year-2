using cake_booking.BLL.Interfaces;
using cake_booking.DAL.Entities;
using cake_booking.DAL.Interfaces;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.BLL.Managers
{
    public class ClientAddressManager : IClientAddressManager
    {
        private readonly IClientAddressRepository _clientAddressRepo;
        public ClientAddressManager(IClientAddressRepository clientAddressRepository)
        {
            _clientAddressRepo = clientAddressRepository;
        }
        public async Task Create(int StudentId, ClientAddressModel clientAddressModel)
        {
            await _clientAddressRepo.Create(StudentId, clientAddressModel);

        }
        public async Task Delete(int id)
        {
            await _clientAddressRepo.Delete(id);
        }
        public async Task<List<ClientAddressModel>> GetAll()
        {
            return await _clientAddressRepo.GetAll();
        }
        public async Task<ClientAddressModel> GetById(int id)
        {
            return await _clientAddressRepo.GetById(id);
        }
        public async Task Update(int id, ClientAddressModel clientAddressModel)
        {
            await _clientAddressRepo.Update(id, clientAddressModel);
        }
    }
}
