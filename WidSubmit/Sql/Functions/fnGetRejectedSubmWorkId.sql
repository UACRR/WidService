use SocWidSubmitEx
go

create or alter function fnGetRejectedSubmWorkId (
	@submWorkId int
)
returns int
as
begin
	declare @submId int = (select SubmissionId from SubmWork where Id = @submWorkId)
	if @submId <> dbo.fnCurSubmId() return null

	declare @retVal int = (
		select t1.SubmWorkId
		from SubmWorkLastPubResult t1
			join SubmWork t2 on t1.ObjId = t2.ObjId
		where t2.Id = @submWorkId
	)

	return @retVal
end
go
