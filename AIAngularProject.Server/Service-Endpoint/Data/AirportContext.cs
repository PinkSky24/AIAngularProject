using Microsoft.EntityFrameworkCore;
using AirportAPI.Models;

namespace AirportAPI.Data
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options) { }

        public DbSet<Airport> Airports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().HasData(
                new Airport { Id = 1, Name = "YYZ", Country = "Canada" },
                new Airport { Id = 2, Name = "YUL", Country = "Canada" }
            );
        }
    }
}