using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelManagement.API.Controllers;
using TravelManagement.Core.Models;
using TravelManagement.Infrastructure.Data;
using Xunit;

namespace TravelManagement.UnitTests.Controllers;

public class AirportsControllerTests
{
    private readonly DbContextOptions<TravelDbContext> _options;

    public AirportsControllerTests()
    {
        _options = new DbContextOptionsBuilder<TravelDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
    }

    [Fact]
    public async Task GetAirports_ReturnsAllAirports()
    {
        // Arrange
        using var context = new TravelDbContext(_options);
        var controller = new AirportsController(context);
        var airport = new Airport { Code = "TEST", Name = "Test Airport", City = "Test City", Country = "Test Country" };
        context.Airports.Add(airport);
        await context.SaveChangesAsync();

        // Act
        var result = await controller.GetAirports();

        // Assert
        var actionResult = Assert.IsType<ActionResult<IEnumerable<Airport>>>(result);
        var airports = Assert.IsAssignableFrom<IEnumerable<Airport>>(actionResult.Value);
        Assert.Single(airports);
    }

    [Fact]
    public async Task CreateAirport_ReturnsCreatedAtAction()
    {
        // Arrange
        using var context = new TravelDbContext(_options);
        var controller = new AirportsController(context);
        var airport = new Airport { Code = "NEW", Name = "New Airport", City = "New City", Country = "New Country" };

        // Act
        var result = await controller.CreateAirport(airport);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        var returnValue = Assert.IsType<Airport>(actionResult.Value);
        Assert.Equal(airport.Code, returnValue.Code);
    }

    [Fact]
    public async Task GetAirport_WithInvalidId_ReturnsNotFound()
    {
        // Arrange
        using var context = new TravelDbContext(_options);
        var controller = new AirportsController(context);

        // Act
        var result = await controller.GetAirport(999);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public async Task DeleteAirport_WithValidId_ReturnsNoContent()
    {
        // Arrange
        using var context = new TravelDbContext(_options);
        var controller = new AirportsController(context);
        var airport = new Airport { Code = "DEL", Name = "Delete Airport", City = "Delete City", Country = "Delete Country" };
        context.Airports.Add(airport);
        await context.SaveChangesAsync();

        // Act
        var result = await controller.DeleteAirport(airport.Id);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
} 