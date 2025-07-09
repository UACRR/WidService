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
	update SearchSteps set Status = 1 where Id = 9
	truncate table ExtraTargetWorks
	insert ExtraTargetWorks(TargetWorkId, WorkId, Name, Authors, Performers)
	select @baseTargetWorkId + row_number() over(order by Id), Id, Title, ComposerAuthor, DisplayArtistName
	from Ddex..IdentMw t1
		left join TargetWorks t2 on t1.Id = t2.WorkId
	where (
			isnull(objId, 0) <> 0
			or isnull(Wic, 0) <> 0
		)
		and t2.WorkId is null
	update SearchSteps set Status = 2 where Id = 9

	-- select * from ExtraTargetWorks

-- ExtraTargetNames
-- Початковий системний код нової інформації стосовно назв
	declare @baseTargetNameId int = (select isnull(max(TargetNameId), 0) from TargetNames)
	update SearchSteps set Status = 1 where Id = 10
	truncate table ExtraTargetNames
	; with TmpNames as (
		select distinct Name
		from ExtraTargetWorks
	)
	insert ExtraTargetNames(TargetNameId, Name)
	select @baseTargetNameId + row_number() over(order by Name), Name
	from TmpNames
	update SearchSteps set Status = 2 where Id = 10

	-- select * from ExtraTargetNames

-- ExtraTargetNamesT
	update SearchSteps set Status = 1 where Id = 11
	truncate table ExtraTargetNamesT
	insert ExtraTargetNamesT(TargetNameId, Name)
	select TargetNameId, dbo.TransLitFromUkrToLat(Name)
	from ExtraTargetNames
	update SearchSteps set Status = 2 where Id = 11

	-- select * from ExtraTargetNamesT

-- ExtraTargetNameWorks
	update SearchSteps set Status = 1 where Id = 12
	truncate table ExtraTargetNameWorks
	insert ExtraTargetNameWorks(TargetNameId, WorkId, ObjId, Wic)
	select distinct t1.TargetNameId, t2.WorkId, null, null
	from ExtraTargetNames t1
		join ExtraTargetWorks t2 on t1.Name = t2.Name
	update SearchSteps set Status = 2 where Id = 12

	-- select * from ExtraTargetNameWorks

-- ВИКОНАВЦІ
-- Додаткова інформація без дублювань (назви транслітеровані)
	update SearchSteps set Status = 1 where Id = 13
	drop table if exists #ExtraTargetPerformerParts
	select distinct WorkId, left(dbo.TransLitFromUkrToLat(value), 64) as Name
	into #ExtraTargetPerformerParts
	from ExtraTargetWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2

	-- select * from #ExtraTargetPerformerParts

-- Початковий системний код нової інформації стосовно виконавців
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
	update SearchSteps set Status = 2 where Id = 13

	-- select * from ExtraTargetPerformerParts

-- ExtraTargetPerformerPartWorks
	truncate table ExtraTargetPerformerPartWorks
	insert ExtraTargetPerformerPartWorks(TargetPerformerPartId, WorkId)
	select t1.TargetPerformerPartId, t2.WorkId
	from ExtraTargetPerformerParts t1
		join #ExtraTargetPerformerParts t2 on t1.Name = t2.Name

	-- select * from ExtraTargetPerformerPartWorks

	drop table if exists #ExtraTargetPerformerParts

-- АВТОРИ
-- Додаткова інформація без дублювань (назви транслітеровані)
	update SearchSteps set Status = 1 where Id = 13
	drop table if exists #ExtraTargetAuthorParts
	select distinct WorkId, left(dbo.TransLitFromUkrToLat(value), 64) as Name
	into #ExtraTargetAuthorParts
	from ExtraTargetWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2

	-- select * from #ExtraTargetAuthorParts

-- Початковий системний код нової інформації стосовно виконавців
	declare @baseTargetAuthorPart int = (select isnull(max(TargetAuthorPartId), 0) from TargetAuthorParts)

-- ExtraTargetAuthorParts
	truncate table ExtraTargetAuthorParts
	; with TmpTargetAuthorParts as (
		select distinct Name
		from #ExtraTargetAuthorParts
	)
	insert ExtraTargetAuthorParts(TargetAuthorPartId, Name)
	select @baseTargetAuthorPart + row_number() over(order by Name), Name
	from TmpTargetAuthorParts
	update SearchSteps set Status = 2 where Id = 13

	-- select * from ExtraTargetAuthorParts

-- ExtraTargetAuthorPartWorks
	truncate table ExtraTargetAuthorPartWorks
	insert ExtraTargetAuthorPartWorks(TargetAuthorPartId, WorkId)
	select t1.TargetAuthorPartId, t2.WorkId
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorParts t2 on t1.Name = t2.Name

	-- select * from ExtraTargetAuthorPartWorks

	drop table if exists #ExtraTargetAuthorParts
end

-- =================================== РОЗШИРЕННЯ ІНФОРМАЦІЮ ДЛЯ ПОШУКУ
-- Таблиці постійні
begin
-- НАЗВИ
-- Коди назв які слід додати без дублювання
	drop table if exists #ExtraTargetNameIdsToAdd
	select t1.TargetNameId
	into #ExtraTargetNameIdsToAdd
	from ExtraTargetNames t1
		left join TargetNames t2 on t1.Name = t2.Name
	where t2.Name is null
	-- select * from #ExtraTargetNameIdsToAdd

-- TargetNames
	insert TargetNames(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNames t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId

	-- select * from TargetNames

-- TargetNamesT
	insert TargetNamesT(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNamesT t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId

-- Коригуємо посилання
update t1
set t1.TargetNameId = t3.TargetNameId
--select *
from ExtraTargetNameWorks t1
	join ExtraTargetNames t2 on t1.TargetNameId = t2.TargetNameId
	join TargetNames t3 on t2.Name = t3.Name

-- TargetNameWorks
	insert TargetNameWorks(TargetNameId, WorkId, ObjId, Wic)
	select TargetNameId, WorkId, ObjId, Wic
	from ExtraTargetNameWorks

	drop table if exists #ExtraTargetNameIdsToAdd

-- ВИКОНАВЦІ

-- Коди виконавців які слід додати без дублювання
	drop table if exists #ExtraTargetPerformerPartIdsToAdd

	select t1.TargetPerformerPartId
	into #ExtraTargetPerformerPartIdsToAdd
	from ExtraTargetPerformerParts t1
		left join TargetPerformerParts t2 on t1.Name = t2.Name
	where t2.Name is null

	-- select * from #ExtraTargetPerformerPartIdsToAdd

-- TargetPerformerParts
	insert TargetPerformerParts(TargetPerformerPartId, Name)
	select t1.TargetPerformerPartId, t1.Name
	from ExtraTargetPerformerParts t1
		join #ExtraTargetPerformerPartIdsToAdd t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId

-- Коригуємо посилання
	update t1
	set t1.TargetPerformerPartId = t3.TargetPerformerPartId
	-- select *
	from ExtraTargetPerformerPartWorks t1
		join ExtraTargetPerformerParts t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId
		join TargetPerformerParts t3 on t2.Name = t3.Name

-- TargetPerformerPartWorks
	insert TargetPerformerPartWorks(TargetPerformerPartId, WorkId)
	select TargetPerformerPartId, WorkId
	from ExtraTargetPerformerPartWorks

	drop table if exists #ExtraTargetPerformerPartIdsToAdd

-- АВТОРИ

-- Коди авторів які слід додати без дублювання
	drop table if exists #ExtraTargetAuthorPartIdsToAdd

	select t1.TargetAuthorPartId
	into #ExtraTargetAuthorPartIdsToAdd
	from ExtraTargetAuthorParts t1
		left join TargetAuthorParts t2 on t1.Name = t2.Name
	where t2.Name is null

	-- select * from #ExtraTargetAuthorPartIdsToAdd

-- TargetAuthorParts
	insert TargetAuthorParts(TargetAuthorPartId, Name)
	select t1.TargetAuthorPartId, t1.Name
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorPartIdsToAdd t2 on t1.TargetAuthorPartId = t2.TargetAuthorPartId

-- TargetAuthorPartWorks
	insert TargetAuthorPartWorks(TargetAuthorPartId, WorkId)
	select TargetAuthorPartId, WorkId
	from ExtraTargetAuthorPartWorks

	drop table if exists #ExtraTargetAuthorPartIdsToAdd

-- Коди творів для яких створена інформація для пошуку

	insert TargetWorks(TargetWorkId, WorkId)
	select t1.TargetWorkId, t1.WorkId 
	from ExtraTargetWorks t1
		left join TargetWorks t2 on t1.WorkId = t2.WorkId
	where t2.WorkId is null

end

end -- PROCEDURE
go