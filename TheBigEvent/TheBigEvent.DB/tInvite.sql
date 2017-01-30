CREATE TABLE [tbe].[tInvite]
(
	[InviteId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [Nom] NVARCHAR(MAX) NULL, 
    [Mail] NVARCHAR(MAX) NULL, 
    [BigSelecteId] INT NULL,
	CONSTRAINT [FK_tInvite_tBigSelect] FOREIGN KEY ([BigSelecteId]) REFERENCES [tbe].[tBigSelecte]([BigSelecteId])
)
