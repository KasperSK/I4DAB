--
-- Create Table    : 'FolkeRegisterAddresse'   
-- FolkeAId        :  
-- Vejnavn         :  
-- Husnummer       :  
-- Postnummer      :  
-- Bynavn          :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE FolkeRegisterAddresse (
    FolkeAId       INT IDENTITY NOT NULL,
    Vejnavn        CHAR(200) NOT NULL,
    Husnummer      CHAR(10) NOT NULL,
    Postnummer     INT NOT NULL,
    Bynavn         CHAR(200) NOT NULL,
	PersonId	   INT NULL,
CONSTRAINT pk_FolkeRegisterAddresse PRIMARY KEY CLUSTERED (FolkeAId),
CONSTRAINT fk_Person FOREIGN KEY (PersonId)
    REFERENCES Person (PersonId)
	ON DELETE CASCADE
    ON UPDATE CASCADE
)