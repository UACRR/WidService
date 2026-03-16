use SocWidSubmitEx
go

create or alter function fnCurErrorFileName()
returns nvarchar(256)
as
begin
	return (select ErrorFileName from Submission where Id = dbo.fnCurSubmId())
end
go

-- select dbo.fnCurSubmFileName()
