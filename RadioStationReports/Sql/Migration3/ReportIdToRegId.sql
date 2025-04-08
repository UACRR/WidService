use RadioStationReports
go

create table ReportIdToRegId (
	  ReportId int primary key nonclustered
	, RegId int not null
)