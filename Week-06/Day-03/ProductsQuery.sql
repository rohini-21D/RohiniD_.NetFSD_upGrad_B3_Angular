CREATE DATABASE Products

USE Products;
GO

CREATE TABLE Products (
    ProductId INT PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10,2)
);

-- INSERT
CREATE PROCEDURE usp_InsertProduct
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Products(ProductName, Category, Price)
    VALUES (@ProductName, @Category, @Price)
END
GO

-- VIEW ALL
CREATE PROCEDURE usp_GetAllProducts
AS
BEGIN
    SELECT * FROM Products
END
GO

-- GET BY ID
CREATE PROCEDURE usp_GetProductById
    @ProductId INT
AS
BEGIN
    SELECT * FROM Products WHERE ProductId = @ProductId
END
GO

-- UPDATE
CREATE PROCEDURE usp_UpdateProduct
    @ProductId INT,
    @ProductName VARCHAR(100),
    @Category VARCHAR(50),
    @Price DECIMAL(10,2)
AS
BEGIN
    UPDATE Products
    SET ProductName = @ProductName,
        Category = @Category,
        Price = @Price
    WHERE ProductId = @ProductId
END
GO

-- DELETE
CREATE PROCEDURE usp_DeleteProduct
    @ProductId INT
AS
BEGIN
    DELETE FROM Products WHERE ProductId = @ProductId
END
GO

SELECT * FROM Products;