CREATE PROCEDURE tbe.pInsertEvent
(
	@NomEvent NVARCHAR(MAX),
	@MenuId INT,
	@SalleId INT,
	@TraiteurId INT,
	@DecoId INT,
	@Localisation NVARCHAR(MAX),
	@UserId INT
)
AS
BEGIN 
	insert into tbe.tEvent(NomEvent,MenuId,SalleId,TraiteurId,DecoId,Localisation,UserId) 
	VALUES(@NomEvent,
		@MenuId,
		@SalleId,
		@TraiteurId,
		@DecoId,
		@Localisation,
		@UserId);
	RETURN 0;
end;