use AutoSearch
go

create or alter procedure spSearchInWid
	@ddexReportId int
as
begin

	delete from FoundNamesInWid

	update SearchStepsWid set Status = 1 where Id = 30
-- St~Tt

	insert FoundNamesInWid(SourceNameId, TargetNameId, SearchType)
	select t1.SourceNameId, t2.Wic, 'St~Tt' as SearchType
	from SourceNamesT t1
		join SocWid..WidTitle t2 on t2.WrkTtl = t1.Name
		left join FoundNamesInWid t3 on t1.SourceNameId = t3.SourceNameId and t2.Wic = t3.TargetNameId
	where t3.SourceNameId is null
	union
	select t1.SourceNameId, t2.Wic, 'St~Tt' as SearchType
	from SourceNamesT t1
		join SocWid..widAltTtl t2 on t2.AltTtl = t1.Name
		left join FoundNamesInWid t3 on t1.SourceNameId = t3.SourceNameId and t2.Wic = t3.TargetNameId
	where t3.SourceNameId is null

drop table if exists #FoundNamesInWidByPerformer
select *
into #FoundNamesInWidByPerformer
from FoundNamesInWid t1
	join SocWid..widArtist t2 on t1.TargetNameId = t2.Wic
	join SourcePerformerParts t3 on t2.PerfArtistLstName = t3.Name

select *
from #FoundNamesInWidByPerformer t1
	join SourceWorks t2 on t1.WorkId = t2.WorkId



update SearchStepsWid set Status = 2 where Id = 30


--==================================================================
update SearchStepsWid set Status = 1 where Id = 31
	delete from FoundWorksInWid
	insert FoundWorksInWid(SourceWorkId, TargetWic)
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