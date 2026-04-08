use SocWidSubmitEx
go

create or alter function fnSubmHasReadyWorks()
returns bit
as
begin
	declare @retVal bit
	if exists (select null from vCurSubmWorks where Status = 1)
		set @retVal = 1
	else
		set @retVal = 0

	return @retVal
end
go

