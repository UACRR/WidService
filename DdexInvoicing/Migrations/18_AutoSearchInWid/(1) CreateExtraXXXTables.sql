use AutoSearch
go

-- ExtraTargetWorks
drop table if exists ExtraTargetWorks
create table ExtraTargetWorks (
	  TargetWorkId int primary key
	, WorkId int
	, Name nvarchar(261)
	, Authors nvarchar(2054)
	, Performers nvarchar(2054)
)
create nonclustered index idx_ExtraTargetWorks_WorkId on ExtraTargetWorks(WorkId)
create nonclustered index idx_ExtraTargetWorks_Name on ExtraTargetWorks(Name)
create unique nonclustered index idx_ExtraTargetWorks_WorkId_Name on ExtraTargetWorks(WorkId, Name)

-- ExtraTargetNames
drop table if exists ExtraTargetNames
create table ExtraTargetNames (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create nonclustered index idx_ExtraTargetNames_Name on ExtraTargetNames(Name)

-- ExtraTargetNamesT
drop table if exists ExtraTargetNamesT
create table ExtraTargetNamesT (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create nonclustered index idx_ExtraTargetNamesT_Name on ExtraTargetNamesT(Name)

-- ExtraTargetNameWorks
drop table if exists ExtraTargetNameWorks
create table ExtraTargetNameWorks (
	  TargetNameId int
	, WorkId int
)
create nonclustered index idx_ExtraTargetNameWorks_TargetNameId on ExtraTargetNameWorks(TargetNameId)
create nonclustered index idx_ExtraTargetNameWorks_WorkId on ExtraTargetNameWorks(WorkId)

-- PERFORMERS
drop table if exists ExtraTargetPerformerParts
create table ExtraTargetPerformerParts (
	  TargetPerformerPartId int primary key
	, Name nvarchar(64)
)
create nonclustered index idx_ExtraTargetPerformerParts_Name on ExtraTargetPerformerParts(Name)

drop table if exists ExtraTargetPerformerPartWorks
create table ExtraTargetPerformerPartWorks (
	  TargetPerformerPartId int
	, WorkId int
)
create nonclustered index idx_ExtraTargetPerformerPartWorks_TargetPerformerPartWorks on ExtraTargetPerformerPartWorks(TargetPerformerPartId)
create nonclustered index idx_ExtraTargetPerformerPartWorks_WorkId on ExtraTargetPerformerPartWorks(WorkId)
create unique nonclustered index idx_ExtraTargetPerformerPartWorks_TargetPerformerPartId_WorkId on ExtraTargetPerformerPartWorks(TargetPerformerPartId, WorkId)

-- Author
drop table if exists ExtraTargetAuthorParts
create table ExtraTargetAuthorParts (
	  TargetAuthorPartId int primary key
	, Name nvarchar(64)
)
create nonclustered index idx_ExtraTargetAuthorParts_Name on ExtraTargetAuthorParts(Name)

drop table if exists ExtraTargetAuthorPartWorks
create table ExtraTargetAuthorPartWorks (
	  TargetAuthorPartId int
	, WorkId int
)
create nonclustered index idx_ExtraTargetAuthorPartWorks_TargetAuthorPartWorks on ExtraTargetAuthorPartWorks(TargetAuthorPartId)
create nonclustered index idx_ExtraTargetAuthorPartWorks_WorkId on ExtraTargetAuthorPartWorks(WorkId)
create unique nonclustered index idx_ExtraTargetAuthorPartWorks_TargetAuthorPartId_WorkId on ExtraTargetAuthorPartWorks(TargetAuthorPartId, WorkId)


