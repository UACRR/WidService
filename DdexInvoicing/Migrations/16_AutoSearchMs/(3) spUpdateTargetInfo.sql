use AutoSearch
go

create or alter procedure spUpdateTargetInfo
as
begin

-- =================================== РОБОЧА ІНФОРМАЦІЯ ДЛЯ ОНОВЛЕННЯ ІНФОРМАЦІЇ ДЛЯ ПОШУКУ
-- Інформація робоча, після передачі в головні таблиці інформація з цих таблиць видаляється
begin

-- НАЗВИ
-- Початковий системний код нової інформації стосовно творів
	declare @baseTargetWorkId int = (select isnull(max(TargetWorkId), 0) from TargetWorks)

-- ExtraTargetWorks
	exec spSetSearchStepStarted 7
	truncate table ExtraTargetWorks
	insert ExtraTargetWorks(
		  TargetWorkId
		, WorkId
		, Name
		, Authors
		, Performers)
	select 
		@baseTargetWorkId + row_number() over(order by Id)
		, Id
		, Title
		, translate(ComposerAuthor, '.|,()&:;\/', '          ')
		, translate(DisplayArtistName, '.|,()&:;\/', '          ')
	from Ddex..IdentMw t1
		left join TargetWorks t2 on t1.Id = t2.WorkId
	where (
			isnull(objId, 0) <> 0
			or isnull(Wic, 0) <> 0
		)
		and t2.WorkId is null
	exec spSetSearchStepEnded 7

	-- select * from ExtraTargetWorks

-- ExtraTargetNames
-- Початковий системний код нової інформації стосовно назв
	declare @baseTargetNameId int = (select isnull(max(TargetNameId), 0) from TargetNames)
	exec spSetSearchStepStarted 8
	truncate table ExtraTargetNames
	; with TmpNames as (
		select distinct Name
		from ExtraTargetWorks
	)
	insert ExtraTargetNames(TargetNameId, Name)
	select @baseTargetNameId + row_number() over(order by Name), Name
	from TmpNames
	exec spSetSearchStepEnded 8

	-- select * from ExtraTargetNames

-- ExtraTargetNamesT
	exec spSetSearchStepStarted 9
	truncate table ExtraTargetNamesT
	insert ExtraTargetNamesT(TargetNameId, Name)
	select TargetNameId, AutoSearch.dbo.ClrTranslitFromUkrToLat(Name)
	from ExtraTargetNames
	exec spSetSearchStepEnded 9

	-- select * from ExtraTargetNamesT

-- ExtraTargetNameWorks
	exec spSetSearchStepStarted 10
	truncate table ExtraTargetNameWorks
	insert ExtraTargetNameWorks(TargetNameId, WorkId, ObjId, Wic)
	select distinct t1.TargetNameId, t2.WorkId, null, null
	from ExtraTargetNames t1
		join ExtraTargetWorks t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 10

	-- select * from ExtraTargetNameWorks

-- ВИКОНАВЦІ
-- Додаткова інформація без дублювань (назви транслітеровані)
	exec spSetSearchStepStarted 11
	drop table if exists #ExtraTargetPerformerParts
	select distinct WorkId, left(AutoSearch.dbo.ClrTranslitFromUkrToLat(value), 64) as Name
	into #ExtraTargetPerformerParts
	from ExtraTargetWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 11

	-- select * from #ExtraTargetPerformerParts

-- Початковий системний код нової інформації стосовно виконавців
	exec spSetSearchStepEnded 12
	declare @baseTargetPerformerPart int = (select isnull(max(TargetPerformerPartId), 0) from TargetPerformerParts)

-- ExtraTargetPerformerParts
	truncate table ExtraTargetPerformerParts
	; with TmpTargetPerformerParts as (
		select distinct Name
		from #ExtraTargetPerformerParts
	)
	insert ExtraTargetPerformerParts(TargetPerformerPartId, Name)
	select @baseTargetPerformerPart + row_number() over(order by Name), Name
	from TmpTargetPerformerParts
	exec spSetSearchStepEnded 12

	-- select * from ExtraTargetPerformerParts

-- ExtraTargetPerformerPartWorks
	exec spSetSearchStepStarted 13
	truncate table ExtraTargetPerformerPartWorks
	insert ExtraTargetPerformerPartWorks(TargetPerformerPartId, WorkId)
	select t1.TargetPerformerPartId, t2.WorkId
	from ExtraTargetPerformerParts t1
		join #ExtraTargetPerformerParts t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 13

	-- select * from ExtraTargetPerformerPartWorks

	drop table if exists #ExtraTargetPerformerParts

-- АВТОРИ
-- Додаткова інформація без дублювань (назви транслітеровані)
	exec spSetSearchStepStarted 14
	drop table if exists #ExtraTargetAuthorParts
	select distinct WorkId, left(AutoSearch.dbo.ClrTranslitFromUkrToLat(value), 64) as Name
	into #ExtraTargetAuthorParts
	from ExtraTargetWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 14
	-- select * from #ExtraTargetAuthorParts

-- Початковий системний код нової інформації стосовно виконавців
	declare @baseTargetAuthorPart int = (select isnull(max(TargetAuthorPartId), 0) from TargetAuthorParts)

-- ExtraTargetAuthorParts
	exec spSetSearchStepStarted 15
	truncate table ExtraTargetAuthorParts
	; with TmpTargetAuthorParts as (
		select distinct Name
		from #ExtraTargetAuthorParts
	)
	insert ExtraTargetAuthorParts(TargetAuthorPartId, Name)
	select @baseTargetAuthorPart + row_number() over(order by Name), Name
	from TmpTargetAuthorParts
	exec spSetSearchStepEnded 15

	-- select * from ExtraTargetAuthorParts

-- ExtraTargetAuthorPartWorks
	exec spSetSearchStepStarted 16
	truncate table ExtraTargetAuthorPartWorks
	insert ExtraTargetAuthorPartWorks(TargetAuthorPartId, WorkId)
	select t1.TargetAuthorPartId, t2.WorkId
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorParts t2 on t1.Name = t2.Name
	exec spSetSearchStepEnded 16

	-- select * from ExtraTargetAuthorPartWorks

	drop table if exists #ExtraTargetAuthorParts
end

-- =================================== РОЗШИРЕННЯ ІНФОРМАЦІЮ ДЛЯ ПОШУКУ
-- Таблиці постійні
begin
-- НАЗВИ
-- Коди назв які слід додати без дублювання
	exec spSetSearchStepStarted 17
	drop table if exists #ExtraTargetNameIdsToAdd
	select t1.TargetNameId
	into #ExtraTargetNameIdsToAdd
	from ExtraTargetNames t1
		left join TargetNames t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 17
	-- select * from #ExtraTargetNameIdsToAdd

-- TargetNames
	exec spSetSearchStepStarted 18
	insert TargetNames(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNames t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId
	exec spSetSearchStepEnded 18
	-- select * from TargetNames

-- TargetNamesT
	exec spSetSearchStepStarted 19
	insert TargetNamesT(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNamesT t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId
	exec spSetSearchStepEnded 19

-- Коригуємо посилання
	exec spSetSearchStepStarted 20
	update t1
	set t1.TargetNameId = t3.TargetNameId
	--select *
	from ExtraTargetNameWorks t1
		join ExtraTargetNames t2 on t1.TargetNameId = t2.TargetNameId
		join TargetNames t3 on t2.Name = t3.Name
	exec spSetSearchStepEnded 20

-- TargetNameWorks
	exec spSetSearchStepStarted 21
	insert TargetNameWorks(TargetNameId, WorkId, ObjId, Wic)
	select TargetNameId, WorkId, ObjId, Wic
	from ExtraTargetNameWorks
	exec spSetSearchStepEnded 21

	drop table if exists #ExtraTargetNameIdsToAdd

-- ВИКОНАВЦІ

-- Коди виконавців які слід додати без дублювання
	exec spSetSearchStepStarted 22
	drop table if exists #ExtraTargetPerformerPartIdsToAdd

	select t1.TargetPerformerPartId
	into #ExtraTargetPerformerPartIdsToAdd
	from ExtraTargetPerformerParts t1
		left join TargetPerformerParts t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 22

	-- select * from #ExtraTargetPerformerPartIdsToAdd

-- TargetPerformerParts
	exec spSetSearchStepStarted 23
	insert TargetPerformerParts(TargetPerformerPartId, Name)
	select t1.TargetPerformerPartId, t1.Name
	from ExtraTargetPerformerParts t1
		join #ExtraTargetPerformerPartIdsToAdd t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId
	exec spSetSearchStepEnded 23

-- Коригуємо посилання
	exec spSetSearchStepStarted 24
	update t1
	set t1.TargetPerformerPartId = t3.TargetPerformerPartId
	-- select *
	from ExtraTargetPerformerPartWorks t1
		join ExtraTargetPerformerParts t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId
		join TargetPerformerParts t3 on t2.Name = t3.Name
		exec spSetSearchStepEnded 24

-- TargetPerformerPartWorks
	exec spSetSearchStepStarted 25
	insert TargetPerformerPartWorks(TargetPerformerPartId, WorkId)
	select TargetPerformerPartId, WorkId
	from ExtraTargetPerformerPartWorks
	exec spSetSearchStepEnded 25

	drop table if exists #ExtraTargetPerformerPartIdsToAdd

-- АВТОРИ

-- Коди авторів які слід додати без дублювання
	exec spSetSearchStepStarted 26
	drop table if exists #ExtraTargetAuthorPartIdsToAdd

	select t1.TargetAuthorPartId
	into #ExtraTargetAuthorPartIdsToAdd
	from ExtraTargetAuthorParts t1
		left join TargetAuthorParts t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 26
	-- select * from #ExtraTargetAuthorPartIdsToAdd

-- TargetAuthorParts
	exec spSetSearchStepStarted 27
	insert TargetAuthorParts(TargetAuthorPartId, Name)
	select t1.TargetAuthorPartId, t1.Name
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorPartIdsToAdd t2 on t1.TargetAuthorPartId = t2.TargetAuthorPartId
	exec spSetSearchStepEnded 27

-- TargetAuthorPartWorks
	exec spSetSearchStepStarted 28
	insert TargetAuthorPartWorks(TargetAuthorPartId, WorkId)
	select TargetAuthorPartId, WorkId
	from ExtraTargetAuthorPartWorks
	exec spSetSearchStepEnded 28

	drop table if exists #ExtraTargetAuthorPartIdsToAdd

-- Коди творів для яких створена інформація для пошуку
	exec spSetSearchStepStarted 29
	insert TargetWorks(TargetWorkId, WorkId)
	select t1.TargetWorkId, t1.WorkId 
	from ExtraTargetWorks t1
		left join TargetWorks t2 on t1.WorkId = t2.WorkId
	where t2.WorkId is null
	exec spSetSearchStepEnded 29

end

end -- PROCEDURE
go