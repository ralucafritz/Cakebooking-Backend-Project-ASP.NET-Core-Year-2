using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.BLL.Interfaces
{
    public interface IClientManager
    {
        Task<List<string>> ModifyStudent();
        Task Create(ClientModel client);
        Task<List<ClientJoinClientAddressModel>> GetAddress();
        Task<List<ClientModel>> GetAll();
        Task<ClientModel> GetById(int id);
        Task Delete(int id);
        Task Update(int id, ClientModel client);
        Task<List<string>> GetClientAndCity();
        Task<List<string>> GroupClientsByGender();
    }
}
