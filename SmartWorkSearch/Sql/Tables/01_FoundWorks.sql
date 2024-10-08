use SmartWorkSearch
go

-- drop table FoundWorks
create table FoundWorks (
	  Id int primary key identity(1, 1)
	, SourceWorkId int not null
	, Name nvarchar(100) null
	, Authors nvarchar(256) null
	, Performers nvarchar(256) null
	, FoundIn varchar(5) not null -- now either MS or WID
	, FoundCde int not null -- now that is either objId or wic
	, ObjId int null -- in case of WID object replica created from WID
	, ValidFrom date not null
	, ValidTo date not null
	, CreatedAt datetime not null
)

alter table FoundWorks
add constraint fk_FoundWorks_SourceWorkId
foreign key (SourceWorkId) references SourceWorks(Id);

