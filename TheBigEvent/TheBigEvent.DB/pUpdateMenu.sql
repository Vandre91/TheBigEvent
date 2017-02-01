create proc tbe.pUpdateMenu
(
	@MenuId INT, 
	@Nom NVARCHAR(MAX),
	@Cat NVARCHAR(MAX),
	@Prix NVARCHAR(MAX),
	@NbPersonnes NVARCHAR(MAX)
)
as
begin
	update tbe.tMenu
	set Nom = @Nom,
	Prix = @Prix,
	NbPersonnes = @NbPersonnes
	where MenuId = @MenuId;
	return 0;
end;