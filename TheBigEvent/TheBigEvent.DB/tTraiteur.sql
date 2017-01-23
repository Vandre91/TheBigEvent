CREATE TABLE [tbe].[tTraiteur]
(
	[TraiteurId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [UserId] INT NULL, 
    [Descriptions] NVARCHAR(MAX) NULL, 
    [Nom] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_tTraiteur_tUser] FOREIGN KEY ([UserId]) REFERENCES [tbe].[tUser]([UserId])
)
