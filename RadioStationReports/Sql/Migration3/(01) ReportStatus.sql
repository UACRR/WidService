use RadioStationReports
go

create table ReportStatus (
	  Id int primary key
	, Code varchar(16)
	, Description nvarchar(64)
)

insert ReportStatus(Id, Code, Description)
values
	  (0, 'Loading', '')
	, (1, 'Loaded', '')
	, (2, 'Checked', '')
	, (3, 'Distributed', '')