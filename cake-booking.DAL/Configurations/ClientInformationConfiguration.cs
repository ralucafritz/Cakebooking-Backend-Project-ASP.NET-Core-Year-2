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
    public class ClientInformationConfiguration : IEntityTypeConfiguration<ClientInformation>
    {
        public void Configure(EntityTypeBuilder<ClientInformation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Email)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(x => x.Gender)
                .HasColumnType("nvarchar(1)")
                .HasMaxLength(1);

            builder.HasOne(x => x.Client)
                .WithOne(x => x.ClientInformation)
                .HasForeignKey<ClientInformation>(x => x.ClientId);
        }
    }
}
