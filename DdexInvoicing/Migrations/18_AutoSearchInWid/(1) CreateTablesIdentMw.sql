use AutoSearch
go

-- =================================== ІНФОРМАЦІЯ ДЛЯ ПОШУКУ
-- TargetWorks
drop table if exists TargetWorksIdentMw
create table TargetWorksIdentMw (
	    TargetWorkId int primary key
	 ,  WorkId int
)

-- TargetNames
drop table if exists TargetNamesIdentMw
create table TargetNamesIdentMw (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create unique nonclustered index idx_TargetNamesIdentMw_Name on TargetNamesIdentMw(Name)

-- TargetNamesT
drop table if exists TargetNamesIdentMwT
create table TargetNamesIdentMwT (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create nonclustered index idx_TargetNamesIdentMwT_Name on TargetNamesIdentMwT(Name)

-- TargetNameWorks
drop table if exists TargetNameWorksIdentMw
create table TargetNameWorksIdentMw (
	  TargetNameId int
	, WorkId int
)
create nonclustered index idx_TargetNameWorksIdentMw_TargetNameId on TargetNameWorksIdentMw(TargetNameId)
create nonclustered index idx_TargetNameWorkIdentMws_WorkId on TargetNameWorksIdentMw(WorkId)
create nonclustered index idx_TargetNameWorksIdentMw_TargetNameId_WorkId on TargetNameWorksIdentMw(TargetNameId, WorkId)
alter table TargetNameWorksIdentMw add constraint fk_TargetNameWorksIdentMw_TargetNameId foreign key (TargetNameId) references TargetNamesIdentMw(TargetNameId);


drop table if exists TargetPerformerPartsIdentMw
create table TargetPerformerPartsIdentMw (
	  TargetPerformerPartId int primary key
	, Name nvarchar(64)
)
create unique nonclustered index idx_TargetPerformerPartsIdentMw_Name on TargetPerformerPartsIdentMw(Name)

drop table if exists TargetPerformerPartWorksIdentMw
create table TargetPerformerPartWorksIdentMw (
	  TargetPerformerPartId int
	, WorkId int
)
create nonclustered index idx_TargetPerformerPartWorks_TargetPerformerPartWorksIdentMw on TargetPerformerPartWorksIdentMw(TargetPerformerPartId)
create nonclustered index idx_TargetPerformerPartWorksIdentMw_WorkId on TargetPerformerPartWorksIdentMw(WorkId)

drop table if exists TargetAuthorPartsIdentMw
create table TargetAuthorPartsIdentMw (
	  TargetAuthorPartId int primary key
	, Name nvarchar(64)
)
create nonclustered index idx_TargetAuthorPartsIdentMw_Name on TargetAuthorPartsIdentMw(Name)

drop table if exists TargetAuthorPartWorksIdentMw
create table TargetAuthorPartWorksIdentMw (
	  TargetAuthorPartId int
	, WorkId int
)
create nonclustered index idx_TargetAuthorPartWorksIdentMw_TargetAuthorPartWorks on TargetAuthorPartWorksIdentMw(TargetAuthorPartId)
create nonclustered index idx_TargetAuthorPartWorksIdentMw_WorkId on TargetAuthorPartWorksIdentMw(WorkId)

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
	  Id int primary key
	, Name varchar(100)
	, Status int
)

drop table if exists SearchStepsIdentMw
create table SearchStepsIdentMw (
	  Id int primary key identity(1, 1)
	, Name varchar(100)
	, Status int
)
insert SearchStepsIdentMw (Name, Status)
values
	  ('Заповнення таблиці SourceWorks', 0)									-- 1
	, ('Заповнення таблиці SourceNames', 0)									-- 2
	, ('Заповнення таблиці SourceNamesT', 0)								-- 3
	, ('Заповнення таблиці SourceNameWorks', 0)								-- 4
	, ('Заповнення таблиці SourcePerformerParts', 0)						-- 5
	, ('Заповнення таблиці SourceAuthorParts', 0)							-- 6
																			-- 
	, ('Заповнення таблиці ExtraTargetWorks', 0)							-- 7
	, ('Заповнення таблиці ExtraTargetNames', 0)							-- 8
	, ('Заповнення таблиці ExtraTargetNamesT', 0)							-- 9
	, ('Заповнення таблиці ExtraTargetNameWorks', 0)						-- 10
	, ('Заповнення таблиці #ExtraTargetPerformerParts', 0)					-- 11
	, ('Заповнення таблиці ExtraTargetPerformerParts', 0)					-- 12
	, ('Заповнення таблиці ExtraTargetPerformerPartWorks', 0)				-- 13
	, ('Заповнення таблиці #ExtraTargetAuthorParts', 0)						-- 14
	, ('Заповнення таблиці ExtraTargetAuthorParts', 0)						-- 15
	, ('Заповнення таблиці ExtraTargetAuthorPartWorks', 0)					-- 16
																			-- 
	, ('Заповнення таблиці #ExtraTargetNameIdsToAdd', 0)					-- 17
	, ('Розшення таблиці TargetNames', 0)									-- 18
	, ('Розшення таблиці TargetNamesT', 0)									-- 19
	, ('Корекція посилань в ExtraTargetNameWorks', 0)						-- 20
	, ('Розшення таблиці TargetNameWorks', 0)								-- 21
	, ('Заповнення таблиці #ExtraTargetPerformerPartIdsToAdd', 0)			-- 22
	, ('Розшення таблиці TargetPerformerParts', 0)							-- 23
	, ('Корекція посилань в ExtraTargetPerformerPartWorks', 0)				-- 24
	, ('Розшення таблиці TargetPerformerPartWorks', 0)						-- 25
	, ('Заповнення таблиці #ExtraTargetAuthorPartIdsToAdd', 0)				-- 26
	, ('Розшення таблиці TargetAuthorParts', 0)								-- 27
	, ('Корекція посилань в ExtraTargetAuthorPartWorks', 0)					-- 28
	, ('Розшення таблиці TargetAuthorPartWorks', 0)							-- 29
																			-- 
																			-- 
	, ('Пошук творів-кандидатів за подбністю назв', 0)						-- 30
	, ('Вибір із творів-кандидатів за авторами і виконавцями', 0)			-- 31