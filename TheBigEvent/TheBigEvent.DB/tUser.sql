CREATE TABLE [tbe].[tUser]
(
	[UserId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [Passe] varbinary(128) not null,
    [FirstName] NVARCHAR(MAX) NULL, 
    [LastName] NVARCHAR(MAX) NULL, 
    [City] NVARCHAR(MAX) NULL, 
    [Tel] INT NULL, 
    [Mail] NVARCHAR(MAX) NOT NULL, 
    [Pro] BIT NULL, 
    [Siret] NVARCHAR(MAX) NULL, 
    [Compagny] NVARCHAR(MAX) NULL
)
