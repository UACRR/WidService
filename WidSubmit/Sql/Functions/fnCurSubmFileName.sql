use SocWidSubmitEx
go

create or alter function fnCurSubmFileName()
returns nvarchar(256)
as
begin
	return (select SubmFileName from Submission where Id = dbo.fnCurSubmId())
end
go


