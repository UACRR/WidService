use SocWidSubmitEx
go

create or alter procedure spCreateInitialSubmission
as
begin

-- Виконується лише для порожньої БД
	if exists (select null from Submission) return

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
		  datefromparts(1900, 1, 1) as StartedAt
		, getdate()					as EndedAt
		, ''						as SubmFileName
		, ''						as RespFileName
		, ''						as ErrorFileName
		, 9						as SubmissionStatusID -- finished
		, getdate()					as CreatedAt
		, null						as UpdatedAt

	declare @submId int = scope_identity()
	print @submId

-- Видаляємо дані
	--delete from SubmWorkShare
	--delete from SubmWorkAltName
	--delete from SubmWorkPerformer
	--delete from SubmWork
	--delete from SubmRightHolder
	--delete from RightHolder
-- RightHolder

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
		  @submId	as SubmissionId
		, t2.Id		as RightHolderId
		, 1			as SubmAsOwn
		, getdate() as CreatedAt
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
		  @submId						as SubmissionId
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

	-- ДЕ МОЖНА ВІДНОВЛЮЄМО НАЗВИ
	update t1
	set
		  t1.Name = t2.Name
		, t1.NameForWid = dbo.ClrTranslitFromUkrToLat(t2.Name)
	from SubmWork t1
		join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
	where t1.Name = ''
		and t2.ObjId is null

	-- ДЕ НЕ ОНОВИЛИ ПРИБИРАЄМО
	delete t1
	from SubmWork t1
		left join MediaService..ObjectRight t2 on t1.ObjId = t2.ObjId
	where t1.Name = ''
		and t2.ObjId is null


--; with DupWorkNames as (
--select objid, count(*) cnt
--	from SocWidSubmit..WidSubmGroupWorkName 
--	where IsMain = 1
--	group by ObjId
--	having count(*) > 1
--)
--select *
--from DupWorkNames t1
--	join SocWidSubmit..WidSubmGroupWorkName t2 on t1.ObjId = t2.ObjId
--		and t2.IsMain = 1
--order by t1.ObjId
--
--
--
--
--
--select t1.ObjId
--from SocWidSubmit..WidSubmGroupWork t1
--		left join SocWidSubmit..WidSubmGroupWorkName t3 on t1.ObjId = t3.ObjId
--			--and t3.IsMain = 1
--	where t1.Status = 10
--		and t1.WidSubmGroupId not in (2014, 2015)
--		and t3.Id is null
--
--select * from MediaService..ObjectRight where ObjId = 891949
--select * from SocWidSubmit..WidSubmGroupWorkName where ObjId = 891949
--
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

-- ============================   NEXT SUBMISSION
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
	where SubmissionId = @submId

end
go

-- exec spCreateInitialSubmission

