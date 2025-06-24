use Ddex
go

create or alter procedure spSetReportsTerritory
as
begin
	; with Terr as (
		select DdexReportId, value as Territory
		from DdexReportProcessingData
			cross apply string_split(DataValue, '_')
		where DataName = 'DdexFile1'
			and len(value) = 2
	)
	update t1
	set t1.Territory = t2.Territory
	from DdexReport t1
		join Terr t2 on t1.Id = t2.DdexReportId
	where t1.Territory is null
end
go

exec spSetReportsTerritory