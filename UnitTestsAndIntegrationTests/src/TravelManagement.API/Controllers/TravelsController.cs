using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelManagement.Core.Models;
using TravelManagement.Infrastructure.Data;

namespace TravelManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TravelsController : ControllerBase
{
    private readonly TravelDbContext _context;

    public TravelsController(TravelDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Travel>>> GetTravels()
    {
        return await _context.Travels
            .Include(t => t.Client)
            .Include(t => t.DepartureAirport)
            .Include(t => t.ArrivalAirport)
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Travel>> GetTravel(int id)
    {
        var travel = await _context.Travels
            .Include(t => t.Client)
            .Include(t => t.DepartureAirport)
            .Include(t => t.ArrivalAirport)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (travel == null)
        {
            return NotFound();
        }

        return travel;
    }

    [HttpGet("flight/{flightNumber}")]
    public async Task<ActionResult<IEnumerable<Travel>>> GetTravelsByFlight(string flightNumber)
    {
        return await _context.Travels
            .Include(t => t.Client)
            .Include(t => t.DepartureAirport)
            .Include(t => t.ArrivalAirport)
            .Where(t => t.FlightNumber == flightNumber)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Travel>> CreateTravel(Travel travel)
    {
        _context.Travels.Add(travel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTravel), new { id = travel.Id }, travel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTravel(int id, Travel travel)
    {
        if (id != travel.Id)
        {
            return BadRequest();
        }

        _context.Entry(travel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TravelExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTravel(int id)
    {
        var travel = await _context.Travels.FindAsync(id);
        if (travel == null)
        {
            return NotFound();
        }

        _context.Travels.Remove(travel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TravelExists(int id)
    {
        return _context.Travels.Any(e => e.Id == id);
    }
} 