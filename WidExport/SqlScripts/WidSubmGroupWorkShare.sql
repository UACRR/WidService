use SocWidSubmit
go

drop table if exists WidSubmGroupWorkShare
go

create table WidSubmGroupWorkShare (
	  Id					int identity(1,1) not null primary key clustered
	, WidSubmGroupId		int not null
	, ObjId					int not null
	, CopyRightId			int not null
	, CustId				int not null
	, IpBaseNr				varchar(13) null
	, IpNameNr				int null
	, RhType				int not null
	, RhRole				int not null
	, PerShr				decimal(5, 2) not null
	, MecShr				decimal(5, 2) not null
	, AggrLocal				bit not null
	, AggrIpiPer			bit not null
	, AggrIpiMec			bit not null
	, CreatedBy				varchar(10) not null
	, ModifiedBy			varchar(10) not null
	, CreatedAt				datetime not null
	, ModifiedAt			datetime not null
	, RecSipId				int null
	, RecSsrPerId			int null
	, RecSsrMecId			int null
	, RecOipId				int null
	, RecOsrPerId			int null
	, RecOsrMecId			int null
	, AggrInvert			bit null
)
go

alter table WidSubmGroupWorkShare 
add constraint fk_WidSubmGroupWorkShare_WidSubmGroup
foreign key (WidSubmGroupId) references WidSubmGroup (Id)

alter table WidSubmGroupWorkShare 
add constraint fk_WidSubmGroupWorkShare_RecSip
foreign key (RecSipId) references RecSip (Id)

alter table WidSubmGroupWorkShare 
add constraint fk_WidSubmGroupWorkShare_RecSsrPer
foreign key (RecSsrPerId) references RecSsr (Id)

alter table WidSubmGroupWorkShare 
add constraint fk_WidSubmGroupWorkShare_RecSsrMec
foreign key (RecSsrMecId) references RecSsr (Id)

alter table WidSubmGroupWorkShare 
add constraint fk_WidSubmGroupWorkShare_WidSubmGroup
foreign key (WidSubmGroupId) references WidSubmGroup (Id)

alter table WidSubmGroupWorkShare 
add constraint fk_WidSubmGroupWorkShare_RecOip
foreign key (RecOipId) references RecOip (Id)

alter table WidSubmGroupWorkShare 
add constraint fk_WidSubmGroupWorkShare_RecOsrPer
foreign key (RecOsrPerId) references RecOsr (Id)

alter table WidSubmGroupWorkShare 
add constraint fk_WidSubmGroupWorkShare_RecOsrMec
foreign key (RecOsrMecId) references RecOsr (Id)

go
