use SocCisNet
go

drop table if exists WorkSubmissions
create table WorkSubmissions (
	  Id int primary key identity(1, 1)
	, SrcWorkId int
	, SrcSocCde int
	, TranCde varchar(3)
	, UpdatedAt datetime
	, WorkCode varchar(50) not null
)
go

alter table WorkSubmissions
add constraint fk_WorkSubmissions_WorkCode
foreign key (WorkCode) references Works(WorkCode)
go

