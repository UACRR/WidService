use MediaService
go

create or alter function fnWidIpRolePrty(@ipRole varchar(3))
returns int
as
begin
declare @prty int
select @prty =
	case
		when @ipRole = 'CA' then 1
		when @ipRole = 'C'  then 2
		when @ipRole = 'A'  then 3
		when @ipRole = 'E'  then 4
		when @ipRole = 'AD' then 5
		when @ipRole = 'AM' then 6
		when @ipRole = 'AR' then 7
		when @ipRole = 'PA' then 8
		when @ipRole = 'SA' then 9
		when @ipRole = 'SE' then 10
		when @ipRole = 'TR' then 11
		else 11
	end
	return @prty
end
go

-- select fnWidIpRolePrty(4)