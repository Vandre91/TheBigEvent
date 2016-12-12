CREATE PROCEDURE tbe.pUserAdd
(
	@Passe NVARCHAR(MAX),
	@FirstName NVARCHAR(MAX),
	@LastName NVARCHAR(MAX), 
	@City NVARCHAR(MAX), 
	@Tel int, 
	@Mail NVARCHAR(MAX), 
	@Pro bit, 
	@Siret int, 
	@Compagny NVARCHAR(MAX)
)
AS
BEGIN 
	insert into tbe.tUser(Passe, FirstName, LastName, City, Tel, Mail, Pro, Siret, Compagny) 
	VALUES(@Passe, @FirstName, @LastName, @City, @Tel, @Mail, @Pro, @Siret, @Compagny);
	RETURN 0;
end;