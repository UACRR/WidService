use AutoSearch
go

create or alter procedure spSearchInIdentMw
	@ddexReportId int
as
begin

	exec spFillInInitialInfo @ddexReportId

	delete from FoundNamesInIdentMw

	update SearchSteps set Status = 1 where Id = 17
-- St~Tt
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St~Tt' as SearchType
	from SourceNamesT t1
		join TargetNamesT t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- Tt~St
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'Tt~St' as SearchType
	from SourceNamesT t1
		join TargetNamesT t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S=T
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S=T' as SearchType
	from SourceNames t1
		join TargetNames t2 on t2.Name = t1.Name
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- St=Tt
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St=Tt' as SearchType
	from SourceNamesT t1
		join TargetNamesT t2 on t2.Name = t1.Name
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S~T
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S~T' as SearchType
	from SourceNames t1
		join TargetNames t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- T~S
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'T~S' as SearchType
	from SourceNames t1
		join TargetNames t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- St=T
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St=T' as SearchType
	from SourceNamesT t1
		join TargetNames t2 on t2.Name = t1.Name
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S=Tt
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S=Tt' as SearchType
	from SourceNames t1
		join TargetNamesT t2 on t2.Name = t1.Name
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- St~T
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St~T' as SearchType
	from SourceNamesT t1
		join TargetNames t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- S~Tt
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'S~Tt' as SearchType
	from SourceNames t1
		join TargetNamesT t2 on t2.Name like concat( t1.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- T~St
	insert FoundNamesInIdentMw(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'T~St' as SearchType
	from SourceNames t1
		join TargetNamesT t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInIdentMw t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

update SearchSteps set Status = 2 where Id = 17
--==================================================================
update SearchSteps set Status = 1 where Id = 18
	delete from FoundWorksInIdentMw
	insert FoundWorksInIdentMw(SourceWorkId, TargetWorkId)
	select t2.WorkId as SourceWorkId, max(t4.WorkId) as TargetWorkId
	from FoundNamesInIdentMw t1
		join SourceNameWorks t2 on t1.SourceNameId = t2.SourceNameId
		join SourcePerformerParts t3 on t2.WorkId = t3.WorkId
		join TargetNameWorks t4 on t1.TargetNameId = t4.TargetNameId
		join TargetPerformerParts t5 on t4.WorkId = t5.WorkId
		join SourceAuthorParts t6 on t2.WorkId = t6.WorkId
		join TargetAuthorParts t7 on t4.WorkId = t7.WorkId
	where t3.Name = t5.Name
		and t6.Name = t7.Name
	group by t2.WorkId

	update t2
	set t2.ObjId = t3.ObjId, t2.WIc = t3.Wic, t2.Status = t3.Status
	from FoundWorksInIdentMw t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join Ddex..IdentMw t3 on t1.TargetWorkId = t3.Id
update SearchSteps set Status = 2 where Id = 18
/*
	select t2.Title, t2.ComposerAuthor, t2.DisplayArtistName, t3.Title, t3.ComposerAuthor, t3.DisplayArtistName
	from FoundWorksInIdentMw t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join Ddex..IdentMw t3 on t1.TargetWorkId = t3.Id
*/
end

-- spSearchNameInIdentMw 1496