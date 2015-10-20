USE E15I4DABH2Gr7
GO

DECLARE @peter int
SELECT @peter = PersonID FROM Person WHERE Fornavn = 'Peter' AND Efternavn = 'Pedersen'
UPDATE Telefonummer SET Nummer='80808080' WHERE Telefonummer.PersonID = @peter
GO