CREATE PROCEDURE tbe.pCreatEvent
(
	@NomEvent NVARCHAR(MAX),
	@NbInvite NVARCHAR(MAX), 
	@Prix NVARCHAR(50), 
	@Horaire DATETIME,
	@MenuId INT,
	@SalleId INT,
	@TraiteurId INT,
	@DecoId INT,
	@Localisation NVARCHAR(MAX),
	@UserId INT,
	@Validation NVARCHAR(MAX)
)
AS
BEGIN 
	insert into tbe.tEvent(NomEvent,NbInvite,Prix,Horaire,MenuId,SalleId,TraiteurId,DecoId,Localisation,UserId,"Validation") 
	VALUES(@NomEvent, 
		@NbInvite, 
		@Prix,
		@Horaire,
		@MenuId,
		@SalleId,
		@TraiteurId,
		@DecoId,
		@Localisation,
		@UserId,
		@Validation);
	RETURN 0;
end;