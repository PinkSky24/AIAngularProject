# Aviation Database Project

This project provides a SQL Server database schema for managing aviation-related data, including countries, airports, and airplanes.

## Project Structure 

## Database Schema

### Tables Overview

1. **Countries**
   - Stores basic country information
   - Primary key: country_id
   - Includes country code and name

2. **Airports**
   - Stores airport information
   - Primary key: airport_id
   - Foreign key to countries table
   - Includes IATA code, name, city, and coordinates

3. **Airplanes**
   - Stores airplane information
   - Primary key: airplane_id
   - Foreign key to airports table (home airport)
   - Includes registration number, model, manufacturer, and capacity

### Table Details

#### Countries Table
```sql
CREATE TABLE countries (
    country_id INT IDENTITY(1,1) PRIMARY KEY,
    country_code CHAR(2) UNIQUE NOT NULL,
    country_name VARCHAR(100) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);
```

#### Airports Table
```sql
CREATE TABLE airports (
    airport_id INT IDENTITY(1,1) PRIMARY KEY,
    iata_code CHAR(3) UNIQUE NOT NULL,
    airport_name VARCHAR(100) NOT NULL,
    city VARCHAR(100) NOT NULL,
    country_id INT NOT NULL,
    latitude DECIMAL(10, 8),
    longitude DECIMAL(11, 8),
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (country_id) REFERENCES countries(country_id)
);
```

#### Airplanes Table
```sql
CREATE TABLE airplanes (
    airplane_id INT IDENTITY(1,1) PRIMARY KEY,
    registration_number VARCHAR(20) UNIQUE NOT NULL,
    model VARCHAR(50) NOT NULL,
    manufacturer VARCHAR(50) NOT NULL,
    capacity INT NOT NULL,
    manufacturing_year INT,
    home_airport_id INT,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (home_airport_id) REFERENCES airports(airport_id)
);
```

## Sample Data

The schema includes sample data for:
- 6 countries (US, UK, France, Germany, Japan, Canada)
- 6 major airports (one in each country)
- 6 airplanes (one based at each airport)

## Usage

### Prerequisites
- Microsoft SQL Server (2016 or later)
- SQL Server Management Studio (SSMS) or another SQL client

### Installation
1. Open SQL Server Management Studio
2. Connect to your SQL Server instance
3. Create a new database
4. Open the `schema.sql` file
5. Execute the script

### Example Queries

#### Get all airports in a country
```sql
SELECT a.airport_name, a.city, c.country_name
FROM airports a
JOIN countries c ON a.country_id = c.country_id
WHERE c.country_code = 'US';
```

#### Get all airplanes at an airport
```sql
SELECT p.registration_number, p.model, a.airport_name
FROM airplanes p
JOIN airports a ON p.home_airport_id = a.airport_id
WHERE a.iata_code = 'JFK';
```

## Development Process

### Prompts Used

1. Initial schema creation prompt:
```
Create a sql script for creating of table, relationship and load a dummy data 
It should support crud of countries, airports and airplane
Also create a README.md as documentation
```

2. SQL Server compatibility prompt:
```
Add Canada as country and the script should be ready for sql server
```

### Key Changes Made
- Converted PostgreSQL SERIAL to SQL Server IDENTITY(1,1)
- Changed TIMESTAMP to DATETIME
- Changed CURRENT_TIMESTAMP to GETDATE()
- Changed INTEGER to INT
- Added Canada-related sample data

## Data Types Used

- **INT**: For ID fields and numeric values
- **CHAR(2)**: For country codes (ISO 3166-1 alpha-2)
- **CHAR(3)**: For IATA airport codes
- **VARCHAR**: For names and other text fields
- **DECIMAL**: For geographic coordinates
- **DATETIME**: For timestamps

## Relationships

1. **Airports → Countries**
   - Many-to-One relationship
   - Each airport belongs to one country
   - Foreign key: airports.country_id → countries.country_id

2. **Airplanes → Airports**
   - Many-to-One relationship
   - Each airplane has one home airport
   - Foreign key: airplanes.home_airport_id → airports.airport_id

## Contributing

To contribute to this project:
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## License

This project is available under the MIT License. 
