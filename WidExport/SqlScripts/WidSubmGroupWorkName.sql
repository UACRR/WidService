use SocWidSubmit
go

drop table if exists WidSubmGroupWorkName
go

create table WidSubmGroupWorkName (
	  Id					int identity(1,1) not null primary key clustered
	, SeekObjectId			int null
	, WidSubmGroupId		int not null
	, ObjId					int
	, LocalName				nvarchar(100) not null
	, WidName				varchar(60) not null
	, IsMain				bit not null
	, IsConfirmed			bit not null
	, IsDuplicate			bit not null
	, CreatedBy				varchar(10) not null
	, ModifiedBy			varchar(10) not null
	, CreatedAt				datetime not null
	, ModifiedAt			datetime not null
	, RecAltId				int null
)
go

alter table WidSubmGroupWorkName 
add constraint fk_WidSubmGroupWorkName_WidSubmGroup
foreign key (WidSubmGroupId) references WidSubmGroup (Id)

alter table WidSubmGroupWorkName 
add constraint fk_WidSubmGroupWorkName_RecAlt
foreign key (RecAltId) references RecAlt (Id)

go
