use SmartWorkSearch
go

--drop table SourceWorks

create table SourceWorks (
	  Id int primary key identity(1, 1)
	, Name nvarchar(max) not null
	, Authors nvarchar(max) not null
	, Performers nvarchar(max) not null
	, Iswc varchar(20)
	, Source varchar(10) null
	, CreatedAt datetime not null
	, UpdatedAt datetime not null
)


