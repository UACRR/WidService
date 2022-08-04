drop table if exists DdexAdjConsolidatedSummary
go

create table DdexAdjConsolidatedSummary(
	DdexReportId int not null,
	SummaryRecordId varchar(100) not null,
	AllocatedUsages decimal(20, 6) null,
	AllocatedRevenue decimal(20, 6) null,
	RightsType varchar(100) null,
	ContentCategory varchar(100) null,
	constraint PK_DdexAdjConsolidatedSummary primary key clustered
	(
		DdexReportId ASC,
		SummaryRecordId ASC
	)
)
go


