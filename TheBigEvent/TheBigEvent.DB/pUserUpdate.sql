create proc tbe.pUserUpdate
(
	@UserId INT,  
    @FirstName NVARCHAR(MAX),  
    @LastName NVARCHAR(MAX),  
    @City NVARCHAR(MAX),
    @Tel INT  
	
)
as
begin
	update tbe.tUser
	set FirstName = @FirstName,
	    LastName = @LastName,
		City = @City,
		Tel = @Tel
	where UserId = @UserId;
	return 0;
end;