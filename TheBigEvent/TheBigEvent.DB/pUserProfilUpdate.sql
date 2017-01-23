create proc tbe.pUserProfilUpdate
(
	@UserId INT,  
    @Mail NVARCHAR(MAX),  
    @Passe varbinary(128)
)
as
begin
	update tbe.tUser
	set Mail = @Mail,
	    Passe = @Passe
	where UserId = @UserId;
	return 0;
end;