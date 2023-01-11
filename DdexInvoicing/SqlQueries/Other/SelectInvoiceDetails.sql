declare @fileid int = 4;
select top 1000
        t4.*
    ,   t5.ResourceTitle
    ,   t5.Title
    ,   t5.ComposerAuthor
    ,   t5.DisplayArtistName
    ,   t5.ISWC
    ,   t5.Wic
    ,   t5.[ObjId]
    ,   t1.record_type
    ,   t1.transaction_type
    ,   t1.sales_transaction_id
    ,   t1.release_id
    ,   t1.resource_id
    ,   t1.workcode
    ,   t1.work_title
    ,   t1.use_quantity
    ,   t1.applied_tariff
    ,   t1.original_release_revenue_basis
    ,   t1.original_resource_revenue_basis
    ,   t1.claim_licensor_combined
    ,   t1.claim_unmatched_combined
    ,   t1.amount_invoiced_total
    ,   t1.claim_licensor_mech
    ,   t1.claim_licensor_perf
    ,   t1.amount_licensor_mech
    ,   t1.amount_licensor_perf
from CcidInDetail t1
    join CcidInFile t2 on t2.fileId = t1.fileId
    join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
	join IdentBacklog t4 on t1.sales_transaction_id = t4.SalesTransactionId
	join IdentMw t5 on t4.mwId = t5.id
where t1.fileId = @fileId and t3.ddexReportId = t4.ddexReportId
order by t4.NetRevenue desc
                 