USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spCreateInitialInvoiceSubscrM]    Script Date: 12.09.2022 13:06:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



-- Batch submitted through debugger: SQLQuery1.sql|9|0|C:\Users\OlegM\AppData\Local\Temp\~vs8438.sql

ALTER procedure [dbo].[spCreateInitialInvoiceSubscrM] @ddexReportId int, @fileId int
as
begin
--declare @ddexReportId int = 8;
declare @inInstanceIndex int;
declare @sum_amount_licensor numeric(30, 6)
declare @invoiceId int;

--declare @ddexReportId int = 1;

-- agreement parameters
declare @licId int, @licVersion int, @custId int, @ddexReportingPeriodId int;
select @licId = licId, @licVersion = licVersion, @custId = custId, @ddexReportingPeriodId = ddexReportingPeriodId
from DdexReport 
where id = @ddexReportId;

declare @year int, @quarter int;
select @year = year, @quarter = quarter from DdexReportingPeriod where id = @ddexReportingPeriodId

declare @month int = 3 * @quarter - 2;

declare @exchRate float = (select exchRate from CcidExchangeRate where year = @year and month = @month and licId = @licId and licVersion = @licVersion and custId = @custId);
if @exchRate is null
begin
	raiserror('Відсутня інформація із договору, необхідна для розрахунків', 0, 0);
	return;
end

declare @musicRate float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 1 and licId = @licId and licVersion = @licVersion and custId = @custId);
declare @geRate float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 2 and licId = @licId and licVersion = @licVersion and custId = @custId);
declare @mechSplit float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 3 and licId = @licId and licVersion = @licVersion and custId = @custId);
declare @perfSplit float = (select cast(paramValue as float) * 0.01 from AgreementParam where paramId = 4 and licId = @licId and licVersion = @licVersion and custId = @custId);
declare @MusicPSM float = (select cast(paramValue as float) * @exchRate from AgreementParam where paramId = 5 and licId = @licId and licVersion = @licVersion and custId = @custId);
declare @GePSM float = (select cast(paramValue as float) * @exchRate from AgreementParam where paramId = 6 and licId = @licId and licVersion = @licVersion and custId = @custId);

--select @exchRate, @musicRate, @geRate, @mechSplit, @perfSplit, @MusicPSM, @GePSM

if @musicRate is null or @geRate is null or @mechSplit is null or @perfSplit is null or @MusicPSM is null or @GePSM is null
begin
	raiserror('Відсутня інформація із догвору, необхідна для розрахунків', 0, 0);
	return;
end

-- get data from Ddex header record for the report
declare @RecipientName varchar(100)
	, @SenderName varchar(100)
	, @UsageStartDate date
	, @UsageEndDate date
select @RecipientName = RecipientName
	, @SenderName = SenderName
	, @UsageStartDate = UsageStartDate
	, @UsageEndDate = UsageEndDate
from DdexRecordHead
where DdexReportId = @ddexReportId

-- Get file type from DdexReport
declare @fileType as varchar(100) = (
			select fileType from DdexReport where Id = @ddexReportId
		)

-- ============ Calc base data
declare @perfMS float = 1;
declare @mechMS float = 1;

declare @MarketShareCombined float = @perfSplit * @perfMS + @mechSplit * @mechMS;
declare @MusicShareCombined float = @MusicRate * @MarketShareCombined;
declare @GeShareCombined float = @geRate * @MarketShareCombined;

if @fileId is null
begin
	insert into CcidInvoice(ddexReportId, createdDate, [status], recordCount, netRevenueExcluded, netRevenueClaimed)
	values (@ddexReportId, getdate(), 0, null, null, null);
	select @invoiceId = SCOPE_IDENTITY();
end
else
begin
	select @invoiceId = ccidInvoiceId from CcidInFile where fileId = @fileId;
end


-- cleanup CCID records for invoice
if @fileId is not null
begin
	delete from CcidInDetail where fileId = @fileId
	delete from CcidInTrailer where fileId = @fileId
	delete from CcidInHeader where fileId = @fileId
end
else
begin
	insert into CcidInFile(ccidInvoiceId, InstanceIndex, Status, [Name], TargetFolder)
	values (@invoiceId, 1, 0, '', '');
	set @fileId = scope_identity();
end

-- Fill in header record
insert into CcidInHeader(
		fileId
		, record_type
		, version
		, date
		, sender
		, receiver
		, ccid_id
		, territory
		, start_date
		, end_date
		, royalty_currency
		, original_revenue_basis_currency
		, conversion_rate
		, work_code_type
		, ccid_id_correction_reference
		, type_of_claim
		, commercial_model
		, service_description
		, use_type
		, mech_perc_split
		, perf_perc_split
		, aux
)
values (
		@fileId
		, 'HD'
		, '14.1'
		, GetDate()
		, 'UACRR-CS'
		, 'Google'
		, cast(@fileId as varchar) -- ccid_id
		, 'UA'
		, @UsageStartDate
		, @UsageEndDate
		, 'USD'
		, 'USD'
		, 1.00000
		, null
		, null
		, 'IN'
		, 'SubscriptionModel' -- commercial_model
		, case when @fileType = 'Usage-Subscription-Music' then 'YouTubeMusic' else 'YouTubePremium' end -- service_description
		, 'Stream' -- use_type
		, @mechSplit * 100 -- mech_perc_split
		, @perfSplit * 100 -- perf_perc_split
		, cast(@musicRate * 100 as varchar) + '|' + cast(@geRate * 100 as varchar) -- aux
)

-- CREATE DETAIL RECORDS
declare @TotalRevenue float
	, @MusicPlusGEMusicViews int
	, @MusicViews int
	, @MusicRatio float
	, @GeRatio float
	, @subscriberCount int
	, @musicPSMPool float
	, @gePSMPool float
	, @blendedPSMPool float
	, @constantPSMRoyaltyValue float
	, @ConstantGrossRevenueValue float
	, @TotalRevSharePayable float
	, @TotalPSMPayable float;

-- Loop over months
declare @startMonth int = datepart(m, @UsageStartDate);
declare @endMonth int = datepart(m, @UsageEndDate);
declare @curMonth int = @startMonth;

-- FOR TESTING
drop table if exists #CcidInDetail

CREATE TABLE #CcidInDetail(
	[fileId] [int] NULL,
	[record_type] [char](2) NOT NULL,
	[transaction_type] [char](3) NOT NULL,
	[ref_id] [numeric](20, 0) IDENTITY(1,1) NOT NULL,
	[correction_reference] [numeric](20, 0) NULL,
	[sales_transaction_id] [nvarchar](60) NULL,
	[work_id] [nvarchar](60) NULL,
	[release_id] [nvarchar](60) NULL,
	[resource_id] [nvarchar](60) NOT NULL,
	[isrc] [varchar](12) NULL,
	[iswc] [varchar](11) NULL,
	[workcode] [varchar](39) NULL,
	[work_title] [varchar](60) NOT NULL,
	[use_quantity] [decimal](10, 0) NOT NULL,
	[applied_tariff] [varchar](10) NULL,
	[royalty_type] [char](2) NULL,
	[revenue_basis] [numeric](30, 10) NULL,
	[original_release_revenue_basis] [numeric](30, 10) NULL,
	[original_resource_revenue_basis] [numeric](30, 10) NULL,
	[royalty] [numeric](30, 10) NULL,
	[resource_share] [numeric](6, 2) NULL,
	[restrictions] [varchar](10) NULL,
	[claim_licensor_combined] [numeric](6, 2) NOT NULL,
	[claim_copcon_combined] [numeric](6, 2) NULL,
	[claim_unmatched_combined] [numeric](6, 2) NULL,
	[claim_pd_combined] [numeric](6, 2) NULL,
	[claim_not_collected_combined] [numeric](6, 2) NULL,
	[amount_invoiced_total] [numeric](30, 10) NOT NULL,
	[claim_licensor_mech] [numeric](6, 2) NOT NULL,
	[claim_licensor_perf] [numeric](6, 2) NOT NULL,
	[amount_licensor_mech] [numeric](30, 10) NOT NULL,
	[amount_licensor_perf] [numeric](30, 10) NOT NULL,
	[amount_copcon_mech] [numeric](30, 10) NULL,
	[amount_copcon_perf] [numeric](30, 10) NULL,
	[amount_pd_mech] [numeric](30, 10) NULL,
	[amount_pd_perf] [numeric](30, 10) NULL,
	[amount_not_collected_mech] [numeric](30, 10) NULL,
	[amount_not_collected_perf] [numeric](30, 10) NULL,
	[amount_unmatched_mech] [numeric](30, 10) NULL,
	[amount_unmatched_perf] [numeric](30, 10) NULL,
	[claim_copcon_mech] [numeric](6, 2) NULL,
	[claim_copcon_perf] [numeric](6, 2) NULL,
	[claim_pd_mech] [numeric](6, 2) NULL,
	[claim_pd_perf] [numeric](6, 2) NULL,
	[claim_not_collected_mech] [numeric](6, 2) NULL,
	[claim_not_collected_perf] [numeric](6, 2) NULL,
	[claim_unmatched_mech] [numeric](6, 2) NULL,
	[claim_unmatched_perf] [numeric](6, 2) NULL) ON [PRIMARY]


while @curMonth <= @endMonth
begin
	set @exchRate = (select exchRate from CcidExchangeRate where year = @year and month = @curMonth and licId = @licId and licVersion = @licVersion and custId = @custId);
	if @exchRate is null
	begin
		raiserror('Відсутня інформація із договору, необхідна для розрахунків', 0, 0);
		return;
	end

	set @MusicPSM = (select cast(paramValue as float) * @exchRate from AgreementParam where paramId = 5 and licId = @licId and licVersion = @licVersion and custId = @custId);
	set @GePSM = (select cast(paramValue as float) * @exchRate from AgreementParam where paramId = 6 and licId = @licId and licVersion = @licVersion and custId = @custId);

	set @TotalRevenue = (select netrevenue
				from DdexRecordSY_04_01 
				where ddexReportId = @ddexReportId 
					and SubscriberType = 'all'
					and datepart(m, SubPeriodStartDate) = @curMonth); 
	set @MusicPlusGEMusicViews = (select sum(TotalUsages) 
			from DdexRecordSY_05_02 
			where ddexReportId = @ddexReportId 
				and ContentCategory in ('Music', 'GEMusic')
				and datepart(m, SubPeriodStartDate) = @curMonth); 
	set @MusicViews = (select sum(TotalUsages) 
			from DdexRecordSY_05_02 
			where ddexReportId = @ddexReportId 
				and ContentCategory = 'Music'
				and datepart(m, SubPeriodStartDate) = @curMonth); 
	set @MusicRatio = (select @MusicViews / sum(TotalUsages) 
		from DdexRecordSY_05_02 
		where ddexReportId = @ddexReportId
			and datepart(m, SubPeriodStartDate) = @curMonth);
	set @GeRatio = 1 - @MusicRatio;
	set @subscriberCount = (select Subscribers 
		from DdexRecordSY_04_01 
		where ddexReportId = @ddexReportId 
			and SubscriberType = 'all'
			and datepart(m, SubPeriodStartDate) = @curMonth);
	set @musicPSMPool = @subscriberCount * @musicPSM;
	set @gePSMPool = @subscriberCount * @gePSM;
	set @blendedPSMPool = @musicRatio * @musicPSMPool + @geRatio * @gePSMPool;
	set @constantPSMRoyaltyValue = @BlendedPSMPool / @MusicPlusGEMusicViews;
	set @ConstantGrossRevenueValue = @TotalRevenue / @MusicPlusGEMusicViews;
	set @TotalRevSharePayable = @TotalRevenue * (@MusicShareCombined * @MusicRatio + @GeShareCombined * @GeRatio);
	set @TotalPSMPayable = @subscriberCount * (@MusicRatio * @MusicPSM + @geRatio * @gePsm);

	select 
		  @fileType fileType
		, @year [year]
		, @quarter [quarter]
		, @musicRate musicRate
		, @geRate geRate
		, @mechSplit mechSplit
		, @perfSplit perfSplit
		, @MusicPSM MusicPSM
		, @GePSM GePSM
		, @perfMS perfMS
		, @mechMS mechMS
		, @MarketShareCombined MarketShareCombined
		, @MusicShareCombined MusicShareCombined
		, @GeShareCombined GeShareCombined
		, @TotalRevenue TotalRevenue
		, @MusicPlusGEMusicViews MusicPlusGEMusicViews
		, @MusicViews MusicViews
		, @MusicRatio MusicRatio
		, @GeRatio GeRatio
		, @subscriberCount subscriberCount
		, @musicPSMPool musicPSMPool
		, @gePSMPool gePSMPool
		, @blendedPSMPool blendedPSMPool
		, @constantPSMRoyaltyValue constantPSMRoyaltyValue
		, @ConstantGrossRevenueValue ConstantGrossRevenueValue
		, @TotalRevSharePayable TotalRevSharePayable 
		, @TotalPSMPayable TotalPSMPayable 

	if @TotalRevSharePayable > @TotalPSMPayable
	begin
		insert into #CcidInDetail (
				  fileId
				, record_type
				, transaction_type
				--, correction_reference
				, sales_transaction_id
				--, work_id
				, release_id
				, resource_id
				--, isrc
				--, iswc
				, workcode
				, work_title
				, use_quantity
				, applied_tariff
				, royalty_type
				, revenue_basis
				, original_release_revenue_basis
				, original_resource_revenue_basis
				, royalty
				, resource_share
				--, restrictions
				, claim_licensor_combined
				--, claim_copcon_combined
				, claim_unmatched_combined
				--, claim_pd_combined
				--, claim_not_collected_combined
				, amount_invoiced_total
				, claim_licensor_mech
				, claim_licensor_perf
				, amount_licensor_mech
				, amount_licensor_perf
				/*
				, amount_copcon_mech
				, amount_copcon_perf
				, amount_pd_mech
				, amount_pd_perf
				, amount_not_collected_mech
				, amount_not_collected_perf
				, amount_unmatched_mech
				, amount_unmatched_perf
				, claim_copcon_mech
				, claim_copcon_perf
				, claim_pd_mech
				, claim_pd_perf
				, claim_not_collected_mech
				, claim_not_collected_perf
				, claim_unmatched_mech
				, claim_unmatched_perf
				*/
		)
		select 
				  @fileId
				, 'ID'
				, 'ORI'
				, t1.salestransactionid sales_transaction_id
				, left(t1.dspreleaseid, 60) release_id
				, left(t1.dspreleaseid, 60) resource_id
				, left(case 
					when t3.Wic is null 
					then case
							when t4.[ObjId] is null
							then ''
							else 'ObjId:' + cast(t4.[ObjId] as varchar(100)) 
						end
					else 'Wic:' + cast(t3.Wic as varchar(100)) 
					end
				  , 39) workcode
				, left(case 
					when t3.Wic is null 
					then case
							when t4.[name] is null
							then ''
							else t4.[name] 
						end
					else t3.ttl 
					end
					, 60) work_title
				, t1.usages use_quantity
				, case when t1.ContentCategory = 'Music' then @musicRate * 100 else @geRate * 100 end applied_tariff
				, 'P' royalty_type
				, t1.Usages * @ConstantGrossRevenueValue revenue_basis
				, t1.Usages * @ConstantGrossRevenueValue original_release_revenue_basis
				, t1.Usages * @ConstantGrossRevenueValue original_resource_revenue_basis
				, case when t1.usages > 0 then 
					(case when t1.ContentCategory = 'Music' then @musicRate else @geRate end)
							* t1.Usages * @ConstantGrossRevenueValue  / t1.usages 
					else null 
					end royalty
				, 100 resource_share
				, (
						cast(t1.rateTotalMEC as float) * @mechSplit
						+  
						cast(t1.rateTotalPER as float) * @perfSplit
					) 
						as claim_licensor_combined
				, (case when t2.[status] = 1 then 100 else 0 end) claim_unmatched_combined
				, 0.01
					* (
						cast(t1.rateTotalMEC as float) * @mechSplit
						+  
						cast(t1.rateTotalPER as float) * @perfSplit
					)
					* (case when t1.ContentCategory = 'Music' then @musicRate else @geRate end)
					* t1.Usages * @ConstantGrossRevenueValue 
						as amount_invoiced_total
				, cast(t1.rateTotalMEC as float) claim_licensor_mech
				, cast(t1.rateTotalPER as float) claim_licensor_perf
				, 0.01
					* cast(t1.rateTotalMEC as float) * @mechSplit
					* (case when t1.ContentCategory = 'Music' then @musicRate else @geRate end) 
					* t1.Usages * @ConstantGrossRevenueValue
						as amount_licensor_mech
				, 0.01
					* cast(t1.rateTotalPER as float) * @perfSplit
					* (case when t1.ContentCategory = 'Music' then @musicRate else @geRate end)
					* t1.Usages * @ConstantGrossRevenueValue
						as amount_licensor_perf
		from IdentBacklog t1 
			inner join IdentMW t2 on t2.id = t1.mwid
			left join SocWid..widTitle t3 on t3.Wic = t2.Wic
			left join MediaService.dbo.ObjectRight t4 on t4.[ObjId] = t2.[ObjId]
		where t1.DdexReportId = @ddexReportId
			and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
			and (t2.[Status] = 1 or t2.[Status] = 2)
			and datepart(m, t1.ValidityPeriodStart) = @curMonth
	end
	else
	begin
		insert into #CcidInDetail (
				  fileId
				, record_type
				, transaction_type
				--, correction_reference
				, sales_transaction_id
				--, work_id
				, release_id
				, resource_id
				--, isrc
				--, iswc
				, workcode
				, work_title
				, use_quantity
				--, applied_tariff
				, royalty_type
				, revenue_basis
				, original_release_revenue_basis
				, original_resource_revenue_basis
				, royalty
				, resource_share
				--, restrictions
				, claim_licensor_combined
				--, claim_copcon_combined
				, claim_unmatched_combined
				--, claim_pd_combined
				--, claim_not_collected_combined
				, amount_invoiced_total
				, claim_licensor_mech
				, claim_licensor_perf
				, amount_licensor_mech
				, amount_licensor_perf
				/*
				, amount_copcon_mech
				, amount_copcon_perf
				, amount_pd_mech
				, amount_pd_perf
				, amount_not_collected_mech
				, amount_not_collected_perf
				, amount_unmatched_mech
				, amount_unmatched_perf
				, claim_copcon_mech
				, claim_copcon_perf
				, claim_pd_mech
				, claim_pd_perf
				, claim_not_collected_mech
				, claim_not_collected_perf
				, claim_unmatched_mech
				, claim_unmatched_perf
				*/
		)
		select 
				  @fileId
				, 'ID'
				, 'ORI'
				, t1.salestransactionid sales_transaction_id
				, left(t1.dspreleaseid, 60) release_id
				, left(t1.dspreleaseid, 60) resource_id
				, left(case 
					when t3.Wic is null 
					then case
							when t4.[ObjId] is null
							then ''
							else 'ObjId:' + cast(t4.[ObjId] as varchar(100)) 
						end
					else 'Wic:' + cast(t3.Wic as varchar(100)) 
					end
				  , 39) workcode
				, left(case 
					when t3.Wic is null 
					then case
							when t4.[name] is null
							then ''
							else t4.[name] 
						end
					else t3.ttl 
					end
					, 60) work_title
				, t1.usages use_quantity
				--, case when t1.ContentCategory = 'Music' then @musicRate else @geRate end applied_tariff
				, 'M' royalty_type
				, t1.Usages * @ConstantGrossRevenueValue revenue_basis
				, t1.Usages * @ConstantGrossRevenueValue original_release_revenue_basis
				, t1.Usages * @ConstantGrossRevenueValue original_resource_revenue_basis
				, @constantPSMRoyaltyValue royalty
				, 100 resource_share
				,  (
						cast(t1.rateTotalMEC as float) * @mechSplit
						+  
						cast(t1.rateTotalPER as float) * @perfSplit
					) 
						as claim_licensor_combined
				, (case when t2.[status] = 1 then 100 else 0 end) claim_unmatched_combined
				, 0.01 
					* 
					(
						cast(t1.rateTotalMEC as float) * @mechSplit
						+  
						cast(t1.rateTotalPER as float) * @perfSplit
					)
					*
					@constantPSMRoyaltyValue 
					*
					t1.Usages  
						as amount_invoiced_total
				, cast(t1.rateTotalMEC as float) claim_licensor_mech
				, cast(t1.rateTotalPER as float) claim_licensor_perf
				, 0.01 
					* 
					cast(t1.rateTotalMEC as float) * @mechSplit
					*
					@constantPSMRoyaltyValue 
					*
					t1.Usages 
						as amount_licensor_mech
				, 0.01 
					* 
					cast(t1.rateTotalPER as float) * @perfSplit
					*
					@constantPSMRoyaltyValue 
					*
					t1.Usages 
						as amount_licensor_perf
		from IdentBacklog t1 
			inner join IdentMW t2 on t2.id = t1.mwid
			left join SocWid..WidTitle t3 on t3.Wic = t2.Wic
			left join MediaService.dbo.ObjectRight t4 on t4.[ObjId] = t2.[ObjId]
		where t1.DdexReportId = @ddexReportId
			and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
			and (t2.[Status] = 1 or t2.[Status] = 2)
			and datepart(m, t1.ValidityPeriodStart) = @curMonth
	end
	
	set @curMonth = @curMonth + 1;
end

-- insert trailer record

insert into CcidInTrailer(
		fileId
		, record_type
		, id_records
		, dl_records
		, sum_amount_licensor
		, sum_amount_copcon
		, sum_amount_unmatched
)
select
		@fileId
		, 'TR'
		, isnull(count(*), 0) id_records
		, 0 dl_records
		, isnull(sum(amount_invoiced_total), 0) sum_amount_licensor
		, 0 sum_amount_copcon
		, 0 sum_amount_unmatched
from CcidInDetail
where fileId = @fileId

-- mark records as included into invoice
update t1
set t1.IncludedInCcid = @invoiceId
from IdentBacklog t1 
	inner join IdentMW t2 on t2.id = t1.mwid
where t1.DdexReportId = @ddexReportId
	and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
	and (t2.[Status] = 1 or t2.[Status] = 2)

end

--GO

-- exec [spCreateInitialInvoiceSubscrM] 12, null
-- select * from #CcidInDetail
GO

