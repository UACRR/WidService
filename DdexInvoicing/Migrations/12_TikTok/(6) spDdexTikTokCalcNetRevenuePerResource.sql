use Ddex
go

create or alter procedure spDdexTikTokCalcNetRevenuePerResource
	@ddexReportId int
as
begin
	declare @totalNetRevenue decimal(20, 6) = (
		select NetRevenue 
		from DdexRecordSY_Base 
		where ddexReportId = @ddexReportId
	)

	declare @totalUsages int= (
		select sum(Usages)
		from DdexIdentificationBacklog
		where ddexReportId = @ddexReportId
	)

	declare @netRevenuePerUsage float = @totalNetRevenue / @totalUsages

	update DdexIdentificationBacklog
	set NetRevenue = Usages * @netRevenuePerUsage
	where ddexReportId = @ddexReportId

end
go

-- exec spDdexTikTokCalcNetRevenuePerResource 956
