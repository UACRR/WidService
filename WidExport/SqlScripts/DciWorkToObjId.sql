use SocWidSubmit
go

drop table if exists DciWorkToObjId
go

create table DciWorkToObjId (
	WorkId int not null primary key,
	Wic int not null,
	SocWorkCde varchar(20) null,
	WidName varchar(120) null,
	WidIswc varchar(11) null,
	WidAuthor varchar(136) null,
	ObjId int not null,
	Status int not null
)
go

