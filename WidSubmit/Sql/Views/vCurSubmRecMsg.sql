use SocWidSubmitEx
go

create or alter view vCurSubmRecMsg
as
	select
		  t1. Id
		, t1.SubmissionId
		, t1.RecType
		, t1.TransSeqNr
		, t1.RecSeqNr
		, t1.RecTypeRef
		, t2.MsgType
		, t2.MsgLevel
		, t2.ErrCondNr
		, t2.MsgTxt
	from RecMsg t1
		join RecMsgType t2 on t1.RecMsgTypeId = t2.Id
	where SubmissionId = dbo.fncurSubmId()
go

