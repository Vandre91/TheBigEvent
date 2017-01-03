CREATE TABLE [tbe].[tMenu]
(
	[MenuId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [Nom] NVARCHAR(MAX) NULL, 
    [Cat] NVARCHAR(MAX) NULL, 
    [Prix] NVARCHAR(MAX) NULL, 
    [NbPersonnes] NVARCHAR(MAX) NULL, 
    [TraiteurId] INT NULL, 
    CONSTRAINT [FK_tMenu_tTraiteur] FOREIGN KEY ([TraiteurId]) REFERENCES [tbe].[tTraiteur]([TraiteurId])
)
