use SocWidSubmitEx
go

create or alter function fnPrevSubmId()
returns int
as
begin
	declare @prevSubmMaxDateTime datetime = (select EndedAt from Submission where EndedAt <> dbo.fnMaxDate())
	return (select Id from Submission where EndedAt = @prevSubmMaxDateTime)
end
go

