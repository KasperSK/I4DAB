USE Northwind;

--Opgave 1 
--find alt fra Customers

-- SELECT * FROM Customers;

--Opgave 2
--Find efternavn(LastName), fornavn(FirstName), fødselsdato(BirthDate), by(City) og land(Country) på alle ansatte(Employees).

-- SELECT LastName, FirstName, BirthDate, City, Country FROM Employees;

-- Opgave 3 
-- Find forskellige lande(Country) på alle ansatte(Employees). Resultatet må ikke indeholde dubletter.

-- SELECT DISTINCT Country FROM Employees;

-- Opgave 4 
-- Find alle rækker på kunder(Customers), der bor i UK(Country).

-- SELECT * FROM Customers WHERE Country = 'UK';

-- Opgave 5
-- Find alle rækker på ordrerdetaljer(Order Details), hvor antal(Quantity) er mellem 10 og 20, begge inklusiv.
-- Hint: Brug [] omkring Order Details ellers vil Query Analyzeren læse det som seperate ord.

-- SELECT * FROM [Order Details] WHERE 10 <= Quantity AND Quantity <= 20;

-- Opgave 6
-- Find LastName, FirstName, BirthDate, City og Country på ansatte(Employees), der har ordet "Sales" i deres titel(Title).

-- SELECT LastName, FirstName, BirthDate, City, Country FROM Employees WHERE Title LIKE '%Sales%';

-- Opgave 7 
-- Find CustomerID, CompanyName på alle kunder, der bor i London(City). Resultatet skal være sorteret alfabetisk på PostalCode.

-- SELECT CustomerID, CompanyName FROM Customers WHERE City = 'London' ORDER BY PostalCode;

-- Opgave 8
-- Find alle kunder fra USA og Spain, der har en ContactTitle "Marketing Manager". Resultatet skal sorteres omvendt alfabetisk på CompanyName.

-- SELECT * FROM Customers WHERE ContactTitle = 'Marketing Manager' ORDER BY CompanyName DESC;

-- Opgave 9
-- Find alle rækker kunder fra UK, USA og Spain, der ikke har defineret nogen Fax.

-- SELECT * FROM Customers WHERE (Country = 'UK' OR Country = 'USA' OR Country = 'Spain') AND Fax IS NULL;

-- Opgave 10
-- Hvor mange kunder(Customers)  er der ?

-- SELECT count(*) FROM Customers;

-- Opgave 11
-- Hvad er min-, max- og gennemsnitprisen(UnitPrice) af alle ordrerdetaljer(Order Details)? Hint: Brug [] omkring Order Details ellers vil Query Analyzer'en læse det som seperate ord.

-- SELECT min(UnitPrice), max(UnitPrice), avg(UnitPrice) FROM [Order Details];

-- Opgave 12
-- Hvad er summen af alle enheder(Quantities) i ordredetaljer ?

-- SELECT sum(Quantity) FROM [Order Details];

-- Opgave 13
-- Hvor mange forskellige ordrer(OrdreID's) var der i July 1996 ?
-- Hint: Dato skal angives som ‘DD-Mon-YYYY’, eks: ’01-Jul-1996’
-- Eller brug funktionerne YEAR() og MONTH(), se i SQL Server Books Online

-- SELECT DISTINCT OrderID FROM Orders WHERE year(OrderDate) = 1996 and month(OrderDate) = 7;

-- Opgave 14
-- Find antal kunder fra hvert land(Country). Overskrifterne på søjlerne skal være ’Land’ og ’Antal kunder i landet’ 

-- SELECT DISTINCT Country, count(Country) AS 'Antal kunder' FROM Customers GROUP BY Country;

-- Opgave 15
-- Find antal kunder fra hvert land(Country), hvor vi har mere end 2 kunder.

-- SELECT DISTINCT Country, count(Country) AS 'Antal kunder' FROM Customers GROUP BY Country HAVING count(Country) > 1;

-- Opgave 16
-- Find FirstName, LastName og City af alle ansatte(Employees), der har haft ordrer i July 1996.
-- Hints: Brug "IN", brug order tabellen i subquery og dato skal angives som ‘DD-Mon-YYYY’

-- SELECT FirstName, LastName, City FROM Employees WHERE 1996 IN (SELECT year(OrderDate) FROM Orders) and 7 IN (SELECT month(OrderDate) FROM Orders);

-- Opgave 17
-- Find alle rækker på ordrer vi har haft til kunder fra Mexico.

-- SELECT * FROM Orders JOIN Customers ON (Orders.CustomerID = Customers.CustomerID) WHERE Country = 'Mexico';

-- Opgave 18
-- Find alle rækker på ordrer vi havde i 1997 på kunder fra Mexico. Resultatet skal sorteres stigende på CustomerID og faldende på OrderDate.

