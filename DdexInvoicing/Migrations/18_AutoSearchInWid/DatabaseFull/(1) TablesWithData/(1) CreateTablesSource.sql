use AutoSearch
go

-- =================================== ¬’≤ƒÕ¿ ≤Õ‘Œ–Ã¿÷≤ﬂ ≤« «¬≤“”
-- SourceWorks
drop table if exists SourceWorks
create table SourceWorks (
	  SourceWorkId int primary key identity(1, 1)
	, WorkId int
	, Name nvarchar(261)
	, Authors nvarchar(2054)
	, Performers nvarchar(2054)
)
create nonclustered index idx_SourceWorks_WorkId on SourceWorks(WorkId)
create nonclustered index idx_SourceWorks_Name on SourceWorks(Name)

-- SourceNames
drop table if exists SourceNames
create table SourceNames (
	  SourceNameId int primary key identity (1, 1)
	, Name nvarchar(261)
)
create nonclustered index idx_SourceNames_Name on SourceNames(Name)

-- SourceNamesT
drop table if exists SourceNamesT
create table SourceNamesT (
	  SourceNameId int primary key
	, Name nvarchar(261)
)
create nonclustered index idx_SourceNamesT_Name on SourceNamesT(Name)

-- SourceNameWorks
drop table if exists SourceNameWorks
create table SourceNameWorks (
	  SourceNameId int not null
	, WorkId int not null
)
create nonclustered index idx_SourceNameWorks_SourceNameId on SourceNameWorks(SourceNameId)
create nonclustered index idx_SourceNameWorks_WorkId on SourceNameWorks(WorkId)
alter table SourceNameWorks add primary key (SourceNameId, WorkId)

drop table if exists SourcePerformerParts
create table SourcePerformerParts (
		SourcePerformerPartId int primary key identity (1, 1)
	, WorkId int
	, Name nvarchar(64)
)
create nonclustered index idx_SourcePerformerParts_Name on SourcePerformerParts(Name)

drop table if exists SourceAuthorParts
create table SourceAuthorParts (
		SourceAuthorPartId int primary key identity (1, 1)
	, WorkId int
	, Name nvarchar(64)
)
create nonclustered index idx_SourceAuthorParts_Name on SourceAuthorParts(Name)

