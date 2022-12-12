USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spCreateCcidParamsForSubscr]    Script Date: 12.09.2022 13:04:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spCreateCcidParamsForSubscr]
	  @ddexReportId int
	
	, @musicRate float output
	, @geRate float output
	, @mechSplit float output
	, @perfSplit float output
	, @totalRevSharePayable float output
	, @totalPSMPayable float output
	, @constantGrossRevenueValue float output
	, @constantPSMRoyaltyValue float output
	, @blendedRevshareRate float output
as
begin
/*
Процедура вычисляет параметры необходимые для расчета позиций по инвойсу для подписки.
Расчеты основаны на документе SWOD от Гугл. 
*/

-- agreement parameters
declare @licId int
	  , @custId int;
select @licId = licId
	 , @custId = custId
from DdexReport 
where id = @ddexReportId;

declare @exchRate float = (select cast(exchRate as float) from DdexReport where id = @ddexReportId);


set @musicRate = (select cast(musicRate as float) * 0.01 from DdexReport where id = @ddexReportId);
set @geRate = (select cast(geRate as float) * 0.01 from DdexReport where id = @ddexReportId);
set @mechSplit = (select cast(mechSplit as float) * 0.01 from DdexReport where id = @ddexReportId);
set @perfSplit = (select cast(perfSplit as float) * 0.01 from DdexReport where id = @ddexReportId);
declare @musicPSM float = (select cast(musicPSM as float) from DdexReport where id = @ddexReportId);
declare @gePSM float = (select cast(gePSM as float) * @exchRate from DdexReport where id = @ddexReportId);

-- ============ Calc base data
declare @perfMS float = 1;
declare @mechMS float = 1;

declare @marketShareCombined float = @perfSplit * @perfMS + @mechSplit * @mechMS;
declare @musicShareCombined float = @musicRate * @marketShareCombined;
declare @geShareCombined float = @geRate * @marketShareCombined;

declare @totalRevenue float = (
	select sum(netrevenue) 
	from DdexRecordSY_04_01 
	where ddexReportId = @ddexReportId 
		and SubscriberType = 'all');
declare @musicPlusGEMusicViews int = (
	select sum(TotalUsages) 
	from DdexRecordSY_05_02 
	where ddexReportId = @ddexReportId 
		and ContentCategory in ('Music', 'GEMusic'));
declare @musicViews int = (
	select sum(TotalUsages) 
	from DdexRecordSY_05_02 
	where ddexReportId = @ddexReportId 
		and ContentCategory = 'Music');
declare @musicRatio float = (
	select @musicViews / sum(TotalUsages) 
	from DdexRecordSY_05_02 
	where ddexReportId = @ddexReportId);
declare @geRatio float = 1 - @musicRatio;
declare @subscriberCount int = (
	select sum(Subscribers) from DdexRecordSY_04_01 where ddexReportId = @ddexReportId and SubscriberType = 'all');
declare @musicPSMPool float = @subscriberCount * @musicPSM;
declare @gePSMPool float = @subscriberCount * @gePSM;
declare @blendedPSMPool float = @musicRatio * @musicPSMPool + @geRatio * @gePSMPool;
set @constantPSMRoyaltyValue = @blendedPSMPool / @musicPlusGEMusicViews;
set @constantGrossRevenueValue = @totalRevenue / @musicPlusGEMusicViews;
set @totalRevSharePayable = @totalRevenue * (@musicShareCombined * @musicRatio + @geShareCombined * @geRatio)
set @totalPSMPayable = @subscriberCount * (@MusicRatio * @MusicPSM + @geRatio * @gePsm);
set @blendedRevshareRate = @musicRatio * @musicRate + @geRatio * @geRate;

/*
select 
	  @musicRate musicRate
	, @geRate geRate
	, @mechSplit mechSplit
	, @perfSplit perfSplit
	, @totalRevSharePayable TotalRevSharePayable 
	, @totalPSMPayable TotalPSMPayable 
	, @constantGrossRevenueValue ConstantGrossRevenueValue
	, @constantPSMRoyaltyValue constantPSMRoyaltyValue
	, @blendedRevshareRate blendedRevshareRate*/
end
GO

