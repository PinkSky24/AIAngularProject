# Travel Management API

This project is a RESTful API built with ASP.NET Core that manages airports, clients, and travel bookings using an in-memory database.

## Features

- CRUD operations for Airports
- CRUD operations for Clients
- CRUD operations for Travel bookings
- Swagger UI for API documentation and testing
- Unit tests using xUnit
- Integration tests for end-to-end scenarios

## Project Structure

```
TravelManagement/
├── src/
│   ├── TravelManagement.API/         # Main API project
│   ├── TravelManagement.Core/        # Domain models and interfaces
│   └── TravelManagement.Infrastructure/  # Data access and implementations
├── tests/
│   ├── TravelManagement.UnitTests/   # Unit tests
│   └── TravelManagement.IntegrationTests/  # Integration tests
└── README.md
```

## Getting Started

1. Clone the repository
2. Open the solution in Visual Studio or your preferred IDE
3. Build the solution
4. Run the API project

## API Endpoints

### Airports
- GET /api/airports - Get all airports
- GET /api/airports/{id} - Get airport by ID
- POST /api/airports - Create new airport
- PUT /api/airports/{id} - Update airport
- DELETE /api/airports/{id} - Delete airport

### Clients
- GET /api/clients - Get all clients
- GET /api/clients/{id} - Get client by ID
- POST /api/clients - Create new client
- PUT /api/clients/{id} - Update client
- DELETE /api/clients/{id} - Delete client

### Travel
- GET /api/travel - Get all travel bookings
- GET /api/travel/{id} - Get travel by ID
- POST /api/travel - Create new travel booking
- PUT /api/travel/{id} - Update travel booking
- DELETE /api/travel/{id} - Delete travel booking

## Testing

### Unit Tests
Run unit tests using:
```bash
dotnet test tests/TravelManagement.UnitTests
```

### Integration Tests
Run integration tests using:
```bash
dotnet test tests/TravelManagement.IntegrationTests
```

## Documentation
API documentation is available through Swagger UI at `/swagger` when running the application. 