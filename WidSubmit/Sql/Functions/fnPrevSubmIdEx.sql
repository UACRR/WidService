use SocWidSubmitEx
go

create or alter function fnPrevSubmIdEx(
	@curSubmId int
)
returns int
as
begin
	declare @curSubmEndedAt datetime = (select EndedAt from Submission where Id = @curSubmId)
	declare @prevSubmEndedAt datetime = (select max(EndedAt) from Submission where EndedAt < @curSubmEndedAt)
	if( @prevSubmEndedAt is null) return @curSubmId
	declare @prevSubmId int = (select Id from Submission where EndedAt = @prevSubmEndedAt)
	return (select Id from Submission where Id = @prevSubmId)
end
go

