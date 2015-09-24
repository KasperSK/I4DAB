/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF OBJECT_ID('Person', 'U') IS NOT NULL
DELETE FROM Person WHERE PersonID = PersonID;

IF OBJECT_ID('FolkeRegisterAddresse', 'U') IS NOT NULL
DELETE FROM Person WHERE FolkeAID = FolkeAID;