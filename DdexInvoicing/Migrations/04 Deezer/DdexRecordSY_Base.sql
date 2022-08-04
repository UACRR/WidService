drop table if exists DdexRecordSY_Base
go

create table DdexRecordSY_Base (
	DdexReportId int NOT NULL,
	RecordIndex int NOT NULL,
	SummaryRecordId varchar(100) NULL,
	DistributionChannel varchar(100) NULL,
	DistributionChannelDPID varchar(100) NULL,
	CommercialModel varchar(100) NULL,
	UseType varchar(100) NULL,
	Territory varchar(100) NULL,
	ServiceDescription varchar(100) NULL,
	Usages int NULL,
	Subscribers decimal(20, 2) NULL,
	Currency varchar(100) NULL,
	NetRevenue decimal(20, 6) NULL,
	IndirectNetRevenue decimal(20, 6) NULL,
	constraint PK_DdexRecordSY_01 primary key clustered
	(
		DdexReportId asc,
		RecordIndex asc
	)
)
go


