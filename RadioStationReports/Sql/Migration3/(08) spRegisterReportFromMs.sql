use RadioStationReports
go

create or alter procedure spRegisterReportFromMs
	  @regId int
	, @reportId int output
as
begin

--begin tran
--declare @regId int = 9427

-- ÂÈÄÀËßªÌÎ ÇÀĞÅªÑÒĞÎÂÀÍÈÉ ÇÂ²Ò ßÊÙÎ ÇÀÂÀÍÒÀÆÅÍÍß ÍÅ ÇÀÂÅØÈËÎÑÜ
declare @oldReportId int = (
	select t1.Id
	from Reports t1
		join ReportIdToRegId t2 on t1.Id = t2.ReportId
	where t2.RegId = @regId
		and t1.Status = 0
)

if @oldReportId is not null
begin
	exec spDeleteReport @oldReportId
end

-- ÑÒÂÎĞŞªÌÎ ²ÍÔÎĞÌÀÖ²Ş ÄËß ÇÀÂÀÍÒÀÆÅÍÍß
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
	, Status
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
	, 0								as Status
from MediaService..Register t1
	join MediaService..PaidPeriod t2 on t1.periodId = t2.periodId
where t1.RegId = @regId

set @reportId = scope_identity()

-- ÑÒÂÎĞŞªÌÎ ÇÀÏÈÑÈ ÄËß ĞßÄÊ²Â ÇÂ²ÒÓ
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

-- ÑÒÂÎĞŞªÌÎ Â²ÄÏÎÂ²ÄÍ²ÑÒÜ ÇÂ²ÒÓ ÄÎÄÀÒÊÓ ÇÂ²ÒÀÌ ÑÌÀĞÒ ÍÀ ÎÑÍÎÂ² ÍÀÇÂÈ ÔÀÉËÓ
insert ReportIdToRegId (ReportId, RegId)
select @reportId, t2.RegId
from Reports t1
	join MediaService..Register t2 on t1.FileName = t2.FileName
where t1.Id = @reportId

-- ÑÒÂÎĞŞªÌÎ ÏÎÑÈËÀÍÍß ÍÀ ĞÀÄ²ÎÑÒÀÍÖ²Ş
declare @customerName nvarchar(max) = (
	select t2.ShortName 
	from MediaService..Register t1
		join MediaService..vCustomerNamesShort t2 on t1.CustId = t2.CustId
	where t1.RegId = @regId
)
declare @radioStationId int = (
	select Id 
	from RadioStations
	where Name = @customerName
)

if @radioStationId is null
begin
	insert RadioStations(Name) values(@customerName)
	set @radioStationId = scope_identity()
end

update Reports set RadioStationId = @radioStationId where Id = @reportId

--select * from ReportLines where ReportId = @reportId and isnull(WorkId, 0) = 0


--rollback tran
--select * from MediaService..RegisterItem
--exec sp_help 'ReportLines';

end