using cake_booking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL.Configurations
{
    class PickUpOrderConfiguration : IEntityTypeConfiguration<PickUpOrder>
    {
        public void Configure(EntityTypeBuilder<PickUpOrder> builder)
        {
            builder.HasKey(p => new
            {
                p.StartDay,
                p.ClientId,
                p.CakeId,
                p.VendorId
            });

            builder.HasOne(p => p.Client)
                .WithMany(p => p.PickUpOrders)
                .HasForeignKey(p => p.ClientId);


            builder.HasOne(p => p.Vendor)
                .WithMany(p => p.PickUpOrders)
                .HasForeignKey(p => p.VendorId);

            builder.HasOne(p => p.Cake)
                .WithMany(p => p.PickUpOrders)
                .HasForeignKey(p => p.CakeId);
        }
    }
}
