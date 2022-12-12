USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spCreateClFromCrf]    Script Date: 12.09.2022 13:05:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spCreateClFromCrf] @inFileId int, @clFileId int
as
begin

delete from CcidClHeader where fileId = @clFileId;
delete from CcidClDetail where fileId = @clFileId;
delete from CcidClTrailer where fileId = @clFileId;

insert CcidClHeader(
		fileId
      ,	record_type
      ,	version
      ,	date
      ,	sender
      ,	receiver
      ,	ccid_id
      ,	territory
      ,	start_date
      ,	end_date
      ,	royalty_currency
      ,	original_revenue_basis_currency
      ,	conversion_rate
      ,	work_code_type
      ,	ccid_id_correction_reference
      ,	type_of_claim
      ,	commercial_model
      ,	service_description
      ,	use_type
      ,	mech_perc_split
      ,	perf_perc_split
      ,	aux
)
select 
		@clFileId
      ,	record_type
      ,	version
      ,	date
      ,	sender
      ,	receiver
      ,	ccid_id
      ,	territory
      ,	start_date
      ,	end_date
      ,	royalty_currency
      ,	original_revenue_basis_currency
      ,	conversion_rate
      ,	work_code_type
      ,	ccid_id_correction_reference
      ,	type_of_claim
      ,	commercial_model
      ,	service_description
      ,	use_type
      ,	mech_perc_split
      ,	perf_perc_split
      ,	aux
from CcidInHeader
where fileId = @inFileId

insert CcidClDetail (
		fileId
      ,	record_type
      ,	transaction_type
	  --, ref_id
      ,	correction_reference
      ,	sales_transaction_id
      ,	work_id
      ,	release_id
      ,	resource_id
      ,	isrc
      ,	iswc
      ,	workcode
      ,	work_title
      ,	use_quantity
      ,	applied_tariff
      ,	royalty_type
      ,	revenue_basis
      ,	original_release_revenue_basis
      ,	original_resource_revenue_basis
      ,	royalty
      ,	resource_share
      ,	restrictions
      ,	claim_licensor_combined
      ,	claim_copcon_combined
      ,	claim_unmatched_combined
      ,	claim_pd_combined
      ,	claim_not_collected_combined
      ,	amount_invoiced_total
      ,	claim_licensor_mech
      ,	claim_licensor_perf
      ,	amount_licensor_mech
      ,	amount_licensor_perf
      ,	amount_copcon_mech
      ,	amount_copcon_perf
      ,	amount_pd_mech
      ,	amount_pd_perf
      ,	amount_not_collected_mech
      ,	amount_not_collected_perf
      ,	amount_unmatched_mech
      ,	amount_unmatched_perf
)
select 
	    @clFileId
      ,	record_type
      ,	transaction_type
      --,	ref_id
      ,	ref_id --correction_reference
      ,	sales_transaction_id
      ,	work_id
      ,	release_id
      ,	resource_id
      ,	isrc
      ,	iswc
      ,	workcode
      ,	work_title
      ,	use_quantity
      ,	applied_tariff
      ,	royalty_type
      ,	revenue_basis
      ,	original_release_revenue_basis
      ,	original_resource_revenue_basis
      ,	royalty
      ,	resource_share
      ,	restrictions
      ,	claim_licensor_combined
      ,	claim_copcon_combined
      ,	claim_unmatched_combined
      ,	claim_pd_combined
      ,	claim_not_collected_combined
      ,	case when t1.statusMech = 2 then amount_licensor_mech else 0 end
		+  	
		case when t1.statusPerf = 2 then amount_licensor_perf else 0 end amount_invoiced_total
      ,	claim_licensor_mech
      ,	claim_licensor_perf
      ,	case when t1.statusMech = 2 then amount_licensor_mech else 0 end amount_licensor_mech
      ,	case when t1.statusPerf = 2 then amount_licensor_perf else 0 end amount_licensor_perf
      ,	amount_copcon_mech
      ,	amount_copcon_perf
      ,	amount_pd_mech
      ,	amount_pd_perf
      ,	amount_not_collected_mech
      ,	amount_not_collected_perf
      ,	amount_unmatched_mech
      ,	amount_unmatched_perf
from CrfDetail t1
	join CcidInDetail t2 on t1.SalesTransactionId = t2.sales_transaction_id
where t1.fileId = @inFileId
order by t2.ref_id

insert into CcidClTrailer(
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
	, count(*)
	, 0
	, sum(amount_invoiced_total)
	, 0
	, 0
from CcidClDetail
where fileId = @clFileId
group by fileId

end
GO

