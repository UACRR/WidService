use SocCisNet
go

drop table if exists Packages
create table Packages (
	  PackageId int primary key
	, CreatedAt datetime not null
	, LoadedAt  datetime not null
)
go


