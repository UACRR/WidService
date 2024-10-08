use SocWidSubmit
go

drop table if exists SubmFile
go

create table SubmFile (
	Id int identity(1,1) not null primary key clustered,
	Name varchar(32) null,
	Year int not null,
	Month int not null,
	Day int not null,
	SubmFileStatus int not null,
	WidSubmGroupId int null
)
go

alter table SubmFile 
add constraint fk_SubmFile_SubmFileStatus
foreign key (SubmFileStatus)
references SubmFileStatus(Id)

alter table SubmFile 
add constraint fk_SubmFile_WidSubmGroupId
foreign key (WidSubmGroupId)
references WidSubmGroup(Id)
-- insert into SubmFile(Name, Year, Month) values ('PendingSubmissions', 0, 0, 0)
go


