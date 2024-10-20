use SocIpiTesting
go

create or alter function fncGetDateTimeFromStrings
(
	@strDate as char(8), @strTime as char(6)
)
returns datetime
as
begin
	if trim(@strDate) = ''
		return datefromparts(1900, 1, 1)
	if substring(@strDate, 1, 4) < '1900'
		return datefromparts(1900, 1, 1)
	return datetimefromparts(
		  (cast(substring(@strDate, 1, 4) as int))	
		, (cast(substring(@strDate, 5, 2) as int))	
		, (cast(substring(@strDate, 7, 2) as int))
		, (cast(substring(@strTime, 1, 2) as int))
		, (cast(substring(@strTime, 3, 2) as int))
		, (cast(substring(@strTime, 5, 2) as int))
		, 0
      )		
end
go

