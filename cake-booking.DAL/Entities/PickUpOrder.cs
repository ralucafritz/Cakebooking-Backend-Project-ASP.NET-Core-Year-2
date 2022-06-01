using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Entities
{
    public class PickUpOrder
    {
        // we need to create a composite key that will contain of:
        // ClientId
        // VendorId
        // CakeId
        // StartHour of the PickUpOrder

        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public int VendorId { get; set; }
        public int ClientId { get; set; }
        public int CakeId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Vendor Vendor { get; set; }
        public virtual Cake Cake { get; set; }
    }
}
