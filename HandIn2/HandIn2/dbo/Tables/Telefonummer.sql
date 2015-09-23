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