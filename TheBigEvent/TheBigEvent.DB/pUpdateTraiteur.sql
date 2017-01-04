create proc tbe.pUpdateTraiteur
(
	@TraiteurId INT, 
	@UserId INT
)
as
begin
	update tbe.tTraiteur
	set UserId = @UserId
	where TraiteurId = @TraiteurId;
	return 0;
end;