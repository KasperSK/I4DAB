--
-- Create Table    : 'FolkeRegisterAddresse'   
-- FolkeAId        :  
-- Vejnavn         :  
-- Husnummer       :  
-- Postnummer      :  
-- Bynavn          :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE EkstraAddresse (
    [Id]       INT IDENTITY NOT NULL,
	PersonID	   INT NOT NULL,
	AddresseID	   INT NOT NULL,
	Forhold		   CHAR(200) NOT NULL,
CONSTRAINT pk_EkstraAddresse PRIMARY KEY CLUSTERED ([Id]),
CONSTRAINT fk_Person FOREIGN KEY (PersonID)
    REFERENCES Person (Id),
CONSTRAINT fk_Addresse FOREIGN KEY (AddresseID)
    REFERENCES Addresse (Id),

)