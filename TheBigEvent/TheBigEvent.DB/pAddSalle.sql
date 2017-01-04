CREATE PROCEDURE tbe.pAddSalle
(
	@Nbplace NVARCHAR(MAX),
	@UserId INT
	
)
AS
BEGIN 
	insert into tbe.Salle(Nbplace,UserId) 
	VALUES(@Nbplace,@UserId);
	RETURN 0;
end;