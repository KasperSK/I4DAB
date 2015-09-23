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
	FolkeAId	   INT NOT NULL,
CONSTRAINT pk_Person PRIMARY KEY CLUSTERED (PersonID),
CONSTRAINT fk_FolkeRegisterA
	FOREIGN KEY (FolkeAId)
    REFERENCES FolkeRegisterAddresse (FolkeAId)
)