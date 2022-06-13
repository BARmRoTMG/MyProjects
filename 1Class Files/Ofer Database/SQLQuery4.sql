-- outer join ========================
-- Cust_Orders LEFT
SELECT C.CustomerID, companyname,ContactName, OrderID 
FROM Customers C LEFT OUTER JOIN Orders O
ON   C.CustomerID = O.CustomerID
where O.OrderID is null


-- Cust_Orders Left  
SELECT Customers.CustomerID,ContactName, OrderID 
FROM Customers  LEFT OUTER JOIN Orders 
ON   Customers.CustomerID = Orders.CustomerID
where Orders.OrderID is null
-- order by orderid -- Customers.CustomerID

-- Cust_Orders RIGHT, order with no customer
SELECT C.CustomerID,ContactName,OrderID 
FROM Customers C RIGHT OUTER JOIN Orders O
ON C.CustomerID = O.CustomerID
where C.CustomerID is null


-- Cust_Orders Full
SELECT C.CustomerID, companyname,ContactName, OrderID 
FROM   Customers C FULL OUTER JOIN Orders O
ON     C.CustomerID = O.CustomerID
where orderid is null OR C.CustomerID is null
order by OrderID

-- outer join categories and products full

select Categories.categoryid,categoryname,ProductID,ProductName
from categories FULL outer join products
on Categories.categoryid = products.CategoryID
where ProductID is null OR categories.CategoryID is null

-- suppliers and products full


select suppliers.SupplierID,ProductID
from products Full outer join suppliers 
ON products.supplierid = Suppliers.supplierid
where ProductID is null or Suppliers.SupplierID is null

-- ================================================
-- TIP : all columns from employees table <table .*>

  select orderid,employees .*
  from employees inner join orders ON
  employees.EmployeeID = orders.EmployeeID


  -- page 5,61 all employees orders 8/96 only
  select Employees.EmployeeID,OrderDate
  from employees left outer join orders on
  employees.EmployeeID = orders.EmployeeID
  and year(orderdate) = 1996 and month(orderdate) = 8
 
-- addded new employee aviv join and outer join
-- how many orders each employee done


select  e.EmployeeID, FirstName,
count(OrderID) '#orders'
from Employees e INNER JOIN Orders o ON e.EmployeeID=o.EmployeeID
group by e.EmployeeID, FirstName
--      having count(orderid) >= 100
order by #orders desc 

-- to check
select *
from Orders
order by EmployeeID

-- num of orders per emp per year with having 
select e.EmployeeID, FirstName, LastName,YEAR(OrderDate)'OrderYear',
count(OrderID) '#orders'
from Employees e join Orders o on e.EmployeeID=o.EmployeeID
group by e.EmployeeID, FirstName, LastName,YEAR(OrderDate)
--having count(OrderID) > 15
order by e.EmployeeID desc 

--1 
-- ** num of orders per emp, all emps
-- (also emps which did not do orders),

select e.EmployeeID, FirstName, LastName,count(OrderID) '#orders'
from Employees e LEFT OUTER JOIN Orders o 
     ON e.EmployeeID=o.EmployeeID
group by e.EmployeeID, FirstName, LastName
order by #orders desc 

-- 2
-- num of orders per emp, only first 4 hardworkers  TOP
select top 4 e.EmployeeID, FirstName, LastName,count(OrderID) '#orders'
from Employees e LEFT outer join Orders o on e.EmployeeID=o.EmployeeID
group by e.EmployeeID, FirstName, LastName
order by #orders desc 

-- num of orders per emp, only "Not industrious"
select top 4 e.EmployeeID, FirstName, LastName,count(OrderID) '#orders'
from Employees e LEFT outer join Orders o ON e.EmployeeID=o.EmployeeID
group by e.EmployeeID, FirstName, LastName
order by #orders asc

select e.EmployeeID, FirstName,LastName,city
from Employees E left outer join Orders O on e.EmployeeID=o.EmployeeID
where O.employeeid is null
group by e.EmployeeID, FirstName, LastName,city

--  ** Total income per customer per year

-- per customer phase 1 no year

SELECT C.CustomerID,CompanyName,ContactName,
       floor(SUM (Quantity * UnitPrice * (1-discount))) 'Total_Neto',
       SUM(Quantity * UnitPrice) 'Total_Bruto'
FROM  Customers C, Orders O,[Order Details] OD
      WHERE C.CustomerID = O.CustomerID AND O.OrderID = OD.OrderID
GROUP BY C.CustomerID,CompanyName,ContactName
order by customerid

-- per customer per year phase 2
SELECT C.CustomerID, ContactName, YEAR(OrderDate)'OrderYear',
floor(SUM (Quantity * UnitPrice * (1-discount))) 'Total_Neto',
SUM(Quantity * UnitPrice) 'Total_Bruto'
FROM Customers C, Orders O,[Order Details] OD
WHERE C.CustomerID = O.CustomerID AND O.OrderID = OD.OrderID
GROUP BY C.CustomerID, ContactName, YEAR(OrderDate)
order by customerid


-- sub query =========================
-- details of the high price item
SELECT *
FROM Products
order by unitprice desc

-- details of max price item
SELECT *
FROM Products
WHERE unitPrice = 
				(SELECT max(UnitPrice)
				 FROM Products)

SELECT *
FROM Products
WHERE unitPrice = 263.5
						 
--all besides the expensive product   <> !=
					   
SELECT *
	FROM Products
	WHERE UnitPrice <> (SELECT max(UnitPrice) 
					    FROM Products)
-- or <, >, !=
-- ---------------------------------------------
-- ** details (info) of the youngest employee

SELECT employeeid,firstname,city,country,year(birthdate)'BirthYear'
       ,year(hiredate)'HireYear'
FROM Employees
WHERE birthdate = 
					(SELECT max (BirthDate)
					 FROM Employees)

-- can be done also like this 
select top 1 *
from Employees
order by BirthDate  desc

-- ** details of the veteran employee,concat,hiredate year and month

SELECT firstname,city,country,day(hiredate) 'DD',
month (hiredate) 'MM',year(hiredate) 'YYYY',
concat (day(hiredate),'/',month (hiredate),'/',year (hiredate))'HireDate',
day(hiredate)+ '  ' + month (hiredate) + '  ' + year (hiredate) '1992+4+1'
	FROM Employees
	WHERE HireDate = 
					(SELECT min(HireDate) 
					 FROM Employees)

	 select *
	 from Employees


/* who ordered (customer/s details) the most expensive product
  (which purshased)*/


SELECT C.CustomerID,ContactName,CompanyName,O.OrderID
FROM  Customers C, Orders O, [Order Details] OD
WHERE C.CustomerID = O.CustomerID AND O.OrderID = OD.OrderID
AND  OD.UnitPrice =   
	              (SELECT MAX(UnitPrice)FROM [Order Details])

order by C.CustomerID 

-- distinct, each customers appears once 
SELECT distinct C.CustomerID, ContactName,CompanyName,OD.unitprice
FROM Customers C, Orders O, [Order Details] OD
WHERE C.CustomerID = O.CustomerID AND O.OrderID = OD.OrderID
AND OD.UnitPrice =   
	              (SELECT MAX(UnitPrice)FROM [Order Details])
	 
-- sub query is a query
SELECT distinct C.CustomerID, ContactName,CompanyName
FROM Customers C, Orders O, [Order Details] OD
WHERE C.CustomerID = O.CustomerID AND O.OrderID = OD.OrderID
AND OD.UnitPrice =   
	             (SELECT MAX(UnitPrice)
				  FROM [Order Details]
				  where  
				  group by
				  having
				  order by )
group by
        having 
order by ContactName


-- who placed (customer) the 1st order (by order id)


SELECT C.CustomerID, CompanyName,ContactName,Country,OrderID
FROM  Customers C, Orders O
WHERE C.CustomerID = O.CustomerID 
AND Orderid = 
			 (SELECT MIN(OrderID) FROM Orders)


-- =====================================================


-- ** !! employee details with max number of orders !!



select *
from Employees
where EmployeeID = ( 
					select top 1 employeeid 
					from orders
					group by EmployeeID
					order by COUNT(*) desc)

--top1, to assist 
select  top 1 employeeid,count(*) --top 1
from orders
group by EmployeeID
order by count(*) desc
				   

-- to assist s
select  employeeid,count(*) --top 1
from orders
group by EmployeeID
order by count(*) desc

--  display products details and supplier name for products
--  that unitprice > average price, order by unit price



select ProductID,ProductName,UnitPrice,products.SupplierID,CompanyName
from   products,Suppliers
where  products.supplierid = suppliers.SupplierID AND
       unitprice > 
				 (select avg (UnitPrice) from products)

order by UnitPrice

-- problematic, function can not run in where
select ProductID,ProductName,UnitPrice,products.SupplierID,CompanyName
from products,Suppliers
where products.supplierid = suppliers.SupplierID and
       unitprice > avg (UnitPrice)

-- SAME products details where price > average price,
-- with 2 sub queries (too complicated)
select ProductID,ProductName,UnitPrice,SupplierID
from products
where unitprice in
(	select unitprice
	from products
	where unitprice > 
				     (select avg (unitprice) from products))

-- ==============================================
-- IN  NOT IN   sub query returns more then 1 value

SELECT firstname,city,country,year(birthdate) 'birthdate',
year(hiredate) 'hiredate'
	FROM Employees
	WHERE birthdate IN
	                  (SELECT BirthDate FROM Employees)

-- =====================================================================
-- using IN,cust who buy in 1996 which also order in 1997 (cust,orderid)
-- NOT IN

SELECT companyname,OrderID,year(orderdate) 'orderdate'
FROM   Customers C, Orders O
WHERE C.CustomerID = O.CustomerID 
   AND YEAR(OrderDate) = 1997 
   AND C.CustomerID 
		    IN
   		   (SELECT CustomerID 
	 	    FROM Orders 
	        WHERE YEAR(OrderDate) = 1996)
order by companyname,OrderID


-- Same with distinct, no order id 
SELECT distinct companyname,year(orderdate) 
FROM Customers C, Orders O
WHERE C.CustomerID = O.CustomerID 
   AND YEAR(OrderDate) = 1997 
   AND C.CustomerID IN 
					(SELECT CustomerID 
	 				 FROM Orders O
					 WHERE YEAR(OrderDate) = 1996)
order by companyname

-- who(customer) placed the 1st ordrer
SELECT C.CustomerID, ContactName
FROM Customers C join Orders O on 
 C.CustomerID = O.CustomerID 
where OrderID = 
               (SELECT MIN(OrderID) FROM Orders)

-- display product details which supply by suppliers 
-- that got same country as employees country, three queries 2 sub


select *
from Products
where SupplierID
 IN 
 	(select Supplierid
	from Suppliers
	where Country IN
		 (select country from employees))

-- ==========================================================
-- sub query in the SELECT 

-- prodid with price of avg price item, aggregation limit
   
select productid,productname,unitprice,QuantityPerUnit,
(select AVG(unitprice) from Products) 'Avg price',
(select max(unitprice) from products) 'Max Price'
from Products

-- employeeid with price of item 5 and max orderid

select firstname,city,
(select unitprice from Products where ProductID = 5 ) 'Prod5_price',
(select max(orderid) from orders) 'MaxOrderid' 
from Employees

-- * display employeeid with the price of max price item
  
select employeeid,
(select max (unitprice) from Products) 'max price'
from Employees

-- emp age in years with average order age          getdate() year()

select firstname,(year(getdate())- year (BirthDate)) 'EmpAge',
(select avg (year(getdate()) - year(orderdate)) from orders) 'Avg_Order_Age'
from Employees

select *
from [Order Details]


/* *** products details (code,name)which are in orders where total order 
 cost is more then 10,000$ (with/after discount,neto)
 ,page 5-71 */


SELECT  distinct P.ProductID, P.ProductName
FROM [Order Details] OD, Products P 
WHERE OD.ProductID = P.ProductId AND 
OD.OrderID IN
		    (SELECT OrderID
		     FROM  [Order Details]
		     GROUP BY OrderId
		        HAVING SUM(Quantity * UnitPrice * (1-discount)) > 10000)


-- sub query only phase 1
		(SELECT OrderID,SUM(Quantity * UnitPrice * (1-discount))
		 FROM  [Order Details]
		 GROUP BY OrderId
		   HAVING SUM(Quantity * UnitPrice * (1-discount)) > 10000)		
	
select * from [Order Details]
 
-- verify sub query data with discount, with floor
	 SELECT OrderID,floor(SUM(Quantity * UnitPrice* (1-discount))) 'SumOrd'
	 FROM  [Order Details]
	 GROUP BY OrderId
	 HAVING floor(SUM (Quantity * UnitPrice * (1-discount))) > 10000
	 order by SumOrd desc 	 
	 
-- to assist 
	 SELECT OrderID,floor(SUM(Quantity * UnitPrice* (1-discount)))'sumo'
	 FROM  [Order Details]
	 GROUP BY OrderId
	 order by sumo desc


	 	 -- to test calculations
	 select *
	 from [Order Details]
	 where orderid = 10251

-- ==================================================
-- Union and union all page 5-81

-- union all, display all data,   example: all students from all universities
select companyname,country,City
from Customers
union all
select companyname,country,city
from Suppliers

order by country,City

-- UNION eliminate duplications 
select City,Country
from Customers
UNION
select city,Country
from Suppliers


-- intersect appears in both tables
select city,Country
from Customers
intersect
select city,Country
from Suppliers

select country,City
from Employees
intersect
select country,city
from Suppliers
intersect
select country,city
from customers

-- customers who bought in 1996 and 1997 
select CustomerID from orders where year(orderdate) = 1996
intersect 
select customerid from orders where year(orderdate) = 1997 

-- except  without / minus 
-- 1
SELECT ProductID FROM Products
EXCEPT
SELECT ProductID FROM [Order Details]

-- 2
SELECT ProductID FROM [Order Details] 
EXCEPT
SELECT ProductID FROM Products

-- employee with no orders
SELECT EmployeeID FROM Employees
EXCEPT
SELECT EmployeeID FROM Orders

-- 
SELECT distinct EmployeeID FROM Orders
EXCEPT
SELECT EmployeeID FROM Employees

-- except  country city between cust and supp
SELECT Country FROM Customers
EXCEPT
SELECT Country from Suppliers

-- except
SELECT Country FROM Suppliers
EXCEPT
SELECT Country from Customers

-- on orders
select orderid from orders where year(orderdate) = 1996
except
select orderid from orders where year(OrderDate) = 1996



--==============================================
--Insert ======================
 select * from Categories

 -- IDENTITY PK     right click , properties

insert into Categories (categoryid,CategoryName)
				values (10,'1045 Category')


-- Skip the PK  option 1
Insert into Categories
       (CategoryName,[Description])
values ('123456789012345','Football,Basketball,Tenis,SheshBesh etc.')
 
 -- option 2 
 Insert  into Categories
 values ('NBA Players','mj,kd',NULL)

 select * from Categories

 select * from products
 -- insert new item into products

 insert into products (ProductName,supplierid,categoryid,
					   QuantityPerUnit,UnitPrice)
                values('basketball',1,11,null,0.99)

select * from Employees    

-- error, all columns should fill in when columns names not mentioned 
insert into Employees values ('green','roni')

-- that's OK , columns names mentioned
 Insert into Employees (lastname,FirstName)
 values                ('Green','Roni')  

 select *
 from Employees


 select * from Products
 
 -- Insert more then 1 row 
Insert into Categories
       (CategoryName,[Description]) 
values ('cat_1','demo category for You'),
       ('cat_2','demo category for Me')

select * from Categories

-- Update =================== page 6-9
update categories
set    categoryname = 'Sport_Sela',description = 'NEW_shesh besh products'
where  CategoryID = 12

select * from Categories

select * from Products

update Products
set productname = 'Basketball_1'
where ProductID = 88

-- ======================
select * from Employees
where firstname = 'aviv'

-- much better with employyee id
update Employees
set city = 'Ramat Gan',country='USA'            
where firstname = 'aviv'
-- =============================

select * from Categories
where CategoryID = 10

/* 40 units of "Tofu" have been bought,
   update the data to reflect the new stock value for this item. */

-- step 1
select *
from Products
where ProductName ='tofu'

-- step 2
update products
set UnitsInStock -=40   --  or unitsinstock = unitsinstock + 40 
where ProductName = 'tofu' and ProductID=14

select *
from Products
where ProductName ='tofu'

/* A client asks to add two more units of "Mascarpone Fabioli"
to his order (order id - 10258).           */


-- item from order details page 6-9
--verifications
select *
from [Order Details]
where OrderID = 10258

select *
from products
where ProductName like '%fabio%'

select *
from [Order Details]
where orderid = 10258 and productid = 32  

-- Step 1 OD update
update [Order Details]
set Quantity = Quantity+2
where orderid = 10258
      and productid = 32

-- option B using sub query instead of 32
         (select productid 
		  from products
          where  productname = 'mascarpone fabioli')



  -- Step 2 Inventory update
update products
set UnitsInStock -=2
where ProductID = 32     -- mascarpone fabioli


-- DELETE =============
delete from Categories
where CategoryID >= 10

delete from Categories
where CategoryID in (20,30,40,50)

select * from Categories
-- ======================================
select * from Products

select * from Employees

delete from Employees
where EmployeeID >=11

delete from Products
where ProductID = 78

-- FK issue
delete from orders
where orderid=10248

select * from Orders

select *
from [Order Details]

-- delete FK before PK


delete from orders
where OrderID = 10248


select * from Car_Demo_2021

-- Delete with rollback option (no action done) 
BEGIN TRANSACTION 
	DELETE FROM Car_Demo_2021
	WHERE color = 'blue' 
--	if OK 
COMMIT
-- else  
ROLLBACK 
 


select * from Car_Demo_2021


-- ========================================

-- Create table ,attention to date format
create table Car_Demo_2022 (
Car_id		char (10) primary key,		
Shield_Num	char (25) not null unique,
GradeSafe	int not null check(gradesafe >= 20 and gradesafe <= 100),
Notes		char(255),
CarDate		datetime check (year(cardate) between 2000 and year(getdate())),
OnRoad_date date,
Color		char(10)default 'Blue',
Price		decimal(8,2),   -- total 8 digits 999999.99
Employeeid	int references  employees (employeeid) );

-- int bigint smallint float

select * from Car_Demo_2022

insert into Car_Demo_2022 values
('10-88-88','plate_4',88,'notes','2019-10-28','2019-12-12','color blue',null,2),
('10-88-45','plate_5',44,'notes','2019-10-10','2019-12-12','Yellow',null,1),
('10-88-46','plate_6',88,'notes','2019-10-10','2019-12-12','yellow',null,3),
('10-88-48','plate_8',44,'notes','2019-10-10','2019-12-12','color blue',null,4),
('10-88-49','plate_9',88,'notes','2019-10-10',getdate(),default,4444,5),
('10-88-50','plate_10',44,'notes',getdate(),'2019-12-12','color blue',1258.41,4)
 
 -- insert with error grade safe out of range
 insert into Car_Demo_2022 values
 ('10-44-66','plate_1000',101,'notes','2019-10-10 11:59',getdate(),'blue',123456.26,5)

delete Car_Demo_2022


select * from Car_Demo_2022

-- join with employees
select firstname,Car_id,color,[Shield_Num]
from Employees join Car_Demo_2022
on Employees.EmployeeID = Car_Demo_2022.Employeeid

-- drop table
drop table Car_Demo_2022;

-- is it possible ?  FK issue
drop table Orders

select * from Car_Demo_2021

-- change data fields in table
-- alter column change column attributes
alter table  car_demo_2021
alter column color char(25)

-- alter table add column country
alter table car_demo_2021
add CountryOfOrigin char(20)

-- alter table drop column
ALTER TABLE car_demo_2021
DROP COLUMN countryoforigin;



-- alter drop constraints such as default from later versions
ALTER TABLE car_demo_2021
ALTER COLUMN color DROP DEFAULT

-- change datatype, year format is supported from 2017 
ALTER TABLE car_demo_2021
ALTER COLUMN onroad_date year;

-- ??
drop table Orders

-- view Create Drop =============
GO

CREATE VIEW V_ORD2EMP 
AS
select orderid,year(orderdate)'YYYY',FirstName,City,country,ShippedDate
from   Orders,Employees
where  orders.EmployeeID = Employees.EmployeeID;

GO

select * from V_ord2emp;

drop view v_ord2emp;

-- VIEW, customerid,contact, year, total$ with and without discount
create view V_TotalPerYear_1 as
SELECT C.CustomerID,companyname, ContactName,YEAR(OrderDate)'OrderYear',
floor(SUM (Quantity * UnitPrice * (1-discount))) 'Total$',
SUM(Quantity * UnitPrice) 'Total_NoDisc'
FROM Customers C, Orders O,[Order Details] OD
WHERE C.CustomerID = O.CustomerID AND O.OrderID = OD.OrderID
GROUP BY C.CustomerID, companyname,ContactName, YEAR(OrderDate)

drop view V_totalperyear_1

select *
from V_totalperyear_1
where Total$ between 4000 and  8000
order by customerid,Total$ desc

select orders.orderid
from orders,[Order Details]

-- Implicit View ============
WITH V_temp AS
(select city, count(*) NumOfEmps
from Employees
group by city)
 
select *
from  V_temp
where NumOfEmps = (select max(NumOfEmps)
                            from V_temp)



-- customers who booght more then 48000 a year
with  V_totalperyear2 as
(SELECT C.CustomerID, ContactName, YEAR(OrderDate)'OrderYear',
floor(SUM (Quantity * UnitPrice * (1-discount))) 'Total$',
SUM(Quantity * UnitPrice) 'Total_NoDisc'
FROM Customers C, Orders O, [Order Details] OD
WHERE C.CustomerID = O.CustomerID AND O.OrderID = OD.OrderID
GROUP BY C.CustomerID,ContactName, YEAR(OrderDate))

select *
from V_totalperyear2
where Total$ > 48000
order by Total$ desc

-- ================================================

CREATE DATABASE [NADLAN];

drop database NADLAN
use nadlan
create table city  ( );
create table house ( ) ;
create table sales ( );
create table House_Type ( );


use northwind
-- Create table from table including content, backups
select * into employees_2
from Employees

select * from employees_2

drop table employees_2












