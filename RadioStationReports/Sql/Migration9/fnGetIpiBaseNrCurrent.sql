use MediaService
go

create or alter function fnGetIpiBaseNrCurrent (
	@ipNameNr int
)
returns varchar(13)
as
begin

declare @result varchar(13)

; with Numbered as
(
	select
		  t1.IpBaseNr
		, t2.SttCde
		, row_number() over (partition by t2.IpBaseNr order by t2.AmdDt desc) as SeqNr
	from SocIpi..IpiName t1
		join SocIpi..IpiStatus t2 on t1.IpBaseNr = t2.IpBaseNr
	where t1.IpNameNr = @ipNameNr
		and getdate() between t2.FromDt and t2.ToDt
)
select @result = min(IpBaseNr)
from Numbered
where SeqNr = 1
	and SttCde = 1

return @result
end
go
