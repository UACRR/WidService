use SocWidSubmit
go

drop table if exists WidSubmGroupWorkCheckList
go

create table WidSubmGroupWorkCheckList (
	  Id					int identity(1,1) not null primary key clustered
	, WidSubmGroupId		int not null
	, ObjId					int not null
	, HasOwnAuthor			bit not null
	, RolesDefined			bit not null
	, HasNonPublisher		bit not null
	, AllInIpi				bit not null
	, PubShare0or100		bit not null
	, MecShare0or100		bit not null
	, HasShare				bit not null
	, NamesApproved			bit not null
	, PerformersApproved	bit not null
	, AllIpiCodesValid		bit not null
)

go

alter table WidSubmGroupWorkCheckList 
add constraint fk_WidSubmGroupWorkCheckList_WidSubmGroup
foreign key (WidSubmGroupId) references WidSubmGroup (Id)

go
