use RadioStationReports
go

--drop table ReportIdToRegId
create table ReportIdToRegId (
	  ReportId int not null
	, RegId int not null
	, primary key (ReportId, RegId)
)