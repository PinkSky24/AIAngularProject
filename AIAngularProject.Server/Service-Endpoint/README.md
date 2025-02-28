# is a simple .NET Core Web API for managing airports. It demonstrates basic CRUD operations using an in-memory database and includes Swagger for testing the endpoints.

## All Prompts Used in Project Creation
1. Initial CRUD API Creation:
```
Create a CRUD operation in .net core, c# and database in memory. Add the swagger library for test endpoint.

The CRUD operation should, create airport, get airport, update airport, delete airport. 

Airport should have Id, Name, Country

By default we should have
Id 1, YYZ, Canada
Id 2, YUL, Canada.Create a readme.md with prompt used to create the project, also with a basic information about the project, endpoint, technology.Give me all steps needed and code needed
```

## Issues
Issues with namespace
Did not create files and structure

## Technologies Used

- .NET Core
- C#
- Entity Framework Core (In-Memory Database)
- Swagger

## Endpoints

- `GET /api/airports` - Get all airports
- `GET /api/airports/{id}` - Get an airport by ID
- `POST /api/airports` - Create a new airport
- `PUT /api/airports/{id}` - Update an existing airport
- `DELETE /api/airports/{id}` - Delete an airport

## Default Data

- Id: 1, Name: YYZ, Country: Canada
- Id: 2, Name: YUL, Country: Canada

## How to Run

1. Clone the repository.
2. Navigate to the project directory.
3. Run `dotnet restore` to install dependencies.
4. Run `dotnet run` to start the application.
5. Open a browser and navigate to `http://localhost:5000/swagger` to access the Swagger UI for testing the endpoints.