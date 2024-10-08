use SocWidSubmit
go

drop table if exists ObjIdToWic
go

create table ObjIdToWic (
	  ObjId int primary key clustered not null
	, Wic int not null
	, Iswc varchar(11) null
	, Source int null
)

alter table ObjIdToWic 
add constraint fk_ObjIdToWic_Source
foreign key (Source)
references ObjIdToWicSource(Id)
go

