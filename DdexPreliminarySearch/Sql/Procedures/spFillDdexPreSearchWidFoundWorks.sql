use Ddex_Mw_Search
go

create or alter procedure spFillDdexPreSearchWidFoundWorks
	  @ddexReportId int
	, @blockSeqNr int
as
begin

drop table if exists #Found
select t1.Id, t2.Wic, 'NT' as SourceCol, 'WID' as TargetDb, 'Main' as TargetTbl
into #Found
from DdexPreSearchReportWorks t1
	join SocWid..widTitle t2 on t1.NameT = t2.WrkTtl
where t1.DdexReportId = @ddexReportId
	and t1.BlockSeqNr = @blockSeqNr
	and t1.NameT <> ''

insert #Found
select t1.Id, t2.Wic, 'AT' as SourceCol, 'WID' as TargetDb, 'Main' as TargetTbl
from DdexPreSearchReportWorks t1
	join SocWid..widTitle t2 on t1.AlbumT = t2.WrkTtl
where t1.DdexReportId = @ddexReportId
	and t1.BlockSeqNr = @blockSeqNr
	and t1.AlbumT <> ''
	and t2.Wic not in (select Wic from #Found tt where tt.id = t1.Id)

insert #Found
select t1.Id, t2.Wic, 'NT' as SourceCol, 'WID' as TargetDb, 'Alt' as TargetTbl
from DdexPreSearchReportWorks t1
	join SocWid..widAltTtl t2 on t1.NameT = t2.AltTtl
where t1.DdexReportId = @ddexReportId
	and t1.BlockSeqNr = @blockSeqNr
	and t1.NameT <> ''
	and t2.Wic not in (select Wic from #Found tt where tt.id = t1.Id)

insert #Found
select t1.Id, t2.Wic, 'AT' as SourceCol, 'WID' as TargetDb, 'Alt' as TargetTbl
from DdexPreSearchReportWorks t1
	join SocWid..widAltTtl t2 on t1.AlbumT = t2.AltTtl
where t1.DdexReportId = @ddexReportId
	and t1.BlockSeqNr = @blockSeqNr
	and t1.AlbumT <> ''
	and t2.Wic not in (select Wic from #Found tt where tt.id = t1.Id)

;with AuthorDistinct as (
	select 
		  t1.Wic												as Wic
		, trim(concat(trim(t2.FstName), ' ', trim(t2.Name)))	as Name
	from SocWid..widIntrPty t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where t1.IpRole in ('C', 'A', 'CA')
),
Authors as (
	select
		  Wic											 as Wic
		, string_agg(convert(varchar(max), Name), ', ')	 as Authors
	from AuthorDistinct
	group by Wic
),
PerformerDistinct as (
	select 
		  Wic																  as Wic
		, trim(concat(trim(PerfArtistFstName), ' ', trim(PerfArtistLstName))) as Name
	from SocWid..widArtist
),
Performers as (
	select
		  Wic											 as Wic
		, string_agg(convert(varchar(max), Name), ', ')	 as Performers
	from PerformerDistinct
	group by Wic
)

insert DDEX_MW_SEARCH..DdexPreSearchFoundWorks (
      DdexPreSearchReportWorkId
    , Name
    , Authors
    , Performers
    , SourceCol
    , TargetDb
    , TargetTbl
    , FoundId
)
select 
	  t1.Id as DdexPreSearchReportWorkId
	, t2.WrkTtl
	, left(t3.Authors, 1000)
	, left(t4.Performers, 1000)
	, t1.SourceCol
	, t1.TargetDb
	, t1.TargetTbl
	, t1.Wic
from #Found t1
	join SocWid..widTitle t2 on t1.Wic = t2.Wic
	join Authors t3 on t1.Wic = t3.Wic
	join Performers t4 on t1.Wic = t4.Wic

end
go

exec spFillDdexPreSearchWidFoundWorks 115, 10
go

