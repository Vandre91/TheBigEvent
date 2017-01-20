CREATE PROCEDURE tbe.pAddMenu
(
	@Nom NVARCHAR(MAX),
	@Cat NVARCHAR(MAX),
	@Prix NVARCHAR(MAX),
	@NbPersonnes NVARCHAR(MAX),
	@TraiteurId INT
	
)
AS
BEGIN 
	insert into tbe.tMenu(Nom,Cat,Prix,NbPersonnes,TraiteurId) 
	VALUES(@Nom,@Cat,@Prix,@NbPersonnes,@TraiteurId);
	RETURN 0;
end;