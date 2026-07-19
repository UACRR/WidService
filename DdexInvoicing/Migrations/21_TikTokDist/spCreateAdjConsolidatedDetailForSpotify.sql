use Ddex
go

alter procedure spCreateAdjConsolidatedDetailForSpotify
	@ddexReportId int
as
begin

	delete from DdexAdjConsolidatedDetail where ddexreportid = @ddexReportId

	insert DdexAdjConsolidatedDetail
	select
		  @ddexReportId as DdexReportId
		, sales_transaction_id as SalesTransactionId
		, use_quantity as AllocatedUsages
		, amount_licensor_perf as AllocatedRevenue
		, 1 as RightsType
		, 0 as ContentCategory
		, amount_licensor_perf as AllocatedRevenueCompensated
		, workcode as WorkCode
	from CcidInDetail t1
		join CcidInFile t2 on t1.fileId = t2.fileId
		join CcidInvoice t3 on t2.ccidInvoiceId = t3.Id
	where t3.ddexReportId = @ddexReportId
	union
	select
		  @ddexReportId as DdexReportId
		, sales_transaction_id as SalesTransactionId
		, use_quantity as AllocatedUsages
		, amount_licensor_mech as AllocatedRevenue
		, 0 as RightsType
		, 0 as ContentCategory
		, amount_licensor_mech as AllocatedRevenueCompensated
		, workcode as WorkCode
	from CcidInDetail t1
		join CcidInFile t2 on t1.fileId = t2.fileId
		join CcidInvoice t3 on t2.ccidInvoiceId = t3.Id
	where t3.ddexReportId = @ddexReportId

	exec spCorrectAdjConsolidated @ddexReportId
end