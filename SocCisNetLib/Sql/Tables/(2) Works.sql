use SocCisNet
go

drop table if exists Works
create table Works (
	  WorkId int primary key
	, Name varchar(128) not null
	, Iswc varchar(11)
	, SrcWorkId int
	, SrcSocCde int
	, SrcDbCde int
	, RefWorkCde int null
	, SubmittedAt datetime not null
	, CreatedAt datetime not null
	, UpdatedAt datetime not null
	, LoadedAt  datetime not null
)
go

