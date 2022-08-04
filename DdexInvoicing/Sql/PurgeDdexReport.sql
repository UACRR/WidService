delete t2
from IdentProgress t1
	join IdentProgressByBlock t2 on t1.Id = t2.IdentProgressId

go


delete from IdentProgress 

go


delete from IdentReportMwRecords 

go


delete from IdentMWAuthor 

go


delete from DdexReportProcessingData 

go

alter table IdentMWAuthor drop constraint FK_IDENTMWA_REFERENCE_IDENTBAC
go


delete from IdentBacklog

go

alter table IdentMWAuthor add constraint FK_IDENTMWA_REFERENCE_IDENTBAC foreign key(BlockId, DdexReportId, SalesTransactionId)
references IdentBacklog (BlockId, DdexReportId, SalesTransactionId)
go


delete from DdexRecordHead

go


delete from DdexRecordSY_04_01

go


delete from DdexRecordSY_05_02

go


delete from DdexIdentificationBacklog

go


delete from DdexFileErrors

go


delete from DdexAdjConsolidatedSummary

go


delete from DdexAdjConsolidatedDetail

go

-- CCID IN

delete t3
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidInHeader t3 on t2.fileId = t3.fileId

go


delete t3
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidInTrailer t3 on t2.fileId = t3.fileId

go


delete t3
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidInDetail t3 on t2.fileId = t3.fileId

go


delete t3
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
	join CrfDetail t3 on t2.fileId = t3.fileId

go


delete t3
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
	join DdexAdjustment t3 on t2.fileId = t3.fileId

go


delete t2
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId

go

-- CCID CL


delete t3
from CcidInvoice t1
	join CcidClFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidClHeader t3 on t2.fileId = t3.fileId

go


delete t3
from CcidInvoice t1
	join CcidClFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidClTrailer t3 on t2.fileId = t3.fileId

go


delete t3
from CcidInvoice t1
	join CcidClFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidClDetail t3 on t2.fileId = t3.fileId

go


delete t2
from CcidInvoice t1
	join CcidClFile t2 on t1.Id = t2.ccidInvoiceId

go

-- CCID INVOICE

delete 
from CcidInvoice 

go


delete from DdexReport

go
