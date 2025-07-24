use AutoSearch
go

create or alter procedure spSearchInMs
	@ddexReportId int
as
begin

	exec spCreateSourceInfo @ddexReportId
	exec spUpdateTargetInfoMs

	delete from FoundNamesInMs

	update SearchStepsMs set Status = 1 where Id = 30

-- ѕќ¬Ќ≈ —ѕ≤¬ѕјƒ≤ЌЌя
-- St=Tt
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St=Tt' as SearchType
	from SourceNamesT t1
		join TargetNamesMsT t2 on t2.Name = t1.Name
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S=T (на практиц≥ н≥чого не додасть)
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S=T' as SearchType
	from SourceNames t1
		join TargetNamesMs t2 on t2.Name = t1.Name
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- St=T
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St=T' as SearchType
	from SourceNamesT t1
		join TargetNamesMs t2 on t2.Name = t1.Name
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S=Tt
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S=Tt' as SearchType
	from SourceNames t1
		join TargetNamesMsT t2 on t2.Name = t1.Name
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- ѕќƒ≤ЅЌ≤ ѕќ„ј“ » Ќј«¬»
-- «ј”¬ј∆≈ЌЌя - текст, €кий шукаЇтьс€, сл≥д супроводжувати проб≥лом, ≥накше буде знаходитьс€ не потр≥бне
drop table if exists #SourceNames
select SourceNameId, concat(Name, ' ') as Name 
into #SourceNames
from SourceNames

drop table if exists #SourceNamesT
select SourceNameId, concat(Name, ' ') as Name 
into #SourceNamesT
from SourceNamesT

drop table if exists #TargetNamesMs
select TargetNameId, concat(Name, ' ') as Name 
into #TargetNamesMs
from TargetNamesMs

drop table if exists #TargetNamesMsT
select TargetNameId, concat(Name, ' ') as Name 
into #TargetNamesMsT
from TargetNamesMsT

-- St~Tt
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St~Tt' as SearchType
	from #SourceNamesT t1
		join TargetNamesMsT t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- Tt~St
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'Tt~St' as SearchType
	from SourceNamesT t1
		join #TargetNamesMsT t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null


-- S~T
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S~T' as SearchType
	from #SourceNames t1
		join TargetNamesMs t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- T~S
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'T~S' as SearchType
	from SourceNames t1
		join #TargetNamesMs t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null


-- St~T
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St~T' as SearchType
	from #SourceNamesT t1
		join TargetNamesMs t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S~Tt
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S~Tt' as SearchType
	from #SourceNames t1
		join TargetNamesMsT t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- T~St
	insert FoundNamesInMs(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'T~St' as SearchType
	from SourceNames t1
		join #TargetNamesMsT t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInMs t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

update SearchStepsMs set Status = 2 where Id = 30


select t1.SearchType, t2.WorkId, t3.Title, t5.ObjId, t5.Name, t3.ComposerAuthor, t5.author, t3.DisplayArtistName, t5.performer
	from FoundNamesInMs t1
		join SourceNameWorks t2 on t1.SourceNameId = t2.SourceNameId
		join Ddex..IdentMw t3 on t2.WorkId = t3.Id
		join TargetNameWorksMs t4 on t1.TargetNameId = t4.TargetNameId
		join MediaService..ObjectRight t5 on t4.WorkId = t5.ObjId
where t3.Title = 'без бою'
order by t3.Title desc

select *
from SourceNames
where Name = 'без бою'

--==================================================================
update SearchStepsMs set Status = 1 where Id = 31
	delete from FoundWorksInMs
	insert FoundWorksInMs(SourceWorkId, TargetObjId)
	select t2.WorkId as SourceWorkId, max(t4.WorkId) as TargetWorkId
	from FoundNamesInMs t1
		join SourceNameWorks t2 on t1.SourceNameId = t2.SourceNameId
		join SourcePerformerParts t3 on t2.WorkId = t3.WorkId
		join TargetNameWorksMs t4 on t1.TargetNameId = t4.TargetNameId
		join TargetPerformerPartWorksMs t5 on t4.WorkId = t5.WorkId
		join TargetPerformerPartsMs t51 on t51.TargetPerformerPartId = t5.TargetPerformerPartId
		join SourceAuthorParts t6 on t2.WorkId = t6.WorkId
		join TargetAuthorPartWorksMs t7 on t4.WorkId = t7.WorkId
		join TargetAuthorPartsMs t71 on t71.TargetAuthorPartId = t7.TargetAuthorPartId
	where t3.Name = t51.Name
		and t6.Name = t71.Name
	group by t2.WorkId

	update t2
	set t2.ObjId = t1.TargetObjId, t2.Wic = null, t2.Status = 2
	from FoundWorksInMs t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
	update SearchStepsMs set Status = 2 where Id = 31

/*
	select t2.Title, t2.ComposerAuthor, t2.DisplayArtistName, t3.Name, t3.Author, t3.Performer
	from FoundWorksInMs t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join MediaService..ObjectRight t3 on t1.TargetObjId = t3.ObjId
*/
end

-- spSearchNameInMs 1496