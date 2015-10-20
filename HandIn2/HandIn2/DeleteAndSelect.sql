Use E15I4DABH2Gr7
GO

DELETE FROM Person WHERE Person.Fornavn = 'Line' AND Person.Efternavn = 'Smed'

DECLARE @peter int
SELECT @peter = PersonID FROM Person WHERE Fornavn = 'Peter' AND Efternavn = 'Pedersen'
UPDATE Telefonummer SET Nummer='80808080' WHERE Telefonummer.PersonID = @peter

SELECT Person.Efternavn, Person.Fornavn, FolkeRegisterAddresse.Bynavn FROM Person, FolkeRegisterAddresse WHERE Person.FolkeAID = FolkeRegisterAddresse.FolkeAID
SELECT Telefonummer.Nummer FROM Telefonummer INNER JOIN Person ON Telefonummer.PersonID = Person.PersonID WHERE Person.Fornavn = 'Merkur'
SELECT Person.Efternavn, Person.Fornavn FROM Person INNER JOIN Telefonummer ON Telefonummer.PersonID = Person.PersonID WHERE Telefonummer.Nummer = 90320423
GO