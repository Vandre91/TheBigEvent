create proc tbe.pUpdateDeco
(
	@DecoId INT, 
	@UserId INT,
	@Descriptions NVARCHAR(MAX),
	@Prix Float,
	@Nom NVARCHAR(MAX)
)
as
begin
	update tbe.tDeco
	set UserId = @UserId,
	Descriptions = @Descriptions,
	Prix = @Prix,
	Nom = @Nom
	where DecoId = @DecoId;
end;