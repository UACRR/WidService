use SocCisNet
go

drop table if exists WorkPerformers
create table WorkPerformers (
	  Id int primary key identity(1, 1)
	, FstName varchar(128)
	, LstName varchar(128)
	, WorkId int not null
)
go

alter table WorkPerformers
add constraint fk_WorkPerformers_WorkId
foreign key (WorkId) references Works(WorkId)
go

