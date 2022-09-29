declare @ccidInvoiceId int = (select max(Id) from CcidInvoice);

delete t1
from CcidInHeader t1
	join CcidInFile t2 on t1.fileId = t2.fileId
	join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
where t3.id = @ccidInvoiceId

delete t1
from CcidInDetail t1
	join CcidInFile t2 on t1.fileId = t2.fileId
	join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
where t3.id = @ccidInvoiceId

delete t1
from CcidInTrailer t1
	join CcidInFile t2 on t1.fileId = t2.fileId
	join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
where t3.id = @ccidInvoiceId

delete t2
from CcidInFile t2
	join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
where t3.id = @ccidInvoiceId

delete CcidInvoice
where id = @ccidInvoiceId

update IdentBacklog
set IncludedInCcid = null
where IncludedInCcid = @ccidInvoiceId
