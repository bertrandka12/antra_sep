
-- Use Northwind database. All questions are based on assumptions described by the Database Diagram sent to you yesterday. 
-- When inserting, make up info if necessary. Write query for each step. Do not use IDE. BE CAREFUL WHEN DELETING DATA OR DROPPING TABLE.


--1. Create a view named “view_product_order_[your_last_name]”, list all products and total ordered quantity for that product.

CREATE view view_product_order_kalis as 
SELECT p.ProductID ,p.ProductName, sum(o.Quantity) QuantityCount 
FROM Products p inner join[Order Details] o 
on o.ProductID = p.ProductID
GROUP BY p.ProductID ,p.ProductName;


--2. Create a stored procedure “sp_product_order_quantity_[your_last_name]” that accept product id as an input and 
--total quantities of order as output parameter.

Create proc sp_product_order_quantity_Kalis
@id int,@total int out as 
Begin
    Select @id = v.ProductID, @total = v.QuantityCount 
    From view_product_quantity_order_Kalis v
    Where v.ProductID = @id
End 

DECLARE @id int, @total int
EXEC sp_product_order_quantity_Kalis 2, @total out
PRINT @total



--3. Create a stored procedure “sp_product_order_city_[your_last_name]” that accept product name as an input and top 5 cities 
-- that ordered most that product combined with the total quantity of that product ordered from that city as output.

CREATE sp_product_order_city_kalisa
(@productName varchar(50), @orderCity varchar(20) OUT) AS 
BEGIN
    SELECT @productName = s.productname 
    FROM (
            Select TOP 5 d.ProductID,d.ProductName
            From (
                    Select p.ProductID, p.ProductName, sum(od.quantity) t
                    From Products p join[Order Details] od 
                    On p.ProductID = od.ProductID 
                    Group by p.ProductID,p.ProductName
                 ) as [d] 
                 Order by d.t desc
         ) s 
        left join (
            select * 
            from (
                select dd.productid, dd.city, rank() 
                over (partition by productid order by q desc) [rk] 
                from (
                    select p.ProductID, c.city, sum(od.quantity) q 
                    from Customers c join orders o 
                    on c.CustomerID = o.CustomerID left join[Order Details] od 
                    on o.OrderID = od.OrderID left join Products p 
                    on od.ProductID=p.ProductID
                    group by p.ProductID,c.City
                ) dd
            ) cc
            where cc.rk=1
        ) x 
    on s.productid = x.productid 
    where x.city = @orderCity
End

--4. Create 2 new tables “people_your_last_name” “city_your_last_name”. 
-- City table has two records: {Id:1, City: Seattle}, {Id:2, City: Green Bay}. 
-- People has three records: {id:1, Name: Aaron Rodgers, City: 2}, {id:2, Name: Russell Wilson, City:1}, {Id: 3, Name: Jody Nelson, City:2}. 
-- Remove city of Seattle. If there was anyone from Seattle, put them into a new city “Madison”. 
-- Create a view “Packers_your_name” lists all people from Green Bay. If any error occurred, no changes should be made to DB. 
-- (after test) Drop both tables and view.

create table people_kalisa(id int,name char(20),cityId int)
insert into people_kalisa(id,name,cityid)values(1,'Aaron Rodgers',2)
insert into people_kalisa(id,name,cityid)values(2,'Russell Wilson',1)
insert into people_kalisa(id,name,cityid)values(3,'Jody Nelson',2)

create table city_kalisa(cityid int,city char(20))
insert into city_kalisa(cityid,city) values (1,'Seattle') 
insert into city_kalisa(cityid,city) values (2,'Green Bay')

Select * FROM city_kalisa
DELETE FROM city_kalisa WHERE city = 'Seattle'

CREATE view Packers_kalisa As
Select * 
FROM people_kalisa p JOIN city_kalisa c
ON p.cityid= c.cityid
WHERE c.city = 'Green Bay'


drop table people_kalisa 
drop table city_kalisa 
drop view Packers_kalisa

--5. Create a stored procedure “sp_birthday_employees_[you_last_name]” that creates a new table “birthday_employees_your_last_name” and 
-- fill it with all employees that have a birthday on Feb. (Make a screen shot) drop the table. Employee table should not be affected.

CREATE PROC sp_birthday_employees_kalisa AS
Begin
    SELECT employeeid, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Photo
    INTO birthday_employees_kalisa 
    FROM Employees 
    WHERE month(BirthDate)=2
End

EXEC sp_birthday_employees_kalisa

DROP table birthday_employees_kalisa

--6. How do you make sure two tables have the same data?

--> you can use inner join to find records where primary key exist in both tables.
-->you can also use a left outer join  or right outer join

