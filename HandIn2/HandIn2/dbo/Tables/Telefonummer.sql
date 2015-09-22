--
-- Create Table    : 'Telefonummer'   
-- Nummer          :  
-- Type            :  
-- NummerID        :  
--
CREATE TABLE Telefonummer (
    Nummer         INT NOT NULL,
    Type           CHAR(200) NOT NULL,
    NummerID       INT NOT NULL,
CONSTRAINT pk_Telefonummer PRIMARY KEY CLUSTERED (NummerID))