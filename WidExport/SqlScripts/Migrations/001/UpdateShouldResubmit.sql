declare @GroupId int = 3

-- Твори що мають помилки
drop table if exists #ErrObjIds
select distinct ObjId
into #ErrObjIds
from vWidSubmGroupWorkErrors
where WidSubmGroupId = @GroupId

--select * from #ErrObjIds

-- Серед обраних ті, що мають реєстрацію в ВІД
drop table if exists #InWidObjIds
select distinct t1.ObjId
into #InWidObjIds
from #ErrObjIds t1
	join ObjIdToWic t2 on t1.ObjId = t2.ObjId

--select * from #InWidObjIds

-- Видаляємо їх
delete #ErrObjIds
where ObjId in (select ObjId from #InWidObjIds)

--select * from #ErrObjIds

drop table #InWidObjIds

-- Твори з необробленими помилками

drop table if exists #NotProcessedObjIds
select distinct t1.ObjId
into #NotProcessedObjIds
from #ErrObjIds t1
	join vWidSubmGroupWorkErrors t2 on t1.ObjId = t2.ObjId
where t2.WidSubmGroupId = @GroupId
	and (t2.IsFixed = 0 and t2.NeedNotFix = 0)

--select * from #NotProcessedObjIds

-- Видаляємо їх
delete #ErrObjIds
where ObjId in (select ObjId from #NotProcessedObjIds)

--select * from #ErrObjIds

drop table #NotProcessedObjIds

-- Знаходимо твори, для яких є виправлення
drop table if exists #FixedObjIds
select distinct t1.ObjId
into #FixedObjIds
from #ErrObjIds t1
	join vWidSubmGroupWorkErrors t2 on t1.ObjId = t2.ObjId
where t2.WidSubmGroupId = @GroupId
	and t2.IsFixed = 1

-- Проставляємо НІ для всіх, а потім ТАК для виправлених

update t1
set t1.ShouldResubmit = 0
from WidSubmGroupWork t1
	join #ErrObjIds t2 on t1.ObjId = t2.ObjId
where t1.WidSubmGroupId = @GroupId

update t1
set t1.ShouldResubmit = 1
from WidSubmGroupWork t1
	join #FixedObjIds t2 on t1.ObjId = t2.ObjId
where t1.WidSubmGroupId = @GroupId

-- Вадаляємо тимчасові таблиці
drop table #FixedObjIds
drop table #ErrObjIds

--order by WidSubmGroupId, ObjId, SubmRecType