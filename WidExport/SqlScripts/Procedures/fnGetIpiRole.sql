use SocWidSubmit
go

create or alter function fnGetIpiRole
(
	  @rhType int
	, @rhRole int
)
returns varchar(10)
as
begin
	return case 
			when @rhType = 1 then
				case
					when @rhRole = 1 then 'LY'
					when @rhRole = 2 then 'MC'
					when @rhRole = 5 then 'LY'
					when @rhRole = 6 then 'LY'
					when @rhRole = 7 then 'MC'
					when @rhRole = 10 then 'LY,MC'
					else ''
				end
			when @rhType= 3 and (@rhRole = 8 or @rhRole = 9) then 'EM'
			else ''
		  end		
end
go


