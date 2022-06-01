using cake_booking.DAL.Configurations;
using cake_booking.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cake_booking.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }
        public DbSet<ClientInformation> ClientInformations { get; set; }
        //public DbSet<Vendor> Vendors{ get; set; }
        //public DbSet<ClientVendor> ClientVendors{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(options => options.AddConsole()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ClientConfiguration());

            modelBuilder.ApplyConfiguration(new ClientAddressConfiguration());

            modelBuilder.ApplyConfiguration(new ClientInformationConfiguration());

            //modelBuilder.ApplyConfiguration(new VendorConfiguration());

            //modelBuilder.ApplyConfiguration(new ClientVendorConfiguration());

        }




    }
}
