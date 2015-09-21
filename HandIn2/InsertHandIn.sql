use db_name
go

DECLARE @person_id INT;
DECLARE @tlf_id INT;
DECLARE @Adr_id INT; 


INSERT INTO Person (Fornavn, Mellemnavn, Efternavn, Forhold)
Values('Kaj', 'Emil', 'Hansen', 'Arbejde')
SET @person_id = SCOPE_IDENTITY() 

INSERT INTO Telefonnummer (Nummer, Type)
Values(82107298, 'Arbejde')
SET @tlf_id = SCOPE_IDENTITY() 

INSERT INTO PersonTelefonnumre (PersonID, NummerID)
Values(@person_id,@tlf_id)

INSERT INTO Adresse (Vejnavn, Husnummer, Postnummer, Bynavn, Type)
Values('Larsvej', 1, 8210, 'Aarhus', 'Arbejde')
SET @Adr_id = SCOPE_IDENTITY() 

INSERT INTO PersonAdresse (PersonID, AdresseID)
Values(@person_id,@Adr_id)
go