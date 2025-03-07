namespace TravelManagement.Core.Models;

public class Airport
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public virtual ICollection<Travel> DepartureFlights { get; set; } = new List<Travel>();
    public virtual ICollection<Travel> ArrivalFlights { get; set; } = new List<Travel>();
} 