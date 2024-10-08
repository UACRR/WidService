use MediaService
go

create or alter view vWidPrefIswc
as
select
	  Wic			as Wic
	, max(PrefIswc)	as Iswc
from SocWid..widIswc
group by Wic
go

-- select top 100 * from vWidPrefIswc