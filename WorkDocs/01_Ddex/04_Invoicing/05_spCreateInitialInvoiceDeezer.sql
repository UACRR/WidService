use Ddex
go

create or alter procedure [dbo].[spCreateInitialInvoiceDeezer] @leadingDdexReportId int, @leadingFileId int
as
begin
--declare @leadingDdexReportId int = 37;
--declare @leadingFileId int = 91;
declare @musicRate float = (select cast(musicRate as float) * 0.01 from DdexReport where id = @leadingDdexReportId);
declare @mechSplit float = (select cast(mechSplit as float) * 0.01 from DdexReport where id = @leadingDdexReportId);
declare @perfSplit float = (select cast(perfSplit as float) * 0.01 from DdexReport where id = @leadingDdexReportId);

if @musicRate is null or @mechSplit is null or @perfSplit is null
begin
	raiserror('Відсутня інформація із договору, необхідна для розрахунків', 0, 0);
	return;
end

-- create invoice if required and get invoice id
declare @invoiceId int;

if @leadingFileId is null
begin
	insert into CcidInvoice(
		  ddexReportId
		, createdDate
		, [status]
		, recordCount
		, netRevenueExcluded
		, netRevenueClaimed
	)
	values (
		  @leadingDdexReportId
		, getdate()
		, 0 --status
		, null -- recordCount
		, null -- netRevenueExcluded
		, null -- netRevenueClaimed
	);
	select @invoiceId = SCOPE_IDENTITY();
end
else
begin
	select @invoiceId = ccidInvoiceId 
	from CcidInFile 
	where fileId = @leadingFileId;
end

-- We are dealing with initial file(s)
declare @inInstanceIndex int = 1;

-- get data from Ddex header records for the report group
drop table if exists #tmpHeaderInfo;
select *
into #tmpHeaderInfo
from DdexRecordHead
where DdexReportId in (select id from ft_AgreementReportIds(@leadingDdexReportId))

-- get data from summary records records for the report group
drop table if exists #tmpSummaryInfo;
select *
into #tmpSummaryInfo
from DdexRecordSY_Base
where DdexReportId in (select id from ft_AgreementReportIds(@leadingDdexReportId))

-- cleanup initial CCID file records for invoice or create CCID file record
if @leadingFileId is not null
begin
	delete t1
	from CcidInDetail t1
		join CcidInFile t2 on t1.fileId = t2.fileId
	where t2.ccidInvoiceId = @invoiceId
		and t2.InstanceIndex = @inInstanceIndex

	delete t1
	from CcidInTrailer t1
		join CcidInFile t2 on t1.fileId = t2.fileId
	where t2.ccidInvoiceId = @invoiceId
		and t2.InstanceIndex = @inInstanceIndex

	delete t1
	from CcidInHeader t1
		join CcidInFile t2 on t1.fileId = t2.fileId
	where t2.ccidInvoiceId = @invoiceId
		and t2.InstanceIndex = @inInstanceIndex
end
else
begin
	insert into CcidInFile(
		  ccidInvoiceId
		, InstanceIndex
		, [status]
		, [Name]
		, TargetFolder
		, ddexReportId
	)
	select
		  @invoiceId
		, 1
		, 0
		, ''
		, ''
		, id
	from DdexReport
	where Id in (select id from ft_AgreementReportIds(@leadingDdexReportId))
end

-- Here we have CcidInFile records that reference corresponding ddex report from the group of sevices

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
select
		  t1.fileId
		, 'HD' -- record_type
		, '14.1' -- version
		, GetDate() -- date
		, 'UACRR-CS' -- sender
		, t3.SenderName -- receiver
		, cast(t1.fileId as varchar) -- ccid_id
		, t4.Territory -- territory
		, t3.UsageStartDate -- start_date
		, t3.UsageEndDate -- end_date
		, t4.Currency -- royalty_currency
		, t4.Currency -- original_revenue_basis_currency
		, 1.00000 -- conversion_rate
		, null -- work_code_type
		, null -- ccid_id_correction_reference
		, 'IN' -- type_of_claim
		, t4.CommercialModel -- commercial_model
		, t3.ServiceDescription -- service_description
		, t4.UseType -- use_type
		, @mechSplit * 100 -- mech_perc_split
		, @perfSplit * 100 -- perf_perc_split
		, cast(@musicRate * 100 as varchar) -- aux
from CcidInFile t1
	join CcidInvoice t2 on t1.ccidInvoiceId = t2.Id
	join #tmpHeaderInfo t3 on t1.ddexReportId = t3.DdexReportId
	join #tmpSummaryInfo t4 on t1.ddexReportId = t4.DdexReportId
	join DdexReport t5 on t1.ddexReportId = t5.Id
where t2.Id = @invoiceId
	and t1.InstanceIndex = @inInstanceIndex
	
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
		  t5.fileId
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
from 
	CcidInFile t5
	inner join DdexReport t6 on t5.ddexReportId = t6.id
	inner join IdentBacklog t1 on t1.DdexReportId = t6.id
	inner join IdentMW t2 on t2.id = t1.mwid
	left join SocWid..WidTitle t3 on t3.Wic = t2.Wic
	left join MediaService.dbo.ObjectRight t4 on t4.[ObjId] = t2.[ObjId]
where t5.ccidInvoiceId = @invoiceId
	and t5.InstanceIndex = @inInstanceIndex
	and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
	and (t2.[Status] = 1 or t2.[Status] = 2)

-- вставляем trailer

-- insert empty records to serve the case when some files have no detail records
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
		  fileId
		, 'TR'
		, 0 id_records
		, 0 dl_records
		, 0 sum_amount_licensor
		, 0 sum_amount_copcon
		, 0 sum_amount_unmatched
from CcidInFile
where ccidInvoiceId = @invoiceId
	and InstanceIndex = @inInstanceIndex

-- update records for files having detail records
;with TmpCcidInTrailer as (
	select
		  t1.fileId
		, isnull(count(*), 0) id_records
		, isnull(sum(t1.amount_invoiced_total), 0) sum_amount_licensor
	from CcidInDetail t1
		join CcidInFile t2 on t1.fileId = t2.fileId	
	where t2.ccidInvoiceId = @invoiceId
		and t2.InstanceIndex = @inInstanceIndex
	group by t1.fileId
)
update t1
set
	t1.id_records = t2.id_records
	, t1.sum_amount_licensor = t2.sum_amount_licensor
from CcidInTrailer t1
	join TmpCcidInTrailer t2 on t1.fileId = t2.fileId

-- mark records as included into invoice
update t1
set t1.IncludedInCcid = @invoiceId
from IdentBacklog t1 
	inner join IdentMW t2 on t2.id = t1.mwid
where t1.DdexReportId in (select id from ft_AgreementReportIds(@leadingDdexReportId))
	and (t1.IncludedInCcid is null or t1.IncludedInCcid = @invoiceId)
	and (t2.[Status] = 1 or t2.[Status] = 2)

drop table #tmpHeaderInfo
drop table #tmpSummaryInfo;

end

--exec [spCreateInitialInvoiceDeezer] 37, null
go

