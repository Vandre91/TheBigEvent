CREATE PROCEDURE tbe.pAddDeco
(
	@UserId INT
)
AS
BEGIN 
	insert into tbe.tDeco(UserId) 
	VALUES(@UserId);
	RETURN 0;
end;