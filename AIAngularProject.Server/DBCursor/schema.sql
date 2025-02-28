-- Create Countries table
CREATE TABLE countries (
    country_id INT IDENTITY(1,1) PRIMARY KEY,
    country_code CHAR(2) UNIQUE NOT NULL,
    country_name VARCHAR(100) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    updated_at DATETIME DEFAULT GETDATE()
);

-- Create Airports table
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

-- Create Airplanes table
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

-- Insert sample data for Countries
INSERT INTO countries (country_code, country_name) VALUES
('US', 'United States'),
('GB', 'United Kingdom'),
('FR', 'France'),
('DE', 'Germany'),
('JP', 'Japan'),
('CA', 'Canada');

-- Insert sample data for Airports
INSERT INTO airports (iata_code, airport_name, city, country_id, latitude, longitude) VALUES
('JFK', 'John F. Kennedy International Airport', 'New York', 1, 40.6413, -73.7781),
('LHR', 'London Heathrow Airport', 'London', 2, 51.4700, -0.4543),
('CDG', 'Charles de Gaulle Airport', 'Paris', 3, 49.0097, 2.5479),
('FRA', 'Frankfurt Airport', 'Frankfurt', 4, 50.0379, 8.5622),
('HND', 'Haneda Airport', 'Tokyo', 5, 35.5494, 139.7798),
('YYZ', 'Toronto Pearson International Airport', 'Toronto', 6, 43.6777, -79.6248);

-- Insert sample data for Airplanes
INSERT INTO airplanes (registration_number, model, manufacturer, capacity, manufacturing_year, home_airport_id) VALUES
('N123AA', 'Boeing 787-9', 'Boeing', 290, 2019, 1),
('G-XWBA', 'Airbus A350-1000', 'Airbus', 350, 2020, 2),
('F-HRBA', 'Airbus A320neo', 'Airbus', 180, 2018, 3),
('D-AIMC', 'Boeing 737-800', 'Boeing', 189, 2017, 4),
('JA123A', 'Boeing 777-300ER', 'Boeing', 400, 2016, 5),
('C-FGPT', 'Boeing 787-9', 'Boeing', 298, 2021, 6); 