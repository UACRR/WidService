use AutoSearch
go

create or alter procedure spSearchInMs
	@ddexReportId int
as
begin

	exec spCreateSourceInfo @ddexReportId
	exec spUpdateTargetInfoMs

	delete from FoundNamesInWid

	update SearchStepsWid set Status = 1 where Id = 30
-- St~Tt

	insert FoundNamesInWid(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.Wic, 'St~Tt' as SearchType
	from SourceNamesT t1
		join SocWid..WidTitle t2 on t2.WrkTtl like concat( t1.Name, '%')
		left join FoundNamesInWid t3 on t1.SourceNameId = t3.SourceNameId and t2.Wic = t3.TargetNameId
	where t3.SourceNameId is null

-- Tt~St
	insert FoundNamesInWid(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'Tt~St' as SearchType
	from SourceNamesT t1
		join TargetNamesMsT t2 on t1.Name like concat( t2.Name, '%')
		left join FoundNamesInWid t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null

-- St=Tt
	insert FoundNamesInWid(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.TargetNameId, 'St=Tt' as SearchType
	from SourceNamesT t1
		join TargetNamesMsT t2 on t2.Name = t1.Name
		left join FoundNamesInWid t3 on t1.SourceNameId = t3.SourceNameId and t2.TargetNameId = t3.TargetNameId
	where t3.SourceNameId is null


update SearchStepsWid set Status = 2 where Id = 30
--==================================================================
update SearchStepsWid set Status = 1 where Id = 31
	delete from FoundWorksInMs
	insert FoundWorksInMs(SourceWorkId, TargetObjId)
	select t2.WorkId as SourceWorkId, max(t4.WorkId) as TargetWorkId
	from FoundNamesInWid t1
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
	update SearchStepsWid set Status = 2 where Id = 31

/*
	select t2.Title, t2.ComposerAuthor, t2.DisplayArtistName, t3.Name, t3.Author, t3.Performer
	from FoundWorksInMs t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join MediaService..ObjectRight t3 on t1.TargetObjId = t3.ObjId
*/
end

-- spSearchNameInMs 1496