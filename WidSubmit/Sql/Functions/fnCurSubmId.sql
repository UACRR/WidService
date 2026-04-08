use SocWidSubmitEx
go

create or alter function fnCurSubmId()
returns int
as
begin
	return (select Id from Submission where EndedAt = dbo.fnMaxDate())
end
go

