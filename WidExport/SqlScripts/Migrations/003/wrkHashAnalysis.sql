use SocWidSubmit
go

declare @WidSubmGroupWorkIds as tblTypeIntList

-- Хеш ЗМІНЕНТИХ творів в групі змін (без ДОДАНИХ)
insert @WidSubmGroupWorkIds
select t1.Id
from WidSubmGroupWork t1
	join WidSubmGroup t2 on t1.WidSubmGroupId = t2.Id
	join WidSubmGroupWork t3 on t1.ObjId = t3.ObjId
		and dbo.fnIsSystemGroup(t3.WidSubmGroupId) <> 1
where dbo.fnIsChangesGroup(t1.WidSubmGroupId) = 1

drop table if exists #GeneratedChangedWorksHash;
create table #GeneratedChangedWorksHash (
		  WidSubmGroupId int
		, ObjId int
		, HashString nvarchar(max)
)
insert #GeneratedChangedWorksHash
exec spWidSubmGroupWorkHashSelect @WidSubmGroupWorkIds

--------------------

-- Хеш ЗАВЕРШЕНИХ творів

delete from @WidSubmGroupWorkIds

insert @WidSubmGroupWorkIds
select t1.Id
from WidSubmGroupWork t1
	join WidSubmGroup t2 on t1.WidSubmGroupId = t2.Id
where t1.Status = 10
	-- and dbo.fnIsSystemGroup(t1.WidSubmGroupId) <> 1 (не потрібна додаткова умова, з системних груп твори після передачі в СМАРТ одразу вилучаються)

drop table if exists #GeneratedCompletedWorksHash;
create table #GeneratedCompletedWorksHash (
		  WidSubmGroupId int
		, ObjId int
		, HashString nvarchar(max)
)
insert #GeneratedCompletedWorksHash
exec spWidSubmGroupWorkHashSelect @WidSubmGroupWorkIds

-----------------------------------------
-- Перевіряємо що завершені твори мають хєш, і немає хешу незавершених творів
select count(* )
from #GeneratedCompletedWorksHash t1
	full join WidSubmGroupWorkHash t2 on t1.ObjId = t2.ObjId
where t1.ObjId is null or t2.ObjId is null

-- Перерівяємо що згенеровані і постійні значення хешу співпадають
select *
from #GeneratedCompletedWorksHash t1
	full join WidSubmGroupWorkHash t2 on t1.ObjId = t2.ObjId
where t1.HashString <> t2.HashString

-- Виправляємо постійний хеш
update t2
set t2.HashString = t1.HashString
from #GeneratedCompletedWorksHash t1
	join WidSubmGroupWorkHash t2 on t1.ObjId = t2.ObjId
where t1.HashString <> t2.HashString

--==============================================================

-- Змінені твори повинні належати до закритих груп
select count(*)
from #GeneratedChangedWorksHash t1
	join WidSubmGroupWork t2 on t1.ObjId = t2.ObjId
		and dbo.fnIsChangesGroup(t2.WidSubmGroupId) <> 1
	join WidSubmGroup t3 on t2.WidSubmGroupId = t3.Id
where t3.Status <> 1

-- Змінені твори повинні містити всі твори із закритих груп у яких відмінний хеш
select count(*)
from #GeneratedCompletedWorksHash t1
	join WidSubmGroupWork t2 on t1.ObjId = t2.ObjId
		and dbo.fnIsChangesGroup(t2.WidSubmGroupId) <> 1
	left join #GeneratedChangedWorksHash t3 on t1.ObjId = t3.ObjId
where t1.HashString <> t3.HashString
	and t3.ObjId is null

-- Зайві твори в групі змін (ті, що мають такий самий хеш як і твори в основній групі) - видаляємо
declare @changesGroupId int = (select Id from WidSubmGroup where dbo.fnIsChangesGroup(Id) = 1)

drop table if exists #WrongWorks
select t3.WidSubmGroupId, t3.ObjId
into #WrongWorks
from #GeneratedCompletedWorksHash t1
	join WidSubmGroupWork t2 on t1.ObjId = t2.ObjId
		and dbo.fnIsChangesGroup(t2.WidSubmGroupId) <> 1
	join #GeneratedChangedWorksHash t3 on t1.ObjId = t3.ObjId
where t1.HashString = t3.HashString

select *
from #WrongWorks t1
where ObjId = 880972

/*
select * from #GeneratedCompletedWorksHash where ObjId = 875660
select * from #GeneratedChangedWorksHash where ObjId = 875660
select * from WidSubmGroupWorkHash where ObjId = 875660
#АГОВ|1|Сергій Бабкін|||||||
#АГОВ|1|Сергій Бабкін|||||||
#АГОВ|1|Сергій Бабкін|||||||
*/

delete t2
from #WrongWorks t1
	join WidSubmGroupWorkShare t2 on t1.WidSubmGroupId = t2.WidSubmGroupId
		and t1.ObjId = t2.ObjId

delete t2
from #WrongWorks t1
	join WidSubmGroupWorkName t2 on t1.WidSubmGroupId = t2.WidSubmGroupId
		and t1.ObjId = t2.ObjId

delete t2
from #WrongWorks t1
	join WidSubmGroupWorkPerformer t2 on t1.WidSubmGroupId = t2.WidSubmGroupId
		and t1.ObjId = t2.ObjId

delete t2
from #WrongWorks t1
	join WidSubmGroupWork t2 on t1.WidSubmGroupId = t2.WidSubmGroupId
		and t1.ObjId = t2.ObjId

 -- Корекція окремих обєктів
exec spWidSubmGroupUpdateFromMs 2015
exec spWidSubmGroupUpdateFromMs 2012
exec spWidSubmGroupUpdateFromMs 2014
exec spWidSubmGroupUpdateFromMs 2020

update t1
set t1.SeekObjectId = t2.Id
from WidSubmGroupWorkName t1
	left join MediaService..SeekObject t2 on t1.ObjId = t2.ObjId 
		and T1.LocalName = t2.name
		and t2.codeI = 1
where t1.IsMain <> 1
	and t1.SeekObjectId is null

go