use SocWidSubmitEx
go

create or alter function fnCurRespFileName()
returns nvarchar(256)
as
begin
	return (select RespFileName from Submission where Id = dbo.fnCurSubmId())
end
go

-- select dbo.fnCurSubmFileName()
