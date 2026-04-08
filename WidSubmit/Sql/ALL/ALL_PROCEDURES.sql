use SocWidSubmitEx
go

create or alter procedure spBindRespToSubm
as
begin

	exec spRespFileDataDelete 1

	-- Створюємо посилання на запис, якому відповідає рядок відповіді
	update t2
	set t2.RecWiaWiuId = t1.Id
	--select t2.*
	from vCurSubmRecWiaWiu t1
		join Z_RecAck t2 on t1.RecType = t2.TransTypeRef
			and t1.GrId = t2.GrpSeqNrRef
			and t1.TransSeqNr = t2.TransSeqNrRef

	-- Передаємо в постійну таблицю
	insert RecAck (
			RecWiaWiuId
		  , RecType
		  , TransSeqNr
		  , RecSeqNr
		  , CreDRef
		  , CreTRef
		  , GrpSeqNrRef
		  , TransSeqNrRef
		  , TransTypeRef
		  , WrkTtlRef
		  , SubmWrkNrRef
		  , Iswc
		  , PrcsD
		  , Status
	)
	select 
			RecWiaWiuId
		  , RecType
		  , TransSeqNr
		  , RecSeqNr
		  , CreDRef
		  , CreTRef
		  , GrpSeqNrRef
		  , TransSeqNrRef
		  , TransTypeRef
		  , WrkTtlRef
		  , SubmWrkNrRef
		  , Iswc
		  , PrcsD
		  , Status
	from Z_RecAck

	-- Збираємо перелік інформації у сповіщеннях у таблицю однакових сповіщень
	; with CurMsgList as (
		select distinct MsgType, MsgLevel, ErrCondNr, MsgTxt
		from Z_RecMsg
	)
	insert RecMsgType(MsgType, MsgLevel, ErrCondNr, MsgTxt)
	select t1.*
	from CurMsgList t1
		left join RecMsgType t2 on t1.MsgType = t2.MsgType
			and t1.MsgLevel = t2.MsgLevel
			and t1.ErrCondNr = t2.ErrCondNr
			and t1.MsgTxt = t2.MsgTxt
	where t2.Id is null

	-- Передаємо в постійну таблицю з заміною окремих сповіщень на посилання з таблиці однакових сповіщень
	insert RecMsg (
		  SubmissionId
		, RecType
		, TransSeqNr
		, RecSeqNr
		, RecSeqNrRef
		, RecTypeRef
		, RecMsgTypeId
	)
	select
		  SubmissionId  as SubmissionId
		, RecType		as RecType
		, TransSeqNr	as TransSeqNr
		, RecSeqNr		as RecSeqNr
		, RecSeqNrRef	as RecSeqNrRef
		, RecTypeRef	as RecTypeRef
		, t2.Id         as RecMsgTypeId
	from Z_RecMsg t1
		join RecMsgType t2 on t1.MsgType = t2.MsgType
			and t1.MsgLevel = t2.MsgLevel
			and t1.ErrCondNr = t2.ErrCondNr
			and t1.MsgTxt = t2.MsgTxt

	-- Поєднуємо сповіщення з відповідними надісланими рядками
	drop table if exists #RecMsgIdOldNew
	select t1.Id as OldId,  t2.Id as NewId
	into #RecMsgIdOldNew
	from Z_RecMsg t1
		join vCurSubmRecMsg t2 on t1.TransSeqNr = t2.TransSeqNr
			and t1.RecSeqNr = t2.RecSeqNr

	insert MsgMapRecWiaWiu
	select t4.NewId, t3.Id
	from Z_RecMsg t1
		join Z_RecAck t2 on t1.TransSeqNr = t2.TransSeqNr
		join vCurSubmRecWiaWiu t3 on t2.TransSeqNrRef = t3.TransSeqNr
			and t1.RecSeqNrRef = t3.RecSeqNr
		join #RecMsgIdOldNew t4 on t1.Id = t4.OldId
	where t1.RecTypeRef in ('WIA', 'WIU')

	insert MsgMapRecSipOip
	select t4.NewId, t3.Id
	from Z_RecMsg t1
		join Z_RecAck t2 on t1.TransSeqNr = t2.TransSeqNr
		join vCurSubmRecSipOip t3 on t2.TransSeqNrRef = t3.TransSeqNr
			and t1.RecSeqNrRef = t3.RecSeqNr
		join #RecMsgIdOldNew t4 on t1.Id = t4.OldId
	where t1.RecTypeRef in ('SIP', 'OIP')

	insert MsgMapRecSsrOsr
	select t4.NewId, t3.Id
	from Z_RecMsg t1
		join Z_RecAck t2 on t1.TransSeqNr = t2.TransSeqNr
		join vCurSubmRecSsrOsr t3 on t2.TransSeqNrRef = t3.TransSeqNr
			and t1.RecSeqNrRef = t3.RecSeqNr
		join #RecMsgIdOldNew t4 on t1.Id = t4.OldId
	where t1.RecTypeRef in ('SSR', 'OSR')

	insert MsgMapRecAlt
	select t4.NewId, t3.Id
	from Z_RecMsg t1
		join Z_RecAck t2 on t1.TransSeqNr = t2.TransSeqNr
		join vCurSubmRecAlt t3 on t2.TransSeqNrRef = t3.TransSeqNr
			and t1.RecSeqNrRef = t3.RecSeqNr
		join #RecMsgIdOldNew t4 on t1.Id = t4.OldId
	where t1.RecTypeRef in ('ALT')

	insert MsgMapRecPer
	select t4.NewId, t3.Id
	from Z_RecMsg t1
		join Z_RecAck t2 on t1.TransSeqNr = t2.TransSeqNr
		join vCurSubmRecPer t3 on t2.TransSeqNrRef = t3.TransSeqNr
			and t1.RecSeqNrRef = t3.RecSeqNr
		join #RecMsgIdOldNew t4 on t1.Id = t4.OldId
	where t1.RecTypeRef in ('PER')

end
go

-- exec spBindRespToSubmuse SocWidSubmitEx
go

create or alter procedure spCreateInitialSubmission
as
begin

-- Виконується лише для порожньої БД
	if exists (select null from Submission) return

-- Передаємо в СМАРТ міжнародні коди творів
	update t2
	set t2.Iswc = t1.Iswc
	from SocWidSubmit..ObjIdToWic t1
		join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
	where isnull(t1.Iswc, '') <> ''
		and isnull(t2.Iswc, '') = ''
	
-- Заповнюємо міжнародні коди назв
	update t1
	set t1.IPIBase = t2.IpNameNr
	from MediaService..RightHolder t1
		join SocIpi..IpiName t2 on t1.interCode = t2.IpBaseNr
			and t2.NameType = 'PA'
	where isnull(InterCode, '') <> ''
		and isnull(IpiBase, '') = ''
	
	update t1
	set t1.InterCode = t2.IpBaseNr
	from MediaService..RightHolder t1
		join SocIpi..IpiName t2 on t1.IPIBase = t2.IpNameNr
	where isnull(IpiBase, '') <> ''
		and isnull(InterCode, '') = ''

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
		join vCurRightHolder t2 on t1.CustId = t2.CustId

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
	  , AllIpiCodesExist
      , AllIpiCodesValid
      , IsOk
	)
	select Id, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
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
use SocWidSubmitEx
go

create or alter procedure spCurSubmFileRecsClear
as
begin
	declare @submId int = (select dbo.fnCurSubmId())
	
	delete trl 
	from RecTrl trl
		join RecHdr hdr on trl.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete grt 
	from RecGrt grt
		join RecGrh grh on grt.RecGrhId = grh.Id
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete per 
	from RecPer per
		join RecWiaWiu wiawiu on per.RecWiaWiuId = wiawiu.Id
		join RecGrh grh on wiawiu.RecGrhId = grh.Id 
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete alt 
	from RecAlt alt
		join RecWiaWiu wiawiu on alt.RecWiaWiuId = wiawiu.Id
		join RecGrh grh on wiawiu.RecGrhId = grh.Id 
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete ssrosr
	from RecSsrOsr ssrosr
		join RecSipOip sipoip on ssrosr.RecSipOipId = sipoip.Id
		join RecWiaWiu wiawiu on sipoip.RecWiaWiuId = wiawiu.Id
		join RecGrh grh on wiawiu.RecGrhId = grh.Id 
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete sipoip
	from RecSipOip sipoip
		join RecWiaWiu wiawiu on sipoip.RecWiaWiuId = wiawiu.Id
		join RecGrh grh on wiawiu.RecGrhId = grh.Id 
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete wiawiu
	from RecWiaWiu wiawiu
		join RecGrh grh on wiawiu.RecGrhId = grh.Id 
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete grh
	from RecGrh grh
		join RecHdr hdr on grh.RecHdrId = hdr.Id
	where hdr.SubmissionId = @submId

	delete hdr
	from RecHdr hdr
	where hdr.SubmissionId = @submId

end
go
use SocWidSubmitEx
go

create or alter procedure spCurSubmWorksDelete
	  @objIds dbo.typeObjIds readonly
	, @keepWorks int
as
begin

	delete t3 from @objIds t1 join SubmWork t2 on t1.ObjId = t2.ObjId join SubmCheckList	 t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete t3 from @objIds t1 join SubmWork t2 on t1.ObjId = t2.ObjId join SubmWorksAcceptedHash	 t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete t3 from @objIds t1 join SubmWork t2 on t1.ObjId = t2.ObjId join SubmWorkShare	 t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete t3 from @objIds t1 join SubmWork t2 on t1.ObjId = t2.ObjId join SubmWorkAltName   t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete t3 from @objIds t1 join SubmWork t2 on t1.ObjId = t2.ObjId join SubmWorkPerformer t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	if @keepWorks = 0 delete t2 from @objIds t1 join SubmWork t2 on t1.ObjId = t2.ObjId where t2.SubmissionId = dbo.fnCurSubmId()
end
go

use SocWidSubmitEx
go


create or alter procedure spCurSubmWorksDeleteAll
as
begin

	delete t3 from SubmWork t2 join SubmWorkShare	 t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete t3 from SubmWork t2 join SubmWorkAltName   t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete t3 from SubmWork t2 join SubmWorkPerformer t3 on t2.Id = t3.SubmWorkId	where t2.SubmissionId = dbo.fnCurSubmId()
	delete from SubmWork where SubmissionId = dbo.fnCurSubmId()
end
go

-- exec spCurSubmWorksDeleteAll

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
use SocWidSubmitEx
go

create or alter procedure spRespFileDataDelete
	@skipZTables bit = 0

as
begin
	if @skipZTables = 0
	begin
		truncate table Z_RecAck
		truncate table Z_RecMsg
	end

	delete t1 from RecAck t1 join vCurSubmRecWiaWiu t2 on t1.RecWiaWiuId = t2.Id

	drop table if exists #MsgIds
	select Id into #MsgIds from vCurSubmRecMsg

	delete t1 from MsgMapRecWiaWiu t1 join #MsgIds t2 on t1.RecMsgId = t2.Id
	delete t1 from MsgMapRecSipOip t1 join #MsgIds t2 on t1.RecMsgId = t2.Id
	delete t1 from MsgMapRecSsrOsr t1 join #MsgIds t2 on t1.RecMsgId = t2.Id
	delete t1 from MsgMapRecAlt    t1 join #MsgIds t2 on t1.RecMsgId = t2.Id
	delete t1 from MsgMapRecPer    t1 join #MsgIds t2 on t1.RecMsgId = t2.Id
	delete t1 from RecMsg	       t1 join #MsgIds t2 on t1.Id       = t2.Id

end
go



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
		, t2.rHolderType														as RhType
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
		, t1.RhType					as NewRhType
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
				t1.RhType = t2.RhType
				and	isnull(t1.IpBaseNr, '') = isnull(t2.IpBaseNr, '')
				and isnull(t1.IpNameNr, 0) = isnull(t2.IpNameNr, 0)
				and t1.Name = left(t2.Name, 255)
				and t1.FstName = left(t2.FstName, 255)
				and t1.IsActive = t2.IsActive
				and t1.HasIpiAgreePer = t2.HasIpiAgreePer
				and t1.HasIpiAgreeMec = t2.HasIpiAgreeMec
			)

	-- ЗАСТОСУВАННЯ ЗМІН У НАЯВНИХ ПРАВОВЛАСНИКАХ, ЯКІ АКТИВНІ В СМАРТІ

	-- Якщо зміна трапилась вродовж того самого дня, змінюємо останній рядок
	update t1 
	set
		  t1.RhType			= t2.NewRhType
		, t1.IpBaseNr		= left(t2.NewIpBaseNr, 13)		
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
		  dbo.fnCurDate()					as ValidFrom
		, dbo.fnMaxDate()					as ValidTo
		, dbo.fnCurDate()					as CreatedAt
		, t1.NewCustId						as CustId
		, t1.NewRhType						as RhType
		, left(t1.NewIpBaseNr, 13)			as IpBaseNr
		, t1.NewIpNameNr					as IpNameNr
		, left(t1.NewName, 255)				as Name
		, left(t1.NewFstName, 255)			as FstName
		, left(t1.NewNameForWid, 255)		as NameForWid
		, left(t1.NewFstNameForWid, 255)	as FstNameForWid
		, t1.NewIsOwn						as IsOwn
		, t1.NewIsActive					as IsActive			
		, t2.HasIpiAgreePer					as HasIpiAgreePer
		, t2.HasIpiAgreeMec					as HasIpiAgreeMec
	from #SocRightHoldersChanged t1
		join RightHolder t2 on t1.CurId = t2.Id
	where t2.ValidFrom <> dbo.fnCurDate()

	-- ДОДАЄМО ВІДСУТНІХ ПРАВОВЛАСНИКІВ
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
		  dbo.fnMinDate()				as ValidFrom
		, dbo.fnMaxDate()				as ValidTo
		, dbo.fnCurDate()				as CreatedAt
		, t1.CustId						as CustId
		, t1.RhType						as RhType
		, left(t1.IpBaseNr, 13)			as IpBaseNr
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
use SocWidSubmitEx
go

create or alter procedure spSelectDataForWia
as
begin
	select
		  Id		 as SubmWorkId
		, ObjId	     as ObjId
		, NameForWid as NameForWid
		, Iswc	     as Iswc
		, IsChanged  as IsChanged
	from vCurSubmWorks
	where Status = 1
end
go

use SocWidSubmitEx
go

create or alter procedure spSelectRightHolderCurSubmWorks
	@custId int
	-- Спеціальні значення: 0 - всі створи, -1 -жодного твору
as
begin

	if @custId = 0 -- Вибираємо всі твори
	begin
		select
			  Id          
			, SubmissionId
			, ObjId       
			, Wic
			, Iswc
			, Name        
			, NameForWid	
			, IsChanged
			, Status
		from vCurSubmWorks
		order by Name

		return
	end
	else
	begin
		select
			  t4.Id          
			, t4.SubmissionId
			, t4.ObjId       
			, t4.Wic 
			, t4.Iswc
			, t4.Name        
			, t4.NameForWid	
			, t4.IsChanged
			, t4.Status
		from vCurSubmRightHolder t1
			join RightHolder t2 on t1.RightHolderId = t2.Id
			join SubmWorkShare t3 on t1.RightHolderId = t3.RightHolderId
			join vCurSubmWorks t4 on t3.SubmWorkId = t4.Id
		where t2.CustId = @custId
		order by t4.Name
	end

end
go

-- exec spSelectRightHolderCurSubmWorks -1use SocWidSubmitEx
go

create or alter procedure spSelectRightHoldersForCurSubm
	@submId int
as

	if @submId = dbo.fnCurSubmId() -- ДЛЯ ПОТОЧНОГО СЕАНСУ ОБИРАЄМО РОЗШИРЕНУ ІНФОРМАЦІ
	begin
		-- Коди СМАРТ правовласників, які були включені в сеанси пулікації
		drop table if exists #InSubmRightHoldersPrev
		select distinct t2.CustId
		into #InSubmRightHoldersPrev
		from SubmRightHolder t1
			join RightHolder t2 on t1.RightHolderId = t2.Id
		where t1.SubmissionId <> dbo.fnCurSubmId()

		-- Коди СМАРТ правовласників, які включені в поточний сеанс пулікації
		drop table if exists #InSubmRightHoldersCur
		select distinct t2.CustId
		into #InSubmRightHoldersCur
		from vCurSubmRightHolder t1
			join RightHolder t2 on t1.RightHolderId = t2.Id

		select
			  t1.Id																				as Id		
			, t1.ValidFrom																		as ValidFrom	
			, t1.ValidTo																		as ValidTo	
			, t1.CreatedAt																		as CreatedAt	
			, t1.CustId																			as CustId	
			, t1.IpBaseNr																		as IpBaseNr	
			, t1.IpNameNr																		as IpNameNr	
			, t1.Name																			as Name
			, t1.FstName																		as FstName
			, t1.NameForWid																		as NameForWid
			, t1.FstNameForWid																	as FstNameForWid
			, t1.IsOwn																			as IsOwn
			, t1.IsActive																		as IsActive
			, t1.HasIpiAgreePer																	as HasIpiAgreePer
			, t1.HasIpiAgreeMec																	as HasIpiAgreeMec
			, case when t2.CustId is null then cast(0 as bit) else cast(1 as bit) end 			as IsInCurSubm
			, case when t3.CustId is null then cast(0 as bit) else cast(1 as bit) end			as WasPublished
		from vCurOwnRightHolder t1
			left join #InSubmRightHoldersCur t2 on t1.CustId = t2.CustId
			left join #InSubmRightHoldersPrev t3 on t1.CustId = t3.CustId
	end
	else
	begin -- В іншому разі виводимо лише правовласників відповідного сеансу
		select
			  t2.Id																				as Id		
			, t2.ValidFrom																		as ValidFrom	
			, t2.ValidTo																		as ValidTo	
			, t2.CreatedAt																		as CreatedAt	
			, t2.CustId																			as CustId	
			, t2.IpBaseNr																		as IpBaseNr	
			, t2.IpNameNr																		as IpNameNr	
			, t2.Name																			as Name
			, t2.FstName																		as FstName
			, t2.NameForWid																		as NameForWid
			, t2.FstNameForWid																	as FstNameForWid
			, t2.IsOwn																			as IsOwn
			, t2.IsActive																		as IsActive
			, t2.HasIpiAgreePer																	as HasIpiAgreePer
			, t2.HasIpiAgreeMec																	as HasIpiAgreeMec
			, cast(1 as bit)																	as IsInCurSubm
			, cast(1 as bit)																	as WasPublished
		from SubmRightHolder t1
			join RightHolder t2 on t1.RightHolderId = t2.Id
		where SubmissionId = @submId
	end

go

-- exec spSelectRightHoldersForCurSubm 2

-- select * from vCurOwnRightHolderuse SocWidSubmitEx
go

create or alter procedure spSelectRightHolderSubmWorks
	  @submissionId int
	, @custId int
	-- ‘ЇҐж? «м­? §­ зҐ­­п: 0 - ўб? бвў®аЁ, -1 -¦®¤­®Ј® вў®аг
as
begin

	if @custId = 0 -- ‚ЁЎЁа у¬® ўб? вў®аЁ
	begin
		select
			  Id          
			, SubmissionId
			, ObjId       
			, Wic
			, Iswc
			, Name        
			, NameForWid	
			, IsChanged
			, Status
		from SubmWork
		where SubmissionId = @submissionId
		order by Name

		return
	end
	else
	begin
		select distinct -- ’®© б ¬Ё© Їа ў®ў« б­ЁЄ ў Їа®жҐ­в е ¬®¦Ґ ва ЇЁвЁбм Є?«мЄ  а §
			  t4.Id          
			, t4.SubmissionId
			, t4.ObjId       
			, t4.Wic 
			, t4.Iswc
			, t4.Name        
			, t4.NameForWid	
			, t4.IsChanged
			, t4.Status
		from SubmRightHolder t1
			join RightHolder t2 on t1.RightHolderId = t2.Id
			join SubmWorkShare t3 on t1.RightHolderId = t3.RightHolderId
			join SubmWork t4 on t3.SubmWorkId = t4.Id
		where t2.CustId = @custId
			and t1.SubmissionId = @submissionId
			and t4.SubmissionId = @submissionId
		order by t4.Name
	end

end
go
use SocWidSubmitEx
go

create or alter procedure spSelectSubmWorkShareDiff
	@submWorkId int
as
begin

	declare @curSubmId int = (select SubmissionId from SubmWork where Id = @submWorkId)
	--print @curSubmId
	declare @prevSubmId int = (select dbo.fnPrevSubmIdEx(@curSubmId))
	--print @prevSubmId

	drop table if exists #CurSubmWorkShare
	select t2.ObjId, t3.CustId, t1.*
	into #CurSubmWorkShare
	from SubmWorkShare t1
		join SubmWork t2 on t1.SubmWorkId = t2.Id
		join RightHolder t3 on t1.RightHolderId = t3.Id
	where t2.Id = @submWorkId
	--select * from #CurSubmWorkShare

	drop table if exists #PrevSubmWorkShare

	; with PrevSubmWorkIds as (
		select distinct t3.Id as SubmWorkId
		from #CurSubmWorkShare t1
			join SubmWork t2 on t1.SubmWorkId = t2.Id
			join SubmWork t3 on t2.ObjId = t3.ObjId
				and t3.SubmissionId = @prevSubmId
	)
	select t2.ObjId, t4.CustId, t3.*
	into #PrevSubmWorkShare
	from PrevSubmWorkIds t1
		join SubmWork t2 on t1.SubmWorkId = t2.Id
		join SubmWorkShare t3 on t2.Id = t3.SubmWorkId
		join RightHolder t4 on t3.RightHolderId = t4.Id
	--select * from #PrevSubmWorkShare

	select           
		  t1.SubmWorkId										as CurSubmWorkId   
		, t1.RightHolderId									as CurRightHolderId
		, t3.CustId											as CurRhCustId     
		, t3.IpBaseNr										as CurRhIpBaseNr   
		, t3.IpNameNr										as CurRhIpNameNr   
		, dbo.fnFullName(t3.Name, t3.FstName)				as CurRhName       
		, dbo.fnFullName(t3.NameForWid, t3.FstNameForWid)	as CurRhNameForWid 
		, dbo.fnGetMsRightHolderTypeName(t3.RhType)			as CurRhTypeName   
		, dbo.fnGetMsRightHolderRoleName(t1.RhRole)			as CurRhRoleName   
		, t1.RoleForWid										as CurRhRoleForWid 
		, t3.IsOwn											as CurRhIsOwn      
		, t3.IsActive										as CurRhIsActive   
		, t1.ShrPer											as CurRhShrPer     
		, t1.ShrMec											as CurRhShrMec

		, t2.SubmWorkId										as PrevSubmWorkId   
		, t2.RightHolderId									as PrevRightHolderId
		, t4.CustId											as PrevRhCustId     
		, t4.IpBaseNr										as PrevRhIpBaseNr   
		, t4.IpNameNr										as PrevRhIpNameNr   
		, dbo.fnFullName(t4.Name, t4.FstName)				as PrevRhName       
		, dbo.fnFullName(t4.NameForWid, t4.FstNameForWid)	as PrevRhNameForWid 
		, dbo.fnGetMsRightHolderTypeName(t4.RhType)			as PrevRhTypeName   
		, dbo.fnGetMsRightHolderRoleName(t2.RhRole)			as PrevRhRoleName   
		, t2.RoleForWid										as PrevRhRoleForWid 
		, t4.IsOwn											as PrevRhIsOwn      
		, t4.IsActive										as PrevRhIsActive   
		, t2.ShrPer											as PrevRhShrPer     
		, t2.ShrMec											as PrevRhShrMec
	from #CurSubmWorkShare t1
		full join #PrevSubmWorkShare t2 on t1.ObjId = t2.ObjId
			and t1.CustId = t2.CustId
			and t1.RoleForWid = t2.RoleForWid
		left join RightHolder t3 on t1.RightHolderId = t3.Id
		left join RightHolder t4 on t2.RightHolderId = t4.Id
end
go 

-- exec spSelectSubmWorkShareDiff 15208

use SocWidSubmitEx
go

create or alter procedure spSubmChecklistUpdate
as
begin
	
	-- SubmWorkStatus
	declare @NOT_READY			int = 0
	declare @READY				int = 1
	declare @SUBMITTED			int = 2
	declare @ACCEPTED			int = 3
	declare @ACCEPTED_WARNINGS	int = 4
	declare @REJECTED			int = 5
	declare @APPLIED			int = 6
	declare @COMPLETED			int = 7

	declare @rhTypeRightHolder int = 1
	declare @rhTypeCommunity int = 2
	declare @rhTypePublisher int = 3

	drop table if exists #CheckList
	select 
		   Id    as SubmWorkId
		,  0	 as HasOwnRightHolder
		,  1	 as RolesDefined
		,  0	 as HasNonPublisher
		,  1	 as AllInIpi
		,  0	 as PubShare0or100
		,  0	 as MecShare0or100
		,  0	 as HasShare
		,  1	 as AllIpiCodesExist
		,  1	 as AllIpiCodesValid
		,  0	 as IsOk
	into #CheckList
	from vCurSubmWorks

	drop table if exists #ShareRightHolders
	select 
		  t2.Id as SubmWorkId
		, t3.Id as RightHolderId
		, t3.CustId
		, t3.RhType
		, t1.RhRole
		, t1.RoleForWid
		, t3.IpBaseNr
		, t3.IpNameNr
		, t3.IsOwn
		, t3.IsActive
		, t3.HasIpiAgreePer
		, t3.HasIpiAgreeMec
		, t1.ShrPer
		, t1.ShrMec
	into #ShareRightHolders
	from SubmWorkShare t1
		join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		join vCurRightHolder t3 on t1.RightHolderId = t3.Id

	-- Є автор, що має договри з УАСПП
	; with ValidWorkIds as (
		select distinct SubmWorkId
		from #ShareRightHolders
		where IsOwn = 1
	)
	update t1
	set t1.HasOwnRightHolder = 1
	from #CheckList t1
		join ValidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId

    -- Для всіх автрів/видавців визначені ролі
	; with InvalidWorkIds as (
		select distinct SubmWorkId
		from SubmWorkShare t1
			join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		where t1.RoleForWid = ''
	)
	update t1
	set t1.RolesDefined = 0
	from #CheckList t1
		join InvalidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId

	-- Є правовласники окрім видавців
	; with ValidWorkIds as (
		select distinct SubmWorkId
		from #ShareRightHolders
		where RhType <> @rhTypePublisher

	)
	update t1
	set t1.HasNonPublisher = 1
	from #CheckList t1
		join ValidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId

	-- Всі автори/видавці мають коди IPI
	; with InvalidWorkIds as (
		select distinct SubmWorkId
		from #ShareRightHolders
		where (isnull(IpBaseNr, '') = '' or isnull(IpNameNr, 0) = 0)
			and SubmWorkId = 18384
	)
	update t1
	set t1.AllInIpi = 0
	from #CheckList t1
		join InvalidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId
	-- select * from #CheckList

    -- Сума процентів Пуб нуль або 100
	; with WorkShrPer as (
		select 
			  t2.Id as SubmWorkId
			, sum(ShrPer) as Shr
		from SubmWorkShare t1
			join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		group by t2.Id
	)
	update t1
	set t1.PubShare0or100 = 1
	from #CheckList t1
		join WorkShrPer t2 on t1.SubmWorkId = t2.SubmWorkId
	where t2.Shr = 0 or t2.Shr = 100

    -- Сума процентів Мех нуль або 100
	; with WorkShrMec as (
		select 
			  t2.Id as SubmWorkId
			, sum(ShrMec) as Shr
		from SubmWorkShare t1
			join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		group by t2.Id
	)
	update t1
	set t1.MecShare0or100 = 1
	from #CheckList t1
		join WorkShrMec t2 on t1.SubmWorkId = t2.SubmWorkId
	where t2.Shr = 0 or t2.Shr = 100

	-- Має проценти
	; with WorkTotalShare as (
		select 
			  t2.Id as SubmWorkId
			, sum(ShrPer + ShrMec) as Shr
		from SubmWorkShare t1
			join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		group by t2.Id
	)
	update t1
	set t1.HasShare = 1
	from #CheckList t1
		join WorkTotalShare t2 on t1.SubmWorkId = t2.SubmWorkId
	where t2.Shr > 0
	
	-- Всі автори мають міжнародні коди
	; with InvalidWorkIds as (
		select distinct SubmWorkId
		from #ShareRightHolders
		where isnull(IpBaseNr, '') = '' 
			or isnull(IpNameNr, 0) = 0
	)
	update t1
	set t1.AllIpiCodesExist = 0
	from #CheckList t1
		join InvalidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId

	-- Коди всіх авторів існують в IPI і мають вірний статус (1)
	; with InvalidWorkIds as (
		select t1.SubmWorkId
			, max(case when t3.SttCde is null then 5 else t3.SttCde end) as SttCde
		from #ShareRightHolders t1
			left join SocIpi..IpiBase t2 on t1.IpBaseNr = t2.IpBaseNr
			left join SocIpi..IpiStatus t3 on t2.IpBaseNr = t3.IpBaseNr
		where isnull(t1.IpBaseNr, '') <> ''
		group by t1.SubmWorkId
		having max(case when t3.SttCde is null then 5 else t3.SttCde end) <> 1
	)
	update t1
	set t1.AllIpiCodesValid = 0
	from #CheckList t1
		join InvalidWorkIds t2 on t1.SubmWorkId = t2.SubmWorkId
	
	--  В підсумку
	update #CheckList
	set IsOk = 1
	where 
			HasOwnRightHolder		= 1
		and RolesDefined			= 1
		and HasNonPublisher			= 1
		and AllInIpi				= 1
		and PubShare0or100			= 1
		and MecShare0or100			= 1
		and HasShare				= 1
		and AllIpiCodesExist		= 1
		and AllIpiCodesValid		= 1

	-- Заносимо результати в постійну таблицю
	delete t1
	from SubmCheckList t1
		join SubmWork t2 on t1.SubmWorkId = t2.Id
	where t2.SubmissionId = dbo.fnCurSubmId()

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
	select
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
	from #CheckList

end
go
use SocWidSubmitEx
go

create or alter procedure spSubmClose
as
begin

-- Сперш оновлюємо правовласників
	exec spRightHoldersUpdate

-- Не передані або не прийняті твори
	drop table if exists #NotSubmittedWorkIds
	select Id
	into #NotSubmittedWorkIds
	from vCurSubmWorks
	where Status not in (3, 4)

-- Правовласники поточного сеансу
	drop table if exists #CurSubmRightHolder
	select t1.*, t2.CustId
	into #CurSubmRightHolder
	from vCurSubmRightHolder t1
		join RightHolder t2 on t1.RightHolderId = t2.Id

-- Завершуємо поточний сеанс
	update Submission
	set
		  EndedAt = getdate()
		, SubmissionStatusId = 7
		, UpdatedAt = getdate()
	where id = dbo.fnCurSubmId()

-- Створюємо новий сеанс
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
	values (
		  getdate()			-- StartedAt
		, dbo.fnMaxDate()	-- EndedAt
		, ''				-- SubmFileName
		, ''				-- RespFileName
		, ''				-- ErrorFileName
		, 0					-- SubmissionStatusId
		, getdate()			-- CreatedAt
		, getdate()			-- UpdatedAt
	)

-- Не передані твори переносимо в новий сеанс сеанс
-- Тепер поточним є новий сеанс
	update t1
	set SubmissionId = dbo.fnCurSubmId()
	from SubmWork t1
		join #NotSubmittedWorkIds t2 on t1.Id = t2.Id

-- Переносимо з попереднього сеансу активних на поточну дату правовласників

	-- !!! Слід перепослати правовласників сеансу на НОВИХ історичних правовласників базуючись на ObjId
	-- Твори не перепосилаємо - відбудеться в результаті оновлення творів
	insert SubmRightHolder (
		  SubmissionId
		, RightHolderId
		, SubmAsOwn
		, CreatedAt
	)
	select 
	      dbo.fnCurSubmId() -- SubmissionId
		, t2.Id             -- RightHolderId
		, t1.SubmAsOwn      -- SubmAsOwn
		, getdate()         -- CreatedAt
	from #CurSubmRightHolder t1
		join vCurRightHolder t2 on t1.CustId = t2.CustId
	where t2.IsActive = 1

end
go
use SocWidSubmitEx
go

create or alter procedure spSubmPassIswcToMs
as
begin
	update t2
	set t2.Iswc = t1.Iswc
	from vCurSubmWorks t1
		join MediaService..MediaTrack t2 on t1.ObjId = t2.ObjId
	where isnull(t1.Iswc, '') <> ''
		and isnull(t2.Iswc, '') = ''

	update t2
	set Status = 6
	from vCurSubmWorks t1
		join SubmWork t2 on t1.Id = t2.Id
	where isnull(t1.Iswc, '') <> ''
end
go

use SocWidSubmitEx
go

create or alter procedure spSubmRightHoldersSave
	@guid uniqueidentifier
as
begin
--truncate table Z_SubmRightHolder
--declare @guid uniqueidentifier = 'D4D436D6-6603-4116-B5C6-2DC7541ED33A'
-- select * from Z_SubmRightHolder
-- Видалення
	delete t1
	from SubmRightHolder t1
		join vCurSubmRightHolder t2 on t1.Id = t2.Id
		left join Z_SubmRightHolder t3 on t2.RightHolderId = t3.RightHolderId
			and t3.Guid = @guid
	where t3.RightHolderId is null

-- Оновлення
	update t1
	set t1.SubmAsOwn = t2.SubmAsOwn
	from SubmRightHolder t1
		join Z_SubmRightHolder t2 on t1.RightHolderId = t2.RightHolderId
			and t2.Guid = @guid

-- Додавання
	insert SubmRightHolder(
		SubmissionId
      , RightHolderId
      , SubmAsOwn
      , CreatedAt
	)
	select
		dbo.fnCurSubmId()
      , t2.RightHolderId
      , t2.SubmAsOwn
      , dbo.fnCurDate()
	from vCurSubmRightHolder t1
		right join Z_SubmRightHolder t2 on t1.RightHolderId = t2.RightHolderId
			and Guid = @guid
	where t1.RightHolderId is null

-- Видалення робочої інформації
	delete Z_SubmRightHolder
	where Guid = @guid

end
go

--select * from Z_SubmRightHolder where RightHolderId =  288337use SocWidSubmitEx
go

create or alter procedure spSubmWorkAltNameSelect
	@submWorkId int
as
begin
	select SubmWorkId, NameForWid, OrigNames
	from SubmWorkAltName
	where SubmWorkId = @submWorkId
end
go
use SocWidSubmitEx
go

create or alter procedure spSubmWorksTargetCreate
as
begin
	/*
		Процедура створює в таблицях Z_*** інформацію про твори, якими володіють
		правовласники, включені в поточний сеанс публікації
		ПРОЦЕДУРА ІДЕМПОТЕНТНА - НЕ ЗАЛЕЖИТЬ ВІД ПОПЕРЕДНЬОГО ОПРИЦЮІВАННЯ ІНФОРМАЦІЇ
	*/

	-- ШУКАЄМО ПЕРЕЛІК ObjId ЯКИМИ ВОЛОДІЮТЬ ПРАВОВЛАСНИКИ ПОТОЧНОГО СЕАНСУ ПУБЛІКАЦІЇ
	drop table if exists #ObjIds
	select distinct t3.ObjId
	into #ObjIds
	from vCurSubmRightHolder t1
		join RightHolder t2 on t1.RightHolderId = t2.Id
		join MediaService..CopyRight t3 on t2.CustId = t3.CustId
		join MediaService..MediaTrack t4 on t3.ObjId = t4.ObjId
	
	-- СТВОРЮЄМО ТВОРИ
	drop table if exists #SubmWork
	select
	    t1.ObjId								as ObjId
      , null									as Wic
	  , left(trim(isnull(t1.Iswc, '')), 11)		as Iswc
	  , t1.Name									as Name
      , dbo.ClrTranslitFromUkrToLat(t1.Name)	as NameForWid
	into #SubmWork
	from MediaService..MediaTrack t1
		join #ObjIds t2 on t1.ObjId = t2.ObjId
	where t1.Name is not null -- ЗАПОБІЖНИК, але трапляється

	update t1
	set t1.Wic = t2.Wic
	from #SubmWork t1
		join SocWid..WidIswc t2 on t1.Iswc = t2.Iswc
	where t1.Iswc <> ''
	
	-- СТВОРЮЄМО ПРОЦЕНТИ
	drop table if exists #SubmWorkShare
	select
	      t3.Id										as RightHolderId
		, t2.ObjId									as ObjId
		, t2.roleCode								as RhRole
		, dbo.fnGetWidRole(t3.RhType, t2.roleCode)  as RoleForWid
		, t2.rate									as ShrPer
		, t2.rateMech								as ShrMec
	into #SubmWorkShare
	from #ObjIds t1
		join MediaService..CopyRight t2 on t1.ObjId = t2.ObjId
		join vCurRightHolder t3 on t2.CustId = t3.CustId
	where getdate() between t2.beginDate and t2.endDate	
	
	-- СТВОРЮЄМО АЛЬТЕРНАТИВНІ НАЗВИ
	drop table if exists #SubmWorkAltName

	; with MsAltNames as (
		select distinct t1.ObjId, left(t1.Name, 256) as Name, left(dbo.ClrTranslitFromUkrToLat(t1.Name), 256) as NameForWid
		from MediaService..SeekObject t1
			join #ObjIds t2 on t1.ObjId = t2.ObjId
			join #SubmWork t3 on t1.ObjId = t3.ObjId
		where t1.CodeI = 1
			and trim(t1.Name) <> ''
			and trim(t1.Name) <> trim(t3.Name)
	)
	, AltNames as (
		select ObjId, NameForWid, string_agg(Name, '~') as OrigNames
		from MsAltNames
		where trim(NameForWid) <> trim(Name)
		group by ObjId, NameForWid
	)
	select
		  ObjId		  as ObjId
		, OrigNames	  as OrigNames
		, NameForWid  as NameForWid
	into #SubmWorkAltName
	from AltNames

	-- СТВОРЮЄМО ВИКОНАВЦІВ
	drop table if exists #SubmWorkPerformer

	; with MsPerformers as (
		select distinct t1.ObjId, left(t1.Name, 256) as Name, left(dbo.ClrTranslitFromUkrToLat(t1.Name), 256) as NameForWid
		from MediaService..SeekObject t1
			join #ObjIds t2 on t1.ObjId = t2.ObjId
		where t1.CodeI = 2
			and trim(t1.Name) <> ''
	)
	, Performers as (
		select ObjId, NameForWid, string_agg(Name, '~') as OrigNames
		from MsPerformers
		where trim(NameForWid) <> trim(Name)
		group by ObjId, NameForWid
	)
	select
		  ObjId		  as ObjId
		, OrigNames	  as OrigNames
		, NameForWid  as NameForWid
	into #SubmWorkPerformer
	from Performers

	-- ПРИБИРАЄМО РОБОЧІ ДАНІ
	exec spZ_SubmWorksDeleteAll

	-- ПЕРЕДАЄМО В РОБОЧІ ТАБЛИЦІ
	insert Z_SubmWork (
		   SubmissionId
		,  ObjId
		,  Wic
		,  Iswc
		,  Name
		,  NameForWid
		,  IsChanged
		,  CreatedAt
		,  UpdatedAt
	)
	select
		   0						as SubmissionId
		,  ObjId					as ObjId
		,  Wic						as Wic
		,  Iswc						as Iswc
		,  left(Name, 256)			as Name
		,  left(NameForWid, 256)	as NameForWid
		,  0						as IsChanged
		,  getdate()				as CreatedAt
		,  null						as UpdatedAt
	from #SubmWork

	insert Z_SubmWorkShare (
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
	    t1.Id as SubmWorkId
      , t2.RightHolderId as RightHolderId
      , t2.RhRole as RhRole
      , t2.RoleForWid as RoleForWid
      , t2.ShrPer as ShrPer
      , t2.ShrMec as ShrMec
      , getdate() as CreatedAt
      , null as UpdatedAt
	from Z_SubmWork t1
		join #SubmWorkShare t2 on t1.ObjId = t2.ObjId

	insert Z_SubmWorkAltName (
	    SubmWorkId
      , OrigNames
      , NameForWid
      , CreatedAt
      , UpdatedAt
	)
	select
	    t1.Id			as SubmWorkId
      , t2.OrigNames	as OrigNames
      , t2.NameForWid	as NameForWid
      , getdate()		as CreatedAt
      , null			as UpdatedAt
	from Z_SubmWork t1
		join #SubmWorkAltName t2 on t1.ObjId = t2.ObjId

	insert Z_SubmWorkPerformer (
	    SubmWorkId
      , OrigNames
      , NameForWid
      , CreatedAt
      , UpdatedAt
	)
	select
	    t1.Id			as SubmWorkId
      , t2.OrigNames	as OrigNames
      , t2.NameForWid	as NameForWid
      , getdate()		as CreatedAt
      , null			as UpdatedAt
	from Z_SubmWork t1
		join #SubmWorkPerformer t2 on t1.ObjId = t2.ObjId

	-- СТВОРЮЄМО ХЕШ ДЛЯ ТВОРІВ В РОБОЧИХ ТАБЛИЦЯХ
	exec spZ_SubmWorksHashUpdate
end

-- exec spSubmWorksTargetCreate
-- select * from Z_SubmWorkuse SocWidSubmitEx
go

create or alter procedure spSubmWorksUpdate
as
begin

	/*
		Змінює твори поточного сеансу базуючись на поточних даних із СМАРТ
	*/

	-- ПРИБИРАЄМО ЗАПИСИ ЯКІ ВИНИКЛИ ПРИ СТВОРЕННІ ФАЙЛУ ДЛЯ ПУБЛІКАЦІЇ
	exec spCurSubmFileRecsClear

	-- СПЕРШ ОНОВЛЮЄМО ПРАВОВЛАСНИКІВ
	exec spRightHoldersUpdate

	-- ПЕРЕПОСИЛАЄМО ПРАВОВЛАСНИКІВ ПОТОЧНОГО СЕАНСУ НА ОСТАННІХ В ІСТОРІЇ
	update t1
	set t1.RightHolderId = t4.Id
	-- select *
	from SubmRightHolder t1
		join vCurSubmRightHolder t2 on t1.Id = t2.Id
		join RightHolder t3 on t1.RightHolderId = t3.Id
		join vCurRightHolder t4 on t3.CustId = t4.CustId

	-- ПЕРЕПОСИЛАЄМО ПРОЦЕНТИ ПОТОЧНОГО СЕАНСУ НА ОСТАННІХ В ІСТОРІЇ ПРАВОВЛАСНИКІВ
	update t1
	set t1.RightHolderId = t4.Id
	-- select *
	from SubmWorkShare t1
		join vCurSubmWorks t2 on t1.SubmWorkId = t2.Id
		join RightHolder t3 on t1.RightHolderId = t3.Id
		join vCurRightHolder t4 on t3.CustId = t4.CustId
	
	-- СТВОРЮЄМО В РОБОЧИХ ТАБЛИЦЯХ ПОТОЧНІ ДАНІ ІЗ СМАРТ
	exec spSubmWorksTargetCreate

	-- СТВОРЮЄМО ХЕШ ДЛЯ ОСТАННЬОЇ УСПІШНО ОПУБЛІКОВАНОЇ ІНФОРМАЦІЇ 
	exec spWorksAcceptedHashUpdate

	-- ТВОРИ ПОПЕРЕДНЬОГО СЕАНСУ, ЯКІ НЕ ЗАЗНАЛИ ЗМІН
	drop table if exists #UnChangedObjIds
	select t2.ObjId
	into #UnChangedObjIds
	from SubmWorksAcceptedHash t1
		join Z_SubmWorkHash t2 on t1.ObjId = t2.ObjId
	where t1.HashValue = t2.HashValue

	-- ВИДАЛЯЄМО ТВОРИ ПОТОЧНОГО СЕАНТУ ЯКИХ НЕМАЄ СЕРЕД ТВОРІВ ДЛЯ ПОТОЧНОЇ ПЕРЕДАЧІ В РОБОЧИХ ТАБЛИЦЯХ
	declare @objIdsToDelete1 as dbo.typeObjIds
	insert @objIdsToDelete1 (ObjId)
	select t1.ObjId
	from SubmWork t1
		left join Z_SubmWork t2 on t1.ObjId = t2.ObjId
	where t1.SubmissionId = dbo.fnCurSubmId()
		and t2.ObjId is null
	exec spCurSubmWorksDelete @objIds = @objIdsToDelete1, @keepWorks = 0
	delete from @objIdsToDelete1

	-- ВИДАЛЯЄМО ТВОРИ ПОТОЧНОГО СЕАНТУ ЯКІ НЕ ЗАЗНАЛИ ЗМІН
	declare @objIdsToDelete2 as dbo.typeObjIds
	insert @objIdsToDelete2 (ObjId) select ObjId from #UnChangedObjIds
	exec spCurSubmWorksDelete @objIds = @objIdsToDelete2, @keepWorks = 0

	-- ТАК САМО РОБИМО ДЛЯ РОБОЧИХ ТАБЛИЦЬ
	exec spZ_SubmWorksDelete @objIds = @objIdsToDelete2, @keepWorks = 0
	delete from @objIdsToDelete2

	-- ВИДАЛЯЄМО СУПУТНЮ ІНФОРМАЦІЮ ІЗ ТВОРІВ ПОТОЧНОГО СЕАНСУ ЯКІ ЗАЛИШИЛИСЬ
	declare @objIdsToDelete3 as dbo.typeObjIds
	insert @objIdsToDelete3 (ObjId) select ObjId from vCurSubmWorks
	exec spCurSubmWorksDelete @objIds = @objIdsToDelete3, @keepWorks = 1
	delete from @objIdsToDelete3

	-- ЗМІНЮЄМО ТВОРИ ПОТОЧНОГО СЕАНСУ
	update t1
	set
		  t1.Wic			= t2.Wic
		, t1.Iswc			= t2.Iswc
		, t1.Name			= t2.Name
		, t1.NameForWid		= t2.NameForWid
--		, t1.IsChanged		= 1 Статус лидишаємо без змін
--		, t1.CreatedAt		= t2.CreatedAt
		, t1.UpdatedAt		= getdate()
	from SubmWork t1
		join Z_SubmWork t2 on t1.ObjId = t2.ObjId
	where t1.SubmissionId = dbo.fnCurSubmId()

	-- ДОДАЄМО ДО ПОТОЧНОГО СЕАНСУ  ТВОРИ ЯКИХ НЕ БУЛО В ПОПЕРЕДНІХ СЕАНСАХ
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
		  dbo.fnCurSubmId()		SubmissionId
		, t1.ObjId				ObjId
		, t1.Wic				Wic
		, t1.Iswc				Iswc		
		, t1.Name				Name		
		, t1.NameForWid			NameForWid
		, 0						IsChanged
		, 0						Status
		, t1.CreatedAt			CreatedAt	
		, t1.UpdatedAt			UpdatedAt
	from Z_SubmWork t1
		left join SubmWork t2 on t1.ObjId = t2.ObjId
			and t2.SubmissionId = dbo.fnCurSubmId()
		left join SubmWorksAcceptedHash t3 on t1.ObjId = t3.ObjId
	where t2.ObjId is null
		and t3.ObjId is null

	-- ДОДАЄМО ДО ПОТОЧНОГО СЕАНСУ ТВОРИ, ЯКІ ЗАЗНАЛИ ЗМІН ВІДНОСНО ОСТАННЬОГО СЕАНСУ
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
		  dbo.fnCurSubmId()		SubmissionId
		, t1.ObjId				ObjId
		, t1.Wic				Wic
		, t1.Iswc				Iswc		
		, t1.Name				Name		
		, t1.NameForWid			NameForWid
		, 1						IsChanged
		, 0						Status
		, t1.CreatedAt			CreatedAt	
		, t1.UpdatedAt			UpdatedAt	
	from Z_SubmWork t1
		left join SubmWork t2 on t1.ObjId = t2.ObjId
			and t2.SubmissionId = dbo.fnCurSubmId()
		join Z_SubmWorkHash t3 on t1.ObjId = t3.ObjId
		join SubmWorksAcceptedHash t4 on t1.ObjId = t4.ObjId
			and t3.HashValue <> t4.HashValue
	where t2.ObjId is null

	-- ДОДАЄМО SubmWorkShare
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
		t1.Id
      , t3.RightHolderId
      , t3.RhRole
      , t3.RoleForWid
      , t3.ShrPer
      , t3.ShrMec
      , getdate()
      , null
	from SubmWork t1
		join Z_SubmWork t2 on t1.ObjId = t2.ObjId
		join Z_SubmWorkShare t3 on t2.Id = t3.SubmWorkId
	where t1.SubmissionId = dbo.fnCurSubmId()

	-- ДОДАЄМО SubmWorkAltName
	insert SubmWorkAltName (
	    SubmWorkId
      , OrigNames
      , NameForWid
      , CreatedAt
      , UpdatedAt
	)
	select
		t1.Id
      , t3.OrigNames
      , t3.NameForWid
      , getdate()
      , null
	from SubmWork t1
		join Z_SubmWork t2 on t1.ObjId = t2.ObjId
		join Z_SubmWorkAltName t3 on t2.Id = t3.SubmWorkId
	where t1.SubmissionId = dbo.fnCurSubmId()

	-- ДОДАЄМО SubmWorkPerformer
	insert SubmWorkPerformer (
	   SubmWorkId
      , OrigNames
      , NameForWid
      , CreatedAt
      , UpdatedAt
	)
	select
		t1.Id
      , t3.OrigNames
      , t3.NameForWid
      , getdate()
      , null
	from SubmWork t1
		join Z_SubmWork t2 on t1.ObjId = t2.ObjId
		join Z_SubmWorkPerformer t3 on t2.Id = t3.SubmWorkId
	where t1.SubmissionId = dbo.fnCurSubmId()
	
	-- ПРИБИРАЄМО РОБОЧІ ДАНІ
	--exec spZ_SubmWorksDeleteAll

	-- ВИКОНУЄМО ДОДАТКОВІ ДІЇ
	--exec spUpdateObjIdToWicIswcFromMs
	exec spSubmChecklistUpdate
	exec spSubmWorksUpdatePostProc
end

-- exec spSubmWorksUpdate
-- select * from Z_SubmWorkuse SocWidSubmitEx
go

create or alter procedure spSubmWorksUpdateFromResp
as
begin
	update t3
	set
		  t3.Iswc   = t1.Iswc
		, t3.Status = dbo.fnSubmWorkStatusFromAck(t1.Status)
	from RecAck t1
		join RecWiaWiu t2 on t1.RecWiaWiuId = t2.Id
		join SubmWork t3 on t2.SubmWorkId = t3.Id
	where t3.SubmissionId = dbo.fnCurSubmId()

	update t1
	set t1.Wic = t2.Wic
	from SubmWork t1
		join SocWid..WidIswc t2 on t1.Iswc = t2.Iswc
	where t1.SubmissionId = dbo.fnCurSubmId()
		and isnull(t1.Iswc, '') <> ''
		and isnull(t1.Wic, 0) = 0

end
go
use SocWidSubmitEx
go

create or alter procedure spSubmWorksUpdatePostProc
as
begin

	if (select SubmissionStatusId from Submission where Id = dbo.fnCurSubmId()) >= 3 /* SUBM_FILE_UPLOADED*/
		throw 0, 'Операція неможлива після передачі творів в ВІД', 0;

-- Твори що мають ISWC передаємо я змінені
	update SubmWork
	set IsChanged = 1
	where SubmissionId = dbo.fnCurSubmId()
		and isnull(Iswc, '') <> ''

-- Плануємо до передачі твори, що не містять помилок

	update t1
	set t1.Status = 0
	from SubmWork t1
		join vCurSubmWorks t2 on t1.Id = t2.Id

	; with ReadyToSubm as (
		select t1.Id
		from SubmWork t1
			join vCurSubmWorks t2 on t1.Id = t2.Id
			join SubmCheckList t3 on t2.Id = t3.SubmWorkId
		where t3.IsOk = 1
	)
	update t1
	set t1.Status = 1
	from SubmWork t1
		join ReadyToSubm t2 on t1.Id = t2.Id
	
end
go
use SocWidSubmitEx
go

create or alter procedure spSubmWorksUpdatePostProc
as
begin

	if (select SubmissionStatusId from Submission where Id = dbo.fnCurSubmId()) >= 3 /* SUBM_FILE_UPLOADED*/
		throw 0, 'Операція неможлива після передачі творів в ВІД', 0;

-- Твори що мають ISWC передаємо я змінені
	update SubmWork
	set IsChanged = 1
	where SubmissionId = dbo.fnCurSubmId()
		and isnull(Iswc, '') <> ''

-- Плануємо до передачі твори, що не містять помилок

	update t1
	set t1.Status = 0
	from SubmWork t1
		join vCurSubmWorks t2 on t1.Id = t2.Id

	; with ReadyToSubm as (
		select t1.Id
		from SubmWork t1
			join vCurSubmWorks t2 on t1.Id = t2.Id
			join SubmCheckList t3 on t2.Id = t3.SubmWorkId
		where t3.IsOk = 1
	)
	update t1
	set t1.Status = 1
	from SubmWork t1
		join ReadyToSubm t2 on t1.Id = t2.Id
	
end
go
use SocWidSubmitEx
go

create or alter procedure spWorksAcceptedHashUpdate
as
begin
    drop table if exists #WorkHash
	create table #WorkHash (
		  SubmWorkId int
		, ObjId int
		, HashString nvarchar(max)
	)

	insert #WorkHash (SubmWorkId, ObjId, HashString)
	select Id, ObjId, NameForWid
	from vSubmWorksAccepted

	drop table if exists #NamesHash
	; with DistinctAltNames as (
		select distinct t1.SubmWorkId, t2.ObjId, t1.NameForWid
		from SubmWorkAltName t1
			join vSubmWorksAccepted t2 on t1.SubmWorkId = t2.Id
	)
	select t1.SubmWorkId, string_agg(t2.NameForWid, '|') within group (order by t2.ObjId, t2.NameForWid asc) as HashString
	into #NamesHash
	from #WorkHash t1
		join DistinctAltNames t2 on t1.SubmWorkId = t2.SubmWorkId
	group by t1.SubmWorkId

	--select * from #NamesHash t1 join SubmWork t2 on t1.SubmWorkId = t2.Id where ObjId = 2541
--	select * from SubmWork where Id in (56,	57)
--	select * from #WorkHash where SubmWorkId in (56,	57)
	
	drop table if exists #PerformersHash
	; with DistinctPerformers as (
		select distinct t1.SubmWorkId, t2.ObjId, t1.NameForWid
		from SubmWorkPerformer t1
			join SubmWork t2 on t1.SubmWorkId = t2.Id
	)
	select t1.SubmWorkId, string_agg(t2.NameForWid, '|') within group (order by t2.ObjId, t2.NameForWid asc) as HashString
	into #PerformersHash
	from #WorkHash t1
		join DistinctPerformers t2 on t1.SubmWorkId = t2.SubmWorkId
	group by t1.SubmWorkId

	--select * from #PerformersHash t1 join SubmWork t2 on t1.SubmWorkId = t2.Id where ObjId = 2541

	drop table if exists #SharesHash
	select t1.SubmWorkId, string_agg(
		concat(t3.CustId, '|', t3.IpBaseNr, '|', t3.IpNameNr, '|', t3.RhType, '|', t2.RhRole, '|', t2.ShrPer, '|', t2.ShrMec)
			, '|') 
		within group (order by t3.CustId, t3.RhType, t2.RhRole) as HashString
	into #SharesHash
	from #WorkHash t1
		left join SubmWorkShare t2 on t1.SubmWorkId = t2.SubmWorkId
	    left join RightHolder t3 on t2.RightHolderId = t3.Id
	group by t1.SubmWorkId

	--select * from #SharesHash t1 join SubmWork t2 on t1.SubmWorkId = t2.Id where ObjId = 2541

	update t1
	set HashString = concat(t1.HashString, '|', t2.HashString)
	from #WorkHash t1
		left join #SharesHash t2 on t1.SubmWorkId = t2.SubmWorkId
	
	
	delete from SubmWorksAcceptedHash
	
	insert SubmWorksAcceptedHash (
		  SubmWorkId
		, ObjId
		, HashValue
		, CreatedAt
	)
	select SubmWorkId
		, ObjId
		, HashString
		, getdate()
	from #WorkHash

	drop table #WorkHash
end

-- spWorksAcceptedHashUpdate

--select * from SocWidSubmit..WidSubmGroupWork where WidSubmGroupId not in (2014, 2015) and Status = 10
--select * from SubmWorkHash order by HashValue

--select * from SocWidSubmit..WidSubmGroupWorkShare where ObjId = 2541
--select * from SocWidSubmit..WidSubmGroupWorkName where ObjId = 918699
--select * from SubmWork where Id = 6819

--select * from SubmWork where Name = ''use SocWidSubmitEx
go

create or alter procedure spZ_SubmWorksDelete
	  @objIds dbo.typeObjIds readonly
	, @keepWorks int
as
begin

	delete t3 from @objIds t1 join Z_SubmWork t2 on t1.ObjId = t2.ObjId join Z_SubmWorkHash	     t3 on t2.Id = t3.SubmWorkId
	delete t3 from @objIds t1 join Z_SubmWork t2 on t1.ObjId = t2.ObjId join Z_SubmWorkShare	 t3 on t2.Id = t3.SubmWorkId
	delete t3 from @objIds t1 join Z_SubmWork t2 on t1.ObjId = t2.ObjId join Z_SubmWorkAltName   t3 on t2.Id = t3.SubmWorkId
	delete t3 from @objIds t1 join Z_SubmWork t2 on t1.ObjId = t2.ObjId join Z_SubmWorkPerformer t3 on t2.Id = t3.SubmWorkId
	if @keepWorks = 0 delete t2 from @objIds t1 join Z_SubmWork t2 on t1.ObjId = t2.ObjId   
end
go
use SocWidSubmitEx
go

create or alter procedure spZ_SubmWorksDeleteAll
as
begin
	delete from Z_SubmWorkHash
	delete from Z_SubmWorkShare
	delete from Z_SubmWorkAltName
	delete from Z_SubmWorkPerformer
	delete from Z_SubmWork
end
go
use SocWidSubmitEx
go

create or alter procedure spZ_SubmWorksHashUpdate
as
begin
	drop table if exists #WorkHash
	create table #WorkHash (
		  SubmWorkId int
		, ObjId int
		, HashString nvarchar(max)
	)

	insert #WorkHash (	SubmWorkId, ObjId, HashString)
	select				Id,         ObjId, NameForWid
	from Z_SubmWork

	declare @compacChech bit = 1
	if @compacChech = 0
	begin
	
		drop table if exists #NamesHash
		; with DistinctAltNames as (
			select distinct t1.SubmWorkId, t2.ObjId, t1.NameForWid
			from Z_SubmWorkAltName t1
				join Z_SubmWork t2 on t1.SubmWorkId = t2.Id
		)
		select t1.SubmWorkId, string_agg(t2.NameForWid, '|') within group (order by t2.ObjId, t2.NameForWid asc) as HashString
		into #NamesHash
		from #WorkHash t1
			join DistinctAltNames t2 on t1.SubmWorkId = t2.SubmWorkId
		group by t1.SubmWorkId

		--select * from #NamesHash t1 join SubmWork t2 on t1.SubmWorkId = t2.Id where ObjId = 2541
	--	select * from SubmWork where Id in (56,	57)
	--	select * from #WorkHash where SubmWorkId in (56,	57)
	
		drop table if exists #PerformersHash
		; with DistinctPerformers as (
			select distinct t1.SubmWorkId, t2.ObjId, t1.NameForWid
			from Z_SubmWorkPerformer t1
				join Z_SubmWork t2 on t1.SubmWorkId = t2.Id
		)
		select t1.SubmWorkId, string_agg(t2.NameForWid, '|') within group (order by t2.ObjId, t2.NameForWid asc) as HashString
		into #PerformersHash
		from #WorkHash t1
			join DistinctPerformers t2 on t1.SubmWorkId = t2.SubmWorkId
		group by t1.SubmWorkId

		--select * from #PerformersHash t1 join SubmWork t2 on t1.SubmWorkId = t2.Id where ObjId = 2541
	end

	drop table if exists #SharesHash
	select t1.SubmWorkId, string_agg(
		concat(t3.CustId, '|', t3.IpBaseNr, '|', t3.IpNameNr, '|', t3.RhType, '|', t2.RhRole, '|', t2.ShrPer, '|', t2.ShrMec)
			, '|') 
		within group (order by t3.CustId, t3.RhType, t2.RhRole) as HashString
	into #SharesHash
	from #WorkHash t1
		left join Z_SubmWorkShare t2 on t1.SubmWorkId = t2.SubmWorkId
	    left join RightHolder t3 on t2.RightHolderId = t3.Id
	group by t1.SubmWorkId


	--select * from #SharesHash t1 join SubmWork t2 on t1.SubmWorkId = t2.Id where ObjId = 2541

	update t1
	set HashString = concat(t1.HashString, '|', t2.HashString) --, '|', t3.HashString, '|', t4.HashString)
	from #WorkHash t1
		left join #SharesHash t2 on t1.SubmWorkId = t2.SubmWorkId
		--left join #NamesHash t3 on t1.SubmWorkId = t3.SubmWorkId
		--left join #PerformersHash t4 on t1.SubmWorkId = t4.SubmWorkId

	delete t1
	from Z_SubmWorkHash t1
		join Z_SubmWork t2 on t1.SubmWorkId = t2.Id
	
	insert Z_SubmWorkHash (
		  SubmWorkId
		, ObjId
		, HashValue
		, CreatedAt
	)
	select SubmWorkId
		, ObjId
		, HashString
		, getdate()
	from #WorkHash

	drop table #WorkHash
end
go

-- exec spZ_SubmWorksHashUpdate
-- select * from Z_SubmWorkHash

use SocWidSubmitEx
go

create or alter procedure spSelectRightHolderSubmWorks
	  @submissionId int
	, @custId int
	-- Спеціальні значення: 0 - всі створи, -1 -жодного твору
as
begin

	if @custId = 0 -- Вибираємо всі твори
	begin
		select
			  Id          
			, SubmissionId
			, ObjId       
			, Wic
			, Iswc
			, Name        
			, NameForWid	
			, IsChanged
			, Status
		from SubmWork
		where SubmissionId = @submissionId
		order by Name

		return
	end
	else
	begin
		select
			  t4.Id          
			, t4.SubmissionId
			, t4.ObjId       
			, t4.Wic 
			, t4.Iswc
			, t4.Name        
			, t4.NameForWid	
			, t4.IsChanged
			, t4.Status
		from SubmRightHolder t1
			join RightHolder t2 on t1.RightHolderId = t2.Id
			join SubmWorkShare t3 on t1.RightHolderId = t3.RightHolderId
			join SubmWork t4 on t3.SubmWorkId = t4.Id
		where t2.CustId = @custId
			and t4.SubmissionId = @submissionId
		order by t4.Name
	end

end
go

-- exec spSelectRightHolderCurSubmWorks -1