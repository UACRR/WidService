use MediaService
go

update MediaTrack
set Iswc = trim(Iswc)

drop table if exists #Iswcs
select ObjId, Iswc
into #Iswcs
from MediaTrack
where Iswc <> ''
	and (len(Iswc) <> 11 or left(Iswc, 1) <> 'T')

update #Iswcs set Iswc = replace(Iswc, '-', '')
update #Iswcs set Iswc = replace(Iswc, '.', '')

update #Iswcs 
set Iswc = substring(Iswc, 2, len(Iswc) - 1)
where substring(Iswc, 2, 1) = 'T'

update #Iswcs 
set Iswc = concat('T', Iswc)
where len(Iswc) = 10

update #Iswcs 
set Iswc = ''
where len(Iswc) <> 11

update t1
set t1.Iswc = t2.Iswc
from MediaTrack t1
	join #Iswcs t2 on t1.ObjId = t2.ObjId

drop table if exists #Iswcs