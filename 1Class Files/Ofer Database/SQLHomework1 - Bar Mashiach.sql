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