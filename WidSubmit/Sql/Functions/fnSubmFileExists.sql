use SocWidSubmitEx
go

create or alter function fnSubmFileExists()
returns bit
as
begin
	declare @retVal bit
	if (select SubmFileName from Submission where Id = dbo.fnCurSubmId()) <> ''
		set @retVal = 1
	else
		set @retVal = 0

	return @retVal
end
go

-- select dbo.fnSubmFileExists()
