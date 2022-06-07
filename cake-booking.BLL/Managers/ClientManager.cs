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
    public class ClientManager : IClientManager
    {
        private readonly IClientRepository _clientRepo;

        public ClientManager(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public async Task Create(ClientModel clientModel)
        {
            await _clientRepo.Create(clientModel);
        }

        public async Task Delete(int id)
        {
            await _clientRepo.Delete(id);
        }

        public async Task<List<ClientJoinClientAddressModel>> GetAddress()
        {
            return await _clientRepo.GetAddress();
        }

        public async Task<List<ClientModel>> GetAll()
        {
            return await _clientRepo.GetAll();
        }

        public async Task<ClientModel> GetById(int id)
        {
            return await _clientRepo.GetById(id);
        }

        public async Task<List<string>> ModifyStudent()
        {
            var clients = await _clientRepo.GetAll();
            var list = new List<string>();
            var i = 0;
            foreach (var client in clients)
            {
                i++;
                list.Add($"Client {i}: \n" +
                    $"\t First Name: {client.FirstName} \n" +
                    $"\t Last Name: {client.LastName} \n");
            }
            return list;
        }

        public async Task Update(int id, ClientModel clientModel)
        {
            await _clientRepo.Update(id, clientModel);
        }

        public async Task<List<string>> GetClientAndCity()
        {
            return await _clientRepo.GetClientAndCity();
        }
        public async Task<List<string>> GroupClientsByGender()
        {
            return await _clientRepo.GroupClientsByGender();
        }
    }
}
