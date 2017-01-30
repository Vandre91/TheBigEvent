CREATE TABLE [tbe].[tBigSelecte]
(
	[BigSelecteId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [UserId] INT NULL, 
    [Nom] NVARCHAR(50) NULL, 
    [Ville] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(MAX) NULL,
)
