use RadioStationReports
go

create or alter procedure spRegisterReportFromMs
	  @regId int
	, @reportId int output
as
begin

--begin tran
--declare @regId int = 3778
declare @rootPath nvarchar(max) = (select TemplateFileFullName from Configuration)
set @rootPath = dbo.fnTrimRightAfter(@rootPath, '\', 1)

declare @customerShortName nvarchar(100) = (
	select t2.ShortName
	from MediaService..Register t1
		join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
	where t1.regId = @regId
)

declare @periodId int =(select periodId from MediaService..Register where regId = @regId)
declare @beginDate as varchar(10) = (
	select cast(beginDate as varchar(10))
	from MediaService..PaidPeriod
	where periodId = @periodId
)
declare @endDate as varchar(10) = (
	select cast(endDate as varchar(10))
	from MediaService..PaidPeriod
	where periodId = @periodId
)
declare @dateInterval varchar(21) = concat(@beginDate, '_', @endDate)

declare @workFilesPath nvarchar(max) = concat(@rootPath, @customerShortName, '\', @dateInterval, '\')

-- ÑÒÂÎĞŞªÌÎ ÇÀÏÈÑ ÄËß ÇÂ²ÒÓ
insert Reports (
	  RadioStationId
	, StartYear
	, StartMonth
	, EndYear
	, EndMonth
	, FileName
	, FilePath
	, WorkFilesPath
	, SourceFileCopyName
	, SearchFileName
	, DistributionFileName
	, CheckFileName
	, IsArchived
	, CreatedAt
	, UpdatedAt
	, AutoSearchFinishedAt
	, CalcRoyaltyFinishedAt
	, SearchFileCreatedAt
	, SearchFileUpdatedAt
	, SearchFileImportedAt
	, DistributionFileCreatedAt
	, DistributionFileUpdatedAt
)
select
	  null							as RadioStationId
	, datepart(yyyy, t2.beginDate)	as StartYear
	, datepart(mm, t2.beginDate)	as StartMonth
	, datepart(yyyy, t2.endDate)	as EndYear
	, datepart(mm, t2.endDate)		as EndMonth
	, t1.FileName					as FileName
	, ''							as FilePath
	, @workFilesPath				as WorkFilesPath
	, ''							as SourceFileCopyName
	, ''							as SearchFileName
	, ''							as DistributionFileName
	, ''							as CheckFileName
	, 0								as IsArchived
	, getdate()						as CreatedAt
	, getdate()						as UpdatedAt
	, null							as AutoSearchFinishedAt
	, null							as CalcRoyaltyFinishedAt
	, null							as SearchFileCreatedAt
	, null							as SearchFileUpdatedAt
	, null							as SearchFileImportedAt
	, null							as DistributionFileCreatedAt
	, null							as DistributionFileUpdatedAt
from MediaService..Register t1
	join MediaService..PaidPeriod t2 on t1.periodId = t2.periodId
where t1.RegId = @regId

set @reportId = scope_identity()

-- ÑÒÂÎĞŞªÌÎ ÇÀÏÈÑ ÄËß ĞßÄÊ²Â ÇÂ²ÒÓ
insert ReportLines(
	  ReportId
	, LineNr
	, Name
	, Performer
	, MusicAuthor
	, TextAuthor
	, Duration
	, CountUses
	, TotalDuration
	, WorkId
)
select
	  @reportId as ReportId
	, regIItemId as LineNr
	, ItemName as Name
	, Performer as Performer
	, '' as MusicAuthor
	, '' as TextAuthor
	, dbo.fnTrimRightAfter(cast(durationUse as varchar), '.', 0) as Duration
	, cast(CountUse as varchar) as CountUses
	, dbo.fnTrimRightAfter(cast(DurationItem as varchar), '.', 0) as TotalDuration
	, null as WorkId
from MediaService..RegisterItem
where regId = @regId

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
	, Performers
	, NameT
	, PerformersT
)
select
	  Name													as Name
	, Performer												as Performers
	, MediaService.dbo.TransLitCharFromUkrToLat(Name)		as NameT
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

--select * from ReportLines where ReportId = @reportId and isnull(WorkId, 0) = 0

-- ÑÒÂÎĞŞªÌÎ Â²ÄÏÎÂ²ÄÍ²ÑÒÜ ÇÂ²ÒÓ ÄÎÄÀÒÊÓ ÇÂ²ÒÀÌ ÑÌÀĞÒ ÍÀ ÎÑÍÎÂ² ÍÀÇÂÈ ÔÀÉËÓ
select t4.*, t3.*, t2.*
from Reports t1
	join MediaService..Register t2 on t1.FileName = t2.FileName
	join MediaService..PaidPeriod t3 on t2.periodId = t3.PeriodId
	join MediaService..vCustomerNamesShort t4 on t2.custId = t4.CustId
where t1.FileName = t2.FileName
	and t1.Id = @reportId

--rollback tran
--select * from MediaService..RegisterItem
--exec sp_help 'ReportLines';

end