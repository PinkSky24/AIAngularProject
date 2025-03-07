namespace TravelManagement.Core.Models;

public class Travel
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int DepartureAirportId { get; set; }
    public int ArrivalAirportId { get; set; }
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }
    public string FlightNumber { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public virtual Client Client { get; set; } = null!;
    public virtual Airport DepartureAirport { get; set; } = null!;
    public virtual Airport ArrivalAirport { get; set; } = null!;
} 