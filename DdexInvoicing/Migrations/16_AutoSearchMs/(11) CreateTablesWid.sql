use AutoSearch
go

-- =================================== ІНФОРМАЦІЯ ДЛЯ ПОШУКУ
-- TargetWorksWid
drop table if exists TargetWorksWid
create table TargetWorksWid (
	    TargetWorkId int primary key
	 ,  Wic int
)

-- TargetNames
drop table if exists TargetNamesWid
create table TargetNamesWid (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create unique nonclustered index idx_TargetNamesWid_Name on TargetNames(Name)

-- TargetNamesT
drop table if exists TargetNamesWidT
create table TargetNamesWidT (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
create nonclustered index idx_TargetNamesWidT_Name on TargetNamesT(Name)

-- TargetNameWorks
drop table if exists TargetNameWorksWid
create table TargetNameWorksWid (
	  TargetNameId int
	, WorkId int
	, ObjId int
	, Wic int
)
create nonclustered index idx_TargetNameWorksWid_TargetNameId on TargetNameWorksWid(TargetNameId)
create nonclustered index idx_TargetNameWorksWid_WorkId on TargetNameWorksWid(WorkId)
create nonclustered index idx_TargetNameWorksWid_TargetNameId_WorkId on TargetNameWorksWid(TargetNameId, WorkId)
alter table TargetNameWorksWid add constraint fk_TargetNameWorksWid_TargetNameId foreign key (TargetNameId) references TargetNamesWid(TargetNameId);


drop table if exists TargetPerformerPartsWid
create table TargetPerformerPartsWid (
	  TargetPerformerPartId int primary key
	, Name nvarchar(64)
)
create unique nonclustered index idx_TargetPerformerPartsWid_Name on TargetPerformerPartsWid(Name)

drop table if exists TargetPerformerPartWorksWid
create table TargetPerformerPartWorksWid (
	  TargetPerformerPartId int
	, WorkId int
)
create nonclustered index idx_TargetPerformerPartWorksWid_TargetPerformerPartWorks on TargetPerformerPartWorksWid(TargetPerformerPartId)
create nonclustered index idx_TargetPerformerPartWorksWid_WorkId on TargetPerformerPartWorksWid(WorkId)

drop table if exists TargetAuthorPartsWid
create table TargetAuthorPartsWid (
	  TargetAuthorPartId int primary key
	, Name nvarchar(64)
)
create nonclustered index idx_TargetAuthorPartsWid_Name on TargetAuthorPartsWid(Name)

drop table if exists TargetAuthorPartWorksWid
create table TargetAuthorPartWorksWid (
	  TargetAuthorPartId int
	, WorkId int
)
create nonclustered index idx_TargetAuthorPartWorksWid_TargetAuthorPartWorks on TargetAuthorPartWorksWid(TargetAuthorPartId)
create nonclustered index idx_TargetAuthorPartWorksWid_WorkId on TargetAuthorPartWorksWid(WorkId)

-- РЕЗУЛЬТАТИ ПОШУКУ
drop table if exists FoundNamesInWid
create table FoundNamesInWid(
	  SourceNameId int
	, TargetNameId int
	, SearchType varchar(10)
)

drop table if exists FoundWorksInWid
create table FoundWorksInWid(
	  SourceWorkId int
	, TargetWic int
)

-- МОНІТОРИНГ
drop table if exists SearchStepsWid
create table SearchStepsWid (
	  Id int primary key identity(1, 1)
	, Name varchar(100)
	, Status int
)

insert SearchStepsWid (Name, Status)
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