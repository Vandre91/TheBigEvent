CREATE TABLE [tbe].[tMessage]
(
	[MessageId] INT NOT NULL PRIMARY KEY identity(0, 1), 
    [UserId1] INT NULL, 
    [UserId2] INT NULL, 
    [Text] NVARCHAR(MAX) NULL
)
