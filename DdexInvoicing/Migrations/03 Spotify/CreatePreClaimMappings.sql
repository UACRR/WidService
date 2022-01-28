drop table if exists PreClaimMappings;
go

create table PreClaimMappings (
	  dspReleaseId varchar(60) primary key nonclustered
	, mwId int not null
	, wic int null
	, objId int null
	, rateTotalPER decimal(5, 2) null
	, rateTotalMEC decimal(5, 2) null
)