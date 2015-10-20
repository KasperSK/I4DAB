CREATE VIEW [dbo].[Folkeadresser]
	AS SELECT Person.Efternavn, Person.Fornavn, FolkeRegisterAddresse.Bynavn FROM Person, FolkeRegisterAddresse WHERE Person.FolkeAID = FolkeRegisterAddresse.FolkeAID
GO

CREATE VIEW [dbo].[Merkursnumre]
	AS SELECT Telefonummer.Nummer FROM Telefonummer INNER JOIN Person ON Telefonummer.PersonID = Person.PersonID WHERE Person.Fornavn = 'Merkur'
GO

CREATE VIEW [dbo].[Ejerafnummer]
	AS SELECT Person.Efternavn, Person.Fornavn FROM Person INNER JOIN Telefonummer ON Telefonummer.PersonID = Person.PersonID WHERE Telefonummer.Nummer = 90320423
GO