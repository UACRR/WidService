use DDEX
go


exec spSetParamValueInt N'leadingDdexReportId', 1520
exec spSetParamValueInt N'leadingFileId', null

declare @musicRate float = (select cast(musicRate as float) * 0.01 from DdexReport where id = dbo.fnParamValueInt(N'leadingDdexReportId'));
exec spSetParamValueFloat N'musicRate', @musicRate

declare @mechSplit float = (select cast(mechSplit as float) * 0.01 from DdexReport where id = dbo.fnParamValueInt(N'leadingDdexReportId'));
exec spSetParamValueFloat N'mechSplit', @mechSplit

declare @perfSplit float = (select cast(perfSplit as float) * 0.01 from DdexReport where id = dbo.fnParamValueInt(N'leadingDdexReportId'));
exec spSetParamValueFloat N'perfSplit', @perfSplit

if dbo.fnParamValueInt(N'musicRate') is null or dbo.fnParamValueInt(N'mechSplit') is null or dbo.fnParamValueInt(N'perfSplit') is null
begin
	print 'Відсутня інформація із договору, необхідна для розрахунків';
end

--rollback tran
begin tran
declare @invoiceId int;

if dbo.fnParamValueInt(N'leadingFileId') is null
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
		  dbo.fnParamValueInt(N'leadingDdexReportId')
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
	where fileId = dbo.fnParamValueInt(N'leadingFileId')
end
exec spSetParamValueInt N'invoiceId', @invoiceId

-- We are dealing with initial file(s)
exec spSetParamValueInt N'inInstanceIndex', 1

-- get data from Ddex header records for the report group
drop table if exists #tmpHeaderInfo;
select *
into #tmpHeaderInfo
from DdexRecordHead
where DdexReportId in (select id from ft_AgreementReportIds(dbo.fnParamValueInt(N'leadingDdexReportId')))

-- get data from summary records records for the report group
drop table if exists #tmpSummaryInfo;
select distinct DdexReportId, Territory, Currency, CommercialModel, 'AsPerContractConsumption' as UseType
into #tmpSummaryInfo
from DdexRecordSY_Base
where DdexReportId in (select id from ft_AgreementReportIds(dbo.fnParamValueInt(N'leadingDdexReportId')))

-- cleanup initial CCID file records for invoice or create CCID file record
if dbo.fnParamValueInt(N'leadingFileId') is not null
begin
	delete t1
	from CcidInDetail t1
		join CcidInFile t2 on t1.fileId = t2.fileId
	where t2.ccidInvoiceId = dbo.fnParamValueInt(N'invoiceId')
		and t2.InstanceIndex = dbo.fnParamValueInt(N'inInstanceIndex')

	delete t1
	from CcidInTrailer t1
		join CcidInFile t2 on t1.fileId = t2.fileId
	where t2.ccidInvoiceId = dbo.fnParamValueInt(N'invoiceId')
		and t2.InstanceIndex = dbo.fnParamValueInt(N'inInstanceIndex')

	delete t1
	from CcidInHeader t1
		join CcidInFile t2 on t1.fileId = t2.fileId
	where t2.ccidInvoiceId = dbo.fnParamValueInt(N'invoiceId')
		and t2.InstanceIndex = dbo.fnParamValueInt(N'inInstanceIndex')
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
		  dbo.fnParamValueInt(N'invoiceId')
		, 1
		, 0
		, ''
		, ''
		, id
	from DdexReport
	where Id in (select id from ft_AgreementReportIds(dbo.fnParamValueInt(N'leadingDdexReportId')))
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
		, dbo.fnParamValueFloat(N'mechSplit') * 100 -- mech_perc_split
		, dbo.fnParamValueFloat(N'perfSplit') * 100 -- perf_perc_split
		, cast(dbo.fnParamValueFloat(N'musicRate') * 100 as varchar) -- aux
from CcidInFile t1
	join CcidInvoice t2 on t1.ccidInvoiceId = t2.Id
	join #tmpHeaderInfo t3 on t1.ddexReportId = t3.DdexReportId
	join #tmpSummaryInfo t4 on t1.ddexReportId = t4.DdexReportId
	join DdexReport t5 on t1.ddexReportId = t5.Id
where t2.Id = dbo.fnParamValueInt(N'invoiceId')
	and t1.InstanceIndex = dbo.fnParamValueInt(N'inInstanceIndex')

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
		, dbo.fnParamValueFloat(N'musicRate') * 100 applied_tariff
		, 'P' royalty_type
		, t1.netrevenue revenue_basis
		, t1.netrevenue original_release_revenue_basis
		, t1.netrevenue original_resource_revenue_basis
		, 100 resource_share
		, (
				cast(isnull(t1.rateTotalMEC, 0) as float) * dbo.fnParamValueFloat(N'mechSplit')
				+  
				cast(isnull(t1.rateTotalPER, 0) as float) * dbo.fnParamValueFloat(N'perfSplit')
			) 
				as claim_licensor_combined
		, (case when t2.[status] = 1 then 100 else 0 end) claim_unmatched_combined
		, 0.01
			* (
				cast(isnull(t1.rateTotalMEC, 0) as float) * dbo.fnParamValueFloat(N'mechSplit')
				+  
				cast(isnull(t1.rateTotalPER, 0) as float) * dbo.fnParamValueFloat(N'perfSplit')
			)
			* dbo.fnParamValueFloat(N'musicRate')
			* t1.netrevenue 
				as amount_invoiced_total
		, isnull(t1.rateTotalMEC, 0) claim_licensor_mech
		, isnull(t1.rateTotalPER, 0) claim_licensor_perf
		, 0.01
			* cast(isnull(t1.rateTotalMEC, 0) as float) 
			* dbo.fnParamValueFloat(N'mechSplit')
			* dbo.fnParamValueFloat(N'musicRate')
			* t1.netrevenue 
				as amount_licensor_mech
		, 0.01
			* cast(isnull(t1.rateTotalPER, 0) as float) 
			* dbo.fnParamValueFloat(N'perfSplit')
			* dbo.fnParamValueFloat(N'musicRate')
			* t1.netrevenue 
				as amount_licensor_perf
from 
	CcidInFile t5
	inner join DdexReport t6 on t5.ddexReportId = t6.id
	inner join IdentBacklog t1 on t1.DdexReportId = t6.id
	inner join IdentMW t2 on t2.id = t1.mwid
	left join SocWid..WidTitle t3 on t3.Wic = t2.Wic
	left join MediaService.dbo.ObjectRight t4 on t4.ObjId = t2.ObjId
		--or (t4.categoryCode = 18 and t4.loadid = t2.ObjId)
where t5.ccidInvoiceId = dbo.fnParamValueInt(N'invoiceId')
	and t5.InstanceIndex = dbo.fnParamValueInt(N'inInstanceIndex')
	and (t1.IncludedInCcid is null or t1.IncludedInCcid = dbo.fnParamValueInt(N'invoiceId'))
	--and (t2.[Status] = 1 or t2.[Status] = 2)
	and (
		cast(isnull(t1.rateTotalMEC, 0) as float) * dbo.fnParamValueFloat(N'mechSplit')
		+  
		cast(isnull(t1.rateTotalPER, 0) as float) * dbo.fnParamValueFloat(N'perfSplit')
	) > 0

rollback tran


