use AutoSearch
go

create or alter procedure spCreateSourceInfo
	@ddexReportId int
as
begin

	update SearchSteps set Status = 0

/*
update t2
set t2.ObjId = null, t2.Wic = null, Status = 0
from Ddex..IdentBacklog t1
	join Ddex..IdentMw t2 on t1.mwId = t2.Id
where t1.DdexReportId = 1496
*/

/*
select *
from Ddex..IdentBacklog t1
	join Ddex..IdentMw t2 on t1.mwId = t2.Id
where t1.DdexReportId = 1496
	and t2.Status= 2
--	and Title = 'I Loved You - Denis First Extended Mix'
*/

-- =================================== ВХІДНА ІНФОРМАЦІЯ ІЗ ЗВІТУ
-- Інформація робоча, після завершення пошуку інформація з таблиць видаляється
begin
-- SourceWorks
	update SearchSteps set Status = 1 where Id = 1
	truncate table SourceWorks
	insert SourceWorks(WorkId, Name, Authors, Performers)
	select t2.Id, t2.Title, t2.ComposerAuthor, t2.DisplayArtistName
	from Ddex..IdentBacklog t1
		join Ddex..IdentMw t2 on t1.mwId = t2.Id
	--where t1.DdexReportId in (select Id from Ddex..ft_AgreementReportIds(1496))
	where t1.DdexReportId = 1496--@ddexReportId --
		and isnull(t2.objId, 0) = 0
		and isnull(t2.Wic, 0) = 0
	update SearchSteps set Status = 2 where Id = 1
	
		-- select count(*) from SourceWorks

-- SourceNames
	update SearchSteps set Status = 1 where Id = 2
	truncate table SourceNames
	insert SourceNames(Name)
	select distinct Name
	from SourceWorks
	update SearchSteps set Status = 2 where Id = 2

-- SourceNamesT
	update SearchSteps set Status = 1 where Id = 3
	truncate table SourceNamesT
	insert SourceNamesT(SourceNameId, Name)
	select SourceNameId, dbo.TransLitFromUkrToLat(Name)
	from SourceNames
	update SearchSteps set Status = 2 where Id = 3

-- SourceNameWorks
	update SearchSteps set Status = 1 where Id = 4
	truncate table SourceNameWorks
	insert SourceNameWorks(SourceNameId, WorkId, ObjId, Wic)
	select distinct t1.SourceNameId, t2.WorkId, null, null
	from SourceNames t1
		join SourceWorks t2 on t1.Name = t2.Name
	update SearchSteps set Status = 2 where Id = 4

-- SourcePerformerParts
	update SearchSteps set Status = 1 where Id = 5
	truncate table SourcePerformerParts
	insert SourcePerformerParts(WorkId, Name)
	select distinct WorkId, value
	from SourceWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	update SearchSteps set Status = 2 where Id = 5

-- SourcePerformerParts Translit
	update SearchSteps set Status = 1 where Id = 6
	update SourcePerformerParts set Name = dbo.TransLitFromUkrToLat(Name)
	update SearchSteps set Status = 2 where Id = 6

-- SourceAuthorParts
	update SearchSteps set Status = 1 where Id = 7
	truncate table SourceAuthorParts
	insert SourceAuthorParts(WorkId, Name)
	select distinct WorkId, value
	from SourceWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	update SearchSteps set Status = 2 where Id = 7

-- SourceAuthorParts Translit
	update SearchSteps set Status = 1 where Id = 8
	update SourceAuthorParts set Name = dbo.TransLitFromUkrToLat(Name)
	update SearchSteps set Status = 2 where Id = 8

end

end -- Процедури
go

-- exec spCreateSourceInfo 1496