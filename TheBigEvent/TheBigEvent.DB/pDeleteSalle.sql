create proc tbe.pDeleteSalle
(
	@SalleId   int
)
as
begin
	delete from tbe.Salle where SalleId = @SalleId;
	return 0;
end;