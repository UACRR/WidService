use RadioStationReports
go

create table SearchFileImportBuf (
	  ReportId int not null
	, ObjId int null
	, Wic int null
	, Iswc varchar(13) not null
	, LineNr int not null
)
go
