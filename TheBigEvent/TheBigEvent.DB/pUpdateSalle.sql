create proc tbe.pUpdateSalle
(
	@SalleId INT, 
	@Nbplace NVARCHAR(MAX),
	@Descriptions NVARCHAR(MAX),
	@Prix Float,
	@Nom NVARCHAR(MAX)
)
as
begin
	update tbe.Salle
	set Nbplace = @Nbplace,
	Descriptions = @Descriptions,
	Prix = @Prix,
	Nom = @Nom
	where SalleId = @SalleId;
	return 0;
end

