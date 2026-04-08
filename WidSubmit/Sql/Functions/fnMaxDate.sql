use SocWidSubmitEx
go

create or alter function fnMaxDate()
returns date
as
begin
	return (select datefromparts(9999, 12, 31))
end
go

