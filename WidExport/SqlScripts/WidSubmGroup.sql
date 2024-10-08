use SocWidSubmit
go

drop table if exists WidSubmGroup
go

create table WidSubmGroup (
	  Id int identity(1,1) not null primary key clustered
	, SeqNr int not null
	, Name nvarchar(100) not null
	, Status int not null
)

alter table WidSubmGroup 
add constraint fk_WidSubmGroup_WidSubmGroupStatus
foreign key (Status) references WidSubmGroupStatus (Id)
go

