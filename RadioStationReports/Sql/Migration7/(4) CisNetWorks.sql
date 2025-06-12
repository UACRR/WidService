use MediaService
go

drop table if exists CisNetWorks
create table CisNetWorks (
	  ObjId int primary key
	, WorkCode varchar(50) not null
	, CreatedAt datetime not null
)
go

alter table CisNetWorks
add constraint fk_CisNetWorks_ObjId
foreign key (ObjId) references ObjectRight(ObjId)
go