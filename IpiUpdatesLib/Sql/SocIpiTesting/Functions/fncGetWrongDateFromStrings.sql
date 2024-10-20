use SocIpiTesting
go

create or alter function fncGetWrongDateFromStrings
(
	  @strYear  as char(4)
	, @strMonth as char(2)
	, @strDay   as char(2)
)
returns varchar(12)
as
begin
	declare @intYear  int = case when trim(@strYear)  = '' then 1900 else cast(@strYear   as int) end
	declare @intMonth int = case when trim(@strMonth) = '' then 1    else cast(@strMonth  as int) end
	declare @intDay   int = case when trim(@strDay)   = '' then 1    else cast(@strDay    as int) end
	declare @strDate varchar(12) = concat(@intYear, '-', @intMonth, '-', @intDay)
	if isdate(@strDate) = 0
	begin
		return @strDate
	end
	return 'correct'	
end
go

