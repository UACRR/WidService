use SocWidSubmitEx
go

create or alter procedure spCreateInitialSubmission
as
begin

-- Виконується лише для порожньої БД
	if exists (select null from Submission) return

-- Назви файлів
	declare @submFileName nvarchar(max) = (select max(Name) from SocWidSubmit..SubmFile)
	declare @respFileName nvarchar(max) = (select max(Name) from SocWidSubmit..RespFile)

-- Submission
	insert Submission (
		  StartedAt
		, EndedAt
		, SubmFileName
		, RespFileName
		, ErrorFileName
		, SubmissionStatusId
		, CreatedAt
		, UpdatedAt
	)
	select
		  dbo.fnMinDate()	as StartedAt
		, dbo.fnMaxDate()	as EndedAt
		, @submFileName		as SubmFileName
		, @respFileName		as RespFileName
		, ''				as ErrorFileName
		, 6					as SubmissionStatusID -- вершена але не закрита
		, getdate()			as CreatedAt
		, null				as UpdatedAt

-- Видаляємо дані
	--delete from SubmWorkShare
	--delete from SubmWorkAltName
	--delete from SubmWorkPerformer
	--delete from SubmWork
	--delete from SubmRightHolder
	--delete from RightHolder


-- RightHolder
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
	      dbo.fnMinDate()	as ValidFrom		
		, dbo.fnMaxDate()	as ValidTo		
		, getdate()			as CreatedAt		
		, t1.CustId			as CustId	
		, t2.rHolderType	as RhType
		, t2.InterCode		as IpBaseNr		
		, t2.IpiBase		as IpNameNr		
		, t3.Name			as Name			
		, t3.FstName		as FstName		
		, t3.NameForWid		as NameForWid	
		, t3.FstNameForWid	as FstNameForWid	
		, 1					as IsOwn			
		, 1					as IsActive		
		, 1					as HasIpiAgreePer
		, 1					as HasIpiAgreeMec
	from SocWidSubmit..WidSubmGroupParty t1
		join MediaService..RightHolder t2 on t1.CustId = t2.CustId
		join vCustomerNamesForWid t3 on t1.CustId = t3.CustId
	where t1.WidSubmGroupId not in (2014, 2015)


	; with Dist as (
		select distinct CustId, IpBaseNr, IpNameNr, RhType
		from SocWidSubmit..WidSubmGroupWorkShare
		where WidSubmGroupId not in (2014, 2015)
	),
	Res as (
		select CustId, IpBaseNr, IpNameNr, RhType, row_number() over (partition by CustId order by IpBaseNr desc) as SeqNr
		from Dist
	),
	CustomerInfo as (
		select * from Res where SeqNr = 1
	)
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
		  datefromparts(1900, 1, 1)		as ValidFrom		
		, datefromparts(9999, 12, 31)	as ValidTo		
		, getdate()						as CreatedAt		
		, t1.CustId						as CustId	
		, t1.RhType						as RhType
		, t1.IpBaseNr					as IpBaseNr		
		, t1.IpNameNr					as IpNameNr		
		, t2.Name						as Name			
		, t2.FstName					as FstName		
		, t2.NameForWid					as NameForWid	
		, t2.FstNameForWid				as FstNameForWid	
		, 1								as IsOwn			
		, 1								as IsActive		
		, 1								as HasIpiAgreePer
		, 1								as HasIpiAgreeMec
	from CustomerInfo t1
		join vCustomerNamesForWid t2 on t1.CustId = t2.CustId

	--update t1
	--set t1.RhType = t2.rHolderType
	--from RightHolder t1
	--	join MediaService..RightHolder t2 on t1.CustId = t2.CustId

-- select * from RightHolder

-- SubmRightHolder
	insert SubmRightHolder (
		  SubmissionId
		, RightHolderId
		, SubmAsOwn
		, CreatedAt
	)
	select
		  dbo.fnCurSubmId()	as SubmissionId
		, t2.Id				as RightHolderId
		, 1					as SubmAsOwn
		, getdate()			as CreatedAt
--		select * 
	from SocWidSubmit..WidSubmGroupParty t1
		join RightHolder t2 on t1.CustId = t2.CustId
			 and t2.ValidFrom = datefromparts(1900, 1, 1)

--select * from RightHolder

-- SubmWork
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
		  dbo.fnCurSubmId()				as SubmissionId
		, t1.ObjId						as ObjId
		, t2.Wic						as Wic
		, left(isnull(t2.Iswc, ''), 11)	as Iswc
		, isnull(t3.LocalName, '')		as Name
		, isnull(t3.WidName, '')		as NameForWid
		, 0								as IsChanged
		, 7								as Status -- Завершено
		, getdate()						as CreatedAt
		, null							as UpdatedAt
	from SocWidSubmit..WidSubmGroupWork t1
		left join SocWidSubmit..ObjIdToWic t2 on t1.ObjId = t2.ObjId
		left join SocWidSubmit..WidSubmGroupWorkName t3 on t1.ObjId = t3.ObjId -- Дивним чином назви деяких творів втрачено
			and t3.IsMain = 1
			and t3.WidSubmGroupId not in (2014, 2015)
	where t1.Status = 10
		and t1.WidSubmGroupId not in (2014, 2015)

-- Віновлення відсутніх кодів ISWC
	--select * from SubmWork t1 left join SocWid..WidTitle t2 on t1.Wic = t2.Wic where trim(t1.Iswc) = '' and t2.Wic is null
	--    Твори знаходяться але не мають ISWC, так само в ЦизНет
	--    ВІДНОВЛЕННЯ НЕ МОЖЛИВЕ

-- Віновлення відсутніх кодів WIC
	-- select * from SubmWork where Wic is null and Iswc = ''
			-- Для всіх таких творів є код ISWC
	--select * from SubmWork t1 left join SocWid..WIdIswc t2 on t1.Iswc = t2.Iswc	where t1.Wic is null and t1.Iswc <> ''
				-- Твори не знаходяться в локальній ВІД але існують в ЦизНет
	--    ВІДНОВЛЕННЯ НЕ МОЖЛИВЕ НАРАЗІ, АЛЕ ПІСЛЯ ВІДНОВЛЕННЯ ПЕРЛІКАЦІЇ ВІД БУДЕ ЗДІЙСНЕНО ОКРЕМО

-- Віновлення назв в ВІД
	-- select * from SubmWork t1 where t1.Name = ''
	-- Локальні назви завжди присутні

	-- Відновлюємо з кодом WIC
	update t1
	set t1.NameForWid = t2.WrkTtl
	from SubmWork t1
		join SocWid..WidTitle t2 on t1.Wic = t2.Wic
	where t1.NameForWid = ''

	-- select * from SubmWork t1 where t1.NameForWid = ''
	-- Деякі назви не відновились
	-- Твори не знаходяться в локальній ВІД але існують в ЦизНет
	-- select *	from SubmWork t1 join SocWid..WidIswc t2 on t1.Iswc = t2.Iswc where t1.NameForWid = ''
	-- Відновлення за кодом ISWC не дає результату

	-- ВІДНОСЛЮЄМО ШЛЯХОМ ТРАНЗЛІТЕРАЦІЇ
	update SubmWork
	set NameForWid = dbo.ClrTranslitFromUkrToLat(Name)
	from SubmWork
	where NameForWid = ''

	-- select * from SubmWork t1 where t1.NameForWid = ''
	-- НАЗВИ ВІД ВІДНОВЛЕНІ

-- SubmWorkShare
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
		  t2.Id										as SubmWorkId
		, t3.Id										as RightHolderId
		, t1.RhRole									as RhRole
		, dbo.fnGetWidRole(t3.RhType, t1.RhRole)	as RoleForWid
		, t1.PerShr									as ShrPer
		, t1.MecShr									as ShrMec
		, getdate()									as CreatedAt
		, null										as UpdatedAt
	from SocWidSubmit..WidSubmGroupWorkShare t1
		join SubmWork t2 on t1.ObjId = t2.ObjId
		join RightHolder t3 on t1.CustId = t3.CustId
			and t3.ValidFrom = datefromparts(1900, 1, 1)
	where t1.WidSubmGroupId not in (2014, 2015)

-- SubmWorkAltName
	; with AltNames as (
		select
			  WidSubmGroupId						 as WidSubmGroupId
			, ObjId									 as ObjId
			, dbo.ClrTranslitFromUkrToLat(LocalName) as NameForWid
			, LocalName								 as OrigName
		from SocWidSubmit..WidSubmGroupWorkName
	), TargetAltNames as (
		select WidSubmGroupId, ObjId, NameForWid, string_agg(OrigName, '~') as OrigNames
		from AltNames
		where trim(NameForWid) <> trim(OrigName)
		group by WidSubmGroupId, ObjId, NameForWid
	)
	insert SubmWorkAltName (
		  SubmWorkId
		, OrigNames
		, NameForWid
		, CreatedAt
		, UpdatedAt
	)
	select
		  t2.Id								as SubmWorkId
		, t1.OrigNames						as OrigNames
		, dbo.ClrTranslitFromUkrToLat(Name) as NameForWid
		, getdate()							as CreatedAt
		, null								as UpdatedAt
	from TargetAltNames t1
		join SubmWork t2 on t1.ObjId = t2.ObjId
	where t1.WidSubmGroupId not in (2014, 2015)

-- SubmWorkPerformer
	; with Performers as (
		select
			  WidSubmGroupId						 as WidSubmGroupId
			, ObjId									 as ObjId
			, dbo.ClrTranslitFromUkrToLat(LocalName) as NameForWid
			, LocalName								 as OrigName
		from SocWidSubmit..WidSubmGroupWorkPerformer
	), TargetPerformers as (
		select WidSubmGroupId, ObjId, NameForWid, string_agg(OrigName, '~') as OrigNames
		from Performers
		where trim(NameForWid) <> trim(OrigName)
		group by WidSubmGroupId, ObjId, NameForWid
	)
	insert SubmWorkPerformer (
		  SubmWorkId
		, OrigNames
		, NameForWid
		, CreatedAt
		, UpdatedAt
	)
	select
		  t2.Id			as SubmWorkId
		, t1.OrigNames	as Name
		, t1.NameForWid	as NameForWid
		, getdate()		as CreatedAt
		, null			as UpdatedAt
	from TargetPerformers t1
		join SubmWork t2 on t1.ObjId = t2.ObjId
	where t1.WidSubmGroupId not in (2014, 2015)

-- SubmCheckList
	insert SubmCheckList (
        SubmWorkId
      , HasOwnRightHolder
      , RolesDefined
      , HasNonPublisher
      , AllInIpi
      , PubShare0or100
      , MecShare0or100
      , HasShare
      , AllIpiCodesValid
      , IsOk
	)
	select Id, 1, 1, 1, 1, 1, 1, 1, 1, 1
	from SubmWork

-- ============================   NEXT SUBMISSION
	return

	insert Submission (
		  StartedAt
		, EndedAt
		, SubmFileName
		, RespFileName
		, ErrorFileName
		, SubmissionStatusID
		, CreatedAt
		, UpdatedAt
	)
	select
		  dateadd(S, 1, getdate())						as StartedAt
		, cast(datefromparts(9999, 12, 31) as datetime)	as EndedAt
		, ''											as SubmFileName
		, ''											as RespFileName
		, ''											as ErrorFileName
		, 0												as SubmissionStatusID -- початковий
		, getdate()										as CreatedAt
		, null											as UpdatedAt

	declare @nextSubmId int = scope_identity()
	print @nextSubmId

	insert SubmRightHolder (
		  SubmissionId
		, RightHolderId
		, SubmAsOwn
		, CreatedAt
	)
	select
		  @nextSubmId as SubmissionId
		, t1.Id		  as RightHolderId
		, t1.SubmAsOwn	  as SubmAsOwn
		, getdate()   as CreatedAt
--		select * 
	from SubmRightHolder t1
		join RightHolder t2 on t1.RightHolderId = t2.Id
		join vMsRightHoldersActive t3 on t2.CustId = t3.custId
	where SubmissionId = dbo.fnCurSubmId() -- !!!!!!!!!!!!!!!!!!!!!!!!!!!!!

end
go

-- exec spCreateInitialSubmission

