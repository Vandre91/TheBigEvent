CREATE TABLE [tbe].[tProposition]
(
	[PropositionId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [Date] DATETIME2 NULL, 
    [BigSelecteId] INT NULL,
	CONSTRAINT [FK_tProposition_tBigSelect] FOREIGN KEY ([BigSelecteId]) REFERENCES [tbe].[tBigSelecte]([BigSelecteId])
)
