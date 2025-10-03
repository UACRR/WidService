use AutoSearch
go

create or alter procedure spCreateSourceInfoApple
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
	insert SourceWorksApple(WorkId, Name, Authors, Performers)
	select 
		  TrackDspId
		, TrackTitle
		, translate(ComposerAuthor, '.|,()&:;\/', '          ')
		, translate(TrackPrimaryArtist, '.|,()&:;\/', '          ')
	from AppleMusic..AppleContentReport
	exec spSetSearchStepEnded 1
	
		-- select count(*) from SourceWorks

-- SourceNames
	exec spSetSearchStepStarted 2
	truncate table SourceNames
	insert SourceNames(Name)
	select distinct Name
	from SourceWorksApple
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
	insert SourceNameWorksApple(SourceNameId, WorkId)
	select distinct t1.SourceNameId, t2.WorkId
	from SourceNames t1
		join SourceWorksApple t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 4

-- SourcePerformerParts
	exec spSetSearchStepStarted 5
	truncate table SourcePerformerPartsApple
	insert SourcePerformerPartsApple(WorkId, Name)
	select distinct WorkId, left(AutoSearch.dbo.ClrTranslitFromUkrToLat(value), 64)
	from SourceWorksApple
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 5

-- SourceAuthorParts
	exec spSetSearchStepStarted 6
	truncate table SourceAuthorPartsApple
	insert SourceAuthorPartsApple(WorkId, Name)
	select distinct WorkId, left(AutoSearch.dbo.ClrTranslitFromUkrToLat(value), 64)
	from SourceWorksApple
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 6

end

end -- Процедури
go

-- exec spCreateSourceInfo 1496