use SocWidSubmit
go

create or alter view vMapMsgToOsr
as
select t1.Id as RecMsgId, t4.Id as RecOsrId
from RecMsg t1
	join vMapMsgToParentWia t2 on t1.Id = t2.RecMsgId
	join RecWia t3 on t2.RecWiaId = t3.Id
	join RecOsr t4 on t3.SubmFileId = t4.SubmFileId
		and t3.GrpSeqNr = t4.GrpSeqNr
		and t3.TransSeqNr = t4.TransSeqNr
		and t1.RecSeqNrRef = t4.RecSeqNr
where t1.RecTypeRef = 'OSR'
go