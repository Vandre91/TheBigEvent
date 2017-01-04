create proc tbe.pUpdateSalle
(
	@SalleId INT, 
	@Nbplace NVARCHAR(MAX)
)
as
begin
	update tbe.Salle
	set Nbplace = @Nbplace
	where SalleId = @SalleId;
	return 0;
end