USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spDdexDeleteReportData]    Script Date: 12.09.2022 13:07:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER PROCEDURE [dbo].[spDdexDeleteReportData] @ddexReportId int
AS
BEGIN
	SET NOCOUNT ON;

	-- declare @ddexReportId int = 14
	delete t1 
	from CcidInHeader t1 
		join CcidInFile t2 on t1.fileID = t2.fileId
		join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
	where t3.ddexReportId = ddexReportId

	delete t1 
	from CcidInDetail t1 
		join CcidInFile t2 on t1.fileID = t2.fileId
		join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
	where t3.ddexReportId = ddexReportId

	delete t1 
	from CcidInTrailer t1 
		join CcidInFile t2 on t1.fileID = t2.fileId
		join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
	where t3.ddexReportId = ddexReportId

	delete t1 
	from CcidClHeader t1 
		join CcidClFile t2 on t1.fileID = t2.fileId
		join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
	where t3.ddexReportId = ddexReportId

	delete t1 
	from CcidClDetail t1 
		join CcidClFile t2 on t1.fileID = t2.fileId
		join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
	where t3.ddexReportId = ddexReportId

	delete t1 
	from CcidClTrailer t1 
		join CcidClFile t2 on t1.fileID = t2.fileId
		join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
	where t3.ddexReportId = ddexReportId

	delete t2 
	from CcidInFile t2
		join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
	where t3.ddexReportId = ddexReportId

	delete t2 
	from CcidClFile t2
		join CcidInvoice t3 on t3.Id = t2.ccidInvoiceId
	where t3.ddexReportId = ddexReportId

	delete CcidInvoice where ddexReportId = ddexReportId

	delete from IdentReportMwRecords where ddexReportId = @ddexReportId
	delete t1 from IdentProgressByBlock t1 join IdentProgress t2 on t2.id = t1.IdentProgressId where t2.DdexReportId = @ddexReportId
	delete from IdentProgress where DdexReportId = @ddexReportId
	delete from IdentBacklog where ddexReportId = @ddexReportId
	delete from DdexNetRevenueDistr where ddexReportId = @ddexReportId
	delete from DdexIdentificationBacklog where ddexReportId = @ddexReportId
	delete from DdexFileErrors where ddexReportId = @ddexReportId
	--delete from DdexRecordHead where ddexReportId = @ddexReportId
	delete from DdexRecordSY_04_01 where ddexReportId = @ddexReportId
	delete from DdexRecordSY_05_02 where ddexReportId = @ddexReportId
	update DdexReport set Status = 0, SubStatus = 0 where Id = @ddexReportId
END
GO

