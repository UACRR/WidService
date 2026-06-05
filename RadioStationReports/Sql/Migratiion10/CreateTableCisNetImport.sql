use RadioStationReports
go

drop table if exists CisNetImport
create table CisNetImport (
      id int primary key identity (1, 1)
	, FileName varchar(100)
    , XmlData xml
	, XmlDataHash as cast(hashbytes('sha2_256', cast(Xmldata as varchar(max))) as varbinary(32)) persisted
	, CreatedAt datetime
	, ObjId int
)
go
