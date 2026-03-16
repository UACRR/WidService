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

-- exec spBindRespToSubm