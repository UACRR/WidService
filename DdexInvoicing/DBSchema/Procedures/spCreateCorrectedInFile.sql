USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spCreateCorrectedInFile]    Script Date: 12.09.2022 13:05:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spCreateCorrectedInFile] @ccidClFileId int
as
begin
declare @clInstanceIndex int = (select InstanceIndex from CcidClFile where fileId = @ccidClFileId);
declare @inNewInstanceIndex int = @clInstanceIndex + 1;
declare @ccidInvoiceId int = (select CcidInvoiceId from CcidClFile where fileId = @ccidClFileId);
declare @newCcidInFileId int = (select fileId from CcidInFile where ccidInvoiceId = @ccidInvoiceId and InstanceIndex = @inNewInstanceIndex);
declare @prevCcidInFileId int = (select fileId from CcidInFile where ccidInvoiceId = @ccidInvoiceId and InstanceIndex = @inNewInstanceIndex - 1);

-- cleaup In file if exists or create new one otherwise
if @newCcidInFileId is not null
begin
	delete from CcidInDetail where fileId = @newCcidInFileId
	delete from CcidInTrailer where fileId = @newCcidInFileId
	delete from CcidInHeader where fileId = @newCcidInFileId
end
else
begin
	insert into CcidInFile(ccidInvoiceId, InstanceIndex, [status], [Name], TargetFolder)
	values (@ccidInvoiceId, @inNewInstanceIndex, 0, '', '');
	set @newCcidInFileId = scope_identity();
end

-- prepare working data
if object_id('tempdb..#tmpDetails') IS NOT NULL
    drop table #tmpDetails

-- create snapshot of detail records of the latest sent invoice
select *
into #tmpDetails
from CcidInDetail
where fileId = @prevCcidInFileId

-- overwrite snaphot by the records from Claim
-- Keep ref_id and correction_reference untouched
;with ClDetailEx as
(
	select * 
	from CcidClDetail
	where fileId = @ccidClFileId
)
merge into #tmpDetails
   using ClDetailEx
      on #tmpDetails.ref_id = ClDetailEx.correction_reference
when matched then
   update 
      set fileId = ClDetailEx.fileId
		,	record_type = ClDetailEx.record_type
		,	transaction_type = ClDetailEx.transaction_type
		--,	ref_id = ClDetailEx.ref_id
		--,	correction_reference = null
		,	sales_transaction_id = ClDetailEx.sales_transaction_id
		,	work_id = ClDetailEx.work_id
		,	release_id = ClDetailEx.release_id
		,	resource_id = ClDetailEx.resource_id
		,	isrc = ClDetailEx.isrc
		,	iswc = ClDetailEx.iswc
		,	workcode = ClDetailEx.workcode
		,	work_title = ClDetailEx.work_title
		,	use_quantity = ClDetailEx.use_quantity
		,	applied_tariff = ClDetailEx.applied_tariff
		,	royalty_type = ClDetailEx.royalty_type
		,	revenue_basis = ClDetailEx.revenue_basis
		,	original_release_revenue_basis = ClDetailEx.original_release_revenue_basis
		,	original_resource_revenue_basis = ClDetailEx.original_resource_revenue_basis
		,	royalty = ClDetailEx.royalty
		,	resource_share = ClDetailEx.resource_share
		,	restrictions = ClDetailEx.restrictions
		,	claim_licensor_combined = ClDetailEx.claim_licensor_combined
		,	claim_copcon_combined = ClDetailEx.claim_copcon_combined
		,	claim_unmatched_combined = ClDetailEx.claim_unmatched_combined
		,	claim_pd_combined = ClDetailEx.claim_pd_combined
		,	claim_not_collected_combined = ClDetailEx.claim_not_collected_combined
		,	amount_invoiced_total = ClDetailEx.amount_invoiced_total
		,	claim_licensor_mech = ClDetailEx.claim_licensor_mech
		,	claim_licensor_perf = ClDetailEx.claim_licensor_perf
		,	amount_licensor_mech = ClDetailEx.amount_licensor_mech
		,	amount_licensor_perf = ClDetailEx.amount_licensor_perf
		,	amount_copcon_mech = ClDetailEx.amount_copcon_mech
		,	amount_copcon_perf = ClDetailEx.amount_copcon_perf
		,	amount_pd_mech = ClDetailEx.amount_pd_mech
		,	amount_pd_perf = ClDetailEx.amount_pd_perf
		,	amount_not_collected_mech = ClDetailEx.amount_not_collected_mech
		,	amount_not_collected_perf = ClDetailEx.amount_not_collected_perf
		,	amount_unmatched_mech = ClDetailEx.amount_unmatched_mech
		,	amount_unmatched_perf = ClDetailEx.amount_unmatched_perf
		,	claim_copcon_mech = ClDetailEx.claim_copcon_mech
		,	claim_copcon_perf = ClDetailEx.claim_copcon_perf
		,	claim_pd_mech = ClDetailEx.claim_pd_mech
		,	claim_pd_perf = ClDetailEx.claim_pd_perf
		,	claim_not_collected_mech = ClDetailEx.claim_not_collected_mech
		,	claim_not_collected_perf = ClDetailEx.claim_not_collected_perf
		,	claim_unmatched_mech = ClDetailEx.claim_unmatched_mech
		,	claim_unmatched_perf = ClDetailEx.claim_unmatched_perf;

-- remove from the snaphot records having zero amount after merge
delete from #tmpDetails where amount_invoiced_total = 0;

-- Create CcidInHeader Record making copy of header record of the ccid In file and setting new ccid_id
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
		@newCcidInFileId
		, record_type
		, version
		, GetDate()
		, sender
		, receiver
		, cast(@newCcidInFileId as varchar) -- ccid_id
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
from CcidInHeader
where fileId = @prevCcidInFileId

-- insert detail records from the corrected snapshot letting ccid_id be automatically filled-in
insert into CcidInDetail (
		  fileId
		, record_type
		, transaction_type
		, correction_reference
		, sales_transaction_id
		, work_id
		, release_id
		, resource_id
		, isrc
		, iswc
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
		, restrictions
		, claim_licensor_combined
		, claim_copcon_combined
		, claim_unmatched_combined
		, claim_pd_combined
		, claim_not_collected_combined
		, amount_invoiced_total
		, claim_licensor_mech
		, claim_licensor_perf
		, amount_licensor_mech
		, amount_licensor_perf
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
)
select 
		  @newCcidInFileId
		, record_type
		, transaction_type
		, correction_reference
		, sales_transaction_id
		, work_id
		, release_id
		, resource_id
		, isrc
		, iswc
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
		, restrictions
		, claim_licensor_combined
		, claim_copcon_combined
		, claim_unmatched_combined
		, claim_pd_combined
		, claim_not_collected_combined
		, amount_invoiced_total
		, claim_licensor_mech
		, claim_licensor_perf
		, amount_licensor_mech
		, amount_licensor_perf
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
from #tmpDetails

-- insert trailer record based on previous trailer record with sum_amount_licensor corrected
declare @sum_amount_licensor decimal(20, 10) = (select sum(amount_invoiced_total) from #tmpDetails)
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
		  @newCcidInFileId
		, record_type
		, id_records
		, dl_records
		, @sum_amount_licensor
		, sum_amount_copcon
		, sum_amount_unmatched
from CcidInTrailer
where fileId = @prevCcidInFileId;

-- drop working data
drop table #tmpDetails;

end


--exec spCreateCorrectedInFile 7
GO

