use MediaService

declare @custId int = 2343     -- KHARCHYSHYN

drop table if exists #RightHolders
select @custId as CustId
into #RightHolders

drop table if exists #Works
select distinct ObjId
into #Works
from CopyRight t1
	join #RightHolders t2 on t1.custId = t2.CustId

-- Цикл
insert #RightHolders
select distinct custId
from #Works t1
	join CopyRight t2 on t1.ObjId  = t2.ObjId
where t2.custId not in (select CustId from #RightHolders)

insert into #Works
select distinct objId
from CopyRight t1
	join #RightHolders t2 on t1.custId = t2.custId
where t1.objId not in (select objId from #Works)

select count(*) 
from RightHolder -- 121495:241222
group by custId
having count(*) > 1

select objId, count(*) 
from #Works
group by objId
having count(*) > 1

select count(*) from #Works
