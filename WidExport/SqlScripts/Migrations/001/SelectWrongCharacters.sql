drop table if exists #WrongCharRecs
; with WrongCharRecs as (
	select t3.Id as WiaId
	, t3.WrkTtl as WiaWrkTtl
	, t4.WrkTtlRef as AckWrkTtl
	, 'Wrong E' as Type
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where SubmRecType = 'WIA' and t2.Id = 15 and t3.WrkTtl like '%Å%'
union
select t3.Id as WiaId
	, t3.WrkTtl as WiaWrkTtl
	, t4.WrkTtlRef as AckWrkTtl
	, 'Wrong #' as Type
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where SubmRecType = 'WIA' and t2.Id = 15 and t3.WrkTtl like '%¹%'
union
select t3.Id as WiaId
	, t3.WrkTtl as WiaWrkTtl
	, t4.WrkTtlRef as AckWrkTtl
	, 'Wrong «' as Type
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where SubmRecType = 'WIA' and t2.Id = 15 and t3.WrkTtl like '%«%'
union
select t3.Id as WiaId
	, t3.WrkTtl as WiaWrkTtl
	, t4.WrkTtlRef as AckWrkTtl
	, 'Wrong »' as Type
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where SubmRecType = 'WIA' and t2.Id = 15 and t3.WrkTtl like '%»%'
union
select t3.Id as WiaId
	, t3.WrkTtl as WiaWrkTtl
	, t4.WrkTtlRef as AckWrkTtl
	, 'Wrong …' as Type
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where SubmRecType = 'WIA' and t2.Id = 15 and t3.WrkTtl like '%…%'
union
select t3.Id as WiaId
	, t3.WrkTtl as WiaWrkTtl
	, t4.WrkTtlRef as AckWrkTtl
	, 'Wrong ’' as Type
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where SubmRecType = 'WIA' and t2.Id = 15 and t3.WrkTtl like '%’%'
union
select t3.Id as WiaId
	, t3.WrkTtl as WiaWrkTtl
	, t4.WrkTtlRef as AckWrkTtl
	, 'Wrong –' as Type
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where SubmRecType = 'WIA' and t2.Id = 15 and t3.WrkTtl like '%–%'
union
select t3.Id as WiaId
	, t3.WrkTtl as WiaWrkTtl
	, t4.WrkTtlRef as AckWrkTtl
	, 'Wrong   (inivisible)' as Type
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where SubmRecType = 'WIA' and t2.Id = 15 and t3.WrkTtl like '% %'
union
select t3.Id as WiaId
	, t3.WrkTtl as WiaWrkTtl
	, t4.WrkTtlRef as AckWrkTtl
	, 'Wrong ‘' as Type
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where SubmRecType = 'WIA' and t2.Id = 15 and t3.WrkTtl like '%‘%'
)
select *
into #WrongCharRecs
from WrongCharRecs
order by WiaWrkTtl, AckWrkTtl

; with WiaRecIds as (
	select distinct WiaId from #WrongCharRecs
)
select t3.Id, *
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where t3.Id in (select WiaId from WiaRecIds where WiaId = t3.Id)
	and t2.ErrCondNr not in (6, 8, 9, 10, 12, 13, 35)
order by t3.Id, t2.ErrCondNr

; with DistErr as (
	select  distinct RespFileErr from RespFileErr-- where RespFileErr not in (6, 8, 9, 10, 12, 13, 35)
)
select * from DistErr t1 join RespFileErrCode t2 on t1.RespFileErr = t2.Id order by ErrCondNr

select distinct t2.Id, t1.SubmRecType, t2.MsgTxt  
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	--join RecAlt t3 on t1.SubmRecId = t3.id
--order by t1.SubmRecType
where t1.IsFixed <> 1 and NeedNotFix <> 1
order by SubmRecType

update RespFileErr set IsFixed = 0 where IsFixed is null

select t3.WrkTtl as WiaWrkTtl
	, t4.WrkTtlRef as AckWrkTtl
	, 'Wrong #' as Type
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.Id
	join RecAck t4 on t3.TransSeqNr = t4.TransSeqNr
where SubmRecType = 'WIA' and t2.Id = 15

select * from RecAck where Status = 'RJ'

