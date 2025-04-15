use RadioStationReports
go

create or alter procedure spCreateWorksForRegisteredReport
	@reportId int
as
begin
-- ÄÎÄÀªÌÎ ÍÎÂ² ÒÂÎĞÈ, ßÊ² ÍÀÄ²ÉØËÈ Ó ÇÂ²Ò²
; with TmpWorksToAdd as (
	select t1.Name, t1.Performer
	from ReportLines t1
		left join Works t2 on
			t1.Name = t2.Name
			and t1.Performer = t2.Performers
	where ReportId = @reportId
		and t2.Id is null
)
insert Works(
	  Name
	, Authors
	, Performers
	, NameT
	, AuthorsT
	, PerformersT
)
select
	  Name													as Name
	, ''													as Authors
	, Performer												as Performers
	, MediaService.dbo.TransLitCharFromUkrToLat(Name)		as NameT
	, ''													as AuthorsT
	, MediaService.dbo.TransLitCharFromUkrToLat(Performer)	as PerformersT
from TmpWorksToAdd

-- ÑÒÂÎĞŞªÌÎ ÏÎÑÈËÀÍÍß ĞßÄÊ²Â ÇÂ²ÒÓ ÍÀ ÒÂÎĞÈ
update t1
set t1.WorkId = t2.Id
from ReportLines t1
	join Works t2 on
		t1.Name = t2.Name
		and t1.Performer = t2.Performers
where t1.ReportId = @reportId

end