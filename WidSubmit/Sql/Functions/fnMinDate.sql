use SocWidSubmitEx
go

create or alter function fnMinDate()
returns date
as
begin
	return (select datefromparts(1900, 1, 1))
end
go

