CREATE PROCEDURE tbe.pAddMessage
(
	@UserId1 INT,
	@UserId2 INT,
	@Text NVARCHAR(MAX)
)
AS
BEGIN 
	insert into tbe.tMessage(UserId1,UserId2,Text) 
	VALUES(@UserId1,@UserId2,@Text);
	RETURN 0;
end;