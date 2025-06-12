use SocCisNet
go

drop table if exists WorkPerformers
create table WorkPerformers (
	  Id int primary key identity(1, 1)
	, FstName varchar(128)
	, LstName varchar(128)
	, WorkCode varchar(50) not null
)
go

alter table WorkPerformers
add constraint fk_WorkPerformers_WorkCode
foreign key (WorkCode) references Works(WorkCode)
go

