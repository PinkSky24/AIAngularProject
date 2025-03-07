using Microsoft.EntityFrameworkCore;
using TravelManagement.Core.Models;

namespace TravelManagement.Infrastructure.Data;

public class TravelDbContext : DbContext
{
    public TravelDbContext(DbContextOptions<TravelDbContext> options) : base(options)
    {
    }

    public DbSet<Airport> Airports { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Travel> Travels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Travel>()
            .HasOne(t => t.Client)
            .WithMany(c => c.Travels)
            .HasForeignKey(t => t.ClientId);

        modelBuilder.Entity<Travel>()
            .HasOne(t => t.DepartureAirport)
            .WithMany(a => a.DepartureFlights)
            .HasForeignKey(t => t.DepartureAirportId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Travel>()
            .HasOne(t => t.ArrivalAirport)
            .WithMany(a => a.ArrivalFlights)
            .HasForeignKey(t => t.ArrivalAirportId)
            .OnDelete(DeleteBehavior.Restrict);
    }
} 