drop table if exists DdexEnumRightsType
go

create table dbo.DdexEnumRightsType(
	codeI int not null primary key clustered,
	codeName varchar(15) NOT NULL,
	name varchar(15) NOT NULL)
go

insert DdexEnumRightsType
values (0, 'MechanicalRight', 'MechanicalRight'),
		(1, 'PerformingRight', 'PerformingRight')
go
