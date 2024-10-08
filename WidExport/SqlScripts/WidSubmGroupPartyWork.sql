use SocWidSubmit
go

drop table if exists WidSubmGroupPartyWork
go

create table WidSubmGroupPartyWork (
	  Id int identity(1,1) not null primary key clustered
	, WidSubmGroupId int not null
	, IpNameNr int not null
	, ObjId int not null
)
go

alter table WidSubmGroupPartyWork 
add constraint fk_WidSubmGroupPartyWork_WidSubmGroup
foreign key (WidSubmGroupId) references WidSubmGroup (Id)
go

