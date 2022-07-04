use RealEstate
--Queries

select TypeID, count(H.TypeID) 'NumOfHouses', (SD.HousePrice * h.TypeID) 'TOTAL'
from Sales S, [Sale Details] SD, Houses H
WHERE S.SaleID = SD.SaleID and SD.HouseID = H.HouseID
group by H.TypeID, SD.HousePrice

select H.TypeID, sum(sd.HousePrice) 'TOTAL', year(s.SaleDate) 'Year of Sales'
from Sales S, [Sale Details] SD, Houses H
WHERE S.SaleID = SD.SaleID and SD.HouseID = H.HouseID
group by h.TypeID, year(s.SaleDate)

SELECT Neighborhood, AVG(HousePrice) 'AverageHousingPrices'
FROM Houses 
GROUP BY Neighborhood
ORDER BY AVG(HousePrice) desc

select SalesmanID, FirstName, LastName, SalesMade
from Salesmen SM
where SalesMade = (SELECT MAX(SalesMade) FROM Salesmen)