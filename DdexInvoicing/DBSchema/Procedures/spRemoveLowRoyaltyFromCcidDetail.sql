USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spRemoveLowRoyaltyFromCcidDetail]    Script Date: 12.09.2022 13:09:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spRemoveLowRoyaltyFromCcidDetail]
	  @fileId int
as
begin

declare @royaltyThreshold numeric(30, 10) = (
	select isnull(t3.royaltyThreshold, 0)
	from CcidInFile t1
		join CcidInvoice t2 on t2.id = t1.ccidInvoiceId
		join DdexReport t3 on t3.id = t2.ddexReportId
	where t1.fileId = @fileId
);

if @royaltyThreshold = 0
	return;

delete
from CcidInDetail
where fileId = @fileId 
	and workcode in (
		select workcode
		from CcidInDetail
		where fileId = @fileId
			and isnull(workcode, '') <> ''
		group by workcode
		having sum(amount_licensor_mech) < @royaltyThreshold
			and sum(amount_licensor_perf) < @royaltyThreshold 
	);

delete
from CcidInDetail
where fileId = @fileId
	and amount_invoiced_total = 0;

end
GO

