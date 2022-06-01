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
    }
}
