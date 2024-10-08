declare @objId int  = 8058

drop table if exists #per

select 
	  performer as PerfArtistLstName
into #per
from MediaService..ObjectRight
where ObjId = @objId

insert #per (
	PerfArtistLstName
)
select distinct
	  name as PerfArtistLstName
from MediaService..SeekObject
where codeI = 2
	and ObjId = @objId
	and name <> (select PerfArtistLstName from #per)

select 
	PerfArtistLstName
from #per