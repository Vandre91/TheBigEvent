﻿CREATE PROC tbe.pUpdateTraiteur
(
	@TraiteurId INT, 
	@UserId INT,
	@Nom NVARCHAR(MAX),
	@Descriptions NVARCHAR(MAX)
)
as
begin
	update tbe.tTraiteur
	set UserId = @UserId, Nom = @Nom, Descriptions = @Descriptions
	where TraiteurId = @TraiteurId;
	return 0;
end;