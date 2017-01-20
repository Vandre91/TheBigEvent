create proc tbe.pDeleteTraiteur
(
	@TraiteurId   int
)
as
begin
	delete from tbe.tTraiteur where TraiteurId = @TraiteurId;
	return 0;
end;