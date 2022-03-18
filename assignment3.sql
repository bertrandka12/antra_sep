--Write queries for following scenarios
--All scenarios are based on Database NORTHWND.

--1.List all cities that have both Employees and Customers.
SELECT distinct City 
FROM Customers
WHERE city IN (SELECT City from Employees)

--2.List all cities that have Customers but no Employee.
--a.      Use sub-query
SELECT distinct City 
FROM Customers
WHERE city NOT IN (
    SELECT City FROM Employees)
--b.      Do not use sub-query
SELECT distinct c.City 
FROM Customers c LEFT JOIN Employees e 
ON c.City = e.City

--3.List all products and their total order quantities throughout all orders.
SELECT c.CustomerID, c.CompanyName, c.ContactName, SUM(od.Quantity) AS TotalOrderQty 
FROM Customers c LEFT JOIN Orders o 
ON c.CustomerID = o.CustomerID LEFT JOIN [Order Details] od
ON o.OrderID = od.OrderID
GROUP BY c.CustomerID, c.CompanyName, c.ContactName
ORDER BY TotalOrderQty desc

--4.List all Customer Cities and total products ordered by that city.
SELECT c.City,SUM(od.Quantity) AS TotalPdtOrdered 
FROM Customers c LEFT JOIN Orders o 
ON c.CustomerID = o.CustomerID LEFT JOIN [Order Details] od
ON o.OrderID = od.OrderID
GROUP BY c.City
ORDER BY TotalPdtOrdered desc

--5.List all Customer Cities that have at least two customers.
--a.      Use union
SELECT cu.City 
FROM Customers cu 
GROUP BY cu.City 
HAVING COUNT(cu.City) > 2 UNION SELECT c.City FROM Customers c GROUP BY c.City HAVING COUNT(c.City) = 2

--b.      Use sub-query and no union
SELECT distinct c.City
FROM Customers c
WHERE c.City IN (
    SELECT u.City FROM Customers u GROUP BY u.City HAVING COUNT(u.City) >=2 
    )

--6.List all Customer Cities that have ordered at least two different kinds of products.
SELECT distinct c.City
FROM Orders o INNER JOIN Customers c
ON o.CustomerID = c.CustomerID 
INNER JOIN [Order Details] r
ON r.OrderID = o.OrderID
GROUP BY c.City, r.ProductID
HAVING count(r.ProductID) > 2

--7.List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.
SELECT * 
FROM Customers c
WHERE c.City NOT IN (
    SELECT o.ShipCity 
    FROM Orders o INNER JOIN Customers c 
    ON o.ShipCity = c.City
    )

--8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.
WITH cte_ordersc as (
SELECT oc.ShipCity,oc.ProductID, oc.average,DENSE_RANK() over 
(partition by oc.ProductID order by oc.number) rnk 
FROM (
    SELECT TOP(5) od.ProductID,o.ShipCity, SUM(Quantity) number,AVG(od.UnitPrice)average 
    FROM dbo.Orders o left join dbo.[Order Details] od on o.OrderID=od.OrderID 
    GROUP BY o.ShipCity, od.ProductID 
    ORDER BY number DESC
    ) oc
)
SELECT * 
FROM cte_ordersc 
WHERE rnk=1

--9. List all cities that have never ordered something but we have employees there.
--a.      Use sub-query
SELECT e.City 
FROM Employees e 
WHERE e.City NOT IN 
(
    SELECT c.City 
    FROM Orders o INNER JOIN Customers c 
    ON c.CustomerID = o.CustomerID
    )
--b.      Do not use sub-query
SELECT distinct e.City 
FROM Employees e LEFT JOIN Customers c 
ON e.City = c.City
WHERE c.City IS NULL

--10. List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
SELECT * 
FROM (select Top 1 e.City, count(o.OrderID) countOrder 
FROM Employees e INNER JOIN Orders o 
ON e.EmployeeID = o.EmployeeID
GROUP BY e.City) T1 INNER JOIN 
(
    SELECT Top 1 c.City, count(r.Quantity) countQuantity 
    FROM [Order Details] r INNER JOIN Orders d 
    ON r.OrderID = d.OrderID INNER JOIN Customers c 
    ON c.CustomerID = d.CustomerID GROUP BY c.City
    ) T2 
ON T1.City = T2.City;

--11.How do you remove the duplicates record of a table?

--> you first have to look for the duplicate rows with a GROUP BY clause then use the DELETE to remove any rows that are duplicate 


