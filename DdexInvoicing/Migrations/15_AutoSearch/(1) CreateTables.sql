use AutoSearch
go

-- =================================== ВХІДНА ІНФОРМАЦІЯ ІЗ ЗВІТУ
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
	, ObjId int
	, Wic int
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

-- =================================== РОБОЧА ІНФОРМАЦІЯ ДЛЯ ОНОВЛЕННЯ ІНФОРМАЦІЇ ДЛЯ ПОШУКУ
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


-- TargetNames
drop table if exists ExtraTargetNames
create table ExtraTargetNames (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create nonclustered index idx_ExtraTargetNames_Name on ExtraTargetNames(Name)

-- TargetNamesT
drop table if exists ExtraTargetNamesT
create table ExtraTargetNamesT (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create nonclustered index idx_ExtraTargetNamesT_Name on ExtraTargetNamesT(Name)

-- TargetNameWorks
drop table if exists ExtraTargetNameWorks
create table ExtraTargetNameWorks (
	  TargetNameId int
	, WorkId int
	, ObjId int
	, Wic int
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

-- AuthorS
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


-- =================================== ІНФОРМАЦІЯ ДЛЯ ПОШУКУ
-- TargetWorks
drop table if exists TargetWorks
create table TargetWorks (
	    TargetWorkId int primary key
	 ,  WorkId int
)

-- TargetNames
drop table if exists TargetNames
create table TargetNames (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create unique nonclustered index idx_TargetNames_Name on TargetNames(Name)

-- TargetNamesT
drop table if exists TargetNamesT
create table TargetNamesT (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create nonclustered index idx_TargetNamesT_Name on TargetNamesT(Name)

-- TargetNameWorks
drop table if exists TargetNameWorks
create table TargetNameWorks (
	  TargetNameId int
	, WorkId int
	, ObjId int
	, Wic int
)
create nonclustered index idx_TargetNameWorks_TargetNameId on TargetNameWorks(TargetNameId)
create nonclustered index idx_TargetNameWorks_WorkId on TargetNameWorks(WorkId)
create nonclustered index idx_TargetNameWorks_TargetNameId_WorkId on TargetNameWorks(TargetNameId, WorkId)
alter table TargetNameWorks add constraint fk_TargetNameWorks_TargetNameId foreign key (TargetNameId) references TargetNames(TargetNameId);


drop table if exists TargetPerformerParts
create table TargetPerformerParts (
	  TargetPerformerPartId int primary key
	, Name nvarchar(64)
)
create unique nonclustered index idx_TargetPerformerParts_Name on TargetPerformerParts(Name)

drop table if exists TargetPerformerPartWorks
create table TargetPerformerPartWorks (
	  TargetPerformerPartId int
	, WorkId int
)
create nonclustered index idx_TargetPerformerPartWorks_TargetPerformerPartWorks on TargetPerformerPartWorks(TargetPerformerPartId)
create nonclustered index idx_TargetPerformerPartWorks_WorkId on TargetPerformerPartWorks(WorkId)

drop table if exists TargetAuthorParts
create table TargetAuthorParts (
	  TargetAuthorPartId int primary key
	, Name nvarchar(64)
)
create nonclustered index idx_TargetAuthorParts_Name on TargetAuthorParts(Name)

drop table if exists TargetAuthorPartWorks
create table TargetAuthorPartWorks (
	  TargetAuthorPartId int
	, WorkId int
)
create nonclustered index idx_TargetAuthorPartWorks_TargetAuthorPartWorks on TargetAuthorPartWorks(TargetAuthorPartId)
create nonclustered index idx_TargetAuthorPartWorks_WorkId on TargetAuthorPartWorks(WorkId)

-- РЕЗУЛЬТАТИ ПОШУКУ
drop table if exists FoundNamesInIdentMw
create table FoundNamesInIdentMw(
	  SourceNameId int
	, TargetNameId int
	, SearchType varchar(10)
)

drop table if exists FoundWorksInIdentMw
create table FoundWorksInIdentMw(
	  SourceWorkId int
	, TargetWorkId int
)

-- МОНІТОРИНГ
drop table if exists SearchSteps
create table SearchSteps (
	  Id int primary key identity(1, 1)
	, Name varchar(100)
	, Status int
)

insert SearchSteps (Name, Status)
values
	  ('Заповнення таблиці SourceWorks', 0)
	, ('Заповнення таблиці SourceNames', 0)
	, ('Заповнення таблиці SourceNamesT', 0)
	, ('Заповнення таблиці SourceNameWorks', 0)
	, ('Заповнення таблиці SourcePerformerParts', 0)
	, ('Заповнення таблиці SourcePerformerParts - transliterate', 0)
	, ('Заповнення таблиці SourceAuthorParts', 0)
	, ('Заповнення таблиці SourceAuthorParts - transliterate', 0)

	, ('Заповнення таблиці TargetWorks', 0)
	, ('Заповнення таблиці TargetNames', 0)
	, ('Заповнення таблиці TargetNamesT', 0)
	, ('Заповнення таблиці TargetNameWorks', 0)
	, ('Заповнення таблиці TargetPerformerParts', 0)
	, ('Заповнення таблиці TargetPerformerParts - transliterate', 0)
	, ('Заповнення таблиці TargetAuthorParts', 0)
	, ('Заповнення таблиці TargetAuthorParts - transliterate', 0)

	, ('Пошук творів-кандидатів за подбністю назв', 0)
	, ('Вібір із творів-кандидатів за авторами і виконавцями', 0)