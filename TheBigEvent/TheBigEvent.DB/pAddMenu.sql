CREATE PROCEDURE tbe.pAddMenu
(
	@Nom NVARCHAR(MAX),
	@Prix NVARCHAR(MAX),
	@Entrer NVARCHAR(MAX),
	@Plat NVARCHAR(MAX),
	@Dessert NVARCHAR(MAX),
	@NbPersonnes NVARCHAR(MAX),
	@TraiteurId INT
	
)
AS
BEGIN 
	insert into tbe.tMenu(Nom,Prix,Entrer,Plat,Dessert,NbPersonnes,TraiteurId) 
	VALUES(@Nom,@Prix,@Entrer,@Plat,@Dessert,@NbPersonnes,@TraiteurId);
	RETURN 0;
end;