use SocIpiEx
go

drop table if exists LastProcessedUpdateFile
create table LastProcessedUpdateFile (
	Name char(8)
)
insert LastProcessedUpdateFile values(null)
go

drop table if exists AgreeTerrs
create table AgreeTerrs (
	  IpAgreeNr varchar(41) primary key clustered
	, IpBaseNr varchar(13)
	, Terr varchar(max)
)
go

drop table if exists Agree
create table Agree (
	  Id		int primary key nonclustered
	, IpBaseNr	varchar(13)
	, SocCde	char(3)
	, RgtCde	char(2)
	, RolCde	char(2)
	, Terr		varchar(max)
	, IsUkraine bit
)
go

drop table if exists RhUkr
create table RhUkr (
	  IpBaseNr	varchar(13) primary key nonclustered
)
go

drop table if exists RhNoUkr
create table RhNoUkr (
	  IpBaseNr	varchar(13) primary key nonclustered
)
go

drop table if exists RhRao
create table RhRao (
	  IpBaseNr	varchar(13) primary key nonclustered
)
go

drop table if exists RhExtraPay
create table RhExtraPay (
	  IpBaseNr	varchar(13) primary key nonclustered
)
go