using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotels.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Hotels.Infrastructure.ContextDB
{
    public class HotelDBContext : DbContext
    {
        public HotelDBContext()
        {
        }

        public HotelDBContext(DbContextOptions<HotelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().
                                SetBasePath(Directory.GetCurrentDirectory()).
                                AddJsonFile("appsettings.json", optional: false);

            IConfiguration config = builder.Build();

            string conexString = config.GetValue<string>("ConnectionStrings:hotelsSql");

            optionsBuilder.UseSqlite(conexString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        { 
            base.OnModelCreating(modelBuilder);
        }
    }
}
