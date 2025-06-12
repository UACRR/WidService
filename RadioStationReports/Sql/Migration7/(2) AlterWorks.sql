use RadioStationReports
go

--alter table Works
--drop column CisNetWorkId

alter table Works
add CisNetWorkCode varchar(50) null
go