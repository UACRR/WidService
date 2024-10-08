use MediaService
go

create or alter view vWidSrObjectListQuery
as
with
-- ISWC
Iswcs as (
	select 
		  Wic				Wic
		, max(PrefIswc)		iswc
	from SocWid..widIswc
	group by Wic
),
-- ¬» ŒÕ¿¬÷≤
Perfomers as (
	select
		  Wic
		, left(
			string_agg (convert(varchar(max), trim(PerfArtistFstName + ' ' + PerfArtistLstName)), ', ')
			, 254
		) Performers
	from SocWid..WidArtist
	group by Wic
),
-- ¿¬“Œ–»
AuthorSingle as (
	select distinct 
		  t1.Wic
		, trim(t2.FstName + ' ' + t2.Name) Name
	from SocWid..widIntrPty t1
		join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
	where IpRole in ('C', 'CA', 'A')
),
Authors as (
	select
		  Wic
		, left(
			string_agg (convert(varchar(max), Name), ', ')
			, 100
		) Authors
	from AuthorSingle
	group by Wic
),
-- œ–Œ÷≈Õ“» œ”¡À≤◊ ¿
RatePer as (
	select
		  Wic
		, sum(Shares) ratePer
	from SocWid..widShares
	where RightType = 'PER'
	group by Wic
),
-- œ–Œ÷≈Õ“» Ã≈’¿Õ≤ ¿
RateMec as (
	select
		  Wic
		, sum(Shares) rateMec
	from SocWid..widShares
	where RightType = 'MEC'
	group by Wic
)
select --top 100 
	  t1.Wic		as Wic
	, t2.iswc		as iswc
	, t1.WrkTtl		as name
	, t4.Authors	as author
	, t3.Performers as performer
	, t1.MwDistrCat	as genreName
	, t5.rateMec	as rateTotalMEC
	, t6.ratePer	as rateTotalPER
from 
	SocWid..widTitle t1
	left join Iswcs		 t2	on t1.Wic = t2.Wic
	left join Perfomers	 t3	on t1.Wic = t3.Wic
	left join Authors	 t4	on t1.Wic = t4.Wic
	left join RateMec	 t5	on t1.Wic = t5.Wic
	left join RatePer	 t6	on t1.Wic = t6.Wic
go


