use RadioStationReports
go

create or alter procedure spAutoSearchInMs
	@reportId int
as
begin

-- опн бяъй бхоюднй - ъйын ╙ меб╡донб╡дм╡ярэ 
update t1
set t1.FoundIn = 'M'
from ReportLines t0
	join Works t1 on t0.WorkId = t1.Id
	join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
where FoundIn is null
	and t1.ObjId is not null
	and t0.ReportId = @reportId

-- бхапю╙лн ме гмюидем╡ рбнпх яепед бя╡у
drop table if exists #NotFoundWorks
select
	  t2.Id as WorkId
	, MediaService.dbo.TransliterateUkrToEng(t2.Name) as Name
	, MediaService.dbo.TransliterateUkrToEng(t2.Performers) as Performers
into #NotFoundWorks
from ReportLines t1
	join Works t2 on t1.WorkId = t2.Id
where FoundIn is null
	and t1.ReportId = @reportId

-- пегскэрюр оньсйс
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

-- гюярнянбс╙лн пегскэрюр

update t1
set
	  t1.FoundIn = 'M'
	, t1.ObjId = t2.ObjId
from Works t1
	join #ResMs t2 on t1.Id = t2.WorkId

end
go