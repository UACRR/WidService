use SocWidSubmit
go

drop table if exists RespFile
go

create table RespFile (
	Id int identity(1,1) not null primary key clustered,
	Name varchar(32) null,
	Year int not null,
	Month int not null,
	Day int not null,
)
go


