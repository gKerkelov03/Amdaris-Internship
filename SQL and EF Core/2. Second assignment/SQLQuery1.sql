select FirstName, LastName, businessentityid as Employee_id
from Person.Person
order by LastName asc


select PersonPhone.BusinessEntityID, FirstName, LastName, PhoneNumber
from Person.PersonPhone join Person.Person on PersonPhone.BusinessEntityID = Person.BusinessEntityID
where Person.LastName like 'L%'
order by FirstName, LastName;


select LastName, SalesyYTD, PostalCode, 
