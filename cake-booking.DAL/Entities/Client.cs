using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ClientAddress ClientAddress { get; set; }
        public virtual ClientInformation ClientInformation { get; set; }
        //public virtual ICollection<ClientVendor> ClientVendors { get; set; }
    }
}
