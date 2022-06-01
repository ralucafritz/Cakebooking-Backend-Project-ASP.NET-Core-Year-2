using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Models
{
    public class VendorPickUpOrderModel
    {
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string CakeName { get; set; }
        public string CakeDescription { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
    }
}
