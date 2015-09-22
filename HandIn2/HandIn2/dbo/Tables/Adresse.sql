--
-- Create Table    : 'Adresse'   
-- Vejnavn         :  
-- Husnummer       :  
-- Postnummer      :  
-- Bynavn          :  
-- Type            :  
-- AdresseID       :  
--
CREATE TABLE Adresse (
    Vejnavn        CHAR(200) NOT NULL,
    Husnummer      INT NOT NULL,
    Postnummer     INT NOT NULL,
    Bynavn         CHAR(200) NOT NULL,
    Type           CHAR(200) NOT NULL,
    AdresseID      INT NOT NULL,
[Hat] NCHAR(10) NULL, 
    CONSTRAINT pk_Adresse PRIMARY KEY CLUSTERED (AdresseID))