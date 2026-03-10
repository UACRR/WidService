use SocWidSubmitEx
go

create or alter procedure spSubmWorkAltNameSelect
	@submWorkId int
as
begin
	select SubmWorkId, NameForWid, OrigNames
	from SubmWorkAltName
	where SubmWorkId = @submWorkId
end
go
