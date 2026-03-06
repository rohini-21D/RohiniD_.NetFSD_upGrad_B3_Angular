--- Create EcommDb and all tables using the provided schema.

CREATE DATABASE EcommDB
USE EcommDB

CREATE TABLE Categories(
category_id INT PRIMARY KEY IDENTITY(1,1),
category_name VARCHAR(50),
description VARCHAR(100)
);

CREATE TABLE Brands(
brand_id INT PRIMARY KEY IDENTITY(1,1),
brand_name VARCHAR(50)
);

CREATE TABLE Products(
product_id INT PRIMARY KEY IDENTITY(1,1),
product_name VARCHAR(50),
brand_id INT,
category_id INT,
model_year INT,
list_price DECIMAL(10,2),
FOREIGN KEY (brand_id) REFERENCES Brands(brand_id),
FOREIGN KEY (category_id) REFERENCES Categories(category_id)
);

CREATE TABLE Customers(
customer_id INT PRIMARY KEY IDENTITY(1,1),
first_name VARCHAR(50),
last_name VARCHAR(50),
city VARCHAR(50),
email VARCHAR(50)
);

CREATE TABLE Stores(
store_id INT PRIMARY KEY IDENTITY(1,1),
store_name VARCHAR(50),
city VARCHAR(50),
state VARCHAR(50)
);

CREATE TABLE Staffs(
staff_id INT PRIMARY KEY IDENTITY(1,1),
staff_name VARCHAR(50),
store_id INT,
FOREIGN KEY (store_id) REFERENCES Stores(store_id)
);

CREATE TABLE Orders(
order_id INT PRIMARY KEY IDENTITY(1,1),
customer_id INT,
store_id INT,
staff_id INT,
order_date DATE,
FOREIGN KEY(customer_id) REFERENCES Customers(customer_id),
FOREIGN KEY(store_id) REFERENCES Stores(store_id),
FOREIGN KEY(staff_id) REFERENCES Staffs(staff_id)
);

--Insert at least 5 records in categories, brands, products, customers, and stores.

INSERT INTO Categories(category_name,description) VALUES
('SUV','Sports Utility Vehicle'),
('Sedan','Comfort passenger cars'),
('Truck','Heavy duty vehicles'),
('Electric','Electric powered vehicles'),
('Sports','High performance cars');  

INSERT INTO Brands(brand_name) VALUES
('Toyota'),
('Hyundai'),
('Tesla'),
('Mahindra'),
('Honda');

INSERT INTO Products(product_name,brand_id,category_id,model_year,list_price) VALUES
('Creta',2,1,2023,18000),
('City',5,2,2022,20000),
('Fortuner',1,1,2023,45000),
('Thar',4,1,2024,25000),
('CyberTruck',3,3,2024,70000),
('Model S',3,4,2023,80000),
('Innova',1,2,2022,30000);

INSERT INTO Customers(first_name,last_name,city,email) VALUES
('Rohini','Dabbara','Hyderabad','rohini@gmail.com'),
('Pavan','Kumar','Delhi','pavan@gmail.com'),
('Rekha','Chowdary','Mumbai','rekha@gmail.com'),
('Seetha','Ram','Hyderabad','seetha@gmail.com'),
('Arjun','Reddy','Chennai','arjun@gmail.com');

INSERT INTO Stores(store_name,city,state) VALUES
('Hyderabad Store','Hyderabad','Telangana'),
('Delhi Store','Delhi','Delhi'),
('Mumbai Store','Mumbai','Maharashtra'),
('Chennai Store','Chennai','Tamil Nadu'),
('Bangalore Store','Bangalore','Karnataka');  

INSERT INTO Staffs(staff_name,store_id) VALUES
('Raj',1),
('Amit',1),
('Priya',2),
('Karan',3),
('Sneha',4);

INSERT INTO Orders(customer_id,store_id,staff_id,order_date) VALUES
(1,1,1,'2024-01-10'),
(2,2,3,'2024-02-15'),
(3,3,4,'2024-03-20'),
(4,1,2,'2024-04-05'),
(5,4,5,'2024-05-11');


--Problem 1: Basic Setup and Data Retrieval in EcommDb

SELECT * FROM Products
SELECT * FROM Categories

--Write SELECT queries to retrieve all products with their brand and category names.
SELECT p.product_name Products,b.brand_name BrandName,c.category_name 
FROM Brands b 
INNER JOIN Products p ON b.brand_id=p.brand_id
INNER JOIN Categories c ON c.category_id=p.category_id

--- Retrieve all customers from a specific city.
SELECT * FROM Customers
SELECT * FROM Customers WHERE city='Mumbai'

--- Display total number of products available in each category.

SELECT c.category_name Categpries,COUNT(p.product_id) AS TotalProducts
FROM Categories c LEFT JOIN Products p ON c.category_id=p.category_id
GROUP BY c.category_name


--Problem 2: Creating Views and Indexes for Performance

-- Create a view that shows product name, brand name, category name, model year and list price.

CREATE VIEW Product_View AS
SELECT p.product_name [PRODUCT NAME],b.brand_name [Brand Name],c.category_name [Category Name],p.model_year [Model Year],p.list_price[List Price]
FROM Products p 
JOIN Brands b ON p.brand_id=b.brand_id
JOIN Categories c ON c.category_id=p.category_id ;

SELECT * FROM Product_View

--- Create a view that shows order details with customer name, store name and staff name.

CREATE VIEW Order_View AS
SELECT 
o.order_id,
c.first_name + ' ' + c.last_name AS customer_name,
s.store_name,
st.staff_name,
o.order_date
FROM Orders o
JOIN Customers c ON o.customer_id=c.customer_id
JOIN Stores s ON o.store_id=s.store_id
JOIN Staffs st ON o.staff_id=st.staff_id;

SELECT * FROM Order_View

---Create appropriate indexes on foreign key columns.
CREATE INDEX idx_products_brand
ON Products(brand_id);

CREATE INDEX idx_products_category
ON Products(category_id);

CREATE INDEX idx_orders_customer
ON Orders(customer_id);

CREATE INDEX idx_orders_store
ON Orders(store_id);
