--1. Total sales amount by territory
SELECT 
    st.Name AS TerritoryName,
    SUM(soh.TotalDue) AS TotalSalesAmount
FROM 
    Sales.SalesOrderHeader soh
JOIN 
    Sales.SalesTerritory st ON soh.TerritoryID = st.TerritoryID
GROUP BY 
    st.Name
ORDER BY 
    TotalSalesAmount DESC;


--2. Top products by sales quantity
SELECT 
    p.Name AS ProductName,
    SUM(sod.OrderQty) AS TotalQuantitySold
FROM 
    Sales.SalesOrderDetail AS sod
JOIN 
    Production.Product AS p ON sod.ProductID = p.ProductID
GROUP BY 
    p.Name
ORDER BY 
    TotalQuantitySold DESC


--3. Average List Price of Products by Category
SELECT 
    pc.Name AS CategoryName,
    AVG(p.ListPrice) AS AverageListPrice
FROM 
    Production.Product AS p
JOIN 
    Production.ProductSubcategory AS psc ON p.ProductSubcategoryID = psc.ProductSubcategoryID
JOIN 
    Production.ProductCategory AS pc ON psc.ProductCategoryID = pc.ProductCategoryID
GROUP BY 
    pc.Name
ORDER BY 
    AverageListPrice DESC;


--4. Customers with the highest number of orders
SELECT 
    p.FirstName + ' ' + p.LastName AS CustomerName,
    ph.PhoneNumber,
    COUNT(soh.SalesOrderID) AS NumberOfOrders
FROM 
    Sales.Customer AS c
JOIN 
    Sales.SalesOrderHeader AS soh ON c.CustomerID = soh.CustomerID
JOIN 
    Person.Person AS p ON c.PersonID = p.BusinessEntityID
JOIN 
    Person.PersonPhone AS ph ON p.BusinessEntityID = ph.BusinessEntityID
GROUP BY 
    c.CustomerID, p.FirstName, p.LastName, ph.PhoneNumber
ORDER BY 
    NumberOfOrders DESC;


--5. Salesperson performance by territory
SELECT 
    st.Name AS TerritoryName,
    p.FirstName,
    p.LastName,
    SUM(soh.TotalDue) AS TotalSalesAmount
FROM 
    Sales.SalesOrderHeader AS soh
JOIN 
    Sales.SalesTerritory AS st ON soh.TerritoryID = st.TerritoryID
JOIN 
    Sales.SalesPerson AS sp ON soh.SalesPersonID = sp.BusinessEntityID
JOIN 
    HumanResources.Employee AS e ON sp.BusinessEntityID = e.BusinessEntityID
JOIN 
    Person.Person AS p ON e.BusinessEntityID = p.BusinessEntityID
GROUP BY 
    st.Name, e.BusinessEntityID, p.FirstName, p.LastName
ORDER BY 
    TerritoryName, TotalSalesAmount DESC;


--6. Average order value per customer
SELECT 
    p.FirstName + ' ' + p.LastName AS CustomerName,
    ph.PhoneNumber,
    AVG(soh.TotalDue) AS AverageOrderValue
FROM 
    Sales.Customer AS c
JOIN 
    Sales.SalesOrderHeader AS soh ON c.CustomerID = soh.CustomerID
JOIN 
    Person.Person AS p ON c.PersonID = p.BusinessEntityID
JOIN 
    Person.PersonPhone AS ph ON p.BusinessEntityID = ph.BusinessEntityID
GROUP BY 
    c.CustomerID, p.FirstName, p.LastName, ph.PhoneNumber
ORDER BY 
    AverageOrderValue DESC;


--7. Customers with orders in the last month
SELECT 
    p.FirstName + ' ' + p.LastName AS CustomerName,
    ph.PhoneNumber,
    COUNT(soh.SalesOrderID) AS NumberOfOrders,
    SUM(soh.TotalDue) AS TotalSalesAmount
FROM 
    Sales.Customer AS c
JOIN 
    Sales.SalesOrderHeader AS soh ON c.CustomerID = soh.CustomerID
JOIN 
    Person.Person AS p ON c.PersonID = p.BusinessEntityID
JOIN 
    Person.PersonPhone AS ph ON p.BusinessEntityID = ph.BusinessEntityID
WHERE 
    soh.OrderDate >= DATEADD(MONTH, -1, GETDATE())
GROUP BY 
    c.CustomerID, p.FirstName, p.LastName, ph.PhoneNumber
ORDER BY 
    TotalSalesAmount DESC;

--8. Customers with the highest average order value
SELECT 
    p.FirstName + ' ' + p.LastName AS CustomerName,
    ph.PhoneNumber,
    AVG(soh.TotalDue) AS AverageOrderValue
FROM 
    Sales.Customer AS c
JOIN 
    Sales.SalesOrderHeader AS soh ON c.CustomerID = soh.CustomerID
JOIN 
    Person.Person AS p ON c.PersonID = p.BusinessEntityID
JOIN 
    Person.PersonPhone AS ph ON p.BusinessEntityID = ph.BusinessEntityID
GROUP BY 
    c.CustomerID, p.FirstName, p.LastName, ph.PhoneNumber
HAVING 
    COUNT(soh.SalesOrderID) > 1 -- Only include customers with more than one order
ORDER BY 
    AverageOrderValue DESC;
