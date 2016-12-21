CREATE PROCEDURE tbe.pUserAdd
(
	@Passe NVARCHAR(MAX),
<<<<<<< HEAD
	@FirstName NVARCHAR(MAX),
	@LastName NVARCHAR(MAX), 
	@City NVARCHAR(MAX), 
	@Tel int, 
	@Mail NVARCHAR(MAX), 
	@Pro bit, 
	@Siret int, 
=======
	@Mail NVARCHAR(MAX), 
	@Pro bit, 
	@Siret NVARCHAR(MAX), 
>>>>>>> master
	@Compagny NVARCHAR(MAX)
)
AS
BEGIN 
<<<<<<< HEAD
	insert into tbe.tUser(Passe, FirstName, LastName, City, Tel, Mail, Pro, Siret, Compagny) 
	VALUES(@Passe, @FirstName, @LastName, @City, @Tel, @Mail, @Pro, @Siret, @Compagny);
=======
	insert into tbe.tUser(Passe, Mail, Pro, Siret, Compagny) 
	VALUES(@Passe, @Mail, @Pro, @Siret, @Compagny);
>>>>>>> master
	RETURN 0;
end;