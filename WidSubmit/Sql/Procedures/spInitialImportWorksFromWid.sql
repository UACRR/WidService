use SocWidSubmitEx
go

create or alter procedure spInitialImportWorksFromWid
as
begin

-- ВИКОРИСТОВУЄТЬСЯ ЛИШЕ НАПОЧАТКУ
	if (select count(*) from Submission) > 1 return

	
-- ТВОРИ ДЛЯ ДОДАВАННЯ ДО ПОЧАТКОВОГО СЕАНСУ
	drop table if exists #ExtraPublishedWorks
	select distinct
		  t4.ObjId
		, max(t2.Wic) as Wic -- !!! Коду ISWC може відповідати декілька творів у ВІД
	into #ExtraPublishedWorks
	from vCurOwnRightHolder t1
		join SocWid..widIntrPty t2 on t1.IpNameNr = t2.IpNameNr
		join SocWid..WidIswc t3 on t2.Wic = t3.Wic
		join MediaService..MediaTrack t4 on t3.Iswc = t4.Iswc
		left join vCurSubmWorks t5 on t4.ObjId = t5.ObjId -- щоб не розглядати вже додані до сеансу твори
	where
		    t1.IsActive = 1 -- Розглядаємо лише активних
		and isnull(t1.IpNameNr, '') <> '' -- І твори яких можна знайти за міжнародним кодом
		and t5.ObjId is null -- І які не передані з попередньої версії додатку
	group by t4.ObjId, t1.CustId

-- МОЖУТЬ ЗЯВИТИСЬ ПОВЯЗАНІ З ДОДАТКОВИМИ ТВОРАМИ СТОРОННІ ПРАВОВЛАСНИКИ
	drop table if exists #RightHolder
	; with ExtraRightHolders as (
		select distinct t3.CustId
		from #ExtraPublishedWorks t1
			join SocWid..WidIntrPty t2 on t1.Wic = t2.Wic
			join MediaService..RightHolder t3 on t2.IpNameNr = t3.IPIBase -- В СМАРТ ЗНАХОДЯТЬСЯ НЕ ВСІ
			left join vCurRightHolder t4 on t3.CustId = t4.CustId
		where t4.CustId is null
	)
	select
		  dbo.fnMinDate()	as ValidFrom
		, dbo.fnMaxDate()	as ValidTo
		, getdate()			as CreatedAt
		, t1.CustId			as CustId
		, t2.rHolderType	as RhType
		, t2.interCode		as IpBaseNr
		, t2.IPIBase		as IpNameNr
		, t3.Name			as Name
		, t3.FstName as		FstName
		, t3.NameForWid		as NameForWid
		, t3.FstNameForWid	as FstNameForWid
		, 0					as IsOwn
		, 0					as IsActive
		, 0					as HasIpiAgreePer
		, 0					as HasIpiAgreeMec
	into #RightHolder
	from ExtraRightHolders t1
		join MediaService..RightHolder t2 on t1.CustId = t2.CustId
		join vCustomerNamesForWid t3 on t2.custId = t3.CustId -- може виключити певні рядки

-- ДОДАТКОВІ ПРАВОВЛАСНИКИ СЕАНСУ
	drop table if exists #SubmRightHolder
	; with ExtraWorksCustIds as (
		select distinct t3.CustId
		from #ExtraPublishedWorks t1
			join SocWid..WidIntrPty t2 on t1.Wic = t2.Wic
			join MediaService..RightHolder t3 on t2.IpNameNr = t3.IPIBase -- В СМАРТ ЗНАХОДЯТЬСЯ НЕ ВСІ
	)
	select distinct
		  dbo.fnCurSubmId() as SubmissionId
		, t3.Id				as RightHolderId
		, 1					as SubmAsOwn
		, getdate()			as CreatedAt
	into #SubmRightHolder
	from ExtraWorksCustIds t1
		left join vCurOwnRightHolder t2 on t1.CustId = t2.CustId
		join vCurRightHolder t3 on t1.CustId = t3.CustId
	where t2.CustId is null

-- ТВОРИ ДЛЯ ДОДАВАННЯ У ПОТРІБНОМУ ФОРМАТІ
	drop table if exists #SubmWork
	select distinct
		  dbo.fnCurSubmId() as SubmissionId
		, t1.ObjId as ObjId
		, t1.Wic as Wic
		, t2.Iswc as Iswc
		, t2.Name as Name
		, t3.WrkTtl as NameForWid
		, 0 as IsChanged
		, 7 as Status
		, getdate() as CreatedAt
		, null as UpdatedAt
	into #SubmWork
	from #ExtraPublishedWorks t1
		join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
		join SocWid..widTitle t3 on t1.Wic = t3.Wic

-- Аналіз проблем
	-- 1. Є різні твори СМАРТ які посилаються на той самий твір ВІД
		-- select Wic, count(*) from #SubmWork group by Wic having count(*) > 1
	-- Приклад
	--    select t1.ObjId, t1.Wic, t1.Iswc, t1.NameForWid as [Назва ВІД]
	--    	, t2.Name as [Назва СМАРТ]
	--    	, t2.lyrics as [Поети СМАРТ], t2.Composers as [Композитори СМАРТ], t2.Performers as [Виконавці СМАРТ]
	--    	, t2.ModifyDate as [Дата зміни СМАРТ]
	--    from #SubmWork t1
	--    	join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
	--    where t1.Wic in (select Wic from #SubmWork group by Wic having count(*) > 1)
	--    	and t1.Wic = 33786442 -- 41520286 41553157
	--    order by t1.Wic, t1.ObjId

-- ПРОЦЕНТИ ТВОРІВ
	drop table if exists #Parties
	select t1.ObjId, t2.*
	into #Parties
	from #SubmWork t1
		join SocWid..widIntrPty t2 on t1.Wic = t2.Wic

	drop table if exists #SharesPer
	select t1.ObjId, t1.IpNameNr, t1.IpRole, t2.*
	into #SharesPer
	from #Parties t1
		left join SocWid..WidShares t2 on t1.Wic = t2.Wic
			and t1.RolId = t2.IntrPtyRolid
			and t2.RightType = 'PER'

	drop table if exists #SharesMec
	select t1.ObjId, t1.IpNameNr, t2.*
	into #SharesMec
	from #Parties t1
		left join SocWid..WidShares t2 on t1.Wic = t2.Wic
			and t1.RolId = t2.IntrPtyRolid
			and t2.RightType = 'MEC'

	drop table if exists #SubmWorkShare
	select
		  t1.ObjId as ObjId --SubmWorkId	   -- Тимчасово
		, t1.IpNameNr as IpNameNr -- RightHolderId -- Тимчасово
		, t1.IpRole as RhRole
		, t1.IpRole as RoleForWid
		, isnull(t2.Shares, 0) as ShrPer
		, isnull(t3.Shares, 0) as ShrMec
		, getdate() as CreatedAt
		, null as UpdatedAt
	into #SubmWorkShare
	from #Parties t1
		left join #SharesPer t2 on t1.ObjId = t2.ObjId -- Слід поєднувати з кодом смарт бо різні твори СМАРТ можуть мати той самий ISWC
			and t1.Wic = t2.Wic
			and t1.RolId = t2.IntrPtyRolid
		left join #SharesMec t3 on t1.ObjId = t3.ObjId
			and t1.Wic = t3.Wic
			and t1.RolId = t3.IntrPtyRolid
	order by t1.Wic

-- АЛЬТЕРНАТИВНІ НАЗВИ
	drop table if exists #SubmWorkAltName
	select distinct
	    t1.ObjId  as ObjId
      , t2.AltTtl as OrigNames
      , t2.AltTtl as NameForWid
      , getdate() as CreatedAt
      , null      as UpdatedAt
	into #SubmWorkAltName
	from #SubmWork t1
		join SocWid..widAltTtl t2 on t1.Wic = t2.Wic

-- ВИКОНАВЦІ
	drop table if exists #SubmWorkPerformer
	select distinct
	    t1.ObjId													  as ObjId
      , trim(concat(t2.PerfArtistLstName, ' ', t2.PerfArtistFstName)) as OrigNames
      , trim(concat(t2.PerfArtistLstName, ' ', t2.PerfArtistFstName)) as NameForWid
      , getdate()													  as CreatedAt
      , null														  as UpdatedAt
	into #SubmWorkPerformer
	from #SubmWork t1
		join SocWid..WidArtist t2 on t1.Wic = t2.Wic

--=================================== ЗАСТОСУВАННЯ ЗМІН
	
	insert RightHolder (
		  ValidFrom
		, ValidTo
		, CreatedAt
		, CustId
		, RhType
		, IpBaseNr
		, IpNameNr
		, Name
		, FstName
		, NameForWid
		, FstNameForWid
		, IsOwn
		, IsActive
		, HasIpiAgreePer
		, HasIpiAgreeMec
	)
	select
		  ValidFrom
		, ValidTo
		, CreatedAt
		, CustId
		, RhType
		, IpBaseNr
		, IpNameNr
		, Name
		, FstName
		, NameForWid
		, FstNameForWid
		, IsOwn
		, IsActive
		, HasIpiAgreePer
		, HasIpiAgreeMec
	from #RightHolder

	insert SubmRightHolder (
		  SubmissionId
		, RightHolderId
		, SubmAsOwn
		, CreatedAt
	)
	select
		  SubmissionId
		, RightHolderId
		, SubmAsOwn
		, CreatedAt
	from #SubmRightHolder

	insert SubmWork (
		  SubmissionId
		, ObjId
		, Wic
		, Iswc
		, Name
		, NameForWid
		, IsChanged
		, Status
		, CreatedAt
		, UpdatedAt
	)
	select
		  SubmissionId
		, ObjId
		, Wic
		, Iswc
		, Name
		, NameForWid
		, IsChanged
		, Status
		, CreatedAt
		, UpdatedAt
	from #SubmWork

	insert SubmWorkShare (
		  SubmWorkId
		, RightHolderId
		, RhRole
		, RoleForWid
		, ShrPer
		, ShrMec
		, CreatedAt
		, UpdatedAt
	)
	select
		  t2.Id
		, t3.Id
		, case 
			when t1.RoleForWid = 'E'  then 8
			when t1.RoleForWid = 'CA' then 10
			when t1.RoleForWid = 'A'  then 1
			else						   2
		  end
		, t1.RoleForWid
		, t1.ShrPer
		, t1.ShrMec
		, t1.CreatedAt
		, t1.UpdatedAt
	from #SubmWorkShare t1
		join SubmWork t2 on t1.ObjId = t2.ObjId
		join vCurRightHolder t3 on t1.IpNameNr = t3.IpNameNr

	insert SubmWorkAltName (
	    SubmWorkId
      , OrigNames
      , NameForWid
      , CreatedAt
      , UpdatedAt
	)
	select
	    t2.Id
      , t1.OrigNames
      , t1.NameForWid
      , t1.CreatedAt
      , t1.UpdatedAt
	from #SubmWorkAltName t1
		join SubmWork t2 on t1.ObjId = t2.ObjId

	insert SubmWorkPerformer (
	    SubmWorkId
      , OrigNames
      , NameForWid
      , CreatedAt
      , UpdatedAt
	)
	select
	    t2.Id
      , t1.OrigNames
      , t1.NameForWid
      , t1.CreatedAt
      , t1.UpdatedAt
	from #SubmWorkPerformer t1
		join SubmWork t2 on t1.ObjId = t2.ObjId
	
	insert SubmCheckList (
        SubmWorkId
      , HasOwnRightHolder
      , RolesDefined
      , HasNonPublisher
      , AllInIpi
      , PubShare0or100
      , MecShare0or100
      , HasShare
	  , AllIpiCodesExist
      , AllIpiCodesValid
      , IsOk
	)
	select t2.Id, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
	from #SubmWork t1
		join SubmWork t2 on t1.ObjId = t2.ObjId

end
go
