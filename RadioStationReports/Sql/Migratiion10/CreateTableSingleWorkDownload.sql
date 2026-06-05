use SocCisNet
go

drop table if exists SingleWorkDownload
create table SingleWorkDownload (
      id int primary key identity (1, 1)
	, SocCode varchar(16)
	, SourceDb varchar(16)
	, SocWorkCode varchar(32)
    , XmlData xml
	, XmlDataHash as cast(hashbytes('sha2_256', cast(Xmldata as varchar(max))) as varbinary(32)) persisted unique
	, CreatedAt datetime
	, ObjId int
)
go
