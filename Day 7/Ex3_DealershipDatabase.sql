CREATE DATABASE Dealership;
USE Dealership;

CREATE TABLE Cars (
    id INT IDENTITY(1,1) PRIMARY KEY,
    inventory_number NVARCHAR(50) NOT NULL UNIQUE,
    vehicle_identification_number NVARCHAR(50) NOT NULL UNIQUE,
    make NVARCHAR(50),
    model NVARCHAR(50),
    year INT,
    odometer_reading INT,
    color NVARCHAR(50),
    price DECIMAL(10, 2),
    status NVARCHAR(20) CHECK (status IN ('available', 'sold'))
);

CREATE TABLE Sales (
    id INT IDENTITY(1,1) PRIMARY KEY,
    inventory_number NVARCHAR(50),
    sales_date DATE,
    customer_name NVARCHAR(100),
    customer_phone NVARCHAR(15),
    payment_method NVARCHAR(50),
    payment_amount DECIMAL(10, 2),
    FOREIGN KEY (inventory_number) REFERENCES Cars(inventory_number)
);

INSERT INTO Cars (inventory_number, vehicle_identification_number, make, model, year, odometer_reading, color, price, status)
VALUES
    ('INV001', '1HGBH41JXMN109186', 'Toyota', 'Camry', 2020, 15000, 'Blue', 22000.00, 'available'),
    ('INV002', '1HGCM82633A123456', 'Honda', 'Accord', 2019, 30000, 'Black', 21000.00, 'available'),
    ('INV003', '2T1BURHE0HC121234', 'Ford', 'Focus', 2018, 45000, 'Red', 18000.00, 'sold'),
    ('INV004', '3C4PDCBB6JT123456', 'Chevrolet', 'Malibu', 2017, 60000, 'White', 17000.00, 'available'),
    ('INV005', '1FTEW1E51JKF12345', 'Nissan', 'Altima', 2021, 10000, 'Silver', 23000.00, 'sold');

	INSERT INTO Sales (inventory_number, sales_date, customer_name, customer_phone, payment_method, payment_amount)
VALUES
    ('INV003', '2024-07-20', 'John Doe', '555-1234', 'Credit Card', 18000.00),
    ('INV005', '2024-07-22', 'Jane Smith', '555-5678', 'Cash', 23000.00);




