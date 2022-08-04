drop table if exists DdexAdjConsolidatedDetail
go

create table DdexAdjConsolidatedDetail(
	DdexReportId int not null,
	SalesTransactionId varchar(100) not null,
	AllocatedUsages decimal(20, 6) not null,
	AllocatedRevenue decimal(20, 6) not null,
	RightsType int not null,
	ContentCategory int not null,
	AllocatedRevenueCompensated decimal(20, 6) not null,
	WorkCode varchar(39) null,
	constraint pk_DdexAdjConsolidatedDetail PRIMARY KEY CLUSTERED 
	(
		DdexReportId,
		SalesTransactionId,
		RightsType
	)
)
go


