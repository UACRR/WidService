use SocIpiTesting
go

create or alter function fncGetDateFromString
(
	@strVal as char(8)
)
returns date
as
begin
	if trim(@strVal) = ''
		return datefromparts(1900, 1, 1)
	return datefromparts(
		  (cast(substring(@strVal, 1, 4) as int))		
		, (cast(substring(@strVal, 5, 2) as int))		
		, (cast(substring(@strVal, 7, 2) as int))		
      )	
end
go

