--  AGGREGATION ========================
select * from Products
where ProductID < 11
order by unitprice

select * from Products

select count(productid)'pk',count(UnitPrice)'count',sum(UnitPrice)'sum UP'
from Products

-- Products
select  count(unitprice)'Count_up',
		count(productid) 'count_id',
		max(unitprice)  'maxPrice',
		min(unitprice)  'minPrice',
		avg(unitprice)  'avgPrice',
		sum(unitprice)  'sum_Price',
		max(productname)'max_name',
		min(productname)'min_name'

from Products

-- where ProductID < 11


select * from Products


select * from Orders
--  * = PK 
select count (*) 'CountPK',
count(orderid) 'count',
sum  (orderid) 'Sum_id',
min  (orderid) '1st_order',
max  (orderid) 'High_Order',
avg  (orderid) 'AVG orderid',
count(shippeddate)'Count_shippeddate',
count (*) - count(shippeddate)'not supplied',
avg (freight) 'avg freight'
from [Orders]

-- Employees

select count(*) ' count',
sum(employeeid) 'sum_EMPID',
min(EmployeeID) '1st num',
max(EmployeeID) 'High num',
AVG(employeeid) 'average num'
from Employees

select * from Employees

-- dispaly num of items (count),total inventory in $



select productname,(UnitsInStock*UnitPrice) 
from Products


select count(ProductID) '#items',sum(UnitsInStock*UnitPrice) 'Sum_Total inventory$'
from products

select * from [Order Details]
order by ProductID

-- (how many times item number 1 sold/ordered)


select count(*)'OD rows'
from [Order Details]
where ProductID = 1

-- how many orders done in 1996

select count(*)'orders1996'
from [Orders]
where year(orderdate) = 1996

select * from Employees

-- home phone

select count(HomePhone) 'WithPhone',
count(*) 'NumOfEmp',
count(*) - count(HomePhone)'Diff_NoPhone'
from Employees

select * from Employees

select * from [Order Details]
-- order details 
select count (*)'Count_PK',
count(unitprice)'Count_price',
max  (unitprice)  'MaxPrice_Sold',
min  (unitprice)  'Low price_Sold',
sum  (unitprice)  'sumPrice',
sum  (unitprice * quantity)'Total Sales Brutu',
floor (sum(unitprice * quantity))'Floor Total Sales Brutu'
from [Order Details]

select unitprice
from [Order Details]
-- 

-- employees, date of old, young, average birth year of all emps


select min(birthdate)'OldAndWise',
       max(birthdate)'Young',
       avg(year(birthdate))'Avg_Year'
from Employees

-- age of wiser employee years 
select year(getdate()) - year(min(birthdate)) 'OldAndWise',
       year(getdate()) - year(max (birthdate))'Young',
       avg (year(birthdate))'avg'
from Employees

-- vatik mevugar
select min(hiredate) 'vatik', min (birthdate) 'mevugar'
from Employees

select * from Employees


-- count in colum which is null like region
select count (*) 'AllEmps',count(region) 'With_Region',
count(*) - count(region)'Not USA'
from Employees

select EmployeeID,firstname,Country,region,ReportsTo
from   Employees
where  region is null

select count(*) 'PK*', 
count(employeeid) 'NumOfEmps',
count(ReportsTo)   'reportsto',
count(distinct ReportsTo) 'Num of Managers'
from Employees

select ReportsTo from Employees


3
  -- young and veterant full dates
 select count(EmployeeID)'numofemps',min(birthdate) 'Veterant_Date',
 max (birthdate) 'Young_Date',avg(year(birthdate)) 'avg',
 avg(year(getdate()) - year(BirthDate)) 'AverageAge'
 from Employees

 -- young and veterant age
 select year (getdate()) - year (min(birthdate)) 'Veteran',
 year (getdate()) - year (max (birthdate)) 'young'
 from Employees
 
-- min max average of unit price in category of
-- dairy products (4), num of products in category


select min(UnitPrice) 'min',
       max(UnitPrice) 'max',
       avg(UnitPrice) 'avg',
       count(*) '#Prods_InCat_4_Dairy'
from Products
where categoryid = 4 

-- and categories.categoryname like 'd%'

select * from Categories

-- ERROR only functions allowed
SELECT AVG(UnitPrice),OrderID
FROM [Order Details]


-- WHERE OrderID = 10258;
-- avg price and total lines in order 10258

select avg(unitprice) 'avg_Price_10258',
count(*) 'NumOfProds_10258',sum(quantity)'Sum_qunt',sum(unitprice)'Sum_unitprice'
from [Order Details]
where orderid = 10258

select *
from [Order Details]
where OrderID = 10258

--  total inventory in $ 
--sum
select productid,productname,unitprice,unitsinstock,
(unitprice * unitsinstock ) 'Total_Per_Item_Inventory'
from Products

select sum (unitprice * unitsinstock) 'Total_Inventory',
round (sum (unitprice * unitsinstock),0) 'Total_Inventory_R'
from Products

-- ERROR 
select firstname,year (min(hiredate))
from Employees

4
-- sum(total) sales in all orders (in $),  might use floor and round

select * from [Order Details]

select sum(UnitPrice*Quantity) 'SumSales_Bruto'
from [Order Details]

select floor(sum(UnitPrice*Quantity)) 'SumSales_Bruto'
from [Order Details]

select floor(sum(UnitPrice*Quantity*(1-Discount)	)) 'SumSales_Neto',
sum(UnitPrice*Quantity) 'SumSales_Bruto',
(sum (UnitPrice*Quantity*(1-Discount)) - sum(UnitPrice*Quantity)) * -1
'Total discOpt1',
floor (sum (UnitPrice*Quantity*(Discount))) 'Total_Disc_Opt2'
from [Order Details]


--5
-- total amount per line in order
select OrderID,[ProductID],[UnitPrice],[Quantity],discount 'Disc%',
UnitPrice * Quantity 'Item_Total',UnitPrice * Quantity * Discount 'Item_Disc$',
UnitPrice * Quantity * (1-Discount) 'Item_Total neto'
from [Order Details]

-- total amount per line in order with product name

select OrderID,products.[ProductID],productname,[Quantity],discount 'Disc%',
"order details".UnitPrice * Quantity 'Item_Total',"order details".UnitPrice * Quantity * Discount 'Item_Disc$',
"order details".UnitPrice * Quantity * (1-Discount) 'Item_Total neto'
from [Order Details],Products
where Products.ProductID = [Order Details].ProductID 

--6
-- total amount per order NA
select orderid,sum(UnitPrice * Quantity) 'Total'
from [Order Details]
group by OrderID

select *
from [Order Details]




select (sum(UnitPrice*Quantity*(1-Discount))) 'SumSales_Neto'
from [Order Details]

select floor(sum(UnitPrice*Quantity*(1-Discount))) 'SumSales(floor)'
from [Order Details]

select round(sum(UnitPrice*Quantity*(1-Discount)),1) 'SumSales(Round)'
from [Order Details]

 -- young and veterant
 select year (getdate()) - year(min(birthdate)) 'Veteran',
 year (getdate()) - year (max (birthdate)) 'young'
 from Employees



/* GROUP BY ============================*/
-- by city	
select city, count(City) 'NumOf'
from Employees
group by city

select city
from Employees
order by City

select * from Employees

-- by title
select Title,count(*) 'NumOf'
from Employees
group by Title

select Title,count(Title) 'NumOf'
from Employees
group by Title

select * from Employees

-- employees from country and city

select country,city,count(*) 'NumOfEmps'
from   Employees
group by country,City
order by NumOfEmps desc 


select country
from customers
order by country

-- ** number of customers from each country, order by: your choice


select country,count(Country) 'NumOfCustomers'
from customers
group by country
order by NumOfCustomers desc


-- number of customers from each country, city, order by num of customers desc

select country,city,count(*) 'NumOfCustomers'
from customers
group by country,city
order by NumOfCustomers desc

-- ** ERROR select and group by must be the same **
--    order of columns not influence 
select country,city,count(*) 'NumOfCustomers'
from   customers
group by country
order by NumOfCustomers desc

-- in countries,city that ends with y
select country,city,count(*) 'NumOfCustomers'
from  customers
where country like '%y'
group by country,city
order by country desc

-- suppliers and num of products they supply
 
-- 1st option temp solution, no supplier name
 
select SupplierID,count(SupplierID) 'NumOfProd'
from   Products
group by SupplierID
order by NumOfProd desc


-- works like 
select productid,productname,unitprice,SupplierID
from Products 
order by SupplierID

-- 2nd option Correct one with supp name

select suppliers.SupplierID,companyname,contactname,contacttitle,
       count(suppliers.SupplierID) 'NumOfProd'
from  Products,Suppliers
where Products.SupplierID=Suppliers.SupplierID  
group by Suppliers.SupplierID,CompanyName,ContactName,ContactTitle
order by NumOfProd desc  



-- incorrect grouping , product is unique per supplier
select suppliers.SupplierID,CompanyName,productid,
       count(suppliers.SupplierID) 'NumOfProd'
from  Products,Suppliers
where Products.SupplierID=Suppliers.SupplierID  
group by Suppliers.SupplierID,CompanyName,ProductID
order by NumOfProd desc


-- ** how many orders each employee done/prepared,
--    1st option with emp num only, 2nd with emp num and name

-- 1st option
select EmployeeID,count(employeeid) 'NumOrders'
from   orders
group by employeeid
order by NumOrders desc

select orderid,EmployeeID
from orders
order by EmployeeID

-- 2nd options with employee name, order by num of orders
select Orders.EmployeeID,FirstName,
count (Orders.employeeid) 'NumOfOrders'
from  orders,Employees
where orders.EmployeeID = Employees.EmployeeID
group by Orders.EmployeeID,firstname
order by NumOfOrders desc

-- London employees
select employees.EmployeeID,FirstName,city,
count (Employees.employeeid) 'NumOfOrders'
from  orders,Employees
where orders.EmployeeID = Employees.EmployeeID
      and city = 'london'
group by employees.EmployeeID,firstname,City
order by NumOfOrders desc

-- group by 2 columns
select country,city, count(City)
from Employees
group by Country,City
order by count(*) desc

-- group by country
select country,count(Country)
from Employees
group by Country
order by count(*) desc

select * from Products

-- by region 
select EmployeeID,Region
from Employees 
order by region

-- by region PK Vs. region
select Region, count(*) 'NumOfEmps*',count(region) 'By_Region'
from Employees
group by Region

select EmployeeID,Region
from Employees

-- by region
select Region,count(region)
from Employees
group by Region

-- count by region Vs. by PK
select Region, count(Region) 'ByRegion',count(*) 'by PK'
from Employees
group by Region
order by count(*) desc

-- count by region Vs. by PK
select firstname,Region 
from Employees

-- count by * Vs. by spesific colomn
select country ,count(*) 'NumOfCustomers',
count(country) 'by country'
from customers
group by country

-- how many products from each category, display category code name


select products.CategoryID,CategoryName,count(*)'NumOfProd'
from   products,categories
where  Products.CategoryID = Categories.CategoryID 
group by products.CategoryID,CategoryName
order by NumOfProd

select *
from Products
order by CategoryID

select CategoryID,count(*)'numProducats'
from Products
group by CategoryID
order by CategoryID

-- HAVING
-- number of customers from each country HAVING
select country ,count(*) 'NumOfCustomers'
from   customers
group by country
      having count(*) between 6 and 12 
order by NumOfCustomers desc

-- HAVING
-- SUPPLIERS and num of products they supply, 
-- supp with more or equal to 4 products
  
select suppliers.SupplierID,companyname, count(suppliers.SupplierID) 'Num'
from  Products,Suppliers
where Products.SupplierID=Suppliers.SupplierID
group by Suppliers.SupplierID,CompanyName
	  having count (suppliers.SupplierID) >= 4
order by count(suppliers.SupplierID) desc


-- HAVING, emps with 100 orders and up 
-- 2nd options with employee name, order by num of orders

select employees.EmployeeID,FirstName,city,
count (Orders.employeeid) 'NumOfOrders'
from  orders,Employees
where orders.EmployeeID = Employees.EmployeeID
group by employees.EmployeeID,firstname,city
	  having count (Orders.employeeid) >= 100 
order by NumOfOrders desc

select *
from orders
order by EmployeeID


-- how many items in each category, with having  categories 10 and up
SELECT Products.CategoryID,categoryname, 
COUNT (ProductID) 'Items_InCategory'
FROM   Products,Categories
where  products.categoryid = categories.CategoryID 
GROUP  BY Products.CategoryID,CategoryName
	   having count(productid) >= 10 
order by Items_InCategory desc 

-- number (count) of orders per specific date
-- 1)which table/s ? 2)column to group by ?


 
select ltrim(orderdate)'Order Date',count(OrderDate) 'NumOrders'
from Orders
group by OrderDate
      having count (OrderDate) >= 4


-- orders per year (order year)


select year(orderdate)'Year',count(OrderDate) 'NumOrders'
from Orders
group by year(OrderDate)
order by YEAR(OrderDate)


-- how many orders by year and month

select year(orderdate) 'Year',month(orderdate)'Month',count(OrderDate) 'NumOrders'
from Orders
group by year(OrderDate),MONTH(OrderDate)
order by YEAR(OrderDate)  

-- ** total amount(Money) per order, "bruto" without discount

select * from [Order Details]


-- No discount
SELECT  orderid,sum (Quantity * UnitPrice) 'Total_Bruto$' 
FROM  [Order Details]
GROUP BY orderid



-- No discount
SELECT  orderid,SUM(Quantity * UnitPrice) 'Total_Bruto$' 
FROM  [Order Details] 
GROUP BY orderid

-- with discount
SELECT  orderid,SUM(Quantity * UnitPrice *(1-Discount)) 'Total_Neto$' 
FROM  [Order Details] 
GROUP BY orderid

-- round bruto and neto
SELECT  orderid,SUM(Quantity * UnitPrice) 'Total_Bruto$',
        SUM(Quantity * UnitPrice *(1-Discount)) 'Total_Neto$',
        round(SUM(Quantity * UnitPrice *(1-Discount)),2) 'Total_$_Round'
FROM  [Order Details] OD
GROUP BY orderid

-- ==== 1080

-- round bruto and neto, orders more then 15000
SELECT  orderid,SUM(Quantity * UnitPrice) 'Total_Bruto$',
round(SUM(Quantity * UnitPrice *(1-Discount)),1) 'Total_$' 
FROM  [Order Details] OD
GROUP BY orderid
     
     -- Having round(SUM(Quantity * UnitPrice *(1-Discount)),2) > 15000

select *
from [Order Details]

-- how may items in each order, with having

select orderid,count(orderid)'num of product'
from [Order Details]
group by orderid
	having count (orderid) > = 4
order by [num of product] desc



-- ** sum (amount in $ neto) per customer per year

SELECT C.CustomerID, ContactName, YEAR(OrderDate) 'OrderYear',
floor(SUM(Quantity * UnitPrice *(1-Discount))) 'SumPerYear'
FROM Customers C, Orders O, [Order Details] OD
WHERE C.CustomerID = O.CustomerID
      AND O.OrderID = OD.OrderID
GROUP BY C.CustomerID, ContactName, YEAR(OrderDate)
order by C.CustomerID 

select *
from [Order Details]

select Country,count(*) 'NumOfCustomers'
from customers
group by country 
order by NumOfCustomers desc
-- 1080 end 

-- TOP
-- top 4, orders with amount of prod 
select top 4 country,count(*) 'NumOfCustomers'
from  customers
group by country
order by NumOfCustomers  desc

-- without top 
select country,count(*) 'NumOfCustomers'
from  customers
group by country
order by NumOfCustomers desc

-- having
select country,count(*) 'NumOfCustomers'
from customers
group by country 
 --     having count(*) >= 9
order by NumOfCustomers desc 

SELECT COUNT(CustomerID)
FROM Customers
WHERE City = 'London'


-- NUM of items in each category and having >=10, only items in stock
-- table/s, join?, columns

select * from Products order by CategoryID

SELECT CategoryID, COUNT(*) 'Items_InCategory'
FROM Products
Where unitsinstock > 0 and Discontinued = 0
GROUP BY CategoryID 
	having count(*) >= 10
order by count (*) desc

-- NUM of items in each category and having, only items in stock
SELECT categories.CategoryID,categoryname,COUNT(*) 'Items_InCategory'
FROM   Products,categories
Where  Products.categoryid = categories.CategoryID
AND unitsinstock > 0 and Discontinued = 0
GROUP BY categories.CategoryID,CategoryName 
      having count(*) >= 10
order by count (*) desc

select *
from products

--  for each category display num of prod in it and  average price
select p.CategoryID,count(*) 'NumOfProd', avg(UnitPrice) 'Avg Price',
min(unitprice) 'MinPrice', max(unitprice) 'MaxPrice'
from Products P 
group by p.CategoryID

--same with category name
select C.CategoryID, CategoryName, 
count(*) 'NumOfProd', avg(UnitPrice) 'Avg Price'
from Products p join Categories c on p.CategoryID=c.CategoryID
group by C.CategoryID, CategoryName
--having COUNT(*) > 8
order by NumOfProd desc


-- **
-- customers who bought(neto) more than 10,000$ 


select  C.customerid,ContactName,CompanyName, 
floor (SUM(Quantity * UnitPrice * (1-discount)))'TotalCostPerCust'
from [Order Details] od join orders o on od.OrderID=o.OrderID
join Customers c on c.CustomerID=o.CustomerID
group by c.CustomerID, ContactName,CompanyName 
	having SUM(Quantity * UnitPrice * (1-discount)) > 10000
order by TotalCostPerCust desc

-- customers from london who bought more than 5000 
select  C.customerid,ContactName,floor(SUM(Quantity * UnitPrice * (1-discount))) 'TotalCostPerCust'
from [Order Details] od join orders o on od.OrderID=o.OrderID
						join Customers c on c.CustomerID=o.CustomerID
--where city='London'	
group by c.CustomerID, ContactName 
having SUM(Quantity * UnitPrice * (1-discount)) > 5000
order by TotalCostPerCust desc

select firstname,getdate()'todaydate', hiredate, year(getdate()) - year(hiredate) +
	(month(getdate()) - month(hiredate)) / 12.0 'exact seniority',
	year(getdate()) - year(hiredate)'rounded seniority_in years',
	(month(getdate()) - month(hiredate)) / 12.0 'monthNeto'
from employees

select firstname,datediff (month,hiredate,getdate())/12.0 '?'
from   Employees

