﻿CREATE TABLE [tbe].[tUser]
(
	[UserId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [Passe] NVARCHAR(MAX) NOT NULL, 
    [FirstName] NVARCHAR(MAX) NULL, 
    [LastName] NVARCHAR(MAX) NULL, 
    [City] NVARCHAR(MAX) NULL, 
    [Tel] INT NULL, 
    [Mail] NVARCHAR(MAX) NOT NULL, 
<<<<<<< HEAD
    [Pro] BIT NOT NULL, 
    [Siret] INT NULL, 
=======
    [Pro] BIT NULL, 
    [Siret] NVARCHAR(MAX) NULL, 
>>>>>>> master
    [Compagny] NVARCHAR(MAX) NULL
)
