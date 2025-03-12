# Travel Management API

This project is a RESTful API built with ASP.NET Core that manages airports, clients, and travel bookings using an in-memory database.

## Prompt
Create a C# project with three endpoints using an in-memory database. The endpoints should include:

Airport Endpoint (CRUD operations)
Client Endpoint (CRUD operations)
Travel Endpoint (CRUD operations for travel with client and airport information)
Additionally, the project should include:

Unit tests for all endpoints using the xUnit framework.
End-to-end integration tests (booking travel, editing travel, deleting travel, getting travel by flight).
Swagger setup for manual testing.
Detailed documentation in a README.md file.
Detailed Requirements:

Endpoints:
Airport Endpoint:
Create, Read, Update, Delete operations for airport data.
Client Endpoint:
Create, Read, Update, Delete operations for client data.
Travel Endpoint:
Create, Read, Update, Delete operations for travel data, including client and airport information.
Unit Tests:

Use the xUnit framework to create unit tests for all endpoints.
Ensure tests cover all CRUD operations.
Integration Tests:

Create end-to-end integration tests for the following scenarios:
Booking travel
Editing travel
Deleting travel
Getting travel by flight
Swagger Setup:

Configure Swagger for the project to enable manual testing of endpoints.

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
