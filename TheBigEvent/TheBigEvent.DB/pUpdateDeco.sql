create proc tbe.pUpdateDeco
(
	@DecoId INT, 
	@UserId INT
)
as
begin
	update tbe.tDeco
	set UserId = @UserId
	where DecoId = @DecoId;
end;