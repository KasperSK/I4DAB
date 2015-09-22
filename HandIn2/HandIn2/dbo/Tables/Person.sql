--
-- Create Table    : 'Person'   
-- Fornavn         :  
-- Mellemnavn      :  
-- Efternavn       :  
-- Forhold         :  
-- PersonID        :  
--
CREATE TABLE Person (
    Fornavn        CHAR(200) NOT NULL,
    Mellemnavn     CHAR(200) NULL,
    Efternavn      CHAR(200) NOT NULL,
    Forhold        CHAR(200) NOT NULL,
    PersonID       INT NOT NULL,
CONSTRAINT pk_Person PRIMARY KEY CLUSTERED (PersonID))