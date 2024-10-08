select
	  t1.RegId
	, t1.RegIItemId
	, t3.CustId
	, t5.shortName
	, t3.fileName
	, t4.beginDate
	, t4.endDate
	, t2.countUse
	, t2.ObjId
	, t2.Wic
--	, t2.ItemName
--	, t2.authorMusic
--	, t2.performer
from MsReportRows t1
	join MediaService..RegisterItem t2 on t1.RegId = t2.regId and t1.RegIItemId = t2.regIItemId
	join MediaService..Register t3 on t2.regId = t3.RegId
	join Mediaservice..PaidPeriod t4 on t3.periodId = t4.periodId
	join MediaService..AnketaCompany t5 on t3.custId = t5.custId
where t1.SourceWorkId = 3
order by t3.custId, t4.beginDate

select
	  t3.CustId
	, t5.shortName
	, t4.year
	, isnull(t4.month, 0) as month
	, isnull(t4.quarter, 0) as quarter
	, lower(t3.FileType)
	, t2.DdexReportId
	, t2.BlockId
	, t2.SalesTransactionId
	, t2.Usages
	, isnull(t6.ObjId, 0)
	, isnull(t6.Wic, 0)
from DdexReportRows t1
	join Ddex..IdentBacklog t2 on t1.DdexReportId = t2.DdexReportId 
		and t1.BlockId = t2.BlockId
		and t1.SalesTransactionId = t2.SalesTransactionId
	join Ddex..DdexReport t3 on t2.DdexReportId = t3.Id
	join Ddex..DdexReportingPeriod t4 on t3.ddexReportingPeriodId = t4.Id
	join MediaService..AnketaCompany t5 on t3.custId = t5.custId
	join Ddex..IdentMw t6 on t2.MwId = t6.Id
where t1.SourceWorkId = 3
order by t3.CustId, t4.year, t4.month, t4.quarter, t3.FileType