use SocWidSubmit
go

create or alter procedure spWidSubmGroupWorkHashSelect 
	@WidSubmGroupWorkIds as tblTypeIntList readonly
as
begin
/*
	declare @WidSubmGroupWorkIds as tblTypeIntList

	insert @WidSubmGroupWorkIds
select t1.Id
from WidSubmGroupWork t1
	join WidSubmGroup t2 on t1.WidSubmGroupId = t2.Id
where dbo.fnIsSystemGroup(t1.WidSubmGroupId) <> 1
	and t2.Status = 1*/

    drop table if exists #WorkHash
	create table #WorkHash (
		  WidSubmGroupId int
		, ObjId int
		, HashString nvarchar(max)
	)

	insert #WorkHash
	select t1.WidSubmGroupId, t1.ObjId, ''
	from WidSubmGroupWork t1
		join @WidSubmGroupWorkIds t2 on t1.Id = t2.IntValue

	drop table if exists #NamesHash
	select t1.ObjId, string_agg(concat(t2.LocalName, '|', t2.IsMain), '|') within group (order by t2.IsMain desc, t2.SeekObjectId asc) as HashString
	into #NamesHash
	from #WorkHash t1
		join WidSubmGroupWorkName t2 on t1.WidSubmGroupId = t2.WidSubmGroupId and t1.ObjId = t2.ObjId
	group by t1.ObjId
	order by t1.ObjId

	--select * from #NamesHash

	drop table if exists #PerformersHash
	select t1.ObjId, string_agg(isnull(t2.LocalName, ''), '|') within group (order by t2.SeekObjectId asc) as HashString
	into #PerformersHash
	from #WorkHash t1
		left join WidSubmGroupWorkPerformer t2 on t1.WidSubmGroupId = t2.WidSubmGroupId and t1.ObjId = t2.ObjId
	group by t1.ObjId
	order by t1.ObjId

	--select * from #PerformersHash

	drop table if exists #SharesHash
	select t1.ObjId, string_agg(
		concat(t2.CustId, '|', t2.IpBaseNr, '|', t2.IpNameNr, '|', t2.RhType, '|', t2.RhRole, '|', t2.PerShr, '|', t2.MecShr)
			, '|') 
		within group (order by t2.CopyRightId) as HashString
	into #SharesHash
	from #WorkHash t1
		left join WidSubmGroupWorkShare t2 on t1.WidSubmGroupId = t2.WidSubmGroupId and t1.ObjId = t2.ObjId
	group by t1.ObjId
	order by t1.ObjId

	--select * from #SharesHash order by ObjId

	update t1
	set HashString = concat(t2.HashString, '|', t3.HashString, '|', t4.HashString)
	from #WorkHash t1
		join #NamesHash t2 on t1.ObjId = t2.ObjId
		join #PerformersHash t3 on t1.ObjId = t3.ObjId
		join #SharesHash t4 on t1.ObjId = t4.ObjId

	select * from #WorkHash order by ObjId

	drop table #WorkHash
end
go

/*
declare @WidSubmGroupWorkIds as tblTypeIntList

insert @WidSubmGroupWorkIds
select t1.Id
from WidSubmGroupWork t1
	join WidSubmGroup t2 on t1.WidSubmGroupId = t2.Id
where dbo.fnIsSystemGroup(t1.WidSubmGroupId) <> 1
	and t2.Status = 1
exec spWidSubmGroupWorkHashSelect @WidSubmGroupWorkIds
*/


