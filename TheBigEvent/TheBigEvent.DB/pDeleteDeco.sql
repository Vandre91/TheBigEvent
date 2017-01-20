create proc tbe.pDeleteDeco
(
	@DecoId   int
)
as
begin
	delete from tbe.tDeco where DecoId = @DecoId;
	return 0;
end;