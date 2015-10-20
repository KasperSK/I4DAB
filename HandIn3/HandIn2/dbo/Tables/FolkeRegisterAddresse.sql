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
    FolkeAID       INT IDENTITY NOT NULL,
    Vejnavn        CHAR(200) NOT NULL,
    Husnummer      CHAR(10) NOT NULL,
    Postnummer     INT NOT NULL,
    Bynavn         CHAR(200) NOT NULL,
	PersonID	   INT NULL,
CONSTRAINT pk_FolkeRegisterAddresse PRIMARY KEY CLUSTERED (FolkeAID),
CONSTRAINT fk_Person FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
	ON DELETE CASCADE
    ON UPDATE CASCADE
)