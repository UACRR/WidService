drop table if exists DdexEnumContentCategory
go

create table dbo.DdexEnumContentCategory(
	codeI int not null primary key clustered,
	codeName varchar(7) NOT NULL,
	name varchar(7) NOT NULL)
go

insert DdexEnumContentCategory
values (0, 'Music', 'Music'),
		(1, 'GEMusic', 'GEMusic'),
		(2, 'GE', 'GE')
go
