CREATE TABLE [tbe].[tEvent]
(
	[EventId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [NomEvent] NVARCHAR(MAX) NOT NULL, 
    [NbInvite] NVARCHAR(MAX) NULL, 
    [Prix] NVARCHAR(MAX) NULL, 
    [Horaire] DATETIME NULL, 
    [MenuId] INT NULL, 
    [SalleId] INT NULL, 
    [TraiteurId] INT NULL, 
    [DecoId] INT NULL, 
    [Localisation] NVARCHAR(MAX) NULL, 
    [UserId] INT NULL, 
    [Validation] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_tEvent_tMenu] FOREIGN KEY ([MenuId]) REFERENCES [tbe].[tMenu]([MenuId]), 
    CONSTRAINT [FK_tEvent_tSalle] FOREIGN KEY ([SalleId]) REFERENCES [tbe].[Salle]([SalleId]), 
    CONSTRAINT [FK_tEvent_tTraiteur] FOREIGN KEY ([TraiteurId]) REFERENCES [tbe].[tTraiteur]([TraiteurId]), 
    CONSTRAINT [FK_tEvent_tDeco] FOREIGN KEY ([DecoId]) REFERENCES [tbe].[tDeco]([DecoId]), 
    CONSTRAINT [FK_tEvent_tUser] FOREIGN KEY ([UserId]) REFERENCES [tbe].[tUser]([UserId])
)
