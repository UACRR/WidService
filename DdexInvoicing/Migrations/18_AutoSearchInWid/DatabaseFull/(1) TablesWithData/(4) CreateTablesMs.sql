use AutoSearch
go

-- =================================== ІНФОРМАЦІЯ ДЛЯ ПОШУКУ
-- TargetWorksMs
drop table if exists TargetWorksMs
create table TargetWorksMs (
	    TargetWorkId int primary key
	 ,  ObjId int
)

-- TargetNames
drop table if exists TargetNamesMs
create table TargetNamesMs (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create unique nonclustered index idx_TargetNamesMs_Name on TargetNamesMs(Name)

-- TargetNamesT
drop table if exists TargetNamesMsT
create table TargetNamesMsT (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create nonclustered index idx_TargetNamesMsT_Name on TargetNamesMsT(Name)

-- TargetNameWorks
drop table if exists TargetNameWorksMs
create table TargetNameWorksMs (
	  TargetNameId int
	, WorkId int
)
create nonclustered index idx_TargetNameWorksMs_TargetNameId on TargetNameWorksMs(TargetNameId)
create nonclustered index idx_TargetNameWorksMs_WorkId on TargetNameWorksMs(WorkId)
create nonclustered index idx_TargetNameWorksMs_TargetNameId_WorkId on TargetNameWorksMs(TargetNameId, WorkId)
alter table TargetNameWorksMs add constraint fk_TargetNameWorksMs_TargetNameId foreign key (TargetNameId) references TargetNamesMs(TargetNameId);


drop table if exists TargetPerformerPartsMs
create table TargetPerformerPartsMs (
	  TargetPerformerPartId int primary key
	, Name nvarchar(64)
)
create unique nonclustered index idx_TargetPerformerPartsMs_Name on TargetPerformerPartsMs(Name)

drop table if exists TargetPerformerPartWorksMs
create table TargetPerformerPartWorksMs (
	  TargetPerformerPartId int
	, WorkId int
)
create nonclustered index idx_TargetPerformerPartWorksMs_TargetPerformerPartWorks on TargetPerformerPartWorksMs(TargetPerformerPartId)
create nonclustered index idx_TargetPerformerPartWorksMs_WorkId on TargetPerformerPartWorksMs(WorkId)

drop table if exists TargetAuthorPartsMs
create table TargetAuthorPartsMs (
	  TargetAuthorPartId int primary key
	, Name nvarchar(64)
)
create nonclustered index idx_TargetAuthorPartsMs_Name on TargetAuthorPartsMs(Name)

drop table if exists TargetAuthorPartWorksMs
create table TargetAuthorPartWorksMs (
	  TargetAuthorPartId int
	, WorkId int
)
create nonclustered index idx_TargetAuthorPartWorksMs_TargetAuthorPartWorks on TargetAuthorPartWorksMs(TargetAuthorPartId)
create nonclustered index idx_TargetAuthorPartWorksMs_WorkId on TargetAuthorPartWorksMs(WorkId)

-- РЕЗУЛЬТАТИ ПОШУКУ
drop table if exists FoundNamesInMs
create table FoundNamesInMs(
	  SourceNameId int
	, TargetNameId int
	, SearchType varchar(10)
)

drop table if exists FoundWorksInMs
create table FoundWorksInMs(
	  SourceWorkId int
	, TargetObjId int
)

-- МОНІТОРИНГ
drop table if exists SearchStepsMs
create table SearchStepsMs (
	  Id int primary key identity(1, 1)
	, Name varchar(100)
	, Status int
)

insert SearchStepsMs (Name, Status)
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
	, ('Розширення таблиці TargetNamesMs', 0)									-- 18
	, ('Розширення таблиці TargetNamesMsT', 0)									-- 19
	, ('Корекція посилань в ExtraTargetNameWorks', 0)						-- 20
	, ('Розширення таблиці TargetNameWorksMs', 0)								-- 21
	, ('Заповнення таблиці #ExtraTargetPerformerPartIdsToAdd', 0)			-- 22
	, ('Розширення таблиці TargetPerformerPartsMs', 0)							-- 23
	, ('Корекція посилань в ExtraTargetPerformerPartWorks', 0)				-- 24
	, ('Розширення таблиці TargetPerformerPartWorksMs', 0)						-- 25
	, ('Заповнення таблиці #ExtraTargetAuthorPartIdsToAdd', 0)				-- 26
	, ('Розширення таблиці TargetAuthorPartsMs', 0)								-- 27
	, ('Корекція посилань в ExtraTargetAuthorPartWorks', 0)					-- 28
	, ('Розширення таблиці TargetAuthorPartWorksMs', 0)							-- 29
																			-- 
																			-- 
	, ('Пошук творів-кандидатів за подбністю назв', 0)						-- 30
	, ('Вибір із творів-кандидатів за авторами і виконавцями', 0)			-- 31