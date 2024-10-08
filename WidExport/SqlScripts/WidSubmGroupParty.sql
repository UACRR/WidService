use SocWidSubmit
go

drop table if exists WidSubmGroupParty
go

create table WidSubmGroupParty (
	  Id				int identity(1,1) not null primary key clustered
	, WidSubmGroupId	int not null
	, CustId			int not null
	, IpBaseNr			varchar(13) not null
	, IpNameNr			int not null
)
go

alter table WidSubmGroupParty 
add constraint fk_WidSubmGroupParty_WidSubmGroup
foreign key (WidSubmGroupId) references WidSubmGroup (Id)
go
