using cake_booking.BLL.Interfaces;
using cake_booking.DAL.Interfaces;
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
        public async Task<List<string>> ModifyStudent()
        {
            throw new NotImplementedException();
        }
    }
}
