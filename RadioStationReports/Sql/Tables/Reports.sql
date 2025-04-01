use RadioStationReports
go

-- drop table Reports

create table Reports (
	  Id							int				identity(1, 1) not null primary key clustered
	, RadioStationId				int				null
	, StartYear						int				null
	, StartMonth					int				null
	, EndYear						int				null
	, EndMonth						int				null
	, FileName						nvarchar(100)	not null
	, FilePath						nvarchar(1028)	null
	, WorkFilesPath					nvarchar(1028)	not null
	, SourceFileCopyName			nvarchar(100)	not null
	, SearchFileName				nvarchar(100)	not null
	, DistributionFileName			nvarchar(100)	not null
	, CheckFileName					nvarchar(100)	not null
	, IsArchived					bit				not null default(0)
	, CreatedAt						datetime		null
	, UpdatedAt						datetime		null
	, AutoSearchFinishedAt			datetime		null
	, CalcRoyaltyFinishedAt			datetime		null
	, SearchFileCreatedAt			datetime		null
	, SearchFileUpdatedAt			datetime		null
	, SearchFileImportedAt			datetime		null
	, DistributionFileCreatedAt		datetime		null
	, DistributionFileUpdatedAt		datetime		null
)
go

alter table Reports
add constraint fk_Report_RadioStation foreign key (RadioStationId)
references RadioStations(Id)
go


