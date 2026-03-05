CREATE DATABASE StoreDB
USE StoreDB
---CUSTOMER TABLE--
CREATE TABLE Customers(
   CustId INT IDENTITY(1,1) PRIMARY KEY,
   FirstName VARCHAR(50),
   LastName VARCHAR(50)
)

INSERT INTO Customers VALUES ('Rohini','Chowdary');
INSERT INTO Customers VALUES ('Rekha','Chowdary');
INSERT INTO Customers VALUES ('Pavan','Kumar')
INSERT INTO Customers VALUES ('Seetha','Ram')
INSERT INTO Customers VALUES ('Venkata','Sheshadri')

--ORDER TABLE--
CREATE TABLE Orders(
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    CustId INT,
    [Order Date] DATE,
    [Order Status] INT,
    [Store Name] VARCHAR(50),
    FOREIGN KEY (CustId) REFERENCES Customers(CustId)
);

INSERT INTO Orders VALUES
(1, '2024-01-10', 1, 'Hyderabad'),
(2, '2024-01-12', 4, 'Chennai'),
(3, '2024-01-15', 1, 'Hyderabad'),
(4, '2024-01-18', 4, 'Bangalore'),
(5, '2024-01-20', 1, 'Chennai');

--BRANDS--

CREATE TABLE Brands(
   [Brand ID] INT IDENTITY(1,1) PRIMARY KEY,
   [Brand Name] VARCHAR(50)
)

INSERT INTO Brands VALUES
('Nike'),
('Adidas'),
('Puma');
INSERT INTO Brands VALUES('Gucci');

--CATEGORY--

CREATE TABLE Cateory(
   [Category ID] INT IDENTITY(1,1) PRIMARY KEY,
   [Category Name] VARCHAR(50)
)

INSERT INTO Cateory VALUES
('Shoes'),
('Clothing'),
('Bags');

---STORES  TabLE--
CREATE TABLE Stores(
  StoreID INT IDENTITY(1,1) PRIMARY KEY,
  STOREName VARCHAR(50)
)

INSERT INTO Stores VALUES 
('Hyderabad'),
('Bangalore'),
('Chennai');

---------------------
--PRODUCTS  TABLE--
---------------------

CREATE TABLE Products(
    ProductID INT IDENTITY(1,1) PRIMARY KEY,
    ProducName VARCHAR(100) NOT NULL,
    BrandID INT,
    CategoryID INT,
    ModelYear INT,
    ListPrice DECIMAL(10,2),
    FOREIGN KEY (BrandID) REFERENCES Brands([Brand ID]),
    FOREIGN KEY (CategoryID) REFERENCES Cateory([Category ID])
);
INSERT INTO Products VALUES ('Nike Air Max',1,1,2023,1200);
INSERT INTO Products VALUES
('Adidas Runner',2,1,2022,950),
('Puma T-Shirt',3,2,2023,600),
('Gucci Bag',4,3,2024,2500);

-------------------------
-- ORDER ITEMS TABLE
-------------------------
CREATE TABLE OrderItems(
   ItemID INT IDENTITY(1,1) PRIMARY KEY,
   OrderID INT,
   ProductID INT,
   Quantity INT,
   ListPrice DECIMAL(10,2),
   Discount DECIMAL(4,2),
   FOREIGN KEY (OrderID) REFERENCES Orders(OrderId),
   FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
)

INSERT INTO OrderItems VALUES
(1,1,2,1200,0.10),
(2,2,1,950,0.05),
(3,3,3,600,0),
(4,4,1,2500,0.15),
(5,2,2,950,0.05);

-------------------------
-- STOCKS TABLE
-------------------------
CREATE TABLE Stocks(
   StockID INT IDENTITY(1,1) PRIMARY KEY,
   StoreID INT,
   ProductID INT,
   Quantity INT,
   FOREIGN KEY (StoreID) REFERENCES Stores(StoreID),
   FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
)

INSERT INTO Stocks VALUES
(1,1,50),
(1,2,40),
(2,3,30),
(3,4,20);

--Problem-01---
--------------------
--1. Retrieve customer first name, last name, order_id, order_date, and order_status.
--2. Display only orders with status Pending (1) or Completed (4).
--3. Sort the results by order_date in descending order.
--------------------

SELECT c.FirstName,c.LastName,o.OrderId,o.[Order Date],o.[Order Status] FROM Customers c INNER JOIN Orders o 
  ON c.CustId=o.CustId
  WHERE o.[Order Status]=1 OR o.[Order Status]=4
  ORDER BY o.[Order Date] DESC;


  ---PROBLEM-02---
--------------------------------
📌 Requirements
--1. Display product_name, brand_name, category_name, model_year, and list_price.
--2. Filter products with list_price greater than 500.
--3. Sort results by list_price in ascending order.
--------------------------------

SELECT p.ProducName,b.[Brand Name],c.[Category Name],p.ModelYear,p.ListPrice 
   FROM Products p INNER JOIN Brands b
     ON p.BrandID =b.[Brand ID] INNER JOIN Cateory c
       ON p.CategoryID=c.[Category ID]   
       WHERE p.ListPrice > 500 
         ORDER BY p.ListPrice ASC 

----PROBLEM-03----
------------------------------------------
--1. Display store_name and total sales amount.
--2. Calculate total sales using (quantity * list_price * (1 - discount)).
--3. Include only completed orders (order_status = 4).
--4. Group results by store_name.
--5. Sort total sales in descending order.

---------------------------------------------

SELECT  s.STOREName [Store Name], SUM (OI.Quantity * OI.ListPrice *( 1 - OI.Discount)) [Total Sales Amount]
FROM Stores s 
INNER JOIN Orders o
       ON s.STOREName =o.[Store Name] 
INNER JOIN OrderItems OI
       ON o.OrderId=oi.OrderID
WHERE o.[Order Status]=4
GROUP BY s.STOREName
ORDER BY [Total Sales Amount] DESC

-----------------------------------
----PROBLEM-04-----
--1. Display product_name, store_name, available stock quantity, and total quantity sold.
--2. Include products even if they have not been sold (use appropriate join).
--3. Group results by product_name and store_name.
--4. Sort results by product_name.
------------------------------------

SELECT 
    p.ProducName,
    s.STOREName,
    st.Quantity AS [Available Stock],
    SUM(oi.Quantity) AS [Total Quantity Sold]
FROM Stocks st
INNER JOIN Products p
       ON st.ProductID = p.ProductID
INNER JOIN Stores s
       ON st.StoreID = s.StoreID
LEFT JOIN OrderItems oi
       ON p.ProductID = oi.ProductID
GROUP BY 
       p.ProducName,
       s.STOREName,
       st.Quantity
ORDER BY 
       p.ProducName;
