declare @objId int  = 8058

drop table if exists #alt

select 
	  name as AltTtl
	, 'OT' as TtlType
into #alt
from MediaService..ObjectRight
where ObjId = @objId

insert #alt (
	  AltTtl
	, TtlType
)
select distinct
	  name as AltTtl
	, 'ET' as TtlType
from MediaService..SeekObject
where codeI = 1
	and ObjId = @objId
	and name <> (select name from #alt)

select 
	  AltTtl
	, TtlType
from #alt