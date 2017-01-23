CREATE PROCEDURE tbe.pAddSalle
(
	@Nbplace NVARCHAR(MAX),
	@UserId INT,
	@Descriptions NVARCHAR(MAX),
	@Prix FLOAT,
	@NOM NVARCHAR(MAX)
)
AS
BEGIN 
	insert into tbe.Salle(Nbplace,UserId,Descriptions,Prix,Nom) 
	VALUES(@Nbplace,@UserId,@Descriptions,@Prix,@Nom);
	RETURN 0;
end;