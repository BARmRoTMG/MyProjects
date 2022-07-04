--creating DB
--drop database RealEstate
CREATE DATABASE RealEstate;

--Creating Tables
CREATE TABLE "Salesmen" (
	"SalesmanID" "int" IDENTITY (1, 1) NOT NULL ,
	"FirstName" nvarchar (10) NOT NULL ,
	"LastName" nvarchar (20) NOT NULL ,
	"Title" nvarchar (30) NULL ,
	"SalesMade" nvarchar (25) NULL ,
	"Specialize" "INT" NULL,
	"BirthDate" "datetime" NULL ,
	"HireDate" "datetime" NULL ,
	"Address" nvarchar (60) NULL ,
	"City" nvarchar (15) NULL ,
	"Region" nvarchar (15) NULL ,
	"PostalCode" nvarchar (10) NULL ,
	"Country" nvarchar (15) NULL ,
	"HomePhone" nvarchar (24) NULL ,
	"Extension" nvarchar (4) NULL 
	CONSTRAINT "PK_Salesmen" PRIMARY KEY  CLUSTERED 
	(
		"SalesmanID"
	),
	CONSTRAINT "FK_Specialize" FOREIGN KEY
	(
		"Specialize"
	) 
	REFERENCES "dbo"."Salesmen"
	(
		"SalesmanID" 
	)
)

CREATE TABLE "Customers" (
	"CustomerID" nchar (5) NOT NULL ,
	"CustomerFirstName" nvarchar (40) NOT NULL ,
	"CustomerLastName" nvarchar (40) NOT NULL ,
	"NumOfHouses" int NULL,
	"Address" nvarchar (60) NULL ,
	"City" nvarchar (15) NULL ,
	"Region" nvarchar (15) NULL ,
	"PostalCode" nvarchar (10) NULL ,
	"Country" nvarchar (15) NULL ,
	"Phone" nvarchar (24) NULL 

	CONSTRAINT "PK_Customers" PRIMARY KEY  CLUSTERED 
	(
		"CustomerID"
	)
)

CREATE TABLE "HouseType" (
	"TypeID" "int" IDENTITY (1, 1) NOT NULL ,
	"TypeName" nvarchar (15) NOT NULL ,
	"Description" "ntext" NULL ,
	"Picture" "image" NULL ,
	CONSTRAINT "PK_HouseType" PRIMARY KEY  CLUSTERED 
	(
		"TypeID"
	)
)

CREATE TABLE "Houses" (
	"HouseID" "int" IDENTITY (1, 1) NOT NULL ,
	"SalesmanID" "int" NULL ,
	"TypeID" "int" NULL ,
	"HousePrice" "money" NULL CONSTRAINT "DF_Products_UnitPrice" DEFAULT (0),
	"Neighborhood" nvarchar (20) null,
	"City" nvarchar (20) null,
	CONSTRAINT "PK_Houses" PRIMARY KEY  CLUSTERED 
	(
		"HouseID"
	),
	CONSTRAINT "FK_Houses_HouseType" FOREIGN KEY 
	(
		"TypeID"
	) REFERENCES "dbo"."HouseType" (
		"TypeID"
	),
	CONSTRAINT "FK_Houses_Salesmen" FOREIGN KEY 
	(
		"SalesmanID"
	) REFERENCES "dbo"."Salesmen" (
		"SalesmanID"
	),
	CONSTRAINT "CK_Houses_HousePrice" CHECK (HousePrice >= 0)
)


CREATE TABLE "Sales" (
	"SaleID" "int" IDENTITY (1, 1) NOT NULL ,
	"CustomerID" nchar (5) NULL ,
	"SalesmanID" "int" NULL ,
	"SaleDate" "datetime" NULL ,
	"HouseAddress" nvarchar (60) NULL ,
	"HouseCity" nvarchar (15) NULL ,
	"HouseRegion" nvarchar (15) NULL ,
	"HousePostalCode" nvarchar (10) NULL ,
	"HouseCountry" nvarchar (15) NULL ,
	CONSTRAINT "PK_Sales" PRIMARY KEY  CLUSTERED 
	(
		"SaleID"
	),
	CONSTRAINT "FK_Sales_Customers" FOREIGN KEY 
	(
		"CustomerID"
	) REFERENCES "dbo"."Customers" (
		"CustomerID"
	),
	CONSTRAINT "FK_Orders_Salesmen" FOREIGN KEY 
	(
		"SalesmanID"
	) REFERENCES "dbo"."Salesmen" (
		"SalesmanID"
	)
)


CREATE TABLE "Sale Details" (
	"SaleID" "int" NOT NULL ,
	"HouseID" "int" NOT NULL ,
	"HousePrice" "money" NOT NULL CONSTRAINT "DF_Order_Details_UnitPrice" DEFAULT (0),
	"Discount" "real" NOT NULL CONSTRAINT "DF_Order_Details_Discount" DEFAULT (0),
	CONSTRAINT "PK_Sale_Details" PRIMARY KEY  CLUSTERED 
	(
		"SaleID",
		"HouseID"
	),
	CONSTRAINT "FK_Sale_Details_Sales" FOREIGN KEY 
	(
		"SaleID"
	) REFERENCES "dbo"."Sales" (
		"SaleID"
	),
	CONSTRAINT "FK_Sales_Details_Houses" FOREIGN KEY 
	(
		"HouseID"
	) REFERENCES "dbo"."Houses" (
		"HouseID"
	),
	CONSTRAINT "CK_Discount" CHECK (Discount >= 0 and (Discount <= 1)),
	CONSTRAINT "CK_HousePrice" CHECK (HousePrice >= 0)
)


--Inserting Data Customers
INSERT into Customers  VALUES(1, 'Bar', 'Mashiach', 0, 'Derech Hayam 24', 'Ganei Tikva', 'Israel', '55555', 'Israel', '0547443655')
INSERT into Customers  VALUES(2, 'Niso', 'Mazganim', 0, 'Eilat 12', 'Petach Tikva', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(3, 'Gabi', 'Mulner', 0, 'Derech Hashalom 54', 'Tel Aviv', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(4, 'Joey', 'Tribiani', 0, 'Street1', 'Tel Aviv', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(5, 'Ross', 'Geller', 0, 'Street2', 'Tel Aviv', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(6, 'Monika', 'Geller', 0, 'Street3', 'Tel Aviv', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(7, 'Rachel', 'Green', 0, 'Street4', 'Tel Aviv', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(8, 'Chandler', 'Bing', 0, 'Street5', 'Tel Aviv', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(9, 'Fibi', 'Bufe', 0, 'Street6', 'Petach Tikva', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(10, 'Arnold', 'Shwartzeneger', 0, 'Street7', 'Petach Tikva', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(11, 'Leo', 'Messi', 0, 'Street8', 'Petach Tikva', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(12, 'Neymar', 'Junior', 0, 'Street9', 'Petach Tikva', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(13, 'Asher', 'Swissa', 0, 'Street10', 'Ganei Tikva', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(14, 'Amit', 'Agami', 0, 'Street11', 'Ganei Tikva', 'Israel', '55555', 'Israel', '05252525252')
INSERT into Customers  VALUES(15, 'Adam', 'Ten', 0, 'Street12', 'Ganei Tikva', 'Israel', '55555', 'Israel', '05252525252')


--Inserting Data Salesmen
set quoted_identifier on
go
set identity_insert Salesmen on
go
ALTER TABLE Salesmen NOCHECK CONSTRAINT ALL
go
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(1, 'Bar', 'Mashiach', 'Manager', 0, getDate() - year(5), 'Ganei Tikva', 'Israel', '7443655', '054')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(2, 'Ben', 'Banner', 'Salesman', 0, getDate() - year(3), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(3, 'Nir', 'Niro', 'Salesman', 0, getDate() - year(3), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(4, 'Sam', 'Sami', 'Salesman', 0, getDate() - year(1), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(5, 'Noam', 'Gletzer', 'Salesman', 0, getDate() - year(1), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(6, 'Shon', 'Solomon', 'Salesman', 0, getDate() - year(4), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(7, 'Idan', 'Nakash', 'Salesman', 0, getDate() - year(4), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(8, 'Matan', 'Cohen', 'Salesman', 0, getDate() - year(2), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(9, 'Omri', 'Sin', 'Salesman', 0, getDate() - year(1), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(10, 'Ben', 'Henson', 'Salesman', 0, getDate() - year(3), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(11, 'Itay', 'Naiberg', 'Salesman', 0, getDate() - year(3), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(12, 'Ori', 'Mandler', 'Salesman', 0, getDate() - year(3), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(13, 'Ohad', 'Malaku', 'Salesman', 0, getDate() - year(2), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(14, 'Bar', 'Edri', 'Salesman', 0, getDate() - year(4), 'Ashkelon', 'Israel', '3598655', '053')
Insert Into Salesmen (SalesmanID, FirstName, LastName, Title, SalesMade, HireDate, City, Country, HomePhone, Extension) VALUES(15, 'Inbar', 'Sagi', 'Salesman', 0, getDate() - year(3), 'Ashkelon', 'Israel', '3598655', '053')
go
set identity_insert Salesmen off
go
ALTER TABLE Salesmen CHECK CONSTRAINT ALL
go


--Inserting Data HouseType
set quoted_identifier on
go
set identity_insert HouseType on
go
ALTER TABLE HouseType NOCHECK CONSTRAINT ALL
go
INSERT into HouseType (TypeID, TypeName, "Description", Picture) Values(1, 'Villa', 'A large scale floor house with a garden and a front yard.', null)
INSERT into HouseType (TypeID, TypeName, "Description", Picture) Values(2, 'Penthouse', 'A large scale apartment on the top level of a building with a open roof.', null)
INSERT into HouseType (TypeID, TypeName, "Description", Picture) Values(3, 'Apartment', 'A building apartment', null)
INSERT into HouseType (TypeID, TypeName, "Description", Picture) Values(4, 'House', 'A regular floor house', null)
go
set identity_insert HouseType off
go
ALTER TABLE HouseType CHECK CONSTRAINT ALL
go




--Inserting Data Houses
set quoted_identifier on
go
set identity_insert Houses on
go
ALTER TABLE Houses NOCHECK CONSTRAINT ALL
go
--Neighborhoods - TLV Town, Shenkin, Savyon
--City's - Tel Aviv, Givatayim, Savyon
--Villa
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(1, 2, 1, 'Savyon', 'Savyon', 4200000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(2, 2, 1, 'Savyon', 'Savyon', 4550000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(3, 2, 1, 'Savyon', 'Savyon', 3895000)

--Penthouse
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(4, 3, 2, 'TLV Town', 'Tel Aviv', 3980000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(5, 3, 2, 'TLV Town', 'Tel Aviv', 3700000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(6, 3, 2, 'Shenkin', 'Givatayim', 3550000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(7, 3, 2, 'TLV Town', 'Tel Aviv', 2980000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(8, 3, 2, 'Shenkin', 'Givatayim', 3000000)

--Apartment
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(9, 4, 3, 'TLV Town', 'Tel Aviv', 2500000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(10, 4, 3, 'TLV Town', 'Tel Aviv', 1800000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(11, 4, 3, 'Shenkin', 'Givatayim', 1860000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(12, 4, 3, 'TLV Town', 'Tel Aviv', 2000000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(13, 4, 3, 'Shenkin', 'Givatayim', 1350000)

--House
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(14, 5, 4, 'Savyon', 'Savyon', 2500000)
Insert Into Houses(HouseID, SalesmanID, TypeID, Neighborhood, City, HousePrice) Values(15, 5, 4, 'Shenkin', 'Givatayim', 2450000)
go
set identity_insert Houses off
go
ALTER TABLE Houses CHECK CONSTRAINT ALL
go





--Inserting Data Sales
set quoted_identifier on
go
set identity_insert Sales on
go
ALTER TABLE Sales NOCHECK CONSTRAINT ALL
go
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (1, 1, 2, GetDate() - year(1))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (2, 2, 3, GetDate() - year(2))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (3, 3, 4, GetDate() - year(3))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (4, 4, 5, GetDate() - day(100))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (5, 5, 6, GetDate() - day(130))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (6, 6, 7, GetDate() - day(150))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (7, 7, 8, GetDate() - day(200))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (8, 8, 9, GetDate() - month(1))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (9, 9, 10, GetDate() - month(2))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (10, 10, 11, GetDate() - month(7))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (11, 11, 12, GetDate() - month(8))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (12, 12, 13, GetDate() - month(5))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (13, 13, 14, GetDate() - month(3))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (14, 14, 15, GetDate() - year(1))
Insert Into Sales (SaleID, CustomerID, SalesmanID, SaleDate) Values (15, 15, 1, GetDate() - year(1))
go
set identity_insert Sales off
go
ALTER TABLE Sales CHECK CONSTRAINT ALL
go


--Inserting Data Sale Details
Insert [Sale Details] values (1, 1, 4200000, 0)
Insert [Sale Details] values (2, 2, 4550000, 0)
Insert [Sale Details] values (3, 3, 3895000, 0)
Insert [Sale Details] values (4, 4, 3980000, 0)
Insert [Sale Details] values (5, 5, 3700000, 0)
Insert [Sale Details] values (6, 6, 3550000, 0)
Insert [Sale Details] values (7, 7, 2980000, 0)
Insert [Sale Details] values (8, 8, 3000000, 0)
Insert [Sale Details] values (9, 9, 2500000, 0)
Insert [Sale Details] values (10, 10, 1800000, 0)
Insert [Sale Details] values (11, 11, 1860000, 0)
Insert [Sale Details] values (12, 12, 2000000, 0)
Insert [Sale Details] values (13, 13, 1350000, 0)
Insert [Sale Details] values (14, 14, 2500000, 0)
Insert [Sale Details] values (15, 15, 2450000, 0)

UPDATE Salesmen SET SalesMade = 9 WHERE SalesmanID = 1;  






