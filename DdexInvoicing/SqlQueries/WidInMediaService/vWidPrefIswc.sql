use MediaService
go

drop view if exists vWidPrefIswc
go

create view vWidPrefIswc
as
select
	  Wic			as Wic
	, max(PrefIswc)	as Iswc
from SocWid..widIswc
group by Wic
go

-- select top 100 * from vWidPrefIswc