USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spDdexDeleteReportTypeInvoices]    Script Date: 12.09.2022 13:07:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[spDdexDeleteReportTypeInvoices]
	@fileType varchar(255)
AS
BEGIN
--declare @fileType varchar(255) = 'deezer-all'
	drop table if exists #reportIds;
	select Id
	into #reportIds
	from DdexReport
	where FileType = @fileType

	delete t1
	from CcidInHeader t1 
		join CcidInFile t2 on t1.fileId = t2.fileId
		join CcidInvoice t3 on t2.ccidInvoiceId = t3.id
		join #reportIds t4 on t3.ddexReportId = t4.Id

	delete t1
	from CcidInDetail t1 
		join CcidInFile t2 on t1.fileId = t2.fileId
		join CcidInvoice t3 on t2.ccidInvoiceId = t3.id
		join #reportIds t4 on t3.ddexReportId = t4.Id	

	delete t1
	from CcidInTrailer t1 
		join CcidInFile t2 on t1.fileId = t2.fileId
		join CcidInvoice t3 on t2.ccidInvoiceId = t3.id
		join #reportIds t4 on t3.ddexReportId = t4.Id

	alter table CcidInDetail drop constraint if exists FK_CCID_DET_REFERENCE_CCID_FIL 
	alter table CcidInDetail drop constraint if exists fk_CcidInDetail_CcidInFile 
	delete t1
	from CcidInFile t1 
		join CcidInvoice t3 on t1.ccidInvoiceId = t3.id
		join #reportIds t4 on t3.ddexReportId = t4.Id
	alter table CcidInDetail
		add constraint fk_CcidInDetail_CcidInFile foreign key (fileId) references CcidInFile(fileId);

	delete t3 
	from CcidInvoice t3
		join #reportIds t4 on t3.ddexReportId = t4.Id

	update t3
	set t3.IncludedInCcid = null
	from #reportIds t2
		join IdentBacklog t3 on t2.Id = t3.DdexReportId

	drop table if exists #reportIds;
END
GO

