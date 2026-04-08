use SocWidSubmitEx
go

create or alter function fnPrevDate()
returns date
as
begin
	return (select dateadd(day, -1, getdate()))
end
go

