use MediaService
go

create or alter view vWidWrkShareSum
as
select
	  Wic as Wic
	, sum(case when RightType = 'PER' then Shares else 0 end) as SharePer
	, sum(case when RightType = 'MEC' then Shares else 0 end) as ShareMec
from SocWid..WidShares
group by Wic
go
