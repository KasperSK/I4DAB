--
-- Create Table    : 'PersonAdresse'   
-- PersonID        :  (references Person.PersonID)
-- AdresseID       :  (references Adresse.AdresseID)
--
CREATE TABLE PersonAdresse (
    PersonID       INT NOT NULL,
    AdresseID      INT NOT NULL,
CONSTRAINT pk_PersonAdresse PRIMARY KEY CLUSTERED (PersonID,AdresseID),
CONSTRAINT fk_PersonAdresse FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_PersonAdresse2 FOREIGN KEY (AdresseID)
    REFERENCES Adresse (AdresseID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)