select 
	  t2.Id
	, t1.SubmRecType
	, t2.MsgTxt
	, t3.WrkTtl
	, cast(substring(t3.SubmWrkNr, 3, 1000) as int) ObjId
from RespFileErr t1
	join RespFileErrCode t2 on t1.RespFileErr = t2.Id
	join RecWia t3 on t1.SubmRecId = t3.id
--order by t1.SubmRecType
where t2.Id = 20
order by t2.Id

select *
from WidSubmGroupWorkShare
where ObjId = 875584

; with ObjIds as (
	select 
		  cast(substring(t3.SubmWrkNr, 3, 1000) as int) ObjId
	from RespFileErr t1
		join RespFileErrCode t2 on t1.RespFileErr = t2.Id
		join RecWia t3 on t1.SubmRecId = t3.id
	where t2.Id = 21
)
select distinct IpNameNr
from WidSubmGroupWorkShare t1
	join ObjIds t2 on t1.ObjId = t2.ObjId
order by t1.ObjId

select * from SocIpi..IpiName where IpNameNr in ( 
	  460882050
	, 725138453
	, 870867004
	, 1079186133
	, 1184921245
)

select * from WidSubmGroupWorkShare where aggrinvert is not null order by IpNameNr