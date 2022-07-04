-- default DB 
use northwind

-- all customers
select *
from Employees

-- reports to
select EmployeeID,FirstName,city,Country,ReportsTo
from Employees


-- employee role
select FirstName,Title,TitleOfCourtesy,HomePhone
from Employees

-- customer details code,name,city,country
select customerid,CompanyName,contactname,city,country 
from  Customers

-- Supplier details code,name,address,city,country           drag columns [  ] 
select [SupplierID],[CompanyName],[Address],[City],Country
from [dbo].[Suppliers]

-- company business
select *
from Categories

-- customer details
select customerid,companyname,contactname,city,Country
from Customers

-- calculated column
select ProductID,productname,UnitsInStock * UnitPrice 
from Products

-- calculated with as
select ProductID,productname,UnitsInStock * UnitPrice as 'Total$_PerItem' 
from Products

-- 1st option
select ProductID,productname,unitsinstock,unitprice, 
UnitsInStock * UnitPrice AS 'Item_Total$'
from Products

-- as 2nd option
select ProductID,productname,unitprice,unitsinstock,
'Item_Total$'= UnitsInStock * UnitPrice 
from Products

-- distinct eliminate duplications
select distinct city
from employees

select city 
from Employees

select distinct firstname
from Employees

-- country from customers no duplications

select country
from Customers

select distinct Country
from Customers


-- Distinct should not be run for unique columns
select distinct CustomerID          --,companyname     --,[CompanyName]
from Customers

select distinct Country
from Suppliers

select Country,City
from Customers

select distinct Country,City 
from Customers

select distinct city,Country
from Customers

-- data from another DB 
select *
from northwind.dbo.Categories

-- functions                              
-- replace string 
select FirstName,replace (FirstName, 'ST','999ZZ_')as Replaced
from Employees

select city,replace (city, 'lonDon','GB_London')'NewCity'
from Employees

-- from place , num of chars
select firstname,SUBSTRING (FirstName,1,4) 'SubString'
from Employees

select HomePhone,substring(HomePhone,6,99) as 'Tel_No_extension'
from Employees

-- using ltrim to cut left blanks
select HomePhone,ltrim(substring(HomePhone,6,99)) as 'Tel_No_extension'
from Employees

-- extension only from place 1 display 5 chars
select HomePhone,SUBSTRING(homephone,1,5) 'extension'
from Employees 

-- left or right chars in string
SELECT companyname,LEFT(CompanyName,5)'5left',right(companyname,5)'5right'
FROM Customers;

--  length, number of chars
select HomePhone,len(homephone) 'NumOfChars'
from Employees

-- Combine len and substring
select HomePhone,len(homephone)'len',
substring(HomePhone,len(homephone)-8,99) 'TelWithnoExtention'
from Employees

-- capital letters and low letters
Select UPPER(firstname) 'CAPS',LOWER('ABCDname') 'Regular'
from Employees
-- ==================================================
-- current date universal time
select getdate() 'Getdate',getutcdate () 'UTC'

select firstname,hiredate
from Employees

-- employee with hiredate
select employeeid,firstname,hiredate,
year (HireDate) 'YYYY',month (HireDate) 'MM',day(HireDate) 'DD'
from Employees

-- current date
select year (getdate())'YY',month(getdate())'MM',
day(getdate())'DD'


-- emp name with hiredate
select employeeid,firstname,city,
year (HireDate) 'YYYY',month (HireDate) 'MM',day(HireDate) 'DD'
from Employees

-- emp name with birthdate

select firstname,year (BirthDate) 'YYYY',month (birthdate) 'MM',
day (birthdate) 'DD'	
from Employees

-- order date 

select orderid,orderdate,
year(orderdate) 'YYYY',month (orderdate) 'MM',day (OrderDate) 'DD'
from Orders

-- emp name,city,country, age in years


-- date functions wrong ....
select FirstName,city,country,2022 - year (BirthDate) 'Age'
from Employees

-- correct, date as parameter
select FirstName,city,country,year (getdate()) - year (birthdate) 'Age'
from Employees

-- datediff, employees age in years
select firstname,DATEDIFF(YEAR,birthdate,getdate()) 'Date_in_years' 
from Employees

-- datediff, employees age in month and years
select firstname,DATEDIFF(MONTH,birthdate,getdate()) 'Age_in_month' 
from Employees

-- datediff, employees age in month and years accurate float
select firstname,DATEDIFF(month,birthdate,getdate())/12.0 'Age_in_month' 
from Employees

select firstname,DATEDIFF(day,BirthDate,getdate()) 'Age_in_days'
from Employees

select firstname,DATEDIFF(day,BirthDate,getdate())/ 365.0 'Age_in_days'
from Employees

-- hire date in years accurate by date
select firstname,HireDate,DATEDIFF(DAY,hireDate,getdate())/365.0 'Hire_in_Days'
from Employees

-- each char is 2 bytes in DB
select firstname,DATALENGTH (firstname) 'LengthInBytes'
from Employees

-- merge columns with concat or +
select concat(firstname,' ',city)'name city'
from employees

-- merge columns with concat or +
select concat(firstname,' ',EmployeeID)'name id'
from employees

select firstname + ' '  + city + ' ' + country 'Name_city_Country'
from Employees

select concat(firstname,' From ', city,Country) 'Name_city'
from employees


select concat(firstname,' Hired ', month(hiredate),'/',year(hiredate))
from employees


-- round the number after ,num is the digit that rounded
select round (125.8645,0)   'R 0'
select round (125.8645,1)   'R 1'
select round (125.8645,2)   'R 2'
select round (125.8645,3)   'R 3'
select round (125.8645,4)   'R 4'
select round (125.0000,-1) '-1'
select round (123.0000,-1) '-1'
select round (123.0000,-2) '-2'

-- unitprice rounded
select unitprice,round(unitprice,0) '0',round (unitprice,1) '1' 
from products

-- floor to the nearest small number
select 123.9999,floor (123.9999) 'floor'
select floor (0.58888)
select floor (-125.99999)
select floor (-9999.9999)
select ceiling (0.5888)
-- ===================================================
-- hire date in years accurate with and without round
select firstname,(DATEDIFF(DAY,hiredate,getdate())/365.0) 'date_in_Years'
from Employees

select firstname,round(DATEDIFF(DAY,HireDate,getdate())/365.0,1)'date_in_Years'
from Employees

-- when draging from object explorer
select [FirstName],[HireDate]
from [dbo].[Employees]

-- more functions
select sqrt(16)'sqrt16',log(2000000.0)'log',sign(-10*1/8*5)'s',sign(10*10-10+10)'s',
power(4,4)'power',CURRENT_TIMESTAMP'time stamp',getdate()'getdate',
44 / 5 '44/5',44/5.0 'float', 44 % 5 'Remainder modulu'

-- place of t in firstname, 1st 
SELECT firstname,CHARINDEX('t',firstname) AS Position,
CHARINDEX(' ','att att') 'BlankPlace'
from Employees;


--soundex similarity, 0 weak, 4 strong
SELECT DIFFERENCE('123456','888856'),DIFFERENCE('abcdeioe', '1234');

-- format integer
SELECT FORMAT(123456789, '##-##-#####');

SELECT companyname,LEFT(CompanyName, 5) 'left',right(companyname,5) 'right'
FROM  Customers;

-- reverse string
SELECT REVERSE('1080abcd');

-- spaces
select space(10)+ ' ' +firstname
from Employees

-- ltrim remove leading spaces from a character variable, here dispaly date clearly
select hiredate,ltrim(hiredate) 'ltrim_Date',rtrim(hiredate)'rtrim date',
ltrim('    abcd')'ltrim',rtrim ('      jhghjg      ')'rtrim'
from Employees




-- where in next file
select *
from Employees
where EmployeeID >= 8 

-- products details where stock bigger than 0

select ProductID, ProductName,Unitprice, UnitsInStock, ReorderLevel, QuantityPerUnit
from Products
where UnitsInStock > 20

