--
-- Create Table    : 'Person'   
-- PersonID        :  
-- Fornavn         :  
-- Mellemnavn      :  
-- Efternavn       :  
-- Forhold         :  
--
CREATE TABLE Person (
    [Id]       INT IDENTITY NOT NULL,
    Fornavn        CHAR(200) NOT NULL,
    Mellemnavn     CHAR(200) NULL,
    Efternavn      CHAR(200) NOT NULL,
    Forhold        CHAR(200) NOT NULL,
	FolkeAID	   INT NULL,
CONSTRAINT pk_Person PRIMARY KEY CLUSTERED ([Id]),
CONSTRAINT fk_FolkeRegisterA FOREIGN KEY (FolkeAID)
    REFERENCES Addresse ([Id])
)