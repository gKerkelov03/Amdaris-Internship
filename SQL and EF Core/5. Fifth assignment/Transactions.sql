--1. Place an order for a customer
/*BEGIN TRANSACTION PlaceOrder;
DECLARE @CustomerID INT;
DECLARE @ProductID INT;
DECLARE @Quantity INT;

SET @CustomerID = 123;
SET @ProductID = 456; 
SET @Quantity = 5;

INSERT INTO Sales.SalesOrderHeader (CustomerID, OrderDate)
VALUES (@CustomerID, GETDATE());

INSERT INTO Sales.SalesOrderDetail (SalesOrderID, ProductID, OrderQty)
VALUES (SCOPE_IDENTITY(), @ProductID, @Quantity);

UPDATE Production.ProductInventory
SET Quantity = Quantity - @Quantity
WHERE ProductID = @ProductID;

COMMIT TRANSACTION PlaceOrder;
*/



--2. Process return of product
/*BEGIN TRANSACTION ProcessReturn;
DECLARE @SalesOrderID INT;
DECLARE @ProductID INT;
DECLARE @ReturnedQuantity INT;

SET @SalesOrderID = 789; 
SET @ProductID = 456; 
SET @ReturnedQuantity = 2; 

UPDATE Sales.SalesOrderDetail
SET OrderQty = OrderQty - @ReturnedQuantity
WHERE SalesOrderID = @SalesOrderID
  AND ProductID = @ProductID;

UPDATE Production.ProductInventory
SET Quantity = Quantity + @ReturnedQuantity
WHERE ProductID = @ProductID;

COMMIT TRANSACTION ProcessReturn;
*/


--3. Update product price
/*BEGIN TRANSACTION UpdateProductPrice;
DECLARE @ProductID INT;
DECLARE @NewPrice MONEY;

SET @ProductID = 456; 
SET @NewPrice = 29.99; 

UPDATE Production.Product
SET ListPrice = @NewPrice
WHERE ProductID = @ProductID;

COMMIT TRANSACTION UpdateProductPrice;
*/

--4. Mark order as shipped
/*BEGIN TRANSACTION MarkOrderShipped;
DECLARE @SalesOrderID INT;

SET @SalesOrderID = 789; 

UPDATE Sales.SalesOrderHeader
SET Status = 'Shipped'
WHERE SalesOrderID = @SalesOrderID;

COMMIT TRANSACTION MarkOrderShipped;
*/


--5. Transfer an inventory from one warehouse to another
/*BEGIN TRANSACTION TransferInventory;
DECLARE @ProductID INT;
DECLARE @SourceWarehouseID INT;
DECLARE @DestinationWarehouseID INT;
DECLARE @QuantityToTransfer INT;

SET @ProductID = 456; -- Product ID
SET @SourceWarehouseID = 1; -- Source warehouse ID
SET @DestinationWarehouseID = 2; -- Destination warehouse ID
SET @QuantityToTransfer = 50; -- Quantity to transfer

-- Reduce inventory in the source warehouse
UPDATE Production.ProductInventory
SET Quantity = Quantity - @QuantityToTransfer
WHERE ProductID = @ProductID
AND LocationID = @SourceWarehouseID;

-- Increase inventory in the destination warehouse
UPDATE Production.ProductInventory
SET Quantity = Quantity + @QuantityToTransfer
WHERE ProductID = @ProductID
AND LocationID = @DestinationWarehouseID;

COMMIT TRANSACTION TransferInventory;
*/

--6. Assign a new territory to a salesperson
/*BEGIN TRANSACTION AssignTerritory;
DECLARE @SalesPersonID INT;
DECLARE @NewTerritoryID INT;

SET @SalesPersonID = 123; 
SET @NewTerritoryID = 5; 

UPDATE Sales.SalesPerson
SET TerritoryID = @NewTerritoryID
WHERE BusinessEntityID = @SalesPersonID;

COMMIT TRANSACTION AssignTerritory;
*/


--7. Update employee's job title
/*BEGIN TRANSACTION UpdateJobTitle;
DECLARE @EmployeeID INT;
DECLARE @NewJobTitle NVARCHAR(50);

SET @EmployeeID = 789; 
SET @NewJobTitle = 'Senior Sales Person';

UPDATE HumanResources.Employee
SET JobTitle = @NewJobTitle
WHERE BusinessEntityID = @EmployeeID;

COMMIT TRANSACTION UpdateJobTitle;
*/

--8. update Employee hire date
/*
BEGIN TRANSACTION UpdateHireDate;
DECLARE @EmployeeID INT;
DECLARE @NewHireDate DATE;

SET @EmployeeID = 123; 
SET @NewHireDate = '2023-01-01'; 

UPDATE HumanResources.Employee
SET HireDate = @NewHireDate
WHERE BusinessEntityID = @EmployeeID;

COMMIT TRANSACTION UpdateHireDate;
*/