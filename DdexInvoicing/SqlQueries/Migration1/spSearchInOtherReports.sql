--select * from DdexReport where id = 477

/*
update t3
set t3.Status = 0
--select * 
from DdexReport t1
	join CcidInvoice t2 on t1.Id = t2.ddexReportId
	join CcidInFile t3 on t2.Id = t3.ccidInvoiceId
where t1.id = 477
*/

--select * into #IdentBacklog477 from IdentBacklog where DdexReportId = 477
--select t2.* into #IdentMw477 from IdentBacklog t1 join IdentMw t2 on t1.mwId = t2.Id  where DdexReportId = 477

--select * from #IdentBacklog477

-- >>>>>>>>>>>>> —Ã¿–“
-- Õ≈ «Õ¿…ƒ≈Õ≤ ” «¬≤“≤ ¿À≈ «Õ¿…ƒ≈Õ≤ ” ≤Õÿ»’ «¬≤“¿’ ƒÀﬂ œ¿–» Õ¿«¬¿-¬» ŒÕ¿¬≈÷‹ (—Ã¿–“)
drop table if exists #IdentMwObjId
select
	  t2.Id						as MwId
	, t2.Title					as Title
	, t2.DisplayArtistName		as Performer
	, max(t3.ObjId)				as ObjId
into #IdentMwObjId
from IdentBacklog t1
	join IdentMw t2 on t1.mwId = t2.Id
	join IdentMw t3 on t2.Title = t3.Title 
		and t2.DisplayArtistName = t3.DisplayArtistName
where isnull(t2.ObjId, 0) = 0
	and isnull(t3.ObjId, 0) <> 0
	and t1.DdexReportId = 477
group by t2.Id, t2.Title, t2.DisplayArtistName

update t2
set t2.ObjId = t1.ObjId, t2.Status = 2
--select *
from #IdentMwObjId t1
	join IdentMw t2 on t1.MwId = t2.Id

-- >>>>>>>>>>>>> WID
-- Õ≈ «Õ¿…ƒ≈Õ≤ ” «¬≤“≤ ¿À≈ «Õ¿…ƒ≈Õ≤ ” ≤Õÿ»’ «¬≤“¿’ ƒÀﬂ œ¿–» Õ¿«¬¿-¬» ŒÕ¿¬≈÷‹
drop table if exists #IdentMwWic
select
	  t2.Id						as MwId
	, t2.Title					as Title
	, t2.DisplayArtistName		as Performer
	, max(t3.Wic)				as Wic
into #IdentMwWic
from IdentBacklog t1
	join IdentMw t2 on t1.mwId = t2.Id
	join IdentMw t3 on t2.Title = t3.Title 
		and t2.DisplayArtistName = t3.DisplayArtistName
where isnull(t2.Wic, 0) = 0
	and isnull(t3.Wic, 0) <> 0
	and t1.DdexReportId = 477
group by t2.Id, t2.Title, t2.DisplayArtistName

update t2
set t2.Wic = t1.Wic, t2.Status = 2
--select *
from #IdentMwWic t1
	join IdentMw t2 on t1.MwId = t2.Id 

	/*

drop table if exists #IdentMwJoined
select
	  t1.ResourceTitle			as ResourceTitleSrc
	, t2.ResourceTitle			as ResourceTitleTgt
	, t1.Title					as TitleSrc
	, t2.Title					as TitleTgt
	, t1.ComposerAuthor			as ComposerAuthorSrc
	, t2.ComposerAuthor			as ComposerAuthorTgt
	, t1.DisplayArtistName		as DisplayArtistNameSrc
	, t2.DisplayArtistName		as DisplayArtistNameTgt
	, t1.ISWC					as ISWCSrc
	, t2.ISWC					as ISWCTgt
	, t2.ObjId
into #IdentMwJoined
from #IdentMw477 t1
	left join IdentMw t2 on t1.Title = t2.Title and t1.DisplayArtistName = t2.DisplayArtistName
where isnull(t2.ObjId, 0) <> 0
order by t1.Title, t1.DisplayArtistName

select
	  TitleSrc
	, DisplayArtistNameSrc
	, ResourceTitleTgt
	, ComposerAuthorSrc
	, ComposerAuthorTgt
	, ISWCTgt
	, ObjId
from #IdentMwJoined
order by TitleSrc, DisplayArtistNameSrc

*/