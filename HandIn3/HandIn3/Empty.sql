USE [HandIn2]
GO

/****** Object: Table [dbo].[Addresse] Script Date: 10/23/2015 2:16:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DELETE FROM [dbo].[Telefonnummer];
DBCC CHECKIDENT ('Telefonnummer', RESEED, 0)
GO

DELETE FROM [dbo].[EkstraAddresse];
DBCC CHECKIDENT ('EkstraAddresse', RESEED, 0)
GO

DELETE FROM [dbo].[Person];
DBCC CHECKIDENT ('Person', RESEED, 0)
GO

DELETE FROM [dbo].[Addresse];
DBCC CHECKIDENT ('Addresse', RESEED, 0)
GO




