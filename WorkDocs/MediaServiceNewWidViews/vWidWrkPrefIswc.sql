use MediaService
go

create or alter view vWidWrkPrefIswc
as
select
	  Wic as Wic
	, max(PrefIswc) as ISWC
from SocWid..WidIswc
group by Wic
go
