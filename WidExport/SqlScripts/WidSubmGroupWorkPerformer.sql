use SocWidSubmit
go

drop table if exists WidSubmGroupWorkPerformer
go

create table WidSubmGroupWorkPerformer (
	  Id					int identity(1,1) not null primary key clustered
	, SeekObjectId			int null
	, WidSubmGroupId		int not null
	, ObjId					int
	, LocalName				nvarchar(100) not null
	, WidName				varchar(35) not null
	, IsConfirmed			bit not null
	, IsDuplicate			bit not null
	, CreatedBy				varchar(10) not null
	, ModifiedBy			varchar(10) not null
	, CreatedAt				datetime not null
	, ModifiedAt			datetime not null
	, RecPerId				int null
)
go

alter table WidSubmGroupWorkPerformer 
add constraint fk_WidSubmGroupWorkPerformer_WidSubmGroup
foreign key (WidSubmGroupId) references WidSubmGroup (Id)

alter table WidSubmGroupWorkPerformer 
add constraint fk_WidSubmGroupWorkPerformer_RecPer
foreign key (RecPerId) references RecPer (Id)

go
