using cake_booking.DAL.Entities;
using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientJoinClientAddressModel>> GetAddress();
        Task<List<ClientModel>> GetNameAndNumber();
        Task<List<ClientModel>> GetAll();


        Task<ClientModel> GetById(int id);
        Task Create(ClientModel client);
        Task Delete(int id, ClientModel client);
        Task Update(int id, ClientModel client);
        Task<IQueryable<ClientModel>> GetAllQuery();
    }
}
