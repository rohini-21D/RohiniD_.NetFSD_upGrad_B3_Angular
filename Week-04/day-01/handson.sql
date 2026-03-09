CREATE DATABASE SalesManagementDB
Go
USE SalesManagementDB

CREATE TABLE Stores(
    store_id INT PRIMARY KEY IDENTITY(1,1),
    store_name VARCHAR(100),
    city VARCHAR(50)
)

CREATE TABLE Products(
    product_id INT PRIMARY KEY IDENTITY(1,1),
    product_name VARCHAR(100),
    price DECIMAL(10,2)
)

CREATE TABLE Stocks(
    stock_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT FOREIGN KEY REFERENCES Stores(store_id),
    product_id INT FOREIGN KEY REFERENCES Products(product_id),
    quantity INT,
);

CREATE TABLE Orders(
    order_id INT PRIMARY KEY IDENTITY(1,1),
    store_id INT FOREIGN KEY REFERENCES Stores(store_id),
    order_date DATE,
    shipped_date DATE,
    order_status INT,  -- 1=Pending, 2=Processing, 3=Shipped, 4=Completed 
);


CREATE TABLE Order_Items(
    item_id INT PRIMARY KEY IDENTITY(1,1),
    order_id INT FOREIGN KEY REFERENCES Orders(order_id),
    product_id INT FOREIGN KEY REFERENCES Products(product_id),
    quantity INT,
    list_price DECIMAL(10,2),
    discount DECIMAL(5,2),
);

INSERT INTO Stores VALUES
('Hyderabad Store','Hyderabad'),
('Bangalore Store','Bangalore'),
('Chennai Store','Chennai');

INSERT INTO Products VALUES
('Laptop',50000),
('Mobile',20000),
('Headphones',2000),
('Keyboard',1500),
('Mouse',800);

INSERT INTO Stocks(store_id,product_id,quantity) VALUES
(1,1,20),
(1,2,50),
(1,3,100),
(2,1,15),
(2,2,40),
(3,3,70),
(3,4,60),
(3,5,90);

INSERT INTO Orders(store_id,order_date,shipped_date,order_status) VALUES
(1,'2026-03-01','2026-03-03',4),
(2,'2026-03-02','2026-03-04',4),
(3,'2026-03-05',NULL,1);

INSERT INTO Order_Items(order_id,product_id,quantity,list_price,discount) VALUES
(1,1,1,50000,10),
(1,3,2,2000,5),
(2,2,1,20000,8),
(2,5,3,800,2);

---------------
--PROBLEM_01
---------------
--The company requires reusable database logic to generate reports such as total sales per store and discounted order totals.

--Create a stored procedure to generate total sales amount per store.

ALTER PROCEDURE sp_TotalSalesAmountPerStore
AS
BEGIN
   SELECT s.store_id,s.store_name,
   CAST(SUM(oi.quantity*oi.list_price*(1-oi.discount/100)) AS DECIMAL(10,2)) AS TotalSalesAmountPerStore
   FROM Stores s 
   JOIN Orders o ON s.store_id=o.store_id           
   JOIN Order_Items oi ON oi.order_id=o.order_id
   WHERE o.order_status=4
   GROUP BY s.store_id,s.store_name 
END

EXEC sp_TotalSalesAmountPerStore

-- Create a stored procedure to retrieve orders by date range.
CREATE PROCEDURE sp_GetOrderByDateRange
   @starDate DATE,
   @endDate DATE
AS
BEGIN
     SELECT o.order_id,s.store_name,o.order_date,o.shipped_date,o.order_status
     FROM Orders o JOIN Stores s ON o.store_id=s.store_id
     WHERE o.order_date BETWEEN @starDate AND @endDate
END

EXEC sp_GetOrderByDateRange
    @starDate='2026-03-01',
    @endDate='2026-03-03'

-- Create a scalar function to calculate total price after discount.

CREATE FUNCTION fn_FinalPrice(
    @price DECIMAL(10,2),
    @discount DECIMAL(5,2)
)
RETURNS DECIMAL(10,2)
AS
BEGIN
     DECLARE @FinalPrice DECIMAL(10,2)
     SET @FinalPrice=@price - (@price * @discount/100)
     RETURN @FinalPrice
END

SELECT product_id,
       list_price,
       discount,
       dbo.fn_FinalPrice(list_price,discount) FinalPrice 
FROM Order_Items

--Create a table-valued function to return top 5 selling products.

CREATE FUNCTION dbo.TopSellingProducts()
RETURNS TABLE 
AS
RETURN
(
   SELECT TOP 5 
       p.product_name,SUM(oi.quantity) AS TotalSold
   FROM Products p JOIN Order_Items oi ON p.product_id=oi.product_id
   GROUP BY(p.product_name)
   ORDER BY TotalSold DESC
)

SELECT * FROM dbo.TopSellingProducts()


-------------------------------
-----PROBLEM-02
-----------------------
---Whenever a new record is inserted into order_items, the stock quantity in the stocks table must automatically decrease based on the ordered quantity.
--- Create an AFTER INSERT trigger on order_items.
--Reduce the corresponding quantity in stocks table.
-- Prevent stock from becoming negative.
-- If stock is insufficient, rollback the transaction with a custom error message.


CREATE TRIGGER UpdateStock
ON Order_Items
AFTER INSERT
AS
BEGIN

-- Check if stock is sufficient
IF EXISTS (
    SELECT 1
    FROM Stocks s
    JOIN inserted i 
        ON s.product_id = i.product_id
    WHERE s.quantity < i.quantity
)
BEGIN
    PRINT 'Insufficient Stock'
    ROLLBACK TRANSACTION
    RETURN
END

-- Update stock
UPDATE s
SET s.quantity = s.quantity - i.quantity
FROM Stocks s
JOIN inserted i
    ON s.product_id = i.product_id

END


INSERT INTO Order_Items(order_id,product_id,quantity,list_price,discount)
VALUES(3,3,10,50000,5)

SELECT * FROM Stocks

--------------
--PROBLEM-03
--------------

--Before updating order_status in orders table, ensure that shipped_date is not NULL when status is set to Completed (4).
--📌 Requirements 
--- Create an AFTER UPDATE trigger on orders.
--- Validate that shipped_date is NOT NULL when order_status = 4.
--- Prevent update if condition fails.

CREATE TRIGGER OrderValidation
ON Orders
AFTER UPDATE
AS
BEGIN

BEGIN TRY

IF EXISTS
(
   SELECT 1
   FROM inserted
   WHERE order_status=4
   AND shipped_date IS NULL
)
BEGIN 
    PRINT 'Shipped Date Cannot be null when order is completed'
    ROLLBACK TRANSACTION
END

END TRY

BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH

END

UPDATE Orders
SET order_status=4 WHERE order_id=3

SELECT * FROM Orders

-------------
--PROBLEM-04
-------------

--Management wants a detailed revenue calculation per store by iterating through completed orders and calculating total revenue including discounts.
--- Use a cursor to iterate through completed orders (order_status = 4).
-- Calculate total revenue per order using order_items.
-- Store computed revenue in a temporary table.
-- Display store-wise revenue summary.

DECLARE @order_id INT
DECLARE @store_id INT
DECLARE @revenue DECIMAL(12,2)
CREATE TABLE #RevenueTemp
(
    store_id INT,
    revenue DECIMAL(12,2)
)

DECLARE order_cursor CURSOR
FOR
SELECT order_id, store_id
FROM Orders
WHERE order_status = 4

OPEN order_cursor

FETCH NEXT FROM order_cursor INTO @order_id, @store_id

WHILE @@FETCH_STATUS = 0
BEGIN

    SELECT @revenue =
    SUM(quantity * list_price * (1 - discount/100.0))
    FROM Order_Items
    WHERE order_id = @order_id

    INSERT INTO #RevenueTemp VALUES(@store_id,@revenue)

    FETCH NEXT FROM order_cursor INTO @order_id, @store_id

END

CLOSE order_cursor
DEALLOCATE order_cursor


SELECT store_id,
       SUM(revenue) AS TotalRevenue
FROM #RevenueTemp
GROUP BY store_id
