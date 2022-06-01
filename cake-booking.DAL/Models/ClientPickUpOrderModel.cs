using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Models
{
    public class ClientPickUpOrderModel
    {
        public string VendorName { get; set; }
        public string CakeName { get; set; }
        public DateTime StartHour { get; set; }
        public DateTime StopHour { get; set; }
    }
}
