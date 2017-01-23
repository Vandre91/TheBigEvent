CREATE PROCEDURE tbe.pUserAdd
(
	@Passe varbinary(128),
	@Mail NVARCHAR(MAX), 
	@Pro bit, 
	@Siret NVARCHAR(MAX), 
	@Compagny NVARCHAR(MAX)
)
AS
BEGIN 
	insert into tbe.tUser(Passe, Mail, Pro, Siret, Compagny) 
	VALUES(@Passe, @Mail, @Pro, @Siret, @Compagny);
	RETURN 0;
end;