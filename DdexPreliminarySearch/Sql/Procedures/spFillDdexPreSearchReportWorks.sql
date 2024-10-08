use Ddex_Mw_Search
go

create or alter procedure spFillDdexPreSearchReportWorks (
	@ddexReportId int, @blockSeqNr int
)
as
begin

delete t1
from DdexPreSearchFoundWorks t1
	join DdexPreSearchReportWorks t2 on t1.DdexPreSearchReportWorkId = t2.Id
where t2.DdexReportId = @ddexReportId and t2.BlockSeqNr = @blockSeqNr
delete from DdexPreSearchReportWorks where DdexReportId = @ddexReportId and BlockSeqNr = @blockSeqNr

; with AllWorks as (
	select
		  @ddexReportId as DdexReportId
		, @blockSeqNr  as BlockSeqNr
		, t2.Id as MwId
		, t2.ResourceTitle as Album
		, t2.Title as Name
		, t2.ComposerAuthor as Authors
		, t2.DisplayArtistName as Performers
	from Ddex..IdentBacklog t1
		join Ddex..IdentMw t2 on t1.mwId = t2.Id
	where ddexReportId = @ddexReportId
		and isnull(ISWC, '') = ''
		and isnull(wic, 0) = 0
		and isnull(objid, 0) = 0
	order by t1.NetRevenue desc
	offset (@blockSeqNr - 1) * 1000 rows fetch next 1000 rows only
)
insert DdexPreSearchReportWorks (
	  DdexReportId
	, BlockSeqNr
	, MwId
	, Album
	, Name
	, Authors
	, Performers
	, AlbumT
	, NameT
	, AuthorsT
	, PerformersT
)
select distinct
	  DdexReportId
	, BlockSeqNr
	, MwId
	, Album
	, Name
	, Authors
	, Performers
	, ''
	, ''
	, ''
	, ''
from AllWorks

update DdexPreSearchReportWorks set Album = '' where Album is null or Album in ('-')
update DdexPreSearchReportWorks set Name = '' where Name is null or Name in ('-')
update DdexPreSearchReportWorks set Authors = '' where Authors is null or Authors in ('-')
update DdexPreSearchReportWorks set Performers = '' where Performers is null or Performers in ('-')

delete from DdexPreSearchReportWorks where Album = '' and Name = ''

end
go

--exec spFillDdexPreSearchReportWorks 115, 10
go

--select * from DdexPreSearchReportWorks order by MwId
go
