use RealEstate
--Queries
--1

select TypeID, count(H.TypeID) 'NumOfHouses', (SD.HousePrice * h.TypeID) 'TOTAL'
from Sales S, [Sale Details] SD, Houses H
WHERE S.SaleID = SD.SaleID and SD.HouseID = H.HouseID
group by H.TypeID, SD.HousePrice

select * 
from houses