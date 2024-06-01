--1. Customers with orders exceeding the average order value

SELECT     
    p.FirstName,
    p.LastName,
    ph.PhoneNumber,
    soh.TotalDue - (SELECT AVG(TotalDue) FROM Sales.SalesOrderHeader) AS DifferenceFromAverage
FROM 
    Sales.Customer AS c
JOIN 
    Person.Person AS p ON c.PersonID = p.BusinessEntityID
JOIN 
    Person.PersonPhone AS ph ON p.BusinessEntityID = ph.BusinessEntityID
JOIN 
    Sales.SalesOrderHeader AS soh ON c.CustomerID = soh.CustomerID
WHERE 
    soh.TotalDue > (SELECT AVG(TotalDue) FROM Sales.SalesOrderHeader)
ORDER BY 
    c.CustomerID;

--2. Employees with above average salaries
SELECT 
    
    p.FirstName,
    p.LastName,
    ph.PhoneNumber
FROM 
    HumanResources.Employee AS e
JOIN 
    HumanResources.EmployeePayHistory AS r ON e.BusinessEntityID = r.BusinessEntityID
JOIN 
    Person.Person AS p ON e.BusinessEntityID = p.BusinessEntityID
JOIN 
    Person.PersonPhone AS ph ON p.BusinessEntityID = ph.BusinessEntityID
WHERE 
    r.Rate > (SELECT AVG(Rate) FROM HumanResources.EmployeePayHistory)
ORDER BY 
    r.Rate DESC;


--3. Products with above average sales
SELECT 
    p.ProductID,
    p.Name,
    (SELECT SUM(sod.LineTotal) 
     FROM Sales.SalesOrderDetail AS sod 
     WHERE sod.ProductID = p.ProductID) AS TotalSales
FROM 
    Production.Product AS p
WHERE 
    (SELECT SUM(sod.LineTotal) 
     FROM Sales.SalesOrderDetail AS sod 
     WHERE sod.ProductID = p.ProductID) > 
     (SELECT AVG(TotalSales) 
      FROM (SELECT SUM(LineTotal) AS TotalSales 
            FROM Sales.SalesOrderDetail 
            GROUP BY ProductID) AS SubQuery)
ORDER BY 
    TotalSales DESC;


--4. Orders with Total Quantity Greater Than the Average
SELECT 
    soh.SalesOrderID,
    soh.OrderDate,
    (SELECT SUM(sod.OrderQty) 
     FROM Sales.SalesOrderDetail AS sod 
     WHERE sod.SalesOrderID = soh.SalesOrderID) AS TotalQuantity
FROM 
    Sales.SalesOrderHeader AS soh
WHERE 
    (SELECT SUM(sod.OrderQty) 
     FROM Sales.SalesOrderDetail AS sod 
     WHERE sod.SalesOrderID = soh.SalesOrderID) > 
     (SELECT AVG(TotalQuantity) 
      FROM (SELECT SUM(OrderQty) AS TotalQuantity 
            FROM Sales.SalesOrderDetail 
            GROUP BY SalesOrderID) AS SubQuery)
ORDER BY 
    TotalQuantity DESC;

--5. Products with no sales in the last quarter
SELECT 
    p.ProductID,
    p.Name,
    p.ProductNumber
FROM 
    Production.Product AS p
WHERE 
    NOT EXISTS (SELECT 1 
                FROM Sales.SalesOrderDetail AS sod 
                JOIN Sales.SalesOrderHeader AS soh ON sod.SalesOrderID = soh.SalesOrderID
                WHERE sod.ProductID = p.ProductID 
                AND soh.OrderDate >= DATEADD(QUARTER, -1, GETDATE()));


--6. Customers with Orders Exceeding the Average Order Value of Their Region
SELECT 
    c.CustomerID,
    p.FirstName + ' ' +p.LastName as Name
FROM 
    Sales.Customer AS c
JOIN 
    Person.Person AS p ON c.PersonID = p.BusinessEntityID
WHERE 
    NOT EXISTS (SELECT 1 
                FROM Sales.SalesOrderHeader AS soh 
                WHERE soh.CustomerID = c.CustomerID 
                AND soh.OrderDate >= DATEADD(YEAR, -1, GETDATE()));


--7. Top 10 customers by total sales amount
SELECT TOP 10
    c.CustomerID,
    CONCAT(p.FirstName, ' ', p.LastName) AS CustomerName,
    (SELECT SUM(soh.TotalDue) 
     FROM Sales.SalesOrderHeader AS soh 
     WHERE soh.CustomerID = c.CustomerID) AS TotalSalesAmount
FROM 
    Sales.Customer AS c
JOIN 
    Person.Person AS p ON c.PersonID = p.BusinessEntityID
ORDER BY 
    TotalSalesAmount DESC;


-- Products with the highest number of orders
SELECT TOP 10
    p.ProductID,
    p.Name AS ProductName,
    (SELECT COUNT(sod.SalesOrderDetailID) 
     FROM Sales.SalesOrderDetail AS sod 
     WHERE sod.ProductID = p.ProductID) AS NumberOfOrders
FROM 
    Production.Product AS p
ORDER BY 
    NumberOfOrders DESC;