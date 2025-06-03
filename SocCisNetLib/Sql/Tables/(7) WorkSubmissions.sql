use SocCisNet
go

drop table if exists WorkSubmissions
create table WorkSubmissions (
	  Id int primary key identity(1, 1)
	, SrcWorkId int
	, SrcSocCde int
	, TranCde varchar(3)
	, UpdatedAt datetime
	, WorkId int not null
)
go

alter table WorkSubmissions
add constraint fk_WorkSubmissions_WorkId
foreign key (WorkId) references Works(WorkId)
go

