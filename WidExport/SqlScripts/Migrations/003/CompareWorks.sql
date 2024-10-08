use SocWidSubmit
go

-- Посилання на твори в СМАРТІ, які зазнали змін після передачі в ВІД
-- OldObjId is null означає що твір було видалено в СМАРТІ
-- NewObjId is null означає що твір було додано в СМАРТІ
-- В іншому випадку твір було змінено в СМАРТІ
drop table if exists #ChangedWorks
select t1.ObjId as NewObjId, t2.ObjId as OldObjId
into #ChangedWorks
from WidSubmGroupWork t1
	full join WidSubmGroupWork t2 on t1.ObjId = t2.ObjId
		and dbo.fnIsSystemGroup(t2.WidSubmGroupId) <> 1
where dbo.fnIsChangesGroup(t1.WidSubmGroupId) = 1

select 
	  isnull(t1.OldObjId, t1.NewObjId) as ObjId
	, t2.LocalName as OldName
	, t3.LocalName as NewName
	,	case when t1.OldObjId is null then 'A'
		else 
			case when t1.NewObjId is null then 'D' else 'U'  end
		end as WorkChange
	,	case when t1.OldObjId is null or t1.NewObjId is null then ''
		else 
			case when trim(t2.LocalName) <> trim(t3.LocalName) then 'Yes' else 'No'  end
		end as NameChange
from #ChangedWorks t1
	left join WidSubmGroupWorkName t2 on t1.OldObjId = t2.ObjId
		and t2.IsMain = 1
		and dbo.fnIsSystemGroup(t2.WidSubmGroupId) <> 1
	left join WidSubmGroupWorkName t3 on t1.NewObjId = t3.ObjId
		and t3.IsMain = 1
		and dbo.fnIsSystemGroup(t3.WidSubmGroupId) = 1

-- Далі цікаємось лише творами, зміненими в смарті
drop table if exists #UpdatedWorks
select OldObjId
into #UpdatedWorks
from #ChangedWorks
where OldObjId is not null
	and NewObjId is not null

-- select * from #UpdatedWorks order by OldObjId

-- ЗМІНИ НАЗВ
drop table if exists #ChangedGroupWorkName
select
	  t1.SeekObjectId
	, t1.WidSubmGroupId
	, t1.ObjId
	, case when t1.SeekObjectId is null then 'MAIN' else 'ALT' end as NameType
	, t3.LocalName as OldName
	, t1.LocalName as NewName
	, case when t3.LocalName is null then 'A'
		else 
			case when t1.LocalName is null then 'D' else 'U'  end
		end as WorkChange
	, case when t1.LocalName is null or t3.LocalName is null then ''
		else 
			case when trim(t1.LocalName) <> trim(t3.LocalName) then 'Yes' else 'No'  end
		end as NameChange
--into #ChangedGroupWorkName
from WidSubmGroupWorkName t1
	join #UpdatedWorks t2 on t1.ObjId = t2.OldObjId -- Лишаємо лише твори, які зазнали змін
	full join WidSubmGroupWorkName t3 on t1.ObjId = t3.ObjId
		and dbo.fnIsSystemGroup(t3.WidSubmGroupId) <> 1
		and isnull(t1.SeekObjectId, 0) = isnull(t3.SeekObjectId, 0)
where dbo.fnIsSystemGroup(t1.WidSubmGroupId) = 1
	and t1.ObjId = 716668
order by t1.ObjId, t1.SeekObjectId

-- ЗМІНИ ВИКОНАВЦІВ
drop table if exists #ChangedGroupWorkPerformer
select
	  t1.SeekObjectId
	, t1.WidSubmGroupId
	, t1.ObjId
	, case when t1.SeekObjectId is null then 'MAIN' else 'ALT' end as PerformerType
	, t3.LocalName as OldName
	, t1.LocalName as NewName
	, case when t3.LocalName is null then 'A'
		else 
			case when t1.LocalName is null then 'D' else 'U'  end
		end as WorkChange
	, case when t1.LocalName is null or t3.LocalName is null then ''
		else 
			case when trim(t1.LocalName) <> trim(t3.LocalName) then 'Yes' else 'No'  end
		end as NameChange
into #ChangedGroupWorkPerformer
from WidSubmGroupWorkPerformer t1
	join #UpdatedWorks t2 on t1.ObjId = t2.OldObjId -- Лишаємо лише твори, які зазнали змін
	full join WidSubmGroupWorkPerformer t3 on t1.ObjId = t3.ObjId
		and dbo.fnIsSystemGroup(t3.WidSubmGroupId) <> 1
		and isnull(t1.SeekObjectId, 0) = isnull(t3.SeekObjectId, 0)
where dbo.fnIsSystemGroup(t1.WidSubmGroupId) = 1
order by t1.ObjId, t1.SeekObjectId

-- ЗМІНИ РОЗПОДІЛУ ПРОЦЕНТІВ
drop table if exists #ChangedGroupWorkShare
select
	  t1.CopyRightId
	, t1.WidSubmGroupId
	, t1.ObjId
	, case when t3.CopyRightId is null then 'A'
		else 
			case when t1.CopyRightId is null then 'D' else 'U'  end
		end as WorkChange
	, t3.CustId as OldCustId
	, t1.CustId as NewCustId
	, t3.IpBaseNr as OldIpBaseNr
	, t1.IpBaseNr as NewIpBaseNr
	, t3.IpNameNr as OldIpNameNr
	, t1.IpNameNr as NewIpNameNr
	, t3.RhType as OldRhType
	, t1.RhType as NewRhType
	, t3.RhRole as OldRhRole
	, t1.RhRole as NewRhRole
	, t3.PerShr as OldPerShr
	, t1.PerShr as NewPerShr
	, t3.MecShr as OldMecShr
	, t1.MecShr as NewMecShr
	, t3.AggrLocal as OldAggLocal
	, t1.AggrLocal as NewAgrLocal
	, t3.AggrIpiPer as OldAgrIpiPer
	, t1.AggrIpiPer as NewAgrIpiPer
	, t3.AggrIpiMec as OldAgrIpiMec
	, t1.AggrIpiMec as NewAgrIpiMec
--into #ChangedGroupWorkShare
from WidSubmGroupWorkShare t1
	join #UpdatedWorks t2 on t1.ObjId = t2.OldObjId -- Лишаємо лише твори, які зазнали змін
	full join WidSubmGroupWorkShare t3 on t1.ObjId = t3.ObjId
		and dbo.fnIsSystemGroup(t3.WidSubmGroupId) <> 1
		and t1.CopyRightId = t3.CopyRightId
where dbo.fnIsSystemGroup(t1.WidSubmGroupId) = 1
	and t1.ObjId = 716668
order by t1.ObjId, t1.CopyRightId

-- select * from #ChangedGroupWorkPerformer
/*
; with SingleSeekObjectId as (
	select WidSubmGroupId, ObjId, SeekObjectId, min(Id) as Id, count(*) as Cnt
	from WidSubmGroupWorkPerformer
	group by WidSubmGroupId, ObjId, SeekObjectId
	having count(*) <> 1
)
--delete t2
select *
from WidSubmGroupWorkPerformer t1
	join WidSubmGroupWorkName t2 on 
		    t1.WidSubmGroupId = t2.WidSubmGroupId
		and t1.ObjId = t2.ObjId
		and t1.SeekObjectId = t2.SeekObjectId
		and t1.Id <> t2.Id

*/

