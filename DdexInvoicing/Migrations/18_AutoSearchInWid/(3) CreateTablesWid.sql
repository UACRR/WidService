use AutoSearch
go

-- =================================== ІНФОРМАЦІЯ ДЛЯ ПОШУКУ


-- TargetWorksWid
drop table if exists TargetWorksWid
create table TargetWorksWid (
	Wic int primary key
)

-- TargetNames
drop table if exists TargetNamesWid
create table TargetNamesWid (
	  TargetNameId int primary key
	, Name nvarchar(261)
)
--create unique nonclustered index idx_TargetNamesWid_Name on TargetNamesWid(Name)

-- TargetNameWorks
drop table if exists TargetNameWorksWid
create table TargetNameWorksWid (
	  TargetNameId int
	, Wic int
)
--create nonclustered index idx_TargetNameWorksWid_TargetNameId on TargetNameWorksWid(TargetNameId)
--create nonclustered index idx_TargetNameWorksWid_WorkId on TargetNameWorksWid(Wic)
--alter table TargetNameWorksWid add constraint fk_TargetNameWorksWid_TargetNameId foreign key (TargetNameId) references TargetNamesWid(TargetNameId);


drop table if exists TargetPerformerPartsWid
create table TargetPerformerPartsWid (
	  TargetPerformerPartId int primary key
	, Name nvarchar(64)
)
--create unique nonclustered index idx_TargetPerformerPartsWid_Name on TargetPerformerPartsWid(Name)

drop table if exists TargetPerformerPartWorksWid
create table TargetPerformerPartWorksWid (
	  TargetPerformerPartId int
	, WorkId int
)
--create nonclustered index idx_TargetPerformerPartWorksWid_TargetPerformerPartWorks on TargetPerformerPartWorksWid(TargetPerformerPartId)
--create nonclustered index idx_TargetPerformerPartWorksWid_WorkId on TargetPerformerPartWorksWid(WorkId)

drop table if exists TargetAuthorPartsWid
create table TargetAuthorPartsWid (
	  TargetAuthorPartId int primary key
	, Name nvarchar(64)
)
--create nonclustered index idx_TargetAuthorPartsWid_Name on TargetAuthorPartsWid(Name)

drop table if exists TargetAuthorPartWorksWid
create table TargetAuthorPartWorksWid (
	  TargetAuthorPartId int
	, Wic int
)
--create nonclustered index idx_TargetAuthorPartWorksWid_TargetAuthorPartWorks on TargetAuthorPartWorksWid(TargetAuthorPartId)
--create nonclustered index idx_TargetAuthorPartWorksWid_Wic on TargetAuthorPartWorksWid(Wic)

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
drop table if exists SearchSteps
create table SearchSteps (
	  Id int primary key
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
	, ('Заповнення таблиці ExtraTargetNamesWid', 0)							-- 8
	, ('Заповнення таблиці ExtraTargetNameWorksWid', 0)						-- 9
																			-- 
	, ('Заповнення таблиці TargetNamesWid', 0)								-- 10
	, ('Корекція посилань в ExtraTargetNameWorksWid', 0)					-- 11
	, ('Розшення таблиці TargetNameWorksWid', 0)							-- 12
	
	, ('Заповнення таблиці #ExtraTargetPerformerPartsWid', 0)				-- 13
	, ('Заповнення таблиці ExtraTargetPerformerPartsWid', 0)				-- 14
	, ('Заповнення таблиці ExtraTargetPerformerPartWorksWid', 0)			-- 15
	, ('Розшення таблиці TargetPerformerPartsWid', 0)						-- 16
	, ('Корекція посилань в ExtraTargetPerformerPartWorks', 0)				-- 17
	, ('Розшення таблиці TargetPerformerPartWorksWid', 0)					-- 18

	, ('Заповнення таблиці #WicAuthorNames', 0)								-- 19
	, ('Заповнення таблиці #WicAuthorNameParts', 0)							-- 20
	, ('Заповнення таблиці ExtraTargetAuthorPartsWid', 0)					-- 21
	, ('Заповнення таблиці ExtraTargetAuthorPartWorksWid', 0)				-- 22
	, ('Розшення таблиці TargetAuthorPartsWid', 0)							-- 23
	, ('Розшення таблиці TargetAuthorPartWorksWid', 0)						-- 24

	, ('Розшення таблиці TargetWorksWid', 0)								-- 25
																			-- 
																			-- 
	, ('Пошук творів-кандидатів за подбністю назв', 0)						-- 26
	, ('Вибір із творів-кандидатів за авторами і виконавцями', 0)			-- 27
	, ('Застосування знайдених творів', 0)									-- 28