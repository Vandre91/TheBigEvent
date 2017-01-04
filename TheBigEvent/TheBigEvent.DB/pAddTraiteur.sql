CREATE PROCEDURE tbe.pAddTraiteur
(
	@UserId INT
)
AS
BEGIN 
	insert into tbe.tTraiteur(UserId) 
	VALUES(@UserId);
	RETURN 0;
end;