use SocCisNet
go

drop table if exists PackageWorks
create table PackageWorks (
	  Id int primary key identity(1, 1)
	, PackageId int not null
	, WorkId int not null

)
go

alter table PackageWorks
add constraint fk_PackageWorks_PackageId
foreign key (PackageId) references Packages(PackageId)
go

alter table PackageWorks
add constraint fk_PackageWorks_WorkId
foreign key (WorkId) references Works(WorkId)
go

alter table PackageWorks
add constraint uc_PackageWorks_PackageId_WorkId unique (PackageId, WorkId)
go


