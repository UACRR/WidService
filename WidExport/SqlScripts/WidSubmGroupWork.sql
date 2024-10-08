use SocWidSubmit
go

drop table if exists WidSubmGroupWork
go

create table WidSubmGroupWork (
	  Id					int identity(1,1) not null primary key clustered
	, WidSubmGroupId		int not null
	, ObjId					int not null
	, Status				int not null
	, SubmFileId			int null
	, RecWiaId				int null
	, ShouldResubmit		bit null
	, ReSubmitIswc			varchar(11) not null
)
go

alter table WidSubmGroupWork 
add constraint fk_WidSubmGroupWork_WidSubmGroup
foreign key (WidSubmGroupId) references WidSubmGroup (Id)

alter table WidSubmGroupWork 
add constraint fk_WidSubmGroupWorkStatus_WidSubmGroupWorkStatus
foreign key (Status) references WidSubmGroupWorkStatus (Id)

alter table WidSubmGroupWork 
add constraint fk_WidSubmGroupWork_SubmFile
foreign key (SubmFileId) references SubmFile (Id)

alter table WidSubmGroupWork 
add constraint fk_WidSubmGroupWork_RecWia
foreign key (RecWiaId) references RecWia (Id)

go

