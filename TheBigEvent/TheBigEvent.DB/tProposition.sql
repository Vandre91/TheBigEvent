CREATE TABLE [dbo].[tProposition]
(
	[PropositionId] INT NOT NULL PRIMARY KEY, 
    [Date] DATETIME2 NULL, 
    [BigSelecteId] INT NULL,
	CONSTRAINT [FK_tProposition_tBigSelect] FOREIGN KEY ([BigSelecteId]) REFERENCES [tbe].[tBigSelecte]([BigSelecteId])
)
