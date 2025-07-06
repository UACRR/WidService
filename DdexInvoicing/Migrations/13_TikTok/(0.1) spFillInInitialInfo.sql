use AutoSearch
go

create or alter procedure spFillInInitialInfo
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

-- =================================== ¬’≤ƒÕ¿ ≤Õ‘Œ–Ã¿÷≤ﬂ ≤« «¬≤“”

	update SearchSteps set Status = 1 where Id = 1
	truncate table SourceWorks
	insert SourceWorks(WorkId, Name, Authors, Performers)
	select t2.Id, t2.Title, t2.ComposerAuthor, t2.DisplayArtistName
	from Ddex..IdentBacklog t1
		join Ddex..IdentMw t2 on t1.mwId = t2.Id
	--where t1.DdexReportId in (select Id from Ddex..ft_AgreementReportIds(1496))
	where t1.DdexReportId = @ddexReportId --1496
		and isnull(t2.objId, 0) = 0
		and isnull(t2.Wic, 0) = 0
	update SearchSteps set Status = 2 where Id = 1
	
		-- select count(*) from SourceWorks

	update SearchSteps set Status = 1 where Id = 2
	truncate table SourceNames
	insert SourceNames(Name)
	select distinct Name
	from SourceWorks
	update SearchSteps set Status = 2 where Id = 2

	update SearchSteps set Status = 1 where Id = 3
	truncate table SourceNamesT
	insert SourceNamesT(SourceNameId, Name)
	select SourceNameId, dbo.TransLitFromUkrToLat(Name)
	from SourceNames
	update SearchSteps set Status = 2 where Id = 3

	update SearchSteps set Status = 1 where Id = 4
	truncate table SourceNameWorks
	insert SourceNameWorks(SourceNameId, WorkId, ObjId, Wic)
	select distinct t1.SourceNameId, t2.WorkId, null, null
	from SourceNames t1
		join SourceWorks t2 on t1.Name = t2.Name
	update SearchSteps set Status = 2 where Id = 4

	update SearchSteps set Status = 1 where Id = 5
	truncate table SourcePerformerParts
	insert SourcePerformerParts(WorkId, Name)
	select distinct WorkId, value
	from SourceWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	update SearchSteps set Status = 2 where Id = 5

	update SearchSteps set Status = 1 where Id = 6
	update SourcePerformerParts set Name = dbo.TransLitFromUkrToLat(Name)
	update SearchSteps set Status = 2 where Id = 6

	update SearchSteps set Status = 1 where Id = 7
	truncate table SourceAuthorParts
	insert SourceAuthorParts(WorkId, Name)
	select distinct WorkId, value
	from SourceWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	update SearchSteps set Status = 2 where Id = 7

	update SearchSteps set Status = 1 where Id = 8
	update SourceAuthorParts set Name = dbo.TransLitFromUkrToLat(Name)
	update SearchSteps set Status = 2 where Id = 8

-- =================================== ¬’≤ƒÕ¿ ≤Õ‘Œ–Ã¿÷≤ﬂ ƒÀﬂ œŒÿ” ”
	update SearchSteps set Status = 1 where Id = 9
	truncate table TargetWorks
	insert TargetWorks(WorkId, Name, Authors, Performers)
	select Id, Title, ComposerAuthor, DisplayArtistName
	from Ddex..IdentMw
	where isnull(objId, 0) <> 0
		or isnull(Wic, 0) <> 0
	update SearchSteps set Status = 2 where Id = 9

	update SearchSteps set Status = 1 where Id = 10
	truncate table TargetNames
	insert TargetNames(Name)
	select distinct Name
	from TargetWorks
	update SearchSteps set Status = 2 where Id = 10

	update SearchSteps set Status = 1 where Id = 11
	truncate table TargetNamesT
	insert TargetNamesT(TargetNameId, Name)
	select TargetNameId, dbo.TransLitFromUkrToLat(Name)
	from TargetNames
	update SearchSteps set Status = 2 where Id = 11

	update SearchSteps set Status = 1 where Id = 12
	truncate table TargetNameWorks
	insert TargetNameWorks(TargetNameId, WorkId, ObjId, Wic)
	select distinct t1.TargetNameId, t2.WorkId, null, null
	from TargetNames t1
		join TargetWorks t2 on t1.Name = t2.Name
	update SearchSteps set Status = 2 where Id = 12

-- —ÀŒ¬¿ ” ¬» ŒÕ¿¬÷ﬂ’
	update SearchSteps set Status = 1 where Id = 13
	truncate table TargetPerformerParts
	insert TargetPerformerParts(WorkId, Name)
	select distinct WorkId, left(value, 64)
	from TargetWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	update SearchSteps set Status = 2 where Id = 13

	update SearchSteps set Status = 1 where Id = 14
	update TargetPerformerParts set Name = dbo.TransLitFromUkrToLat(name)
	update SearchSteps set Status = 2 where Id = 14

-- —ÀŒ¬¿ ” ¿¬“Œ–¿’
	update SearchSteps set Status = 1 where Id = 15
	truncate table TargetAuthorParts
	insert TargetAuthorParts(WorkId, Name)
	select distinct WorkId, left(value, 64)
	from TargetWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	update SearchSteps set Status = 2 where Id = 15

	update SearchSteps set Status = 1 where Id = 16
	update TargetAuthorParts set Name = left(dbo.TransLitFromUkrToLat(name), 64)
	update SearchSteps set Status = 2 where Id = 16


end
go

-- exec spFillInInitialInfo 1496