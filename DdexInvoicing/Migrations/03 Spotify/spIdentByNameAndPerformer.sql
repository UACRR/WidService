drop procedure if exists spIdentByNameAndPerformer
go

create procedure spIdentByNameAndPerformer (
	@ddexReportId int
) as
begin

drop table if exists #TmpSpotifyMw

select
	  t2.Id
	, t2.ResourceTitle
	, t2.Title
	, t2.ComposerAuthor
	, t2.DisplayArtistName
	, t2.ISWC
	, t2.WIC
	, t2.objId
	, t2.IdentifiedTitle
	, t1.NetRevenue
	, t2.status
into #TmpSpotifyMw
from IdentBacklog t1
	join IdentMw t2 on t1.mwId = t2.Id
where ddexReportId = @ddexReportId
	  and t2.status <> 2

; with ObjectRightUnique as (
	select name, performer, count(*)  cnt
	from  MediaService..ObjectRight
	group by name, performer
	having count(*) = 1
)
update t1
set 
	  t1.ObjId = t3.ObjId
	, t1.status = 2
from #TmpSpotifyMw t1
	join ObjectRightUnique t2 on t1.Title = t2.name and t1.DisplayArtistName = t2.performer
	join MediaService..ObjectRight t3  on t1.Title = t3.name and t1.DisplayArtistName = t3.performer

; with wObjectUnique as (
	select name, performers, count(*) cnt
	from  WID_IPI..wObject
	group by name, performers
	having count(*) = 1
)
update t1
set 
	  t1.WIC = t3.WIC
	, t1.status = 2
from #TmpSpotifyMw t1
	join wObjectUnique t2 on t1.Title = t2.name and t1.DisplayArtistName = t2.performers
	join WID_IPI..wObject t3  on t1.Title = t3.name and t1.DisplayArtistName = t3.performers
where t1.status <> 2

update t1
set
	  t1.objId = t2.objId
	, t1.WIC = t2.WIC
	, t1.status = t2.status
from IdentMw t1
	join #TmpSpotifyMw t2 on t1.Id = t2.Id
where t2.status = 2

--select count(*) from #TmpSpotifyMw
--select count(*) from #TmpSpotifyMw where status = 2
--select sum(NetRevenue) from #TmpSpotifyMw
--select sum(NetRevenue) from #TmpSpotifyMw where status = 2

drop table if exists #TmpSpotifyMw

end

go