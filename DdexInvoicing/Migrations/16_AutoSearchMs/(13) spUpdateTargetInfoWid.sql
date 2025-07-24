use AutoSearch
go

create or alter procedure spUpdateTargetInfoWid
as
begin

-- =================================== РОБОЧА ІНФОРМАЦІЯ ДЛЯ ОНОВЛЕННЯ ІНФОРМАЦІЇ ДЛЯ ПОШУКУ
-- Інформація робоча, після передачі в головні таблиці інформація з цих таблиць видаляється
begin

-- НАЗВИ
-- Початковий системний код нової інформації стосовно творів
	declare @baseTargetWorkId int = (select isnull(max(TargetWorkId), 0) from TargetWorksWid)

-- ExtraTargetWorks
	update SearchStepsWid set Status = 1 where Id = 7
	truncate table ExtraTargetWorks
	insert ExtraTargetWorks(TargetWorkId, WorkId, Name, Authors, Performers)
	select @baseTargetWorkId + row_number() over(order by t1.Wic), t1.Wic, t1.Name, t1.author, t1.performer
	from SocWid..widTitle t1
		left join TargetWorksWid t2 on t1.Wic = t2.Wic
	where t2.Wic is null
	update SearchSteps set Status = 2 where Id = 7

	-- select * from ExtraTargetWorks

-- ExtraTargetNames
-- Початковий системний код нової інформації стосовно назв
	declare @baseTargetNameId int = (select isnull(max(TargetNameId), 0) from TargetNamesWid)
	update SearchStepsWid set Status = 1 where Id = 8
	truncate table ExtraTargetNames
	; with TmpNames as (
		select distinct Name
		from ExtraTargetWorks
	)
	insert ExtraTargetNames(TargetNameId, Name)
	select @baseTargetNameId + row_number() over(order by Name), Name
	from TmpNames
	update SearchStepsWid set Status = 2 where Id = 8

	-- select * from ExtraTargetNames

-- ExtraTargetNamesT
	update SearchStepsWid set Status = 1 where Id = 9
	truncate table ExtraTargetNamesT
	insert ExtraTargetNamesT(TargetNameId, Name)
	select TargetNameId, AutoSearch.dbo.ClrTranslitFromUkrToLat(Name)
	from ExtraTargetNames
	update SearchStepsWid set Status = 2 where Id = 9

	-- select * from ExtraTargetNamesT

-- ExtraTargetNameWorks
	update SearchStepsWid set Status = 1 where Id = 10
	truncate table ExtraTargetNameWorks
	insert ExtraTargetNameWorks(TargetNameId, WorkId, Wic, Wic)
	select distinct t1.TargetNameId, t2.WorkId, null, null
	from ExtraTargetNames t1
		join ExtraTargetWorks t2 on t1.Name = t2.Name
	update SearchStepsWid set Status = 2 where Id = 10

	-- select * from ExtraTargetNameWorks

-- ВИКОНАВЦІ
-- Додаткова інформація без дублювань (назви транслітеровані)
	update SearchStepsWid set Status = 1 where Id = 11
	drop table if exists #ExtraTargetPerformerParts
	select distinct WorkId, left(AutoSearch.dbo.ClrTranslitFromUkrToLat(value), 64) as Name
	into #ExtraTargetPerformerParts
	from ExtraTargetWorks
		cross apply string_split(Performers, ' ')
	where len(value) > 2
	update SearchStepsWid set Status = 2 where Id = 11

	-- select * from #ExtraTargetPerformerParts

-- Початковий системний код нової інформації стосовно виконавців
	update SearchStepsWid set Status = 2 where Id = 12
	declare @baseTargetPerformerPart int = (select isnull(max(TargetPerformerPartId), 0) from TargetPerformerPartsWid)

-- ExtraTargetPerformerParts
	truncate table ExtraTargetPerformerParts
	; with TmpTargetPerformerParts as (
		select distinct Name
		from #ExtraTargetPerformerParts
	)
	insert ExtraTargetPerformerParts(TargetPerformerPartId, Name)
	select @baseTargetPerformerPart + row_number() over(order by Name), Name
	from TmpTargetPerformerParts
	update SearchStepsWid set Status = 2 where Id = 12

	-- select * from ExtraTargetPerformerParts

-- ExtraTargetPerformerPartWorks
	update SearchStepsWid set Status = 1 where Id = 13
	truncate table ExtraTargetPerformerPartWorks
	insert ExtraTargetPerformerPartWorks(TargetPerformerPartId, WorkId)
	select t1.TargetPerformerPartId, t2.WorkId
	from ExtraTargetPerformerParts t1
		join #ExtraTargetPerformerParts t2 on t1.Name = t2.Name
	update SearchStepsWid set Status = 2 where Id = 13

	-- select * from ExtraTargetPerformerPartWorks

	drop table if exists #ExtraTargetPerformerParts

-- АВТОРИ
-- Додаткова інформація без дублювань (назви транслітеровані)
	update SearchStepsWid set Status = 1 where Id = 14
	drop table if exists #ExtraTargetAuthorParts
	select distinct WorkId, left(AutoSearch.dbo.ClrTranslitFromUkrToLat(value), 64) as Name
	into #ExtraTargetAuthorParts
	from ExtraTargetWorks
		cross apply string_split(Authors, ' ')
	where len(value) > 2
	update SearchStepsWid set Status = 2 where Id = 14
	-- select * from #ExtraTargetAuthorParts

-- Початковий системний код нової інформації стосовно виконавців
	declare @baseTargetAuthorPart int = (select isnull(max(TargetAuthorPartId), 0) from TargetAuthorPartsWid)

-- ExtraTargetAuthorParts
	update SearchStepsWid set Status = 1 where Id = 15
	truncate table ExtraTargetAuthorParts
	; with TmpTargetAuthorParts as (
		select distinct Name
		from #ExtraTargetAuthorParts
	)
	insert ExtraTargetAuthorParts(TargetAuthorPartId, Name)
	select @baseTargetAuthorPart + row_number() over(order by Name), Name
	from TmpTargetAuthorParts
	update SearchStepsWid set Status = 2 where Id = 15

	-- select * from ExtraTargetAuthorParts

-- ExtraTargetAuthorPartWorks
	update SearchStepsWid set Status = 1 where Id = 16
	truncate table ExtraTargetAuthorPartWorks
	insert ExtraTargetAuthorPartWorks(TargetAuthorPartId, WorkId)
	select t1.TargetAuthorPartId, t2.WorkId
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorParts t2 on t1.Name = t2.Name
	update SearchStepsWid set Status = 2 where Id = 16

	-- select * from ExtraTargetAuthorPartWorks

	drop table if exists #ExtraTargetAuthorParts
end

-- =================================== РОЗШИРЕННЯ ІНФОРМАЦІЮ ДЛЯ ПОШУКУ
-- Таблиці постійні
begin
-- НАЗВИ
-- Коди назв які слід додати без дублювання
	update SearchStepsWid set Status = 1 where Id = 17
	drop table if exists #ExtraTargetNameIdsToAdd
	select t1.TargetNameId
	into #ExtraTargetNameIdsToAdd
	from ExtraTargetNames t1
		left join TargetNamesWid t2 on t1.Name = t2.Name
	where t2.Name is null
	update SearchStepsWid set Status = 2 where Id = 17
	-- select * from #ExtraTargetNameIdsToAdd

-- TargetNames
	update SearchStepsWid set Status = 1 where Id = 18
	insert TargetNamesWid(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNames t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId
	update SearchStepsWid set Status = 2 where Id = 18
	-- select * from TargetNames

-- TargetNamesT
	update SearchStepsWid set Status = 1 where Id = 19
	insert TargetNamesWidT(TargetNameId, Name)
	select t1.TargetNameId, t1.Name
	from ExtraTargetNamesT t1
		join #ExtraTargetNameIdsToAdd t2 on t1.TargetNameId = t2.TargetNameId
	update SearchStepsWid set Status = 2 where Id = 19

-- Коригуємо посилання
	update SearchStepsWid set Status = 1 where Id = 20
	update t1
	set t1.TargetNameId = t3.TargetNameId
	--select *
	from ExtraTargetNameWorks t1
		join ExtraTargetNames t2 on t1.TargetNameId = t2.TargetNameId
		join TargetNamesWid t3 on t2.Name = t3.Name
	update SearchStepsWid set Status = 2 where Id = 20

-- TargetNameWorks
	update SearchStepsWid set Status = 1 where Id = 21
	insert TargetNameWorksWid(TargetNameId, WorkId, Wic, Wic)
	select TargetNameId, WorkId, Wic, Wic
	from ExtraTargetNameWorks
	update SearchStepsWid set Status = 2 where Id = 21

	drop table if exists #ExtraTargetNameIdsToAdd

-- ВИКОНАВЦІ

-- Коди виконавців які слід додати без дублювання
	update SearchStepsWid set Status = 1 where Id = 22
	drop table if exists #ExtraTargetPerformerPartIdsToAdd

	select t1.TargetPerformerPartId
	into #ExtraTargetPerformerPartIdsToAdd
	from ExtraTargetPerformerParts t1
		left join TargetPerformerPartsWid t2 on t1.Name = t2.Name
	where t2.Name is null
	update SearchStepsWid set Status = 2 where Id = 22

	-- select * from #ExtraTargetPerformerPartIdsToAdd

-- TargetPerformerParts
	update SearchStepsWid set Status = 1 where Id = 23
	insert TargetPerformerPartsWid(TargetPerformerPartId, Name)
	select t1.TargetPerformerPartId, t1.Name
	from ExtraTargetPerformerParts t1
		join #ExtraTargetPerformerPartIdsToAdd t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId
	update SearchStepsWid set Status = 2 where Id = 23

-- Коригуємо посилання
	update SearchStepsWid set Status = 1 where Id = 24
	update t1
	set t1.TargetPerformerPartId = t3.TargetPerformerPartId
	-- select *
	from ExtraTargetPerformerPartWorks t1
		join ExtraTargetPerformerParts t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId
		join TargetPerformerPartsWid t3 on t2.Name = t3.Name
	update SearchStepsWid set Status = 2 where Id = 24

-- TargetPerformerPartWorks
	update SearchStepsWid set Status = 1 where Id = 25
	insert TargetPerformerPartWorksWid(TargetPerformerPartId, WorkId)
	select TargetPerformerPartId, WorkId
	from ExtraTargetPerformerPartWorks
	update SearchStepsWid set Status = 2 where Id = 25

	drop table if exists #ExtraTargetPerformerPartIdsToAdd

-- АВТОРИ

-- Коди авторів які слід додати без дублювання
	update SearchStepsWid set Status = 1 where Id = 26
	drop table if exists #ExtraTargetAuthorPartIdsToAdd

	select t1.TargetAuthorPartId
	into #ExtraTargetAuthorPartIdsToAdd
	from ExtraTargetAuthorParts t1
		left join TargetAuthorPartsWid t2 on t1.Name = t2.Name
	where t2.Name is null
	update SearchStepsWid set Status = 2 where Id = 26
	-- select * from #ExtraTargetAuthorPartIdsToAdd

-- TargetAuthorParts
	update SearchStepsWid set Status = 1 where Id = 27
	insert TargetAuthorPartsWid(TargetAuthorPartId, Name)
	select t1.TargetAuthorPartId, t1.Name
	from ExtraTargetAuthorParts t1
		join #ExtraTargetAuthorPartIdsToAdd t2 on t1.TargetAuthorPartId = t2.TargetAuthorPartId
	update SearchStepsWid set Status = 2 where Id = 27

-- TargetAuthorPartWorks
	update SearchStepsWid set Status = 1 where Id = 28
	insert TargetAuthorPartWorksWid(TargetAuthorPartId, WorkId)
	select TargetAuthorPartId, WorkId
	from ExtraTargetAuthorPartWorks
	update SearchStepsWid set Status = 2 where Id = 28

	drop table if exists #ExtraTargetAuthorPartIdsToAdd

-- Коди творів для яких створена інформація для пошуку
	update SearchStepsWid set Status = 1 where Id = 29
	insert TargetWorksWid(TargetWorkId, Wic)
	select t1.TargetWorkId, t1.WorkId 
	from ExtraTargetWorks t1
		left join TargetWorks t2 on t1.WorkId = t2.WorkId
	where t2.WorkId is null
	update SearchStepsWid set Status = 2 where Id = 29

end

end -- PROCEDURE
go

-- exec spUpdateTargetInfoWid