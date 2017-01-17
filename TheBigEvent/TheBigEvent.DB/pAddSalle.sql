CREATE PROCEDURE tbe.pAddSalle
(
	@Nbplace NVARCHAR(MAX),
	@UserId INT,
	@Descriptions NVARCHAR(MAX)
)
AS
BEGIN 
	insert into tbe.Salle(Nbplace,UserId,Descriptions) 
	VALUES(@Nbplace,@UserId,@Descriptions);
	RETURN 0;
end;