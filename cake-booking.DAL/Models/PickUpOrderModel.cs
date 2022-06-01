using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Models
{
    public class PickUpOrderModel
    {
        public DateTime StartHour { get; set; }
        public int ClientId { get; set; }
        public int VendorId { get; set; }
        public int CakeId { get; set; }
        public DateTime StopHour { get; set; }

    }
}
