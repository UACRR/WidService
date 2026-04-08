use SocWidSubmitEx
go

create or alter function fnPrevSubmWorkId(
	@curSubmWorkId int
)
returns int
as
begin
	declare @curSubmId int = (select SubmissionId from SubmWork where Id = @curSubmWorkId)
	declare @prevSubmId int = (select dbo.fnPrevSubmIdEx(@curSubmId))
	return (
		select t2.Id
		from SubmWork t1
			join SubmWork t2 on t1.ObjId = t2.ObjId
				and t2.SubmissionId = @prevSubmId
		where t1.Id = @curSubmWorkId
			
	)
end
go

