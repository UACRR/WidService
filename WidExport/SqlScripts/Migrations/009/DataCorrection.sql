use SocWidSubmit
go

--Видаляємо творі із групи змін
delete from WidSubmGroupWorkHash where WidSubmGroupId = 2015
delete from WidSubmGroupWork			 where WidSubmGroupId = 2015
delete from WidSubmGroupWorkShare	 where WidSubmGroupId = 2015
delete from WidSubmGroupWorkName		 where WidSubmGroupId = 2015
delete from WidSubmGroupWorkPerformer where WidSubmGroupId = 2015

-- Create wrong works from non-system groups in work table
drop table if exists Z_WrongWorks
; with WrongWorks as (
	select distinct t1.WidSubmGroupId, t1.ObjId 
	from WidSubmGroupWork t1
		left join WidSubmGroupWorkSHare t2 on t1.ObjId = t2.ObjId
	where t2.ObjId is null
		and t1.WidSubmGroupId not in (2014, 2015)
	union 
	select distinct t1.WidSubmGroupId, t1.ObjId 
	from WidSubmGroupWork t1
		left join WidSubmGroupWorkName t2 on t1.ObjId = t2.ObjId
	where t2.ObjId is null
		and t1.WidSubmGroupId not in (2014, 2015)
)
select t2.*
into Z_WrongWorks
from WrongWorks t1
	join WidSubmGroupWork t2 on t1.ObjId = t2.ObjId
where t2.WidSubmGroupId not in (2014, 2015)

-- Видаляємо невірні твори
delete t1 from WidSubmGroupWork t1 join Z_WrongWorks t2 on t1.WidSubmGroupId = t2.WidSubmGroupId and t1.ObjId = t2.ObjId
delete t1 from WidSubmGroupWorkShare t1 join Z_WrongWorks t2 on t1.WidSubmGroupId = t2.WidSubmGroupId and t1.ObjId = t2.ObjId
delete t1 from WidSubmGroupWorkName t1 join Z_WrongWorks t2 on t1.WidSubmGroupId = t2.WidSubmGroupId and t1.ObjId = t2.ObjId
delete t1 from WidSubmGroupWorkPerformer t1 join Z_WrongWorks t2 on t1.WidSubmGroupId = t2.WidSubmGroupId and t1.ObjId = t2.ObjId
delete t1 from WidSubmGroupWorkHash t1 join Z_WrongWorks t2 on t1.WidSubmGroupId = t2.WidSubmGroupId and t1.ObjId = t2.ObjId

-- Оновлюємо групу змін
exec spWidSubmGroupChangedWorksUpdate
exec spUpdateObjIdToWicFromMs
exec spWidSubmGroupUpdateChecklist 2015
exec spWidSubmGroupPreProc 2015

-- Позначаємо твори групи змін які мають код ISWC як ПРИЙНЯТІ
--select * 
update t1
set t1.Status = 5
from WidSubmGroupWork t1
	join ObjIdToWic t2 on t1.ObjId = t2.ObjId
where t1.WidSubmGroupId = 2015 and isnull(t2.Iswc, '') <> ''

-- Передача в СМАРТ і перенос/оновлення в головних групах
declare @cntCandidateWorks int
declare @cntNotReadyWorks int
declare @cntPassedWorks int
exec spWidSubmAllApplyToSmart @cntCandidateWorks, @cntNotReadyWorks, @cntPassedWorks

--select * from WidSubmGroupWork where ObjId = 980279
--select * from WidSubmGroupWorkName where ObjId = 980279