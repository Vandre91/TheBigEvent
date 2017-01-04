create proc tbe.pDeleteEvent
(
	@EventId   int
)
as
begin
	delete from tbe.tEvent where EventId = @EventId;
	return 0;
end;