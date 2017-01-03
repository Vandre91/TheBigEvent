CREATE TABLE [tbe].[tDeco]
(
	[DecoId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [UserId] INT NULL, 
    CONSTRAINT [FK_tDeco_tUser] FOREIGN KEY ([UserId]) REFERENCES [tbe].[tUser]([UserId])
)
