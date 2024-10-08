use MediaService
go

create or alter view vWidSrQuery
as
select 
	  t1.Wic				as Wic
	, t1.AltTtl				as AltTtl
	, t2.PerfArtistFstName	as PerfArtistFstName
	, t2.PerfArtistLstName	as PerfArtistLstName
	, t4.FstName			as AuthorFstName
	, t4.LstName			as AuthorLstName
from SocWid..WidAltTtl t1
	left join SocWid..WidArtist t2	on t1.Wic = t2.Wic 
	left join SocWid..widIntrPty t3 on t2.Wic = t3.Wic
	join SocWid..IpiName t4			on t3.IpNameNr = t4.IpNameNr
go
