USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spCreateInitialInvoiceSpotify]    Script Date: 12.09.2022 13:05:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spCreateInitialInvoiceSpotify] @ddexReportId int, @fileId int
as
begin
--declare @ddexReportId int = 22;
--declare @fileId int = null;
declare @invoiceId int;
declare @inInstanceIndex int;
declare @ServiceDescription varchar(100), 
		@RecipientName varchar(100), 
		@SenderName varchar(100), 
		@UsageStartDate date, 
		@UsageEndDate date

declare @musicRate float = (select cast(musicRate as float) * 0.01 from DdexReport where id = @ddexReportId);
declare @mechSplit float = (select cast(mechSplit as float) * 0.01 from DdexReport where id = @ddexReportId);
declare @perfSplit float = (select cast(perfSplit as float) * 0.01 from DdexReport where id = @ddexReportId);

if @musicRate is null or @mechSplit is null or @perfSplit is null
begin
	raiserror('Відсутня інформація із договору, необхідна для розрахунків', 0, 0);
	return;
end

-- get date from Ddex header record for the report
select @ServiceDescription = ServiceDescription
	, @RecipientName = RecipientName
	, @SenderName = SenderName
	, @UsageStartDate = UsageStartDate
	, @UsageEndDate = UsageEndDate
from DdexRecordHead
where DdexReportId = @ddexReportId

declare @CommercialModel varchar(100) = 
	case when lower(@ServiceDescription) = 'free' then 'AdvertisementSupportedModel' else 'SubscriptionModel' end;

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
	insert into CcidInFile(ccidInvoiceId, InstanceIndex, [status], [Name], TargetFolder)
	values (@invoiceId, 1, 0, '', '');
	set @fileId = scope_identity();
end

-- Create CcidInHeader Record 
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
		, 'Spotify'
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
		, @CommercialModel
		, @ServiceDescription
		, 'OnDemandStream'
		, @mechSplit * 100
		, @perfSplit * 100
		, cast(@musicRate * 100 as varchar)
)

-- Create detail records
insert into CcidInDetail (
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
		--, royalty
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
		, right(t1.salestransactionid, len(t1.salestransactionid) - charindex('@', t1.salestransactionid)) sales_transaction_id
		, left(t1.dspreleaseid, 60) release_id
		, left(t1.DspResourceId, 60) resource_id
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
			else t3.WrkTtl 
			end
			, 60) work_title
		, t1.usages use_quantity
		, @musicRate * 100 applied_tariff
		, 'P' royalty_type
		, t1.netrevenue revenue_basis
		, t1.netrevenue original_release_revenue_basis
		, t1.netrevenue original_resource_revenue_basis
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
			* @musicRate
			* t1.netrevenue 
				as amount_invoiced_total
		, t1.rateTotalMEC claim_licensor_mech
		, t1.rateTotalPER claim_licensor_perf
		, 0.01
			* cast(t1.rateTotalMEC as float) 
			* @mechSplit
			* @musicRate
			* t1.netrevenue 
				as amount_licensor_mech
		, 0.01
			* cast(t1.rateTotalPER as float) 
			* @perfSplit
			* @musicRate
			* t1.netrevenue 
				as amount_licensor_perf
from IdentBacklog t1 
	inner join IdentMW t2 on t2.id = t1.mwid
	left join SocWid..WidTitle t3 on t3.Wic = t2.Wic
	left join MediaService.dbo.ObjectRight t4 on t4.[ObjId] = t2.[ObjId]
where t1.DdexReportId = @ddexReportId
	and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
	and (t2.[Status] = 1 or t2.[Status] = 2)

-- Удаляем записи с малой прибылью
exec spRemoveLowRoyaltyFromCcidDetail @fileId;

-- вставляем trailer

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
GO

