USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spDdexDeleteReportInvoices]    Script Date: 12.09.2022 13:07:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[spDdexDeleteReportInvoices]
	@ddexReportId int
AS
BEGIN
	delete t1
	from CcidInHeader t1 
		join CcidInFile t2 on t1.fileId = t2.fileId
		join CcidInvoice t3 on t2.ccidInvoiceId = t3.id
	where t3.ddexReportId = @ddexReportId

	delete t1
	from CcidInDetail t1 
		join CcidInFile t2 on t1.fileId = t2.fileId
		join CcidInvoice t3 on t2.ccidInvoiceId = t3.id
	where t3.ddexReportId = @ddexReportId

	delete t1
	from CcidInTrailer t1 
		join CcidInFile t2 on t1.fileId = t2.fileId
		join CcidInvoice t3 on t2.ccidInvoiceId = t3.id
	where t3.ddexReportId = @ddexReportId

	delete t1
	from CcidInFile t1 
		join CcidInvoice t3 on t1.ccidInvoiceId = t3.id
	where t3.ddexReportId = @ddexReportId

	delete CcidInvoice where ddexReportId = @ddexReportId
END
GO

