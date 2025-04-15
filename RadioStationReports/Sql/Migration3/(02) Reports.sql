use RadioStationReports
go

-- drop table Reports
alter table Reports
add Status int default(0)
go

alter table Reports
add constraint fk_Report_Status foreign key (Status)
references ReportStatus(Id)
go

update Reports set Status = 1
go


