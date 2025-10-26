drop table if exists CopyRightBeginDates
select distinct 
	  ObjId
	, isnull(beginDate, datefromparts(1900, 1, 1)) as beginDate
into CopyRightBeginDates
from MediaService..CopyRight

drop table if exists CopyRightEndDates
select distinct 
	  ObjId
	, isnull(endDate, datefromparts(9999, 12, 31)) as endDate
into CopyRightEndDates
from MediaService..CopyRight

drop table if exists CopyRightPoints
select objId, beginDate as datePoint
into CopyRightPoints
from CopyRightBeginDates
union
select objId, endDate
from CopyRightEndDates

update CopyRightPoints set datePoint = datefromparts(1900, 1, 1) where datepart(year, datePoint) < 2017
update CopyRightPoints set datePoint = datefromparts(9999, 12, 31) where datepart(year, datePoint) >= 3000

select distinct ObjId, datePoint
from CopyRightPoints 
order by ObjId, datePoint

select ObjId, count(*) from CopyRightPoints group by Objid having count(*) < 2

select t2.Name, t1.beginDate, t1.endDate, t3.Name 
from MediaService..CopyRight t1
	join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
	join MediaService..vCustomerNames t3 on t1.CustId = t3.CustId
where t1.ObjId = 970682

drop table if exists CopyRightIntervals
select t1.objId, t1.beginDate, t2.endDate
into CopyRightIntervals
from CopyRightBeginDates t1
	join CopyRightEndDates t2 on t1.ObjId = t2.ObjId


update CopyRightIntervals set beginDate = datefromparts(9999, 12, 31) where beginDate > datefromparts(2100, 12, 31)
update CopyRightIntervals set endDate = datefromparts(9999, 12, 31) where endDate > datefromparts(2100, 12, 31)

	select distinct * from CopyRightIntervals where ObjId = 86892 order by beginDate, endDate
