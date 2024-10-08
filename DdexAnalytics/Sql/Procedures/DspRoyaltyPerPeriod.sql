/*
drop table if exists #NetRevenue
select t3.Year, t3.Quarter, t3.Month, t2.FileType, sum(t1.NetRevenue) as NetRevenue
into #NetRevenue
from IdentBacklog t1
	join DdexReport t2 on t1.DdexReportId = t2.Id
	join DdexReportingPeriod t3 on t2.ddexReportingPeriodId = t3.Id
group by  t3.Year, t3.QUarter, t3.Month, t2.FileType
*/

drop table if exists #NetRevenue
select t3.Year, t3.Quarter, t3.Month, t2.FileType, sum(t2.NetRevenue) as NetRevenue
into #NetRevenue
from DdexReport t2
	join DdexReportingPeriod t3 on t2.ddexReportingPeriodId = t3.Id
group by  t3.Year, t3.QUarter, t3.Month, t2.FileType

drop table if exists #CcidRoyalty
select t5.Year, t5.QUarter, t5.Month, t4.FileType, t2.Status, sum(t1.sum_amount_licensor) as Royalty
into #CcidRoyalty
from CcidInTrailer t1
	join CcidInFile t2 on t1.FileId = t2.FileId
	join CcidInvoice t3 on t2.ccidInvoiceId = t3.Id
	join DdexReport t4 on t3.DdexReportId = t4.Id
	join DdexReportingPeriod t5 on t4.ddexReportingPeriodId = t5.Id
group by t5.Year, t5.Quarter, t5.Month, t4.FileType, t2.Status

drop table if exists #Result
select 
	  Year
	, Quarter
	, Month
	, FileType
	, NetRevenue
	, cast(0 as float) as RoyaltyPlanned
	, cast(0 as float) as RoyaltyReadyToSend
	, cast(0 as float) as RoyaltySent
	, 1   as NoInvoice
into #Result
from #NetRevenue

update t1
set 
	  t1.RoyaltyPlanned		= case when t2.Status = 0 then t2.Royalty else 0.0 end
	, t1.RoyaltyReadyToSend = case when t2.Status = 1 then t2.Royalty else 0.0 end
	, t1.RoyaltySent		= case when t2.Status = 2 then t2.Royalty else 0.0 end
	, t1.NoInvoice			= 0
--select *
from #Result t1
	join #CcidRoyalty t2 on
		t1.Year					= t2.Year		
	and isnull(t1.Quarter, 0)	= isnull(t2.Quarter, 0)
	and isnull(t1.Month, 0)		= isnull(t2.Month, 0)
	and t1.FileType				= t2.FileType

select 
	  Year														as [Рік]
	, isnull(cast(Quarter as varchar(10)), '')					as [Квартал]
	, isnull(cast(Month as varchar(10)), '')					as [Місяць]
	, FileType													as [Звіт]
	, NetRevenue												as [Прибуток у звіті]
	, case when NoInvoice = 1 then 'Немає' else 'Існують' end	as [Наявність інвойсів]
	, RoyaltyPlanned											as [Роялті в роботі]
	, RoyaltyReadyToSend										as [Роялті до передачі]
	, RoyaltySent												as [Роялті передані]
from #Result 
order by FileType, Year, Quarter, Month

		


