use SocCisNet
go

drop table if exists WorkAltNames
create table WorkAltNames (
	  Id int primary key identity(1, 1)
	, Name varchar(128) not null
	, NameType char(2)
	, Lan char(2)
	, WorkId int not null
)
go

alter table WorkAltNames
add constraint fk_WorkAltNames_WorkId
foreign key (WorkId) references Works(WorkId)
go

