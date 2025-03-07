using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TravelManagement.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext using in-memory database
builder.Services.AddDbContext<TravelDbContext>(options =>
    options.UseInMemoryDatabase("TravelDb"));

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Travel Management API",
        Version = "v1",
        Description = "An API for managing airports, clients, and travel bookings"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Travel Management API V1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Seed some initial data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TravelDbContext>();
    
    // Add sample data
    if (!context.Airports.Any())
    {
        context.Airports.AddRange(
            new TravelManagement.Core.Models.Airport { Code = "JFK", Name = "John F. Kennedy International Airport", City = "New York", Country = "USA" },
            new TravelManagement.Core.Models.Airport { Code = "LHR", Name = "London Heathrow Airport", City = "London", Country = "UK" }
        );
        context.SaveChanges();
    }
}

// Print the Swagger URL to the console
Console.WriteLine("Swagger UI is available at: {your-base-url}/swagger");

app.Run(); 