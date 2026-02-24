use SocWidSubmit
go

create or alter view vMapMsgToParentWia
as
select t1.Id as RecMsgId, t5.Id as RecWiaId, t1.RespFileId as RespFileId
from RecMsg t1
	join RecAck t2 on t1.TransSeqNr = t2.TransSeqNr
		and t1.RespFileId = t2.RespFileId
	join RecHdrRsp t3 on t2.RespFileId = t3.RespFileId
	join SubmFile t4 on t3.FileNameRef = t4.Name
	join RecWia t5 on t4.Id = t5.SubmFileId
		and t2.SubmWrkNrRef = t5.SubmWrkNr

go

select * from vMapMsgToParentWia

