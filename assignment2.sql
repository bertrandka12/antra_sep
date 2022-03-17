
--1. How many products can you find in the Production.Product table?

--> There are 504 products 

SELECT COUNT(*)
FROM Production.Product 

--2. Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. 
--The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT COUNT(*)
FROM Production.Product p
WHERE p.ProductSubcategoryID IS NOT NULL

--3.How many Products reside in each SubCategory? Write a query to display the results with the following titles.
-- ProductSubcategoryID CountedProducts
/*ProductSubcategoryID CountedProducts

-------------------- --------------- */

SELECT p.ProductSubcategoryID, COUNT(p.ProductSubcategoryID) CountedProducts
FROM Production.Product p
WHERE p.ProductSubcategoryID IS NOT NULL
GROUP BY p.ProductSubcategoryID

--4. How many products that do not have a product subcategory.

SELECT count(*)
FROM Production.Product
WHERE ProductSubcategoryID IS NULL


--5. Write a query to list the sum of products quantity in the Production.ProductInventory table.
SELECT SUM(p.Quantity)
FROM Production.ProductInventory p

--6. Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and 
--limit the result to include just summarized quantities less than 100.
/*ProductID    TheSum
-----------        ----------*/

SELECT p.ProductID, SUM(p.Quantity) AS TheSum
FROM Production.ProductInventory p
WHERE p.LocationID = 40
GROUP BY p.ProductID
HAVING SUM(p.Quantity) < 100


--7. Write a query to list the sum of products with the shelf information in the Production.
--ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100
/*
    Shelf      ProductID    TheSum

    ----------   -----------        -----------
    */

SELECT p.Shelf, p.ProductID, SUM(p.Quantity) AS TheSum
FROM Production.ProductInventory p 
WHERE p.LocationID = 40
GROUP BY p.ProductID, p.shelf
HAVING SUM(p.Quantity) < 100

--8. Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.

SELECT AVG(p.Quantity) 
FROM Production.ProductInventory p 
WHERE p.LocationID = 10

--9.    Write query  to see the average quantity  of  products by shelf  from the table Production.ProductInventory
/*    ProductID   Shelf      TheAvg

----------- ---------- -----------*/

SELECT p.ProductID, p.Shelf, AVG(p.Quantity) AS TheAvg
FROM Production.ProductInventory p
GROUP BY ROLLUP (p.Shelf, p.ProductID)



--10.  Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory
/*    ProductID   Shelf      TheAvg

----------- ---------- -----------*/

SELECT p.ProductID, p.Shelf, AVG(p.Quantity) AS TheAvg
FROM Production.ProductInventory p
WHERE p.LocationID = 10 AND p.Shelf <> 'N/A'
GROUP BY ROLLUP (p.Shelf, p.ProductID) 
ORDER BY p.Shelf


--11.  List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.
/*    Color                        Class              TheCount          AvgPrice

-------------- - -----    -----------            ---------------------*/
SELECT p.Color, p.Class,COUNT(*) AS TheCount, AVG(p.ListPrice) AS AvgPrice
FROM Production.Product p
WHERE p.Class IS NOT NULL AND p.Color IS NOT NULL
GROUP BY GROUPING SETS ((p.Color), (p.Class))

-- Joins:

--12.   Write a query that lists the country and province names from person. CountryRegion and 
--person. StateProvince tables. Join them and produce a result set similar to the following.   
/*    Country                        Province

---------                          ----------------------*/
SELECT Distinct c.Name as Country, s.Name as Province
FROM Person.StateProvince s INNER JOIN Person.CountryRegion c 
ON s.CountryRegionCode = c.CountryRegionCode


--13.  Write a query that lists the country and province names from person. CountryRegion and 
--person. StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.

SELECT distinct c.Name as Country, s.Name as Province
FROM Person.StateProvince s INNER JOIN Person.CountryRegion c 
ON s.CountryRegionCode = c.CountryRegionCode
WHERE c.Name = 'Germany' OR c.Name = 'Canada'


-- Using Northwnd Database: (Use aliases for all the Joins)

--14.  List all Products that has been sold at least once in last 25 years.

SELECT distinct p.ProductName 
FROM Products p INNER JOIN [Order Details] o 
ON p.ProductID = o.ProductID INNER JOIN Orders r
ON r.OrderID = o.OrderID
WHERE r.OrderDate between '1997-03-17' and '2022-03-17'

--15.  List top 5 locations (Zip Code) where the products sold most.
SELECT top 5 ShipPostalCode 
FROM Orders
GROUP BY ShipPostalCode
ORDER BY count(ShipPostalCode) DESC

--16.  List top 5 locations (Zip Code) where the products sold most in last 25 years.
SELECT top 5 ShipPostalCode 
FROM Orders
WHERE OrderDate between '1997-03-17' and '2022-03-17'
GROUP BY ShipPostalCode
ORDER BY count(ShipPostalCode) desc

--17.   List all city names and number of customers in that city.     
SELECT City, count(ContactName) as CustomerNumber
FROM Customers
GROUP BY City

--18.  List city names which have more than 2 customers, and number of customers in that city
SELECT City, count(ContactName) as CustomerNumber
FROM Customers
GROUP BY City
HAVING count(ContactName) > 2

--19.  List the names of customers who placed orders after 1/1/98 with order date.
SELECT distinct c.ContactName 
FROM Orders o INNER JOIN Customers c
ON o.CustomerID = c.CustomerID
WHERE OrderDate BETWEEN '1998-01-01' AND '2022-03-17'

--20.  List the names of all customers with most recent order dates
SELECT CustomerID, OrderDate 
FROM 
(SELECT distinct CustomerID, OrderDate ,dense_rank() over (partition by CustomerID order by orderDate desc) rnk from Orders) dt
where dt.rnk = 1


--21.  Display the names of all customers  along with the  count of products they bought
SELECT c.ContactName, count(c.ContactName) 
FROM Orders o inner join Customers c
ON o.CustomerID = c.CustomerID
group by c.ContactName
order by count(c.ContactName) DESC

--22.  Display the customer ids who bought more than 100 Products with count of products.
select c.ContactName, sum(r.Quantity) 
from Orders o inner join Customers c
on o.CustomerID = c.CustomerID inner join [Order Details] r
on r.OrderID = o.OrderID
group by c.ContactName 
having sum(r.Quantity) > 100 
order by sum(r.Quantity) desc

--23.  List all of the possible ways that suppliers can ship their products. Display the results as below
/*    Supplier Company Name                Shipping Company Name
---------------------------------            ----------------------------------*/
SELECT sup.CompanyName, s.CompanyName 
FROM Shippers s cross join Suppliers sup

--24.  Display the products order each day. Show Order date and Product Name.
SELECT distinct r.OrderDate, p.ProductName 
FROM Products p INNER JOIN [Order Details] o 
ON p.ProductID = o.ProductID
INNER JOIN Orders r 
ON r.OrderID = o.OrderID

--25.  Displays pairs of employees who have the same job title.
SELECT * 
FROM Employees e INNER JOIN Employees emp 
ON e.Title = emp.Title

--26.  Display all the Managers who have more than 2 employees reporting to them.
SELECT e.EmployeeID, e.LastName, e.FirstName, e.Title 
FROM Employees e INNER JOIN Employees emp
ON e.EmployeeID = emp.ReportsTo
WHERE e.Title LIKE '%manager%'
GROUP BY e.EmployeeID, e.LastName, e.FirstName, e.Title 
HAVING count(emp.ReportsTo) > 2

--27.  Display the customers and suppliers by city. The results should have the following columns
/*City
Name
Contact Name,
Type (Customer or Supplier)*/

select city, ContactName, 'Customer' as Type 
from Customers union select city, ContactName, 'Supplier' AS Type from Suppliers









