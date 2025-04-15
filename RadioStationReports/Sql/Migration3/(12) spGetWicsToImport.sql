use RadioStationReports
go

create or alter procedure spGetWicsToImport
	@reportId int
as
begin
	
-- йнпецс╙лн йндх б╡д мю нямнб╡ йнд╡б ISWC
; with Iswcs as (
	select t1.Wic, t1.Iswc
	from Works t1
		left join SocWid..widTitle t2 on t1.Wic = t2.Wic
	where isnull(t1.Wic, 0) <> 0
		and t2.Wic is null
		and isnull(t1.Iswc, '') <> ''
)
update t1
set t1.Wic = t2.Wic
from Iswcs t1
	join SocWid..WidIswc t2	on t1.Iswc = t2.Iswc

-- яйхдю╙лн б мск меб╡пм╡ йндх б╡д
; with Wics as (
	select t1.Wic
	from Works t1
		left join SocWid..widTitle t2 on t1.Wic = t2.Wic
	where isnull(t1.Wic, 0) <> 0
		and t2.Wic is null
)
update t1
set t1.Wic = null
from Wics t1

-- бхахпю╙лн онрп╡ам╡ йндх б╡д
select t2.Wic
from ReportLines t1
	join Works t2 on t1.WorkId = t2.Id
where isnull(t2.Wic, 0) <> 0
	and isnull(t2.ObjId, 0) = 0
	and t1.ReportId = @reportId
end