--
-- Create Table    : 'PersonTelefonnumer'   
-- PersonID        :  (references Person.PersonID)
-- NummerID        :  (references Telefonummer.NummerID)
--
CREATE TABLE PersonTelefonnumer (
    PersonID       INT NOT NULL,
    NummerID       INT NOT NULL,
CONSTRAINT pk_PersonTelefonnumer PRIMARY KEY CLUSTERED (PersonID,NummerID),
CONSTRAINT fk_PersonTelefonnumer FOREIGN KEY (PersonID)
    REFERENCES Person (PersonID)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
CONSTRAINT fk_PersonTelefonnumer2 FOREIGN KEY (NummerID)
    REFERENCES Telefonummer (NummerID)
    ON DELETE NO ACTION
    ON UPDATE CASCADE)