use RadioStationReports
go

create or alter procedure spAutoSearchInWid
	@reportId int
as
begin

-- опн бяъй бхоюднй - ъйын ╙ меб╡донб╡дм╡ярэ 
update t1
set t1.FoundIn = 'W'
from ReportLines t0
	join Works t1 on t0.WorkId = t1.Id
	join SocWid..WidTitle t2 on t1.Wic = t2.Wic
where FoundIn is null
	and t1.Wic is not null
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

-- гюярнянбс╙лн пегскэрюр
update t1
set
	  t1.FoundIn = 'W'
	, t1.Wic = t2.Wic
from Works t1
	join #ResWid t2 on t1.Id = t2.WorkId

end
go