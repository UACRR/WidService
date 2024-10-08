use MediaService
go

create or alter view  vTsk10_WIDObjects
as
select
	  t1.Wic as WIC
	, t5.ISWC as ISWC
	, t1.WrkTtl as name
	, t1.MwDistrCat as genreName
	, t2.Authors as author
	, t3.Performers as performer
	, t4.ShareMec as rateTotalMEC
	, t4.SharePer as rateTotalPER
from SocWid..widTitle t1
	left join vWidWrkAuthorAgg t2 on t1.Wic = t2.Wic
	left join vWidWrkPerformerAgg t3 on t1.Wic = t3.Wic
	left join vWidWrkShareSum t4 on t1.Wic = t4.Wic
	left join vWidWrkPrefIswc t5 on t1.Wic = t5.Wic
go
