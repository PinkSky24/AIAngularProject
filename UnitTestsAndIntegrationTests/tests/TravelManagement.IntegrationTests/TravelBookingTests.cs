using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using TravelManagement.Core.Models;
using Xunit;

namespace TravelManagement.IntegrationTests;

public class TravelBookingTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public TravelBookingTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task FullTravelBookingFlow_Success()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Create a client
        var newClient = new Client
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "john.doe@example.com",
            PhoneNumber = "1234567890"
        };

        var clientResponse = await client.PostAsJsonAsync("/api/clients", newClient);
        Assert.Equal(HttpStatusCode.Created, clientResponse.StatusCode);
        var createdClient = await clientResponse.Content.ReadFromJsonAsync<Client>();
        Assert.NotNull(createdClient);

        // Create departure airport
        var departureAirport = new Airport
        {
            Code = "LAX",
            Name = "Los Angeles International Airport",
            City = "Los Angeles",
            Country = "USA"
        };

        var departureResponse = await client.PostAsJsonAsync("/api/airports", departureAirport);
        Assert.Equal(HttpStatusCode.Created, departureResponse.StatusCode);
        var createdDepartureAirport = await departureResponse.Content.ReadFromJsonAsync<Airport>();
        Assert.NotNull(createdDepartureAirport);

        // Create arrival airport
        var arrivalAirport = new Airport
        {
            Code = "SFO",
            Name = "San Francisco International Airport",
            City = "San Francisco",
            Country = "USA"
        };

        var arrivalResponse = await client.PostAsJsonAsync("/api/airports", arrivalAirport);
        Assert.Equal(HttpStatusCode.Created, arrivalResponse.StatusCode);
        var createdArrivalAirport = await arrivalResponse.Content.ReadFromJsonAsync<Airport>();
        Assert.NotNull(createdArrivalAirport);

        // Book travel
        var travel = new Travel
        {
            ClientId = createdClient.Id,
            DepartureAirportId = createdDepartureAirport.Id,
            ArrivalAirportId = createdArrivalAirport.Id,
            DepartureTime = DateTime.UtcNow.AddDays(1),
            ArrivalTime = DateTime.UtcNow.AddDays(1).AddHours(2),
            FlightNumber = "LA123",
            Price = 299.99m
        };

        var travelResponse = await client.PostAsJsonAsync("/api/travels", travel);
        Assert.Equal(HttpStatusCode.Created, travelResponse.StatusCode);
        var createdTravel = await travelResponse.Content.ReadFromJsonAsync<Travel>();
        Assert.NotNull(createdTravel);

        // Update travel
        createdTravel.Price = 349.99m;
        var updateResponse = await client.PutAsJsonAsync($"/api/travels/{createdTravel.Id}", createdTravel);
        Assert.Equal(HttpStatusCode.NoContent, updateResponse.StatusCode);

        // Get travel by flight number
        var flightResponse = await client.GetAsync($"/api/travels/flight/{travel.FlightNumber}");
        Assert.Equal(HttpStatusCode.OK, flightResponse.StatusCode);
        var flights = await flightResponse.Content.ReadFromJsonAsync<List<Travel>>();
        Assert.NotNull(flights);
        Assert.Single(flights);
        Assert.Equal(349.99m, flights[0].Price);

        // Delete travel
        var deleteResponse = await client.DeleteAsync($"/api/travels/{createdTravel.Id}");
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);

        // Verify travel is deleted
        var getResponse = await client.GetAsync($"/api/travels/{createdTravel.Id}");
        Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
    }
} 