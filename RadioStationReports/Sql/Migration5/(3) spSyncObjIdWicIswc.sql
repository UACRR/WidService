use RadioStationReports
go

create or alter procedure spSyncObjIdWicIswc
as
begin

-- гюонбмч╙лн йндх б╡д
drop table if exists #MissingWics
select t2.ObjId
into #MissingWics
from ReportLines t1
	join Works t2 on t1.WorkId = t2.Id
where isnull(t2.ObjId, 0) <> 0
	and isnull(t2.Wic, 0) = 0

update t3
set t3.Wic = t2.Wic
from #MissingWics t1
	join MediaService..RepMSWIC t2 on t1.ObjId = t2.ObjId
	join Works t3 on t1.ObjId = t3.ObjId

update t3
set t3.Wic = t2.Wic
from #MissingWics t1
	join SocWid..widSubmission t2 on 
			concat('MS', t1.ObjId) = t2.SocWorkCde
		and t2.SocCde = 140
	join Works t3 on t1.ObjId = t3.ObjId
where isnull(t3.Wic, 0) = 0

drop table #MissingWics

-- гюонбмч╙лн йндх ялюпр
drop table if exists #MissingObjIds
select t2.Wic
into #MissingObjIds
from ReportLines t1
	join Works t2 on t1.WorkId = t2.Id
where isnull(t2.Wic, 0) <> 0
	and isnull(t2.ObjId, 0) = 0

update t3
set t3.Wic = t2.Wic
from #MissingObjIds t1
	join MediaService..RepMSWIC t2 on t1.Wic = t2.Wic
	join Works t3 on t1.Wic = t3.Wic

update t3
set t3.ObjId = substring(t2.SocWorkCde, 3, len(t2.SocWorkCde) - 2)
from #MissingObjIds t1
	join SocWid..widSubmission t2 on 
			t1.Wic = t2.Wic
		and t2.SocCde = 140
	join Works t3 on t1.Wic = t3.Wic
where isnull(t3.ObjId, 0) = 0

drop table #MissingObjIds

-- гюонбмч╙лн йндх ISWC г╡ ялюпр
drop table if exists #MissingIswcsForMs
select t2.ObjId
into #MissingIswcsForMs
from ReportLines t1
	join Works t2 on t1.WorkId = t2.Id
where isnull(t2.ObjId, 0) <> 0
	and isnull(t2.Iswc, '') = ''

update t3
set t3.Iswc = left(t2.Iswc, 11)
from #MissingIswcsForMs t1
	join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
	join Works t3 on t1.ObjId = t3.ObjId
where isnull(t2.Iswc, '') <> ''

drop table #MissingIswcsForMs

-- гюонбмч╙лн йндх ISWC г╡ б╡д
drop table if exists #MissingIswcsForWid
select t2.Wic
into #MissingIswcsForWid
from ReportLines t1
	join Works t2 on t1.WorkId = t2.Id
where isnull(t2.Wic, 0) <> 0
	and isnull(t2.Iswc, '') = ''

update t3
set t3.Iswc = t2.PrefIswc
from #MissingIswcsForWid t1
	join SocWid..WidIswc t2 on t1.Wic = t2.Wic
	join Works t3 on t1.Wic = t3.Wic
where isnull(t2.PrefIswc, '') <> ''

drop table #MissingIswcsForWid


end