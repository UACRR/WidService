use SocCisNet
go

drop table if exists Works
create table Works (
	  WorkCode varchar(50) primary key
	, Name varchar(128) not null
	, Iswc varchar(11)
	, SrcWorkId int
	, SrcSocCde int
	, SrcDbCde int
	, RefWorkCde int null
	, SubmittedAt datetime null
	, CreatedAt datetime null
	, UpdatedAt datetime null
	, LoadedAt  datetime null
)
go

