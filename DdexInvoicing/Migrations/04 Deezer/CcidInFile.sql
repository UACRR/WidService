if not exists (select null from sys.columns where Name = N'ddexReportId' and Object_Id = Object_Id(N'CcidInFile'))
alter table CcidInFile
add ddexReportId int null references DdexReport(id);alter table CcidInHeader alter column receiver varchar(50)
