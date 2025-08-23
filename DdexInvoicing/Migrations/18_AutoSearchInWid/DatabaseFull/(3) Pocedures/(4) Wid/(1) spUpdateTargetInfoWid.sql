use AutoSearch
go

create or alter procedure spUpdateTargetInfoWid
as
begin -- PEROCEDURE

begin try

begin -- Заповнення таблиці ExtraTargetWorksWid (select count(*) from ExtraTargetWorksWid)
	exec spSetSearchStepStarted 7
	drop table if exists ExtraTargetWorksWid
	select t1.Wic
	into ExtraTargetWorksWid
	from SocWid..WidTitle t1
		left join TargetWorksWid t2 on t1.Wic = t2.Wic
	where t2.Wic is null
		and trim(isnull(t1.WrkTtl, '')) <> ''
	exec spSetSearchStepEnded 7
end

begin -- =================================== ІНФОРМАЦІЯ ПРО НАЗВИ

	-- Робочі таблиці

	begin -- Заповнення таблиці ExtraTargetNamesWid (select count(*) from ExtraTargetNamesWid)
		exec spSetSearchStepStarted 8
		declare @baseTargetNameId int = (select isnull(max(TargetNameId), 0) from TargetNamesWid)
		drop table if exists ExtraTargetNamesWid
		; with TmpNames as (
			select WrkTtl as Name
			from SocWid..widTitle
			union
			select AltTtl as Name
			from SocWid..widAltTtl
		)
		select 
			  @baseTargetNameId + row_number() over(order by t1.Name)	as TargetNameId
			, t1.Name													as Name
		into ExtraTargetNamesWid
		from TmpNames t1
			left join TargetNamesWid t2 on t1.Name = t2.Name
		where t2.Name is null
		exec spSetSearchStepEnded 8
	end

	begin -- Заповнення таблиці ExtraTargetNameWorksWid (select count(*) from ExtraTargetNameWorksWid)
		exec spSetSearchStepStarted 9
		drop table if exists ExtraTargetNameWorksWid
		; with Dist as (
			select t1.TargetNameId, t2.Wic
			from ExtraTargetNamesWid t1
				join SocWid..WidTitle t2 on t1.Name = t2.WrkTtl
			union
				select t1.TargetNameId, t2.Wic
				from ExtraTargetNamesWid t1
					join SocWid..widAltTtl t2 on t1.Name = t2.AltTtl
		)
		select t1.TargetNameId, t1.Wic
		into ExtraTargetNameWorksWid
		from Dist t1
			left join TargetNameWorksWid t2 on t1.TargetNameId = t2.TargetNameId
		where t2.TargetNameId is null
		exec spSetSearchStepEnded 9
	end

	-- Додаємо інформацію до постійних таблиць. Робимо через SELECT INTO  щоб позбавитись логу транзакцій

	begin -- TargetNamesWid
		exec spSetSearchStepStarted 10
		exec spRestoreTable 'TargetNamesWid' -- якщо головна втрачена відновиться з резервної копії
		drop table if exists #TargetNamesWid -- Потрібний результат
			select * into #TargetNamesWid from TargetNamesWid
				union select * from ExtraTargetNamesWid
		drop table if exists Back_TargetNamesWid -- резервна копія головної таблиці
			select * into Back_TargetNamesWid from TargetNamesWid
		drop table if exists TargetNamesWid -- Оновлення (перебудова) постійної таблиці
			select * into TargetNamesWid from #TargetNamesWid
			create unique nonclustered index idx_TargetNamesWid_Name on TargetNamesWid(Name)
		drop table if exists Back_TargetNamesWid -- видаляємо резервну копію якщо головна таблиця успішно оновлена
		drop table if exists #TargetNamesWid
		exec spSetSearchStepEnded 10
	end

	begin -- Коригуємо посилання - встановлюємо посилання на додані раніш назви в постіних таблицях
		exec spSetSearchStepStarted 11
		update t1
		set t1.TargetNameId = t3.TargetNameId
		from ExtraTargetNameWorksWid t1
			join ExtraTargetNamesWid t2 on t1.TargetNameId = t2.TargetNameId
			join TargetNamesWid t3 on t2.Name = t3.Name
		exec spSetSearchStepEnded 11
	end

	begin -- TargetNameWorksWid
		exec spSetSearchStepStarted 12
		exec spRestoreTable 'TargetNameWorksWid' -- якщо головна втрачена відновиться з резервної копії
		drop table if exists #TargetNameWorksWid -- Потрібний результат
			select * into #TargetNameWorksWid from TargetNameWorksWid
				union select * from ExtraTargetNameWorksWid
		drop table if exists Back_TargetNameWorksWid -- резервна копія головної таблиці
			select * into Back_TargetNameWorksWid from TargetNameWorksWid
		drop table if exists TargetNameWorksWid -- Оновлення (перебудова) постійної таблиці
			select * into TargetNameWorksWid from #TargetNameWorksWid
			create nonclustered index idx_TargetNameWorksWid_TargetNameId on TargetNameWorksWid(TargetNameId)
			create nonclustered index Wic on TargetNameWorksWid(Wic)
		drop table if exists Back_TargetNameWorksWid -- видаляємо резервну копію якщо головна таблиця успішно оновлена
		drop table if exists #TargetNameWorksWid
		exec spSetSearchStepEnded 12
	end
end -- =================================== ІНФОРМАЦІЯ ПРО НАЗВИ

begin -- =================================== ІНФОРМАЦІЯ ПРО ВИКОНАВЦІВ

	-- Робочі таблиці

	begin -- #ExtraTargetPerformerPartsWid
		exec spSetSearchStepStarted 13
		drop table if exists #ExtraTargetPerformerPartsWid
		; with Parts as (
			select t1.Wic, left(t1.PerfArtistFstName, 64) as Name
			from SocWid..WidArtist t1
				join ExtraTargetWorksWid t2 on t1.Wic = t2.Wic
			where isnull(t1.PerfArtistFstName, '') <> ''
			union
			select t1.Wic, left(t1.PerfArtistLstName, 64) as Name
			from SocWid..WidArtist t1
				join ExtraTargetWorksWid t2 on t1.Wic = t2.Wic
			where isnull(t1.PerfArtistLstName, '') <> ''
		),
		NewParts as (
			select t1.Wic, t1.Name
			from Parts t1
				left join TargetPerformerPartsWid t2 on t1.Name = t2.Name
			where t2.Name is null
		)
		select distinct Wic, trim(value) as Name
		into #ExtraTargetPerformerPartsWid
		from NewParts
			cross apply string_split(Name, ' ')
		where len(trim(value)) > 2
		exec spSetSearchStepEnded 13
	end

	begin -- ExtraTargetPerformerPartsWid
		exec spSetSearchStepStarted 14
		declare @baseTargetPerformerPart int = (select isnull(max(TargetPerformerPartId), 0) from TargetPerformerPartsWid)
		drop table if exists ExtraTargetPerformerPartsWid
		; with TmpTargetPerformerParts as (
			select distinct Name
			from #ExtraTargetPerformerPartsWid
		)
		select 
			  @baseTargetPerformerPart + row_number() over(order by Name) as TargetPerformerPartId
			, Name as Name
		into ExtraTargetPerformerPartsWid
		from TmpTargetPerformerParts
		exec spSetSearchStepEnded 14
	end

	begin  -- ExtraTargetPerformerPartWorksWid
		exec spSetSearchStepStarted 15
		drop table if exists ExtraTargetPerformerPartWorksWid
		select t1.TargetPerformerPartId, t2.Wic
		into ExtraTargetPerformerPartWorksWid
		from ExtraTargetPerformerParts t1
			join #ExtraTargetPerformerPartsWid t2 on t1.Name = t2.Name
		exec spSetSearchStepEnded 15
	end

	drop table if exists #ExtraTargetPerformerPartsWid

	-- Додаємо інформацію до постійних таблиць. Робимо через SELECT INTO  щоб позбавитись логу транзакцій

	begin-- TargetPerformerPartsWid
		exec spSetSearchStepStarted 16
		exec spRestoreTable 'TargetPerformerPartsWid' -- якщо головна втрачена відновиться з резервної копії
		drop table if exists #TargetPerformerPartsWid -- Потрібний результат
			select *
			into #TargetPerformerPartsWid 
			from TargetPerformerPartsWid
			union 
			select t1.* 
				from ExtraTargetPerformerPartsWid t1
					left join TargetPerformerPartsWid t2 on t1.Name = t2.Name
				where t2.Name is null
		drop table if exists Back_TargetPerformerPartsWid -- резервна копія головної таблиці
			select * into Back_TargetPerformerPartsWid from TargetPerformerPartsWid
		drop table if exists TargetPerformerPartsWid -- Оновлення (перебудова) постійної таблиці
			select * into TargetPerformerPartsWid from #TargetPerformerPartsWid
			create unique nonclustered index idx_TargetPerformerPartsWid_Name on TargetPerformerPartsWid(Name)
		drop table if exists Back_TargetPerformerPartsWid -- видаляємо резервну копію якщо головна таблиця успішно оновлена
		drop table if exists #TargetPerformerPartsWid
		exec spSetSearchStepEnded 16
	end

	begin -- Коригуємо посилання
		exec spSetSearchStepStarted 17
		update t1
		set t1.TargetPerformerPartId = t3.TargetPerformerPartId
		from ExtraTargetPerformerPartWorks t1
			join ExtraTargetPerformerParts t2 on t1.TargetPerformerPartId = t2.TargetPerformerPartId
			join TargetPerformerPartsWid t3 on t2.Name = t3.Name
		exec spSetSearchStepEnded 17
	end
	
	begin-- TargetPerformerPartWorksWid
		exec spSetSearchStepStarted 18
		exec spRestoreTable 'TargetPerformerPartWorksWid' -- якщо головна втрачена відновиться з резервної копії
		drop table if exists #TargetPerformerPartWorksWid -- Потрібний результат
			select * into #TargetPerformerPartWorksWid from TargetPerformerPartWorksWid
				union select * from ExtraTargetPerformerPartWorksWid
		drop table if exists Back_TargetPerformerPartWorksWid -- резервна копія головної таблиці
			select * into Back_TargetPerformerPartWorksWid from TargetPerformerPartWorksWid
		drop table if exists TargetPerformerPartWorksWid -- Оновлення (перебудова) постійної таблиці
			select * into TargetPerformerPartWorksWid from #TargetPerformerPartWorksWid
			create nonclustered index idx_TargetPerformerPartWorksWid_TargetPerformerPartWorks on TargetPerformerPartWorksWid(TargetPerformerPartId)
			create nonclustered index idx_TargetPerformerPartWorksWid_WorkId on TargetPerformerPartWorksWid(WorkId)
		drop table if exists Back_TargetPerformerPartWorksWid -- видаляємо резервну копію якщо головна таблиця успішно оновлена
		drop table if exists #TargetPerformerPartWorksWid
		exec spSetSearchStepEnded 18
	end

end -- <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ІНФОРМАЦІЯ ПРО ВИКОНАВЦІВ

begin -- =================================== ІНФОРМАЦІЯ ПРО АВТОРІВ

	-- Робочі таблиці

	begin -- #WicAuthorNames (select top 1000 * from #WicAuthorNames order by Name)
		exec spSetSearchStepStarted 19
		drop table if exists #WicAuthorNames
		select distinct t1.Wic, t2.Name as Name
		into #WicAuthorNames
		from SocWid..widIntrPty t1
			join SocIpi..IpiName t2 on t1.IpNameNr = t2.IpNameNr
			join ExtraTargetWorksWid t3 on t1.Wic = t3.Wic
		where t1.IpRole in ('C', 'A', 'CA', 'AR')
		exec spSetSearchStepEnded 19
	end

	begin -- #WicAuthorNameParts
		exec spSetSearchStepStarted 20
		drop table if exists #WicAuthorNameParts
		select distinct Wic, trim(value) as Name
		into #WicAuthorNameParts
		from #WicAuthorNames
			cross apply string_split(Name, ' ')
		where len(trim(value)) > 2
		exec spSetSearchStepEnded 20
	end

	drop table #WicAuthorNames

	begin -- ExtraTargetAuthorPartsWid
		exec spSetSearchStepStarted 21
		declare @baseTargetAuthorPart int = (select isnull(max(TargetAuthorPartId), 0) from TargetAuthorPartsWid)
		drop table if exists ExtraTargetAuthorPartsWid
		; with TmpTargetAuthorParts as (
			select distinct Name
			from #WicAuthorNameParts
		)
		select 
			  @baseTargetAuthorPart + row_number() over(order by Name) as TargetAuthorPartId
			, left(Name, 64) as Name
		into ExtraTargetAuthorPartsWid
		from TmpTargetAuthorParts
		exec spSetSearchStepEnded 21
	end

	begin -- ExtraTargetAuthorPartWorksWid
		exec spSetSearchStepStarted 22
		drop table if exists ExtraTargetAuthorPartWorksWid
		select t1.TargetAuthorPartId, t2.Wic as WorkId
		into ExtraTargetAuthorPartWorksWid
		from ExtraTargetAuthorPartsWid t1
			join #WicAuthorNameParts t2 on t1.Name = t2.Name
		exec spSetSearchStepEnded 22
	end

	drop table if exists #WicAuthorNameParts
	drop table if exists #ExtraTargetAuthorParts

	-- Додаємо інформацію до постійних таблиць. Робимо через SELECT INTO  щоб позбавитись логу транзакцій

	begin -- TargetAuthorPartsWid
		exec spSetSearchStepStarted 23
		exec spRestoreTable 'TargetAuthorPartsWid' -- якщо головна втрачена відновиться з резервної копії
		drop table if exists #TargetAuthorPartsWid -- Потрібний результат
			select * into #TargetAuthorPartsWid from TargetAuthorPartsWid
				union select * from ExtraTargetAuthorPartsWid
		drop table if exists Back_TargetAuthorPartsWid -- резервна копія головної таблиці
			select * into Back_TargetAuthorPartsWid from TargetAuthorPartsWid
		drop table if exists TargetAuthorPartsWid -- Оновлення (перебудова) постійної таблиці
			select * into TargetAuthorPartsWid from #TargetAuthorPartsWid
			create nonclustered index idx_TargetAuthorPartsWid_Name on TargetAuthorPartsWid(Name)
		drop table if exists Back_TargetAuthorPartsWid 
		exec spSetSearchStepEnded 23
	end

	begin-- TargetAuthorPartWorksWid
		exec spSetSearchStepStarted 24
		exec spRestoreTable 'TargetAuthorPartWorksWid' -- якщо головна втрачена відновиться з резервної копії
		drop table if exists #TargetAuthorPartWorksWid -- Потрібний результат
			select * into #TargetAuthorPartWorksWid from TargetAuthorPartWorksWid
				union select * from ExtraTargetAuthorPartWorksWid
		drop table if exists Back_TargetAuthorPartWorksWid -- резервна копія головної таблиці
			select * into Back_TargetAuthorPartWorksWid from TargetAuthorPartWorksWid
		drop table if exists TargetAuthorPartWorksWid -- Оновлення (перебудова) постійної таблиці
			select * into TargetAuthorPartWorksWid from #TargetAuthorPartWorksWid
			create nonclustered index idx_TargetAuthorPartWorksWid_TargetAuthorPartWorks on TargetAuthorPartWorksWid(TargetAuthorPartId)
			create nonclustered index idx_TargetAuthorPartWorksWid_Wic on TargetAuthorPartWorksWid(Wic)
		drop table if exists Back_TargetAuthorPartsWid 
		exec spSetSearchStepEnded 24
	end
	
	drop table if exists #TargetAuthorPartWorksWid
	drop table if exists #ExtraTargetAuthorPartIdsToAdd

end -- <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ІНФОРМАЦІЯ ПРО АВТОРІВ

begin -- TargetWorksWid - Коди творів для яких створена інформація для пошуку
	exec spSetSearchStepStarted 25
	exec spRestoreTable 'TargetWorksWid' -- якщо головна втрачена відновиться з резервної копії
		drop table if exists #TargetWorksWid -- Потрібний результат
			select * into #TargetWorksWid from TargetWorksWid
				union select * from ExtraTargetWorksWid
		drop table if exists Back_TargetWorksWid -- резервна копія головної таблиці
			select * into Back_TargetWorksWid from TargetWorksWid
		drop table if exists TargetWorksWid -- Оновлення (перебудова) постійної таблиці
			select * into TargetWorksWid from #TargetWorksWid
		drop table if exists Back_TargetAuthorPartsWid 
	drop table if exists #TargetWorksWid
	exec spSetSearchStepEnded 25
end

end try
begin catch
	throw
end catch


end -- PROCEDURE
go

-- exec spUpdateTargetInfoWid