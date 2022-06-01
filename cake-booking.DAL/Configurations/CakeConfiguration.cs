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
    public class CakeConfiguration : IEntityTypeConfiguration<Cake>
    {
        public void Configure(EntityTypeBuilder<Cake> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);
            
            builder.Property(p => p.Description)
                .HasColumnType("nvarchar(200)")
                .HasMaxLength(200);

            builder.Property(p => p.Price)
                .HasColumnType("decimal(4,2)");
        }
    }
}
