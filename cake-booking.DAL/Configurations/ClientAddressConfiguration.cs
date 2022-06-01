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
    public class ClientAddressConfiguration : IEntityTypeConfiguration<ClientAddress>
    {
        public void Configure(EntityTypeBuilder<ClientAddress> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.City)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.Property(x => x.Country)
                .HasColumnType("nvarchar(100)")
                .HasMaxLength(100);

            builder.HasOne(x => x.Client)
                .WithOne(x => x.ClientAddress)
                .HasForeignKey<ClientAddress>(x => x.ClientId);
        }
    }
}