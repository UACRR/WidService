use AutoSearch
go

create or alter procedure spSearchInWid
	@ddexReportId int
as
begin

begin try
set transaction isolation level read uncommitted

	exec spCreateSourceInfo @ddexReportId
	exec spUpdateTargetInfoWid

-- St=T
	exec spSetSearchStepStarted 26
	drop table if exists FoundNamesInWid
		select t1.SourceNameId, t2.TargetNameId, 'St=T' as SearchType
			into FoundNamesInWid
			from SourceNamesT t1
				join TargetNamesWid t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 26

--==================================================================
	exec spSetSearchStepStarted 27
	drop table if exists FoundWorksInWid
	select t2.WorkId as SourceWorkId, max(t4.Wic) as TargetWic
	into FoundWorksInWid
	from FoundNamesInWid t1
		join SourceNameWorks t2 on t1.SourceNameId = t2.SourceNameId
		join SourcePerformerParts t3 on t2.WorkId = t3.WorkId
		join TargetNameWorksWid t4 on t1.TargetNameId = t4.TargetNameId
		join TargetPerformerPartWorksWid t5 on t4.Wic = t5.WorkId
		join TargetPerformerPartsWid t51 on t51.TargetPerformerPartId = t5.TargetPerformerPartId
		join SourceAuthorParts t6 on t2.WorkId = t6.WorkId
		join TargetAuthorPartWorksWid t7 on t4.Wic = t7.Wic
		join TargetAuthorPartsWid t71 on t71.TargetAuthorPartId = t7.TargetAuthorPartId
	where t3.Name = t51.Name
		and
		 t6.Name = t71.Name
	group by t2.WorkId
	union
	select t2.WorkId as SourceWorkId, max(t4.Wic) as TargetWorkId --t2.WorkId as SourceWorkId, max(t4.Wic) as TargetWorkId
	from FoundNamesInWid t1
		join SourceNameWorks t2 on t1.SourceNameId = t2.SourceNameId
		join SourcePerformerParts t3 on t2.WorkId = t3.WorkId
		join TargetNameWorksWid t4 on t1.TargetNameId = t4.TargetNameId
		join SourceAuthorParts t6 on t2.WorkId = t6.WorkId
		join TargetAuthorPartWorksWid t7 on t4.Wic = t7.Wic
		join TargetAuthorPartsWid t71 on t71.TargetAuthorPartId = t7.TargetAuthorPartId
	where t6.Name = t71.Name
	group by t2.WorkId
	having count(*) > 1
	exec spSetSearchStepEnded 27


	exec spSetSearchStepStarted 28
	update t2
	set t2.ObjId = null, t2.Wic = t1.TargetWic, t2.Status = 2
	from FoundWorksInWid t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
	exec spSetSearchStepEnded 28

set transaction isolation level read committed
end try
begin catch
	throw
end catch


/*
	select t2.Title, t2.ComposerAuthor, t2.DisplayArtistName, t3.Name, t3.Author, t3.Performer
	from FoundWorksInMs t1
		join Ddex..IdentMw t2 on t1.SourceWorkId = t2.Id
		join MediaService..ObjectRight t3 on t1.TargetObjId = t3.ObjId
*/
end

-- spSearchNameInMs 1496