declare @ddexReportId int = 8;
-- get revshare rates
declare @year int
	, @quarter int;
declare @musicRate float
	, @geRate float
	, @mechSplit float
	, @perfSplit float
	, @MusicPSM float
	, @GePSM float
select @year = [year], @quarter = [quarter] 
from DdexReportingPeriod 
where id = (select ddexReportingPeriodId from DdexReport where Id = @ddexReportId);

select top 1 @musicRate = musicRatesubscr * 0.01
	, @geRate = geRateSubscr * 0.01
	, @mechSplit = mechSplit * 0.01
	, @perfSplit = perfSplit * 0.01
	, @MusicPSM = MusicPSM * 0.01
	, @GePSM = GePSM * 0.01
from RevShare 
where [year] < @year or ([year] = @year and [quarter] <= @quarter ) order by [year], [quarter];

/*
select @musicRate 
	, @geRate 
	, @mechSplit 
	, @perfSplit 
	, @MusicPSM 
	, @GePSM 
*/

declare @perfMS float = 1;
declare @mechMS float = 1;

declare @MarketShareCombined float = @perfSplit * @perfMS + @mechSplit * @mechMS;
declare @MusicShareCombined float = @MusicRate * @MarketShareCombined;
declare @GeShareCombined float = @geRate * @MarketShareCombined;

declare @TotalRevenue float;
select @TotalRevenue = sum(netrevenue) 
from DdexRecordSY_04_01 
where ddexReportId = @ddexReportId 
	and SubscriberType = 'all'
--select @totalRevenue totalRevenue

declare @MusicPlusGEMusicViews int;
select @MusicPlusGEMusicViews = sum(TotalUsages) 
from DdexRecordSY_05_02 
where ddexReportId = @ddexReportId 
	and ContentCategory in ('Music', 'GEMusic')
--select @MusicPlusGEMusicViews MusicPlusGEMusicViews

declare @ConstantGrossRevenueValue float = @TotalRevenue / @MusicPlusGEMusicViews;
--select @ConstantGrossRevenueValue ConstantGrossRevenueValue

--select @MusicShareCombined MusicShareCombined, @geShareCombined geShareCombined

declare @TotalRevSharePayable float;
select @TotalRevSharePayable = sum((MusicUsagePercentage * @MusicShareCombined + (100 - MusicUsagePercentage) * @geShareCombined) * NetRevenue * 0.01)
from DdexRecordSY_04_01 
where ddexReportId = @ddexReportId 
	and SubscriberType = 'all' 
select @TotalRevSharePayable totalRevSharePayable

declare @TotalPSMPayable float;
select @TotalPSMPayable = sum((MusicUsagePercentage * Subscribers *@MusicPSM + (100 - MusicUsagePercentage) * Subscribers * @gePsm) / 25)
from DdexRecordSY_04_01 
where ddexReportId = @ddexReportId 
	and SubscriberType = 'all' 
select @TotalPSMPayable TotalPSMPayable


