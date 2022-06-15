use Northwind

--1
select FirstName, LastName, HomePhone, Extension
from Employees
where Country != 'UK'

--2
select ProductID, ProductName, UnitsInStock, UnitPrice
from Products
where UnitPrice >= 10 and UnitsInStock >= 2
order by UnitPrice

--3
select FirstName, LastName, HireDate
from Employees
where year(HireDate) = 1992

--4
select ProductName,  UnitsInStock, CompanyName
from Products, Suppliers
where UnitsInStock >= 15 AND LEFT(ProductName, 1) = 'B' or LEFT(ProductName, 1) = 'C' or LEFT(ProductName, 1) = 'M'
ORDER BY LEFT(ProductName, 1)

--5
select *
from Products, Categories
where CategoryName = 'Meat/Poultry' OR CategoryName = 'Dairy Products'
order by ProductName

--6
select CategoryName, ProductName, (UnitPrice * UnitsInStock) 'Profit'
from Products, Categories
order by Profit

--7
select distinct Employees.FirstName, Employees.LastName, CategoryName
from Employees, Categories, Orders
where ShippedDate is not null

--8
select FirstName, LastName, HomePhone, Extension, year(GetDate()) - year(BirthDate) 'Age'
from Employees
order by Age desc

--9
select FirstName, ProductName, Quantity
from Employees E, Orders O, [Order Details] OD, Products P
where E.EmployeeID = O.EmployeeID and  O.OrderID = OD.OrderID and OD.ProductID = P.ProductID and Quantity > 0

--10
select ContactName, OD.OrderID, ProductName, Quantity, P.UnitPrice, (Quantity * P.UnitPrice) 'TotalPrice', (day(O.ShippedDate) - day(O.OrderDate)) 'ShippGap'
from Customers C, Orders O, [Order Details] OD, Products P
where C.CustomerID = O.CustomerID and  O.OrderID = OD.OrderID and OD.ProductID = P.ProductID

--11
select ContactName, (OD.Quantity * OD.UnitPrice) 'PaidInTotal'
from Customers C, Orders O, [Order Details] OD
where C.CustomerID = O.CustomerID and  O.OrderID = OD.OrderID

--12
select O.OrderID, OD.Quantity, UnitsInStock, ((OD.Quantity * 100) / P.UnitsInStock) 'Percentage'
from Customers C, Orders O, [Order Details] OD, Products P
where C.CustomerID = O.CustomerID and  O.OrderID = OD.OrderID and OD.ProductID = P.ProductID and UnitsInStock > 0 and ((OD.Quantity * 100) / P.UnitsInStock) >= 10

--13
select Country, count(Country) 'NumOfEmployees', avg((year(GetDate()) - year(BirthDate))) 'Average Age'
from Employees
group by Country

--14
SELECT C.City, count(City) 'Orders', count(City) * '5' as 'Discount In Percentage'
from Customers C, Orders O
where C.CustomerID = O.CustomerID AND (day(ShippedDate) - day(OrderDate)) >= 5 and City = 'London'
group by City

--15
select P.ProductID, P.ProductName, p.UnitsInStock,p.UnitPrice,(p.UnitPrice * p.UnitsInStock) 'Total Value'
from Products p,[Order Details] od
where p.ProductID = od.ProductID 
group by p.ProductID, p.ProductName, p.UnitsInStock, p.UnitPrice
having sum(od.Quantity) > 500
order by 'Total Value' desc;

--16 ?
select FirstName, (Ord.UnitPrice * count(Ord.UnitPrice)) 'Total'
from Employees E, Orders O, [Order Details] Ord
where E.EmployeeID = O.EmployeeID AND O.OrderID = Ord.OrderID AND ShippedDate is null
group by FirstName, Ord.UnitPrice

--17
select SUM (Ord.UnitPrice) 'Anual Revenue' 
from [Order Details] Ord
INNER JOIN Orders O ON O.OrderID = Ord.OrderID
GROUP BY YEAR(O.OrderDate);

--18
select top 1 with tie ProductID, SUM(Quantity * UnitPrice)
from [Order Details]
GROUP BY ProductID
order by SUM(Quantity * UnitPrice) desc

--19
select top 1 ProductName, sum([Order Details].Quantity * [Order Details].UnitPrice * (1-Discount)) 'Most Profitable'
from Products, [Order Details] 
where Products.ProductID = [Order Details].ProductID
group by ProductName
order by 'Most Profitable' desc;

--20
select p.ProductName,max(od.Quantity) as maxQuantity
from [Order Details] od ,Products p
where p.ProductID = od.ProductID
group by p.ProductName

--21
select distinct C.City, year(O.OrderDate) 'Year', avg((Ord.UnitPrice * Ord.Quantity) * (1 + Ord.Discount)) 'Average Anual Income'
from Customers C, [Order Details] Ord, orders O
where C.CustomerID = O.CustomerID and O.OrderID = Ord.OrderID
group by C.City, year(o.OrderDate)
order by 'Year';

--22
select MONTH(o.OrderDate)as months,count(*)as averagefrom Products p,[Order Details] od,Orders o
where p.ProductID = od.ProductID 
and od.OrderID = o.OrderID
and MONTH(o.OrderDate)=MONTH(o.OrderDate)
group by MONTH(o.OrderDate)