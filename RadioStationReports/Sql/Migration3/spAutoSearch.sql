use RadioStationReports
go

create or alter procedure spAutoSearch
as
begin

update t1
set t1.FoundIn = 'M'
from Works t1
	join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
where FoundIn is null
	and t1.ObjId is not null

drop table if exists #NotFoundWorks
select 
	  Id as WorkId
	, MediaService.dbo.TransliterateUkrToEng(Name) as Name
	, MediaService.dbo.TransliterateUkrToEng(Performers) as Performers
into #NotFoundWorks
from Works
where FoundIn is null

drop table if exists #ResMs
; with TmpFoundByName as (
	select distinct t1.WorkId, t2.ObjId, t1.Performers
	from #NotFoundWorks t1
		join MediaService..SeekObject t2 on
				t2.codeI = 1
			and t1.Name = t2.Name
)
select t1.WorkId, t1.ObjId
into #ResMs
from TmpFoundByName t1
	join MediaService..SeekObject t2 on
		    t2.codeI = 2
		and t1.ObjId = t2.objId
		and t1.Performers = t2.Name

; with TmpDups as (
	select WorkId
	from #ResMs
	group by WorkId
	having count(*) > 1
)
delete t1
from #ResMs t1
	join TmpDups t2 on t1.WorkId = t2.WorkId

select t2.Name, t3.Name
from #ResMs t1
	join Works t2 on t1.WorkId = t2.Id
	join MediaService..ObjectRight t3 on t1.ObjId = t3.ObjId
where t2.Name <> t3.Name

delete t1
from #NotFoundWorks t1
	join #ResMs t2 on t1.WorkId = t2.WorkId

-- ===================== WID
drop table if exists #ResWid
; with TmpFoundByName as (
	select distinct t1.WorkId, t2.Wic, t1.Performers
	from #NotFoundWorks t1
		join SocWid..WidTitle t2 on	t1.Name = t2.WrkTtl
	union
	select distinct t1.WorkId, t2.Wic, t1.Performers
	from #NotFoundWorks t1
		join SocWid..widAltTtl t2 on t1.Name = t2.AltTtl
)
select t1.WorkId, t1.Wic
into #ResWid
from TmpFoundByName t1
	join SocWid..WidArtist t2 on
		    t1.Wic = t2.Wic
		and t1.Performers = trim(concat(t2.PerfArtistLstName, ' ', t2.PerfArtistFstName))
union
select t1.WorkId, t1.Wic
from TmpFoundByName t1
	join SocWid..WidArtist t2 on
		    t1.Wic = t2.Wic
		and t1.Performers = trim(concat(t2.PerfArtistFstName, ' ', t2.PerfArtistLstName))

; with TmpDups as (
	select WorkId
	from #ResWid
	group by WorkId
	having count(*) > 1
)
delete t1
from #ResWid t1
	join TmpDups t2 on t1.WorkId = t2.WorkId

select t1.WorkId, t1.WIc, t2.Name, t2.Performers, t3.WrkTtl
from #ResWid t1
	join Works t2 on t1.WorkId = t2.Id
	join SocWid..WidTitle t3 on t1.Wic = t3.Wic
	left join MediaService..RepMSWIC t4 on t1.Wic = t4.Wic
order by t2.Name

select
	  row_number() over (order by t1.Wic)
	, t1.Wic
from #ResWid t1
	left join MediaService..RepMSWIC t2 on t1.Wic = t2.Wic
where t2.Wic is null

exec MediaService..spImportWorkFromWid 

end
go