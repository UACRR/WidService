use Ddex
go

create or alter procedure spCorrectAdjConsolidated
	@ddexReportId int
as
begin
	drop table if exists #WrongWorkCodes
	select distinct t1.WorkCode
	into #WrongWorkCodes
	from DdexAdjConsolidatedDetail t1
		left join MediaService..ObjectRight t2 on t1.WorkCode = concat('ObjId:', t2.ObjId)
	where t1.DdexReportId = @ddexReportId
		and t2.ObjId is null
		and t1.WorkCode like 'ObjId:%'
	union
	select distinct t1.WorkCode
	from DdexAdjConsolidatedDetail t1
		left join SocWid..WidTitle t2 on t1.WorkCode = concat('Wic:', t2.Wic)
	where t1.DdexReportId = @ddexReportId
		and t2.Wic is null
		and t1.WorkCode like 'Wic:%'

	declare @SumFullPer float, @SumFullMec float
	select
		  @SumFullPer = sum(case when RightsType = 1 then AllocatedRevenue else 0 end)
		, @SumFullMec = sum(case when RightsType = 0 then AllocatedRevenue else 0 end)
	from DdexAdjConsolidatedDetail
	where DdexReportId = @ddexReportId
	
	delete t1
	from DdexAdjConsolidatedDetail t1
		join #WrongWorkCodes t2 on t1.WorkCode = t2.WorkCode
	where t1.DdexReportId = @ddexReportId

	declare @SumFinalPer float,	@SumFinalMec float
	select
		  @SumFinalPer = sum(case when RightsType = 1 then AllocatedRevenue else 0 end)
		, @SumFinalMec = sum(case when RightsType = 0 then AllocatedRevenue else 0 end)
	from DdexAdjConsolidatedDetail
	where DdexReportId = @ddexReportId

	update DdexAdjConsolidatedDetail
	set AllocatedRevenue = AllocatedRevenue * (@SumFullPer / @SumFinalPer)
	where DdexReportId = @ddexReportId
		and RightsType = 1

	update DdexAdjConsolidatedDetail
	set AllocatedRevenue = AllocatedRevenue * (@SumFullMec / @SumFinalMec)
	where DdexReportId = @ddexReportId
		and RightsType = 0
end