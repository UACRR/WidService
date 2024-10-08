use Ddex
go

declare @ddexReportId int = 36

declare @ddexReportingPeriodId int = (
	select ddexReportingPeriodId from DdexReport where Id = @ddexReportId
)

declare 
	  @quarter int
	, @year int
select 
	  @quarter  = quarter
	, @year		= year
from DdexReportingPeriod
where Id = @DdexReportingPeriodId

declare	
	  @custId int
	, @licId int
select
	  @custId = custId
	, @licId = licId
from DdexReport
where Id = @ddexReportId

declare
	  @dateBegin date
	, @dateEnd date 
	, @periodName varchar(50)

select 
	  @dateBegin  = dateBegin
	, @dateEnd	  = dateEnd
	, @periodName = periodName
from dbo.ft_DateQuarter(@quarter, @year)

declare @MsPeriodId int
select @MsPeriodId = max(periodId)
from MediaService..PaidPeriod t1 
where 
		licId		 = @licId 
	and t1.custId	 = @custId 
	and t1.beginDate = @dateBegin 
	and t1.endDate	 = @dateEnd

select @MsPeriodId

declare @regId int
select @regId = t2.regId
from MediaService..Register t2
	join MediaService..RegisterRatedList t3 on t2.rmId = t3.rmId
	join MediaService..PaidPeriod t4 on t3.periodId = t4.periodId
where t4.periodId = @MsPeriodId

select @regId

--select * from MediaService..RegisterItem where regId = @regId
--select * from MediaService..RegisterCCIDMW where regId = @regId
--select sum(amountMechCur + amountPerfCur) from MediaService..RegisterCCIDMW where regId = @regId
--select * from MediaService..RegisterCCIDAuthor where regId = @regId
--select * from MediaService..RegisterCCID where regId = @regId



delete t1
from MediaService..RegisterCCIDAuthor t1
	join MediaService..Register t2 on t1.regId = t2.regId
	join MediaService..RegisterRatedList t3 on t2.rmId = t3.rmId
	join MediaService..PaidPeriod t4 on t3.periodId = t4.periodId
where t4.periodId = @MsPeriodId

delete t1
from MediaService..RegisterCCIDMW t1
	join MediaService..Register t2 on t1.regId = t2.regId
	join MediaService..RegisterRatedList t3 on t2.rmId = t3.rmId
	join MediaService..PaidPeriod t4 on t3.periodId = t4.periodId
where t4.periodId = @MsPeriodId

delete t1
from MediaService..RegisterItem t1
	join MediaService..Register t2 on t1.regId = t2.regId
	join MediaService..RegisterRatedList t3 on t2.rmId = t3.rmId
	join MediaService..PaidPeriod t4 on t3.periodId = t4.periodId
where t4.periodId = @MsPeriodId

delete t1
from MediaService..RegisterCCID t1
	join MediaService..Register t2 on t1.regId = t2.regId
	join MediaService..RegisterRatedList t3 on t2.rmId = t3.rmId
	join MediaService..PaidPeriod t4 on t3.periodId = t4.periodId
where t4.periodId = @MsPeriodId

delete t11
from MediaService..DistributionItem t11
	join MediaService..Distribution t12 on t11.distId = t12.distId
	join MediaService..Register t2 on t2.regId = t12.regId
	join MediaService..RegisterRatedList t3 on t2.rmId = t3.rmId
	join MediaService..PaidPeriod t4 on t3.periodId = t4.periodId
where t4.periodId = @MsPeriodId

delete t12
from MediaService..Distribution t12
	join MediaService..Register t2 on t2.regId = t12.regId
	join MediaService..RegisterRatedList t3 on t2.rmId = t3.rmId
	join MediaService..PaidPeriod t4 on t3.periodId = t4.periodId
where t4.periodId = @MsPeriodId

delete t2
from MediaService..Register t2
	join MediaService..RegisterRatedList t3 on t2.rmId = t3.rmId
	join MediaService..PaidPeriod t4 on t3.periodId = t4.periodId
where t4.periodId = @MsPeriodId

delete t3
from MediaService..RegisterRatedList t3
	join MediaService..PaidPeriod t4 on t3.periodId = t4.periodId
where t4.periodId = @MsPeriodId

delete
from MediaService..MoneyPeriodLink
where periodId = @MsPeriodId

delete
from MediaService..PaidPeriod
where periodId = @MsPeriodId

