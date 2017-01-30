CREATE TABLE [tbe].[tValide]
(
	[Id] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [PropositionId] INT NULL, 
    [InviteId] INT NULL,
	CONSTRAINT [FK_tValide_tProposition] FOREIGN KEY ([PropositionId]) REFERENCES [tbe].[tProposition]([PropositionId]),
	CONSTRAINT [FK_tValide_tInviteId] FOREIGN KEY ([InviteId]) REFERENCES [tbe].[tInvite]([InviteId])

)
