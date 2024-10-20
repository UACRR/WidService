use SocIpiTesting
go

create or alter function fncGetDateFromStringsLower
(
	  @strYear  as char(4)
	, @strMonth as char(2)
	, @strDay   as char(2)
)
returns date
as
begin
	declare @intYear  int = case when trim(@strYear)  = '' then 1900 else cast(@strYear   as int) end
	declare @intMonth int = case when trim(@strMonth) = '' then 1    else cast(@strMonth  as int) end
	declare @intDay   int = case when trim(@strDay)   = '' then 1    else cast(@strDay    as int) end

	if @intYear < 1900
	begin
		set @intYear  = 1900
		set @intMonth = 1
		set @intDay   = 1
	end

	declare @strDate varchar(12) = concat(@intYear, '-', @intMonth, '-', @intDay)
	if isdate(@strDate) = 0
	begin
		return datefromparts(1900, 1, 1)	
	end
	return datefromparts(@intYear, @intMonth, @intDay)	
end
go

