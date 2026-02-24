use SocWidSubmitEx
go

create or alter function fnCurDate()
returns date
as
begin
	return getdate()
end
go