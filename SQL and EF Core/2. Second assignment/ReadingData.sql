SELECT FirstName, LastName, businessentityid AS Employee_id 
FROM Person. Person 
ORDER BY LastName ASC


SELECT PersonPhone.BusinessEntityID, FirstName, LastName, PhoneNumber FROM Person.PersonPhone
JOIN Person.Person ON PersonPhone.BusinessEntityID = Person.BusinessEntityID
WHERE Person.LastName LIKE ‘L%’ 
ORDER BY FirstName, LastName;


SELECT p.LastName, sp.SalesYTD, a.PostalCode FROM Sales.SalesPerson sp
JOIN Person.Person p ON sp.BusinessEntityID = p.BusinessEntityID
JOIN Person.BusinessEntityAddress bea ON sp.BusinessEntityID = bea.BusinessEntityID
JOIN Person.Address a ON bea.AddressID = a.AddressID 
WHERE sp.TerritoryID IS NOT NULL AND sp.SalesYTD > 0
GROUP BY a.PostalCode, sp.SalesYTD, p.LastName
ORDER BY sp.SalesYTD DESC, a.PostalCode ASC 


SELECT SalesOrderID, SUM(LineTotal) AS TotalCost FROM Sales.SalesOrderDetail
GROUP BY SalesOrderID HAVING SUM(LineTotal) > 100000;
ORDER BY a.PostalCode
ASC;