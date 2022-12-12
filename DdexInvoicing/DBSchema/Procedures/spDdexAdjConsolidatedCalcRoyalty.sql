USE [DDEX]
GO

/****** Object:  StoredProcedure [dbo].[spDdexAdjConsolidatedCalcRoyalty]    Script Date: 12.09.2022 13:06:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER procedure [dbo].[spDdexAdjConsolidatedCalcRoyalty] (
	@ddexReportId int
)
as
begin

declare @fileType varchar(100);
select @fileType = fileType from DdexReport where Id = @ddexReportId;
if @fileType <> 'AdSupport-Music'
begin
	;with factors as (
		select RightsType
			, ContentCategory
			, sum(cast(AllocatedRevenue as float)) / sum(cast(AllocatedUsages as float)) AllocatedRevenuePerUsage
		from DdexAdjConsolidatedSummary
		where DdexReportId = @ddexReportId
		group by RightsType, ContentCategory
	)
	update t1
	set t1.AllocatedRevenue = t1.AllocatedUsages * t2.AllocatedRevenuePerUsage
	from DdexAdjConsolidatedDetail t1
		join factors t2 on t1.RightsType = t2.RightsType and t1.ContentCategory = t2.ContentCategory
	where t1.DdexReportId = @ddexReportId
end

update t1
set t1.WorkCode = t2.workcode
from DdexAdjConsolidatedDetail t1
	join CcidInDetail t2 on t2.sales_transaction_id = t1.SalesTransactionId
where t1.DdexReportId = @DdexReportId
	and t2.workcode <> ''

declare @NotClaimedAmount float;
select @NotClaimedAmount = isnull(sum(AllocatedRevenue), 0)
from DdexAdjConsolidatedDetail
where DdexReportId = @DdexReportId
	and WorkCode is null

declare @GEAmount float;
select @GEAmount = isnull(sum(AllocatedRevenue), 0)
from DdexAdjConsolidatedSummary
where DdexReportId = @ddexReportId
	and ContentCategory = 2

declare @NotGEAmount float;
select @NotGEAmount = isnull(sum(AllocatedRevenue), 0)
from DdexAdjConsolidatedDetail
where DdexReportId = @ddexReportId
	and WorkCode is not null

declare @CompensationAmount float = @NotClaimedAmount + @GEAmount;
declare @CompensationRate float = @CompensationAmount / @NotGEAmount;

update DdexAdjConsolidatedDetail
set AllocatedRevenueCompensated = AllocatedRevenue + AllocatedRevenue * @CompensationRate
where DdexReportId = @DdexReportId
	and WorkCode is not null

end

GO

