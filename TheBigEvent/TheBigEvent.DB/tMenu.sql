CREATE TABLE [tbe].[tMenu]
(
	[MenuId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [Nom] NVARCHAR(MAX) NULL, 
    [Entrer] NVARCHAR(MAX) NULL,
	[Plat] NVARCHAR(MAX) NULL,
	[Dessert] NVARCHAR(MAX) NULL, 
    [Prix] NVARCHAR(MAX) NULL, 
    [NbPersonnes] NVARCHAR(MAX) NULL, 
    [TraiteurId] INT NULL, 
    CONSTRAINT [FK_tMenu_tTraiteur] FOREIGN KEY ([TraiteurId]) REFERENCES [tbe].[tTraiteur]([TraiteurId])
)
