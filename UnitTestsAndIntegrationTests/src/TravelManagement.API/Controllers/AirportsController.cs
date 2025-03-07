using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelManagement.Core.Models;
using TravelManagement.Infrastructure.Data;

namespace TravelManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AirportsController : ControllerBase
{
    private readonly TravelDbContext _context;

    public AirportsController(TravelDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Airport>>> GetAirports()
    {
        return await _context.Airports.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Airport>> GetAirport(int id)
    {
        var airport = await _context.Airports.FindAsync(id);

        if (airport == null)
        {
            return NotFound();
        }

        return airport;
    }

    [HttpPost]
    public async Task<ActionResult<Airport>> CreateAirport(Airport airport)
    {
        _context.Airports.Add(airport);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAirport), new { id = airport.Id }, airport);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAirport(int id, Airport airport)
    {
        if (id != airport.Id)
        {
            return BadRequest();
        }

        _context.Entry(airport).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AirportExists(id))
            {
                return NotFound();
            }
            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirport(int id)
    {
        var airport = await _context.Airports.FindAsync(id);
        if (airport == null)
        {
            return NotFound();
        }

        _context.Airports.Remove(airport);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AirportExists(int id)
    {
        return _context.Airports.Any(e => e.Id == id);
    }
} 