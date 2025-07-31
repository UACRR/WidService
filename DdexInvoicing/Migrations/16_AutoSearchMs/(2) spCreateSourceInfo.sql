use AutoSearch
go

create or alter procedure spCreateSourceInfo
	@ddexReportId int
as
begin

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
	exec spSetSearchStepStarted 1
	truncate table SourceWorks
	insert SourceWorks(WorkId, Name, Authors, Performers)
	select 
		t2.Id
		, t2.Title
		, translate(t2.ComposerAuthor, '.|,()&:;\/', '          ')
		, translate(t2.DisplayArtistName, '.|,()&:;\/', '          ')
	from Ddex..IdentBacklog t1
		join Ddex..IdentMw t2 on t1.mwId = t2.Id
	--where t1.DdexReportId in (select Id from Ddex..ft_AgreementReportIds(1496))
	where t1.DdexReportId = @ddexReportId --1496--
		and isnull(t2.objId, 0) = 0
		and isnull(t2.Wic, 0) = 0
	exec spSetSearchStepEnded 1
	
		-- select count(*) from SourceWorks

-- SourceNames
	exec spSetSearchStepStarted 2
	truncate table SourceNames
	insert SourceNames(Name)
	select distinct Name
	from SourceWorks
	exec spSetSearchStepEnded 2

-- SourceNamesT
	exec spSetSearchStepStarted 3
	truncate table SourceNamesT
	insert SourceNamesT(SourceNameId, Name)
	select SourceNameId, AutoSearch.dbo.ClrTranslitFromUkrToLat(Name)
	from SourceNames
	exec spSetSearchStepEnded 3

-- SourceNameWorks
	exec spSetSearchStepStarted 4
	truncate table SourceNameWorks
	insert SourceNameWorks(SourceNameId, WorkId, ObjId, Wic)
	select distinct t1.SourceNameId, t2.WorkId, null, null
	from SourceNames t1
		join SourceWorks t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 4

-- SourcePerformerParts
	exec spSetSearchStepStarted 5
	truncate table SourcePerformerParts
	insert SourcePerformerParts(WorkId, Name)
	select distinct WorkId, AutoSearch.dbo.ClrTranslitFromUkrToLat(value)
	from SourceWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 5

-- SourceAuthorParts
	exec spSetSearchStepStarted 6
	truncate table SourceAuthorParts
	insert SourceAuthorParts(WorkId, Name)
	select distinct WorkId, AutoSearch.dbo.ClrTranslitFromUkrToLat(value)
	from SourceWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 6

end

end -- Процедури
go

-- exec spCreateSourceInfo 1496