-- A WIA WITH THE SAME ISWC AS AN EXISTING WORK FROM THE SAME SOCIETY WILL BE REJECTED. (TR)
declare @ErrId int = 14
update RespFileErr set NeedNotFix = 1 where RespFileErr = @ErrId

/*
select *
from RespFileErr t1
	join RecWia t2 on t1.SubmRecId = t2.Id
where IsFixed = 0 and RespFileErr = @ErrId

select *
from MediaService..ObjectRight
where ObjId = 5634

select *
from SocWid..widIswc t1
	join SocWid..widTitle t2 on t1.Wic = t2.Wic
	join SocWid..widIntrPty t3 on t2.Wic = t3.Wic
	join SocIpi..IpiName t4 on t3.IpNameNr = t4.IpNameNr
where Iswc = 'T9214309850'


select *
from SocWidSubmit..WidSubmGroupWork t1
	join MediaService..MediaTrack t2 on t1.ObjId = t2.objId
where isnull(t2.Iswc, '') <> ''

use MediaService
SELECT      c.name  AS 'ColumnName'
            ,t.name AS 'TableName'
FROM        sys.columns c
JOIN        sys.tables  t   ON c.object_id = t.object_id
WHERE       c.name = 'ISWC'
ORDER BY    TableName
            ,ColumnName;
	*/