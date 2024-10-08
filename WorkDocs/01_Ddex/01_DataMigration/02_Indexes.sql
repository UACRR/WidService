use Ddex
go

drop index if exists idxCcidInDetail_FileId on CcidInDetail
create nonclustered index idxCcidInDetail_FileId on CcidInDetail(FileId)
go

drop index if exists idxIdentMWAuthor_SalesKey on IdentMWAuthor
create nonclustered index idxIdentMWAuthor_SalesKey on IdentMWAuthor(DdexReportId, BlockId, SalesTransactionId)
go

drop index if exists idxDdexReportAuthors_DdexReportId on DdexReportAuthors
create nonclustered index idxDdexReportAuthors_DdexReportId on DdexReportAuthors(DdexReportId)
go

drop index if exists idxDdexReportAuthors_Wic on DdexReportAuthors
create nonclustered index idxDdexReportAuthors_Wic on DdexReportAuthors(Wic)
go

drop index if exists idxDdexReportAuthors_ObjId on DdexReportAuthors
create nonclustered index idxDdexReportAuthors_ObjId on DdexReportAuthors(ObjId)
go

drop index if exists idxIdentBacklog_DdexReportId on IdentBacklog
create nonclustered index idxIdentBacklog_DdexReportId on IdentBacklog(DdexReportId)
go

--select top 1000 * from CcidInDetail where fileId = 284