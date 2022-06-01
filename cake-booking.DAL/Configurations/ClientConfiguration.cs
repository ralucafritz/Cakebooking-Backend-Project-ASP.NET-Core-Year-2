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
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(x => x.LastName)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("nvarchar(10)")
                .HasMaxLength(10);

            builder.Property(x => x.Gender)
                .HasColumnType("nvarchar(1)")
                .HasMaxLength(1);
        }
    }
}
