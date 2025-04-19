drop table if exists #RegisterItem
select t1.*
into #RegisterItem
from RegisterItem t1
	left join RegisterCCIDMW t2 on t1.RegId = t2.RegId
		and t1.RegIItemId = t2.RegIItemId
where t2.RegId is null
	and isnull(Performer, '') <> ''

drop table if exists #Stat
select ItemName, Performer, count(*) cnt, sum(countUse) countUse
into #Stat
from #RegisterItem
group by ItemName, Performer

select * from #RegisterItem where objid is not null order by regid
select count(*) from #RegisterItem
select count(*) from #Stat

select t1.*, t2.ObjId, t2.Wic, t2.Iswc
from #Stat t1
	left join RadioStationReports..Works t2 on
		t1.ItemName = t2.Name
		and t1.performer = t2.Performers
where foundin is null
order by countUse desc

'В наступному'

