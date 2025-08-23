use AutoSearch
go

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

go

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

go