CREATE TABLE [tbe].[Salle]
(
	[SalleId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [Nbplace] NVARCHAR(MAX) NULL, 
    [UserId] INT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Salle_tUser] FOREIGN KEY ([UserId]) REFERENCES tbe.tUser([UserId])
)
