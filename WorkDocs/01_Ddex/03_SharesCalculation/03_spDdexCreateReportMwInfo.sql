use Ddex
go

create or alter procedure spDdexCreateReportMwInfo (
	@DdexReportId int
)
as
begin

delete DdexReportMwInfo where DdexReportId = @DdexReportId

; with Works as (
	select distinct 
		  case when t2.Wic = 0 then null else t2.Wic end		as WIc
		, case when t2.ObjId = 0 then null else t2.ObjId end	as ObjId
	from IdentBacklog t1
		join IdentMw t2 on t1.mwId = t2.Id
	where t1.DdexReportId = @DdexReportId
)
insert DdexReportMwInfo (
	  DdexReportId
	, Wic
	, ObjId
)
select 
	  @DdexReportId      DdexReportId
	, Wic	 Wic
	, ObjId	 ObjId
from Works

-- >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> мюгбх рбнп╡б

update t1  
set 
	t1.Title = left(t2.WrkTtl, 100)
from DdexReportMwInfo t1 
	join SocWid..widTitle t2 on t1.Wic = t2.Wic

update t1  
set 
	t1.Title = left(t2.name, 100)
from DdexReportMwInfo t1 
	join MediaService..ObjectRight t2 on t1.objId = t2.objId

-- >>>>>>>>>>>>>>>>>>>>>>>>> бхйнмюбж╡ г WID
 ; with Perfomer as (
	select
		  Wic
		, left(
			  string_agg (convert(varchar(max), trim(PerfArtistFstName + ' ' + PerfArtistLstName)), ', ')
			, 100
		) Performer
	from SocWid..WidArtist
	group by Wic
)
update t1  
set t1.Performers = t2.Performer
from DdexReportMwInfo t1 
	join Perfomer t2 on t1.Wic = t2.Wic 

-- >>>>>>>>>>>>>>>>>>>>>>>>> йнлонгхрнпх г WID
; with AuthorMusicSingle as (
	select distinct 
		  t1.Wic
		, trim(t2.FstName + ' ' + t2.Name) Name
	from SocWid..widIntrPty t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where IpRole in ('C', 'CA')
),
AuthorMusic as (
	select
		  Wic
		, left(
			string_agg (convert(varchar(max), Name), ', ')
			, 100
		) AuthorMusic
	from AuthorMusicSingle
	group by Wic
)
update t1  
set t1.MusicAuthors = t2.AuthorMusic
from DdexReportMwInfo t1 
   join AuthorMusic t2 on t1.Wic = t2.Wic

-- >>>>>>>>>>>>>>>>>>>>>>>>> онерх г WID
; with AuthorTextSingle as (
	select distinct
		  t1.Wic
		, trim(t2.FstName + ' ' + t2.Name) Name
	from SocWid..widIntrPty t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where IpRole in ('A', 'CA')
),
AuthorText as (
	select
		  Wic
		, left(
			string_agg (convert(varchar(max), Name), ', ')
			, 100
		) AuthorText
	from AuthorTextSingle
	group by Wic
)
update t1  
set t1.LyricsAuthors = t2.AuthorText
from DdexReportMwInfo t1 
   join AuthorText t2 on t1.Wic = t2.Wic 
 
-- >>>>>>>>>>>>>>>>>>>>>>>>> йнлонгхрнпх, юбрнпх ╡ онерх г MEDIA SERVICE
update t1  
set 
	  t1.Performers		= left(t2.performers	, 100)
    , t1.MusicAuthors	= left(t2.composers		, 100)
	, t1.LyricsAuthors	= left(t2.lyrics		, 100)
from DdexReportMwInfo t1 
	join MediaService..MediaTrack t2 on t1.objId = t2.objId

	-- >>>>>>>>>>>>>>>>>>>>>>>>> бхдюкъ╙лн гюохях, дкъ ъйху ме гмюидемн ╡мтнплюж╡╞
delete DdexReportMwInfo
where DdexReportId = @DdexReportId
	and Title is null

end -- procedure

go