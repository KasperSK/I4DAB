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