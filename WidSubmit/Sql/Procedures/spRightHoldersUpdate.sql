use SocWidSubmitEx
go

create or alter procedure spRightHoldersUpdate
as
begin
	-- truncate table RightHolder

	-- Активні правовласники в СМАРТ
	drop table if exists #MsRightHolderActive
	select *
	into #MsRightHolderActive
	from vMsRightHoldersActive

	-- Активні правовласники і ті, які мають спільні твори з активними правовласниками
	-- ЗАУВАЖЕННЯ - не потраплять правовласники, у яких немає творів, якими вони володіють
	drop table if exists #MsCustIds
	select distinct t4.custId
	into #MsCustIds
	from #MsRightHolderActive t1
		join MediaService..CopyRight t2 on t1.CustId = t2.CustId
		join MediaService..MediaTrack t3 on t2.ObjId = t3.ObjId
		join MediaService..CopyRight t4 on t3.ObjId = t4.ObjId

	drop table if exists #MsRightHolder
	select distinct
		  t2.custId																as CustId
		, t2.InterCode															as IpBaseNr
		, t2.IPIBase															as IpNameNr
		, t4.Name																as Name
		, t4.FstName															as FstName
		, t4.NameForWid															as NameForWid
		, t4.FstNameForWid														as FstNameForWid
		, case 
			when t3.CustId is null
			then cast(0 as bit)
			else cast(1 as bit)
		  end																	as IsOwn
		, case 
			when t3.CustId is null
			then cast(0 as bit)
			else
				case
				when t3.agrStatus = 2
					and (t3.dateBegin is null or t3.dateBegin <= dbo.fnCurDate())
					and (t3.dateEnd is null or t3.dateEnd >= dbo.fnCurDate())
				then cast(1 as bit)
				else cast(0 as bit)
				end
		  end																	as IsActive
		, 0																		as HasIpiAgreePer  -- Попередньо
		, 0																		as HasIpiAgreeMec  -- Попередньо
	into #MsRightHolder
	from #MsCustIds t1
		join MediaService..RightHolder t2 on t1.CustId = t2.CustId
		left join MediaService..AgreementAddRH t3 on t1.custId = t3.custId
		join vCustomerNamesForWid t4 on t1.CustId = t4.CustId -- Не потраплять правовласники, які не мають анкети

--		select * 
--		from #MsRightHolder t1
--			join MediaService..AgreementAddRH t2 on t1.CustId = t2.CustId
--

	
	-- Встановлюємо HasIpiAgreePer, якщо є в IPI
	update t1
	set t1.HasIpiAgreePer = 1
	from #MsRightHolder t1
		join SocIpi..IpiAgreement t2 on isnull(t1.IpBaseNr, '') = t2.IpBaseNr
			and t2.SocCde = '140'
			and t2.CreClsCde = 'MW'
			and t2.RolCde in ('LY', 'MC', 'EM')
			and t2.RgtCde = 'PR'
			and dbo.fnCurDate() between t2.FromDt and t2.ToDt

	-- Встановлюємо HasIpiAgreeMec, якщо є в IPI
	update t1
	set t1.HasIpiAgreeMec = 1
	from #MsRightHolder t1
		join SocIpi..IpiAgreement t2 on isnull(t1.IpBaseNr, '') = t2.IpBaseNr
			and t2.SocCde = '140'
			and t2.CreClsCde = 'MW'
			and t2.RolCde in ('LY', 'MC', 'EM')
			and t2.RgtCde = 'MR'
			and dbo.fnCurDate() between t2.FromDt and t2.ToDt

--select * from #MsRightHolder where IsOwn = 1 and HasIpiAgreeMec = 0

	-- Коди всіх зареєстрованих правовласників в БД SocWidSubmitEx
	drop table if exists #RegisteredCustIds
	select distinct CustId
	into #RegisteredCustIds
	from RightHolder

	-- Нова інформація для правовласників які зазнали змін
	-- Тут CurId - останній історичний запис (поточний запис) для відповідного правовласника
	drop table if exists #SocRightHoldersChanged
	select 
		  t2.Id						as CurId
		, t1.CustId					as NewCustId		
		, t1.IpBaseNr				as NewIpBaseNr		
		, t1.IpNameNr				as NewIpNameNr		
		, t1.Name					as NewName
		, t1.FstName				as NewFstName
		, t1.NameForWid				as NewNameForWid
		, t1.FstNameForWid			as NewFstNameForWid
		, case
			when t1.IsActive = 1
			then cast(1 as bit)
			else t2.IsOwn
			end						as NewIsOwn	
		, t1.IsActive				as NewIsActive		
		, t1.HasIpiAgreePer			as NewHasIpiAgreePer	
		, t1.HasIpiAgreeMec			as NewHasIpiAgreeMec
	into #SocRightHoldersChanged
	from #MsRightHolder t1
		join RightHolder t2 on
			    t1.CustId = t2.CustId
			and t2.ValidTo = dbo.fnMaxDate()
			and t2.ValidFrom <= dbo.fnCurDate() -- запобіжник на випадок невірної дати на сервері
			and not (
					isnull(t1.IpBaseNr, '') = isnull(t2.IpBaseNr, '')
				and isnull(t1.IpNameNr, 0) = isnull(t2.IpNameNr, 0)
				and t1.Name = left(t2.Name, 255)
				and t1.FstName = left(t2.FstName, 255)
				and t1.IsActive = t2.IsActive
				and t1.HasIpiAgreePer = t2.HasIpiAgreePer
				and t1.HasIpiAgreeMec = t2.HasIpiAgreeMec
			)

	-- Правовласники які стали неактивними
	-- Тут CurId - останній історичний запис (поточний запис) для відповідного правовласника
	drop table if exists #SocRightHoldersDeactivated
	select 
		  t1.Id				as CurId
		, t1.CustId			as CustId		
		, t1.IpBaseNr		as IpBaseNr		
		, t1.IpNameNr		as IpNameNr		
		, t1.Name			as Name
		, t1.FstName		as FstName
		, t1.NameForWid		as NameForWid
		, t1.FstNameForWid	as FstNameForWid
		, t1.IsOwn			as IsOwn	
		, 0					as IsActive		
	into #SocRightHoldersDeactivated
	from RightHolder t1
		left join #MsRightHolderActive t2 on
			    t1.CustId = t2.CustId
	where t1.ValidTo = dbo.fnMaxDate()
		and t1.IsActive = 1
		and t2.CustId is null

	delete t1
	from #SocRightHoldersDeactivated t1
		join #SocRightHoldersChanged t2 on t1.CustId = t2.NewCustId

	-- ЗАСТОСУВАННЯ ЗМІН У НАЯВНИХ ПРАВОВЛАСНИКАХ, ЯКІ АКТИВНІ В СМАРТІ

	-- Якщо зміна трапилась вродовж того самого дня, змінюємо останній рядок
	update t1 
	set
		  t1.IpBaseNr		= t2.NewIpBaseNr		
		, t1.IpNameNr		= t2.NewIpNameNr		
		, t1.Name			= t2.NewName
		, t1.FstName		= t2.NewFstName
		, t1.NameForWid		= t2.NewNameForWid
		, t1.FstNameForWid	= t2.NewFstNameForWid
		, t1.IsOwn			= t1.IsOwn	
		, t1.IsActive		= t2.NewIsActive
		, t1.HasIpiAgreePer	= t2.NewHasIpiAgreePer
		, t1.HasIpiAgreeMec	= t2.NewHasIpiAgreeMec
	from RightHolder t1
		join #SocRightHoldersChanged t2 on t1.Id = t2.CurId
	where t1.ValidFrom = dbo.fnCurDate()

	-- Якщо зміна трапилась пізніше того самого дня, змінюємо фінальну дату останнього рядока
	-- і додаємо новий	
	update RightHolder 
	set ValidTo = dbo.fnPrevDate()
	where Id in (select CurId from #SocRightHoldersChanged)
		and ValidFrom <> dbo.fnCurDate()

	insert RightHolder (
		  ValidFrom
		, ValidTo
		, CreatedAt
		, CustId
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
		  dbo.fnCurDate()						as ValidFrom
		, dbo.fnMaxDate()				as ValidTo
		, dbo.fnCurDate()						as CreatedAt
		, t1.NewCustId					as CustId
		, t1.NewIpBaseNr				as IpBaseNr
		, t1.NewIpNameNr				as IpNameNr
		, left(t1.NewName, 255)			as Name
		, left(t1.NewFstName, 255)		as FstName
		, left(t1.NewNameForWid, 255)	as NameForWid
		, left(t1.NewFstNameForWid, 255) as FstNameForWid
		, 1								as IsOwn
		, 1								as IsActive			
		, t2.HasIpiAgreePer				as HasIpiAgreePer
		, t2.HasIpiAgreeMec				as HasIpiAgreeMec
	from #SocRightHoldersChanged t1
		join RightHolder t2 on t1.CurId = t2.Id
	where t2.ValidFrom <> dbo.fnCurDate()

	-- ДЕАКТИВАЦІЯ ПРАВОВЛАСНИКІВ, ЯКІ НЕ МІТЯТЬСЯ СЕРЕД АКТИВНИХ В СМАРТІ
	
	-- Якщо зміна трапилась вродовж того самого дня, змінюємо останній рядок
	update t1 
	set
		t1.IsActive	= 0
	from RightHolder t1
		join #SocRightHoldersDeactivated t2 on t1.Id = t2.CurId
	where t1.ValidFrom = dbo.fnCurDate()

	-- Якщо зміна трапилась пізніше того самого дня, змінюємо фінальну дату останнього рядока
	-- і додаємо новий	
	update RightHolder 
	set ValidTo = dbo.fnPrevDate()
	where Id in (select CurId from #SocRightHoldersDeactivated)
		and ValidFrom <> dbo.fnCurDate()

	insert RightHolder (
		  ValidFrom
		, ValidTo
		, CreatedAt
		, CustId
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
		  dbo.fnCurDate()					as ValidFrom
		, dbo.fnMaxDate()			as ValidTo
		, dbo.fnCurDate()					as CreatedAt
		, t2.CustId					as CustId
		, t2.IpBaseNr				as IpBaseNr
		, t2.IpNameNr				as IpNameNr
		, left(t2.Name, 255)		as Name
		, left(t2.FstName, 255)		as FstName
		, left(t2.NameForWid, 255)	as NameForWid
		, left(t2.FstNameForWid, 255) as FstNameForWid
		, t2.IsOwn					as IsOwn
		, 0							as IsActive			
		, t2.HasIpiAgreePer			as HasIpiAgreePer
		, t2.HasIpiAgreeMec			as HasIpiAgreeMec
	from #SocRightHoldersDeactivated t1
		join RightHolder t2 on t1.CurId = t2.Id
	where t2.ValidFrom <> dbo.fnCurDate()

	-- ДОДАЄМО ВІДСУТНІХ ПРАВОВЛАСНИКІВ
	insert RightHolder (
		  ValidFrom
		, ValidTo
		, CreatedAt
		, CustId
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
		  dbo.fnMinDate()					as ValidFrom
		, dbo.fnMaxDate()				as ValidTo
		, dbo.fnCurDate()						as CreatedAt
		, t1.CustId						as CustId
		, t1.IpBaseNr					as IpBaseNr
		, t1.IpNameNr					as IpNameNr
		, left(t1.Name, 255)			as Name
		, left(t1.FstName, 255)			as FstName
		, left(t1.NameForWid, 255)		as NameForWid
		, left(t1.FstNameForWid, 255)	as FstNameForWid
		, t1.IsActive					as IsOwn
		, t1.IsActive					as IsActive
		, t1.HasIpiAgreePer				as HasIpiAgreePer
		, t1.HasIpiAgreeMec				as HasIpiAgreeMec
	from #MsRightHolder t1
		left join #RegisteredCustIds t2 on t1.CustId = t2.CustId
	where t2.CustId is null

	-- ПЕРЕПОСИЛАННЯ ПРАВОВЛАСНИКІВ АКТИВНОГО НА НОВІ ПОТОЧНІ ЗАПИСИ ЗМІНЕНИХ ПРАВОВЛАСНИКІВ
	; with WrongRefs as (
		select t1.RightHolderId as RightHolderId
		from vCurSubmRightHolder t1
			left join vCurRightHolder t2 on t1.RightHolderId = t2.Id
		where t2.Id is null
	)
	update t4
	set t4.RightHolderId = t3.Id
	from WrongRefs t1
		join RightHolder t2 on t1.RightHolderId = t2.Id
		join vCurRightHolder t3 on t2.CustId = t3.CustId
		join vCurSubmRightHolder t4 on t1.RightHolderId = t4.RightHolderId

end
go

-- exec spRightHoldersUpdate
-- select * from RightHolder