using cake_booking.DAL.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Helpers
{
    public static class VendorExtension
    {
        public static IQueryable<Vendor> IncludeSchedule(this IQueryable<Vendor> vendors)
        {
            return vendors.Include(x => x.Schedules);
        }

        public static IQueryable Where(this IQueryable<Vendor> vendors, string name)
        {
            return vendors
                .IncludeSchedule()
                .Where(x => x.Name == name);
        }
    }
}
