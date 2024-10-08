use MediaService
go

create or alter function fnWidPrtyIpRole(@prty int)
returns varchar(2)
as
begin
declare @ipRole varchar(2)
select @ipRole =
	case
		when @prty =  1 then 'CA'
		when @prty =  2 then 'C' 
		when @prty =  3 then 'A' 
		when @prty =  4 then 'E' 
		when @prty =  5 then 'AD'
		when @prty =  6 then 'AM'
		when @prty =  7 then 'AR'
		when @prty =  8 then 'PA'
		when @prty =  9	then 'SA'
		when @prty = 10 then 'SE'
		when @prty = 11 then 'TR'
		else 'TR'
	end
	return @ipRole
end
go

-- select dbo.fnWidIpRolePrty(dbo.fnWidPrtyIpRole(10))