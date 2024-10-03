USE AdventureWorks2019
GO

-- 1. How many products can you find in the Production.Product table?

SELECT COUNT(ProductID) AS NumOfProducts
FROM Production.Product

-- 2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT COUNT(ProductID) AS NumOfProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL

-- 3. How many Products reside in each SubCategory? Write a query to display the results with the following titles.
-- ProductSubcategoryID CountedProducts
-- -------------------- ---------------

SELECT ProductSubcategoryID, COUNT(ProductID) AS CountedProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NOT NULL
GROUP BY ProductSubcategoryID

-- 4. How many products that do not have a product subcategory.

SELECT COUNT(ProductID) AS NumOfProducts
FROM Production.Product
WHERE ProductSubcategoryID IS NULL

-- 5. Write a query to list the sum of products quantity in the Production.ProductInventory table.

SELECT ProductID, SUM(Quantity) as TheSUM
FROM Production.ProductInventory
GROUP BY ProductID

-- 6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.
-- ProductID    TheSum
-- -----------  ----------

SELECT ProductID, SUM(Quantity) as TheSUM
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID
HAVING SUM(Quantity) < 100

-- 7. Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
-- Shelf        ProductID       TheSum
-- ----------   -----------     -----------

SELECT Shelf, ProductID, SUM(Quantity) as TheSUM
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID
HAVING SUM(Quantity) < 100

-- 8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.

SELECT ProductID, AVG(Quantity) AS AvgQuantity
FROM Production.ProductInventory
WHERE LocationID = 10
GROUP BY ProductID

-- 9. Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
-- ProductID   Shelf      TheAvg
-- ----------- ---------- -----------

SELECT ProductID, Shelf, AVG(Quantity) as TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf
ORDER BY ProductID, Shelf

-- 10. Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
-- ProductID   Shelf      TheAvg
-- ----------- ---------- -----------

SELECT ProductID, Shelf, AVG(Quantity) as TheAvg
FROM Production.ProductInventory
WHERE Shelf != 'N/A'
GROUP BY ProductID, Shelf
ORDER BY ProductID, Shelf

-- 11. List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
-- Color        Class       TheCount    AvgPrice
-- -----------  ----------- ----------- -----------

SELECT Color, Class, COUNT(ProductID) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class
ORDER BY Color, Class

-- Joins:

-- 12. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables. Join them and produce a result set similar to the following.
-- Country      Province
-- ---------    ----------------------

SELECT cr.Name AS Country, sp.Name AS Province
FROM person.StateProvince sp JOIN person.CountryRegion cr ON sp.CountryRegionCode = cr.CountryRegionCode
ORDER BY cr.Name, sp.Name

-- 13. Write a query that lists the country and province names from person. CountryRegion and person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.
-- Country      Province
-- ---------    ----------------------

SELECT cr.Name AS Country, sp.Name AS Province
FROM person.StateProvince sp JOIN person.CountryRegion cr ON sp.CountryRegionCode = cr.CountryRegionCode
WHERE cr.Name IN ('Germany', 'Canada')
ORDER BY cr.Name, sp.Name

GO

-- Using Northwind Database: (Use aliases for all the Joins)

USE Northwind
GO

-- 14. List all Products that has been sold at least once in last 27 years.

SELECT DISTINCT p.ProductID, p.ProductName
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID JOIN Orders o ON od.OrderID = o.OrderID
WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
ORDER BY p.ProductID, p.ProductName

-- 15. List top 5 locations (Zip Code) where the products sold most.

SELECT TOP 5 o.ShipPostalCode AS ZipCode, SUM(od.Quantity) AS ProductSold
FROM [Order Details] od JOIN Orders o ON od.OrderID = o.OrderID
WHERE o.ShipPostalCode  IS NOT NULL
GROUP BY o.ShipPostalCode
ORDER BY ProductSold DESC

-- 16. List top 5 locations (Zip Code) where the products sold most in last 27 years.

SELECT TOP 5 o.ShipPostalCode AS ZipCode, SUM(od.Quantity) AS ProductSold
FROM [Order Details] od JOIN Orders o ON od.OrderID = o.OrderID
WHERE o.OrderDate >= DATEADD(YEAR, -27, GETDATE())
GROUP BY o.ShipPostalCode
ORDER BY ProductSold DESC

-- 17. List all city names and number of customers in that city.     

SELECT City, COUNT(CustomerID) AS NumOfCustomers
FROM Customers
GROUP BY City
ORDER BY City

-- 18. List city names which have more than 2 customers, and number of customers in that city

SELECT dt.City, dt.NumOfCustomers
FROM (
    SELECT City, COUNT(CustomerID) AS NumOfCustomers
    FROM Customers
    GROUP BY City   
) AS dt
WHERE dt.NumOfCustomers > 2

-- 19. List the names of customers who placed orders after 1/1/98 with order date.

SELECT DISTINCT c.ContactName
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate > '1998-01-01'

-- 20. List the names of all customers with most recent order dates

SELECT c.ContactName, o.OrderDate
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
ORDER BY  o.OrderDate DESC

-- 21. Display the names of all customers  along with the  count of products they bought

SELECT c.ContactName, COUNT(od.ProductID) AS NumOfProducts
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON od.OrderID = o.OrderID
GROUP BY c.ContactName
ORDER BY NumOfProducts DESC

-- 22. Display the customer ids who bought more than 100 Products with count of products.

SELECT dt.CustomerID, dt.NumOfProducts
FROM (
    SELECT c.CustomerID, COUNT(od.ProductID) AS NumOfProducts
    FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON od.OrderID = o.OrderID
    GROUP BY c.CustomerID    
) AS dt
WHERE dt.NumOfProducts > 100


-- 23. List all of the possible ways that suppliers can ship their products. Display the results as below
-- Supplier Company Name                Shipping Company Name
-- ---------------------------------    ----------------------------------

SELECT DISTINCT su.CompanyName AS "Supplier Company Name", sh.CompanyName AS "Shipping Company Name"
FROM Suppliers su JOIN Products p ON su.SupplierID = p.SupplierID 
JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON o.OrderID = od.OrderID
JOIN Shippers sh ON sh.ShipperID = o.ShipVia
ORDER BY su.CompanyName, sh.CompanyName

-- 24. Display the products order each day. Show Order date and Product Name.

SELECT o.OrderDate, p.ProductName
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
JOIN Orders o ON o.OrderID = od.OrderID
ORDER BY o.OrderDate, p.ProductName

-- 25. Displays pairs of employees who have the same job title.

SELECT e1.FirstName + ' ' + e1.LastName AS Employee1, e2.FirstName + ' ' + e2.LastName AS Employee2, e1.Title AS JobTitle
FROM Employees e1 JOIN Employees e2 ON e1.Title = e2.Title 
WHERE e1.EmployeeID < e2.EmployeeID
ORDER BY e1.Title, Employee1, Employee2

-- 26. Display all the Managers who have more than 2 employees reporting to them.

SELECT e1.EmployeeID, e1.FirstName + ' ' + e1.LastName AS Manager, COUNT(e2.ReportsTo) AS NumOfEmployees
FROM Employees e1 JOIN Employees e2 ON e1.EmployeeID = e2.ReportsTo
GROUP BY e1.EmployeeID, e1.FirstName + ' ' + e1.LastName
HAVING COUNT(e2.ReportsTo) > 2

-- 27. Display the customers and suppliers by city. The results should have the following columns
-- City
-- Name
-- Contact Name,
-- Type (Customer or Supplier)

SELECT City, CompanyName AS Name, ContactName, 'Customer' AS Type
FROM Customers
UNION
SELECT City, CompanyName AS Name, ContactName, 'Supplier' AS Type
FROM Suppliers
ORDER BY City, Type