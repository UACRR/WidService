use SocCisNet
go

drop table if exists PackageWorks
create table PackageWorks (
	  Id int primary key identity(1, 1)
	, PackageId int not null
	, WorkCode varchar(50) not null

)
go

alter table PackageWorks
add constraint fk_PackageWorks_PackageId
foreign key (PackageId) references Packages(PackageId)
go

alter table PackageWorks
add constraint fk_PackageWorks_WorkCode
foreign key (WorkCode) references Works(WorkCode)
go

alter table PackageWorks
add constraint uc_PackageWorks_PackageId_WorkCode unique (PackageId, WorkCode)
go


