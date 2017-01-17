create proc tbe.pUpdateSalle
(
	@SalleId INT, 
	@Nbplace NVARCHAR(MAX),
	@Descriptions NVARCHAR(MAX)
)
as
begin
	update tbe.Salle
	set Nbplace = @Nbplace,
	Descriptions = @Descriptions
	where SalleId = @SalleId;
	return 0;
end

