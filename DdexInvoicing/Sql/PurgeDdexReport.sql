declare @ddexReportId int = xxx;
delete t2
from IdentProgress t1
	join IdentProgressByBlock t2 on t1.Id = t2.IdentProgressId
where t1.ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from IdentProgress 
where ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from IdentReportMwRecords 
where ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from IdentMWAuthor 
where ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from DdexReportProcessingData 
where ddexReportId = @ddexReportId
go

alter table IdentMWAuthor drop constraint FK_IDENTMWA_REFERENCE_IDENTBAC
go

declare @ddexReportId int = xxx;
delete from IdentBacklog
where ddexReportId = @ddexReportId
go

alter table IdentMWAuthor add constraint FK_IDENTMWA_REFERENCE_IDENTBAC foreign key(BlockId, DdexReportId, SalesTransactionId)
references IdentBacklog (BlockId, DdexReportId, SalesTransactionId)
go

declare @ddexReportId int = xxx;
delete from DdexRecordHead
where ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from DdexRecordSY_04_01
where ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from DdexRecordSY_05_02
where ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from DdexIdentificationBacklog
where ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from DdexFileErrors
where ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from DdexAdjConsolidatedSummary
where ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from DdexAdjConsolidatedDetail
where ddexReportId = @ddexReportId
go

-- CCID IN
declare @ddexReportId int = xxx;
delete t3
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidInHeader t3 on t2.fileId = t3.fileId
where t1.ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete t3
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidInTrailer t3 on t2.fileId = t3.fileId
where t1.ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete t3
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidInDetail t3 on t2.fileId = t3.fileId
where t1.ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete t3
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
	join CrfDetail t3 on t2.fileId = t3.fileId
where t1.ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete t3
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
	join DdexAdjustment t3 on t2.fileId = t3.fileId
where t1.ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete t2
from CcidInvoice t1
	join CcidInFile t2 on t1.Id = t2.ccidInvoiceId
where t1.ddexReportId = @ddexReportId
go

-- CCID CL

declare @ddexReportId int = xxx;
delete t3
from CcidInvoice t1
	join CcidClFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidClHeader t3 on t2.fileId = t3.fileId
where t1.ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete t3
from CcidInvoice t1
	join CcidClFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidClTrailer t3 on t2.fileId = t3.fileId
where t1.ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete t3
from CcidInvoice t1
	join CcidClFile t2 on t1.Id = t2.ccidInvoiceId
	join CcidClDetail t3 on t2.fileId = t3.fileId
where t1.ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete t2
from CcidInvoice t1
	join CcidClFile t2 on t1.Id = t2.ccidInvoiceId
where t1.ddexReportId = @ddexReportId
go

-- CCID INVOICE
declare @ddexReportId int = xxx;
delete 
from CcidInvoice 
where ddexReportId = @ddexReportId
go

declare @ddexReportId int = xxx;
delete from DdexReport
where Id = @ddexReportId
go
