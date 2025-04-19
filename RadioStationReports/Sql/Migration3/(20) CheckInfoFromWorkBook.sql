use RadioStationReports
go

create table CheckInfoFromWorkBook (
	  Id int primary key
	, Name nvarchar(128)
	, Performers nvarchar(128)
	, CheckValue int
)