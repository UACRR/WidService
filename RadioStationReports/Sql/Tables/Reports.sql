use RadioStationReports
go

-- drop table Reports

create table Reports (
	  Id							int				identity(1, 1) not null primary key clustered
	, FileName						nvarchar(100)	not null
	, FilePath						nvarchar(1028)	null
	, SearchFileName				nvarchar(100)	not null
	, DistributionFileName			nvarchar(100)	not null
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


