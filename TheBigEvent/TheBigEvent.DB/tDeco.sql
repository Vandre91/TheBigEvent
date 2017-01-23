CREATE TABLE [tbe].[tDeco]
(
	[DecoId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [UserId] INT NULL, 
    [Descriptions] NVARCHAR(MAX) NULL, 
    [Prix] FLOAT NULL, 
    [Nom] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_tDeco_tUser] FOREIGN KEY ([UserId]) REFERENCES [tbe].[tUser]([UserId])
)
