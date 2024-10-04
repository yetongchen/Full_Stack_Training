-- All scenarios are based on Database NORTHWIND.
USE Northwind
GO

-- 1. List all cities that have both Employees and Customers.

SELECT DISTINCT e.City
FROM Employees e
WHERE e.City IN (
    SELECT c.City
    FROM Customers c
)
ORDER BY e.City

-- 2. List all cities that have Customers but no Employee.

    -- a. Use sub-query

SELECT DISTINCT c.City
FROM Customers c
WHERE c.City NOT IN (
    SELECT e.City
    FROM Employees e
)
ORDER BY c.City

    -- b. Do not use sub-query

SELECT DISTINCT c.City
FROM Customers c LEFT JOIN Employees e ON c.City = e.City
WHERE e.City IS NULL
ORDER BY c.City

-- 3 List all products and their total order quantities throughout all orders.

SELECT p.ProductID, p.ProductName, SUM(od.Quantity) as TotalQuantity
FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
GROUP BY p.ProductID, p.ProductName
ORDER BY p.ProductID, p.ProductName

-- 4. List all Customer Cities and total products ordered by that city.

SELECT c.City, SUM(od.Quantity) AS TotalProductsOrdered
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
ORDER BY TotalProductsOrdered DESC

-- 5. List all Customer Cities that have at least two customers.

SELECT c.City, COUNT(c.CustomerID) AS NumOfCustomers
FROM Customers c
GROUP BY c.City
HAVING COUNT(c.CustomerID) >= 2
ORDER BY NumOfCustomers DESC

-- 6. List all Customer Cities that have ordered at least two different kinds of products.

SELECT c.City, COUNT(od.ProductID) AS NumOfProductKind
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
GROUP BY c.City
HAVING COUNT(od.ProductID) >= 2
ORDER BY NumOfProductKind DESC

-- 7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT DISTINCT c.CustomerID, c.ContactName, c.City, o.ShipCity
FROM Customers c
JOIN Orders o ON c.CustomerID = o.CustomerID
JOIN [Order Details] od ON o.OrderID = od.OrderID
WHERE c.City = o.ShipCity
ORDER BY c.CustomerID

-- 8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

WITH TopProducts AS (
    SELECT TOP 5 p.ProductID, p.ProductName, SUM(od.Quantity) AS TotalQuantity, AVG(od.UnitPrice) AS AvgPrice
    FROM Products p JOIN [Order Details] od ON p.ProductID = od.ProductID
    GROUP BY p.ProductID, p.ProductName
    ORDER BY TotalQuantity DESC    
), TopCities AS (
    SELECT dt.ProductID, dt.ProductName, dt.TotalQuantity, dt.AvgPrice, c.City,
        SUM(od.Quantity) AS CityTotalQuantity,
        ROW_NUMBER() OVER (PARTITION BY dt.ProductID ORDER BY SUM(od.Quantity) DESC) AS RowNum
    FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    JOIN TopProducts dt ON od.ProductID = dt.ProductID
    GROUP BY dt.ProductID, dt.ProductName, dt.TotalQuantity, dt.AvgPrice, c.City    
)
SELECT ProductID, ProductName, TotalQuantity, AvgPrice, City, CityTotalQuantity
FROM TopCities
WHERE RowNum = 1
ORDER BY TotalQuantity DESC 

-- 9. List all cities that have never ordered something but we have employees there.

    -- a. Use sub-query

SELECT e.City 
FROM Employees e 
WHERE e.City NOT IN (
    SELECT c.City
    FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
)

    -- b. Do not use sub-query

SELECT e.City
FROM Employees e LEFT JOIN Orders o ON e.City = o.ShipCity
WHERE o.OrderID IS NULL

-- 10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

SELECT EmpOrderTopCity.City
FROM
(
    SELECT TOP 1 e.City, COUNT(o.OrderID) AS TotalOrder
    FROM Employees e JOIN Orders o ON e.EmployeeID = o.EmployeeID
    GROUP BY e.City
    ORDER BY TotalOrder DESC
) AS EmpOrderTopCity
JOIN (
    SELECT TOP 1 c.City, SUM(od.Quantity) AS TotalQuantity
    FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
    JOIN [Order Details] od ON o.OrderID = od.OrderID
    GROUP BY c.City
    ORDER BY TotalQuantity DESC
) AS TotalQuantityTopCity ON EmpOrderTopCity.City = TotalQuantityTopCity.City 

-- 11. How do you remove the duplicates record of a table?

-- Assume that there is a table named 'old_table', which has 2 columns: column1, column2.

--1) use ROW_NUMBER()

WITH CTE AS (
    SELECT *, ROW_NUMBER() OVER (PARTITION BY column1, column2 ORDER BY (SELECT NULL)) AS RowNum
    FROM old_table
)
DELETE FROM CTE WHERE RowNum > 1

--2) create a new table with DISTINCT
 
SELECT DISTINCT *
INTO new_table
FROM old_table
