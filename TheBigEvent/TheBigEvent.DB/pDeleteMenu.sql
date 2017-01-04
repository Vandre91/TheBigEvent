create proc tbe.pDeleteMenu
(
	@MenuId   int
)
as
begin
	delete from tbe.tMenu where MenuId = @MenuId;
	return 0;
end;