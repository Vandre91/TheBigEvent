CREATE PROCEDURE tbe.pAddDeco
(
	@UserId INT,
	@Descriptions NVARCHAR(MAX),
	@Prix FLOAT,
	@Nom NVARCHAR(MAX)
)
AS
BEGIN 
	insert into tbe.tDeco(UserId,Descriptions,Prix,Nom) 
	VALUES(@UserId,@Descriptions,@Prix,@Nom);
	RETURN 0;
end;