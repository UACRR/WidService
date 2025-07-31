use AutoSearch
go

create or alter procedure spUpdateTargetInfoMs
as
begin

-- =================================== РОБОЧА ІНФОРМАЦІЯ ДЛЯ ОНОВЛЕННЯ ІНФОРМАЦІЇ ДЛЯ ПОШУКУ
-- Інформація робоча, після передачі в головні таблиці інформація з цих таблиць видаляється
begin

-- НАЗВИ
-- Початковий системний код нової інформації стосовно творів
	declare @baseTargetWorkId int = (select isnull(max(TargetWorkId), 0) from TargetWorksMs)
--	select * from TargetWorksMs

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
		  @baseTargetWorkId + row_number() over(order by t1.ObjId)
		, t1.ObjId
		, t1.Name
		, translate(t1.author, '.|,()&:;\/', '          ')
		, translate(t1.performer, '.|,()&:;\/', '          ')
	from MediaService..ObjectRight t1
		left join TargetWorksMs t2 on t1.ObjId = t2.ObjId
	where t2.ObjId is null
		and trim(isnull(t1.Name, '')) <> ''
	update SearchSteps set Status = 2 where Id = 7

	-- select * from ExtraTargetWorks

-- ExtraTargetNames - ObjectRight
-- Початковий системний код нової інформації стосовно назв
	declare @baseTargetNameId int = (select isnull(max(TargetNameId), 0) from TargetNamesMs)
	exec spSetSearchStepStarted 8
	truncate table ExtraTargetNames
	; with TmpNames as (
		select distinct Name
		from ExtraTargetWorks
		union
		select Name
		from MediaService..SeekObject
		where CodeI = 1
	)
	insert ExtraTargetNames(TargetNameId, Name)
	select @baseTargetNameId + row_number() over(order by Name), Name
	from TmpNames
	where trim(isnull(Name, '')) <> ''
	exec spSetSearchStepEnded 8

	-- select * from ExtraTargetNames order by Name

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
	union
	select distinct t1.TargetNameId, t2.ObjId, null, null
	from ExtraTargetNames t1
		join MediaService..SeekObject t2 on t1.Name = t2.Name
	where t2.CodeI = 1
	exec spSetSearchStepEnded 10

	-- select * from ExtraTargetNameWorks

-- ВИКОНАВЦІ
-- Додаткова інформація без дублювань (назви транслітеровані)
	exec spSetSearchStepStarted 11
	drop table if exists #ExtraTargetPerformerParts
	select distinct 
		  WorkId
		, left(
				trim('.,#/\&:| ' from AutoSearch.dbo.ClrTranslitFromUkrToLat(value))
		   , 64) as Name
	into #ExtraTargetPerformerParts
	from ExtraTargetWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 11

	-- select * from #ExtraTargetPerformerParts order by Name desc

-- Початковий системний код нової інформації стосовно виконавців
	exec spSetSearchStepEnded 12
	declare @baseTargetPerformerPart int = (select isnull(max(TargetPerformerPartId), 0) from TargetPerformerPartsMs)

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
	select distinct 
		  WorkId
		, left(
			    trim('.,#/\&:| ' from AutoSearch.dbo.ClrTranslitFromUkrToLat(value))
			, 64) as Name
	into #ExtraTargetAuthorParts
	from ExtraTargetWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	exec spSetSearchStepEnded 14
	-- select * from #ExtraTargetAuthorParts

-- Початковий системний код нової інформації стосовно виконавців
	declare @baseTargetAuthorPart int = (select isnull(max(TargetAuthorPartId), 0) from TargetAuthorPartsMs)

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
		left join TargetNamesMs t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 17
	-- select * from #ExtraTargetNameIdsToAdd

-- TargetNames
	exec spSetSearchStepStarted 18
	insert TargetNamesMs(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNames t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId
	exec spSetSearchStepEnded 18
	-- select * from TargetNames

-- TargetNamesT
	exec spSetSearchStepStarted 19
	insert TargetNamesMsT(TargetNameId, Name)
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
		join TargetNamesMs t3 on t2.Name = t3.Name
	exec spSetSearchStepEnded 20

-- TargetNameWorks
	exec spSetSearchStepStarted 21
	insert TargetNameWorksMs(TargetNameId, WorkId, ObjId, Wic)
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
		left join TargetPerformerPartsMs t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 22

	-- select * from #ExtraTargetPerformerPartIdsToAdd

-- TargetPerformerParts
	exec spSetSearchStepStarted 23
	insert TargetPerformerPartsMs(TargetPerformerPartId, Name)
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
		join TargetPerformerPartsMs t3 on t2.Name = t3.Name
	exec spSetSearchStepEnded 24

-- TargetPerformerPartWorks
	exec spSetSearchStepStarted 25
	insert TargetPerformerPartWorksMs(TargetPerformerPartId, WorkId)
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
		left join TargetAuthorPartsMs t2 on t1.Name = t2.Name
	where t2.Name is null
	exec spSetSearchStepEnded 26
	-- select * from #ExtraTargetAuthorPartIdsToAdd

-- TargetAuthorParts
	exec spSetSearchStepStarted 27
	insert TargetAuthorPartsMs(TargetAuthorPartId, Name)
	select t1.TargetAuthorPartId, t1.Name
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorPartIdsToAdd t2 on t1.TargetAuthorPartId = t2.TargetAuthorPartId
	exec spSetSearchStepEnded 27

-- TargetAuthorPartWorks
	exec spSetSearchStepStarted 28
	insert TargetAuthorPartWorksMs(TargetAuthorPartId, WorkId)
	select TargetAuthorPartId, WorkId
	from ExtraTargetAuthorPartWorks
	exec spSetSearchStepEnded 28

	drop table if exists #ExtraTargetAuthorPartIdsToAdd

-- Коди творів для яких створена інформація для пошуку
	exec spSetSearchStepStarted 29
	insert TargetWorksMs(TargetWorkId, ObjId)
	select t1.TargetWorkId, t1.WorkId 
	from ExtraTargetWorks t1
		left join TargetWorksMs t2 on t1.WorkId = t2.ObjId
	where t2.ObjId is null
	exec spSetSearchStepEnded 29

end

end -- PROCEDURE
go

-- exec spUpdateTargetInfoMs