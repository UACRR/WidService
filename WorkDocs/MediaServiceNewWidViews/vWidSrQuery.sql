use MediaService
go

create or alter view vWidSrQuery
as
select 
	  t1.Wic				as Wic
	, t1.WrkTtl				as WrkTtl
	, t2.AltTtl				as AltTtl
	, t3.PerfArtistFstName	as PerfArtistFstName
	, t3.PerfArtistLstName	as PerfArtistLstName
	, t5.FstName			as AuthorFstName
	, t5.Name				as AuthorLstName
from SocWid..WidTitle t1
	left join SocWid..WidAltTtl t2 on t1.Wic = t2.Wic
	left join SocWid..WidArtist t3 on t1.Wic = t3.Wic
	left join SocWid..widIntrPty t4 on t1.Wic = t4.Wic
	left join SocIpi..IpiName t5 on t4.IpNameNr = t5.IpNameNr
go

-- select top 100 * from vWidSrQuery


