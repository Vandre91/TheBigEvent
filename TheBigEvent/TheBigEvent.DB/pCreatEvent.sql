CREATE PROCEDURE tbe.pCreatEvent
(
	@NomEvent NVARCHAR(MAX),
	@MenuId INT,
	@SalleId INT,
	@TraiteurId INT,
	@DecoId INT,
	@Localisation NVARCHAR(MAX),
	@UserId INT,
	@NbInvite INT,
	@Prix INT,
	@Dates Datetime2
)
AS
BEGIN 
	insert into tbe.tEvent(NomEvent,MenuId,SalleId,TraiteurId,DecoId,Localisation,UserId,NbInvite,Prix,Dates) 
	VALUES(@NomEvent,
		@MenuId,
		@SalleId,
		@TraiteurId,
		@DecoId,
		@Localisation,
		@UserId,
		@NbInvite,
		@Prix,
		@Dates);
	RETURN 0;
end;