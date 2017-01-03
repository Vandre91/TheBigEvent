create proc tbe.pUserDelete
(
	@UserId   int
)
as
begin
	delete from tbe.tUser where UserId = @UserId;
	return 0;
end;