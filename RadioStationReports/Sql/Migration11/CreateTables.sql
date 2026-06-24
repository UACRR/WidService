use SocCisNet
go

drop table if exists WorkPerformers
drop table if exists WorkAltNames
drop table if exists WorkShares
drop table if exists Works
drop table if exists SingleWorkDownloads
go

create table SingleWorkDownloads (
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

create table Works (
        id int primary key identity (1, 1)
	  , SingleWorkDownloadId int
      , SocWorkCode varchar (32)
      , SocCode     varchar (3)
      , SourceDb    varchar (32)
      , Name        varchar (256)
      , Iswc        varchar (11)
	  , CreatedAt datetime
)

alter table Works add constraint fk_Works_SingleWorkDownloadId foreign key(SingleWorkDownloadId) references SingleWorkDownloads(Id)
go

create table WorkShares (
      id int primary key identity (1, 1)
    , WorkId int
	, IpName   varchar(256)
	, IpBaseNr varchar(13)
	, IpNameNr varchar(16)
	, IpRole   varchar(2)
	, PerSoc   varchar(3)
	, PerShr   decimal(5, 2)
	, MecSoc   varchar(3)
	, MecShr   decimal(5, 2)
	, CreatedAt datetime
)

alter table WorkShares add constraint fk_WorkShares_WorkId foreign key(WorkId) references Works(Id)
go

create table WorkAltNames (
      id int primary key identity (1, 1)
    , WorkId int
	, Name   varchar(256)
	, CreatedAt datetime
)

alter table WorkAltNames add constraint fk_WorkAltNames_WorkId foreign key(WorkId) references Works(Id)
go

create table WorkPerformers (
      id int primary key identity (1, 1)
    , WorkId int
	, Name   varchar(256)
	, CreatedAt datetime
)

alter table WorkPerformers add constraint fk_WorkPerformers_WorkId foreign key(WorkId) references Works(Id)
go



