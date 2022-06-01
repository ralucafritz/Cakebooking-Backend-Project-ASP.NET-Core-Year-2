using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Entities
{
    public class ClientInformation
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
