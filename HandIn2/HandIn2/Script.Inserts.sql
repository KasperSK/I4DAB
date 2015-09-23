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

INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES ('fisk','hat',8210,'Aarhus')
SELECT @lastadr = SCOPE_IDENTITY()

INSERT INTO FolkeRegisterAddresse (Vejnavn, Husnummer, Postnummer, Bynavn) VALUES('Hej', 'MED', 10, 'Dig')

INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold, FolkeAId) Values('Kalle','Rønlev','Møller','Work', @lastadr)
SELECT @lastperson = SCOPE_IDENTITY()
UPDATE FolkeRegisterAddresse SET PersonId=@lastperson WHERE FolkeAId = @lastadr

DELETE FROM Person WHERE PersonID = @lastperson;