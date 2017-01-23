create proc tbe.pDeleteMenubyId
(
	@TraiteurId   int
)
as
begin
	delete from tbe.tMenu where TraiteurId = @TraiteurId;
	return 0;
end;