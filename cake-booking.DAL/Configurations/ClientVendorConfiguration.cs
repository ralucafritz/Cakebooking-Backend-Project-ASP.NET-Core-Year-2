//using cake_booking.DAL.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace cake_booking.DAL.Configurations
//{
//    public class ClientVendorConfiguration : IEntityTypeConfiguration<ClientVendor>
//    {
//        public void Configure(EntityTypeBuilder<ClientVendor> builder)
//        {
//            builder.HasKey(p => p.Id);

//            builder.HasOne(p => p.Client)
//                .WithMany(p => p.ClientVendors)
//                .HasForeignKey(p => p.ClientId);

//            builder.HasOne(p => p.Vendor)
//                .WithMany(p => p.ClientVendors)
//                .HasForeignKey(p => p.VendorId);
//        }
//    }
//}
