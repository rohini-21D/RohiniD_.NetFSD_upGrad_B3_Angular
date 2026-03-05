CREATE DATABASE AutoRetailDB;
USE AutoRetailDB;
--categories have many products
CREATE TABLE Category(
   category_id INT PRIMARY KEY IDENTITY(1,1),
   category_name VARCHAR(50) NOT NULL,
   description VARCHAR(100)
)

INSERT INTO Category VALUES
('Sedan','Comfort passenger cars'),
('SUV','Sports Utility Vehicles'),
('Truck','Heavy duty transport vehicles'),
('Electric','Electric powered vehicles');

SELECT * FROM Category

CREATE TABLE Products(
   product_id INT PRIMARY KEY IDENTITY(1,1),
   product_name VARCHAR(50) NOT NULL,
   category_id INT FOREIGN KEY REFERENCES Category(category_id),
   model_year INT NOT NULL,
   list_price DECIMAL(10,2)
)

INSERT INTO Products (product_name,category_id,model_year,list_price) VALUES
('Honda City',1,2022,12000),
('Hyundai Verna',1,2023,15000),
('Toyota Fortuner',2,2023,45000),
('Mahindra Scorpio',2,2022,35000),
('Tata Ace Truck',3,2021,20000),
('Ashok Leyland Truck',3,2022,40000),
('Tesla Model 3',4,2023,55000),
('Tata Nexon EV',4,2023,30000);


CREATE TABLE Customers(
   customer_id INT PRIMARY KEY IDENTITY(1,1),
   first_name VARCHAR(50) NOT NULL,
   last_name VARCHAR(50) NOT NULL,
   email VARCHAR(50) NOT NULL,
   phone VARCHAR(10) NOT NULL
)

INSERT INTO Customers (first_name,last_name,email,phone) VALUES
('Ravi','Kumar','ravi@gmail.com','9876543210'),
('Anita','Sharma','anita@gmail.com','9876543211'),
('John','David','john@gmail.com','9876543212'),
('Priya','Reddy','priya@gmail.com','9876543213');


CREATE TABLE Stores( 
   store_id INT PRIMARY KEY IDENTITY(1,1),
   store_name VARCHAR(100) NOT NULL,
   city VARCHAR(100),
   state VARCHAR(100)
)

INSERT INTO Stores (store_name,city,state) VALUES
('AutoWorld','Hyderabad','Telangana'),
('CarHub','Bangalore','Karnataka'),
('DriveZone','Chennai','Tamil Nadu'),
('SpeedMotors','Mumbai','Maharashtra');

CREATE TABLE Orders(
   order_id INT PRIMARY KEY IDENTITY(1,1),
   customer_id INT FOREIGN KEY REFERENCES Customers(customer_id),
   store_id INT FOREIGN KEY REFERENCES Stores(store_id),
   order_status INT ,
   order_date DATE,
   required_date DATE,
   shipped_date DATE
)

INSERT INTO Orders (customer_id,store_id,order_status,order_date,required_date,shipped_date) VALUES
(1,1,1,'2023-01-10','2023-01-15','2023-01-12'),
(2,2,1,'2023-02-05','2023-02-10','2023-02-08'),
(3,1,2,'2023-03-01','2023-03-06','2023-03-05'),
(1,3,3,'2022-01-10','2022-01-15','2022-01-20');

CREATE TABLE Order_Items(
   order_item_id INT PRIMARY KEY IDENTITY(1,1),
   order_id INT FOREIGN KEY REFERENCES Orders(order_id),
   product_id INT FOREIGN KEY REFERENCES Products(product_id),
   quantity INT NOT NULL,
   list_price DECIMAL(10,2),
   discount DECIMAL(10,2)
)

INSERT INTO Order_Items (order_id,product_id,quantity,list_price,discount) VALUES
(1,1,1,12000,500),
(1,2,1,15000,500),
(2,3,1,45000,1000),
(3,4,1,35000,500),
(4,5,2,20000,1000);


CREATE TABLE Stocks(
   store_id INT FOREIGN KEY REFERENCES Stores(store_id),
   product_id INT FOREIGN KEY REFERENCES Products(product_id),
   quantity INT NOT NULL
)

INSERT INTO Stocks (store_id,product_id,quantity) VALUES
(1,1,10),
(1,2,5),
(2,3,3),
(3,4,0),
(2,5,7),
(3,6,4),
(4,7,2),
(4,8,6);

CREATE TABLE Archived_Orders(
   archive_id INT PRIMARY KEY IDENTITY(1,1),
   order_id INT ,
   customer_id INT ,
   order_date DATE,
   order_status INT
)

INSERT INTO Archived_Orders (order_id,customer_id,order_date,order_status) VALUES
(5,2,'2021-01-10',3),
(6,3,'2021-02-15',3);

---PROBLEM-01
---1. Retrieve product details (product_name, model_year, list_price).
---2. Compare each product’s price with the average price of products in the same category using a nested query.
---3. Display only those products whose price is greater than the category average.
---4. Show calculated difference between product price and category average.
---5. Concatenate product name and model year as a single column (e.g., 'ProductName (2017)').

SELECT 
CONCAT(product_name,' (',model_year,')') AS ProductDetails,
list_price,

CAST(
       list_price -
       (SELECT AVG(list_price)
        FROM Products p2
        WHERE p2.category_id = p1.category_id)
     AS DECIMAL(10,2)) AS Difference

FROM Products p1

WHERE list_price >
(
    SELECT AVG(list_price)
    FROM Products p2
    WHERE p2.category_id = p1.category_id
);

-------------------------------------------------------------------------------
------Problem-02
--1. Use nested query to calculate total order value per customer.
--2. Classify customers using conditional logic:
--   - 'Premium' if total order value > 10000
--   - 'Regular' if total order value between 5000 and 10000
--   - 'Basic' if total order value < 5000
--3. Use UNION to display customers with orders and customers without orders.
--4. Display full name using string concatenation.
--5. Handle NULL cases appropriately.
---------------------------------------------------------------------------------
SELECT 
CONCAT(first_name,' ',last_name) AS FullName,
customer_id,

CASE 
    WHEN (
        SELECT SUM(quantity*list_price)
        FROM Order_Items oi 
        JOIN Orders o ON oi.order_id = o.order_id
        WHERE o.customer_id = c.customer_id
    ) > 10000 THEN 'Premium'

    WHEN (
        SELECT SUM(quantity*list_price)
        FROM Order_Items oi 
        JOIN Orders o ON oi.order_id = o.order_id
        WHERE o.customer_id = c.customer_id
    ) BETWEEN 5000 AND 10000 THEN 'Regular'

    ELSE 'Basic'
END AS Customer_Type

FROM Customers c
WHERE customer_id IN (SELECT customer_id FROM Orders)

UNION

SELECT 
CONCAT(first_name,' ',last_name) AS FullName,
customer_id,
'Basic' AS Customer_Type

FROM Customers
WHERE customer_id NOT IN (SELECT customer_id FROM Orders);
CASE 
     WHEN (SELECT SUM(quantity*list_price) 
        FROM Order_Items oi JOIN Orders o ON oi.order_id=o.order_id
        WHERE o.customer_id= c.customer_id 
        )  >10000 THEN 'Premium'
     WHEN (SELECT SUM(quantity*list_price)
           FROM Order_Items oi JOIN Orders o ON oi.order_id=o.order_id
           WHERE o.customer_id= c.customer_id
        ) BETWEEN 5000 and 10000 THEN 'Regular'
     ELSE 'Basic'
END Customer_Type
FROM Customers c
---------------------------------------------
PROBLEM -03

--1. Identify products sold in each store using nested queries.
--2. Compare sold products with current stock using INTERSECT and EXCEPT operators.
--3. Display store_name, product_name, total quantity sold.
--4. Calculate total revenue per product (quantity × list_price – discount).
--5. Update stock quantity to 0 for discontinued products (simulation).

---------------------------------------------------------------------------------
SELECT 
s.store_name,
p.product_name,
SUM(oi.quantity) AS TotalSold,
SUM(oi.quantity * oi.list_price - oi.discount) AS Revenue

FROM Stores s
JOIN Orders o ON s.store_id = o.store_id
JOIN Order_Items oi ON o.order_id = oi.order_id
JOIN Products p ON oi.product_id = p.product_id

GROUP BY s.store_name, p.product_name


---------------------------------------------------------------------------
PROBLEM-04

---1. Insert archived records into a new table (archived_orders) using INSERT INTO SELECT.
---2. Delete orders where order_status = 3 (Rejected) and older than 1 year.
---3. Use nested query to identify customers whose all orders are completed.
---4. Display order processing delay (DATEDIFF between shipped_date and order_date).
---5. Mark orders as 'Delayed' or 'On Time' using CASE expression based on required_date.

SELECT 
order_id,
order_date,
required_date,
shipped_date,

DATEDIFF(day,order_date,shipped_date) AS Processing_Days,

CASE
    WHEN shipped_date > required_date THEN 'Delayed'
    ELSE 'On Time'
END AS Delivery_Status

FROM Orders
