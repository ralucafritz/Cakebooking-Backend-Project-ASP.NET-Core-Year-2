using cake_booking.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Interfaces
{
    public interface IClientAddressRepository
    {
        Task<List<ClientAddressModel>> GetAll();
        Task<ClientAddressModel> GetById(int id);
        Task Create(int StudentId, ClientAddressModel clientAddressModel);
        Task Update(int id, ClientAddressModel clientAddressModel);
        Task Delete(int id);
        Task<IQueryable<ClientAddressModel>> GetAllQuery();
    }
}
