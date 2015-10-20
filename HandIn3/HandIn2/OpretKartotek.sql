USE E15I4DABH2Gr11
GO
 
--
-- Create Table    : 'Person'   
-- PersonID        :  
-- Fornavn         :  
-- Mellemnavn      :  
-- Efternavn       :  
-- Forhold         :  
--
CREATE TABLE Person (
    PersonID       INT IDENTITY NOT NULL,
    Fornavn        CHAR(200) NOT NULL,
    Mellemnavn     CHAR(200) NULL,
    Efternavn      CHAR(200) NOT NULL,
    Forhold        CHAR(200) NOT NULL,
	FolkeAID	   INT NOT NULL,
CONSTRAINT pk_Person PRIMARY KEY CLUSTERED (PersonID),
CONSTRAINT fk_FolkeRegisterA
	FOREIGN KEY (FolkeAID)
    REFERENCES FolkeRegisterAddresse (FolkeAID))
GO

--
-- Create Table    : 'Telefonummer'   
-- NummerID        :  
-- Type            :  
-- Nummer          :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE Telefonummer (
    NummerID       INT IDENTITY NOT NULL,
    Type           CHAR(200) NOT NULL,
    Nummer         INT NOT NULL,
    PersonID       INT NOT NULL,
CONSTRAINT pk_Telefonummer PRIMARY KEY CLUSTERED (NummerID),
CONSTRAINT fk_Telefonummer FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO

--
-- Create Table    : 'EkstraAddresse'   
-- AdresseID       :  
-- Vejnavn         :  
-- Husnummer       :  
-- Postnummer      :  
-- Bynavn          :  
-- Type            :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE EkstraAddresse (
    AdresseID      INT IDENTITY NOT NULL,
    Vejnavn        CHAR(200) NOT NULL,
    Husnummer      CHAR(10) NOT NULL,
    Postnummer     INT NOT NULL,
    Bynavn         CHAR(200) NOT NULL,
    Type           CHAR(200) NOT NULL,
    PersonID       INT NOT NULL,
CONSTRAINT pk_EkstraAddresse PRIMARY KEY CLUSTERED (AdresseID),
CONSTRAINT fk_EkstraAddresse FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
GO

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
GO