--
-- Create Table    : 'Telefonnummer'   
-- NummerID        :  
-- Type            :  
-- Nummer          :  
-- PersonID        :  (references Person.PersonID)
--
CREATE TABLE Telefonnummer (
    [Id]       INT IDENTITY NOT NULL,
    Forhold           CHAR(200) NOT NULL,
    Nummer         INT NOT NULL,
    PersonID       INT NULL,
CONSTRAINT pk_Telefonnummer PRIMARY KEY CLUSTERED ([Id]),
CONSTRAINT fk_Telefonnummer FOREIGN KEY (PersonID)
    REFERENCES Person ([Id])
)