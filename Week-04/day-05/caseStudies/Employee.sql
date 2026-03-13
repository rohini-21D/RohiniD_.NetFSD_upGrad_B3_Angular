CREATE DATABASE BookMartOnlineBookstore

USE BookMartOnlineBookstore

CREATE TABLE Books (
    BookID  INT IDENTITY(1,1) PRIMARY KEY,
    Title   NVARCHAR(150) NOT NULL,
    Stock   INT NOT NULL CHECK (Stock >= 0),
    Price   DECIMAL(10,2) NOT NULL
);

CREATE TABLE Orders (
    OrderID    INT IDENTITY(1,1) PRIMARY KEY,
    BookID     INT NOT NULL,
    Quantity   INT NOT NULL CHECK (Quantity > 0),
    OrderDate  DATETIME2 DEFAULT SYSDATETIME(),
    FOREIGN KEY (BookID) REFERENCES Books(BookID)
);
/*BookMart needs a reliable way to place customer orders without overselling books. When a customer orders a book:
•	Check if enough stock is available.
•	If yes → reduce stock and record the order.
•	If no → do not change anything (no partial updates).
*/
--TASK-1:Stored Procedure to Add a Book  

CREATE PROCEDURE sp_AddNewBook 
    @Title NVARCHAR(150),
    @Stock INT,
    @Price DECIMAL(10,2)
AS
BEGIN
BEGIN TRY
         --Validation
         if(@Stock<0)
         BEGIN
              THROW 50001,'Stock is not avilable', 1;
         END
       
        INSERT INTO Books VALUES (@Title,@Stock,@Price)

        PRINT 'Book added Successfully. ';
END TRY

BEGIN CATCH
         
         PRINT 'Error Occured while adding the book. ';
         PRINT ERROR_MESSAGE();
END CATCH

END


EXEC sp_AddNewBook
     @Title= 'SQL Advanced Concepts',
     @Stock= 10,
     @Price =450.00;

EXEC sp_AddNewBook
     @Title= 'C# Advanced Concepts',
     @Stock= 0,
     @Price =450.00;

     DELETE 

SELECT BookID,Title,Stock,Price FROM Books

--Task 2: Main Stored Procedure – Place Order with Transaction  

CREATE PROCEDURE sp_PlaceOrder 
      @BookID INT, @Quantity INT
AS
BEGIN
   	SET XACT_ABORT ON; 
    BEGIN TRY
          BEGIN TRANSACTION;

          DECLARE @Stock INT
          
          SELECT @Stock=Stock  FROM Books
          WHERE BookID=@BookID

          IF @Stock IS NULL
          BEGIN
              RAISERROR('Book not Found.' ,16,1);
          END

          IF @Stock<@Quantity
          BEGIN
               RAISERROR('Not Enough Stock.', 16,1)
          END
          --o	UPDATE Books SET Stock = Stock - @Quantity WHERE BookID = @BookID;
          UPDATE Books 
          SET Stock=Stock - @Quantity 
          WHERE BookID=@BookID;
          --o	INSERT INTO Orders (BookID, Quantity) VALUES (@BookID, @Quantity);

          INSERT INTO Orders(BookID,Quantity)
          VALUES (@BookID,@Quantity)

          COMMIT TRANSACTION
          PRINT 'Order Placed Successfully'

    END TRY
    BEGIN CATCH 
            IF @@TRANCOUNT >0 
                ROLLBACK TRANSACTION

            PRINT 'Error' + CAST(ERROR_NUMBER() AS VARCHAR) + ':' + ERROR_MESSAGE()
    END CATCH
END

EXEC sp_PlaceOrder
    @BookID =1,
    @Quantity=2

    SELECT BookID,Title,Stock,Price FROM Books

--Task 3: Testing & Output  

EXEC sp_AddNewBook 'SQL Basics', 10, 300.00;
EXEC sp_AddNewBook 'C# Programming', 8, 450.00;
EXEC sp_AddNewBook 'Database Design', 5, 500.00;
EXEC sp_AddNewBook 'ASP.NET Core', 7, 600.00;
EXEC sp_AddNewBook 'Advanced SQL', 3, 550.00;

 
EXEC sp_PlaceOrder
    @BookID =3,
    @Quantity=2

EXEC sp_PlaceOrder
    @BookID=2,
    @Quantity=10

EXEC sp_PlaceOrder
    @BookID =25,
    @Quantity=2
