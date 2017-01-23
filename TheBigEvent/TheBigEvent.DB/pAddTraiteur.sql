CREATE PROCEDURE tbe.pAddTraiteur
(
	@UserId INT,
	@Nom NVARCHAR(MAX),
	@Descriptions NVARCHAR(MAX)
)
AS
BEGIN 
	insert into tbe.tTraiteur(UserId,Nom,Descriptions) 
	VALUES(@UserId,@Nom,@Descriptions);
	RETURN 0;
end;