use Ddex
go

create or alter view vTikTokReportsPerPeriod
as
select t2.Year, t2.Month, t1.*
from DdexReport t1
	join DdexReportingPeriod t2 on t1.ddexReportingPeriodId = t2.Id
		and t1.FileType = 'tiktok'
go

-- select * from vTikTokReportsPerPeriod where year = 2024 and month = 5