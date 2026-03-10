USE RetailDB

/* 
Auto retail company wants to ensure stock consistency while placing orders. Whenever an order is placed, stock should reduce automatically and transaction should rollback if stock is insufficient.

- Write a transaction to insert data into orders and order_items tables.
- Check stock availability before confirming order.
- Create a trigger to reduce stock quantity after order insertion.
- Rollback transaction if stock quantity is insufficient.

*/

-- Trigger to automatically reduce stock after order item insertion
CREATE TRIGGER trg_ReduceStock 
ON Order_Items
AFTER INSERT 
AS
BEGIN 
     --  Check if requested quantity is more than available stock
     IF EXISTS(
     SELECT 1
     FROM Stocks s JOIN inserted i
     ON s.product_id=i.product_id
     WHERE s.quantity<i.quantity
     )

     --if stockis insufficient
     BEGIN 
          RAISERROR('Insufficient Stock',16,1) 
          ROLLBACK TRANSACTION
          RETURN
     END
     --If stock is sufficinet reduce the stock quantity
     UPDATE s
     SET s.quantity=s.quantity-i.quantity
     FROM Stocks s JOIN inserted i
     ON s.product_id=i.product_id
END

--Trandaction to palce an order
--TRY block handles susseful execution
BEGIN TRY
BEGIN TRANSACTION

      --INSERT new Order
      INSERT INTO Orders(store_id,order_status) VALUES(1,1)

      --GET THE LAST INSERTED order_id
      DECLARE @OrderID INT
      SET @OrderID=SCOPE_IDENTITY()

      ---- Insert order items
      INSERT INTO Order_Items(order_id,product_id,quantity,price)
      VALUES (@OrderID,1,2,60000), (@OrderID,3,1,3000)

      -- Save changes permanently
      COMMIT TRANSACTION

      PRINT 'Order Placed Successfulyy'
END TRY
BEGIN CATCH
     -- If any error occurs rollback transaction
     ROLLBACK TRANSACTION

     PRINT 'Order Failed Due to Insufficient Stock'
END CATCH

SELECT * FROM Stocks


/* 
When cancelling an order, system must restore stock quantities and update order_status to Rejected (3). All actions must be atomic.
📌 Requirements 
- Begin a transaction when cancelling an order.
- Restore stock quantities based on order_items.
- Update order_status to 3.
- Use SAVEPOINT before stock restoration.
- If stock restoration fails, rollback to SAVEPOINT.
- Commit transaction only if all operations succeed
*/

-- Step 1: Choose order to cancel
DECLARE @OrderID INT=1

-- Step 2: TRY block for safe execution
BEGIN TRY
        -- Step 3: Start transaction
        BEGIN TRANSACTION

        -- Step 4: Create savepoint
        SAVE TRANSACTION BeforeStockRestore
        -- Step 5: Restore stock
        UPDATE s
        SET s.quantity = s.quantity + oi.quantity
        FROM Stocks s
        JOIN Order_Items oi
        ON s.product_id = oi.product_id
        WHERE oi.order_id = @OrderID

        -- Step 6: Update order status to Rejected (3)
        UPDATE Orders
        SET order_status = 3
        WHERE order_id = @OrderID

        -- Step 7: Save changes permanently
        COMMIT TRANSACTION

    PRINT 'Order Cancelled Successfully'
END TRY

--IF ERROR OCCURS
BEGIN CATCH
     ROLLBACK TRANSACTION BeforeStockRestore

     PRINT 'Error occured while cancelling order'
END CATCH

SELECT * FROM Stocks;
SELECT * FROM Orders;
