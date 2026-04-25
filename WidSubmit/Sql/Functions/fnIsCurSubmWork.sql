use SocWidSubmitEx
go

create or alter function fnIsCurSubmWork (
	@submWorkId int
)
returns bit
as
begin
	declare @submId int = (select SubmissionId from SubmWork where Id = @submWorkId)
	return case when @submId = dbo.fnCurSubmId() then cast(1 as bit) else cast(0 as bit) end
end
go
