/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold)
--Values('Kalle','Rønlev','Møller','Work')

--BEGIN TRANSACTION
--   DECLARE @DataID int;
--   INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold) VALUES ('Kalle','Rønlev','Møller','Work');
--   SELECT @DataID = scope_identity();
--   INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, PersonID) VALUES ("fisk","hat",8210,"Aarhus", @DataID);
--COMMIT


DECLARE @lastadr int
DECLARE @lastperson int

-- First insert
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('fiskVej','hat',8210,'Aarhus V')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold, FolkeAID) Values('Kalle','Rønlev','Møller','Work', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Work', 10010010, @lastperson)
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('HesteVej', '2', 3000, 'Lem', 'Sommerhus', @lastperson) 

-- Second insert
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('AndVej','tophat', 8210,'Aarhus V')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold, FolkeAID) Values('Kasper','Sejer','Kristensen','Work', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Work', 20020020, @lastperson)
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('KatteVej', '200', 6880, 'Tarm', 'Sommerhus', @lastperson)

-- Third insert
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('AndVej','tophat', 8210,'Aarhus V')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Efternavn, Forhold, FolkeAID) Values('Alexandros','Hippolytos','Work', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Work', 20020020, @lastperson)
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('KatteVej', '200', 6880, 'Tarm', 'Sommerhus', @lastperson) 

-- Fourth insert
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('GrisVej','6E', 8210,'Aarhus V')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Efternavn, Forhold, FolkeAID) Values('Kristian','Mosegaard','Familie', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Work', 20020020, @lastperson)
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('KatteVej', '200', 6880, 'Tarm', 'Sommerhus', @lastperson) 
INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Mobil', 30030030, @lastperson)
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('HundeVej', '666', 7620, 'Paris', 'Arbejde', @lastperson) 

-- Fifth insert
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('KyllingVej','2E', 8210,'Aarhus V')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold, FolkeAID) Values('Peter','Ring','Pedersen','Ven', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Privat', 22002200, @lastperson)


-- Six
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('KoVej','9E', 8210,'Aarhus V')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Efternavn, Forhold, FolkeAID) Values('Apollon','Tiw','Work', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Work', 12312312, @lastperson)


-- Seven
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('PindsvinVej','220E', 8210,'Aarhus V')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold, FolkeAID) Values('Anoubis','Numitor','Argus','Familie', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Privat', 11122233, @lastperson)
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('ÆbleVej', '666', 7620, 'Paris', 'Arbejde', @lastperson) 
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('PæreVej', '666', 7620, 'Rom', 'Sommerhus', @lastperson) 
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('MuskatVej', '666', 3000, 'Snested', 'PartyHOUSE', @lastperson) 

-- Eight
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('DameVej','540O', 6940,'Lem St.')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Efternavn, Forhold, FolkeAID) Values('Line','Smed','Ven', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Privat', 23841823, @lastperson)

-- Nine
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('NumseVej','20', 2412,'Julemanden')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold, FolkeAID) Values('Jupiter','Mars','Romulus','Ven', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Work', 12312312, @lastperson)
INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Privat', 90320423, @lastperson)
INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Mobil', 24059873, @lastperson)

-- Ten
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('TisselsVej','123', 8210,'Aarhus V')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold, FolkeAID) Values('Merkur','Brutus','Quirinus','Ememy', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Work', 12312312, @lastperson)
INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Privat', 90320423, @lastperson)
INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Mobil', 24059873, @lastperson)
INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Work', 12323312, @lastperson)
INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Privat', 903232423, @lastperson)
INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Mobil', 25459873, @lastperson)

-- Eleven FOR DELETION!!!
INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('TjørnVej','220E', 8270,'Højbjerg')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold, FolkeAID) Values('Loki','Mot','Nudd','Familie', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonID=@lastperson WHERE FolkeAID = @lastadr

INSERT INTO Telefonummer (Type, Nummer, PersonID) Values('Privat', 11122233, @lastperson)
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('ÆbleVej', '66C', 7620, 'Paris', 'Arbejde', @lastperson) 
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('PæreVej', '66V', 7620, 'Rom', 'Sommerhus', @lastperson) 
INSERT INTO EkstraAddresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type, PersonID) Values('MuskatVej', '66A', 7752, 'Snedsted', 'PartyHOUSE', @lastperson) 

-- DELETE FROM Person WHERE PersonID = @lastperson;

DELETE FROM Person WHERE Person.Fornavn = 'Line' AND Person.Efternavn = 'Smed'

DECLARE @peter int
SELECT @peter = PersonID FROM Person WHERE Fornavn = 'Peter' AND Efternavn = 'Pedersen'
UPDATE Telefonummer SET Nummer='80808080' WHERE Telefonummer.PersonID = @peter