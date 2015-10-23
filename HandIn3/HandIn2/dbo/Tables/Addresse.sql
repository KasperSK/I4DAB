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
CREATE TABLE Addresse (
    [Id]      INT IDENTITY NOT NULL,
    Vejnavn        CHAR(200) NOT NULL,
    Husnummer      CHAR(10) NOT NULL,
    Postnummer     INT NOT NULL,
    Bynavn         CHAR(200) NOT NULL,
CONSTRAINT pk_Addresse PRIMARY KEY CLUSTERED ([Id]),
)